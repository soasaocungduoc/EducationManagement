﻿using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EducationManagement.Dtos.InputDtos;
using EM.Database.Schema;
using MoreLinq;

namespace EducationManagement.Services.Implementations
{
    public class SubjectMarkService : ISubjectMarkService
    {
        private readonly DataContext db = new DataContext();

        public bool Add(SubjectMarkDto dto)
        {
            if(dto == null)
            {
                return false;
            }

            if (dto.Marks == null)
            {
                return false;
            }

            if(CheckEndMarkFromDto(dto) == false)
            {
                return false;
            }

            try
            {
                var subjectMarks = new List<SubjectMark>();

                foreach (MarkDto mark in dto.Marks)
                {
                    if (mark.TypeMarkId == 4)
                    {
                        if (CheckEndMarkFromDb(mark.StudentId, dto.SubjectId) == true)
                        {
                            return false;
                        }
                    }
                    var subjectMark = new SubjectMark()
                    {
                        SubjectId = dto.SubjectId,
                        SemesterId = dto.SemesterId,
                        StudentId = mark.StudentId,
                        TypeMarkId = mark.TypeMarkId,
                        Mark = mark.Mark
                    };

                    subjectMarks.Add(subjectMark);
                }

                db.SubjectMarks.AddRange(subjectMarks);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            
            return true;
        }

        private bool CheckEndMarkFromDb(int studentId, int subjectId)
        {
            var subjectMarkFromDb = db.SubjectMarks
                .FirstOrDefault(x => x.StudentId == studentId && x.TypeMarkId == 4 && x.SubjectId == subjectId && x.DelFlag == false);

            if(subjectMarkFromDb == null)
            {
                return false;
            }

            return true;
        }

        private bool CheckEndMarkFromDto(SubjectMarkDto dto)
        {
            var EndMarks = dto.Marks.Where(x => x.TypeMarkId == 4);

            var dupes = EndMarks.GroupBy(x => new { x.TypeMarkId, x.StudentId })
                   .Where(x => x.Skip(1).Any()).ToArray();
            
            if(dupes.Length == 0)
            {
                return true;
            }

            return false;
        }

        public List<SubjectMarkResponseDto> GetSubjectMarks(int userId, int semesterId)
        {
            var student = db.Students.FirstOrDefault(x => !x.DelFlag && x.UserId == userId);
            if (student == null) return null;
            var list = new List<SubjectMarkResponseDto>();

            list = db.Subjects.Where(x => !x.DelFlag && (!x.Name.Equals("Sinh hoạt") && !x.Name.Equals("Chào cờ"))).ToList()
               .Select(x => new SubjectMarkResponseDto
                {
                    SubjectName = x.Name,
                    ListMark = GetMarkList(student.Id, x.Id, semesterId)
                }).ToList();
            return list;
        }

        public List<MarkResponseDto> GetMarkList(int studentId, int subjectId, int semesterId)
        {
            var list = db.SubjectMarks.Include(u => u.TypeMark)
                    .Where(x => !x.DelFlag && x.StudentId == studentId && x.SubjectId == subjectId && x.SemesterId == semesterId)
                    .OrderBy(x => x.TypeMarkId).Select(x => new MarkResponseDto
                    {
                        Id = x.Id,
                        Mark = x.Mark,
                        TypeMark = x.TypeMark.Name
                    }).ToList();
            return list ?? new List<MarkResponseDto>();
        }

        public List<StudentInfoForViewMark> GetStudentInClass(int classId, int semesterId, int subjectId)
        {
            var list = db.Students.Include(x => x.User).ToList().Where(x => !x.DelFlag && x.ClassId == classId)
                 .Select(x => new StudentInfoForViewMark
                 {
                     StudentId = x.Id,
                     StudentName = x.User.LastName + x.User.FirstName,
                     Marks = GetMarkList(x.Id, subjectId, semesterId)
                 }).ToList();

            return list ?? new List<StudentInfoForViewMark>();
        }

        public MarkInTeachingClassResponseDto GetMarksInClass(int classId, int semesterId, int userId)
        {
            //Kiểm tra giáo viên có trong db không
            var teacher = db.Teachers.FirstOrDefault(x => !x.DelFlag && x.UserId == userId);
            if (teacher == null) return null;

            //Kiểm tra lớp có trong db không
            var Class = db.Classes.FirstOrDefault(x => !x.DelFlag && x.Id == classId);
            if (Class == null) return null;

            var result = new MarkInTeachingClassResponseDto();
            result.ClassName = Class.Name;
            
            //Lấy tất cả id môn học mà giáo viên dạy ở lớp đó
            List<int> subjectIds = db.ScheduleSubjects.Include(x => x.Subject)
                .Where(x => !x.DelFlag && x.ClassId == classId && x.TeacherId == teacher.Id && x.SemesterId == semesterId
                && (!x.Subject.Name.Equals("Sinh hoạt") && !x.Subject.Name.Equals("Chào cờ")))
                .DistinctBy(x => x.SubjectId).Select(x => x.SubjectId).ToList();

            if (subjectIds == null) return result;

            //Lấy tất cả điểm của học sinh theo môn học
            foreach (var item in subjectIds)
            {
                var list = GetStudentInClass(classId, semesterId, item);
                result.Subjects.Add(new SubjectMarkOfStudentInClass
                {
                    SubjectName = GetSubjectName(item),
                    Students = list ?? new List<StudentInfoForViewMark>()
                });
            }
            return result;

        }

        private string GetSubjectName(int subjectId)
        {
            var subject = db.Subjects.FirstOrDefault(x => !x.DelFlag && x.Id == subjectId);
            return subject == null ? "" : subject.Name; 
        }

        public bool AddAverage(int classId, int subjectId, int semesterId)
        {
            var studentIds = db.Students
                .Where(x => x.ClassId == classId && x.DelFlag == false)
                .Select(x => x.Id)
                .ToList();

            if(!studentIds.Any())
            {
                return false;
            }

            //check if average marks have already in Db
            var checkAverageMark = db.SubjectMarks
                .FirstOrDefault(x => x.SubjectId == subjectId && x.StudentId == studentIds[0] && x.SemesterId == semesterId && x.TypeMarkId == 5 && x.DelFlag == false);

            if (checkAverageMark != null)
            {
                return false;
            }

            var averageSubjectMarks = new List<SubjectMark>();

            try
            {
                foreach (int studentId in studentIds)
                {

                    var subjectMarks = db.SubjectMarks
                        .Where(x => x.StudentId == studentId && x.SubjectId == subjectId && x.SemesterId == semesterId && x.DelFlag == false)
                        .Select(x => new
                        {
                            TypeMarkId = x.TypeMarkId,
                            Mark = x.Mark
                        }).ToList();

                    //check student has a full of mark, if not return false
                    var typeMarks = subjectMarks.GroupBy(x => x.TypeMarkId).ToArray();

                    if (typeMarks.Length != 4)
                    {
                        return false;
                    }

                    var firstMark = 0.0;
                    var secondMark = 0.0;
                    var thirdMark = 0.0;
                    var fourthMark = 0.0;

                    var firstMarks = subjectMarks.Where(x => x.TypeMarkId == 1).Select(x => x.Mark).ToList();

                    if (!firstMarks.Any())
                    {
                        firstMark = 0;
                    }
                    else
                    {
                        firstMark = firstMarks.Average();
                    }

                    var secondMarks = subjectMarks.Where(x => x.TypeMarkId == 2).Select(x => x.Mark).ToList();

                    if (!secondMarks.Any())
                    {
                        secondMark = 0;
                    }
                    else
                    {
                        secondMark = secondMarks.Average();
                    }

                    var thirdMarks = subjectMarks.Where(x => x.TypeMarkId == 3).Select(x => x.Mark).ToList();

                    if (!thirdMarks.Any())
                    {
                        thirdMark = 0;
                    }
                    else
                    {
                        thirdMark = thirdMarks.Average();
                    }

                    var fourthMarks = subjectMarks.Where(x => x.TypeMarkId == 4).Select(x => x.Mark).ToList();

                    if (!fourthMarks.Any())
                    {
                        fourthMark = 0;
                    }
                    else
                    {
                        fourthMark = fourthMarks.Average();
                    }

                    var averageMark = (firstMark + secondMark + thirdMark * 2 + fourthMark * 3) / 7;

                    var averageSubjectMark = new SubjectMark()
                    {
                        SubjectId = subjectId,
                        SemesterId = semesterId,
                        StudentId = studentId,
                        TypeMarkId = 5,
                        Mark = averageMark
                    };

                    averageSubjectMarks.Add(averageSubjectMark);
                }

                db.SubjectMarks.AddRange(averageSubjectMarks);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            
            return true;
        }
    }
}
using EducationManagement.Dtos;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly DataContext db = new DataContext();

        public ListOfTeacherResponseDto GetListOfTeachers(TeacherConditionSearch conditionSearch)
        {
            try
            {
                // Nếu không tồn tại điều kiện tìm kiếm thì khởi tạo giá trị tìm kiếm ban đầu
                if (conditionSearch == null)
                {
                    conditionSearch = new TeacherConditionSearch();
                }

                ListOfTeacherResponseDto listOfTeacher = new ListOfTeacherResponseDto();
                // Lấy các thông tin dùng để phân trang
                listOfTeacher.Paging = new Commons.Paging(db.Teachers.Count(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && ((x.User.FirstName.Contains(conditionSearch.KeySearch)) || 
                    (x.User.LastName.Contains(conditionSearch.KeySearch))))))
                    , conditionSearch.CurrentPage, conditionSearch.PageSize);

                // Tìm kiếm và lấy dữ liệu theo trang
                var listTeacher = db.Teachers.Include(u => u.User).Include(y=>y.Team).Where(x => !x.DelFlag &&
                    (conditionSearch.KeySearch == null ||
                    (conditionSearch.KeySearch != null && ((x.User.FirstName.Contains(conditionSearch.KeySearch)) ||
                    (x.User.LastName.Contains(conditionSearch.KeySearch))))))
                    .OrderBy(x => x.Id)
                    .Skip((listOfTeacher.Paging.CurrentPage - 1) * listOfTeacher.Paging.NumberOfRecord)
                    .Take(listOfTeacher.Paging.NumberOfRecord).ToList();
                if (listTeacher == null)
                    listOfTeacher.ListOfTeacher = null;
                else
                {
                    listOfTeacher.ListOfTeacher = listTeacher.Select(t => new TeacherResponseDto
                    {
                        Id = t.Id,
                        TeamName = t.Team.Name,
                        UserInfo = new UserResponseDto(t.User)
                    }).ToList();
                }
                    
                listOfTeacher.Condition = conditionSearch;
                return listOfTeacher;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
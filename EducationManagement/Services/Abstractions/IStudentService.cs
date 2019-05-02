using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using System.Collections.Generic;

namespace EducationManagement.Services.Abstractions
{
    public interface IStudentService
    {
        int[] AddStudents(StudentDto[] dtos);
        ListStudentOfParentResponseDto GetStudentsByParentId(int parentId);
        ListStudentsOfClassResponseDto GetStudentsByClassId(int classId);

        StudentResponseDto Get(int studentId);
    }
}

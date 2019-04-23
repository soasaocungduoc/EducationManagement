using EducationManagement.Dtos.InputDtos;

namespace EducationManagement.Services.Abstractions
{
    public interface IStudentService
    {
        int[] AddStudents(StudentDto[] dtos);
    }
}

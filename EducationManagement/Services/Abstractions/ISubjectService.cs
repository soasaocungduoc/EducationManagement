using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Abstractions
{
    public interface ISubjectService
    {
        List<SubjectResponseDto> GetSubjects();
        SubjectResponseDto AddSubject(SubjectDto subject);
        SubjectResponseDto GetSubjectBySubjectId(int SubjectId);
    }
}

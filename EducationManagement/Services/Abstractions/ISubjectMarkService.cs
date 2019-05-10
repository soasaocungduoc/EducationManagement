using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Abstractions
{
    public interface ISubjectMarkService
    {
        List<SubjectMarkResponseDto> GetSubjectMarks(int userId, int semesterId);

        bool Add(SubjectMarkDto dto);

        MarkInTeachingClassResponseDto GetMarksInClass(int classId, int semesterId, int userId);

        bool AddAverage(int classId, int subjectId, int semesterId);
    }
}

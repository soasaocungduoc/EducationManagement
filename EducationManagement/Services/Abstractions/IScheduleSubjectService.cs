using EducationManagement.Dtos.InputDtos;
using EducationManagement.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Abstractions
{
    public interface IScheduleSubjectService
    {
        List<ScheduleSubjectResponseDto> GetScheduleSubjectsByClassId(int id, SemesterIdDto semesterId);
        List<ScheduleSubjectResponseDto> GetScheduleSubjectsByStudentId(int id, SemesterIdDto semesterId);
        List<TeachingScheduleResponseDto> GetTeachingScheduleByTeacherId(int id, SemesterIdDto semesterId);
    }
}

using System.Linq;
using EducationManagement.Dtos.OutputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;

namespace EducationManagement.Services.Implementations
{
    public class SchoolInformationService : ISchoolInformationService
    {
        private readonly DataContext db = new DataContext();

        public SchoolInformationDto GetSchoolInformation()
        {
            var schoolInformationList = db.SchoolInformation;

            if (schoolInformationList == null || !schoolInformationList.Any()) return new SchoolInformationDto();

            return new SchoolInformationDto(schoolInformationList.First());
        }
    }
}
using EM.Database.Schema;
using Newtonsoft.Json;

namespace EducationManagement.Dtos.OutputDtos
{
    public class SchoolInformationDto
    {
        [JsonProperty("school_name")]
        public string SchoolName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("school_introduction")]
        public string SchoolIntroduction { get; set; }

        [JsonProperty("website_url")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        public SchoolInformationDto()
        {
            
        }

        public SchoolInformationDto(SchoolInformation schoolInformation)
        {
            SchoolName = schoolInformation.SchoolName;
            Address = schoolInformation.Address;
            PhoneNumber = schoolInformation.PhoneNumber;
            Email = schoolInformation.Email;
            SchoolIntroduction = schoolInformation.SchoolIntroduction;
            WebsiteUrl = schoolInformation.WebsiteUrl;
            Fax = schoolInformation.Fax;
        }
    }
}
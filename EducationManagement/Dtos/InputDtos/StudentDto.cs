using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationManagement.Dtos.InputDtos
{
    public class StudentDto
    {
        [Required]
        [JsonProperty("classid")]
        public int ClassId { get; set; }

        [Required]
        [JsonProperty("parentid")]
        public int ParentId { get; set; }

        [Required]
        [StringLength(50)]
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("isman")]
        public bool IsMan { get; set; }

        [Required]
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(200)]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        [JsonProperty("phonenumber")]
        public string PhoneNumber { get; set; }


    }
}
using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ConductResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("conduct")]
        public string Conduct { get; set; }

        public ConductResponseDto()
        {

        }

        public ConductResponseDto(int id, string conduct)
        {
            Id = id;
            Conduct = conduct;
        }

        public ConductResponseDto(Conduct conduct)
        {
            Id = conduct.Id;
            Conduct = conduct.ConductType;
        }
    }
}
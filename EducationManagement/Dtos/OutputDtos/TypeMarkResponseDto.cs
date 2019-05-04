using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class TypeMarkResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type_mark")]
        public string TypeMark { get; set; }

        public TypeMarkResponseDto()
        {

        }

        public TypeMarkResponseDto(int id, string typeMark)
        {
            Id = id;
            TypeMark = typeMark;
        }

        public TypeMarkResponseDto(TypeMark typeMark)
        {
            Id = typeMark.Id;
            TypeMark = typeMark.Name;
        }
    }
}
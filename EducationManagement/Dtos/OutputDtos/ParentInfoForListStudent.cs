using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ParentInfoForListStudent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent_name")]
        public string Name { get; set; }

        public ParentInfoForListStudent()
        {

        }

        public ParentInfoForListStudent(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
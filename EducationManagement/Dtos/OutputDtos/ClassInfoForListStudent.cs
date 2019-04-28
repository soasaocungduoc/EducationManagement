using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ClassInfoForListStudent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("class_name")]
        public string Name { get; set; }

        public ClassInfoForListStudent()
        {

        }

        public ClassInfoForListStudent(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ClassInfoForListStudent(Class c)
        {
            Id = c.Id;
            Name = c.Name;
        }
    }
}
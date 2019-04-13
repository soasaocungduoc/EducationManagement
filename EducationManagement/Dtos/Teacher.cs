using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos
{
    public class Teacher
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("team_id")]
        [Required]
        public int TeamId { get; set; }

        public Teacher()
        {

        }

        public Teacher(int id, User user, int teamId)
        {
            Id = id;
            User = user;
            TeamId = teamId;
        }
    }
}
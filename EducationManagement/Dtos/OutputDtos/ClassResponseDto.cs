using EM.Database.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Dtos.OutputDtos
{
    public class ClassResponseDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("number_of_students")]
        public int NumberOfStudents { get; set; }

        [JsonProperty("grade_name")]
        public string GradeName { get; set; }

        [JsonProperty("room_number")]
        public string RoomNumber { get; set; }

        [JsonProperty("teacher_name")]
        public string TeacherName { get; set; }

        public ClassResponseDto()
        {

        }

        public ClassResponseDto(int id, string name, int numberOfStudents, string gradeName, string roomNumber, string teacherName)
        {
            Id = id;
            Name = name;
            NumberOfStudents = numberOfStudents;
            GradeName = gradeName;
            RoomNumber = roomNumber;
            TeacherName = teacherName;
        }
    }
}
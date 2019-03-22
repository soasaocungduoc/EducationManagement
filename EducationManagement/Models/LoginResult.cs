using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Models
{
    public class LoginResult
    {
        public string Token { get; set; }

        public int? UserId { get; set; }
    }
}
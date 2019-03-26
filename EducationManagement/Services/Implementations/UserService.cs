using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Linq;
using System.Text;

namespace EducationManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DataContext db = new DataContext();
        
        public void UpdateAvatar(string token, string url)
        {
            var userId = GetCurrentUserId(token);

            var userFromDb = db.Users.FirstOrDefault(x => x.Id == userId);

            if(userFromDb == null)
            {
                return;
            }

            userFromDb.Avatar = url;

            db.SaveChanges();
        }
        public int GetCurrentUserId(string token)
        {
            string base64Decoded;

            byte[] data = Convert.FromBase64String(token);

            base64Decoded = ASCIIEncoding.ASCII.GetString(data);

            string[] temp = base64Decoded.Split('@');

            var userId = Int32.Parse(temp[0]);

            return userId;
        }
    }
}
using EducationManagement.Commons;
using EducationManagement.Dtos.InputDtos;
using EducationManagement.Services.Abstractions;
using EM.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly DataContext db = new DataContext();

        public int ChangePassword(PasswordDto password, int id)
        {
            var account = db.Accounts.FirstOrDefault(x => !x.DelFlag && x.UserId == id);

            if (account == null) return -1; // cannot found this account

            if (!account.Password.Equals(FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(password.OldPassword))))
                return 0;

            account.Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(password.NewPassword));

            db.SaveChanges();
            return 1;

        }
    }
}
using EM.Database;
using EM.Database.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationManagement.Commons
{
    /// <summary>
    /// Tổng hợp các phương thức hay dùng để xác thực các vấn đền liên quan đến tài khoản.
    /// Author       :   TramHTD - 14/04/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   EducationManagement
    /// Copyright    :   Team SaoCungDuoc
    /// Version      :   1.0.0
    /// </remarks>
    public class AccountVerification
    {
        /// <summary>
        /// Kiểm tra quyền truy cập một action trong controller.
        /// Author      :    TramHTD - 14/04/2018 - create
        /// </summary>
        /// <param name="token">
        /// token của user login.
        /// </param>
        /// <param name="controller">
        /// controller cần kiểm tra.
        /// </param>
        /// <param name="action">
        /// action trong controller cần kiểm tra.
        /// </param>
        /// <returns>
        /// Kết quả sau khi kiểm tra.
        /// </returns>
        public static bool CheckAuthentication(string token, string controller, string action)
        {
            try
            {
                DataContext context = new DataContext();
                int GroupId = JwtAuthenticationExtensions.ExtractTokenInformation(token).GroupId;
                Permission permission = context.Permissions.FirstOrDefault(x => !x.DelFlag && x.GroupId == GroupId && x.Function.ControllerName.Equals(controller) && x.Function.ActionName.Equals(action));
                if (permission == null || !permission.IsEnable)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra quyền truy cập một chức năng theo mã chức năng.
        /// Author       :   TramHTD - 14/04/2018 - create
        /// </summary>
        /// /// <param name="token">
        /// token của user login.
        /// </param>
        /// <param name="functionId">
        /// Mã chức năng cần kiểm tra.
        /// </param>
        /// <returns>
        /// Kết quả sau khi kiểm tra.
        /// </returns>
        public static bool CheckAuthentication(string token, int functionId)
        {
            try
            {
                DataContext context = new DataContext();
                int GroupId = JwtAuthenticationExtensions.ExtractTokenInformation(token).GroupId;
                Permission permission = context.Permissions.FirstOrDefault(x => !x.DelFlag && x.FunctionId == functionId && x.GroupId == GroupId);
                if (permission != null && !permission.IsEnable)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
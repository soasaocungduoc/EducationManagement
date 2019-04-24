﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace EducationManagement.Commons
{
    /// <summary>
    /// Chứa các function sẽ sử dụng chung và nhiều lần trong dự án.
    /// Author       :   TramHTD - 14/04/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   EducationManagement
    /// Copyright    :   Team SaoCungDuoc
    /// Version      :   1.0.0
    /// </remarks>
    public class FunctionCommon
    {
        private static string _secretKey = "SOASaoCungDuoc";

        /// <summary>
        /// Mã hóa MD5 của 1 chuỗi có thêm chuối khóa đầu và cuối.
        /// Author       :   TramHTD - 18/03/2019 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi cần mã hóa.
        /// </param>
        /// <returns>
        /// Chuỗi sau khi đã được mã hóa.
        /// </returns>
        public static string GetMd5(string str)
        {
            str = $"{_secretKey}{str}{_secretKey}";
            var arrBytes = System.Text.Encoding.UTF8.GetBytes(str);
            var myMd5 = new MD5CryptoServiceProvider();
            arrBytes = myMd5.ComputeHash(arrBytes);
            return arrBytes.Aggregate("", (current, b) => current + b.ToString("x2"));
        }
        /// <summary>
        /// Mã hóa MD5 của 1 chuỗi không có thêm chuối khóa đầu và cuối.
        /// Author       :   TramHTD - 18/03/2019 - create
        /// </summary>
        /// <param name="str">
        /// Chuỗi cần mã hóa.
        /// </param>
        /// <returns>
        /// Chuỗi sau khi đã được mã hóa
        /// </returns>
        public static string GetSimpleMd5(string str)
        {
            var arrBytes = System.Text.Encoding.UTF8.GetBytes(str);
            var myMd5 = new MD5CryptoServiceProvider();
            arrBytes = myMd5.ComputeHash(arrBytes);
            return arrBytes.Aggregate("", (current, b) => current + b.ToString("x2"));
        }

        public static bool ValidatePermission(string token, int userId)
        {
            var tokenInformation = JwtAuthenticationExtensions.ExtractTokenInformation(token);
            if (tokenInformation == null) return false;
            return tokenInformation.GroupName == "Admin" ||
                   tokenInformation.GroupName == "Mod" ||
                   tokenInformation.UserId == userId;
        }
    }
}
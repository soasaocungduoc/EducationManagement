namespace EducationManagement.Commons
{
    public static class AuthenticationValidation
    {
        public static bool IsAdminOrMod(string token)
        {
            var tokenInformation = JwtAuthenticationExtensions.ExtractTokenInformation(token);
            if (tokenInformation == null) return false;
            return tokenInformation.GroupName == "Admin" ||
                   tokenInformation.GroupName == "Mod";
        }

        public static bool IsAdmin(string token)
        {
            var tokenInformation = JwtAuthenticationExtensions.ExtractTokenInformation(token);
            if (tokenInformation == null) return false;
            return tokenInformation.GroupName == "Admin";
        }
    }
}
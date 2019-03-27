namespace EducationManagement.Services.Abstractions
{
    public interface IUserService
    {
        bool UpdateAvatar(string token, string url);

        int GetCurrentUserId(string token);
    }
}

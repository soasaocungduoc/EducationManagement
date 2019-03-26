namespace EducationManagement.Services.Abstractions
{
    public interface IUserService
    {
        void UpdateAvatar(string token, string url);

        int GetCurrentUserId(string token);
    }
}

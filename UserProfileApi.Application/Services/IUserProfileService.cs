using UserProfileApi.Domain.Entities;

namespace UserProfileApi.Application.Services
{
    public interface IUserProfileService
    {
        UserProfile GetByUserId(string userId);
        UserProfile GetByEmail(string email);
    }
}

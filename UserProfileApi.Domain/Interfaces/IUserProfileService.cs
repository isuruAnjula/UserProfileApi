using UserProfileApi.Domain.Entities;

namespace UserProfileApi.Domain.Interfaces
{
    public interface IUserProfileService
    {
        UserProfile GetByUserId(string userId);
        UserProfile GetByEmail(string email);
    }
}

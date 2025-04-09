using UserProfileApi.Domain.Entities;
using UserProfileApi.Domain.Interfaces;
using UserProfileApi.Infrastructure.Data;

namespace UserProfileApi.Infrastructure.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly AppDbContext dbcontext;

        // Contect to access user profile data
        public UserProfileService(AppDbContext context)
        {
            dbcontext = context;
        }

        // Retrive userId and email from database
        public UserProfile GetByUserId(string userId) =>
            dbcontext.UserProfiles.FirstOrDefault(u => u.UserId == userId);

        public UserProfile GetByEmail(string email) =>
            dbcontext.UserProfiles.FirstOrDefault(u => u.Email == email);
    }
}

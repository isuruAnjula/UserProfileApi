using UserProfileApi.Data;
using UserProfileApi.Models;

namespace UserProfileApi.Services
{
    public class UserProfileService
    {
        private readonly AppDbContext dbcontext;

        // Contect to access user profile data
        public UserProfileService(AppDbContext context)
        {
            dbcontext = context;
        }

        // Retrive user profile from database
        public UserProfile GetUserProfile(string userId)
        {
            foreach (var user in dbcontext.UserProfiles)
            {
                if (user.UserId == userId)
                {
                    return user;
                }
            }
            return null;
        }
    }
}

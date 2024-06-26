using TournaManagementData;
using TournaManagementModels;

namespace TournaManagementServices
{
    public class UserGetServices
    {
        private List<User> GetAllUsers()
        {
            UserData userData = new UserData();

            return userData.GetUsers();

        }

        public List<User> GetUsersByStatus(int userStatus)
        {
            List<User> usersByStatus = new List<User>();

            foreach (var user in GetAllUsers())
            {
                if (user.status == userStatus)
                {
                    usersByStatus.Add(user);
                }
            }

            return usersByStatus;
        }

        public User GetUser(string username, string mlbbid)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.ign == username && user.mlbbid == mlbbid)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        public User GetUser(string username)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.ign == username)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }
    }
}
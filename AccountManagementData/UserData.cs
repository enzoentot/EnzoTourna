using TournaManagementModels;

namespace TournaManagementData
{
    public class UserData
    {
        List<User> users;
        public UserData()
        {
            users = new List<User>();
            UserFactory _userFactory = new UserFactory();
            users = _userFactory.GetDummyUsers();
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public void AddUser(User user)
        {
           users.Add(user);
        }

        public void UpdateUser(User user)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].ign == user.ign)
                {
                    users[i].profile = user.profile;
                    users[i].ign = user.ign;
                    users[i].dateUpdated = DateTime.Now;
                }
            }
        }
    }
}

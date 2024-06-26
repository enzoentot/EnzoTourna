namespace TournaManagementModels
{
    public class User
    {
        public string ign;
        public string mlbbid;
        public DateTime dateVerified;
        private DateTime dateCreated = DateTime.Now;
        public DateTime dateUpdated;
        public UserProfile profile;
        public int status;
        public string colorNum;
    }
}
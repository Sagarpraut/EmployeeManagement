namespace MoviesApp.Models
{
    public interface IUserDataAccessLayer
    {
        void AddUser(Registration user);
        bool CheckLogin(Registration user);
        Registration GetUserDetails(string emailId);
    }
}
using BankAPI.Models;

namespace BankAPI.Services
{
    public interface IUserService
    {
        User? Validate(string username, string password);
    }
    public class UserService : IUserService
    {
        private readonly List<User> users = new List<User>();
        public UserService()
        {
            users.Add(new User() { UserName = "joydipkanjilal", Password = "joydip123", Role = "manager" });
            users.Add(new User() { UserName = "michaelsanders", Password = "michael321", Role = "developer" });
            users.Add(new User() { UserName = "stephensmith@admin.com", Password = "stephen123", Role = "developer" });
            users.Add(new User() { UserName = "rodpaddock", Password = "rod123", Role = "admin" });
            users.Add(new User() { UserName = "Aditya Jindal", Password = "WellsFargo", Role = "admin" });
        }

        public User? Validate(string username, string password)
        {
            return users.SingleOrDefault(u => u.UserName == username && u.Password == password);
        }
    }
}

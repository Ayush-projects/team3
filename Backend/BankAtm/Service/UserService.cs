using BankAtm.Entities;
using System.Linq;

namespace BankAtm.Service
{
    public interface IUserService
    {
        User? Validate(string username, string password);
    }
    public class UserService : IUserService
    {
        CustomerContext _customerContext;
        public UserService(CustomerContext dbcustomer)
        {
             _customerContext = dbcustomer;
        }

        public User? Validate(string email, string password)
        {
            return _customerContext.Users.FirstOrDefault(p=>p.Email == email && p.Password==password);

                }
    }
}



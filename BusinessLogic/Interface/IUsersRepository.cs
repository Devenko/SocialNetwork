using Domain.Entities;
using System.Collections.Generic;
using System.Web.Security;

namespace BusinessLogic.Interface
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User GetUserByName(string userName);
        MembershipUser GetMembershipUserByName(string userName);
        string GetUserNameByEmail(string email);

        void CreateUser(string userName,
                        string password,
                        string email,
                        string firstName,
                        string lastName,
                        string middleName);

        bool ValidateUser(string userName, string password);
        void SaveUser(User user);
    }
}
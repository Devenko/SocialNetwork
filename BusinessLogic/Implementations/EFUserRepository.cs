using BusinessLogic.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using Domain;

namespace BusinessLogic.Implementations
{
    public class EFUserRepository : IUsersRepository
    {
        private EFDbContext context;//переменная для работы с базой данным

        public EFUserRepository(EFDbContext context)
        {
            this.context = context;
        }
        //получить пользователя
        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }
        //получить пользователя по Id
        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }
        //получение пользователя по имени
        public User GetUserByName(string userName)
        {
            return context.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public MembershipUser GetMembershipUserByName(string userName)
        {
            User user = context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user != null)
            {
                return new MembershipUser("CustomMembershipProvider",
                                           user.UserName,
                                           user.Id,
                                           user.Email,
                                           "",
                                           null,
                                           true,
                                           false,
                                           user.CreatedDateTime,
                                           DateTime.Now,
                                           DateTime.Now,
                                           DateTime.Now,
                                           DateTime.Now);
            }
            return null;
        }
        //получение пользователя по email
        public string GetUserNameByEmail(string email)
        {
            User user = context.Users.FirstOrDefault(x => x.Email == email);
            return user != null ? user.UserName : "";
        }
        //создаем и сохраняем пользователя
        public void CreateUser(string userName, string password, string email, string firstName, string lastName, string middleName)
        {
            User user = new User
            {
                UserName = userName,
                Email = email,
                Password = password,
                CreatedDateTime = DateTime.Now,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName
            };
            SaveUser(user);
        }
        //валидация пользователя по логину
        public bool ValidateUser(string userName, string password)
        {
            User user = context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user != null && user.Password == password)
                return true;
            return false;
        }
        //сохранить пользователя
        public void SaveUser(User user)
        {
            if (user.Id == 0)
                context.Users.Add(user);
            else
                context.Entry(user).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}

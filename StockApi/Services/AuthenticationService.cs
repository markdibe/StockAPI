using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using StockApi.BO;
using StockApi.Context;
using StockApi.Converters;
using StockApi.Entities;
using StockApi.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly StockContext _context;
        private UserConverter converter;
        private readonly IDataProtector _protector;
        public AuthenticationService(StockContext context, IDataProtectionProvider provider)
        {
            _context = context;
            converter = new UserConverter();
            _protector = provider.CreateProtector("ConfigurationManager.ConnectionStrings['StockManagerConnectionString'].ConnectionString");
        }
        public ICollection<UserBO> Create(ICollection<UserBO> Users)
        {
            foreach (var user in Users)
            {
                if (!EmailExisted(user.Email))
                {
                    user.EncriptionKey = _protector.Protect(user.Password);
                    User _user = converter.Convert(user);
                    _context.Users.Add(_user);
                }
            }
            _context.SaveChanges();
            return Users;
        }

        public ICollection<UserBO> Delete(ICollection<string> Ids)
        {
            List<User> UserList = new List<User>();
            foreach (string id in Ids)
            {
                if (GetById(id) != null)
                {
                    var user = converter.Convert(GetById(id));
                    _context.Users.Remove(user);
                    UserList.Add(user);
                }
            }
            _context.SaveChanges();
            return converter.Convert(UserList);
        }

        public ICollection<UserBO> Get()
        {
            return _context.Users.ToList().Select(x => converter.Convert(x)).ToList();
        }

        public UserBO GetById(string id)
        {
            return converter.Convert(_context.Users.FirstOrDefault(user => user.UserId.Equals(id)));
        }

        private bool EmailExisted(string email)
        {
            return _context.Users.Any(x => x.Email.ToLower().Trim().Equals(email.Trim().ToLower()));
        }

        public UserBO Update(UserBO userEdited)
        {
            User dbUser = converter.Convert(GetById(userEdited.UserId));
            dbUser.UserName = userEdited.UserName;
            dbUser.Email = userEdited.Email;
            dbUser.Password = userEdited.Password;
            _context.SaveChanges();
            return converter.Convert(dbUser);
        }

        public bool Login(UserBO userBO)
        {
            User user = converter.Convert(userBO);
            if (!EmailExisted(userBO.Email)) { return false; }
            return RightEmailPass(userBO.Email, userBO.Password);
        }

        private bool RightEmailPass(string email, string password)
        {
            string _password = _protector.Protect(password);
            return _context.Users.Any(x =>
            x.Email.ToLower().Trim().Equals(email.ToLower().Trim())
            &&  x.Password.Equals(_password)
            );
        }



    }
}

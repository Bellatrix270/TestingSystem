using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TestingSystem.Exception;
using TestingSystem.Models.EntityDB;

namespace TestingSystem.Models.DomainLogic
{
    public class User
    {
        private static readonly Lazy<User> _instance = new Lazy<User>(() => new User());
        private readonly TestSystem _db = new TestSystem();
        private string _firstName;
        private string _lastName;
        private string _patronymic;
        private string _login;
        private string _password;
        public static User Instance => _instance.Value;

        public string FirstName
        {
            get
            {
                if (ValidateProperty(_firstName))
                    throw new UserException("User not Authorization");
                return _firstName;
            }
            set => _firstName = value;
        }

        public string LastName
        {
            get
            {
                if (ValidateProperty(_lastName))
                    throw new UserException("User not Authorization");
                return _lastName;
            }
            set => _lastName = value;
        }

        public string Patronymic
        {
            get
            {
                if (ValidateProperty(_patronymic))
                    throw new UserException("User not Authorization");
                return _patronymic;
            }
            set => _patronymic = value;
        }

        public string Login
        {
            get
            {
                if (ValidateProperty(_login))
                    throw new UserException("User not Authorization");
                return _login;
            }
            set => _login = value;
        }

        public string Password
        {
            get
            {
                if (ValidateProperty(_password))
                    throw new UserException("User not Authorization");
                return _password;
            }
            set => _password = value;
        }

        public Dictionary<string, int> UserResults;

        private User()
        {
            
        }

        public void Authorization(string login, string password)
        {
            if (_db.Users.Any(AuthorizationUserPredicate))
                throw new UserException("User not found");

            EntityDB.User user = _db.Users.First(AuthorizationUserPredicate);
            
            Update(user);

            bool AuthorizationUserPredicate(EntityDB.User u) => u.Login == login && u.Password == password; 
        }

        public void Register(EntityDB.User newUser)
        {
            if (newUser == null)
                throw new NullReferenceException("Can't register. User is null");

            newUser.Role = "TestedPerson";
            _db.Users.Add(newUser);
            _db.SaveChanges();
            
            Update(newUser);
        }

        private void Update(EntityDB.User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Patronymic = user.Patronymic;
            Login = user.Login;
            Password = user.Password;
        }

        private bool ValidateProperty(string property)
        {
            return property != string.Empty;
        }

        public static List<EntityDB.User> GetAllUsers()
        {
            return new TestSystem().Users.ToList();
        }

    }
}
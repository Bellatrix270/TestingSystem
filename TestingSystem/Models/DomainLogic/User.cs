using System;
using System.Collections.Generic;

namespace TestingSystem.Models.DomainLogic
{
    public class User
    {
        private static readonly Lazy<User> _instance = new Lazy<User>(() => new User());
        public static User Instance => _instance.Value;

        private User()
        {
            
        }

        public static List<EntityDB.User> GetAllUsers()
        {
            return new List<EntityDB.User>();
        }

    }
}
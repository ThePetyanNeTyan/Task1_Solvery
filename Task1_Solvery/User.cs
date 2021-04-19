using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_Solvery
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }

        public User(string name, string password)
        {
            username = name;
            this.password = password;
        }

        protected User()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   password == user.password;
        }
    }
}

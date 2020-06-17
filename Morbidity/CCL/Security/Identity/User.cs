using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(string name, int userID, string userType)
        {
            Name = name;
            UserID = userID;          
            UserType = userType;
        }      
        public string Name { get; }
        public int UserID { get; }
        protected string UserType { get; }
    }
}
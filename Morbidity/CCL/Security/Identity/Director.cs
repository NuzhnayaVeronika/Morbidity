using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Director
        : User
    {
        public Director(string name, int userID) 
            : base(name, userID, nameof(Director))
        {
        }
    }
}
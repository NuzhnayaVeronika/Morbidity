using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Accountant
        : User
    {
        public Accountant(string name, int userID) 
            : base(name, userID, nameof(Accountant))
        {
        }
    }
}
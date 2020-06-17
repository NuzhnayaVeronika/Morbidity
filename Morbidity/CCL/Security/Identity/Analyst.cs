using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Analyst
        : User
    {
        public Analyst(string name, int userID) 
            : base(name, userID, nameof(Analyst))
        {
        }
    }
}
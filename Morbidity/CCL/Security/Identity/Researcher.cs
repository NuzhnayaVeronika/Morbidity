using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Researcher
        : User
    {
        public Researcher(string name, int userID) 
            : base(name, userID, nameof(Researcher))
        {
        }
    }
}

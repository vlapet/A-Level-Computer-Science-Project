using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardProjectClient.game;

namespace CardProjectClient.components
{
    public abstract class Components
    {
        User CurrentUser;

        public Components(User currentUser)
        {
            CurrentUser = currentUser;
        }   
    }
}

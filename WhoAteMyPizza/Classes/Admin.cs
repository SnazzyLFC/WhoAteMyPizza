using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoAteMyPizza.Classes
{
    class Admin : User
    {
        public Pizza myPizza { get; set; }
    }
}

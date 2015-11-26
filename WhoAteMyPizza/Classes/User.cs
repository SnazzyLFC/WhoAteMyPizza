using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoAteMyPizza.Classes
{
    abstract public class User
    {
        public User()
        {
            this.eatenPieces = 0;
        }
        public int eatenPieces { get; set; }
        private double payment { get; set; }
        public double estimateCost(Pizza pizza)
        {
            double ToPay = pizza.cost * this.eatenPieces / 8;
            return ToPay;
        }
    }
}

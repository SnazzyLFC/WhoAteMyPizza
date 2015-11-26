using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoAteMyPizza.Classes
{
        public class Pizza
    {
        public Pizza(double cost)
        {
            this.cost = cost;
            this.NumberOfPieces = 8;
            //this.numberOfPeople = numberOfPeople;
        }
        public double cost { get; set; }
        private int NumberOfPieces { get; set; }
        public int numberOfPeople { get; set; }

        public int Eat(User who)
        {
            if (NumberOfPieces > 0)
            {
                return 8- this.NumberOfPieces--;
            }
            else
                return -1;
        }
    }

}

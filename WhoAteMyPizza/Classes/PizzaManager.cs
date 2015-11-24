using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace WhoAteMyPizza.Classes
{
    class PizzaManager
    {
        public PizzaManager()
        {
            this.NumberOfPieces = 0;
        }
        //private List<Image> PizzaToEat { get; set; }
        private int NumberOfPieces { get; set; }
        //public int WhichPiece()
        //{
        //    if (NumberOfPieces<=8)
        //    {
        //        Eat();
        //        return NumberOfPieces - 1;
        //    }
        //    else
        //    {
        //        //MsgBox "Pizza już zjedzona"
        //        return -1;
        //    }
        //}
        public int Eat()
        {
            if (NumberOfPieces < 8)
            {
                return this.NumberOfPieces++;
            }
            else
                return -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WhoAteMyPizza.Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WhoAteMyPizza
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EatingPage : Page
    {
        List<Image> PizzaToEat;
        Pizza myPizza;
        User Eater;
        public EatingPage()
        {
            this.InitializeComponent();
            PizzaToEat = new List<Image> { pizza0, pizza1, pizza2, pizza3, pizza4, pizza5, pizza6, pizza7 };
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<object> Parameters = e.Parameter as List<Object>;
            string type = Parameters[0].GetType().ToString();
            if (type == "WhoAteMyPizza.Classes.Admin")
            {
                myPizza = (Pizza)Parameters[1];
                EndButton.Visibility = Visibility.Visible;

            }
            else
                myPizza = new Pizza(10);
            Eater = (User)Parameters[0];
            textBox.Text = myPizza.cost.ToString();
        }
        private void pizzatoclick_Click(object sender, RoutedEventArgs e)
        {
            int piece = myPizza.Eat(Eater);
            if (piece != -1)
            {
                Eater.eatenPieces++;
                PizzaToEat[piece].Visibility = Visibility.Collapsed;
            }                       
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            //Eater.estimateCost(myPizza);
            textBox.Text = Eater.estimateCost(myPizza).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WhoAteMyPizza.Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhoAteMyPizza
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreatingPizza : Page
    {
        private TextBlock pizzaBox;
        private TextBlock costBox;
        private TextBlock deliveryBox;
        private TextBlock WhichOne;

        public CreatingPizza()
        {
            this.InitializeComponent();
            pizzaBox = PizzaBox;
            costBox = CostBox;
            deliveryBox = DeliveryBox;
        }
        private void EstimateCost()
        {
            double deliveryCost = Convert.ToDouble(deliveryBox.Text);
            double pizzaCost = Convert.ToDouble(pizzaBox.Text);
            double cost = pizzaCost + deliveryCost;
            costBox.Text = cost.ToString();
        }
        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            WhichOne = deliveryBox;
            CostTaker.Visibility = Visibility.Visible;
            UserCost.Text = WhichOne.Text;
            SetActive(false);
        }
        private void SetActive(bool argument)
        {
            PizzaButton.IsEnabled = argument;
            DeliveryButton.IsEnabled = argument;
            StartButton.IsEnabled = argument;
        }
        private void CheckIfEmpty()
        {
            if (deliveryBox.Text == "")
                deliveryBox.Text = "0";
            if (pizzaBox.Text == "")
                pizzaBox.Text = "0";
        }
        private void PizzaBox_TextChanged(object sender, RoutedEventArgs e)
        {
            WhichOne = pizzaBox;
            CostTaker.Visibility = Visibility.Visible;
            UserCost.Text = WhichOne.Text;
            SetActive(false);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cost = UserCost.Text;
            try
            {
                var x = Convert.ToDouble(cost);
                if (x < 0)
                    throw new System.Exception();
                WhichOne.Text = cost;
                EstimateCost();
                SetActive(true);
                CostTaker.Visibility = Visibility.Collapsed;
            }
            catch
            {
                SetActive(false);
                UserCost.IsEnabled = false;
                UserCost.Text = "wrong";
                Button.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Visible;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            UserCost.Text = WhichOne.Text;
            UserCost.IsEnabled = true;
            Button2.Visibility = Visibility.Collapsed;
            Button.Visibility = Visibility.Visible;
            SetActive(true);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Pizza myPizza = new Pizza(Convert.ToDouble(costBox.Text));
            Pizza myPizza = new Pizza(Convert.ToDouble(costBox.Text));
            Admin Eater = new Admin();
            Eater.myPizza = myPizza;
            List<object> Parameters = new List<object> { Eater, myPizza };
            this.Frame.Navigate(typeof(EatingPage), Parameters);
        }

        //private void CostBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
    }
}

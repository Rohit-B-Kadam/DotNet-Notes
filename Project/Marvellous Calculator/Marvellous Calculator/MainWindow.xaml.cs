using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace Marvellous_Calculator
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btnRsh":
                    TxtDisplay.Text = "Rsh";
                    break;
                case "btnLsh":
                    TxtDisplay.Text = "Lsh";
                    break;
                case "btnXor":
                    TxtDisplay.Text = "Xor";
                    break;
                case "btnOr":
                    TxtDisplay.Text = "Or";
                    break;
                case "btnAnd":
                    TxtDisplay.Text = "And";
                    break;
                case "btnNot":
                    TxtDisplay.Text = "Not";
                    break;
                case "btnAdd":
                    TxtDisplay.Text = "Add";
                    break;
                case "btnSubt":
                    TxtDisplay.Text = "Subt";
                    break;
                case "btnMulti":
                    TxtDisplay.Text = "Multi";
                    break;
                case "btnDiv":
                    TxtDisplay.Text = "Div";
                    break;
                case "btnEqual":
                    TxtDisplay.Text = "Equal";
                    break;
                case "btnMod":
                    TxtDisplay.Text = "Mod";
                    break;
                case "btnSqrt":
                    TxtDisplay.Text = "Sqrt";
                    break;
                case "btnSquare":
                    TxtDisplay.Text = "Sqr";
                    break;
                case "btnBackspace":
                    TxtDisplay.Text = "Bs";
                    break;
                case "btnClearAll":
                    TxtDisplay.Text = "C";
                    break;
                case "btnClearE":
                    TxtDisplay.Text = "CE";
                    break;
            }
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btn0":
                    TxtDisplay.Text = "0";
                    break;
                case "btn1":
                    TxtDisplay.Text = "1";
                    break;
                case "btn2":
                    TxtDisplay.Text = "2";
                    break;
                case "btn3":
                    TxtDisplay.Text = "3";
                    break;
                case "btn4":
                    TxtDisplay.Text = "4";
                    break;
                case "btn5":
                    TxtDisplay.Text = "5";
                    break;
                case "btn6":
                    TxtDisplay.Text = "6";
                    break;
                case "btn7":
                    TxtDisplay.Text = "7";
                    break;
                case "btn8":
                    TxtDisplay.Text = "8";
                    break;
                case "btn9":
                    TxtDisplay.Text = "9";
                    break;
                case "btnA":
                    TxtDisplay.Text = "A";
                    break;
                case "btnB":
                    TxtDisplay.Text = "B";
                    break;
                case "btnC":
                    TxtDisplay.Text = "C";
                    break;
                case "btnD":
                    TxtDisplay.Text = "D";
                    break;
                case "btnE":
                    TxtDisplay.Text = "E";
                    break;
                case "btnF":
                    TxtDisplay.Text = "F";
                    break;

            }
            
        }

        //Conversation_Click
        private void Conversation_Click(object sender, RoutedEventArgs e)
        {
            switch( (sender as RadioButton).Name)
            {
                case "rbHex":
                    TxtDisplay.Text = "Hex";
                    break;
                case "rbDec":
                    TxtDisplay.Text = "Dec";
                    break;
                case "rbOct":
                    TxtDisplay.Text = "Oct";
                    break;
                case "rbBin":
                    TxtDisplay.Text = "Bin";
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComboItem = sender as ComboBox;
            string name = selectedComboItem.SelectedItem as string;
            if( name.Equals("Factorial") || name.Equals("Factor"))
            {
                btnCheck.Content = "Get";
            }
            else
            {
                btnCheck.Content = "Check";
            }
           
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo.Name.Equals("BitComboBox"))
            {
                List<int> no = new List<int>()
                {
                    0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
                };
                combo.ItemsSource = no;
                combo.SelectedIndex = 0;
            }
            else
            {
                List<string> functName = new List<string>();
                functName.Add("isPrime");
                functName.Add("isPrefect");
                functName.Add("isArmstrong");
                functName.Add("isStrong");
                functName.Add("Factorial");
                functName.Add("Factor");

                combo.ItemsSource = functName;
                combo.SelectedIndex = 0;

            }
        }
    }
}

﻿using System;
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
        Calculator cal;
      
        public MainWindow()
        {
            InitializeComponent();
            cal = new Calculator();
            txtScreen.Text = cal.screenData;
            txtUppScreen.Text = cal.expression;
            rbDec.IsChecked = true;
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                // Arithmetric Operation
                case "btnAdd":
                    cal.BinaryOperator("+");
                    break;
                case "btnSubt":
                    cal.BinaryOperator("-");
                    break;
                case "btnMulti":
                    cal.BinaryOperator("*");
                    break;
                case "btnDiv":
                    cal.BinaryOperator("/");
                    break;
                case "btnMod":
                    cal.BinaryOperator("%");
                    break;
                case "btnRsh":
                    cal.BinaryOperator(">");
                    break;
                case "btnLsh":
                    cal.BinaryOperator("<");
                    break;
                case "btnXor":
                    cal.BinaryOperator("^");
                    break;
                case "btnOr":
                    cal.BinaryOperator("|");
                    break;
                case "btnAnd":
                    cal.BinaryOperator("&");
                    break;
                case "btnNot":
                    cal.UniaryOperator("!");
                    break;

                case "btnBackspace":
                    if (cal.screenData.Length != 1)
                        cal.screenData = cal.screenData.Remove(cal.screenData.Length - 1);
                    else
                        cal.screenData = "0";
                    txtScreen.Text = cal.screenData;
                    break;
                case "btnClearAll":
                    cal.ClearAll();
                    break;
                case "btnClearE":
                    cal.screenData = "0";
                    break;
                // Equal
                case "btnEqual":
                    cal.EqualOpeartor();
                    break;
                case "btnOffBit":
                    cal.BitwiseOperation("OffBit", BitComboBox.SelectedIndex);
                    break;
                case "btnOnBit":
                    cal.BitwiseOperation("OnBit", BitComboBox.SelectedIndex);
                    break;
                case "btnToggle":
                    cal.BitwiseOperation("ToggleBit", BitComboBox.SelectedIndex);
                    break;
                case "btnCheck":
                    cal.NumberFunction(FunctionComboBox.SelectedItem.ToString());
                    break;
                case "btnOpenBkt":
                    cal.Brackets("(");
                    break;
                case "btnCloseBkt":
                    cal.Brackets(")");
                    break;
            }

            DisplayOnScreen(cal.screenData);
            txtUppScreen.Text = cal.expression;
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btn0":
                    cal.DigitClick("0");
                    break;
                case "btn1":
                    cal.DigitClick("1");
                    break;
                case "btn2":
                    cal.DigitClick("2");
                    break;
                case "btn3":
                    cal.DigitClick("3");
                    break;
                case "btn4":
                    cal.DigitClick("4");
                    break;
                case "btn5":
                    cal.DigitClick("5");
                    break;
                case "btn6":
                    cal.DigitClick("6");
                    break;
                case "btn7":
                    cal.DigitClick("7");
                    break;
                case "btn8":
                    cal.DigitClick("8");
                    break;
                case "btn9":
                    cal.DigitClick("9");
                    break;
                case "btnA":
                    cal.DigitClick("A");
                    break;
                case "btnB":
                    cal.DigitClick("B");
                    break;
                case "btnC":
                    cal.DigitClick("C"); 
                    break;
                case "btnD":
                    cal.DigitClick("D");
                    break;
                case "btnE":
                    cal.DigitClick("E");
                    break;
                case "btnF":
                    cal.DigitClick("F");
                    break;

            }

            DisplayOnScreen(cal.screenData);
            txtUppScreen.Text = cal.expression;
        }

        //Conversation_Click
        private void Conversion_Click(object sender, RoutedEventArgs e)
        {
            string cn = (sender as RadioButton).Name;
            switch ( cn )
            {
                case "rbHex":
                    cal.screenData = cal.DataConversion(cal.screenData, cal.displayType, "Hex");
                    cal.displayType = "Hex";
                    break;
                case "rbDec":
                    cal.screenData = cal.DataConversion(cal.screenData, cal.displayType, "Dec");
                    cal.displayType = "Dec";
                    break;
                case "rbOct":
                    cal.screenData = cal.DataConversion(cal.screenData, cal.displayType, "Oct");
                    cal.displayType = "Oct";
                    break;
                case "rbBin":
                    cal.screenData = cal.DataConversion(cal.screenData, cal.displayType, "Bin");
                    cal.displayType = "Bin";
                    break;
            }
            if( cn.Equals("rbDec") || cn.Equals("rbOct") || cn.Equals("rbBin"))
            {
                btnA.IsEnabled = false;
                btnB.IsEnabled = false;
                btnC.IsEnabled = false;
                btnD.IsEnabled = false;
                btnE.IsEnabled = false;
                btnF.IsEnabled = false;
            }
            else
            {
                btnA.IsEnabled = true;
                btnB.IsEnabled = true;
                btnC.IsEnabled = true;
                btnD.IsEnabled = true;
                btnE.IsEnabled = true;
                btnF.IsEnabled = true;
            }

            if(cn.Equals("rbOct") || cn.Equals("rbBin"))
            {
                btn9.IsEnabled = false;
                btn8.IsEnabled = false;
            }
            else
            {
                btn9.IsEnabled = true;
                btn8.IsEnabled = true;
            }

            if (cn.Equals("rbBin"))
            {
                btn7.IsEnabled = false;
                btn6.IsEnabled = false;
                btn5.IsEnabled = false;
                btn4.IsEnabled = false;
                btn3.IsEnabled = false;
                btn2.IsEnabled = false;
            }
            else
            {
                btn7.IsEnabled = true;
                btn6.IsEnabled = true;
                btn5.IsEnabled = true;
                btn4.IsEnabled = true;
                btn3.IsEnabled = true;
                btn2.IsEnabled = true;
            }


            DisplayOnScreen(cal.screenData);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComboItem = sender as ComboBox;
            string name = selectedComboItem.SelectedItem as string;
            if( name.Contains("Is"))
            {
                btnCheck.Content = "Check";
            }
            else
            {
                btnCheck.Content = "Get";
            }
           
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo.Name.Equals("BitComboBox"))
            {
                List<int> no = new List<int>();
                for (int i = 0; i <= 50; i++)
                    no.Add(i);
                
                combo.ItemsSource = no;
                combo.SelectedIndex = 0;
            }
            else
            {

                combo.ItemsSource = cal.NumberFunctName;
                combo.SelectedIndex = 0;

            }
        }

        public void DisplayOnScreen(string data)
        {
            if ( data.Length <= 32)
            {
                txtScreen.FontSize = 35;
            }
            else
            {
                txtScreen.FontSize = 20;
            }

            txtScreen.Text = data;
        }
    }
}

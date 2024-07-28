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
using System.Windows.Shapes;

enum Action
{
    None,
    Multiple,
    Share,
    Plus,
    Minus,
}

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double number;
        private double prevNumber = 0;
        private Action action = Action.None;

        private double Number {  
            get
            {
                return number;
            }
            set
            {
                number = value;
                txtNums.Text = number.ToString();
            }
        }

        private void addNumber(int value)
        {
            double num = Number;
            num = num * 10 + value;

            Number = num;
        }

        private void selectAction(Action value)
        {
            prevNumber = number;
            action = value;
            Number = 0;
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            addNumber(0);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            addNumber(1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            addNumber(2);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            addNumber(3);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            addNumber(4);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            addNumber(5);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            addNumber(6);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            addNumber(7);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            addNumber(8);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            addNumber(9);
        }

        private void ClearAll()
        {
            Number = 0;
            prevNumber = 0;
            action= Action.None;
        }

        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            selectAction(Action.Minus);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            selectAction(Action.Plus);
        }

        private void btnShare_Click(object sender, RoutedEventArgs e)
        {
            selectAction(Action.Share);
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            selectAction(Action.Multiple);
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            switch (action)
            {
                case Action.None:
                    break;
                case Action.Multiple:
                    Number = prevNumber * number;
                    break;
                case Action.Share:
                    Number = prevNumber / number;
                    break;
                case Action.Plus:
                    Number = prevNumber + number;
                    break;
                case Action.Minus:
                    Number = prevNumber - number;
                    break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    ClearAll();
                    break;
                case Key.NumPad0:
                case Key.D0:
                    addNumber(0);
                    break;
                case Key.NumPad1:
                case Key.D1:
                    addNumber(1);
                    break;
                case Key.NumPad2:
                case Key.D2:
                    addNumber(2);
                    break;
                case Key.NumPad3:
                case Key.D3:
                    addNumber(3);
                    break;
                case Key.NumPad4:
                case Key.D4:
                    addNumber(4);
                    break;
                case Key.NumPad5:
                    addNumber(5);
                    break;
                case Key.NumPad6:
                    addNumber(6);
                    break;
                case Key.NumPad7:
                    addNumber(7);
                    break;
                case Key.NumPad8:
                    addNumber(8);
                    break;
                case Key.NumPad9:
                    addNumber(9);
                    break;
                case Key.Add:
                    selectAction(Action.Plus);
                    break;
                case Key.Subtract:
                    selectAction(Action.Minus);
                    break;
                case Key.Multiply:
                    selectAction(Action.Multiple);
                    break;
                case Key.Divide:
                    selectAction(Action.Share);
                    break;
                case Key.Enter:
                    Calculate();
                    break;
            }
        }
    }
}

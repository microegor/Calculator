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

        private int number;
        private int prevNumber = 0;
        private Action action = Action.None;

        private int Number {  
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
            int num = Number;
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

        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            Number = 0;
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
    }
}

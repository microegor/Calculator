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
using System.Windows.Media.Animation;
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

        private double display;
        private double result;
        private double prevNumber = 0;
        private double lastNumber = 0;
        private bool hasLastNumber = false;
        private Action action = Action.None;
        private bool isNewEntry = false;

        private double Display {  
            get
            {
                return display;
            }
            set
            {
                display = value;
                txtNums.Text = display.ToString();
            }
        }

        private void addNumber(int value)
        {
            double num = 0;
            if (isNewEntry == false)
            {
                num = Display;
            } else
            {
                isNewEntry = true;
            }
            num = num * 10 + value;

            Display = num;
        }

        private void selectAction(Action value)
        {
            result = Display;
            action = value;
            hasLastNumber = false;

            isNewEntry = true;
            //Display = 0;
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
            Display = 0;
            lastNumber = 0;
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
        private void btnSine_Click(object sender, RoutedEventArgs e)
        {
            Display = Display * -1;
        }

        private void Calculate()
        {
            if (!hasLastNumber)
            {
                lastNumber = Display;
                hasLastNumber = true;
            }
            switch (action)
            {
                case Action.None:
                    break;
                case Action.Multiple:
                    result = result * lastNumber;
                    Display = result;
                    break;
                case Action.Share:
                    result = result / lastNumber;
                    Display = result;
                    break;
                case Action.Plus:
                    result = result + lastNumber;
                    Display = result;
                    break;
                case Action.Minus:
                    result = result - lastNumber;
                    Display = result;
                    break;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Button targetButton = null;

            switch (e.Key)
            {
                case Key.Escape:
                    ClearAll();
                    break;
                case Key.NumPad0:
                case Key.D0:
                    targetButton = btn0;
                    addNumber(0);
                    break;
                case Key.NumPad1:
                case Key.D1:
                    targetButton = btn1;
                    addNumber(1);
                    break;
                case Key.NumPad2:
                case Key.D2:
                    targetButton = btn2;
                    addNumber(2);
                    break;
                case Key.NumPad3:
                case Key.D3:
                    targetButton = btn3;
                    addNumber(3);
                    break;
                case Key.NumPad4:
                case Key.D4:
                    targetButton = btn4;
                    addNumber(4);
                    break;
                case Key.NumPad5:
                case Key.D5:
                    targetButton = btn5;
                    addNumber(5);
                    break;
                case Key.NumPad6:
                case Key.D6:
                    targetButton = btn6;
                    addNumber(6);
                    break;
                case Key.NumPad7:
                case Key.D7:
                    targetButton = btn7;
                    addNumber(7);
                    break;
                case Key.NumPad8:
                case Key.D8:
                    targetButton = btn8;
                    addNumber(8);
                    break;
                case Key.NumPad9:
                case Key.D9:
                    targetButton = btn9;
                    addNumber(9);
                    break;
                case Key.Add:
                    selectAction(Action.Plus);
                    targetButton = btnPlus;
                    break;
                case Key.Subtract:
                    selectAction(Action.Minus);
                    targetButton = btnMinus;
                    break;
                case Key.Multiply:
                    selectAction(Action.Multiple);
                    targetButton = btnMult;
                    break;
                case Key.Divide:
                    selectAction(Action.Share);
                    targetButton = btnShare;
                    break;
                case Key.Enter:
                    Calculate();
                    break;
            }
            if (targetButton != null)
            {
                var storyboard = (Storyboard)this.Resources["ButtonClickColorAnimation"];
                storyboard.Begin(targetButton);
            }
        }
    }
}

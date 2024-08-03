using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private CalculatorLogic calculator;

        public MainWindow()
        {
            InitializeComponent();
            calculator = new CalculatorLogic();
        }

        private void UpdateDisplay()
        {
            string displayText = calculator.Display.ToString("G9");

            if (displayText.Contains("E"))
            {
                // Найти индекс символа 'E'
                int eIndex = displayText.IndexOf('E');
                // Вычислить длину экспоненциальной части
                int expLength = displayText.Length - eIndex;
                // Обрезать левую часть строки так, чтобы общая длина не превышала 9 символов
                if (eIndex > 9 - expLength)
                {
                    displayText = displayText.Substring(0, 9 - expLength) + displayText.Substring(eIndex);
                }
            }
            else if (displayText.Length > 9)
            {
                displayText = displayText.Substring(0, 9);
            }

            txtNums.Text = displayText;
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(0);
            UpdateDisplay();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(1);
            UpdateDisplay();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(2);
            UpdateDisplay();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(3);
            UpdateDisplay();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(4);
            UpdateDisplay();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(5);
            UpdateDisplay();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(6);
            UpdateDisplay();
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(7);
            UpdateDisplay();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(8);
            UpdateDisplay();
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            calculator.AddNumber(9);
            UpdateDisplay();
        }

        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            calculator.ClearAll();
            UpdateDisplay();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            calculator.SelectAction(Action.Minus);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            calculator.SelectAction(Action.Plus);
        }

        private void btnShare_Click(object sender, RoutedEventArgs e)
        {
            calculator.SelectAction(Action.Share);
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            calculator.SelectAction(Action.Multiple);
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            calculator.Calculate();
            UpdateDisplay();
        }

        private void btnSine_Click(object sender, RoutedEventArgs e)
        {
            calculator.Display = calculator.Display * -1;
            UpdateDisplay();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Button targetButton = null;

            switch (e.Key)
            {
                case Key.Escape:
                    calculator.ClearAll();
                    UpdateDisplay();
                    break;
                case Key.NumPad0:
                case Key.D0:
                    targetButton = btn0;
                    calculator.AddNumber(0);
                    UpdateDisplay();
                    break;
                case Key.NumPad1:
                case Key.D1:
                    targetButton = btn1;
                    calculator.AddNumber(1);
                    UpdateDisplay();
                    break;
                case Key.NumPad2:
                case Key.D2:
                    targetButton = btn2;
                    calculator.AddNumber(2);
                    UpdateDisplay();
                    break;
                case Key.NumPad3:
                case Key.D3:
                    targetButton = btn3;
                    calculator.AddNumber(3);
                    UpdateDisplay();
                    break;
                case Key.NumPad4:
                case Key.D4:
                    targetButton = btn4;
                    calculator.AddNumber(4);
                    UpdateDisplay();
                    break;
                case Key.NumPad5:
                case Key.D5:
                    targetButton = btn5;
                    calculator.AddNumber(5);
                    UpdateDisplay();
                    break;
                case Key.NumPad6:
                case Key.D6:
                    targetButton = btn6;
                    calculator.AddNumber(6);
                    UpdateDisplay();
                    break;
                case Key.NumPad7:
                case Key.D7:
                    targetButton = btn7;
                    calculator.AddNumber(7);
                    UpdateDisplay();
                    break;
                case Key.NumPad8:
                case Key.D8:
                    targetButton = btn8;
                    calculator.AddNumber(8);
                    UpdateDisplay();
                    break;
                case Key.NumPad9:
                case Key.D9:
                    targetButton = btn9;
                    calculator.AddNumber(9);
                    UpdateDisplay();
                    break;
                case Key.Add:
                    calculator.SelectAction(Action.Plus);
                    targetButton = btnPlus;
                    break;
                case Key.Subtract:
                    calculator.SelectAction(Action.Minus);
                    targetButton = btnMinus;
                    break;
                case Key.Multiply:
                    calculator.SelectAction(Action.Multiple);
                    targetButton = btnMult;
                    break;
                case Key.Divide:
                    calculator.SelectAction(Action.Share);
                    targetButton = btnShare;
                    break;
                case Key.Enter:
                    calculator.Calculate();
                    UpdateDisplay();
                    break;
                case Key.OemPeriod:
                case Key.Decimal:
                    calculator.AddDecimalSeparator();
                    targetButton = btnDot;
                    break;
            }

            if (targetButton != null)
            {
                var originalColor = (Color)ColorConverter.ConvertFromString(targetButton.Tag.ToString());
                var storyboard = (Storyboard)this.Resources["ButtonClickColorAnimation"];
                var colorAnimation = (ColorAnimation)storyboard.Children[0];
                colorAnimation.From = originalColor;
                storyboard.Begin(targetButton);
            }
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
                calculator.AddDecimalSeparator();
                UpdateDisplay();
        }
    }
}
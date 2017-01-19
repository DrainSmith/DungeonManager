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

namespace DungeonManagerWpf
{
    /// <summary>
    /// Interaction logic for DiceWindow.xaml
    /// </summary>
    public partial class DiceWindow : Window
    {
        int d4 = 0;
        int d6 = 0;
        int d8 = 0;
        int d10 = 0;
        int d12 = 0;
        int d20 = 0;
        int d100 = 0;
        private double _aspectRatio;
        private bool _isLoaded;

        public DiceWindow()
        {
            InitializeComponent();
        }

        public void DisplayActiveDice()
        {
            
            ActiveDiceTextBox.Text = "";
            string text = "";
            if (d4 > 0)
                text += "D4: " + d4 + " ";
            if (d6 > 0)
                text += "D6: " + d6 + " ";
            if (d8 > 0)
                text += "D8: " + d8 + " ";
            if (d10 > 0)
                text += "D10: " + d10 + " ";
            if (d12 > 0)
                text += "D12: " + d12 + " ";
            if (d20 > 0)
                text += "D20: " + d20 + " ";
            if (d100 > 0)
                text += "D100: " + d100;
            ActiveDiceTextBox.Text = text;
        }

        private void PlusD4Button_Click(object sender, RoutedEventArgs e)
        {
            d4++;
            DisplayActiveDice();
        }

        private void PlusD6Button_Click(object sender, RoutedEventArgs e)
        {
            d6++;
            DisplayActiveDice();
        }

        private void PlusD8Button_Click(object sender, RoutedEventArgs e)
        {
            d8++;
            DisplayActiveDice();
        }

        private void PlusD10Button_Click(object sender, RoutedEventArgs e)
        {
            d10++;
            DisplayActiveDice();
        }

        private void PlusD12Button_Click(object sender, RoutedEventArgs e)
        {
            d12++;
            DisplayActiveDice();
        }

        private void PlusD20Button_Click(object sender, RoutedEventArgs e)
        {
            d20++;
            DisplayActiveDice();
        }

        private void PlusD100Button_Click(object sender, RoutedEventArgs e)
        {
            d100++;
            DisplayActiveDice();
        }

        private void MinusD4Button_Click(object sender, RoutedEventArgs e)
        {
            if (d4 > 0)
            {
                d4--;
                DisplayActiveDice();
            }
        }

        private void MinusD6Button_Click(object sender, RoutedEventArgs e)
        {
            if (d6 > 0)
            {
                d6--;
                DisplayActiveDice();
            }
        }

        private void MinusD8Button_Click(object sender, RoutedEventArgs e)
        {
            if (d8 > 0)
            {
                d8--;
                DisplayActiveDice();
            }
        }

        private void MinusD10Button_Click(object sender, RoutedEventArgs e)
        {
            if (d10 > 0)
            {
                d10--;
                DisplayActiveDice();
            }
        }

        private void MinusD12Button_Click(object sender, RoutedEventArgs e)
        {
            if (d12 > 0)
            {
                d12--;
                DisplayActiveDice();
            }
        }

        private void MinusD20Button_Click(object sender, RoutedEventArgs e)
        {
            if (d20 > 0)
            {
                d20--;
                DisplayActiveDice();
            }
        }

        private void MinusD100Button_Click(object sender, RoutedEventArgs e)
        {
            if (d100 > 0)
            {
                d100--;
                DisplayActiveDice();
            }
        }

        public void Roll()
        {
            
            OutputTextBox.Text = "";
            int grandTotal = 0;
            Random rand = new Random();
            if (d4 > 0)
            {
                int total = 0;
                for (int x = 0; x < d4; x++)
                {
                    int val = rand.Next(1, 4);
                    total += val;
                    OutputTextBox.AppendText(val + ", ");
                }
                grandTotal += total;
                OutputTextBox.Text = OutputTextBox.Text.Remove(OutputTextBox.Text.Length - 2);
                OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText("D4 total: " + total + "\r\n");
            }

            if (d6 > 0)
            {
                int total = 0;
                for (int x = 0; x < d6; x++)
                {
                    int val = rand.Next(1, 6);
                    total += val;
                    OutputTextBox.AppendText(val + ", ");
                }
                grandTotal += total;
                OutputTextBox.Text = OutputTextBox.Text.Remove(OutputTextBox.Text.Length - 2);
                OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText("D6 total: " + total + "\r\n");
            }

            if (d8 > 0)
            {
                int total = 0;
                for (int x = 0; x < d8; x++)
                {
                    int val = rand.Next(1, 8);
                    total += val;
                    OutputTextBox.AppendText(val + ", ");
                }
                grandTotal += total;
                OutputTextBox.Text = OutputTextBox.Text.Remove(OutputTextBox.Text.Length - 2);
                OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText("D8 total: " + total + "\r\n");
            }

            if (d10 > 0)
            {
                int total = 0;
                for (int x = 0; x < d10; x++)
                {
                    int val = rand.Next(1, 10);
                    total += val;
                    OutputTextBox.AppendText(val + ", ");
                }
                grandTotal += total;
                OutputTextBox.Text = OutputTextBox.Text.Remove(OutputTextBox.Text.Length - 2);
                OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText("D10 total: " + total + "\r\n");
            }

            if (d12 > 0)
            {
                int total = 0;
                for (int x = 0; x < d12; x++)
                {
                    int val = rand.Next(1, 12);
                    total += val;
                    OutputTextBox.AppendText(val + ", ");
                }
                grandTotal += total;
                OutputTextBox.Text = OutputTextBox.Text.Remove(OutputTextBox.Text.Length - 2);
                OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText("D12 total: " + total + "\r\n");
            }

            if (d20 > 0)
            {
                int total = 0;
                for (int x = 0; x < d20; x++)
                {
                    int val = rand.Next(1, 20);
                    total += val;
                    OutputTextBox.AppendText(val + ", ");
                }
                grandTotal += total;
                OutputTextBox.Text = OutputTextBox.Text.Remove(OutputTextBox.Text.Length - 2);
                OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText("D20 total: " + total + "\r\n");
            }

            if (d100 > 0)
            {
                int total = 0;
                for (int x = 0; x < d100; x++)
                {
                    int val = rand.Next(1, 100);
                    total += val;
                    OutputTextBox.AppendText(val + ", ");
                }
                grandTotal += total;
                OutputTextBox.Text = OutputTextBox.Text.Remove(OutputTextBox.Text.Length - 2);
                OutputTextBox.AppendText("\r\n");
                OutputTextBox.AppendText("D100 total: " + total + "\r\n");
            }

            OutputTextBox.AppendText("Grand Total: " + grandTotal);
        }

        private void ClearAllButton_Click(object sender, RoutedEventArgs e)
        {
            d4 = 0;
            d6 = 0;
            d8 = 0;
            d10 = 0;
            d12 = 0;
            d20 = 0;
            d100 = 0;
            OutputTextBox.Text = String.Empty;
            ActiveDiceTextBox.Text = String.Empty;
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            Roll();
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if (_isLoaded)
            {
                if (sizeInfo.WidthChanged)
                {
                    this.Width = sizeInfo.NewSize.Height * _aspectRatio;
                }
                else
                {
                    this.Height = sizeInfo.NewSize.Width * _aspectRatio;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _aspectRatio = this.ActualWidth / this.ActualHeight;
            _isLoaded = true;
        }
    }
}

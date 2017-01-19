using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DungeonManagerWpf
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        private int _maxValue = Int32.MaxValue;
        private int _minValue = Int32.MinValue;

        private int _value;

        private EventHandler<ValueChangedEventArgs> _onValueChangedEvent;
        public event EventHandler<ValueChangedEventArgs> OnValueChangedEvent
        {
            add { _onValueChangedEvent += value; }
            remove { _onValueChangedEvent -= value; }
        }

        private void ValueChanged(ValueChangedEventArgs args)
        {
            _onValueChangedEvent?.Invoke(this, args);
        }

        //public int Value {
        //    get { return _value; }
        //    set {
        //        int v = _value;
        //        _value = value;
        //        NumberTextBox.Text = _value.ToString();
        //        ValueChanged(new ValueChangedEventArgs(_value, v));
        //    }
        //}

        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }
            set
            {
                int v = _value;
                _value = value;
                NumberTextBox.Text = _value.ToString();
                ValueChanged(new ValueChangedEventArgs(_value, v));
                SetValue(ValueProperty, value);
            }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new PropertyMetadata(2));

        public int MaxValue { get { return _maxValue; } set { _maxValue = value; } }
        public int MinValue { get { return _minValue; } set { _minValue = value; } }

        public NumericUpDown()
        {
            InitializeComponent();
        }

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int val = 0;
            if (Int32.TryParse(NumberTextBox.Text, out val))
            {
                Value = val;
                NumberTextBox.BorderBrush = new SolidColorBrush(Colors.LightGray);
            }
            else
            {
                NumberTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }

        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            int val = Value + 1;
            if (val <= MaxValue)
                Value = val;
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            int val = Value - 1;
            if (val >= MinValue)
                Value = val;
        }

        private void NumberTetBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsNumber(e.Text);
        }

        private static bool IsNumber(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return regex.IsMatch(text);
        }

        private void NumberTetBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NumberTextBox.Text == string.Empty)
                NumberTextBox.Text = "0";
        }
    }

    public class ValueChangedEventArgs : EventArgs
    {
        public int NewValue;
        public int OldValue;

        public ValueChangedEventArgs(int NewValue, int OldValue)
        {
            this.NewValue = NewValue;
            this.OldValue = OldValue;
        }
    }
}

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

namespace DungeonManagerWpf
{
    /// <summary>
    /// Interaction logic for AttributeControl.xaml
    /// </summary>
    public partial class AttributeControl : UserControl
    {

        public AttributeControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        private string _attributeName;
        private int _modifier;

        public string AttributeName
        {
            get { return _attributeName; }
            set { _attributeName = value; _label.Content = value; }
        }

        public int AttributeValue
        {
            get { return (int)GetValue(AttributeValueProperty); }
            set { SetValue(AttributeValueProperty, value); NumericValue.Value = value; UpdateModifierString(); }
        }

        public int ModifierValue
        {
            get { return GetModifier(AttributeValue); }
        }

        private string ModifierString
        {
            get
            {
                return (string)GetValue(ModifierStringProperty);
            }
            set
            {
                SetValue(ModifierStringProperty, value);
            }
        }

        public static readonly DependencyProperty ModifierStringProperty = DependencyProperty.Register("ModifierString", typeof(string), typeof(AttributeControl), new PropertyMetadata("+0"));

        public static readonly DependencyProperty AttributeValueProperty = DependencyProperty.Register("AttributeValue", typeof(int), typeof(AttributeControl), new PropertyMetadata(10));

        private void UpdateModifierString()
        {
            var i = ModifierValue;
            var s = "";
            if (i < 0)
                s = i.ToString();
            else s = "+" + i;
            ModifierString = s;
        }

        private void NumericUpDown_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            try
            {
                if (e.NewValue != e.OldValue)
                {
                    AttributeValue = e.NewValue;
                    ValueChanged(new ValueChangedEventArgs(e.NewValue, e.OldValue));
                }
            }
            catch { }
        }

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

        public static int GetModifier(int AbilityScore)
        {
            // As per DMG, 30 is the largest ability score a creature can have.
            if (AbilityScore < 1 || AbilityScore > 30)
                throw new ArgumentOutOfRangeException("Must be 1 through 30");
            return (int)Math.Floor(((double)(AbilityScore - 10)) / 2.0);
        }
    }
}

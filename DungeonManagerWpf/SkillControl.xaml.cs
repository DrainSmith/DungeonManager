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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DungeonManagerWpf
{
    /// <summary>
    /// Interaction logic for SkillControl.xaml
    /// </summary>
    public partial class SkillControl : UserControl
    {
        public string SkillName
        {
            get { return (string)GetValue(SkillNameProperty); }
            set { SetValue(SkillNameProperty, value); }
        }

        public int BaseAttribute
        {
            get { return (int)GetValue(BaseAttributeModProperty); }
            set { SetValue(BaseAttributeModProperty, value); }
        }

        public int ProficiencyBonus
        {
            get { return (int)GetValue(ProficiencyBonusProperty); }
            set { SetValue(ProficiencyBonusProperty, value); }
        }

        public Proficiency SkillProficiency
        {
            get { return (Proficiency)GetValue(SkillProficiencyProperty); }
            set { SetValue(SkillProficiencyProperty, value); }
        }

        private string ModifierString
        {
            get {return (string)GetValue(ModifierStringProperty);}
            set {SetValue(ModifierStringProperty, value);}
        }

        public bool JackOfAllTrades
        {
            get { return (bool)GetValue(JackOfAllTradesProperty); }
            set { SetValue(JackOfAllTradesProperty, value); }
        }

        public static readonly DependencyProperty SkillNameProperty =
      DependencyProperty.Register("SkillName", typeof(string),
        typeof(SkillControl), new PropertyMetadata(""));

        public static readonly DependencyProperty BaseAttributeModProperty =
      DependencyProperty.Register("BaseAttribute", typeof(int),
        typeof(SkillControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(BaseAttributeModProperty_PropertyChanged)));

        public static readonly DependencyProperty JackOfAllTradesProperty = DependencyProperty.Register("JackOfAllTrades", typeof(bool), typeof(SkillControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(JackOfAllTradesProperty_PropertyChanged)));

        private static void JackOfAllTradesProperty_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != args.NewValue)
            {
                SkillControl c = (SkillControl)obj;
                c.UpdateAllValues();
            }
        }

        public static readonly DependencyProperty ProficiencyBonusProperty = DependencyProperty.Register("ProficiencyBonus", typeof(int), typeof (SkillControl), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(ProficiencyBonusProperty_PropertyChanged)));

        public static readonly DependencyProperty SkillProficiencyProperty = DependencyProperty.Register("SkillProficiency", typeof(Proficiency), typeof(SkillControl), new FrameworkPropertyMetadata(Proficiency.NotProficient, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(SkillProficiencyProperty_PropertyChanged)));

        public static readonly DependencyProperty ModifierStringProperty = DependencyProperty.Register("ModifierString", typeof(string), typeof(SkillControl), new PropertyMetadata("+0"));

        public SkillControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        private static void SkillProficiencyProperty_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != args.NewValue)
            {
                SkillControl c = (SkillControl)obj;
                c.UpdateCheckBoxes();
            }
        }

        private static void ProficiencyBonusProperty_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != args.NewValue)
            {
                SkillControl c = (SkillControl)obj;
                c.UpdateAllValues();
            }
        }

        private static void BaseAttributeModProperty_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != args.NewValue)
            {
                SkillControl c = (SkillControl)obj;
                c.UpdateAllValues();
            }
        }

        public bool HideExpertise
        {
            get { if (ExpertiseCheckBox.Visibility == Visibility.Visible) return true; else return false;}
            set { ExpertiseCheckBox.Visibility = Visibility.Hidden; }
        }


        public int ModifierValue
        {
            get
            {
                var temp = GetModifier(BaseAttribute);
                if (SkillProficiency == Proficiency.Proficient)
                    temp = temp + ProficiencyBonus;
                else if (SkillProficiency == Proficiency.Expertise)
                    temp = temp + ProficiencyBonus + ProficiencyBonus;
                else if (JackOfAllTrades)
                    temp = temp + (int)Math.Floor((double)(ProficiencyBonus / 2));
                return temp;
            }
        }



        private void ExpertiseCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var oldvalue = SkillProficiency;
            if ((ExpertiseCheckBox.IsChecked == true) && (ProficiencyCheckBox.IsChecked == false))
            {
                ProficiencyCheckBox.IsChecked = true;
            }
            UpdateProficiencies();
            UpdateAllValues();
            ProficiencyChanged(new ProficiencyChangedEventArgs(SkillProficiency, oldvalue));
        }

        private void ProficiencyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var oldvalue = SkillProficiency;
            if ((ExpertiseCheckBox.IsChecked == true) && (ProficiencyCheckBox.IsChecked == false))
            {
                ExpertiseCheckBox.IsChecked = false;
                
            }
            UpdateProficiencies();
            UpdateAllValues();
            ProficiencyChanged(new ProficiencyChangedEventArgs(SkillProficiency, oldvalue));
        }

        private void UpdateAllValues()
        {
            var i = ModifierValue;
            var s = "";
            if (i < 0)
                s = i.ToString();
            else s= "+" + i;
            ModifierString = s;
        }

        private void UpdateProficiencies()
        {
            if ((ExpertiseCheckBox.IsChecked == true) && (ProficiencyCheckBox.IsChecked == true))
                SkillProficiency = Proficiency.Expertise;
            else if ((ExpertiseCheckBox.IsChecked == false) && (ProficiencyCheckBox.IsChecked == true))
                SkillProficiency = Proficiency.Proficient;
            else if ((ExpertiseCheckBox.IsChecked == false) && (ProficiencyCheckBox.IsChecked == false))
                SkillProficiency = Proficiency.NotProficient;
        }

        private void UpdateCheckBoxes()
        {
            if (SkillProficiency == Proficiency.NotProficient)
            {
                ProficiencyCheckBox.IsChecked = false;
                ExpertiseCheckBox.IsChecked = false;
            }
            else if (SkillProficiency == Proficiency.Proficient)
            {
                ProficiencyCheckBox.IsChecked = true;
                ExpertiseCheckBox.IsChecked = false;
            }
            else if (SkillProficiency == Proficiency.Expertise)
            {
                ProficiencyCheckBox.IsChecked = true;
                ExpertiseCheckBox.IsChecked = true;
            }
        }

        public static int GetModifier(int AbilityScore)
        {
            // As per DMG, 30 is the largest ability score a creature can have.
            if (AbilityScore < 1 || AbilityScore > 30)
                return 0;
                //throw new ArgumentOutOfRangeException("Must be 1 through 30");
            return (int)Math.Floor(((double)(AbilityScore - 10)) / 2.0);
        }

        private EventHandler<ProficiencyChangedEventArgs> _onProficiencyChangedEvent;
        public event EventHandler<ProficiencyChangedEventArgs> OnProficiencyChangedEvent
        {
            add { _onProficiencyChangedEvent += value; }
            remove { _onProficiencyChangedEvent -= value; }
        }

        private void ProficiencyChanged(ProficiencyChangedEventArgs args)
        {
            _onProficiencyChangedEvent?.Invoke(this, args);
        }

    }

    public class ProficiencyChangedEventArgs : EventArgs
    {
        public Proficiency NewValue;
        public Proficiency OldValue;

        public ProficiencyChangedEventArgs(Proficiency NewValue, Proficiency OldValue)
        {
            this.NewValue = NewValue;
            this.OldValue = OldValue;
        }
    }

    public enum Proficiency : byte
    {
        NotProficient = 0,
        Proficient = 1,
        Expertise = 2
    }

}

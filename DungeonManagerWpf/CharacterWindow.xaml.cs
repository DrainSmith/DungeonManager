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
using System.Windows.Shapes;

namespace DungeonManagerWpf
{
    /// <summary>
    /// Interaction logic for CharacterWindow.xaml
    /// </summary>
    public partial class CharacterWindow : Window
    {
        private Character _character;
        bool _changeOccured = false;
        private bool _isLoaded;
        private double _aspectRatio;

        public CharacterWindow(Character c)
        {
            this.DataContext = this;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Top = 0;
            this.Left = 0;
            this._character = c;
           
        }

        private void LoadCharacter(Character c)
        {
            this._character = c;
            LevelsListBox.ItemsSource = c.Levels;
            FeaturesListBox.ItemsSource = c.Features;
            CheckForJackOfAllTrades();
            ProficiencyNumeric.Content = c.ProficiencyBonus;
            NameTextBox.Text = c.Name;
            RaceComboBox.SelectedItem = c.Race;
            AlignmentComboBox.SelectedItem = c.Alignment;
            AcrobaticsSkill.SkillProficiency = (Proficiency)c.Acrobatics;
            AnimalHandlingSkill.SkillProficiency = (Proficiency)c.AnimalHandling;
            ArcanaSkill.SkillProficiency = (Proficiency)c.Arcana;
            AthleticsSkill.SkillProficiency = (Proficiency)c.Athletics;
            DeceptionSkill.SkillProficiency = (Proficiency)c.Deception;
            HistorySkill.SkillProficiency = (Proficiency)c.History;
            InsightSkill.SkillProficiency = (Proficiency)c.Insight;
            IntimidationSkill.SkillProficiency = (Proficiency)c.Intimidation;
            InvestigationSkill.SkillProficiency = (Proficiency)c.Investigation;
            MedicineSkill.SkillProficiency = (Proficiency)c.Medicine;
            NatureSkill.SkillProficiency = (Proficiency)c.Nature;
            PerceptionSkill.SkillProficiency = (Proficiency)c.Perception;
            PersuasionSkill.SkillProficiency = (Proficiency)c.Persuasion;
            ReligionSkill.SkillProficiency = (Proficiency)c.Religion;
            SleightOfHandSkill.SkillProficiency = (Proficiency)c.SleightOfHand;
            StealthSkill.SkillProficiency = (Proficiency)c.Stealth;
            SurvivalSkill.SkillProficiency = (Proficiency)c.Survival;
            StrengthSavingThrow.SkillProficiency = (Proficiency)c.StrengthSavingThrow;
            DexteritySavingThrow.SkillProficiency = (Proficiency)c.DexteritySavingThrow;
            ConstitutionSavingThrow.SkillProficiency = (Proficiency)c.ConstitutionSavingThrow;
            IntelligenceSavingThrow.SkillProficiency = (Proficiency)c.IntelligenceSavingThrow;
            WisdomSavingThrow.SkillProficiency = (Proficiency)c.WisdomSavingThrow;
            CharismaSavingThrow.SkillProficiency = (Proficiency)c.CharismaSavingThrow;

            StrengthAttribute.AttributeValue = c.Strength;
            DexterityAttribute.AttributeValue = c.Dexterity;
            ConstitutionAttribute.AttributeValue = c.Constitution;
            IntelligenceAttribute.AttributeValue = c.Intelligence;
            WisdomAttribute.AttributeValue = c.Wisdom;
            CharismaAttribute.AttributeValue = c.Charisma;

            ArmorClassNumeric.Value = c.ArmorClass;
            SpeedTextBox.Text = c.Speed.ToString();
            SpellSaveLabel.Content = c.SpellDC.ToString();
            SpellAttackLabel.Content = c.SpellAttackModifier.ToString();
            PassivePerceptionLabel.Content = c.PassivePerception;
            InitiativeNumeric.Value = c.Initiative;
            HitPointsTextBox.Text = c.HitPoints.ToString();

            
            PersonalityTextBox.Text = c.PersonalityTraits;
            IdealsTextBox.Text = c.Ideals;
            BondsTextBox.Text = c.Bonds;
            FlawsTextBox.Text = c.Flaws;
            BackgroundTextBox.Text = c.Background;
            _changeOccured = false;
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

        private void SaveCharacter(Character c)
        {
            
            int i = Settings.Characters.FindIndex(ch => ch._guid == c._guid);
            if (i != -1)
                Settings.Characters.RemoveAt(i);
            Settings.Characters.Add(c);
            Settings.SaveSettings();
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Button_Click(sender, e);
            }
            else
                DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Maximized)
                WindowState = System.Windows.WindowState.Normal;
            else WindowState = System.Windows.WindowState.Maximized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _aspectRatio = this.ActualWidth / this.ActualHeight;
            _isLoaded = true;
            LoadCharacter(_character);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_changeOccured)
            {
                var result = MessageBox.Show("Save changes?", "DungeonManager", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    SaveCharacter(_character);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _character.Name = NameTextBox.Text;
            _changeOccured = true;
        }

        private void AlignmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _character.Alignment = (CharacterAlignment)AlignmentComboBox.SelectedItem;
            _changeOccured = true;
        }

        private void RaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _character.Race = (CharacterRace)RaceComboBox.SelectedItem;
        }

        private void StrengthAttribute_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            _character.Strength = e.NewValue;
            _changeOccured = true;
        }

        private void DexterityAttribute_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            _character.Dexterity = e.NewValue;
            _changeOccured = true;
        }

        private void ConstitutionAttribute_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            _character.Constitution = e.NewValue;
            _changeOccured = true;
        }

        private void IntelligenceAttribute_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            _character.Intelligence = e.NewValue;
            _changeOccured = true;
        }

        private void WisdomAttribute_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            _character.Wisdom = e.NewValue;
            _changeOccured = true;
        }

        private void CharismaAttribute_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            _character.Charisma = e.NewValue;
            _changeOccured = true;
        }

        private void ArmorClassNumeric_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            _character.ArmorClass = e.NewValue;
            _changeOccured = true;
        }

        private void InitiativeNumeric_OnValueChangedEvent(object sender, ValueChangedEventArgs e)
        {
            _character.Initiative = e.NewValue;
            _changeOccured = true;
        }

        private void SpeedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SpeedTextBox.Text != "")
            {
                _character.Speed = Int32.Parse(SpeedTextBox.Text);
                _changeOccured = true;
            }
        }

        private static bool IsNumber(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return regex.IsMatch(text);
        }

        private void SpeedTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsNumber(e.Text);
        }

        private void StrengthSavingThrow_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.StrengthSavingThrow = (int)e.NewValue;
            _changeOccured = true;
        }

        private void DexteritySavingThrow_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.DexteritySavingThrow = (int)e.NewValue;
            _changeOccured = true;
        }

        private void ConstitutionSavingThrow_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.ConstitutionSavingThrow = (int)e.NewValue;
            _changeOccured = true;
        }

        private void IntelligenceSavingThrow_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.IntelligenceSavingThrow = (int)e.NewValue;
            _changeOccured = true;
        }

        private void WisdomSavingThrow_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Wisdom = (int)e.NewValue;
            _changeOccured = true;
        }

        private void CharismaSavingThrow_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.CharismaSavingThrow = (int)e.NewValue;
            _changeOccured = true;
        }

        private void AcrobaticsSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Acrobatics = (int)e.NewValue;
            _changeOccured = true;
        }

        private void AnimalHandlingSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.AnimalHandling = (int)e.NewValue;
            _changeOccured = true;
        }

        private void ArcanaSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Arcana = (int)e.NewValue;
            _changeOccured = true;
        }

        private void AthleticsSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Athletics = (int)e.NewValue;
            _changeOccured = true;
        }

        private void DeceptionSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Deception = (int)e.NewValue;
            _changeOccured = true;
        }

        private void HistorySkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.History = (int)e.NewValue;
            _changeOccured = true;
        }

        private void InsightSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Insight = (int)e.NewValue;
            _changeOccured = true;
        }

        private void IntimidationSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Intimidation = (int)e.NewValue;
            _changeOccured = true;
        }

        private void InvestigationSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Investigation = (int)e.NewValue;
            _changeOccured = true;
        }

        private void MedicineSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Medicine = (int)e.NewValue;
            _changeOccured = true;
        }

        private void NatureSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Nature = (int)e.NewValue;
            _changeOccured = true;
        }

        private void PerceptionSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Perception = (int)e.NewValue;
            _changeOccured = true;
        }

        private void PerformanceSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Performance = (int)e.NewValue;
            _changeOccured = true;
        }

        private void PersuasionSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Persuasion = (int)e.NewValue;
            _changeOccured = true;
        }

        private void ReligionSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Religion = (int)e.NewValue;
            _changeOccured = true;
        }

        private void SleightOfHandSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.SleightOfHand = (int)e.NewValue;
            _changeOccured = true;
        }

        private void StealthSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Stealth = (int)e.NewValue;
            _changeOccured = true;
        }

        private void SurvivalSkill_OnProficiencyChangedEvent(object sender, ProficiencyChangedEventArgs e)
        {
            _character.Survival = (int)e.NewValue;
            _changeOccured = true;
        }


        private void LevelAddButton_Click(object sender, RoutedEventArgs e)
        {
            var cl = (CharacterClass)NewLevelCombobox.SelectedItem;
            var lv = NewLevelNumeric.Value;
            var level = new Level(cl, lv);

            int i = _character.Levels.FindIndex(ch => ch.Class == cl);
            if (i != -1)
                _character.Levels.RemoveAt(i);
            _character.Levels.Add(level);
            LevelsListBox.ItemsSource = null;
            LevelsListBox.Items.Clear();
            LevelsListBox.ItemsSource = _character.Levels;
            _changeOccured = true;
        }

        private void LevelRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (LevelsListBox.SelectedIndex != -1)
            {
                var l = (Level)LevelsListBox.SelectedItem;
                _character.Levels.Remove(l);
                LevelsListBox.ItemsSource = null;
                LevelsListBox.Items.Clear();
                LevelsListBox.ItemsSource = _character.Levels;
                _changeOccured = true;
            }
        }

        private void LevelUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LevelsListBox.SelectedIndex != -1)
            {
                var l = (Level)LevelsListBox.SelectedItem;
                _character.Levels.Remove(l);
                l.LevelValue = l.LevelValue + 1;
                _character.Levels.Add(l);
                LevelsListBox.ItemsSource = null;
                LevelsListBox.Items.Clear();
                LevelsListBox.ItemsSource = _character.Levels;
                _changeOccured = true;
            }
        }

        private void PersonalityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _character.PersonalityTraits = PersonalityTextBox.Text;
            _changeOccured = true;
        }

        private void IdealsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _character.Ideals = IdealsTextBox.Text;
            _changeOccured = true;
        }

        private void BondsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _character.Bonds = BondsTextBox.Text;
            _changeOccured = true;
        }

        private void FlawsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _character.Flaws = FlawsTextBox.Text;
            _changeOccured = true;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            
        }

        private void AddFeatureButton_Click(object sender, RoutedEventArgs e)
        {
            _character.Features.Remove(NewFeatureTextBox.Text);
            _character.Features.Add(NewFeatureTextBox.Text);
            NewFeatureTextBox.Text = String.Empty;
            FeaturesListBox.ItemsSource = null;
            FeaturesListBox.Items.Clear();
            FeaturesListBox.ItemsSource = _character.Features;
            CheckForJackOfAllTrades();
            _changeOccured = true;

        }

        private void CheckForJackOfAllTrades()
        {
            var i = _character.Features.FindIndex(f => f.ToLower() == "jackofalltrades" || f.ToLower() == "jack of all trades");
            if (i != -1)
                JackOfAllTradesCheckBox.IsChecked = true;
            else JackOfAllTradesCheckBox.IsChecked = false;
        }

        private void RemoveFeaturebutton_Click(object sender, RoutedEventArgs e)
        {
            if (FeaturesListBox.SelectedIndex != -1)
            {
                _character.Features.Remove((string)FeaturesListBox.SelectedItem);
                FeaturesListBox.ItemsSource = null;
                FeaturesListBox.Items.Clear();
                FeaturesListBox.ItemsSource = _character.Features;
                CheckForJackOfAllTrades();
                _changeOccured = true;
            }
        }

        private void BackgroundTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _character.Background = BackgroundTextBox.Text;
        }
    }
}
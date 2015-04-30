using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonManager
{
    public partial class CreateCharacterForm : Form
    {
        bool isEditing = false;
        Character c;

        private void Initialize()
        {
            var alignments = Enum.GetValues(typeof(CharacterAlignment));
            foreach (var a in alignments)
                AlignmentComboBox.Items.Add(a);

            var races = Enum.GetValues(typeof(CharacterRace));
            foreach (var r in races)
                RaceComboBox.Items.Add(r);

            var classes = Enum.GetValues(typeof(CharacterClass));
            foreach (var cl in classes)
                ClassComboBox.Items.Add(cl);
}

        public CreateCharacterForm()
        {
            InitializeComponent();
            Initialize();
            c = new Character();
        }

        public CreateCharacterForm(Character _char)
        {
            InitializeComponent();
            Initialize();
            c = _char;

            isEditing = true;
            ShowCharacter();
        }

        private void ShowCharacter()
        {
            CharismaNumericUpDown.Value = c.Charisma;
            ConstitutionNumericUpDown.Value = c.Constitution;
            DexterityNumericUpDown.Value = c.Dexterity;
            IntelligenceNumericUpDown.Value = c.Intelligence;
            StrengthNumericUpDown.Value = c.Strength;
            WisdomNumericUpDown.Value = c.Wisdom;
            
            ClassListBox.Items.Clear();
            int totalLevels = 0;
            ProficiencyBonuxTextBox.Text = "0";

            foreach (Level l in c.Levels)
            {
                ClassListBox.Items.Add(l._class + ":" + l._level);
                totalLevels += l._level;
            }
            if (totalLevels < 5)
                c.ProficiencyBonus = 2;
            else if (totalLevels < 9)
                c.ProficiencyBonus = 3;
            else if (totalLevels < 13)
                c.ProficiencyBonus = 4;
            else if (totalLevels < 17)
                c.ProficiencyBonus = 5;
            else c.ProficiencyBonus = 6;

            ProficiencyBonuxTextBox.Text = c.ProficiencyBonus.ToString();

            int pp = (10 + Util.GetModifier(c.Wisdom));
            if (c.WisdomSavingThrow)
                pp += c.ProficiencyBonus;
            PassiveWisdomTextBox.Text = pp.ToString();
            SpellSaveTextBox.Text = Util.GetSpellDC(c).ToString();
            SpellAttackTextBox.Text = Util.GetSpellAttackModifier(c).ToString();

            ArmorClassNumericUpDown.Value = c.ArmorClass;
            InitiativeNumericUpDown.Value = c.Initiative;
            SpeedNumericUpDown.Value = c.Speed;

            MaxHitPointsTextBox.Text = c.HitPoints.ToString();

            NameTextBox.Text = c.Name;

            RaceComboBox.SelectedItem = c.Race;
            AlignmentComboBox.SelectedItem = c.Alignment;

            PersonalityTraitsRichTextBox.Text = c.PersonalityTraits;
            IdealsRichTextBox.Text = c.Ideals;
            BondsRichTextBox.Text = c.Bonds;
            FlawsRichTextBox.Text = c.Flaws;

            BackgroundTextBox.Text = c.Background;
            
            
            FeatureListBox.Items.Clear();
            foreach (string s in c.Features)
            {
                FeatureListBox.Items.Add(s);
            }

            if (c.StrengthSavingThrow)
            {
                StrengthCheckBox.Checked = true;
                StrengthSavingThrowTextBox.Text = (Util.GetModifier(c.Strength) + c.ProficiencyBonus).ToString();
            }
            else StrengthSavingThrowTextBox.Text = (Util.GetModifier(c.Strength)).ToString();

            if (c.DexteritySavingThrow)
            {
                DexterityCheckBox.Checked = true;
                DexteritySavingThrowTextBox.Text = (Util.GetModifier(c.Dexterity) + c.ProficiencyBonus).ToString();
            }
            else DexteritySavingThrowTextBox.Text = (Util.GetModifier(c.Dexterity)).ToString();

            if (c.ConstitutionSavingThrow)
            {
                ConstitutionCheckBox.Checked = true;
                ConstitutionSavingThrowTextBox.Text = (Util.GetModifier(c.Constitution) + c.ProficiencyBonus).ToString();
            }
            else ConstitutionSavingThrowTextBox.Text = (Util.GetModifier(c.Constitution)).ToString();

            if (c.IntelligenceSavingThrow)
            {
                IntelligenceCheckBox.Checked = true;
                IntelligenceSavingThrowTextBox.Text = (Util.GetModifier(c.Intelligence) + c.ProficiencyBonus).ToString();
            }
            else IntelligenceSavingThrowTextBox.Text = (Util.GetModifier(c.Intelligence)).ToString();

            if (c.WisdomSavingThrow)
            {
                WisdomCheckBox.Checked = true;
                WisdomSavingThrowTextBox.Text = (Util.GetModifier(c.Wisdom) + c.ProficiencyBonus).ToString();
            }
            else WisdomSavingThrowTextBox.Text = (Util.GetModifier(c.Wisdom)).ToString();

            if (c.CharismaSavingThrow)
            {
                CharismaCheckBox.Checked = true;
                CharismaSavingThrowTextBox.Text = (Util.GetModifier(c.Charisma) + c.ProficiencyBonus).ToString();
            }
            else CharismaSavingThrowTextBox.Text = (Util.GetModifier(c.Charisma)).ToString();

            if (c.Acrobatics == 0)
            {
                AcrobaticsTextBox.Text = Util.GetModifier(c.Dexterity).ToString();
            }
            else if (c.Acrobatics == 1)
            {
                AcrobaticsCheckBox1.Checked = true;
                AcrobaticsTextBox.Text = (Util.GetModifier(c.Dexterity) + c.ProficiencyBonus).ToString();
            }
            else if (c.Acrobatics == 2)
            {
                AcrobaticsCheckBox1.Checked = true;
                AcrobaticsCheckBox2.Checked = true;
                AcrobaticsTextBox.Text = (Util.GetModifier(c.Dexterity) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.AnimalHandling == 0)
            {
                AnimalHandlingTextBox.Text = Util.GetModifier(c.Wisdom).ToString();
            }
            else if (c.AnimalHandling == 1)
            {
                AnimalHandlingCheckBox1.Checked = true;
                AnimalHandlingTextBox.Text = (Util.GetModifier(c.Wisdom) + c.ProficiencyBonus).ToString();
            }
            else if (c.AnimalHandling == 2)
            {
                AnimalHandlingCheckBox1.Checked = true;
                AnimalHandlingCheckBox2.Checked = true;
                AnimalHandlingTextBox.Text = (Util.GetModifier(c.Wisdom) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Arcana == 0)
            {
                ArcanaTextBox.Text = Util.GetModifier(c.Intelligence).ToString();
            }
            else if (c.Arcana == 1)
            {
                ArcanaCheckBox1.Checked = true;
                ArcanaTextBox.Text = (Util.GetModifier(c.Intelligence) + c.ProficiencyBonus).ToString();
            }
            else if (c.Arcana == 2)
            {
                ArcanaCheckBox1.Checked = true;
                ArcanaCheckBox2.Checked = true;
                ArcanaTextBox.Text = (Util.GetModifier(c.Intelligence) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Athletics == 0)
            {
                AthleticsTextBox.Text = Util.GetModifier(c.Strength).ToString();
            }
            else if (c.Athletics == 1)
            {
                AthleticsCheckBox1.Checked = true;
                AthleticsTextBox.Text = (Util.GetModifier(c.Strength) + c.ProficiencyBonus).ToString();
            }
            else if (c.Athletics == 2)
            {
                AthleticsCheckBox1.Checked = true;
                AthleticsCheckBox2.Checked = true;
                AthleticsTextBox.Text = (Util.GetModifier(c.Strength) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Deception == 0)
            {
                DeceptionTextBox.Text = Util.GetModifier(c.Charisma).ToString();
            }
            else if (c.Deception == 1)
            {
                DeceptionCheckBox1.Checked = true;
                DeceptionTextBox.Text = (Util.GetModifier(c.Charisma) + c.ProficiencyBonus).ToString();
            }
            else if (c.Deception == 2)
            {
                DeceptionCheckBox1.Checked = true;
                DeceptionCheckBox2.Checked = true;
                DeceptionTextBox.Text = (Util.GetModifier(c.Charisma) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.History == 0)
            {
                HistoryTextBox.Text = Util.GetModifier(c.Intelligence).ToString();
            }
            else if (c.History == 1)
            {
                HistoryCheckBox1.Checked = true;
                HistoryTextBox.Text = (Util.GetModifier(c.Intelligence) + c.ProficiencyBonus).ToString();
            }
            else if (c.History == 2)
            {
                HistoryCheckBox1.Checked = true;
                HistoryCheckBox2.Checked = true;
                HistoryTextBox.Text = (Util.GetModifier(c.Intelligence) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Insight == 0)
            {
                InsightTextBox.Text = Util.GetModifier(c.Wisdom).ToString();
            }
            else if (c.Insight == 1)
            {
                InsightCheckBox1.Checked = true;
                InsightTextBox.Text = (Util.GetModifier(c.Wisdom) + c.ProficiencyBonus).ToString();
            }
            else if (c.Insight == 2)
            {
                InsightCheckBox1.Checked = true;
                InsightCheckBox2.Checked = true;
                InsightTextBox.Text = (Util.GetModifier(c.Wisdom) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Intimidation == 0)
            {
                IntimidationTextBox.Text = Util.GetModifier(c.Charisma).ToString();
            }
            else if (c.Intimidation == 1)
            {
                IntimidationCheckBox1.Checked = true;
                IntimidationTextBox.Text = (Util.GetModifier(c.Charisma) + c.ProficiencyBonus).ToString();
            }
            else if (c.Intimidation == 2)
            {
                IntimidationCheckBox1.Checked = true;
                IntimidationCheckBox2.Checked = true;
                IntimidationTextBox.Text = (Util.GetModifier(c.Charisma) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Investigation == 0)
            {
                InvestigationTextBox.Text = Util.GetModifier(c.Intelligence).ToString();
            }
            else if (c.Investigation == 1)
            {
                InvestigationCheckBox1.Checked = true;
                InvestigationTextBox.Text = (Util.GetModifier(c.Intelligence) + c.ProficiencyBonus).ToString();
            }
            else if (c.Investigation == 2)
            {
                InvestigationCheckBox1.Checked = true;
                InvestigationCheckBox2.Checked = true;
                InvestigationTextBox.Text = (Util.GetModifier(c.Intelligence) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Medicine == 0)
            {
                MedicineTextBox.Text = Util.GetModifier(c.Wisdom).ToString();
            }
            else if (c.Medicine == 1)
            {
                MedicineCheckBox1.Checked = true;
                MedicineTextBox.Text = (Util.GetModifier(c.Wisdom) + c.ProficiencyBonus).ToString();
            }
            else if (c.Medicine == 2)
            {
                MedicineCheckBox1.Checked = true;
                MedicineCheckBox2.Checked = true;
                MedicineTextBox.Text = (Util.GetModifier(c.Wisdom) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Nature == 0)
            {
                NatureTextBox.Text = Util.GetModifier(c.Intelligence).ToString();
            }
            else if (c.Nature == 1)
            {
                NatureCheckBox1.Checked = true;
                NatureTextBox.Text = (Util.GetModifier(c.Intelligence) + c.ProficiencyBonus).ToString();
            }
            else if (c.Nature == 2)
            {
                NatureCheckBox1.Checked = true;
                NatureCheckBox2.Checked = true;
                NatureTextBox.Text = (Util.GetModifier(c.Intelligence) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Perception == 0)
            {
                PerceptionTextBox.Text = Util.GetModifier(c.Wisdom).ToString();
            }
            else if (c.Perception == 1)
            {
                PerceptionCheckBox1.Checked = true;
                PerceptionTextBox.Text = (Util.GetModifier(c.Wisdom) + c.ProficiencyBonus).ToString();
            }
            else if (c.Perception == 2)
            {
                PerceptionCheckBox1.Checked = true;
                PerceptionCheckBox2.Checked = true;
                PerceptionTextBox.Text = (Util.GetModifier(c.Wisdom) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Performance == 0)
            {
                PerformanceTextBox.Text = Util.GetModifier(c.Charisma).ToString();
            }
            else if (c.Performance == 1)
            {
                PerformanceCheckBox1.Checked = true;
                PerformanceTextBox.Text = (Util.GetModifier(c.Charisma) + c.ProficiencyBonus).ToString();
            }
            else if (c.Performance == 2)
            {
                PerformanceCheckBox1.Checked = true;
                PerformanceCheckBox2.Checked = true;
                PerformanceTextBox.Text = (Util.GetModifier(c.Charisma) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Persuasion == 0)
            {
                PersuasionTextBox.Text = Util.GetModifier(c.Charisma).ToString();
            }
            else if (c.Persuasion == 1)
            {
                PersuasionCheckBox1.Checked = true;
                PersuasionTextBox.Text = (Util.GetModifier(c.Charisma) + c.ProficiencyBonus).ToString();
            }
            else if (c.Persuasion == 2)
            {
                PersuasionCheckBox1.Checked = true;
                PersuasionCheckBox2.Checked = true;
                PersuasionTextBox.Text = (Util.GetModifier(c.Charisma) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Religion == 0)
            {
                ReligionTextBox.Text = Util.GetModifier(c.Intelligence).ToString();
            }
            else if (c.Religion == 1)
            {
                ReligionCheckBox1.Checked = true;
                ReligionTextBox.Text = (Util.GetModifier(c.Intelligence) + c.ProficiencyBonus).ToString();
            }
            else if (c.Religion == 2)
            {
                ReligionCheckBox1.Checked = true;
                ReligionCheckBox2.Checked = true;
                ReligionTextBox.Text = (Util.GetModifier(c.Intelligence) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.SleightOfHand == 0)
            {
                SleightOfHandTextBox.Text = Util.GetModifier(c.Dexterity).ToString();
            }
            else if (c.SleightOfHand == 1)
            {
                SleightOfHandCheckBox1.Checked = true;
                SleightOfHandTextBox.Text = (Util.GetModifier(c.Dexterity) + c.ProficiencyBonus).ToString();
            }
            else if (c.SleightOfHand == 2)
            {
                SleightOfHandCheckBox1.Checked = true;
                SleightOfHandCheckBox2.Checked = true;
                SleightOfHandTextBox.Text = (Util.GetModifier(c.Dexterity) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Stealth == 0)
            {
                StealthTextBox.Text = Util.GetModifier(c.Dexterity).ToString();
            }
            else if (c.Stealth == 1)
            {
                StealthCheckBox1.Checked = true;
                StealthTextBox.Text = (Util.GetModifier(c.Dexterity) + c.ProficiencyBonus).ToString();
            }
            else if (c.Stealth == 2)
            {
                StealthCheckBox1.Checked = true;
                StealthCheckBox2.Checked = true;
                StealthTextBox.Text = (Util.GetModifier(c.Dexterity) + (c.ProficiencyBonus * 2)).ToString();
            }

            if (c.Survival == 0)
            {
                SurvivalTextBox.Text = Util.GetModifier(c.Wisdom).ToString();
            }
            else if (c.Survival == 1)
            {
                SurvivalCheckBox1.Checked = true;
                SurvivalTextBox.Text = (Util.GetModifier(c.Wisdom) + c.ProficiencyBonus).ToString();
            }
            else if (c.Survival == 2)
            {
                SurvivalCheckBox1.Checked = true;
                SurvivalCheckBox2.Checked = true;
                SurvivalTextBox.Text = (Util.GetModifier(c.Wisdom) + (c.ProficiencyBonus * 2)).ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClassListBox.Items.Add(ClassComboBox.Text +":"+ LevelNumericUpDown.Value);
            c.Levels.Add(new Level() { _class = (CharacterClass)ClassComboBox.SelectedItem, _level = (int)LevelNumericUpDown.Value });
            ShowCharacter();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                int i = Settings.Characters.FindIndex(ch => ch._guid == c._guid);
                Settings.Characters.RemoveAt(i);
            }

            Settings.Characters.Add(c);
            Settings.SaveSettings();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Settings.MainForm.RefreshCharacters();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ClassListBox.SelectedIndex != -1)
            {
                string[] s = ClassListBox.SelectedItem.ToString().Split(':');
                int i = c.Levels.FindIndex(l => l._class == (CharacterClass)Enum.Parse(typeof(CharacterClass), s[0]) && l._level == Int32.Parse(s[1]));
                c.Levels.RemoveAt(i);
                ClassListBox.Items.RemoveAt(ClassListBox.SelectedIndex);
            }
            ShowCharacter();
        }

        private void StrengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.Strength = (int)StrengthNumericUpDown.Value;
            StrModifierLabel.Text = Util.GetModifier(c.Strength).ToString();
            ShowCharacter();
        }

        private void DexterityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.Dexterity = (int)DexterityNumericUpDown.Value;
            DexModifierLabel.Text = Util.GetModifier(c.Dexterity).ToString();
            ShowCharacter();
        }

        private void ConstitutionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.Constitution = (int)ConstitutionNumericUpDown.Value;
            ConModifierLabel.Text = Util.GetModifier(c.Constitution).ToString();
            ShowCharacter();
        }

        private void IntelligenceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.Intelligence = (int)IntelligenceNumericUpDown.Value;
            IntModifierLabel.Text = Util.GetModifier(c.Intelligence).ToString();
            ShowCharacter();
        }

        private void WisdomeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.Wisdom = (int)WisdomNumericUpDown.Value;
            WisModifierLabel.Text = Util.GetModifier(c.Wisdom).ToString();
            ShowCharacter();
        }

        private void CharismaNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.Charisma = (int)CharismaNumericUpDown.Value;
            ChaModifierLabel.Text = Util.GetModifier(c.Charisma).ToString();
            ShowCharacter();
        }

        private void AcrobaticsCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (AcrobaticsCheckBox1.Checked && AcrobaticsCheckBox2.Checked)
                c.Acrobatics = 2;
            else if (AcrobaticsCheckBox1.Checked)
                c.Acrobatics = 1;
            else
            {
                AcrobaticsCheckBox2.Checked = false;
                c.Acrobatics = 0;
            }
            ShowCharacter();
        }

        private void AnimalHandlingCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (AnimalHandlingCheckBox1.Checked && AnimalHandlingCheckBox2.Checked)
                c.AnimalHandling = 2;
            else if (AnimalHandlingCheckBox1.Checked)
                c.AnimalHandling = 1;
            else
            {
                AnimalHandlingCheckBox2.Checked = false;
                c.AnimalHandling = 0;
            }
            ShowCharacter();
        }

        private void ArcanaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ArcanaCheckBox1.Checked && ArcanaCheckBox2.Checked)
                c.Arcana = 2;
            else if (ArcanaCheckBox1.Checked)
                c.Arcana = 1;
            else
            {
                ArcanaCheckBox2.Checked = false;
                c.Arcana = 0;
            }
            ShowCharacter();
        }

        private void AthleticsCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (AthleticsCheckBox1.Checked && AthleticsCheckBox2.Checked)
                c.Athletics = 2;
            else if (AthleticsCheckBox1.Checked)
                c.Athletics = 1;
            else
            {
                AthleticsCheckBox2.Checked = false;
                c.Athletics = 0;
            }
            ShowCharacter();
        }

        private void DeceptionCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DeceptionCheckBox1.Checked && DeceptionCheckBox2.Checked)
                c.Deception = 2;
            else if (DeceptionCheckBox1.Checked)
                c.Deception = 1;
            else
            {
                DeceptionCheckBox2.Checked = false;
                c.Deception = 0;
            }
            ShowCharacter();
        }

        private void HistoryCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (HistoryCheckBox1.Checked && HistoryCheckBox2.Checked)
                c.History = 2;
            else if (HistoryCheckBox1.Checked)
                c.History = 1;
            else
            {
                HistoryCheckBox2.Checked = false;
                c.History = 0;
            }
            ShowCharacter();
        }

        private void InsightCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (InsightCheckBox1.Checked && InsightCheckBox2.Checked)
                c.Insight = 2;
            else if (InsightCheckBox1.Checked)
                c.Insight = 1;
            else
            {
                InsightCheckBox2.Checked = false;
                c.Insight = 0;
            }
            ShowCharacter();
        }

        private void IntimidationCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (IntimidationCheckBox1.Checked && IntimidationCheckBox2.Checked)
                c.Intimidation = 2;
            else if (IntimidationCheckBox1.Checked)
                c.Intimidation = 1;
            else
            {
                IntimidationCheckBox2.Checked = false;
                c.Intimidation = 0;
            }
            ShowCharacter();
        }

        private void InvestigationCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (InvestigationCheckBox1.Checked && InvestigationCheckBox2.Checked)
                c.Investigation = 2;
            else if (InvestigationCheckBox1.Checked)
                c.Investigation = 1;
            else
            {
                InvestigationCheckBox2.Checked = false;
                c.Investigation = 0;
            }
            ShowCharacter();
        }

        private void MedicineCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (MedicineCheckBox1.Checked && MedicineCheckBox2.Checked)
                c.Medicine = 2;
            else if (MedicineCheckBox1.Checked)
                c.Medicine = 1;
            else
            {
                MedicineCheckBox2.Checked = false;
                c.Medicine = 0;
            }
            ShowCharacter();
        }

        private void NatureCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (NatureCheckBox1.Checked && NatureCheckBox2.Checked)
                c.Nature = 2;
            else if (NatureCheckBox1.Checked)
                c.Nature = 1;
            else
            {
                NatureCheckBox2.Checked = false;
                c.Nature = 0;
            }
            ShowCharacter();
        }

        private void PerceptionCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PerceptionCheckBox1.Checked && PerceptionCheckBox2.Checked)
                c.Perception = 2;
            else if (PerceptionCheckBox1.Checked)
                c.Perception = 1;
            else
            {
                PerceptionCheckBox2.Checked = false;
                c.Perception = 0;
            }
            ShowCharacter();
        }

        private void PerformanceCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PerformanceCheckBox1.Checked && PerformanceCheckBox2.Checked)
                c.Performance = 2;
            else if (PerformanceCheckBox1.Checked)
                c.Performance = 1;
            else
            {
                PerformanceCheckBox2.Checked = false;
                c.Performance = 0;
            }
            ShowCharacter();
        }

        private void PersuasionCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PersuasionCheckBox1.Checked && PersuasionCheckBox2.Checked)
                c.Persuasion = 2;
            else if (PersuasionCheckBox1.Checked)
                c.Persuasion = 1;
            else
            {
                PersuasionCheckBox2.Checked = false;
                c.Persuasion = 0;
            }
            ShowCharacter();
        }

        private void ReligionCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ReligionCheckBox1.Checked && ReligionCheckBox2.Checked)
                c.Religion = 2;
            else if (ReligionCheckBox1.Checked)
                c.Religion = 1;
            else
            {
                ReligionCheckBox2.Checked = false;
                c.Religion = 0;
            }
            ShowCharacter();
        }

        private void SleightOfHandCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (SleightOfHandCheckBox1.Checked && SleightOfHandCheckBox2.Checked)
                c.SleightOfHand = 2;
            else if (SleightOfHandCheckBox1.Checked)
                c.SleightOfHand = 1;
            else
            {
                SleightOfHandCheckBox2.Checked = false;
                c.SleightOfHand = 0;
            }
            ShowCharacter();
        }

        private void StealthCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (StealthCheckBox1.Checked && StealthCheckBox2.Checked)
                c.Stealth = 2;
            else if (StealthCheckBox1.Checked)
                c.Stealth = 1;
            else
            {
                StealthCheckBox2.Checked = false;
                c.Stealth = 0;
            }
            ShowCharacter();
        }

        private void SurvivalCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (SurvivalCheckBox1.Checked && SurvivalCheckBox2.Checked)
                c.Survival = 2;
            else if (SurvivalCheckBox1.Checked)
                c.Survival = 1;
            else
            {
                SurvivalCheckBox2.Checked = false;
                c.Survival = 0;
            }
            ShowCharacter();
        }

        private void StrengthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            c.StrengthSavingThrow = StrengthCheckBox.Checked;
            ShowCharacter();
        }

        private void DexterityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            c.DexteritySavingThrow = DexterityCheckBox.Checked;
            ShowCharacter();
        }

        private void ConstitutionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            c.ConstitutionSavingThrow = ConstitutionCheckBox.Checked;
            ShowCharacter();
        }

        private void IntelligenceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            c.IntelligenceSavingThrow = IntelligenceCheckBox.Checked;
            ShowCharacter();
        }

        private void WisdomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            c.WisdomSavingThrow = WisdomCheckBox.Checked;
            ShowCharacter();
        }

        private void CharismaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            c.CharismaSavingThrow = CharismaCheckBox.Checked;
            ShowCharacter();
        }

        private void AlignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.Alignment = (CharacterAlignment)AlignmentComboBox.SelectedItem;
        }

        private void RaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.Race = (CharacterRace)RaceComboBox.SelectedItem;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            c.Name = NameTextBox.Text;
        }

        private void ArmorClassNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.ArmorClass = (int)ArmorClassNumericUpDown.Value;
        }

        private void InitiativeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.Initiative = (int)InitiativeNumericUpDown.Value;
        }

        private void SpeedNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            c.Speed = (int)SpeedNumericUpDown.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            FeatureListBox.Items.Add(NewFeatureTextBox.Text);
            c.Features.Add(NewFeatureTextBox.Text);
            NewFeatureTextBox.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (FeatureListBox.SelectedItems.Count == 1)
            {
                c.Features.Remove(FeatureListBox.SelectedItem.ToString());
                FeatureListBox.Items.RemoveAt(FeatureListBox.SelectedIndex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ClassListBox.SelectedItems.Count == 1)
            {
                string[] s = ClassListBox.SelectedItem.ToString().Split(':');
                int i = c.Levels.FindIndex(l => l._class == (CharacterClass)Enum.Parse(typeof(CharacterClass), s[0]) && l._level == Int32.Parse(s[1]));
                c.Levels.RemoveAt(i);
                ClassListBox.Items.RemoveAt(ClassListBox.SelectedIndex);
                c.Levels.Add(new Level() { _class = (CharacterClass)Enum.Parse(typeof(CharacterClass), s[0]), _level = Int32.Parse(s[1]) + 1 });
                ShowCharacter();
            }
        }

        private void MaxHitPointsTextBox_TextChanged(object sender, EventArgs e)
        {

            try 
            { 
                c.HitPoints = Int32.Parse(MaxHitPointsTextBox.Text);
            }
            catch
            {}
        }

        private void XpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MaxHitPointsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PersonalityTraitsRichTextBox_TextChanged(object sender, EventArgs e)
        {
            c.PersonalityTraits = PersonalityTraitsRichTextBox.Text;
        }

        private void IdealsRichTextBox_TextChanged(object sender, EventArgs e)
        {
            c.Ideals = IdealsRichTextBox.Text;
        }

        private void BondsRichTextBox_TextChanged(object sender, EventArgs e)
        {
            c.Bonds = BondsRichTextBox.Text;
        }

        private void FlawsRichTextBox_TextChanged(object sender, EventArgs e)
        {
            c.Flaws = FlawsRichTextBox.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            c.Background = BackgroundTextBox.Text;
        }

        
    }
}

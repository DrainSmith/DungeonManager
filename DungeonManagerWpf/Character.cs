using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonManagerWpf
{
    [Serializable]
    public class Character
    {
        public string _guid { get; set; }
        public int _sortOrder { get; set; }
        public string Name { get; set; }
        public List<Level> Levels = new List<Level>();
        public List<string> Features = new List<string>();
        public CharacterRace Race ;
        public CharacterAlignment Alignment;
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Strength = 10;
        public int Dexterity = 10;
        public int Constitution = 10;
        public int Intelligence = 10;
        public int Wisdom = 10;
        public int Charisma = 10;

        public int StrengthSavingThrow;
        public int DexteritySavingThrow;
        public int ConstitutionSavingThrow;
        public int IntelligenceSavingThrow;
        public int WisdomSavingThrow;
        public int CharismaSavingThrow;

        public int Initiative;
        public int Speed;

        public int Acrobatics = 0; // 0 - not proficient, 1 - proficient, 2 - double proficient
        public int AnimalHandling = 0;
        public int Arcana = 0;
        public int Athletics = 0;
        public int Deception = 0;
        public int History = 0;
        public int Insight = 0;
        public int Intimidation = 0;
        public int Investigation = 0;
        public int Medicine = 0;
        public int Nature = 0;
        public int Perception = 0;
        public int Performance = 0;
        public int Persuasion = 0;
        public int Religion = 0;
        public int SleightOfHand = 0;
        public int Stealth = 0;
        public int Survival = 0;

        public string Background;
        public string PersonalityTraits;
        public string Ideals;
        public string Bonds;
        public string Flaws;

        public Character()
        {
            _guid = Guid.NewGuid().ToString();
            _sortOrder = (new Random()).Next(10, 30);
        }

        [System.Xml.Serialization.XmlIgnore]
        public int ProficiencyBonus
        {
            get
            {
                int totalLevel = Levels.Sum(item => item.LevelValue);
                return 2 + (totalLevel - 1) / 4;
            }
        }

        public static int GetModifier(int AbilityScore)
        {
            // As per DMG, 30 is the largest ability score a creature can have.
            if (AbilityScore < 1 || AbilityScore > 30)
                throw new ArgumentOutOfRangeException("Must be 1 through 30");
            return (int)Math.Floor(((double)(AbilityScore - 10)) / 2.0);
        }

        private int getCastingAbilityVal()
        {
            int retVal = 0;
            List<CharacterClass> chaClasses = new List<CharacterClass>() {
                CharacterClass.Bard, 
                CharacterClass.Sorcerer, 
                CharacterClass.Paladin, 
                CharacterClass.Warlock 
            };
            List<CharacterClass> intClasses = new List<CharacterClass>() {
                CharacterClass.Fighter,
                CharacterClass.Rogue,
                CharacterClass.Wizard
            };
            List<CharacterClass> wisClasses = new List<CharacterClass>() {
                CharacterClass.Druid,
                CharacterClass.Ranger,
                CharacterClass.Monk,
                CharacterClass.Cleric
            };

            foreach (Level l in Levels)
            {
                if (wisClasses.Contains(l.Class))
                    retVal = (GetModifier(Wisdom) > retVal) ? GetModifier(Wisdom) : retVal;
                if (intClasses.Contains(l.Class))
                    retVal = (GetModifier(Intelligence) > retVal) ? GetModifier(Intelligence) : retVal;
                if (chaClasses.Contains(l.Class))
                    retVal = (GetModifier(Charisma) > retVal) ? GetModifier(Charisma) : retVal;
            }
            return retVal;
        }

        public int SpellDC
        {
            get
            {
                return getCastingAbilityVal() + 8 + ProficiencyBonus;
            }
        }

        public int SpellAttackModifier
        {
            get
            {
                return getCastingAbilityVal() + ProficiencyBonus;
            }
        }

        public int PassivePerception
        {
            get
            {
                int retval = 10 + GetModifier(Wisdom);
                if (Perception == 1)
                    retval += ProficiencyBonus;
                if (Perception == 2)
                    retval += ProficiencyBonus * 2;
                return retval;
            }
        }
       
    }

    [Serializable]
    public class Level
    {
        public CharacterClass Class;
        public int LevelValue;

        public Level() { }

        public Level(CharacterClass Class, int LevelValue)
        {
            this.Class = Class;
            this.LevelValue = LevelValue;
        }

        public override string ToString()
        {
            return Class + " : " + LevelValue;
        }
    }

    [Serializable]
    public enum CharacterRace
    {
        Dwarf,
        Elf,
        Halfling,
        Human,
        Dragonborn,
        Gnome,
        HalfElf,
        HalfOrc,
        Tiefling,
        AirGenasi,
        EarthGenasi,
        WaterGenasi,
        FireGenasi,
        Arakocra,
        DeepGnome,
        Goliath
    }

    [Serializable]
    public enum CharacterClass
    {
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    }

    [Serializable]
    public enum CharacterAlignment
    {
        LawfulGood,
        ChaoticGood,
        NeutralGood,
        LawfulNeutral,
        ChaoticNeutral,
        TrueNeutral,
        LawfulEvil,
        ChaoticEvil,
        NeutralEvil
    }

    public class CharacterComparer : IComparer<Character>
    {
        public int Compare(Character a, Character b)
        {
            if (a._sortOrder > b._sortOrder)
                return 1;
            else if (a._sortOrder < b._sortOrder)
                return -1;
            else return 0;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonManager
{
    [Serializable]
    public class Character
    {
        public string _guid;
        public string Name;
        public List<Level> Levels = new List<Level>();
        public List<string> Features = new List<string>();
        public CharacterRace Race;
        public CharacterAlignment Alignment;
        public int HitPoints;
        public int ArmorClass;
        public int Strength = 10;
        public int Dexterity = 10;
        public int Constitution = 10;
        public int Intelligence = 10;
        public int Wisdom = 10;
        public int Charisma = 10;

        public bool StrengthSavingThrow;
        public bool DexteritySavingThrow;
        public bool ConstitutionSavingThrow;
        public bool IntelligenceSavingThrow;
        public bool WisdomSavingThrow;
        public bool CharismaSavingThrow;

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
        }

        [System.Xml.Serialization.XmlIgnore]
        public int ProficiencyBonus
        {
            get 
            {
                int totalLevel = Levels.Sum(item => item._level);
                return 2 + (totalLevel - 1) / 4;
            }
        }

        public static int GetModifier(int AbilityScore)
        {
            // As per DMG, 30 is the largest ability score a creature can have.
            if (AbilityScore < 1 || AbilityScore > 30)
                throw new ArgumentOutOfRangeException("Must be 1 through 25");
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
                if(wisClasses.Contains(l._class))
                    retVal = (GetModifier(Wisdom) > retVal) ? GetModifier(Wisdom) : retVal;
                if(intClasses.Contains(l._class))
                    retVal = (GetModifier(Intelligence) > retVal) ? GetModifier(Intelligence) : retVal;
                if (chaClasses.Contains(l._class))
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
    }

    [Serializable]
    public class Level
    {
        public CharacterClass _class;
        public int _level;

        public Level() { }
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
        Tieling,
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

    
}

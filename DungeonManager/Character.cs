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
        public int ProficiencyBonus;

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

        public Character()
        {
            _guid = Guid.NewGuid().ToString();
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
        Human,
        Elf,
        Dwarf,
        Halfling,
        Gnome,
        HalfElf,
        HalfOrc
    
    }
    [Serializable]
    public enum CharacterClass
    { 
        Barbarian,
        Bard,
        Rogue,
        Wizard,
        Fighter,
        Sorcerer,
        Druid,
        Cleric
    }
    [Serializable]
    public enum CharacterAlignment
    { 
        LawfullGood,
        ChaoticGood,
        NeutralGood,
        LawfullNeutral,
        ChaoticNeutral,
        TrueNeutral,
        LawfullEvil,
        ChaoticEvil,
        NeutralEvil
    }

    
}

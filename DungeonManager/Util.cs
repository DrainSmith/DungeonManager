using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonManager
{
    public static class Util
    {
        public static int GetModifier(int AbilityScore)
        {
            switch (AbilityScore)
            {
                case 1: return -5;
                case 2: return -4;
                case 3: return -4;
                case 4: return -3;
                case 5: return -3;
                case 6: return -2;
                case 7: return -2;
                case 8: return -1;
                case 9: return -1;
                case 10: return 0;
                case 11: return 0;
                case 12: return 1;
                case 13: return 1;
                case 14: return 2;
                case 15: return 2;
                case 16: return 3;
                case 17: return 3;
                case 18: return 4;
                case 19: return 4;
                case 20: return 5;
                case 21: return 5;
                case 22: return 6;
                case 23: return 6;
                case 24: return 7;
                case 25: return 8;
                default: throw new ArgumentOutOfRangeException("Must be 1 through 25");

            }
        }

        public static CharacterRace GetRaceFromString(string s)
        {
            switch (s)
            {
                case "Dwarf": return CharacterRace.Dwarf;
                case "Elf": return CharacterRace.Elf;
                case "Halfling": return CharacterRace.Halfling;
                case "Human": return CharacterRace.Human;
                case "Dragonborn": return CharacterRace.Dragonborn;
                case "Gnome": return CharacterRace.Gnome;
                case "HalfElf": return CharacterRace.HalfElf;
                case "HalfOrc": return CharacterRace.HalfOrc;
                case "Tieling": return CharacterRace.Tieling;
                default: throw new ArgumentOutOfRangeException("Unrecognized Race string");
            }
        }

        public static CharacterClass GetClassFromString(string s)
        {
            switch (s)
            {
                case "Barbarian": return CharacterClass.Barbarian;
                case "Bard": return CharacterClass.Bard;
                case "Cleric": return CharacterClass.Cleric;
                case "Druid": return CharacterClass.Druid;
                case "Fighter": return CharacterClass.Fighter;
                case "Monk": return CharacterClass.Monk;
                case "Paladin": return CharacterClass.Paladin;
                case "Ranger": return CharacterClass.Ranger;
                case "Rogue": return CharacterClass.Rogue;
                case "Sorcerer": return CharacterClass.Sorcerer;
                case "Warlock": return CharacterClass.Warlock;
                case "Wizard": return CharacterClass.Wizard;
                default: throw new ArgumentOutOfRangeException("Unrecognized Class string");
            }
        }

        public static int GetSpellDC(Character c)
        {
            int retVal = 0;
            foreach (Level l in c.Levels)
            {
                int t = 0;
                switch (l._class)
                {
                    //charisma
                    case CharacterClass.Bard:
                    case CharacterClass.Sorcerer:
                    case CharacterClass.Paladin:
                    case CharacterClass.Warlock:
                        {
                            t = 8 + c.ProficiencyBonus + GetModifier(c.Charisma);
                            break;
                        }
                    //int
                    case CharacterClass.Fighter:
                    case CharacterClass.Rogue:
                    case CharacterClass.Wizard:
                        {
                            retVal = 8 + c.ProficiencyBonus + GetModifier(c.Intelligence);
                            break;
                        }
                    //wis
                    case CharacterClass.Druid:
                    case CharacterClass.Ranger:
                    case CharacterClass.Cleric:
                        {
                            retVal = 8 + c.ProficiencyBonus + GetModifier(c.Wisdom);
                            break;
                        }
                    default: break;
                }
                if (t > retVal)
                    retVal = t;

            }
            return retVal;
        }

        public static int GetSpellAttackModifier(Character c)
        {
            return GetSpellDC(c) - 8;
        }
    }
}

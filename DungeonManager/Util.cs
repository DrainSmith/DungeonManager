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
            // As per DMG, 30 is the largest ability score a creature can have.
            if(AbilityScore < 1 || AbilityScore > 30)
                throw new ArgumentOutOfRangeException("Must be 1 through 25");
            return (int) Math.Floor(((double)(AbilityScore - 10)) / 2.0);
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
            // allow for more tolerance when checking class name
            s = s.Trim().ToLowerInvariant();
            switch (s)
            {
                case "barbarian": return CharacterClass.Barbarian;
                case "bard": return CharacterClass.Bard;
                case "cleric": return CharacterClass.Cleric;
                case "druid": return CharacterClass.Druid;
                case "fighter": return CharacterClass.Fighter;
                case "monk": return CharacterClass.Monk;
                case "paladin": return CharacterClass.Paladin;
                case "ranger": return CharacterClass.Ranger;
                case "rogue": return CharacterClass.Rogue;
                case "sorcerer": return CharacterClass.Sorcerer;
                case "warlock": return CharacterClass.Warlock;
                case "wizard": return CharacterClass.Wizard;
                default: throw new ArgumentOutOfRangeException("Unrecognized Class string");
            }
        }

        // Logically this function belongs to the character class, but has not been removed for compatibility reason
        // calls to this method should be removed and replaced with the version found in Character
        public static int GetSpellDC(Character c)
        {
            return c.SpellDC;
        }

        // See comment for GetSpellDC
        public static int GetSpellAttackModifier(Character c)
        {
            return c.SpellAttackModifier;
        }
    }
}

using UnityEngine;

public class SolutionTwoManager : MonoBehaviour
{

    public string characterName;
    public int level;
    public int constitutionScore;
    public string className;
    public string raceName;
    public bool hasTough;
    public bool hasStout;
    public bool useAveraged;

    //Where the actual simultaion occurs
    void Start()
    {
        CharacterClass characterClass = CreateClass(className);
        Race race = CreateRace(raceName);

        if (characterClass == null || race == null)
        {
            Debug.Log("Invalid class or race.");
            return;
        }

        Character character = new Character(characterName,level,constitutionScore,characterClass,race,hasTough,hasStout,useAveraged);

        Debug.Log( "My character " + character.Name + " is a level " + character.Level + " with a CON score of " + character.Con.Score + " and total HP = " + character.MaxHP);
    }

    //switch case for input 
    CharacterClass CreateClass(string name)
    {
        switch (name)
        {
            case "Barbarian": return new Barbarian();
            case "Fighter": return new Fighter();
            case "Paladin": return new Paladin();
            case "Ranger": return new Ranger();
            case "Bard": return new Bard();
            case "Cleric": return new Cleric();
            case "Druid": return new Druid();
            case "Monk": return new Monk();
            case "Rogue": return new Rogue();
            case "Warlock": return new Warlock();
            case "Sorcerer": return new Sorcerer();
            case "Wizard": return new Wizard();
            default: return null;
        }
    }

    //switch case for input 
    Race CreateRace(string name)
    {
        switch (name)
        {
            case "Dwarf": return new Dwarf();
            case "Orc": return new Orc();
            case "Goliath": return new Goliath();
            case "Human": return new Human();
            case "Elf": return new Elf();
            case "Halfling": return new Halfling();
            case "Tiefling": return new Tiefling();
            case "Dragonborn": return new Dragonborn();
            case "Gnome": return new Gnome();
            case "HalfElf": return new HalfElf();
            default: return null;
        }
    }
}
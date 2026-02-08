using System.Collections.Generic;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    /*
    PSEUDOCODE:

    Create dictionaries for class hit dice and race HP bonuses
    Read character info from inspector
    Calculate Constitution modifier
    totalHP = 0

    for each level from 1 to character level
        if level == 1
            Add max hit die
        else
            if averaged
                Add expected value of hit die
            else
                Roll hit die randomly

        Add Constitution modifier
        Add race HP bonus
        Add Tough/Stout feat bonuses

    - Output character description and total HP
    */

    [Header("Character Info")]
    public string characterName;
    public int level;
    public string characterClass;
    public int constitutionScore;
    public string race;

    [Header("Feats")]
    public bool hasTough;
    public bool hasStout;

    [Header("HP Calculation")]
    public bool useAveraged; 

    Dictionary<string, int> classHitDice;
    Dictionary<string, int> raceHpBonus;

    void Start()
    {
        classHitDice = new Dictionary<string, int>()
        {
            { "Barbarian", 12 },
            { "Fighter", 10 },
            { "Paladin", 10 },
            { "Ranger", 10 },
            { "Bard", 8 },
            { "Cleric", 8 },
            { "Druid", 8 },
            { "Monk", 8 },
            { "Rogue", 8 },
            { "Warlock", 8 },
            { "Sorcerer", 6 },
            { "Wizard", 6 }
        };
        raceHpBonus = new Dictionary<string, int>()
        {
            { "Dwarf", 2 },
            { "Orc", 1 },
            { "Goliath", 1 },
            { "Human", 0 },
            { "Elf", 0 },
            { "Halfling", 0 },
            { "Tiefling", 0 },
            { "Dragonborn", 0 },
            { "Gnome", 0 },
            { "Half-Elf", 0 }
        };
        CalculateHP();
    }


    void CalculateHP()
    {
        if (!classHitDice.ContainsKey(characterClass))
        {
            Debug.Log("Invalid class name!");
            return;
        }

        if (!raceHpBonus.ContainsKey(race))
        {
            Debug.Log("Invalid race name!");
            return;
        }

        int totalHP = 0;
        int hitDie = classHitDice[characterClass];
        int conModifier = (constitutionScore - 10) / 2;

        for (int i = 1; i <= level; i++)
        {

            if (i == 1)
            {
                totalHP += hitDie; 
            }
            else
            {
                if (useAveraged)
                {
                    totalHP += (hitDie / 2) + 1;
                }
                else
                {
                    totalHP += Random.Range(1, hitDie + 1);
                }
            }


            totalHP += conModifier;


            totalHP += raceHpBonus[race];


            if (hasTough)
                totalHP += 2;

            if (hasStout)
                totalHP += 1;
        }

        PrintResult(totalHP);
    }

    void PrintResult(int totalHP)
    {
        string featText = "has no feats";
        if (hasTough && hasStout)
        {
            featText = "has Tough and Stout feats";
        }

        else if (hasTough)
        {
            featText = "has Tough feat";
        }

        else if (hasStout)
        {
            featText = "has Stout feat";
        }

        string calcType = useAveraged ? "averaged" : "rolled";

        Debug.Log(
            "My character " + characterName +
            " is a level " + level + " " + characterClass +
            " with a CON score of " + constitutionScore +
            " and is of " + race + " race, " + featText +
            ". I want the HP " + calcType +
            ". Total HP = " + totalHP
        );
    }
}

using UnityEngine;

public class Character
{
    public string Name;
    public int Level;
    public Constitution Con;
    public CharacterClass Class;
    public Race Race;
    public bool Tough;
    public bool Stout;
    public int MaxHP;

    //Constructor 
    public Character(string name, int level, int conScore, CharacterClass characterClass, Race race, bool tough, bool stout, bool averaged)
    {
        Name = name;
        Level = Mathf.Clamp(level, 1, 20);
        Con = new Constitution(conScore);
        Class = characterClass;
        Race = race;
        Tough = tough;
        Stout = stout;

        CalculateHP(averaged);
    }


    // incorporate stats with health
    private void CalculateHP(bool averaged)
    {
        int total = 0;

        for (int i = 1; i <= Level; i++)
        {
            if (i == 1)
                total += Class.HitDie;
            else
                total += Class.Roll(averaged);

            total += Con.Modifier;
            total += Race.BonusPerLevel();

            if (Tough) total += 2;
            if (Stout) total += 1;
        }

        MaxHP = total;
    }
}

//constituition score data container
public struct Constitution
{
    private int score;

    public Constitution(int score)
    {
        this.score = Mathf.Clamp(score, 1, 30);
    }

    public int Modifier => (score - 10) / 2;
    public int Score => score;
}



public abstract class CharacterClass
{
    protected int hitDie;

    public int HitDie => hitDie;

    public virtual int Roll(bool averaged)
    {
        if (averaged)
            return (hitDie / 2) + 1;

        return Random.Range(1, hitDie + 1);
    }
}


// Classes

public class Barbarian : CharacterClass
{
    public Barbarian() { hitDie = 12; }
}

public class Fighter : CharacterClass
{
    public Fighter() { hitDie = 10; }
}

public class Paladin : CharacterClass
{
    public Paladin() { hitDie = 10; }
}

public class Ranger : CharacterClass
{
    public Ranger() { hitDie = 10; }
}

public class Bard : CharacterClass
{
    public Bard() { hitDie = 8; }
}

public class Cleric : CharacterClass
{
    public Cleric() { hitDie = 8; }
}

public class Druid : CharacterClass
{
    public Druid() { hitDie = 8; }
}

public class Monk : CharacterClass
{
    public Monk() { hitDie = 8; }
}

public class Rogue : CharacterClass
{
    public Rogue() { hitDie = 8; }
}

public class Warlock : CharacterClass
{
    public Warlock() { hitDie = 8; }
}

public class Sorcerer : CharacterClass
{
    public Sorcerer() { hitDie = 6; }
}

public class Wizard : CharacterClass
{
    public Wizard() { hitDie = 6; }
}



// Races

public abstract class Race
{
    public abstract int BonusPerLevel();
}

public class Dwarf : Race
{
    public override int BonusPerLevel()
    {
        return 2;
    }
}

public class Orc : Race
{
    public override int BonusPerLevel()
    {
        return 1;
    }
}

public class Goliath : Race
{
    public override int BonusPerLevel()
    {
        return 1;
    }
}

public class Human : Race
{
    public override int BonusPerLevel()
    {
        return 0;
    }
}

public class Elf : Race
{
    public override int BonusPerLevel()
    {
        return 0;
    }
}

public class Halfling : Race
{
    public override int BonusPerLevel()
    {
        return 0;
    }
}

public class Tiefling : Race
{
    public override int BonusPerLevel()
    {
        return 0;
    }
}

public class Dragonborn : Race
{
    public override int BonusPerLevel()
    {
        return 0;
    }
}

public class Gnome : Race
{
    public override int BonusPerLevel()
    {
        return 0;
    }
}

public class HalfElf : Race
{
    public override int BonusPerLevel()
    {
        return 0;
    }
}
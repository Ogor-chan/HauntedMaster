using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string Name;

    public int CurrentHP;
    public int MaxHP;
    public int Damage;
    public int Armour;
    public int Speed;
    public Element MyElement;

    public bool IsPlayer;
    public int WhichPosition;
    public List<StatusEffects> StatusEffectList = new List<StatusEffects>();
    public bool stunned;

    public List<Attack> myAttacks = new List<Attack>();

    public Character(string name,int maxHP, int damage, int armour, int speed, Element myElement, int whichPosition)
    {
        Name = name;
        CurrentHP = maxHP;
        MaxHP = maxHP;
        Damage = damage;
        Armour = armour;
        Speed = speed;
        MyElement = myElement;
        WhichPosition = whichPosition;
    }
}

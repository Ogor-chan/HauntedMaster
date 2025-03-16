using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string Name;

    [HideInInspector] public int CurrentHP;
    public int MaxHP;
    public int Damage;
    public int Armour;
    public int Speed;
    public Element MyElement;

    [HideInInspector] public bool IsPlayer;
    [HideInInspector] public int WhichPosition;
    [HideInInspector] public List<StatusEffects> StatusEffectList = new List<StatusEffects>();
    [HideInInspector] public bool stunned;

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

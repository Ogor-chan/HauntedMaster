using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string Name;
    public Sprite CharacterSprite;

    [HideInInspector] public int CurrentHP;
    public int MaxHP;
    public int Damage;
    public int Armour;
    public int Speed;
    public Element MyElement;

    [HideInInspector] public bool IsPlayer;
    public Position WhichPosition;
    [HideInInspector] public List<StatusEffects> StatusEffectList = new List<StatusEffects>();
    [HideInInspector] public bool stunned;

    public List<Attack> myAttacks = new List<Attack>();

    public Character(string name,int maxHP, int damage, int armour, int speed, Element myElement)
    {
        Name = name;
        CurrentHP = maxHP;
        MaxHP = maxHP;
        Damage = damage;
        Armour = armour;
        Speed = speed;
        MyElement = myElement;
    }

    public Character Clone()
    {
        Character copy = new Character(Name, MaxHP, Damage, Armour, Speed, MyElement);
        copy.CharacterSprite = CharacterSprite;
        copy.IsPlayer = IsPlayer;


        copy.stunned = false;
        copy.WhichPosition = null;

        return copy;
    }
}

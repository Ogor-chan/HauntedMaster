using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] BattleHandler battleHandler;
    [SerializeField] int healProcentage;

    private Character character;


    public void Rest()
    {
        character = battleHandler.playerCharacters[0];
        character.CurrentHP += (int)(character.MaxHP * (healProcentage * 0.01f));
        if (character.CurrentHP > character.MaxHP)
        {
            character.CurrentHP = character.MaxHP;
        }
        battleHandler.CheckHP();
    }

    public void Potion(int healA)
    {
        character = battleHandler.playerCharacters[0];
        character.CurrentHP += healA;
        if (character.CurrentHP > character.MaxHP)
        {
            character.CurrentHP = character.MaxHP;
        }

        battleHandler.CheckHP();
    }
}

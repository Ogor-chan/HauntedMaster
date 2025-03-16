using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
    public Character playerCharacter;
    public List<Character> monsterCharacters;

    public EnemyLibrary Library;

    public BattleHandler battleHandler;

    public int positions;
    // 0 - neutral player position
    // 1,2,3 - elemental player positions
    // 4, 5, 6, 7 - monster positions
    // 8 - boss position

    private void Start()
    {
        TestBattleStarter();
    }



    private void TestBattleStarter()
    {
        int currentEnemy = 0;
        playerCharacter = new Character("Player",50, 2, 0, 3, Element.neutral,0);
        playerCharacter.IsPlayer = true;

        ////////////////////////////////////////////////////////////////HOW TO CREATE ENEMIES
        monsterCharacters.Add(Library.enemies[0].myCharacter);
        monsterCharacters[currentEnemy].myAttacks = new List<Attack>();
        monsterCharacters[currentEnemy].StatusEffectList = new List<StatusEffects>();
        foreach (string name in Library.enemies[0].attackNames)
        {
            monsterCharacters[currentEnemy].myAttacks.Add(AttackLibrary.CreateAttack(name));
        }
        //////////////////////////////////////////////////////////////////////////////////////
        currentEnemy++;
        ////////////////////////////////////////////////////////////////HOW TO CREATE ENEMIES
        monsterCharacters.Add(Library.enemies[1].myCharacter);
        monsterCharacters[currentEnemy].myAttacks = new List<Attack>();
        monsterCharacters[currentEnemy].StatusEffectList = new List<StatusEffects>();
        foreach (string name in Library.enemies[1].attackNames)
        {
            monsterCharacters[currentEnemy].myAttacks.Add(AttackLibrary.CreateAttack(name));
        }
        //////////////////////////////////////////////////////////////////////////////////////

        playerCharacter.myAttacks.Add(new NeutralTestAttack());
        playerCharacter.myAttacks.Add(new AOEWaterAttackTest());
        playerCharacter.myAttacks.Add(new EarthTestAttack());

        battleHandler.playerCharacters.Add(playerCharacter);
        battleHandler.monsterCharacters = monsterCharacters;

        List<Character> turnOrder = new List<Character>();
        turnOrder.Add(playerCharacter);
        foreach (var item in monsterCharacters){turnOrder.Add(item);}
        turnOrder.Sort((item1, item2) => item2.Speed.CompareTo(item1.Speed));
        battleHandler.turnOrder = turnOrder;

    }


}

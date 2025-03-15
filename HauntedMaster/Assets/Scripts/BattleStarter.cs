using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
    public Character playerCharacter;
    public List<Character> monsterCharacters;


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
        playerCharacter = new Character("Player",50, 2, 0, 3, Element.neutral,0);
        playerCharacter.IsPlayer = true;

        monsterCharacters.Add(new Character("Earth Fox",80, 2, 0, 1, Element.earth, 4));
        monsterCharacters[0].myAttacks.Add(new ArmorUp());
        monsterCharacters[0].myAttacks.Add(new RockShot());
        monsterCharacters[0].myAttacks.Add(new PowerRockShot());

        monsterCharacters.Add(new Character("Fire Fox", 50, 3, 0, 2, Element.fire, 5));
        monsterCharacters[1].myAttacks.Add(new Scorch());
        monsterCharacters[1].myAttacks.Add(new Burst());
        monsterCharacters[1].myAttacks.Add(new Flamethrower());

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

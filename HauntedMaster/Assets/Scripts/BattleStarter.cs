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
        playerCharacter = new Character(50, 2, 0, 3, Element.neutral,0);
        playerCharacter.name = "playerr";
        playerCharacter.IsPlayer = true;

        monsterCharacters.Add(new Character(100, 1, 0, 2, Element.fire,4));

        monsterCharacters[0].name = "Fire slime";

        monsterCharacters[0].myAttacks.Add(new NeutralTestAttack());
        playerCharacter.myAttacks.Add(new NeutralTestAttack());
        playerCharacter.myAttacks.Add(new WaterTestAttack());
        playerCharacter.myAttacks.Add(new EarthTestAttack());

        battleHandler.playerCharacter = playerCharacter;
        battleHandler.monsterCharacters = monsterCharacters;

        List<Character> turnOrder = new List<Character>();
        turnOrder.Add(playerCharacter);
        foreach (var item in monsterCharacters){turnOrder.Add(item);}
        turnOrder.Sort((item1, item2) => item2.Speed.CompareTo(item1.Speed));
        battleHandler.turnOrder = turnOrder;

    }


}

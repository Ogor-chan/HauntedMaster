using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleStarter : MonoBehaviour
{
    public Character playerCharacter;
    public List<Character> monsterCharacters;
    public List<Position> PositionsList = new List<Position>();

    public EnemyLibrary Library;

    public BattleHandler battleHandler;

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
        CreatePlayer();

        CreateEnemy(0);
        CreateEnemy(1);
        CreateEnemy(2);
        CreateEnemy(3);


        battleHandler.playerCharacters.Add(playerCharacter);
        battleHandler.monsterCharacters = monsterCharacters;

        List<Character> turnOrder = new List<Character>();
        turnOrder.Add(playerCharacter);
        foreach (var item in monsterCharacters){turnOrder.Add(item);}
        turnOrder.Sort((item1, item2) => item2.Speed.CompareTo(item1.Speed));
        battleHandler.turnOrder = turnOrder;

    }

    private void CreateEnemy(int EnemyIndex)
    {
        monsterCharacters.Add(Library.enemies[EnemyIndex].myCharacter);
        int currentEnemy = monsterCharacters.Count - 1;
        monsterCharacters[currentEnemy].CurrentHP = monsterCharacters[currentEnemy].MaxHP;
        monsterCharacters[currentEnemy].myAttacks = new List<Attack>();
        monsterCharacters[currentEnemy].StatusEffectList = new List<StatusEffects>();
        foreach (string name in Library.enemies[EnemyIndex].attackNames)
        {
            monsterCharacters[currentEnemy].myAttacks.Add(AttackLibrary.CreateAttack(name));
        }

        OccupyPosition(monsterCharacters[currentEnemy]);
    }

    private void CreatePlayer()
    {
        playerCharacter = new Character("Player", 50, 2, 0, 3, Element.neutral);
        playerCharacter.IsPlayer = true;

        playerCharacter.myAttacks.Add(new NeutralTestAttack());
        playerCharacter.myAttacks.Add(new AOEWaterAttackTest());
        playerCharacter.myAttacks.Add(new EarthTestAttack());

        playerCharacter.WhichPosition = PositionsList[0];
    }


    private void OccupyPosition(Character TargetCharacter)
    {
        if (!PositionsList[4].Active)
        {
            PositionsList[4].Active = true;
            PositionsList[4].ImageRenderer.sprite = TargetCharacter.CharacterSprite;
            PositionsList[4].NameText.text = TargetCharacter.Name;
            PositionsList[4].HPText.text = TargetCharacter.MaxHP + "/" + TargetCharacter.MaxHP;
            TargetCharacter.WhichPosition = PositionsList[4];

            PositionsList[4].PositionObject.SetActive(true);
        }
        else if (!PositionsList[5].Active)
        {
            PositionsList[5].Active = true;
            PositionsList[5].ImageRenderer.sprite = TargetCharacter.CharacterSprite;
            PositionsList[5].NameText.text = TargetCharacter.Name;
            PositionsList[5].HPText.text = TargetCharacter.MaxHP + "/" + TargetCharacter.MaxHP;
            TargetCharacter.WhichPosition = PositionsList[5];

            PositionsList[5].PositionObject.SetActive(true);
        }
        else if (!PositionsList[6].Active)
        {
            PositionsList[6].Active = true;
            PositionsList[6].ImageRenderer.sprite = TargetCharacter.CharacterSprite;
            PositionsList[6].NameText.text = TargetCharacter.Name;
            PositionsList[6].HPText.text = TargetCharacter.MaxHP + "/" + TargetCharacter.MaxHP;
            TargetCharacter.WhichPosition = PositionsList[6];

            PositionsList[6].PositionObject.SetActive(true);
        }
        else if (!PositionsList[7].Active)
        {
            PositionsList[7].Active = true;
            PositionsList[7].ImageRenderer.sprite = TargetCharacter.CharacterSprite;
            PositionsList[7].NameText.text = TargetCharacter.Name;
            PositionsList[7].HPText.text = TargetCharacter.MaxHP + "/" + TargetCharacter.MaxHP;
            TargetCharacter.WhichPosition = PositionsList[7];

            PositionsList[7].PositionObject.SetActive(true);
        }
    }



}

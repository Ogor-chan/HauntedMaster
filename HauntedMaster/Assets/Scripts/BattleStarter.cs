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
        GameInitiater();
    }

    private void GameInitiater()
    {
        CreatePlayer();


        battleHandler.playerCharacters.Add(playerCharacter);
        battleHandler.monsterCharacters = monsterCharacters;

        List<Character> turnOrder = new List<Character>();
        turnOrder.Add(playerCharacter);
        foreach (var item in monsterCharacters){turnOrder.Add(item);}
        turnOrder.Sort((item1, item2) => item2.Speed.CompareTo(item1.Speed));
        battleHandler.turnOrder = turnOrder;

    }

    public void StartFight(List<Enemy> Enemies)
    {
        monsterCharacters.Clear();
        foreach (Enemy item in Enemies)
        {
            CreateEnemy(item);
        }



        battleHandler.monsterCharacters = monsterCharacters;

        List<Character> turnOrder = new List<Character>();
        turnOrder.Add(playerCharacter);
        foreach (var item in monsterCharacters) { turnOrder.Add(item); }
        turnOrder.Sort((item1, item2) => item2.Speed.CompareTo(item1.Speed));
        battleHandler.turnOrder = turnOrder;
        battleHandler.BattleStarted();
    }

    private void CreateEnemy(Enemy spawningEnemy)
    {
        Character newEnemy = spawningEnemy.myCharacter.Clone();
        monsterCharacters.Add(newEnemy);
        newEnemy.CurrentHP = newEnemy.MaxHP;
        newEnemy.myAttacks = new List<Attack>();
        newEnemy.StatusEffectList = new List<StatusEffects>();
        foreach (string name in spawningEnemy.attackNames)
        {
            newEnemy.myAttacks.Add(AttackLibrary.CreateAttack(name));
        }

        OccupyPosition(newEnemy);
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

        print(TargetCharacter.Name + " Had occupied " + TargetCharacter.WhichPosition.index + "position");
    }



}

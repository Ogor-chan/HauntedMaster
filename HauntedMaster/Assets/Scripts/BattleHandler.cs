using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public enum BattleState
{
    StartOfBattle,
    StartOfPlayerTurn,
    PlayerTurn,
    EndOfPlayerTurn,
    StartOfMonsterTurn,
    MonsterTurn,
    EndOfMonsterTurn,
    EndOfBattle
}

public class BattleHandler : MonoBehaviour
{
    public Character playerCharacter;
    public List<Character> monsterCharacters;
    public List<Character> turnOrder;
    public List<TMP_Text> monsterHPText;
    public TMP_Text playerHPText;
    public TMP_Text EnergyText;

    public BattleState currentBattleState;
    public Character activeCharacter;


    private int MaxEnergy = 3;
    private int CurrentEnergy;

    private bool isTurnOver;
    private bool Choosen = true;
    private Character[] TempCharArray = new Character[1];

    private void Awake()
    {
        Utilities.CheckDamage += CheckHP;
    }

    private void Start()
    {
        BattleStarted();
    }

    public IEnumerator CheckBattleState()
    {
        switch (currentBattleState)
        {
            case BattleState.StartOfBattle:

                //ACTIVATE START OF BATTLE EFFECTS
                print("START OF BATTLE");

                if (activeCharacter.IsPlayer) { currentBattleState = BattleState.StartOfPlayerTurn;
                    print("STARTING CHAR IS PLAYER");
                }
                else { currentBattleState = BattleState.StartOfMonsterTurn; }
                StartCoroutine(CheckBattleState());
                break;
            case BattleState.StartOfPlayerTurn:

                //ACTIVATE START OF TURN EFFECTS FOR PLAYER
                print("START OF PLAYER TURN");
                CheckHP();
                ActivateStatus(StatusE.stun);
                if (activeCharacter.stunned)
                {
                    activeCharacter.stunned = false;
                    currentBattleState = BattleState.EndOfPlayerTurn;
                }
                else
                {
                    currentBattleState = BattleState.PlayerTurn;

                }

                StartCoroutine(CheckBattleState());
                break;
            case BattleState.PlayerTurn:

                //PLAYER TURN
                print("PLAYER TURN");

                yield return new WaitUntil(() => isTurnOver);
                isTurnOver = false;
                currentBattleState = BattleState.EndOfPlayerTurn;
                StartCoroutine(CheckBattleState());
                break;
            case BattleState.EndOfPlayerTurn:

                //ACTIVATE END OF TURN EFFECTS FOR PLAYER
                print("END OF PLAYER TURN");

                ActivateStatus(StatusE.burn);

                CurrentEnergy = MaxEnergy;
                NextCharacter();
                if (activeCharacter.IsPlayer) { currentBattleState = BattleState.StartOfPlayerTurn; }
                else { currentBattleState = BattleState.StartOfMonsterTurn; }
                if (turnOrder.Count == 1) { currentBattleState = BattleState.EndOfBattle; }
                StartCoroutine(CheckBattleState());
                break;
            case BattleState.StartOfMonsterTurn:

                //ACTIVATE START OF TURN EFFECTS FOR ACTIVE MONSTER
                print("START OF MONSTER TURN");

                ActivateStatus(StatusE.stun);
                if (activeCharacter.stunned)
                {
                    activeCharacter.stunned = false;
                    currentBattleState = BattleState.EndOfMonsterTurn;
                }
                else
                {
                    currentBattleState = BattleState.MonsterTurn;

                }
                StartCoroutine(CheckBattleState());
                break;
            case BattleState.MonsterTurn:

                //MONSTER TURN
                print("MONSTER TURN");

                MonsterAttack();
                yield return new WaitUntil(() => isTurnOver);
                isTurnOver = false;
                currentBattleState = BattleState.EndOfMonsterTurn;
                StartCoroutine(CheckBattleState());
                break;
            case BattleState.EndOfMonsterTurn:

                //ACTIVATE END OF TURN EFFECTS FOR ACTIVE MONSTER
                print("END OF MONSTER TURN");

                ActivateStatus(StatusE.burn);

                NextCharacter();
                if (activeCharacter.IsPlayer) { currentBattleState = BattleState.StartOfPlayerTurn; }
                else { currentBattleState = BattleState.StartOfMonsterTurn; }
                if (turnOrder.Count == 1) { currentBattleState = BattleState.EndOfBattle; }
                StartCoroutine(CheckBattleState());
                break;
            case BattleState.EndOfBattle:
                //ACTIVATE END OF BATTLE EFFECTS
                print("END OF BATTLE");
                break;
        }
    }

    public void BattleStarted()
    {
        activeCharacter = turnOrder[0];
        currentBattleState = BattleState.StartOfBattle;
        isTurnOver = false;
        CurrentEnergy = MaxEnergy;
        CheckHP();

        StartCoroutine(CheckBattleState());
    }

    public void NextCharacter()
    {
        turnOrder.Remove(activeCharacter);
        turnOrder.Add(activeCharacter);
        activeCharacter = turnOrder[0];
    }

    private void CheckHP()
    {
        playerHPText.text = playerCharacter.CurrentHP + "/" + playerCharacter.MaxHP;
        for (int i = 0; i < monsterCharacters.Count; i++)
        {
            monsterHPText[i].text = monsterCharacters[i].CurrentHP + "/" + monsterCharacters[i].MaxHP;
        }
        EnergyText.text = CurrentEnergy + "/" + MaxEnergy;
    }

    public void TestAttack1()
    {
        Attack usedAttack = playerCharacter.myAttacks[0];
        if (CurrentEnergy < usedAttack.EnergyCost)
        {
            return;
        }

        CurrentEnergy -= usedAttack.EnergyCost;
        print("Player is using NeutralTestAttack");
        Character[] targetMonster = new Character[1];

        StartCoroutine(TargetChoice(targetMonster, usedAttack));
    }

    public void TestAttack2()
    {
        Attack usedAttack = playerCharacter.myAttacks[1];

        if (CurrentEnergy < usedAttack.EnergyCost)
        {
            return;
        }

        CurrentEnergy -= usedAttack.EnergyCost;
        print("Player is using AOEWaterTestAttack");
        Character[] targetMonster = monsterCharacters.ToArray();

        StartCoroutine(TargetChoice(targetMonster, usedAttack));
    }
    public void TestAttack3()
    {
        Attack usedAttack = playerCharacter.myAttacks[2];
        if (CurrentEnergy < usedAttack.EnergyCost)
        {
            return;
        }

        CurrentEnergy -= usedAttack.EnergyCost;
        print("Player is using EarthTestAttack");
        Character[] targetMonster = new Character[1];

        StartCoroutine(TargetChoice(targetMonster, usedAttack));
    }

    public void MonsterAttack()
    {
        print("Fire slime is using NeutralTestAttack");
        Character[] target = new Character[1];
        target[0] = playerCharacter;
        monsterCharacters[0].myAttacks[0].ExecuteAttack(target,
            monsterCharacters[0], monsterCharacters[0].myAttacks[0]);

        print("Earth slime is using EarthTestAttack");
        monsterCharacters[1].myAttacks[0].ExecuteAttack(target,
            monsterCharacters[1], monsterCharacters[1].myAttacks[0]);

        isTurnOver = true;
    }


    public IEnumerator TargetChoice(Character[] targets, Attack usedAttack)
    {
        Choosen = false;

        if(targets[0] != null)
        {
            Choosen = true;
        }

        yield return new WaitUntil(() => Choosen);

        targets[0] = TempCharArray[0];
        usedAttack.ExecuteAttack(targets, playerCharacter, usedAttack);

    }


    public void TargetChoiceClick(int position)
    {
        TempCharArray[0] = null;
        if (!Choosen)
        {
            foreach (var item in monsterCharacters)
            {
                if (item.WhichPosition == position)
                {
                    TempCharArray[0] = item;
                    Choosen = true;
                }
            }
        }
    }

    public void EndTurnButton()
    {
        isTurnOver = true;
    }

    public void ActivateStatus(StatusE effect)
    {
        switch (effect)
        {
            case StatusE.burn:
                if (activeCharacter.StatusEffectList.Any(e => e.status == effect))
                {
                    var thisStatusEffect = activeCharacter.StatusEffectList.FirstOrDefault(e => e.status == effect);
                    activeCharacter.CurrentHP =- 2;
                    CheckHP();
                    thisStatusEffect.stack--;
                    print("Burn");

                    if (thisStatusEffect.stack <= 0)
                    {
                        activeCharacter.StatusEffectList.Remove(thisStatusEffect);
                    }
                }
                break;
            case StatusE.stun:
                if (activeCharacter.StatusEffectList.Any(e => e.status == effect))
                {
                    var thisStatusEffect = activeCharacter.StatusEffectList.FirstOrDefault(e => e.status == effect);
                    activeCharacter.stunned = true;
                    thisStatusEffect.stack--;
                    print("Stun");

                    if (thisStatusEffect.stack <= 0)
                    {
                        activeCharacter.StatusEffectList.Remove(thisStatusEffect);
                    }
                }
                break;
        }
    }
}

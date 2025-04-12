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
    public List<Character> playerCharacters = new List<Character>();
    public List<Character> monsterCharacters;
    public List<Character> turnOrder;
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

                NextCharTurn();
                StartCoroutine(CheckBattleState());
                break;
            case BattleState.StartOfPlayerTurn:

                //ACTIVATE START OF TURN EFFECTS FOR PLAYER
                print("START OF PLAYER TURN");
                CheckHP();
                ActivateStatus(StatusE.stun);

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
                ActivateStatus(StatusE.mud);

                CurrentEnergy = MaxEnergy;
                NextCharacter();
                NextCharTurn();

                StartCoroutine(CheckBattleState());
                break;
            case BattleState.StartOfMonsterTurn:

                //ACTIVATE START OF TURN EFFECTS FOR ACTIVE MONSTER
                print("START OF MONSTER TURN");

                ActivateStatus(StatusE.stun);

                StartCoroutine(CheckBattleState());
                break;
            case BattleState.MonsterTurn:

                //MONSTER TURN
                print("MONSTER TURN");

                MonsterAttack();
                isTurnOver = true;
                yield return new WaitUntil(() => isTurnOver);
                isTurnOver = false;
                currentBattleState = BattleState.EndOfMonsterTurn;
                StartCoroutine(CheckBattleState());
                break;
            case BattleState.EndOfMonsterTurn:

                //ACTIVATE END OF TURN EFFECTS FOR ACTIVE MONSTER
                print("END OF MONSTER TURN");

                ActivateStatus(StatusE.burn);
                ActivateStatus(StatusE.mud);

                NextCharacter();
                NextCharTurn();

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
        for (int i = 0; i < playerCharacters.Count; i++)
        {
            if(playerCharacters[i].CurrentHP <= 0)
            {
                print("Player had Died!");
                ///////LOSE STATE MECHANIC TBA
            }
            else
            {
                playerCharacters[i].WhichPosition.HPText.text
    = playerCharacters[i].CurrentHP + "/" + playerCharacters[i].MaxHP;
            }
        }
        for (int i = 0; i < monsterCharacters.Count; i++)
        {
            if(monsterCharacters[i].CurrentHP <= 0)
            {
                MonsterDeath(monsterCharacters[i]);
            }
            else
            {
                monsterCharacters[i].WhichPosition.HPText.text 
                    = monsterCharacters[i].CurrentHP + "/" + monsterCharacters[i].MaxHP;
            }
        }
        EnergyText.text = CurrentEnergy + "/" + MaxEnergy;
    }
    

    private void MonsterDeath(Character DeadMonster)
    {
        print(DeadMonster.Name + " Had Died!");
        monsterCharacters.Remove(DeadMonster);
        DeadMonster.WhichPosition.Active = false;
        DeadMonster.WhichPosition.PositionObject.SetActive(false);
    }
    private void NextCharTurn()
    {
        if (activeCharacter.IsPlayer) { currentBattleState = BattleState.StartOfPlayerTurn; }
        else { currentBattleState = BattleState.StartOfMonsterTurn; }
    }
    public void TestAttack1()
    {
        Attack usedAttack = playerCharacters[0].myAttacks[0];
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
        Attack usedAttack = playerCharacters[0].myAttacks[1];

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
        Attack usedAttack = playerCharacters[0].myAttacks[2];
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
        RollMonsterAttack(activeCharacter);
    }

    public void RollMonsterAttack(Character targetMonster)
    {
        List<int> Thresholds = new List<int>();

        foreach (Attack item in targetMonster.myAttacks)
        {
            Thresholds.Add(item.ChanceToUse);
        }

        int Max = Thresholds.Sum();

        int RandomNumber = Random.Range(0, Max + 1);

        int runningTotal = 0;
        print(RandomNumber);

        foreach (Attack item in targetMonster.myAttacks)
        {
            runningTotal += item.ChanceToUse;
            if (RandomNumber < runningTotal)
            {
                print(targetMonster.Name + " Uses " + item.Name);

                if(item.AttackTarget == Target.Enemy)
                {
                    item.ExecuteAttack(playerCharacters.ToArray(), targetMonster, item);
                }
                else if (item.AttackTarget == Target.Team)
                {
                    item.ExecuteAttack(monsterCharacters.ToArray(), targetMonster, item);
                }
                break;
            }
        }

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
        usedAttack.ExecuteAttack(targets, playerCharacters[0], usedAttack);

    }


    public void TargetChoiceClick(int position)
    {
        TempCharArray[0] = null;
        if (!Choosen)
        {
            foreach (var item in monsterCharacters)
            {
                if (item.WhichPosition.index == position)
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
                    Utilities.DealDamageWithEffect(activeCharacter, thisStatusEffect);
                    thisStatusEffect.stack--;

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

                    if (thisStatusEffect.stack <= 0)
                    {
                        activeCharacter.StatusEffectList.Remove(thisStatusEffect);
                    }
                }

                    if (activeCharacter.IsPlayer)
                    {
                        if (activeCharacter.stunned)
                        {
                            activeCharacter.stunned = false;
                            currentBattleState = BattleState.EndOfPlayerTurn;
                        }
                        else
                        {
                            currentBattleState = BattleState.PlayerTurn;

                        }
                    }
                    else
                    {
                        if (activeCharacter.stunned)
                        {
                            activeCharacter.stunned = false;
                            currentBattleState = BattleState.EndOfMonsterTurn;
                        }
                        else
                        {
                            currentBattleState = BattleState.MonsterTurn;

                        }
                    }
                break;
            case StatusE.mud:
                if (activeCharacter.StatusEffectList.Any(e => e.status == effect))
                {
                    var thisStatusEffect = activeCharacter.StatusEffectList.FirstOrDefault(e => e.status == effect);
                    Utilities.DealDamageWithEffect(activeCharacter, thisStatusEffect);
                }
                break;
            case StatusE.strength:
            case StatusE.weakness:
            case StatusE.armored:
            case StatusE.rip:
                if (activeCharacter.StatusEffectList.Any(e => e.status == effect))
                {
                    var thisStatusEffect = activeCharacter.StatusEffectList.FirstOrDefault(e => e.status == effect);
                    thisStatusEffect.stack--;

                    if (thisStatusEffect.stack <= 0)
                    {
                        activeCharacter.StatusEffectList.Remove(thisStatusEffect);
                    }
                }
                break;
            case StatusE.poison:
                if (activeCharacter.StatusEffectList.Any(e => e.status == effect))
                {

                    var thisStatusEffect = activeCharacter.StatusEffectList.FirstOrDefault(e => e.status == effect);
                    Utilities.DealDamageWithEffect(activeCharacter, thisStatusEffect);
                    thisStatusEffect.stack--;
                    if (thisStatusEffect.stack <= 0)
                    {
                        activeCharacter.StatusEffectList.Remove(thisStatusEffect);
                    }
                }
                break;
            case StatusE.bleed:
                if (activeCharacter.StatusEffectList.Any(e => e.status == effect))
                {
                    var thisStatusEffect = activeCharacter.StatusEffectList.FirstOrDefault(e => e.status == effect);
                    Utilities.DealDamageWithEffect(activeCharacter, thisStatusEffect);
                    thisStatusEffect.stack--;
                    if (thisStatusEffect.stack <= 0)
                    {
                        activeCharacter.StatusEffectList.Remove(thisStatusEffect);
                    }
                }
                break;
        }
    }
}

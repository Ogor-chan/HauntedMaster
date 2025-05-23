using System.Collections.Generic;
using UnityEngine;
public class BoarSwiftyLegs : Attack
{
    public BoarSwiftyLegs()
    {
        Name = "BoarSwiftyLegs";
        Damage = 0;
        AttackElement = Element.neutral;
        ChanceToUse = 20;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {

        Character target = targets[Random.Range(0, targets.Length)];
        Utilities.ApplyHeal(target,Damage);
        
    }

}
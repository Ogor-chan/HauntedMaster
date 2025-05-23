using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FoxWaterHeal : Attack
{
    public FoxWaterHeal()
    {
        Name = "FoxWaterHeal";
        AttackElement = Element.water;
        Damage = 2;
        ChanceToUse = 30;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        Utilities.ApplyHeal(target, 2);
    }

}

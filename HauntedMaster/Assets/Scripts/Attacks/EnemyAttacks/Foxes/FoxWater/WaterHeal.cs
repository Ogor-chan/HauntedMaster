using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaterHeal : Attack
{
    public WaterHeal()
    {
        Name = "WaterHeal";
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

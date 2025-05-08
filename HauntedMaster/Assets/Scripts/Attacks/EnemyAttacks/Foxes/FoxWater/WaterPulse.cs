using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaterPulse : Attack
{
    public WaterPulse()
    {
        Name = "WaterPulse";
        AttackElement = Element.water;
        Damage = 2;
        ChanceToUse = 40;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int DamageDealt = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, DamageDealt);
    }

}

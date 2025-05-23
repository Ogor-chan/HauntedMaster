using System.Collections.Generic;
using UnityEngine;
public class BoarAirAttack : Attack
{
    public BoarAirAttack()
    {
        Name = "BoarAirAttack";
        Damage = 1;
        AttackElement = Element.wind;
        ChanceToUse = 35;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);

    }
}


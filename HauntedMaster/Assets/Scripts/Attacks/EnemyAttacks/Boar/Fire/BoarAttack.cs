using System.Collections.Generic;
using UnityEngine;
public class BoarAttack : Attack
{
    public BoarAttack()
    {
        Name = "BoarAttack";
        Damage = 3;
        AttackElement = Element.fire;
        ChanceToUse = 15;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireSting : Attack
{
    public FireSting()
    {
        Name = "FireSting";
        Damage = 1;
        AttackElement = Element.fire;
        ChanceToUse = 50;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);
        Utilities.ApplyEffect(target, StatusE.bleed, 2);

    }
}

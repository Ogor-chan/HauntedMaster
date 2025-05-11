using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DarkTail : Attack
{
    public DarkTail()
    {
        Name = "DarkTail";
        Damage = 3;
        AttackElement = Element.neutral;
        ChanceToUse = 35;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (Character target in targets)
        {
            int damage = Utilities.CalculateDamage(caster, target, usedAttack);
            Utilities.DealDamage(target, damage);
            Utilities.ApplyEffect(target, StatusE.bleed, 3);
        }

    }
}


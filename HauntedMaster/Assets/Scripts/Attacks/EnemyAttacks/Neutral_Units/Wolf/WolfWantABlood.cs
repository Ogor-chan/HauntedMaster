using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WolfWantABlood : Attack
{
    public WolfWantABlood()
    {
        Name = "WolfWantABlood";
        Damage = 1;
        AttackElement = Element.neutral;
        ChanceToUse = 15;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);
        Utilities.ApplyHeal(caster, Damage);

    }
}
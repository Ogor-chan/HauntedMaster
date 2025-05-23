using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WolfBiteBite : Attack
{
    public WolfBiteBite()
    {
        Name = "WolfBiteBite";
        Damage = 2;
        AttackElement = Element.neutral;
        ChanceToUse = 35;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);
        Utilities.ApplyEffect(target, StatusE.bleed, 3);

    }
}

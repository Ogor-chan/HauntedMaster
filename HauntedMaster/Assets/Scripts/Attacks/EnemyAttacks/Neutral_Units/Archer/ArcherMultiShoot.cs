using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArcherMultiShoot : Attack
{
    public ArcherMultiShoot()
    {
        Name = "ArcherMultiShoot";
        Damage = 2;
        AttackElement = Element.neutral;
        ChanceToUse = 20;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (Character target in targets)
        {
            int damage = Utilities.CalculateDamage(caster, target, usedAttack);
            Utilities.DealDamage(target, damage);
        }
    }

}
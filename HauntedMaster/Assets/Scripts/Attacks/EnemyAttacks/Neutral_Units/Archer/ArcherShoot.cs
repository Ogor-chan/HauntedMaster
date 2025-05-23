using System.Collections.Generic;
using UnityEngine;
public class ArcherShoot : Attack
{
    public ArcherShoot()
    {
        Name = "ArcherShoot";
        Damage = 2;
        AttackElement = Element.neutral;
        ChanceToUse = 50;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);

    }
}

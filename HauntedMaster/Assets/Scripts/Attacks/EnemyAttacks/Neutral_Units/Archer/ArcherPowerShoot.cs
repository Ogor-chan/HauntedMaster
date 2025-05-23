using System.Collections.Generic;
using UnityEngine;
public class ArcherPowerShoot : Attack
{
    public ArcherPowerShoot()
    {
        Name = "ArcherPowerShoot";
        Damage = 1;
        AttackElement = Element.neutral;
        ChanceToUse = 30;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);
        Utilities.ApplyEffect(target, StatusE.stun, 1);

    }
}

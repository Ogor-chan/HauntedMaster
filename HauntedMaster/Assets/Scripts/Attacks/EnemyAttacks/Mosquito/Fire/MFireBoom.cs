using System.Collections.Generic;
using UnityEngine;
public class MFireBoom : Attack
{
    public MFireBoom()
    {
        Name = "MFireBoom";
        Damage = 3;
        AttackElement = Element.fire;
        ChanceToUse = 20;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (Character target in targets)
        {
            int damage = Utilities.CalculateDamage(caster, target, usedAttack);
            Utilities.DealDamage(target, damage);
            Utilities.ApplyEffect(target, StatusE.burn, 2);
        }
    }

}

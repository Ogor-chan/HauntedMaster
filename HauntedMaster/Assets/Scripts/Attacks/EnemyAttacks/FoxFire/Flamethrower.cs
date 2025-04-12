using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flamethrower : Attack
{
    public Flamethrower()
    {
        Name = "Flamethrower";
        Damage = 1;
        AttackElement = Element.fire;
        ChanceToUse = 30;
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

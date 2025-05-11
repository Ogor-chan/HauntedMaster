using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Vulkan : Attack
{
    public Vulkan()
    {
        Name = "Vulkan";
        Damage = 1;
        AttackElement = Element.fire;
        ChanceToUse = 70;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (Character target in targets)
        {
            int damage = Utilities.CalculateDamage(caster, target, usedAttack);
            Utilities.DealDamage(target, damage);
            Utilities.ApplyEffect(target, StatusE.burn, 1);
        }
    }

}
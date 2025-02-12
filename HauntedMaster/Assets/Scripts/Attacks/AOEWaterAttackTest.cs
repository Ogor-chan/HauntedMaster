using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEWaterAttackTest : Attack
{
    public AOEWaterAttackTest()
    {
        Name = "AoeWaterAttackTest";
        EnergyCost = 2;
        Damage = 2;
        AttackElement = Element.water;
        Cooldown = 0;
        CurrentCooldown = 0;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (var item in targets)
        {
            int damage = Utilities.CalculateDamage(caster, item, usedAttack);
            Utilities.DealDamage(item, damage);
        }

    }
}

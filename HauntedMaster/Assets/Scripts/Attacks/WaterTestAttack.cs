using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTestAttack : Attack
{
    public WaterTestAttack()
    {
        Name = "WaterTestAttack";
        EnergyCost = 1;
        Damage = 3;
        AttackElement = Element.water;
        Cooldown = 1;
        CurrentCooldown = 0;
    }

    public override void ExecuteAttack(Character target, int damage)
    {
        Utilities.DealDamage(target, damage);
    }

}

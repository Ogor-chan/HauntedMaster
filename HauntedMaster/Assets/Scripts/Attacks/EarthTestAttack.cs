using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTestAttack : Attack
{
    public EarthTestAttack()
    {
        Name = "EarthTestAttack";
        EnergyCost = 1;
        Damage = 2;
        AttackElement = Element.earth;
        Cooldown = 0;
        CurrentCooldown = 0;
    }

    public override void ExecuteAttack(Character target, int damage)
    {
        Utilities.DealDamage(target, damage);
    }
}

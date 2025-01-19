using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralTestAttack : Attack
{
    public NeutralTestAttack()
    {
        Name = "NeutralTestAttack";
        EnergyCost = 1;
        Damage = 2;
        AttackElement = Element.neutral;
        Cooldown = 0;
        CurrentCooldown = 0;
    }

    public override void ExecuteAttack(Character target, int damage)
    {
        Utilities.DealDamage(target, damage);
    }

}

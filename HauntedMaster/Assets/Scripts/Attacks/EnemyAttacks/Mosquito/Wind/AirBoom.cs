using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AirBoom : Attack
{
    public AirBoom()
    {
        Name = "AirBoom";
        Damage = 3;
        AttackElement = Element.wind;
        ChanceToUse = 20;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (Character item in targets)
        {
            item.Speed += Damage;
        }
        Utilities.DealDamage(caster, 999);
    }

}

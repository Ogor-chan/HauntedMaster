using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaterBoom : Attack
{
    public WaterBoom()
    {
        Name = "WaterBoom";
        Damage = 0;
        AttackElement = Element.water;
        ChanceToUse = 20;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (Character item in targets)
        {
            Utilities.ApplyHeal(item,15);
            Utilities.RemoveNegativeEffects(item);
        }
        Utilities.DealDamage(caster, 9999);
    }

}

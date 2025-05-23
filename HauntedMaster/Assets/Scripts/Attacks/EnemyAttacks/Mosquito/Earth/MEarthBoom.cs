using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MEarthBoom : Attack
{
    public MEarthBoom()
    {
        Name = "MEarthBoom";
        Damage = 2;
        AttackElement = Element.earth;
        ChanceToUse = 20;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {

        foreach (Character target in targets)
        { 
            Utilities.DealDamage(caster, 999);

            // Ma dodawa� pancerz a nie leczy� 
            Utilities.ApplyHeal(target, 20);
        }

    }
}

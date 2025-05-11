using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EarhBoom : Attack
{
    public EarhBoom()
    {
        Name = "EarhBoom";
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

            // Ma dodawaæ pancerz a nie leczyæ 
            Utilities.ApplyHeal(target, 20);
        }

    }
}

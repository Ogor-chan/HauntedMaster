using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WolfShadow : Attack
{
    public WolfShadow()
    {
        Name = "WolfShadow";
        Damage = 0;
        AttackElement = Element.neutral;
        ChanceToUse = 20;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        // Tu ma przejœæ w status shadow
        Utilities.ApplyEffect(caster, StatusE.bleed, 3);

    }
}

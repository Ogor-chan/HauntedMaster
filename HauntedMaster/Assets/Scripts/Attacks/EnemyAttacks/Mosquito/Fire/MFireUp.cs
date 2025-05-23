using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MFireUp : Attack
{
    public MFireUp()
    {
        Name = "MFireUp";
        Damage = 0;
        AttackElement = Element.fire;
        ChanceToUse = 30;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Utilities.ApplyEffect(caster, StatusE.strength, 1);

    }
}

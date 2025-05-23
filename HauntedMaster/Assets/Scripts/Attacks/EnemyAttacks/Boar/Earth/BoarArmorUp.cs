using System.Collections.Generic;
using UnityEngine;
public class BoarArmorUp : Attack
{
    public BoarArmorUp()
    {
        Name = "BoarArmorUp";
        Damage = 2;
        AttackElement = Element.fire;
        ChanceToUse = 30;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
       //Ma byæ pancerz
        Utilities.ApplyHeal(caster,Damage);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ImSpeed : Attack
{
    public ImSpeed()
    {
        Name = "ImSpeeed";
        Damage = 0;
        AttackElement = Element.wind;
        ChanceToUse = 30;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Utilities.ApplyEffect(caster, StatusE.strength, 1);
    }

}

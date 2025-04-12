using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Burst : Attack
{
    public Burst()
    {
        Name = "Burst";
        AttackElement = Element.fire;
        ChanceToUse = 20;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Utilities.ApplyEffect(caster, StatusE.strength, 2);
        Debug.Log(caster.Name + "Gains 2 Strenght");
    }

}

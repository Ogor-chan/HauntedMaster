using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FoxWeaked : Attack
{
    public FoxWeaked()
    {
        Name = "FoxWeaked";
        AttackElement = Element.wind;
        Damage = 0;
        ChanceToUse = 20;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        Utilities.ApplyEffect(target, StatusE.weakness, 1);
    }

}

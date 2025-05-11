using System.Collections.Generic;
using UnityEngine;
public class Insane : Attack
{
    public Insane()
    {
        Name = "Insane";
        Damage = 0;
        AttackElement = Element.neutral;
        ChanceToUse = 20;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        //Insane stack
        Character target = targets[Random.Range(0, targets.Length)];
        Utilities.ApplyEffect(target,StatusE.rip,1);

    }
}
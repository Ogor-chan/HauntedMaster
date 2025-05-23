using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FoxWindInsane : Attack
{
    public FoxWindInsane()
    {
        Name = "FoxWindInsane";
        AttackElement = Element.wind;
        Damage = 2;
        ChanceToUse = 30;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        Utilities.ApplyEffect(target, StatusE.insane, 1);
    }

}

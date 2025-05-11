using System.Collections.Generic;
using UnityEngine;
public class Weaked : Attack
{
    public Weaked()
    {
        Name = "Weaked";
        Damage = 0;
        AttackElement = Element.neutral;
        ChanceToUse = 20;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        Utilities.ApplyEffect(target, StatusE.weakness, 1);

    }
}
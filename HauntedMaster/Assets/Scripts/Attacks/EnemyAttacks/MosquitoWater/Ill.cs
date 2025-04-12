using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ill : Attack
{
    public Ill()
    {
        Name = "Ill";
        Damage = 0;
        AttackElement = Element.water;
        ChanceToUse = 30;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        Utilities.ApplyEffect(target, StatusE.poison, 3);
    }

}

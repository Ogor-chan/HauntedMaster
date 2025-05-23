using System.Collections.Generic;
using UnityEngine;
public class WarriorHeal : Attack
{
    public WarriorHeal()
    {
        Name = "WarriorHeal";
        Damage = 2;
        AttackElement = Element.neutral;
        ChanceToUse = 15;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        int Who = Random.Range(0, 1);
        Character target = targets[Random.Range(0, targets.Length)];
        if (Who == 0)
        {
            Utilities.ApplyHeal(caster, Damage);
        }
        else
        {
            Utilities.ApplyHeal(target, Damage);
        }

    }
}

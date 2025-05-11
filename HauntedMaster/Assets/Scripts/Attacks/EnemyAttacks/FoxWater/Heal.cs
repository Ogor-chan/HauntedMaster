using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Heal : Attack
{
    public Heal()
    {
        Name = "Heal";
        Damage = 2;
        AttackElement = Element.neutral;
        ChanceToUse = 30;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
       
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.ApplyHeal(target, damage);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FoxWindWhistle : Attack
{
    public FoxWindWhistle()
    {
        Name = "FoxWindWhistle";
        AttackElement = Element.wind;
        Damage = 2;
        ChanceToUse = 60;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (Character target in targets)
        {
            int damage = Utilities.CalculateDamage(caster, target, usedAttack);
            Utilities.DealDamage(target, damage);
        }
    }

}

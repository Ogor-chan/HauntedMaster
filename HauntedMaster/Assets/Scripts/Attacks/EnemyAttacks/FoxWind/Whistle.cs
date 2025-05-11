using System.Collections.Generic;
using UnityEngine;
public class Whistle : Attack
{
    public Whistle()
    {
        Name = "Whistle";
        Damage = 2;
        AttackElement = Element.wind;
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
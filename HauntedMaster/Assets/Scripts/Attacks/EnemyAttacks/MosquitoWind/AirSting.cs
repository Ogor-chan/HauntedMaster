using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AirSting : Attack
{
    public AirSting()
    {
        Name = "AirSting";
        Damage = 1;
        AttackElement = Element.wind;
        ChanceToUse = 50;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);
        Utilities.ApplyEffect(target, StatusE.bleed, 2);
    }

}

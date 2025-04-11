using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AirBoom : Attack
{
    public AirBoom()
    {
        Name = "AirSting";
        Damage = 3;
        AttackElement = Element.wind;
        ChanceToUse = 20;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);
    }

}

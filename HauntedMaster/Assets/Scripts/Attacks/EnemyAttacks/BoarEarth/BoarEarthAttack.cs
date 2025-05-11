using System.Collections.Generic;
using UnityEngine;
public class BoarEarthAttack : Attack
{
    public BoarEarthAttack()
    {
        Name = "BoarEarthAttack";
        Damage = 2;
        AttackElement = Element.earth;
        ChanceToUse = 20;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);

    }
}
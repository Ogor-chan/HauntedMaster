using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PowerRockShot : Attack
{
    public PowerRockShot()
    {
        Name = "PowerRockShot";
        Damage = 2;
        AttackElement = Element.earth;
        ChanceToUse = 25;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);
        Utilities.ApplyEffect(target, StatusE.mud, 3);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaterPoison : Attack
{
    public WaterPoison()
    {
        Name = "WaterPoison";
        AttackElement = Element.water;
        Damage = 0;
        ChanceToUse = 30;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        Utilities.ApplyEffect(target, StatusE.poison, 5);
    }

}

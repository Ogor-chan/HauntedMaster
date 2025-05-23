using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FoxWaterPoison : Attack
{
    public FoxWaterPoison()
    {
        Name = "FoxWaterPoison";
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

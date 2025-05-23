using System.Collections.Generic;
using UnityEngine;
public class BoarProvoke : Attack
{
    public BoarProvoke()
    {
        Name = "BoarProvoke";
        Damage = 0;
        AttackElement = Element.neutral;
        ChanceToUse = 50;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
     
        //Taunt tu ma by�
        Utilities.ApplyEffect(caster,StatusE.armored,1);

    }
}
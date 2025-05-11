using System.Collections.Generic;
using UnityEngine;
public class Provoke : Attack
{
    public Provoke()
    {
        Name = "Provoke";
        Damage = 0;
        AttackElement = Element.neutral;
        ChanceToUse = 50;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
     
        //Taunt tu ma byæ
        Utilities.ApplyEffect(caster,StatusE.armored,1);

    }
}
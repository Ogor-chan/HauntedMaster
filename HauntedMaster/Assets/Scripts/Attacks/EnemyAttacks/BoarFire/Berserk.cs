using System.Collections.Generic;
using UnityEngine;
public class Berserk : Attack
{

    //Na siebie ma byæ 
    public Berserk()
    {
        Name = "Berserk";
        Damage = 0;
        AttackElement = Element.fire;
        ChanceToUse = 15;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
    
        Utilities.ApplyEffect(caster,StatusE.strength,1);
        //Insane ma byæ 
        Utilities.ApplyEffect(caster, StatusE.strength, 1);
    }
}
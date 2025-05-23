using System.Collections.Generic;
using UnityEngine;
public class BoarBerserk : Attack
{

    //Na siebie ma by� 
    public BoarBerserk()
    {
        Name = "BoarBerserk";
        Damage = 0;
        AttackElement = Element.fire;
        ChanceToUse = 15;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
    
        Utilities.ApplyEffect(caster,StatusE.strength,1);
        //Insane ma by� 
        Utilities.ApplyEffect(caster, StatusE.strength, 1);
    }
}
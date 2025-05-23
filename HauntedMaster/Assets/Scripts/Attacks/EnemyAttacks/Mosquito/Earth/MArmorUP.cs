using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MArmorUP : Attack
{
    public MArmorUP()
    {
        Name = "MArmorUP";
        Damage = 0;
        AttackElement = Element.earth;
        ChanceToUse = 20;
        AttackTarget = Target.Team;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {

        // Nie ma leczyæ tylko dawaæ pancerz
        Utilities.ApplyHeal(caster, 10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUp : Attack
{
    public ArmorUp()
    {
        Name = "ArmorUp";
        Damage = 2;
        AttackElement = Element.earth;
        ChanceToUse = 30;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        caster.Armour += caster.Damage * Damage;
        Debug.Log(caster.Name + " Gains Armor: " + (caster.Damage * Damage));
    }

}

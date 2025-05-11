using System.Collections.Generic;
using UnityEngine;
public class Plunder : Attack
{
    public Plunder()
    {
        Name = "Plunder";
        Damage = 1;
        AttackElement = Element.neutral;
        ChanceToUse = 60;
        AttackTarget = Target.Enemy;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        Character target = targets[Random.Range(0, targets.Length)];
        int damage = Utilities.CalculateDamage(caster, target, usedAttack);
        Utilities.DealDamage(target, damage);

        //Jeszcze ma kraœæ 20% z³ota gracza

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireTestAttack : Attack
{
    public FireTestAttack()
    {
        Name = "FireTestAttack";
        EnergyCost = 1;
        Damage = 1;
        AttackElement = Element.fire;
        Cooldown = 0;
        CurrentCooldown = 0;
    }

    public override void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack)
    {
        foreach (var item in targets)
        {
            int damage = Utilities.CalculateDamage(caster, item, usedAttack);
            Utilities.DealDamage(item, damage);

            StatusEffects AppliedEffect = new StatusEffects(StatusE.stun, 1);
            if(item.StatusEffectList.Any(e => e.status == StatusE.stun))
            {
                var thisStatusEffect = item.StatusEffectList.FirstOrDefault(e => e.status == StatusE.stun);
                thisStatusEffect.stack = +1;
            }
            item.StatusEffectList.Add(AppliedEffect);

            Utilities.PlayAttackAnimation(caster, item, true, damage);
        }

    }

}

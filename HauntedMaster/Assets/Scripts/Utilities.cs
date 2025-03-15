using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Utilities : MonoBehaviour
{
    public static event Action CheckDamage;

    public static int CalculateDamage(Character dealer, Character reciever, Attack usedAttack)
    {
        float elementMultiplier = Elements.GetEffectiveness(usedAttack.AttackElement, reciever.MyElement);
        float weaknessMultiplier = dealer.StatusEffectList.Any(e => e.status == StatusE.weakness) ? 0.5f : 1.0f;
        float strenghtMulitplier = dealer.StatusEffectList.Any(e => e.status == StatusE.strength) ? 1.5f : 1.0f;
        float armoredMultiplier = reciever.StatusEffectList.Any(e => e.status == StatusE.armored) ? 0.5f : 1.0f;
        float ripMultiplier = reciever.StatusEffectList.Any(e => e.status == StatusE.rip) ? 1.5f : 1.0f;

        int randomAddit = 0;//UnityEngine.Random.Range(-1, 2);

        float damageDealt = Mathf.Max(dealer.Damage + randomAddit, 1) * usedAttack.Damage * elementMultiplier *
            weaknessMultiplier * strenghtMulitplier * armoredMultiplier * ripMultiplier;

        return Mathf.FloorToInt(damageDealt);
    }


    public static void DealDamage(Character target, int Damage)
    {
        if(target.Armour > 0)
        {
            target.Armour -= Damage;

            if(target.Armour < 0)
            {
                Damage = -target.Armour;
                target.Armour = 0;
            }
        }

        target.CurrentHP -= Damage;
        print(target.Name + " has received " + Damage + " damage!");

        CheckDamage?.Invoke();
    }

    public static void ApplyEffect(Character target, StatusE effect, int stackSize)
    {
        StatusEffects AppliedEffect = new StatusEffects(effect, stackSize);
        if (target.StatusEffectList.Any(e => e.status == effect))
        {
            var thisStatusEffect = target.StatusEffectList.FirstOrDefault(e => e.status == effect);
            thisStatusEffect.stack += stackSize;
        }
        else
        {
            target.StatusEffectList.Add(AppliedEffect);
        }
    }

}

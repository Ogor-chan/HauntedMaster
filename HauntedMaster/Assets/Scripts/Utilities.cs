using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Utilities : MonoBehaviour
{
    public static event Action CheckDamage;

    public static List<StatusE> NegativeEffects = new List<StatusE>
    {
        StatusE.bleed,
        StatusE.burn,
        StatusE.mud,
        StatusE.stun,
        StatusE.rip,
        StatusE.weakness,
        StatusE.poison
    };

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

    public static void ApplyHeal(Character target, int Amount)
    {
        target.CurrentHP += Amount;
        if(target.CurrentHP > target.MaxHP)
        {
            target.CurrentHP = target.MaxHP;
        }
    }

    public static void RemoveNegativeEffects(Character target)
    {
        foreach (StatusE item in NegativeEffects)
        {
            if (target.StatusEffectList.Any(e => e.status == item))
            {
                var thisStatusEffect = target.StatusEffectList.FirstOrDefault(e => e.status == item);
                target.StatusEffectList.Remove(thisStatusEffect);
            };
        }
    }

    public static void DealDamageWithEffect(Character target, StatusEffects effect)
    {
        if(effect.status == StatusE.burn)
        {
            float elementMultiplier = Elements.GetEffectiveness(Element.fire, target.MyElement);
            int damage = (int)(5 * elementMultiplier);
            print(target.Name + " has recieved " + damage + " damage from " + effect.status.ToString());
            DealDamage(target, damage);
        }
        else if(effect.status == StatusE.bleed)
        {
            int damage = 10;
            target.CurrentHP -= damage;
            print(target.Name + " has recieved " + damage + " damage from " + effect.status.ToString());
        }
        else if(effect.status == StatusE.poison)
        {
            int damage = effect.stack * 2;
            print(target.Name + " has recieved " + damage + " damage from " + effect.status.ToString());
            DealDamage(target, damage);
        }
        else if(effect.status == StatusE.mud)
        {
            int damage = effect.stack;
            print(target.Name + " has recieved " + damage + " damage from " + effect.status.ToString());
            DealDamage(target, damage);
        }
        CheckDamage?.Invoke();
    }
}

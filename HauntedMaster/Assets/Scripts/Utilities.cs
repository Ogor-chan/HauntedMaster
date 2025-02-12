using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Utilities : MonoBehaviour
{
    public static event Action CheckDamage;

    public static int CalculateDamage(Character dealer, Character reciever, Attack usedAttack)
    {
        float damageDealt;
        float elementMultiplier = Elements.GetEffectiveness(usedAttack.AttackElement, reciever.MyElement);
        int randomAddit = UnityEngine.Random.Range(-1, 2);


        damageDealt = Mathf.Max(dealer.Damage + randomAddit,1) * usedAttack.Damage * elementMultiplier;


        return Mathf.FloorToInt(damageDealt);
    }


    public static void DealDamage(Character target, int Damage)
    {
        target.CurrentHP -= Damage;
        print(target.Name + " has received " + Damage + " damage!");

        CheckDamage?.Invoke();
    }

}

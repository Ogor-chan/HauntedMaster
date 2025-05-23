using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Target
{
    Enemy,
    Team
}
public abstract class Attack
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Sprite Image { get; set; }

    public int EnergyCost { get; set; }
    public int Damage { get; set; }
    public Element AttackElement { get; set; }
    public int Cooldown { get; set; }
    public int CurrentCooldown;
    public int ChanceToUse;
    public Target AttackTarget;

    public abstract void ExecuteAttack(Character[] targets, Character caster, Attack usedAttack);


    ///JAK ROBI� ATAKI
    ///        Character target = targets[Random.Range(0, targets.Length)];      = Losowy target
    ///        int DamageDealt = Utilities.CalculateDamage(caster, target, usedAttack);    = policz damage
    ///        foreach (Character item in targets)   {}            === AOE 
}

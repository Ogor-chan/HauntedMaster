using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class AttackLibrary
{
    private static Dictionary<string, Type> attackRegistry = new Dictionary<string, Type>
    {
        //////////////////////////////////////////////
        { "RockShot", typeof(RockShot) },
        { "PowerRockShot", typeof(PowerRockShot) },
        { "ArmorUp", typeof(ArmorUp) },
        //////////////////////////////////////////////
        { "Scorch", typeof(Scorch) },
        { "Burst", typeof(Burst) },
        { "Flamethrower", typeof(Flamethrower) },
        //////////////////////////////////////////////

    };

    public static Attack CreateAttack(string attackName)
    {
        if (attackRegistry.TryGetValue(attackName, out Type attackType))
        {
            return (Attack)Activator.CreateInstance(attackType);
        }
        else
        {
            Debug.LogError($"Attack '{attackName}' not found in AttackLibrary!");
            return null;
        }
    }
}

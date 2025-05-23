using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class AttackLibrary
{


    /// <summary>
    /// TUTAJ DODAJESZ NOWO UTWORZONE ATAKI WED£UG WZORU
    /// </summary>
    private static Dictionary<string, Type> attackRegistry = new Dictionary<string, Type>
    {
        //////////////////////////////////////////////
        ///Fox
        ///Earth
        { "RockShot", typeof(RockShot) },
        { "PowerRockShot", typeof(PowerRockShot) },
        { "ArmorUp", typeof(ArmorUp) },
        ///Fire
        { "Scorch", typeof(Scorch) },
        { "Burst", typeof(Burst) },
        { "Flamethrower", typeof(Flamethrower) },
        ///Air
        { "FoxWeaked", typeof(FoxWeaked) },
        { "FoxWindWhistle", typeof(FoxWindWhistle) },
        { "FoxWindInsane", typeof(FoxWindInsane) },
        ///Water
        { "FoxWaterPulse", typeof(FoxWaterPulse) },
        { "FoxWaterPoison", typeof(FoxWaterPoison) },
        { "FoxWaterHeal", typeof(FoxWaterHeal) },
        //////////////////////////////////////////////
        //////////////////////////////////////////////
        //////////////////////////////////////////////
        ///Boar
        ///Air
        { "BoarSwiftyLegs", typeof(BoarSwiftyLegs) },
        { "BoarBooster", typeof(BoarBooster) },
        { "BoarAirAttack", typeof(BoarAirAttack) },
        ///Earth
        { "BoarProvoke", typeof(BoarProvoke) },
        { "BoarEarthAttack", typeof(BoarEarthAttack) },
        { "BoarArmorUp", typeof(BoarArmorUp) },
        ///Fire
        { "BoarVulkan", typeof(BoarVulkan) },
        { "BoarBerserk", typeof(BoarBerserk) },
        { "BoarAttack", typeof(BoarAttack) },
        //////////////////////////////////////////////
        ///Mosquito
        ///Air
        { "AirSting", typeof(AirSting)},
        { "AirBoom", typeof(AirBoom) },
        { "ImSpeed", typeof(ImSpeed) },
        ///Water
        { "WaterSting", typeof(WaterSting)},
        { "WaterBoom", typeof(WaterBoom) },
        { "Ill", typeof(Ill) },
        ///Fire
        { "MFireSting", typeof(MFireSting)},
        { "MFireBoom", typeof(MFireBoom) },
        { "MFireUp", typeof(MFireUp) },
        ///Earth
        { "MEarthBoom", typeof(MEarthBoom)},
        { "MEarthSting", typeof(MEarthSting) },
        { "MArmorUP", typeof(MArmorUP) },
        /////////////////////////////////////////////////
        ///Neutral_Units   
        ///Archer
        { "ArcherMultiShoot", typeof(ArcherMultiShoot)},
        { "ArcherPowerShoot", typeof(ArcherPowerShoot) },
        { "ArcherShoot", typeof(ArcherShoot) },
        ///Warrior
        { "WarriorHeal", typeof(WarriorHeal)},
        { "WarriorRip", typeof(WarriorRip) },
        { "WarriorPlunder", typeof(WarriorPlunder) },
        ///Wolf
        { "WolfWantABlood", typeof(WolfWantABlood)},
        { "WolfShadow", typeof(WolfShadow) },
        { "WolfDarkTail", typeof(WolfDarkTail) },
        { "WolfBiteBite", typeof(WolfBiteBite) },
        /////////////////////////////////////////////////
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

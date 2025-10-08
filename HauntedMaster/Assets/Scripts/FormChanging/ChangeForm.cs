using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class changeForm : MonoBehaviour
{
    [SerializeField] BattleHandler battleHandler;
    
    [Header("Fire")]
    [SerializeField] Sprite fireSprite;
    [SerializeField] int maxHPFire;
    [SerializeField] int damageFire;
    [SerializeField] int armourFire;
    [SerializeField] int speedFire;
    [SerializeField] int energyFire;

    [Header("Water")]
    [SerializeField] Sprite waterSprite;
    [SerializeField] int maxHPWater;
    [SerializeField] int damageWater;
    [SerializeField] int armourWater;
    [SerializeField] int speedWater;
    [SerializeField] int energyWater;

    [Header("Earth")]
    [SerializeField] Sprite earthSprite;
    [SerializeField] int maxHPEarth;
    [SerializeField] int damageEarth;
    [SerializeField] int armourEarth;
    [SerializeField] int speedEarth;
    [SerializeField] int energyEarth;

    [Header("Wind")]
    [SerializeField] Sprite windSprite;
    [SerializeField] int maxHPWind;
    [SerializeField] int damageWind;
    [SerializeField] int armourWind;
    [SerializeField] int speedWind;
    [SerializeField] int energyWind;

    [Header("Neutral")]
    [SerializeField] Sprite neutralSprite;
    [SerializeField] int maxHPNeutral;
    [SerializeField] int damageNeutral;
    [SerializeField] int armourNeutral;
    [SerializeField] int speedNeutral;
    [SerializeField] int energyNeutral;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FormChange(string name)
    {
        switch (name)
        {
            case "fire":
                if(battleHandler.CurrentEnergy >= energyFire){
                    battleHandler.CurrentEnergy -= energyFire;
                    battleHandler.activeCharacter.MyElement = Element.fire;
                    //battleHandler.activeCharacter.CharacterSprite = fireSprite;
                    //battleHandler.activeCharacter.MaxHP = maxHPFire;
                    //battleHandler.activeCharacter.Damage = damageFire;
                    //battleHandler.activeCharacter.Armour = armourFire;
                    //battleHandler.activeCharacter.Speed = speedFire;
                    Debug.Log("Fire form selected");
                    battleHandler.ChangeEnergy();
                }
                break;
            case "water":
                if (battleHandler.CurrentEnergy >= energyWater)
                {
                    battleHandler.CurrentEnergy -= energyWater;
                    battleHandler.activeCharacter.MyElement = Element.water;
                    //battleHandler.activeCharacter.CharacterSprite = waterSprite;
                    //battleHandler.activeCharacter.MaxHP = maxHPWater;
                    //battleHandler.activeCharacter.Damage = damageWater;
                    //battleHandler.activeCharacter.Armour = armourWater;
                    //battleHandler.activeCharacter.Speed = speedWater;
                    Debug.Log("Water form selected");
                    battleHandler.ChangeEnergy();
                }
                break;
            case "earth":
                if (battleHandler.CurrentEnergy >= energyEarth)
                {
                    battleHandler.CurrentEnergy -= energyEarth;
                    battleHandler.activeCharacter.MyElement = Element.earth;
                    //battleHandler.activeCharacter.CharacterSprite = earthSprite;
                    //battleHandler.activeCharacter.MaxHP = maxHPEarth;
                    //battleHandler.activeCharacter.Damage = damageEarth;
                    //battleHandler.activeCharacter.Armour = armourEarth;
                    //battleHandler.activeCharacter.Speed = speedEarth;
                    Debug.Log("Earth form selected");
                    battleHandler.ChangeEnergy();
                }
                break;
            case "wind":
                if (battleHandler.CurrentEnergy >= energyWind)
                {
                    battleHandler.CurrentEnergy -= energyWind;
                    battleHandler.activeCharacter.MyElement = Element.wind;
                    //battleHandler.activeCharacter.CharacterSprite = windSprite;
                    //battleHandler.activeCharacter.MaxHP = maxHPWind;
                    //battleHandler.activeCharacter.Damage = damageWind;
                    //battleHandler.activeCharacter.Armour = armourWind;
                    //battleHandler.activeCharacter.Speed = speedWind;
                    Debug.Log("Wind form selected");
                    battleHandler.ChangeEnergy();
                }
                break;
            case "neutral":
                if (battleHandler.CurrentEnergy >= energyNeutral)
                {
                    battleHandler.CurrentEnergy -= energyNeutral;
                    battleHandler.activeCharacter.MyElement = Element.neutral;
                    //battleHandler.activeCharacter.CharacterSprite = neutralSprite;
                    //battleHandler.activeCharacter.MaxHP = maxHPNeutral;
                    //battleHandler.activeCharacter.Damage = damageNeutral;
                    //battleHandler.activeCharacter.Armour = armourNeutral;
                    //battleHandler.activeCharacter.Speed = speedNeutral;
                    Debug.Log("Neutral form selected");
                    battleHandler.ChangeEnergy();
                }
                break;
            default:
                Debug.Log("No form selected");
                break;
        }
    }
}

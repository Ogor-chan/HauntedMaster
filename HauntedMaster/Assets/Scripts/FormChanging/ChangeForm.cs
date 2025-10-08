using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class changeForm : MonoBehaviour
{
    [SerializeField] BattleHandler battleHandler;
    [SerializeField] GameObject attack1;
    [SerializeField] GameObject attack2;
    [SerializeField] GameObject attack3;

    [Header("Fire")]
    [SerializeField] Sprite fireSprite;
    [SerializeField] Sprite fireAttack1;
    [SerializeField] Sprite fireAttack2;
    [SerializeField] Sprite fireAttack3;
    [SerializeField] int maxHPFire;
    [SerializeField] int damageFire;
    [SerializeField] int armourFire;
    [SerializeField] int speedFire;
    [SerializeField] int energyFire;

    [Header("Water")]
    [SerializeField] Sprite waterSprite;
    [SerializeField] Sprite waterAttack1;
    [SerializeField] Sprite waterAttack2;
    [SerializeField] Sprite waterAttack3;
    [SerializeField] int maxHPWater;
    [SerializeField] int damageWater;
    [SerializeField] int armourWater;
    [SerializeField] int speedWater;
    [SerializeField] int energyWater;

    [Header("Earth")]
    [SerializeField] Sprite earthSprite;
    [SerializeField] Sprite earthAttack1;
    [SerializeField] Sprite earthAttack2;
    [SerializeField] Sprite earthAttack3;
    [SerializeField] int maxHPEarth;
    [SerializeField] int damageEarth;
    [SerializeField] int armourEarth;
    [SerializeField] int speedEarth;
    [SerializeField] int energyEarth;

    [Header("Wind")]
    [SerializeField] Sprite windSprite;
    [SerializeField] Sprite windAttack1;
    [SerializeField] Sprite windAttack2;
    [SerializeField] Sprite windAttack3;
    [SerializeField] int maxHPWind;
    [SerializeField] int damageWind;
    [SerializeField] int armourWind;
    [SerializeField] int speedWind;
    [SerializeField] int energyWind;

    [Header("Neutral")]
    [SerializeField] Sprite neutralSprite;
    [SerializeField] Sprite neutralAttack1;
    [SerializeField] Sprite neutralAttack2;
    [SerializeField] Sprite neutralAttack3;
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
        if (battleHandler.CurrentEnergy > 0)
        {
            battleHandler.playerCharacters[0].myAttacks.Clear();
        }
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
                    battleHandler.playerCharacters[0].myAttacks.Add(new FireTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new FireTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new FireTestAttack());
                    Sprite att1 = attack1.GetComponent<SpriteRenderer>().sprite = fireAttack1;
                    Sprite att2 = attack2.GetComponent<SpriteRenderer>().sprite = fireAttack2;
                    Sprite att3 = attack3.GetComponent<SpriteRenderer>().sprite = fireAttack3;
                    
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
                    battleHandler.playerCharacters[0].myAttacks.Add(new WaterTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new AOEWaterAttackTest());
                    battleHandler.playerCharacters[0].myAttacks.Add(new WaterTestAttack());
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
                    battleHandler.playerCharacters[0].myAttacks.Add(new EarthTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new EarthTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new EarthTestAttack());
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
                    battleHandler.playerCharacters[0].myAttacks.Add(new WindTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new WindTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new WindTestAttack());
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
                    battleHandler.playerCharacters[0].myAttacks.Add(new NeutralTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new NeutralTestAttack());
                    battleHandler.playerCharacters[0].myAttacks.Add(new NeutralTestAttack());
                }
                break;
            default:
                Debug.Log("No form selected");
                break;
        }
    }
}

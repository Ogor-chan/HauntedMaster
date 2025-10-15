using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyPotion : MonoBehaviour
{
    [SerializeField] Potion potionScript;
    [SerializeField] Money moneyScript;

    [SerializeField] int potionCost;

    
    public void BuyPotion()
    {
        if (moneyScript.currentAmount >= potionCost && !potionScript.fullPotions)
        {
            moneyScript.currentAmount -= potionCost;
            moneyScript.UpdateMoneyUI();
            potionScript.AddPotion();
        }
    }
}

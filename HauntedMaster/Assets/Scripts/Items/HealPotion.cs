using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] GameObject potion0;
    [SerializeField] GameObject potion1;
    [SerializeField] GameObject potion2;

    [SerializeField] Heal heal;

    [SerializeField] int healAmount;
    [DoNotSerialize] public bool fullPotions= false;

    public void UsePotion(int potion)
    {
        switch (potion)
        {
            case 0:
                heal.Potion(healAmount);
                potion0.SetActive(false);
                fullPotions = false;
                fullPotions = false;
                break;
            case 1:
                heal.Potion(healAmount);
                potion1.SetActive(false);
                fullPotions = false;
                break;
            case 2:
                heal.Potion(healAmount);
                potion2.SetActive(false);
                fullPotions = false;
                break;
        }
    }

    public void AddPotion()
    {
        if (!potion0.activeInHierarchy)
        {
            potion0.SetActive(true);

        }
        else if (!potion1.activeInHierarchy)
        {
            potion1.SetActive(true);
        }
        else if (!potion2.activeInHierarchy)
        {
            potion2.SetActive(true);
        }
        else
        {
            fullPotions = true;
        }
    }
}

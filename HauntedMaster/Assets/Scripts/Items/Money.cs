using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [Header("Money Object")]
    [SerializeField] TextMeshProUGUI money;

    [Header("Money Amount")]
    [SerializeField] int startAmount;

    [Header("Gived Money After Battle")]
    [SerializeField] int from;
    [SerializeField] int to;

    public int currentAmount;

    private void Start()
    {
        currentAmount = startAmount;
        money.text = currentAmount.ToString();
    }

    public void GainedMoney()
    {
        int gainedMoney = Random.Range(from, to + 1);
        currentAmount += gainedMoney;
        money.text = currentAmount.ToString();
    }

    public void UpdateMoneyUI()
    {
        money.text = currentAmount.ToString();
    }
}

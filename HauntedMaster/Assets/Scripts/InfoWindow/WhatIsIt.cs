using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatIsIt : MonoBehaviour
{
    public bool playerAttack;
    public bool statusEffect;
    public bool isEnemy;
    public bool enemyPos4;
    public bool enemyPos5;
    public bool enemyPos6;
    public bool enemyPos7;
    public bool enemyPos8;
    public bool endTurn;

    public string name;
    public string description;
    BattleStarter battleStarter;
    public EnemyLibrary enemyLibrary;

    // Start is called before the first frame update
    void Start()
    {
        battleStarter = FindObjectOfType<BattleStarter>();


        if (playerAttack)
        {
            
        }
        else if (statusEffect)
        {
            
        }
        else if (enemyPos4)
        {
            name = battleStarter.PositionsList[4].NameText.text;
        }
        else if (enemyPos5)
        {
            name = battleStarter.PositionsList[5].NameText.text;
        }
        else if (enemyPos6)
        {
            name = battleStarter.PositionsList[6].NameText.text;
        }
        else if (enemyPos7)
        {
            name = battleStarter.PositionsList[7].NameText.text;
        }
        else if (enemyPos8)
        {
            name = battleStarter.PositionsList[8].NameText.text;
        }
        else if (endTurn)
        {
            name = "End Turn";
        }
        else
        {
            name = "Unknown";
        }

        // Update is called once per frame
        
    }
    
    void Update()
    {
        //Debug.Log(enemyLibrary.enemies.Count);

        //for (int i = 0; i < enemyLibrary.enemies.Count; i++)
        //{
        //    if (enemyLibrary.enemies[i].myCharacter.Name == name)
        //    {
        //        // tutaj mozna zrobic ze wyswietla sie info o tym enemy
        //        Debug.Log("Found enemy: " + enemyLibrary.enemies[i].myCharacter.Name);
        //        // np wyswietlic jego ataki, statystyki itp
        //        break;
        //    }
        //}

        //Teraz zrobic tak ze jak pobiera nazwe to sprawdza co to jest z list i odnosi sie 
        //    w przypadku enemy do jego data library i poszukuje podobnej nazwy enemy
        //    czyli takie jakies
        //    for (int i = 0; i < EnemyLibrary.Count; i++)
        //{
        //    if (EnemyLibrary[i].myCharacter.Name == name)
        //    {
        //        // tutaj mozna zrobic ze wyswietla sie info o tym enemy
        //        Debug.Log("Found enemy: " + EnemyLibrary[i].myCharacter.Name);
        //        // np wyswietlic jego ataki, statystyki itp
        //        break;
        //    }
        //}
    }
}

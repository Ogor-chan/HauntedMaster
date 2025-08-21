using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    public Vector2 mousePos;
    public RaycastHit2D hit;
    public EnemyLibrary enemyLibrary;

    public float timer = 0f;
    string name;
    string description;
    int enemyID;
    [Header("Info Window")]
    [SerializeField] GameObject infoWindow;
    [SerializeField] TextMeshProUGUI objectName;
    [SerializeField] TextMeshProUGUI objectHP;
    [SerializeField] TextMeshProUGUI objectDamage;
    [SerializeField] TextMeshProUGUI objectArmor;
    [SerializeField] TextMeshProUGUI objectSpeed;
    [SerializeField] TextMeshProUGUI objectElement;
    [SerializeField] TextMeshProUGUI objectDescription;

    // Start is called before the first frame update
    void Start()
    {
        infoWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        hit = Physics2D.Raycast(worldMousePos, Vector2.zero);

        if (hit.collider != null)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {

                Debug.Log("Show info for: " + hit.collider.name);
                WhatIsIt info = hit.collider.GetComponent<WhatIsIt>();
                name = info.name;
                description = info.description;

                if (info.isEnemy)
                {
                    EnemyInfo();
                }
                else if (info.statusEffect)
                {
                    StatusEffectInfo();
                }
                else if (info.endTurn)
                {
                    EndTurnInfo();
                }
                else if (info.playerAttack)
                {
                    if (hit.collider.name == "Attack1")
                    {
                        NeutralTestAttack attack = new NeutralTestAttack();
                        PlayerAttackInfo(attack.Name, attack.EnergyCost.ToString(), attack.Damage.ToString(), attack.AttackElement.ToString(), attack.Cooldown.ToString(), attack.CurrentCooldown.ToString());
                    }
                    else if (hit.collider.name == "Attack2")
                    {
                        AOEWaterAttackTest attack = new AOEWaterAttackTest();
                        PlayerAttackInfo(attack.Name, attack.EnergyCost.ToString(), attack.Damage.ToString(), attack.AttackElement.ToString(), attack.Cooldown.ToString(), attack.CurrentCooldown.ToString());
                    }
                    else if (hit.collider.name == "Attack3")
                    {
                        EarthTestAttack attack = new EarthTestAttack();
                        PlayerAttackInfo(attack.Name, attack.EnergyCost.ToString(), attack.Damage.ToString(), attack.AttackElement.ToString(), attack.Cooldown.ToString(), attack.CurrentCooldown.ToString());
                    }
                    
                }
                timer = -600f;
            }
            

            
        }
        else
        {
            timer = 0f;
        }

        if (infoWindow == true)
        {
            if (Input.anyKeyDown)
            {
                infoWindow.SetActive(false);
                timer = 0f; // Reset timer when any key is pressed
            }

        }
    }

    private void EnemyInfo()
    {
        for (int i = 0; i < enemyLibrary.enemies.Count; i++)
        {
            if (enemyLibrary.enemies[i].myCharacter.Name == name)
            {
                // tutaj mozna zrobic ze wyswietla sie info o tym enemy
                Debug.Log("Found enemy: " + enemyLibrary.enemies[i].myCharacter.Name);
                // np wyswietlic jego ataki, statystyki itp
                enemyID = i;
                break;
            }

        }
        infoWindow.SetActive(true);
        objectName.text = enemyLibrary.enemies[enemyID].myCharacter.Name;
        objectHP.text = "HP: " + enemyLibrary.enemies[enemyID].myCharacter.MaxHP;
        objectDamage.text = "Damage: " + enemyLibrary.enemies[enemyID].myCharacter.Damage;
        objectArmor.text = "Armor: " + enemyLibrary.enemies[enemyID].myCharacter.Armour;
        objectSpeed.text = "Speed: " + enemyLibrary.enemies[enemyID].myCharacter.Speed;
        objectElement.text = "Element: " + enemyLibrary.enemies[enemyID].myCharacter.MyElement.ToString();
        objectDescription.text = "";
    }

    private void StatusEffectInfo()
    {
        Debug.Log("Status Effect: " + name);
        infoWindow.SetActive(true);
        objectName.text = name;
        objectHP.text = "";
        objectDamage.text = "";
        objectArmor.text = "";
        objectSpeed.text = "";
        objectElement.text = "";
        objectDescription.text = description;
    }

    private void EndTurnInfo()
    {
        Debug.Log("End Turn Action");
        infoWindow.SetActive(true);
        objectName.text = name;
        objectHP.text = "";
        objectDamage.text = "";
        objectArmor.text = "";
        objectSpeed.text = "";
        objectElement.text = "";
        objectDescription.text = description;
    }
    private void PlayerAttackInfo(string name, string energy, string damage, string element, string cd, string currentCD)
    { 
        Debug.Log("Player Attack: " + name);
        infoWindow.SetActive(true);
        objectName.text = name;
        objectHP.text = "Energy Cost: " + energy;
        objectDamage.text = "Damage: " + damage;
        objectArmor.text = "Attack Element: " + element;
        objectSpeed.text = "Cooldown: " + cd;
        objectElement.text = "Current Cooldown: " + currentCD;
        objectDescription.text = description;
    }
}

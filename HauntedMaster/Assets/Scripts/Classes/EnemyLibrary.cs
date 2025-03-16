using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDatabase", menuName = "Create Enemy Database")]
public class EnemyLibrary : ScriptableObject
{
    public List<Enemy> enemies = new List<Enemy>();
    //
    public Enemy GetEnemyByName(string enemyName)
    {
        return enemies.Find(enemy => enemy.name == enemyName);
    }
}

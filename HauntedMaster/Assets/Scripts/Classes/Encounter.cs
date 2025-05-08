using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Create Encounter")]
public class Encounter : ScriptableObject
{
    public List<Enemy> enemies = new List<Enemy>();
}

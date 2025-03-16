using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Create Enemy")]
public class Enemy : ScriptableObject
{
    public Character myCharacter;
    public string[] attackNames;
}

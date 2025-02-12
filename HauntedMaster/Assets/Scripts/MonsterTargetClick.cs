using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTargetClick : MonoBehaviour
{
    [SerializeField] private BattleHandler BH;
    public int Position;
    //s

    private void OnMouseDown()
    {
        BH.TargetChoiceClick(Position);
    }
}

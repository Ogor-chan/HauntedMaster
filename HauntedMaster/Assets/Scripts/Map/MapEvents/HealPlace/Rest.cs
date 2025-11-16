using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : MonoBehaviour
{
     int restAmount = 1;
     int restCurrent;

    Map Map;
    Heal heal;


    // Start is called before the first frame update
    void Start()
    {
        restCurrent = restAmount;
        Map = GameObject.Find("MapObject").GetComponent<Map>();
        heal = GameObject.Find("RestPlaceScene").GetComponent<Heal>();
    }

    public void RestPlaceLoad()
    {
        //Debug.Log("RestPlaceLoad");
        //restCurrent = restAmount;
        //Map.RestScene.SetActive(true);

        Map = GameObject.Find("MapObject").GetComponent<Map>();
        Debug.Log("RestPlaceLoad");
        restCurrent = restAmount;
        if (Map == null)
        {
            Debug.LogError("Map is null in RestPlaceLoad!");
            return;
        }
        if (Map.RestScene == null)
        {
            Debug.LogError("Map.RestScene is null in RestPlaceLoad!");
            return;
        }
        Map.RestScene.SetActive(true);
    }

    public void UseRest()
    {
        if (restCurrent > 0)
        {
            heal.Rest();
            restCurrent--;
        }
        //Map.RestScene.SetActive(false);
    }
}

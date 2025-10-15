using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputControl : MonoBehaviour
{

    [SerializeField] Map map;

    [SerializeField] KeyCode mapInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(mapInput))
        {
            map.ShowMap(1);
        }
    }
}

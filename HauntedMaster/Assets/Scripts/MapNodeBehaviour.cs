using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeBehaviour : MonoBehaviour
{
    public Map MapScript;
    public MapNode myNode;
    private bool Hover;
    public Vector3 StaticScale;

    private float HoverSpeed = 2f;
    private void Awake()
    {
        StaticScale = this.gameObject.transform.localScale;
    }

    private void Update()
    {
        if (Hover)
        {
            float scaleFactor = Mathf.Sin(Time.time * HoverSpeed) * 0.3f;

            transform.localScale = StaticScale + new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
    }

    public void UpdateStatus()
    {
        myNode.SpriteR.color = Color.white;
        Hover = false;
        this.gameObject.transform.localScale = StaticScale;
        switch (myNode.Status)
        {
            case NodeStatus.Unavailable:
                myNode.SpriteR.color = new Color(1, 1, 1, 0.3f);
                break;
            case NodeStatus.Explored:
                myNode.SpriteR.color = new Color(0.3f, 0.3f, 0.3f, 1f);
                break;
            case NodeStatus.Current:
                break;
            case NodeStatus.Explorable:
                Hover = true;
                break;
        }
    }


    private void OnMouseDown()
    {
        if(myNode.Status == NodeStatus.Explorable)
        {
            MapScript.MovedOnMap(myNode);
        }
    }
}

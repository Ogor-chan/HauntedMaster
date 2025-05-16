using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NodeType
{
    Fight,
    Heal,
    Shop,
    Event,
    Elite,
    Boss
}

public enum NodeStatus
{
    Current,
    Explorable,
    Explored,
    Unavailable
}
[System.Serializable]
public class MapNode
{
    [Header("GameData")]
    public int ID;
    public NodeType Type;
    public NodeStatus Status;

    [Header("References")]
    public Transform WorldPosition;
    public GameObject NodeObject;
    public SpriteRenderer SpriteR;
    public MapNodeBehaviour NodeScript;

    [Header("VisualData")]
    public bool AlreadyConnectedFrom;
    public bool AlreadyConnectedTo;
    [System.NonSerialized]
    public List<MapNode> NodesIConnectTo;
    [System.NonSerialized]
    public List<MapNode> NodesThatConnectToMe;
}
public class Map : MonoBehaviour
{
    private List<MapNode> MapNodeList = new List<MapNode>();
    private List<MapNode> FixedMapNodes = new List<MapNode>();

    [SerializeField] private GameObject MapNodePrefab;
    [SerializeField] private GameObject linePrefab;
    private GameObject Mother;

    [SerializeField] private List<Sprite> SpriteList;
    //0 - fight, 1 - heal, 2 - shop,
    //3 - event, 4 - elite, 5 - boss

    MapBehaviour MB;

    [Header("Connecting")]
    [SerializeField] private float variation = 0.3f;
    [SerializeField] private float horizontalLim = 3f;
    [SerializeField] private float verticalLim = 2f;

    [Header("MapData")]
    [SerializeField] private int numberOfHeals;
    [SerializeField] private int HealbreakSize;
    [SerializeField] private int numberOfElites;
    [SerializeField] private int ElitebreakSize;
    [SerializeField] private int numberOfShops;
    [SerializeField] private int ShopbreakSize;
    [SerializeField] private int numberOfEvents;
    [SerializeField] private int EventbreakSize;

    private MapNode PreviousNode;

    private void Start()
    {
        MB = GameObject.Find("MapBehaviour").GetComponent<MapBehaviour>();
        Mother = this.transform.Find("Mother").gameObject;
        CreateMap();
    }

    private void SpawnPoints(int t)
    {
        int CID = 0;
        for (int i = 0; i < t; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector2 initialSpawn = new Vector2(-5 + (i * 2), -2  + (j * 2));
                float angle = Random.Range(0f, 2 * Mathf.PI);
                float distance = Random.Range(0f, 0.8f);

                float x = initialSpawn.x + distance * Mathf.Cos(angle);
                float y = initialSpawn.y + distance * Mathf.Sin(angle);
                Vector2 spawnPosition = new Vector2(x, y);
                MapNode spawnedNode = SpawnNode(spawnPosition);
                spawnedNode.ID = CID;
                CID++;

                MapNodeList.Add(spawnedNode);
            }
        }
    }

    private void CreateLine(GameObject Spawner, GameObject target)
    {
        GameObject lineObject = Instantiate(linePrefab, Spawner.transform.position, Quaternion.identity);
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

        lineObject.transform.parent = Mother.transform;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Spawner.transform.position);
        lineRenderer.SetPosition(1, target.transform.position);


        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.sortingOrder = 5;
    }

    private void CheckNearby(MapNode spawner)
    {
        GameObject spawnerObject = spawner.NodeObject;
        Transform spawnerTransform = spawner.WorldPosition;
        foreach (MapNode Node in MapNodeList)
        {
            GameObject item = Node.NodeObject;
            float distance = Vector2.Distance(spawnerTransform.position, item.transform.position);
            if (!Node.AlreadyConnectedFrom && spawner != Node)
            {
                if (spawnerTransform.position.x < item.transform.position.x)
                {
                    if (spawnerTransform.position.y >= item.transform.position.y - variation &&
    spawnerTransform.position.y <= item.transform.position.y + variation)
                    {
                        if (distance < horizontalLim)
                        {
                            CreateLine(spawnerObject, item);
                            spawner.NodesIConnectTo.Add(Node);
                            Node.NodesThatConnectToMe.Add(spawner);
                            Node.AlreadyConnectedTo = true;
                            spawner.AlreadyConnectedFrom = true;
                        }
                    }
                    else
                    {
                        if (distance < verticalLim)
                        {
                            CreateLine(spawnerObject, item);
                            spawner.NodesIConnectTo.Add(Node);
                            Node.NodesThatConnectToMe.Add(spawner);
                            Node.AlreadyConnectedTo = true;
                            spawner.AlreadyConnectedFrom = true;

                        }
                    }
                }
            }
        }
    }

    private void SpawnFixedNodes()
    {
        Vector2 spawnPosition = new Vector2(-9f, 0f);
        MapNode spawnedNode = SpawnNode(spawnPosition);
        spawnedNode.AlreadyConnectedFrom = true;
        spawnedNode.NodesIConnectTo.Add(MapNodeList[0]);
        spawnedNode.NodesIConnectTo.Add(MapNodeList[1]);
        spawnedNode.NodesIConnectTo.Add(MapNodeList[2]);
        PreviousNode = spawnedNode;
        FixedMapNodes.Add(spawnedNode);
        CreateLine(spawnedNode.NodeObject, MapNodeList[0].NodeObject);
        MapNodeList[0].AlreadyConnectedTo = true;
        CreateLine(spawnedNode.NodeObject, MapNodeList[1].NodeObject);
        MapNodeList[1].AlreadyConnectedTo = true;
        CreateLine(spawnedNode.NodeObject, MapNodeList[2].NodeObject);
        MapNodeList[2].AlreadyConnectedTo = true;
        //////////////////////////////////////////////////////////////
        spawnPosition = new Vector2(11f, 0f);
        spawnedNode = SpawnNode(spawnPosition);
        spawnedNode.AlreadyConnectedTo = true;
        spawnedNode.Type = NodeType.Boss;
        spawnedNode.NodeObject.transform.localScale *= 2;
        spawnedNode.NodeScript.StaticScale *= 2;
        FixedMapNodes.Add(spawnedNode);
        int lastID = MapNodeList.Count;
        CreateLine(spawnedNode.NodeObject, MapNodeList[lastID - 1].NodeObject);
        MapNodeList[lastID - 1].AlreadyConnectedFrom = true;
        MapNodeList[lastID - 1].NodesIConnectTo.Add(spawnedNode);
        MapNodeList[lastID - 1].Type = NodeType.Heal;
        CreateLine(spawnedNode.NodeObject, MapNodeList[lastID - 2].NodeObject);
        MapNodeList[lastID - 2].AlreadyConnectedFrom = true;
        MapNodeList[lastID - 2].NodesIConnectTo.Add(spawnedNode);
        MapNodeList[lastID - 2].Type = NodeType.Heal;
        CreateLine(spawnedNode.NodeObject, MapNodeList[lastID - 3].NodeObject);
        MapNodeList[lastID - 3].AlreadyConnectedFrom = true;
        MapNodeList[lastID - 3].NodesIConnectTo.Add(spawnedNode);
        MapNodeList[lastID - 3].Type = NodeType.Heal;
        //////////////////////////////////////////////////////////////
        spawnPosition = new Vector2(-10f, 0f);
        spawnedNode = SpawnNode(spawnPosition);
        spawnedNode.AlreadyConnectedFrom = true;
        spawnedNode.Status = NodeStatus.Current;
        spawnedNode.NodesIConnectTo.Add(FixedMapNodes[0]);
        PreviousNode = spawnedNode;
        FixedMapNodes.Add(spawnedNode);
        CreateLine(spawnedNode.NodeObject, FixedMapNodes[0].NodeObject);
        FixedMapNodes[0].AlreadyConnectedTo = true;
        //////////////////////////////////////////////////////////////
        spawnPosition = new Vector2(-11f, 0f);
        spawnedNode = SpawnNode(spawnPosition);
        spawnedNode.AlreadyConnectedFrom = true;
        spawnedNode.Status = NodeStatus.Current;
        spawnedNode.NodesIConnectTo.Add(FixedMapNodes[2]);
        PreviousNode = spawnedNode;
        FixedMapNodes.Add(spawnedNode);
        CreateLine(spawnedNode.NodeObject, FixedMapNodes[2].NodeObject);
        FixedMapNodes[2].AlreadyConnectedTo = true;
    }

    private MapNode SpawnNode(Vector2 spawnPosition)
    {
        GameObject G = Instantiate(MapNodePrefab, spawnPosition, Quaternion.identity);

        MapNode CurrentNode = new MapNode();
        CurrentNode.NodeObject = G;
        CurrentNode.NodeObject.transform.parent = Mother.transform;
        CurrentNode.SpriteR = G.GetComponent<SpriteRenderer>();
        CurrentNode.WorldPosition = G.transform;
        CurrentNode.Status = NodeStatus.Unavailable;
        CurrentNode.Type = NodeType.Fight;
        CurrentNode.NodesIConnectTo = new List<MapNode>();
        CurrentNode.NodesThatConnectToMe = new List<MapNode>();
        CurrentNode.AlreadyConnectedFrom = false;
        CurrentNode.AlreadyConnectedTo = false;
        CurrentNode.NodeScript = G.GetComponent<MapNodeBehaviour>();
        CurrentNode.NodeScript.myNode = CurrentNode;
        CurrentNode.NodeScript.MapScript = this.gameObject.GetComponent<Map>();

        return CurrentNode;
    }

    private void BringBackLostChildren()
    {
        foreach (MapNode currentNode in MapNodeList)
        {
            if (!currentNode.AlreadyConnectedTo)
            {
                MapNode NearestNode = FindClosestNode(currentNode, true);
                CreateLine(currentNode.NodeObject, NearestNode.NodeObject);
                currentNode.AlreadyConnectedTo = true;
                NearestNode.NodesIConnectTo.Add(currentNode);
                currentNode.NodesThatConnectToMe.Add(NearestNode);
            }

            if (!currentNode.AlreadyConnectedFrom)
            {
                MapNode NearestNode = FindClosestNode(currentNode, false);
                CreateLine(currentNode.NodeObject, NearestNode.NodeObject);
                currentNode.AlreadyConnectedFrom = true;
                currentNode.NodesIConnectTo.Add(NearestNode);
                NearestNode.NodesThatConnectToMe.Add(currentNode);
            }
        }
    }

    private MapNode FindClosestNode(MapNode LostNode, bool Left)
    {
        MapNode CurrentNearestNode = null;
        float CurrentSmallestDistance = 100000000;

        foreach (MapNode NodeFind in MapNodeList)
        {
            if (!LostNode.NodesIConnectTo.Contains(NodeFind))
            {
                if (Left)
                {
                    if (NodeFind.WorldPosition.position.x < LostNode.WorldPosition.position.x &&
                        !NodeFind.NodesIConnectTo.Contains(LostNode))
                    {
                        float distance = Vector2.Distance(LostNode.WorldPosition.position, NodeFind.WorldPosition.position);
                        if (distance < CurrentSmallestDistance)
                        {
                            CurrentNearestNode = NodeFind;
                            CurrentSmallestDistance = distance;
                            LostNode.AlreadyConnectedTo = true;
                        }
                    }
                }
                else
                {
                    if (NodeFind.WorldPosition.position.x > LostNode.WorldPosition.position.x &&
                        !NodeFind.NodesIConnectTo.Contains(LostNode))
                    {
                        float distance = Vector2.Distance(LostNode.WorldPosition.position, NodeFind.WorldPosition.position);
                        if (distance < CurrentSmallestDistance)
                        {
                            CurrentNearestNode = NodeFind;
                            CurrentSmallestDistance = distance;
                            LostNode.AlreadyConnectedFrom = true;
                        }
                    }
                }
            }
        }
        return CurrentNearestNode;
    }

    private void SetSprites()
    {
        List<MapNode> setList = new List<MapNode>();

        foreach (MapNode item in MapNodeList)
        {
            setList.Add(item);
        }
        foreach (MapNode item in FixedMapNodes)
        {
            setList.Add(item);
        }

        foreach (MapNode item in setList)
        {
            switch (item.Type)
            {
                case NodeType.Fight:
                    item.SpriteR.sprite = SpriteList[0];
                    break;
                case NodeType.Heal:
                    item.SpriteR.sprite = SpriteList[1];
                    break;
                case NodeType.Shop:
                    item.SpriteR.sprite = SpriteList[2];
                    break;
                case NodeType.Event:
                    item.SpriteR.sprite = SpriteList[3];
                    break;
                case NodeType.Elite:
                    item.SpriteR.sprite = SpriteList[4];
                    break;
                case NodeType.Boss:
                    item.SpriteR.sprite = SpriteList[5];
                    break;
            }
        }
    }

    private void ChangeMapNodes()
    {
        List<MapNode> TempNodeList = new List<MapNode>();

        foreach (MapNode item in MapNodeList)
        {
            if (item.Type == NodeType.Fight)
            {
                TempNodeList.Add(item);
            }
        }

        for (int i = 0; i < numberOfHeals; i++)
        {
            if(TempNodeList.Count == 0)
            {
                break;
            }
            int randomNode = Random.Range(0, TempNodeList.Count);
            TempNodeList[randomNode].Type = NodeType.Heal;

            List<MapNode> DisallowedNodes = new List<MapNode>();
            DisallowedNodes.Add(TempNodeList[randomNode]);

            for (int g = 0; g < HealbreakSize; g++)
            {
                List<MapNode> DisallowedNodes1 = new List<MapNode>();
                DisallowedNodes1.AddRange(DisallowedNodes);
                foreach (MapNode item in DisallowedNodes1)
                {
                    DisallowedNodes.AddRange(NeigbhouringNodes(item));
                }
            }
            foreach (MapNode item in DisallowedNodes)
            {
                if (TempNodeList.Contains(item))
                {
                    TempNodeList.Remove(item);
                }
            }
        }

        TempNodeList.Clear();

        foreach (MapNode item in MapNodeList)
        {
            if (item.Type == NodeType.Fight)
            {
                TempNodeList.Add(item);
            }
        }

        for (int i = 0; i < numberOfShops; i++)
        {
            if (TempNodeList.Count == 0)
            {
                break;
            }
            int randomNode = Random.Range(0, TempNodeList.Count);
            TempNodeList[randomNode].Type = NodeType.Shop;

            List<MapNode> DisallowedNodes = new List<MapNode>();
            DisallowedNodes.Add(TempNodeList[randomNode]);

            for (int g = 0; g < ShopbreakSize; g++)
            {
                List<MapNode> DisallowedNodes1 = new List<MapNode>();
                DisallowedNodes1.AddRange(DisallowedNodes);
                foreach (MapNode item in DisallowedNodes1)
                {
                    DisallowedNodes.AddRange(NeigbhouringNodes(item));
                }
            }
            foreach (MapNode item in DisallowedNodes)
            {
                if (TempNodeList.Contains(item))
                {
                    TempNodeList.Remove(item);
                }
            }
        }

        TempNodeList.Clear();

        foreach (MapNode item in MapNodeList)
        {
            if (item.Type == NodeType.Fight)
            {
                TempNodeList.Add(item);
            }
        }

        for (int i = 0; i < numberOfEvents; i++)
        {
            if (TempNodeList.Count == 0)
            {
                break;
            }
            int randomNode = Random.Range(0, TempNodeList.Count);
            TempNodeList[randomNode].Type = NodeType.Event;

            List<MapNode> DisallowedNodes = new List<MapNode>();
            DisallowedNodes.Add(TempNodeList[randomNode]);

            for (int g = 0; g < EventbreakSize; g++)
            {
                List<MapNode> DisallowedNodes1 = new List<MapNode>();
                DisallowedNodes1.AddRange(DisallowedNodes);
                foreach (MapNode item in DisallowedNodes1)
                {
                    DisallowedNodes.AddRange(NeigbhouringNodes(item));
                }
            }
            foreach (MapNode item in DisallowedNodes)
            {
                if (TempNodeList.Contains(item))
                {
                    TempNodeList.Remove(item);
                }
            }
        }

        TempNodeList.Clear();

        foreach (MapNode item in MapNodeList)
        {
            if (item.Type == NodeType.Fight)
            {
                TempNodeList.Add(item);
            }
        }

        for (int i = 0; i < numberOfElites; i++)
        {
            if (TempNodeList.Count == 0)
            {
                break;
            }
            int randomNode = Random.Range(0, TempNodeList.Count);
            TempNodeList[randomNode].Type = NodeType.Elite;

            List<MapNode> DisallowedNodes = new List<MapNode>();
            DisallowedNodes.Add(TempNodeList[randomNode]);

            for (int g = 0; g < ElitebreakSize; g++)
            {
                List<MapNode> DisallowedNodes1 = new List<MapNode>();
                DisallowedNodes1.AddRange(DisallowedNodes);
                foreach (MapNode item in DisallowedNodes1)
                {
                    DisallowedNodes.AddRange(NeigbhouringNodes(item));
                }
            }
            foreach (MapNode item in DisallowedNodes)
            {
                if (TempNodeList.Contains(item))
                {
                    TempNodeList.Remove(item);
                }
            }
        }

    }

    private void UpdateAllNodeStatus()
    {
        foreach (MapNode item in MapNodeList)
        {
            item.NodeScript.UpdateStatus();
        }
        foreach (MapNode item in FixedMapNodes)
        {
            item.NodeScript.UpdateStatus();
        }
    }

    private List<MapNode> NeigbhouringNodes(MapNode initialNode)
    {
        List<MapNode> Neighbours = new List<MapNode>();

        foreach (MapNode item in initialNode.NodesIConnectTo)
        {
            Neighbours.Add(item);
        }
        foreach (MapNode item in initialNode.NodesThatConnectToMe)
        {
            Neighbours.Add(item);
        }
        return Neighbours;
    }

    public void MovedOnMap(MapNode ClickedNode)
    {
        PreviousNode.Status = NodeStatus.Explored;

        foreach (MapNode item in PreviousNode.NodesIConnectTo)
        {
            item.Status = NodeStatus.Unavailable;
        }
        PreviousNode = ClickedNode;
        ClickedNode.Status = NodeStatus.Current;

        foreach (MapNode item in ClickedNode.NodesIConnectTo)
        {
            item.Status = NodeStatus.Explorable;
        }


        switch (ClickedNode.Type)
        {
            case NodeType.Fight:
                MB.SpawnEncounter();
                break;
            case NodeType.Heal:
                break;
            case NodeType.Shop:
                break;
            case NodeType.Event:
                break;
            case NodeType.Elite:
                break;
            case NodeType.Boss:
                break;
            default:
                MB.SpawnEncounter();
                break;
        }

        Mother.SetActive(false);
        UpdateAllNodeStatus();

    }

    public void CreateMap()
    {
        SpawnPoints(8);
        SpawnFixedNodes();
        foreach (var item1 in MapNodeList)
        {
            CheckNearby(item1);
        }
        BringBackLostChildren();
        ChangeMapNodes();
        SetSprites();
        UpdateAllNodeStatus();
        MovedOnMap(FixedMapNodes[FixedMapNodes.Count - 1]);
    }

    public void ShowMap()
    {
        //CALL THIS AFTER MAPNODE EVENT HAS BEEN CONCLUDED
        Mother.SetActive(true);
    }

    public void DeleteMap()
    {
        //WILL DO ONCE IT BECOMES RELEVANT
        print("DeleteMap() Not yet implemented");
    }

}

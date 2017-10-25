using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public bool displayGridGizmos;
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    Node[,] grid;
    private Vector3 worldBottomLeft;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    //[Header("[블록]")]
    public static List<GameObject> BlockList = new List<GameObject>();

    [Header("[맵 정보]")]
    public float Wavelength = 0;    // 파장
    public float Amplitude = 0;     // 진폭 (최대 높이 값)

    public static GameObject target = null;
    public static GameObject player;

    void Awake()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
        SetMap();
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        player = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        int blockIndex = Random.Range(0, BlockList.Count);
        player.transform.position = new Vector3(BlockList[blockIndex].transform.position.x, BlockList[blockIndex].transform.position.y + (BlockList[blockIndex].transform.localScale.y/2) + 1, BlockList[blockIndex].transform.position.z);
        player.AddComponent<Unit>();
    }

    public static void MovePlayer()
    {
        player.transform.GetComponent<Unit>().target = Grid.target.transform;
        player.transform.GetComponent<Unit>().PlayerMove();
    }

    public void SetMap()
    {
        for (int i = 0; i < BlockList.Count; i++)
        {
            float xCoord = (BlockList[i].transform.position.x) / Wavelength;
            float zCoord = (BlockList[i].transform.position.z) / Wavelength;
            float y = Mathf.PerlinNoise(xCoord, zCoord) * Amplitude;
            BlockList[i].transform.position = new Vector3(BlockList[i].transform.position.x, y / 2, BlockList[i].transform.position.z);
            BlockList[i].transform.localScale = new Vector3(1, y, 1);
        }
    }

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        int index = 0;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                grid[x, y] = new Node(walkable, worldPoint, x, y);

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = worldPoint;
                cube.AddComponent<Block>();
                Block.instance.Index = index;
                BlockList.Add(cube);
                index++;
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }


    public Vector3 WorldPointFromNode(Node node)
    {
        Node Node = node;
        int x = Node.gridX;
        int y = Node.gridY;
        int roundrad = Mathf.RoundToInt(nodeRadius);
        int posx = Mathf.RoundToInt(worldBottomLeft.x) + (x * roundrad);
        int posy = Mathf.RoundToInt(worldBottomLeft.y) + (y * roundrad);
        Vector3 pos = new Vector3(posx, 0, posy);
        return pos;
    }

    //public List<Node> path;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        //if(displayGridGizmos)
        //{
        //    if(path != null)
        //    {
        //        foreach(Node n in path)
        //        {
        //            Gizmos.color = Color.black;
        //            Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
        //        }
        //    }
        //}
        //else
        //{
            if (grid != null && displayGridGizmos)
            {
                foreach (Node n in grid)
                {
                    Gizmos.color = (n.walkable) ? Color.white : Color.red;
                    //if (path != null)
                    //    if (path.Contains(n))
                    //        Gizmos.color = Color.black;
                    Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
                }
            }
        //}
    }
}

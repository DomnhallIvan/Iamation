using ESarkis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DjiztrackElliot : MonoBehaviour
{
    public Tilemap tileMapBG;
    public Tilemap tileMapArea;
    [SerializeField] private PriorityQueue<Vector3Int> frontier = new PriorityQueue<Vector3Int>();
    public List<Tile> tiles;
    public Dictionary<TileBase, int> TileCost = new Dictionary<TileBase, int>();
    public Vector3Int start;
    public Vector3Int goal;
    public Vector3 offsetGrid = new Vector3(0, -0.11f, 0);
    //public set reached = new set();
    public float delay;
    public Dictionary<Vector3Int, Vector3Int> came_from = new Dictionary<Vector3Int, Vector3Int>();
    private Dictionary<Vector3Int, int> cost_so_far = new Dictionary<Vector3Int, int>();
    public int Movements = 20;

    public TileBase pasto;
    public TileBase arena;
    public TileBase veneno;

    private void Start()
    {
        TileCost.Add(pasto, 1);
        TileCost.Add(arena, 5);
        TileCost.Add(veneno, 8);
    }

    private void Update()
    {
    }
    /*
    public IEnumerator ExpandTilemap()
    {
        frontier.Enqueue(start, 0);
       // reached.Add(start);
        cost_so_far[start] = 0;
        came_from[start] = start;

        while (Movements > 0)
        {
            var current = frontier.Dequeue();



            List<Vector3Int> neighbors = GetNeighbors(current);
            foreach (Vector3Int neighbor in neighbors)
            {
                var new_cost = cost_so_far[current] + Costos(current, neighbor);
                if (!reached.Set.Contains(neighbor) && tileMapBG.HasTile(neighbor))
                {
                    if (!cost_so_far.ContainsKey(neighbor) || new_cost < cost_so_far[neighbor] && tileMapBG.GetTile(neighbor) != null)
                    {
                        if (neighbors != null)
                        {
                            cost_so_far[neighbor] = new_cost;
                            int priority = new_cost;
                            frontier.Enqueue(neighbor, priority);
                            came_from[neighbor] = current;
                            tileMapArea.SetTile(neighbor, tiles[2]);
                            Matrix4x4 matrix = Matrix4x4.TRS(offsetGrid, Quaternion.Euler(0f, 0f, 0f), Vector3.one);
                            tileMapArea.SetTransformMatrix(neighbor, matrix);

                            yield return new WaitForSeconds(delay);
                        }
                    }
                }
            }
            Movements -= 1;

            yield return null;
        }


    }


    public void RestartDictionary()
    {
        came_from = new Dictionary<Vector3Int, Vector3Int>();
        cost_so_far = new Dictionary<Vector3Int, int>();
        frontier.Clear();
        reached.Clear();
        Movements = 20;
    }

    List<Vector3Int> GetNeighbors(Vector3Int current)
    {
        List<Vector3Int> neighbors = new List<Vector3Int>();
        neighbors.Add(new Vector3Int(current.x - 1, current.y, current.z));
        neighbors.Add(new Vector3Int(current.x + 1, current.y, current.z));
        neighbors.Add(new Vector3Int(current.x, current.y - 1, current.z));
        neighbors.Add(new Vector3Int(current.x, current.y + 1, current.z));

        return neighbors;
    }

    //Lo puedo ignorar
    public void AddReached(Vector3Int Reached)
    {
        reached.Set.Add(Reached);
    }

    //Lo dejo igual
    public int Costos(Vector3Int current, Vector3Int neighbour)
    {
        if (tileMapBG.GetTile(current) && tileMapBG.GetTile(neighbour) == pasto)
        {
            return 1;
        }
        if (tileMapBG.GetTile(current) && tileMapBG.GetTile(neighbour) == arena)
        {
            return 30;
        }
        if (tileMapBG.GetTile(current) && tileMapBG.GetTile(neighbour) == veneno)
        {
            return 100;
        }
        return 10000;
    }*/
}

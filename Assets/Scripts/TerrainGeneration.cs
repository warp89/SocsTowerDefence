using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    private const int HORIZONTAL = 11;
    private const int VERTICAL = 6;
    private int[,] field = new int[VERTICAL, HORIZONTAL] {
        { 0,0,0,0,0,0,0,0,0,0,0 },
        { 0,0,0,0,0,5,1,6,0,0,0 },
        { 7,1,1,6,0,2,0,2,0,0,0 },
        { 0,0,0,2,0,2,0,3,1,1,8 },
        { 0,0,0,3,1,4,0,0,0,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,0}};

    void Start()
    {
        for (int y = 0; y < VERTICAL; y++)
        {
            for (int x = 0; x < HORIZONTAL; x++)
            {
                GameObject terrain;
                if (x <= 1 && field[y, x] == 0 || x > 8 && field[y, x] == 0)
                {
                    terrain = Instantiate(Resources.Load<GameObject>(TypeDeterminant(field[y, x])), new Vector2(x, y), Quaternion.identity, transform);
                    Destroy(terrain.transform.GetChild(0).gameObject);
                    terrain.GetComponent<TowerBuilder>().enabled = false;
                    continue;
                }
                if (y == 0 || y == 5)
                {
                    terrain = Instantiate(Resources.Load<GameObject>(TypeDeterminant(field[y, x])), new Vector2(x, y), Quaternion.identity, transform);
                    Destroy(terrain.transform.GetChild(0).gameObject);
                    terrain.GetComponent<TowerBuilder>().enabled = false;
                    continue;
                }

                terrain = Instantiate(Resources.Load<GameObject>(TypeDeterminant(field[y, x])), new Vector2(x, y), Quaternion.identity, transform);
                if (field[y, x] >= 3 && field[y, x] < 7)
                {
                    terrain.GetComponent<RoadTurnScript>().turnKind = field[y, x] - 3;
                }

            }
        }
    }
    private string TypeDeterminant(int type)
    {
        string path = "Prefabs";
        switch (type)
        {
            case 0: path += "/BlankTerrain"; break;
            case 1: path += "/HorizontalRoad"; break;
            case 2: path += "/VerticalRoad"; break;
            case 7: path += "/Spawner"; break;
            case 8: path += "/Finish"; break;
            default: path += "/RoadTurn"; break;
        }
        return path;
    }
    public int[,] GetFieldMap()
    {
        return field;
    }
    
}

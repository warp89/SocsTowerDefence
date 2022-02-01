using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsScript : MonoBehaviour
{
    private TerrainGeneration generatedMap;
    private int[,] gameMap;
    private Vector2[] waypoints;

    private void Start()
    {
        generatedMap = TerrainGeneration.FindObjectOfType<TerrainGeneration>();
        gameMap = generatedMap.GetFieldMap();
        waypoints = new Vector2[SumWaypoints(gameMap)];
        WaypointFill(gameMap);
    }
    public Vector2[] GetWaypoints()
    {
        return waypoints;
    }
    private void WaypointFill(int[,] gameMap)
    {
        Vector2 temporaryPoint;
        int counter = 0;
        int horizontalPosition;
        int verticalPosition;
        temporaryPoint = GetStartPoint(gameMap);
        while (counter != waypoints.Length)
        {
            if (counter == 0)
            {
                verticalPosition = (int)temporaryPoint.x;
                horizontalPosition = (int)temporaryPoint.y;

                for (int i = 0; i < gameMap.GetLength(1); i++)
                {
                    horizontalPosition++;
                    if (gameMap[verticalPosition, horizontalPosition] == 4 || gameMap[verticalPosition, horizontalPosition] == 6)
                    {
                        waypoints[counter] = new Vector2(horizontalPosition, verticalPosition);
                        temporaryPoint = new Vector2(verticalPosition, horizontalPosition);
                        counter++;
                        break;
                    }
                }

            }
            else
            {
                verticalPosition = (int)temporaryPoint.x;
                horizontalPosition = (int)temporaryPoint.y;
                if (gameMap[verticalPosition, horizontalPosition] == 6)
                {
                    for (int i = 0; i < gameMap.GetLength(0); i++)
                    {
                        verticalPosition++;
                        if (gameMap[verticalPosition, horizontalPosition] == 3)
                        {
                            waypoints[counter] = new Vector2(horizontalPosition, verticalPosition);
                            temporaryPoint = new Vector2(verticalPosition, horizontalPosition);
                            counter++;
                            break;
                        }
                    }                    
                }
                if (gameMap[verticalPosition, horizontalPosition] == 4)
                {
                    for (int i = 0; i < gameMap.GetLength(0); i++)
                    {
                        verticalPosition--;
                        if (gameMap[verticalPosition, horizontalPosition] == 5)
                        {
                            waypoints[counter] = new Vector2(horizontalPosition, verticalPosition);
                            temporaryPoint = new Vector2(verticalPosition, horizontalPosition);
                            counter++;
                            break;
                        }
                    }                    
                }
                if (gameMap[verticalPosition, horizontalPosition] == 3 || gameMap[verticalPosition, horizontalPosition] == 5)
                {
                    for (int i = 0; i < gameMap.GetLength(1); i++)
                    {
                        horizontalPosition++;
                        if (gameMap[verticalPosition, horizontalPosition] == 4 || gameMap[verticalPosition, horizontalPosition] == 6 || gameMap[verticalPosition, horizontalPosition] == 8)
                        {
                            waypoints[counter] = new Vector2(horizontalPosition, verticalPosition);
                            temporaryPoint = new Vector2(verticalPosition, horizontalPosition);
                            counter++;
                            break;
                        }
                    }
                }
            }
            
        }

    }
    private Vector2 GetStartPoint(int[,] gameMap)
    {
        Vector2 startPoint;
        for (int i = 0; i < gameMap.GetLength(0); i++)
        {
            if (gameMap[i, 0] == 7)
            {
                startPoint = new Vector2(i, 0);
                return startPoint;
            }
        }
        return new Vector2(0, 0);
    }
    private int SumWaypoints(int[,] map)
    {
        int amountWaypoints = 0;
        foreach (int item in map)
        {
            if (item >= 3 && item != 7)
            {
                amountWaypoints++;
            }
        }
        return amountWaypoints;
    }



}

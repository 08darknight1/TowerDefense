using Array2DEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsTerrain : MonoBehaviour
{
    public GameObject TurretPlace;

    public Array2DBool TurretsFullTerrain;

    void Start()
    {
        Debug.Log("CanPlaceTurrets GridSize[" + TurretsFullTerrain.GridSize.x + "][" + TurretsFullTerrain.GridSize.y + "]");

        var previousXValue = 0;

        var posXMultiplyer = 0;

        var previousYValue = 0;

        var posYMultiplyer = 0;

        for (int x = 0; x < TurretsFullTerrain.GridSize.x; x++)
        {
            for (int y = 0; y < TurretsFullTerrain.GridSize.y; y++)
            {
                var NewTurretPlace = Instantiate(TurretPlace);
                NewTurretPlace.GetComponent<TurretGridBlock>().SetGridPosition(x, y);
                NewTurretPlace.GetComponent<TurretGridBlock>().SetCanBeUsed(TurretsFullTerrain.GetCell(x, y));

                if (previousYValue != y)
                {
                    previousYValue = y;
                    posYMultiplyer++;
                }

                if (previousXValue != x) 
                {
                    previousXValue = x;
                    posXMultiplyer++;
                    posYMultiplyer = 0;
                }

                var NewTurretPlacePos = NewTurretPlace.transform.position;
                NewTurretPlace.transform.position = new Vector3(NewTurretPlacePos.x + (1 * posXMultiplyer),
                                                                NewTurretPlacePos.y,
                                                                NewTurretPlacePos.z - (1 * posYMultiplyer));
            }
        }
    }
}

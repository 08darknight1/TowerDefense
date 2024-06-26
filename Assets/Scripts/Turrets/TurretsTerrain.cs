using Array2DEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsTerrain : MonoBehaviour
{
    public GameObject TurretPlace;

    public Array2DBool ActiveTurretsInTerrain;

    public Array2DBool DeactivateTerrain;

    void Start()
    {
        //Debug.Log("CanPlaceTurrets GridSize[" + ActiveTurretsInTerrain.GridSize.x + "][" + ActiveTurretsInTerrain.GridSize.y + "]");

        var previousXValue = 0;

        var posXMultiplyer = 0;

        var previousYValue = 0;

        var posYMultiplyer = 0;

        var turretsGrids = new GameObject();
        turretsGrids.name = "TurretsGrid";
        turretsGrids.transform.parent = gameObject.transform;
        turretsGrids.transform.localPosition = Vector3.zero;

        var cont = 0;

        for (int x = 0; x < ActiveTurretsInTerrain.GridSize.x; x++)
        {
            for (int y = 0; y < ActiveTurretsInTerrain.GridSize.y; y++)
            {
                var quaternionZero = new Quaternion(0, 0, 0, 0);
                var NewTurretPlace = Instantiate(TurretPlace, Vector3.zero, quaternionZero);

                NewTurretPlace.GetComponent<TurretGridBlock>().SetGridPosition(x, y);
                NewTurretPlace.GetComponent<TurretGridBlock>().SetCanBeUsed(ActiveTurretsInTerrain.GetCell(x, y));

                if(DeactivateTerrain.GetCell(x, y))
                {
                    NewTurretPlace.GetComponent<MeshRenderer>().enabled = false;
                    NewTurretPlace.GetComponent<BoxCollider>().enabled = false;
                }

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

                NewTurretPlace.transform.parent = turretsGrids.transform;
                NewTurretPlace.transform.localPosition = Vector3.zero;

                var NewTurretPlacePos = NewTurretPlace.transform.localPosition;
                NewTurretPlace.transform.localPosition = new Vector3(NewTurretPlacePos.x + (1 * posXMultiplyer),
                                                                NewTurretPlacePos.y,
                                                                NewTurretPlacePos.z - (1 * posYMultiplyer));

                NewTurretPlace.name = "TurretPlace[" + cont + "]";
                cont++;
            }
        }
    }
}

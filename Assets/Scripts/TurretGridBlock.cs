using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TurretGridBlock : MonoBehaviour
{
    [SerializeField] private int[] _gridPostion;

    private bool _canBeUsed;

    private MeshRenderer _renderer;

    public Material[] MaterialsForTerrain;

    public void SetGridPosition(int posX, int posY)
    {
        _gridPostion = new int[2];
        //Setting x position 
        _gridPostion[0] = posX;
        //Setting y position
        _gridPostion[1] = posY;
    }

    public void SetCanBeUsed(bool valueToSet)
    {
        _canBeUsed = valueToSet;

        _renderer = gameObject.GetComponent<MeshRenderer>();

        if (_canBeUsed)
        {
            var newMaterialList = new List<Material>();
            newMaterialList.Add(MaterialsForTerrain[0]);
            _renderer.SetMaterials(newMaterialList);
        }
        else
        {
            var newMaterialList = new List<Material>();
            newMaterialList.Add(MaterialsForTerrain[1]);
            _renderer.SetMaterials(newMaterialList);
        }
    }

    public bool ReturnCanBeUsed()
    {
        return _canBeUsed;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class TurretGridBlock : MonoBehaviour
{
    [SerializeField] private int[] _gridPostion;

    private bool _canBeUsed;

    private MeshRenderer _renderer;

    public Material[] MaterialsForTerrain;

    public GameObject TurretOptionsCanvas;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canBeUsed)
        {
            var mousePos = Input.mousePosition;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            Debug.DrawRay(Camera.main.transform.position, mousePos - Camera.main.transform.position, Color.cyan, Mathf.Infinity);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.name != gameObject.name)
                {
                    Debug.Log("Hit something else, sorry! Called: " + hit.transform.name);
                }
                else
                {
                    Debug.Log("Hit TurretGridBlock from " + gameObject.name + "! Opening Turret Options!");
                    var turretOptionCanvas = Instantiate(TurretOptionsCanvas);
                    turretOptionCanvas.transform.SetParent(gameObject.transform);
                    turretOptionCanvas.transform.localPosition = new Vector3(0, 3, 0);
                }
            }
        }
    }

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

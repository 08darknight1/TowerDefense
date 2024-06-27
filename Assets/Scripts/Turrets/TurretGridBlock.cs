using System.Collections.Generic;
using UnityEngine;

public class TurretGridBlock : MonoBehaviour
{
    [SerializeField] private int[] _gridPostion;

    private bool _canBeUsed;

    private bool _turretSpawned;

    private MeshRenderer _renderer;

    public Material[] MaterialsForTerrain;

    public GameObject TurretOptionsCanvas;

    private TurretData _turretData;

    private PlayerController _playerController;

    private GameController _gameController;

    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canBeUsed)
        {
            var mousePos = Input.mousePosition;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            Debug.DrawRay(Camera.main.transform.position, mousePos - Camera.main.transform.position, Color.cyan, Mathf.Infinity);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && _gameController.ReturnCurrentGameState() == GameStage.GAMEPLAY)
            {
                if (hit.transform.name != gameObject.name)
                {
                    Debug.Log("Hit something else, sorry! Called: " + hit.transform.name);
                }
                else
                {
                    if (_playerController._actionTag != PlayerActionTag.MOVING_TURRET)
                    {
                        Debug.Log("Hit TurretGridBlock from " + gameObject.name + "! Opening Turret Options!");
                        var turretOptionCanvas = Instantiate(TurretOptionsCanvas);
                        turretOptionCanvas.transform.SetParent(gameObject.transform);
                        turretOptionCanvas.transform.localPosition = new Vector3(0, 4, 0);
                        turretOptionCanvas.name = "TurretPlacingOptionsCanvas";
                    }
                    else
                    {
                        if (!_turretSpawned)
                        {
                            //Disable all other stuff from the previous owner of the turret
                            var turretOptionsCanvas = GameObject.Find("TurretPlacingOptionsCanvas");

                            var oldParentGridBlock = turretOptionsCanvas.transform.parent.gameObject.GetComponent<TurretGridBlock>();

                            var turretName = oldParentGridBlock.ReturnCurrentTurretData()._turretName;

                            oldParentGridBlock.SetTurretSpawned(false, null);


                            //Put all the turret stuff on the new grid block
                            var turret = oldParentGridBlock.transform.Find(turretName).gameObject;

                            turret.transform.parent = gameObject.transform;

                            turret.transform.localPosition = new Vector3(0, 0.75f, 0);

                            var turretData = turret.GetComponent<TurretData>();

                            SetTurretSpawned(true, turretData);

                            turretOptionsCanvas.GetComponent<TurretsCanvasController>().ApplyTurretsDefaultMaterial(turret);

                            Destroy(turretOptionsCanvas);

                            _playerController._actionTag = PlayerActionTag.IDLE;
                        }
                    }
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

    public void SetTurretSpawned(bool ValueToSet, TurretData newTurretData)
    {
        _turretSpawned = ValueToSet;

        if (ValueToSet)
        {
            _turretData = newTurretData;
        }/*
        else
        {
            _turretData = null;
        }*/
    }

    public TurretData ReturnCurrentTurretData()
    {
        if (_turretSpawned)
        {
            return _turretData;
        }

        return null;
    }

    public bool ReturnCanBeUsed()
    {
        return _canBeUsed;
    }

    public bool ReturnTurretSpawned()
    {
        return _turretSpawned;
    }
}

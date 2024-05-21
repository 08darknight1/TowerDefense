using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretsCanvasController : MonoBehaviour
{
    public GameObject[] UnitsToBuy;

    private TurretGridBlock _turretGridBlock;

    public Material[] _specialTurretsMaterial;
    //0 - Yellow Material (MovingTurretState)

    public Material[] _turretsMaterial;

    private PlayerController _playerController;

    void Start()
    {
        _turretGridBlock = gameObject.transform.parent.gameObject.GetComponent<TurretGridBlock>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        CheckIfPlayerIsClickingOutside();
        UpdateUIButtonsState();
        CheckForPlayerRightClick();
    }

    private void CheckForPlayerRightClick()
    {
        if(Input.GetMouseButtonDown(1) && _playerController._actionTag == PlayerActionTag.MOVING_TURRET)
        {
            var turret = gameObject.transform.parent.transform.Find(_turretGridBlock.ReturnCurrentTurretData()._turretName).gameObject;
            ApplyTurretsDefaultMaterial(turret);
            _playerController._actionTag = PlayerActionTag.IDLE;
            Destroy(gameObject);
        }
    }

    public void CheckToBuyNewTurret(int index)
    {
        var turretSelected = UnitsToBuy[index].GetComponent<TurretData>();

        if(PlayerData.Money >= turretSelected.ReturnTurretCost() && !_turretGridBlock.ReturnTurretSpawned())
        {
            PlayerData.Money -= turretSelected.ReturnTurretCost();

            var newTurret = Instantiate(UnitsToBuy[index]);

            newTurret.transform.SetParent(gameObject.transform.parent.transform);

            newTurret.transform.localPosition = new Vector3(0, 0.75f, 0);

            newTurret.name = turretSelected.name;

            _turretGridBlock.SetTurretSpawned(true, turretSelected);

            Destroy(gameObject);
        }
    }

    public void CheckToDestroyCurrentTurret()
    {
        if (_turretGridBlock.ReturnTurretSpawned())
        {
            var parent = gameObject.transform.parent.gameObject;
            var turret = parent.transform.Find(_turretGridBlock.ReturnCurrentTurretData()._turretName).gameObject;

            Destroy(turret);

            PlayerData.Money += _turretGridBlock.ReturnCurrentTurretData()._turretCost/2;
            _turretGridBlock.SetTurretSpawned(false, null);

            Destroy(gameObject);
        }
    }

    public void UpdateUIButtonsState()
    {
        var initialMenu = gameObject.transform.Find("InitialMenu").gameObject;

        var destroyButton = initialMenu.transform.Find("Destroy").gameObject.GetComponent<Button>();
        var buyButton = initialMenu.transform.Find("Buy").gameObject.GetComponent<Button>();
        var moveButton = initialMenu.transform.Find("Move").gameObject.GetComponent<Button>();

        destroyButton.interactable = _turretGridBlock.ReturnTurretSpawned();//destroy = true se o turretspawned é igual a true
        moveButton.interactable = _turretGridBlock.ReturnTurretSpawned(); ;//move = true se o turretspawned é igual a true
        buyButton.interactable = !_turretGridBlock.ReturnTurretSpawned();//buy = true se o turretspawned é igual a false
    }

    private void CheckIfPlayerIsClickingOutside()
    {
        if (_playerController._actionTag != PlayerActionTag.MOVING_TURRET)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var destroySelf = true;

                var PointerEventData = new PointerEventData(EventSystem.current);

                PointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                var Raycaster = GetComponent<GraphicRaycaster>();

                Raycaster.Raycast(PointerEventData, results);

                var fullChildList = GetComponentsInChildren<Transform>();

                for (int z = 0; z < results.Count; z++)
                {
                    for (int x = 0; x < fullChildList.Length; x++)
                    {
                        if (results[z].gameObject.name == fullChildList[x].gameObject.name)
                        {
                            destroySelf = false;
                        }
                    }
                }

                if (destroySelf)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void MoveCurrentSpawnedTurret()
    {
        var currentTurretData = _turretGridBlock.ReturnCurrentTurretData();

        var parent = gameObject.transform.parent;

        var turret = parent.transform.Find(currentTurretData._turretName).gameObject;

        Debug.Log("TurretName: " + turret.name);

        ApplyNewMaterialToWholeTurret(turret, _specialTurretsMaterial[0]);

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        _playerController._actionTag = PlayerActionTag.MOVING_TURRET;
    }

    private void ApplyNewMaterialToWholeTurret(GameObject Turret, Material newMaterial)
    {
        var modelGameobject = Turret.transform.GetChild(0).gameObject;

        var childCount = modelGameobject.transform.childCount;

        for (int x = 0; x < childCount; x++)
        {
            var childMeshRenderer = modelGameobject.transform.GetChild(x).gameObject.GetComponent<MeshRenderer>();
            var newMaterialsList = new List<Material>();
            newMaterialsList.Add(newMaterial);
            childMeshRenderer.SetMaterials(newMaterialsList);
        }
    }

    public void ApplyTurretsDefaultMaterial(GameObject Turret)
    {
        var modelGameobject = Turret.transform.GetChild(0).gameObject;

        var childCount = modelGameobject.transform.childCount;

        for (int x = 0; x < childCount; x++)
        {
            var childMeshRenderer = modelGameobject.transform.GetChild(x).gameObject.GetComponent<MeshRenderer>();
            var newMaterialsList = new List<Material>();
            newMaterialsList.Add(_turretsMaterial[x]);
            childMeshRenderer.SetMaterials(newMaterialsList);
        }
    }
}

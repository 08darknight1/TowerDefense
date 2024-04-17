using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretsCanvasController : MonoBehaviour
{
    public GameObject[] UnitsToBuy;

    void Update()
    {
        CheckIfPlayerIsClickingOutside();
    }

    public void CheckToBuyNewTurret(int index)
    {
        var turretSelected = UnitsToBuy[index].GetComponent<TurretData>();

        if(PlayerData.Money >= turretSelected.ReturnTurretCost())
        {
            PlayerData.Money -= turretSelected.ReturnTurretCost();

            var newTurret = Instantiate(UnitsToBuy[index]);

            newTurret.transform.SetParent(gameObject.transform.parent.transform);

            newTurret.transform.localPosition = new Vector3(0, 0.75f, 0);

            Destroy(gameObject);
        }
    }

    private void CheckIfPlayerIsClickingOutside()
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

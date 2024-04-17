using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurretsCanvasController : MonoBehaviour
{
    private int contTillDeletion;

    void Update()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private string _actionTag;

    void Start()
    {
        _actionTag = "Idle";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var allCanvas = GameObject.FindGameObjectsWithTag("TurretOptionsCanvas");

            if (allCanvas.Length > 0)
            {
                for (int x = 0; x < allCanvas.Length; x++)
                {
                    Destroy(allCanvas[x]);
                }
            }
        }
    }
}

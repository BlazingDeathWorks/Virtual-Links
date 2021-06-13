using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MousePosController : MonoBehaviour
{
    private Camera cm = null;

    private void Awake()
    {
        cm = Camera.main;
    }

    void Update()
    {
        Cursor.visible = false;

        Vector3 pos = GetMousePos();
        transform.position = pos;
    }

    private Vector3 GetMousePos()
    {
        Vector3 worldPoint = cm.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = -60;
        return worldPoint;
    }
}

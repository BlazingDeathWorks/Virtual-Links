using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosController : MonoBehaviour
{
    [SerializeField]
    private Camera cm = null;
    Transform myTransform = null;

    private void Awake()
    {
        myTransform = transform;
    }

    void LateUpdate()
    {
        Vector3 mousePos = GetMousePos();
        Cursor.visible = false;
        myTransform.position = new Vector3(mousePos.x, mousePos.y);
    }

    Vector3 GetMousePos()
    {
        return cm.ScreenToWorldPoint(Input.mousePosition);
    }
}

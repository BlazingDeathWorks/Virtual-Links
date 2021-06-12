using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Camera cm = null;

    void Update()
    {
        Cursor.visible = true;

        Vector3 viewToWorld = cm.ViewportToWorldPoint(GetMousePos());
        Vector3 pos = new Vector3(viewToWorld.x, viewToWorld.y);
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, pos, Quaternion.identity);
        }
        Debug.Log(cm.ScreenToViewportPoint(Input.mousePosition));
    }

    private Vector3 GetMousePos()
    {
        Vector3 viewPoint = cm.ScreenToViewportPoint(Input.mousePosition);
        return viewPoint;
    }
}

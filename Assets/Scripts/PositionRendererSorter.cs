using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField]
    private float offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;

    private SpriteRenderer sr = null;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!sr) return;
        sr.sortingOrder = Mathf.RoundToInt((transform.position.y + offset));
        if (runOnlyOnce)
        {
            Destroy(this);
        }
    }
}

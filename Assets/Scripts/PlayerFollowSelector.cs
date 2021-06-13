using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class PlayerFollowSelector : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CinemachineVirtualCamera cm = null;
    [Tooltip("Should be from 1 - 5")]
    [SerializeField] private int target;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (cm == null) return;
        float initialZ = cm.transform.position.z;
        target = Mathf.Clamp(target, 1, Spawner.PrefabTransforms.Count);
        cm.Follow = Spawner.PrefabTransforms[target-1];
        cm.transform.position = new Vector3(cm.transform.position.x, cm.transform.position.y, initialZ);
    }
}

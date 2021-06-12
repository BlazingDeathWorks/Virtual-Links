using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float reloadSpeed = 1;
    private float time = 3;

    public void Shoot(Damagable damagable)
    {
        damagable.health -= damage;
    }

    private void Update()
    {
        Reload();
    }

    private void Reload()
    {
        time += Time.deltaTime;

        if (!Input.GetKeyDown(KeyCode.Mouse1)) return;
        if(time >= reloadSpeed + 1)
        {
            LeanTween.rotate(gameObject, new Vector3(0, 0, 270), reloadSpeed).setLoopPingPong(1);
            time = 0;
        }
    }
}

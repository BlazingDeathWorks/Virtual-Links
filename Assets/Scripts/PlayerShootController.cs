using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float reloadSpeed = 1;
    [SerializeField]
    private Text ammoText;
    private float time = 3;
    private int currentAmmo = 0;
    private const int bulletsPerMag = 12;

    private void Awake()
    {
        ResetAmmo();
    }
    
    private void UpdateAmmoText()
    {
        currentAmmo = Mathf.Clamp(currentAmmo, 0, bulletsPerMag);
        ammoText.text = currentAmmo.ToString();
    }

    public void Shoot(Damagable damagable)
    {
        if (currentAmmo > 0)
        {
            damagable.health -= damage;
        }
    }

    private void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentAmmo--;
            UpdateAmmoText();
        }
    }

    private void Update()
    {
        FireBullet();
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
            ResetAmmo();
        }
    }

    private void ResetAmmo()
    {
        currentAmmo = bulletsPerMag;
        UpdateAmmoText();
    }
}

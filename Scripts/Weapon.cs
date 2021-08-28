using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public Joystick joystick;
    public GameObject bullet;
    private int a = 0;
    public int ammo;
    public Slider slider;

    private void Start()
    {
        ammo = 100;
        slider.value = ammo;
    }

    private void Update()
    {
        CheckFire();
        slider.value = ammo;
    }

    public void CheckFire()
    {
        if (joystick.Direction != new Vector2(0, 0) && a == 0)
        {
            a = 1;
            StartCoroutine(SW());
        }
        else if (joystick.Direction == new Vector2(0, 0))
        {
            a = 0;
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        ammo--;
    }

    IEnumerator SW()
    {
        FindObjectOfType<AudioManager>().PlayIt("Выстрел_1", false, 0.25f);
        Shoot();
        if (a == 1 && ammo>0)
        {
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(SW());
        }
    }
}

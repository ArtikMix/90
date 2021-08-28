using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int HP;
    public Slider slider;
    public GameObject deathBack;

    private void Start()
    {
        HP = 100;
        slider.value = HP;
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Death();
        }
    }

    public void SetHealth(int hp)
    {
        HP -= hp;
        slider.value = HP;
        Debug.Log("Player recieve " + hp + " damage." + " Player's HP: " + HP + ".");
    }

    public void Death()
    {
        Debug.Log("Помер!");
        deathBack.SetActive(true);
    }
}

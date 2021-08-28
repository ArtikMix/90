using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLocation : MonoBehaviour
{
    public Transform[] spawn;
    private int kol = 0;
    public GameObject enemy;
    Save save;
    private bool startSpawn = false;
    private int xui = 0;
    void Start()
    {
        //StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (FindObjectOfType<Save>().end == true && xui == 0)
        {
            startSpawn = true;
        }
        if (startSpawn == true)
        {
            xui = 1;
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        startSpawn = false;
        yield return new WaitForSeconds(1.5f);
        int mesto = Random.Range(0, 3);
        Instantiate(enemy, spawn[mesto].position, spawn[mesto].rotation);
        kol++;
        if (kol < 50)
        {
            StartCoroutine(Spawn());
        }
    }
}

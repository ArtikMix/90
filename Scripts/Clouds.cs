using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public GameObject cloud;

    private void Update()
    {
        cloud.transform.position = new Vector2(5000f * Time.deltaTime, 283f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Joystick joystick;
    private Transform rot;

    private void Update()
    {
        if (joystick.Direction != new Vector2(0, 0))
        {
            float hAxis = joystick.Horizontal;
            float vAxis = joystick.Vertical;
            float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, -zAxis);
            rot.eulerAngles = transform.eulerAngles;
        }
        else
        {
            this.transform.eulerAngles = rot.eulerAngles;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Joystick joystick;
    private int a = 0;
    private Animator anim;
    Rotation rotat;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rotat = GetComponent<Rotation>();
    }

    void Update()
    {
        movement.x = joystick.Horizontal * moveSpeed;
        movement.y = joystick.Vertical * moveSpeed;
        if (joystick.Direction != new Vector2(0, 0) && a == 0)
        {
            FindObjectOfType<AudioManager>().PlayIt("Хотьба");
            a = 1;
            anim.SetBool("isrunning", true);
        }
        else if (joystick.Direction == new Vector2(0,0))
        {
            FindObjectOfType<AudioManager>().StopIt("Хотьба");
            a = 0;
            anim.SetBool("isrunning", false);
        }
        if (rotat.joystick.Direction == new Vector2(0, 0))
        {
            float hAxis = joystick.Horizontal;
            float vAxis = joystick.Vertical;
            float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, -zAxis);
            rb.transform.eulerAngles = transform.eulerAngles;
        }
        if (joystick.Direction == new Vector2(0,0) && rotat.joystick.Direction == new Vector2(0, 0))
        {
            transform.eulerAngles = rb.transform.eulerAngles;
        }
        if (joystick.Direction == new Vector2(0,0)&& rotat.joystick.Direction != new Vector2(0, 0))
        {
            rotat.transform.eulerAngles = rotat.transform.eulerAngles;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);    
    }
}

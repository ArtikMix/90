using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeh : MonoBehaviour
{
    public Transform player;
    public float movespeed = 5f;
    private Rigidbody2D rb;
    //public Rigidbody2D look;
    private Vector2 movement;
    public GameObject enemyDeath;
    private bool near = false;
    private string[] mat = { "блядь сука тикай", "блядь мы потеряли", "вот тебе", "дебилоидные гандоны", "нихуя себе снайпер", "ой мамочка", "сука чё творится", "суки ебашут", "помер1", "помер2", "помер3", "помер4", "помер5", "попадание пулей" };

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle-90f;//тут баговало, и враг шёл плечом вперёд. пришлось фиксить с помощью костыля.
        direction.Normalize();
        movement = direction;
        if (Vector2.Distance(player.position, transform.position) <= 3.0f)
        {
            movespeed = 0f;
            if (near == false)
            {
                near = true;
            }
            if (near == true)
            {
                StartCoroutine(Damage());
            }
        }
        else
        {
            movespeed = 5f;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            int i;
            i = Random.Range(1, 20);
            if (i>=14 && i <= 20)
            {
                i = 14;
            }
            FindObjectOfType<AudioManager>().PlayIt(mat[i]);
            Instantiate(enemyDeath, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<Win>().kills++;
        }
    }

    IEnumerator Damage()
    {
        FindObjectOfType<PlayerStats>().SetHealth(15);
        yield return new WaitForSeconds(2.5f);
        near = false;
    }
}





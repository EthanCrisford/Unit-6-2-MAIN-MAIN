using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    //OnTriggerEnter2D col;
    float InputHorizontal;
    float InputVertical;
    public float speed = 5.0f;
    SpriteRenderer sr;
    public GameObject particleEffect1;
    public GameObject particleEffect2;
    //public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        if (InputHorizontal != 0)
        {
            rb.AddForce(new Vector2(horizontal * speed, 0f));
        }

        print(horizontal);

        if (horizontal < -0.2f)
        {
            sr.flipX = false;
        }
        if (horizontal > 0.2f)
        {
            sr.flipX = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Instantiate(particleEffect1, transform.position, Quaternion.identity);

            Destroy(col.gameObject);

            Instantiate(particleEffect2, GameObject.FindGameObjectWithTag("Player").transform);
        }
    }
}


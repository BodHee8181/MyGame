using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int direction;
    [SerializeField]
    float speed;
    [SerializeField]
    int jumpCount;
    Rigidbody2D rb;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = 0;
        if (transform.position.x < player.transform.position.x)
        {
            direction -= 1;
        }
        if (transform.position.x > player.transform.position.x)
        {
            direction += 1;
        }
        rb.AddForce(Vector2.right * direction * speed * Time.deltaTime);
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(direction * maxSpeed, rb.velocity.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunTest : MonoBehaviour
{
    //Direction, speed, jumping, enemies, double jumps?, 
    int direction;
    [SerializeField]
    float speed;
    [SerializeField]
    int jumpCount;
    Rigidbody2D rb;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float health;
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float maxJump;
    int jumpDirection;



    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += 1;
        }
        rb.AddForce(Vector2.right * direction * speed * Time.deltaTime);
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(direction * maxSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            jumpDirection += 1;
            jumpCount += 1;
        }
        rb.AddForce(Vector2.up * jumpDirection * jumpHeight * Time.deltaTime);
        if (Mathf.Abs(rb.velocity.y) > maxJump)
        {
            rb.velocity = new Vector2(jumpDirection * maxJump, rb.velocity.x);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            if (health <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

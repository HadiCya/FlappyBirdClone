using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    float timer = 0f;
    public float speed = 5.5f;
    public float jumpTime = 0.3f;
    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {

            timer += Time.deltaTime;

            if (Input.GetButton("Jump") && timer > jumpTime)
            {
                timer = 0;
                rb.SetRotation(15f);
                rb.angularVelocity = 0f;
                rb.velocity = new Vector2(0f, 0f);
                rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddTorque(timer * -1.7f);
            }
        }

    }

    public void Death(string type)
    {
        dead = true;
        rb.SetRotation(-90f);
        rb.freezeRotation = true;
        rb.angularVelocity = 0f;
        rb.velocity = new Vector2(0f, 0f);
        GameObject.FindObjectOfType<Pipes>().enabled = false;
        if (type.Equals("Pipes"))
        {
            rb.AddForce(transform.up * -speed*2, ForceMode2D.Impulse);
        } else if (type.Equals("Floor"))
        {
            rb.gravityScale = 0;
        }
    }
    
}

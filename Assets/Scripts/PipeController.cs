using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyPipe", 7f);
    }

    void destroyPipe()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (GameObject.FindObjectOfType<PlayerController>().dead)
        {
            CancelInvoke("destroyPipe");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindObjectOfType<PlayerController>().Death("Pipes");

    }

}

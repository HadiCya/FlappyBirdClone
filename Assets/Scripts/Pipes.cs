using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public GameObject pipe;
    public GameObject scoreTrigger;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.Translate(-0.01f, 0f, 0f);
        if (timer > 1.5f)
        {
            timer = 0;
            float rand = Random.Range(1f, 5f);
            float p1 = (-11 + rand);
            float p2 = (11 - (6 - rand));
            GameObject pipe1 = Instantiate(pipe, new Vector3(11, p1, 0), Quaternion.identity);
            pipe1.transform.parent = gameObject.transform;
            GameObject score = Instantiate(scoreTrigger, new Vector3(12, (p1 + p2) / 2, 0), Quaternion.identity);
            score.transform.parent = gameObject.transform;
            GameObject pipe2 = Instantiate(pipe, new Vector3(11, p2, 0), pipe.transform.rotation);
            pipe2.transform.parent = gameObject.transform;
        }
    }

}

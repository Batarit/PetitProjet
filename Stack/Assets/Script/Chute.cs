using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chute : MonoBehaviour
{
    [SerializeField]
    float timerLive = 5;

    [SerializeField]
    float speedChute;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerLive -= Time.deltaTime;

        transform.Translate(0, -speedChute * Time.deltaTime, 0);

        if (timerLive <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Mouvabel : MonoBehaviour
{
    int speed = 25;

    protected static bool isMooving = true;


    public static bool IsMooving { get { return isMooving; } }

    private void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
        if (isMooving)
        {
            transform.Translate(0, 0, -speed*Time.deltaTime);
        }

        if (transform.position.z < -60)
        {
            Destroy(gameObject);
        }
        Beavior();
    }

    public static void StopMove()
    {
        isMooving = false;
    }
    public static void PlayMoving()
    {
        isMooving = true;
    }

    public virtual void Beavior() {}
}

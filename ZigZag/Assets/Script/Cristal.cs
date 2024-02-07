using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -9)
        {
            Destroy(gameObject);
        }

        transform.Rotate(Vector3.one * 20 * Time.deltaTime);
    }
}

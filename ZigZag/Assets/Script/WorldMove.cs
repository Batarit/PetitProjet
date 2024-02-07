using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).Translate(Vector3.back * 2 * Time.deltaTime);

        }
    }
}

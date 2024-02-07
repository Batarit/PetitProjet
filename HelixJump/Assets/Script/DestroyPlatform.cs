using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision != null)
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                if(collision.gameObject.GetComponent<Player>().Destruction == true)
                {
                    Transform t = transform.GetComponentInParent<Platform>().transform;
                    for (int i = 0; i < t.childCount; i++)
                    {
                        if(t.GetChild(i).tag != "Undestroy")
                        {
                            Destroy(t.GetChild(i).gameObject);

                        }
                    }
                }
            }
    }
}

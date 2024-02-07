using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    [SerializeField]
    GameObject cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
            if (other.gameObject.GetComponent<Player>() != null)
            {
                cam.transform.position -= Vector3.up * 8;
                other.gameObject.GetComponent<Player>().Combo++;
                FindObjectOfType<Score>().AddScore(1 * other.gameObject.GetComponent<Player>().Combo);
            }
    }

}

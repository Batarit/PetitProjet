using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    bool isColid = false;

    bool destruction = false;

    int combo = 0;

    public int Combo { get { return combo; } set { combo = value; } }

    public bool Destruction { get { return destruction; } set { destruction = value; } }

    // Update is called once per frame
    void Update()
    {
        if (combo >= 3)
        {
            destruction = true;
        }
        else
        {
            destruction = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {

            gameObject.GetComponent<Rigidbody>().velocity = Vector3.up * 9;
            isColid = true;
            combo = 0;
            if (collision.gameObject.tag == "Bad" && destruction == false)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision != null)
        {
            if (isColid)
            {
                isColid = false;
            }
        }

    }
}

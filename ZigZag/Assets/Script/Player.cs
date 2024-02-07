using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    int direction = 1;

    int score = 0;


    public int Score { get { return score; } }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            direction = -direction;
        }

        transform.Translate(Vector3.right * direction * 2 * Time.deltaTime);

        if (transform.position.y < -2)
        {
            if (PlayerPrefs.GetInt("HighScore") <= Score)
                PlayerPrefs.SetInt("HighScore", Score);
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        if (other != null)
        {
            if (other.gameObject.GetComponent<Cristal>() != null)
            {
                score++;
                Destroy(other.gameObject);
            }
        }
    }
}

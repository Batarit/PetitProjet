using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    int nbScore;
    TMP_Text textScore;
    int nbScene;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().buildIndex != nbScene)
        {
            if (GameObject.FindWithTag("Score") != null)
            {
                if (GameObject.FindWithTag("Score").GetComponent<TMP_Text>() != null)
                {
                    textScore = GameObject.FindWithTag("Score").GetComponent<TMP_Text>();
                    nbScene = SceneManager.GetActiveScene().buildIndex;
                }
            }
        }
        if (textScore != null)
            textScore.text = "Score : " + nbScore;
    }

    public void AddScore(int nb)
    {
        nbScore += nb;
    }
}

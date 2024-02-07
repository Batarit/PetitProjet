using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerBody : MonoBehaviour
{
    int pv = 2;

    int score = 2;

    [SerializeField]
    GameObject textPv;
    [SerializeField]
    GameObject textScore;

    List<Obstacle> obstacleOn;

    bool inObstacle;
    bool allredyInObstacle;
    [SerializeField]
    float timerLife = 0;
    float lifeLoseTime = 0.5f;

    public int Pv { get { return pv; } }
    private void Start()
    {
        obstacleOn = new List<Obstacle>();
        textPv.GetComponent<TMP_Text>().text = pv.ToString();
        textScore.GetComponent<TMP_Text>().text = score.ToString();
    }

    private void Update()
    {
        if (inObstacle)
        {
            timerLife += Time.deltaTime;
            if (timerLife > lifeLoseTime)
            {
                timerLife = 0;
                pv--;
                textPv.GetComponent<TMP_Text>().text = pv.ToString();
                for (int i = 0; i < obstacleOn.Count; i++)
                {

                    obstacleOn[i].pvRemouve--;
                    obstacleOn[i].LostHP();
                    if (obstacleOn[i] == null || obstacleOn[i].pvRemouve <= 0)
                    {
                        allredyInObstacle = false;
                        inObstacle = false;
                        obstacleOn.Remove(obstacleOn[i]);
                        Mouvabel.PlayMoving();

                    }
                }
            }
        }

        if (pv <= 0)
        {
            if (PlayerPrefs.GetFloat("HighScore") < score)
                PlayerPrefs.SetInt("HighScore", score);
            SceneManager.LoadScene(0);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            PVPlus pVPlus = other.gameObject.GetComponent<PVPlus>();
            if (pVPlus != null)
            {
                pv += pVPlus.AddPV();
                score += pVPlus.AddPV();
                Destroy(pVPlus.gameObject);

            }
            Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                Mouvabel.StopMove();
                obstacleOn.Add(obstacle);
                if (inObstacle)
                {
                    allredyInObstacle = true;
                }
                inObstacle = true;
            }
        }
        textPv.GetComponent<TMP_Text>().text = pv.ToString();
        textScore.GetComponent<TMP_Text>().text = score.ToString();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {

            Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                if (allredyInObstacle)
                {
                    allredyInObstacle = false;
                }
                else
                {
                    inObstacle = false;

                    Mouvabel.PlayMoving();
                }
                obstacleOn.Remove(obstacle);
            }
        }
    }
}

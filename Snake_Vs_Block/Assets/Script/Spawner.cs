using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    GameObject[] mouvabels;

    float timerWall = 0;
    float timerObject = 0;

    float SpawnTimeWall = 2.5f;

    float SpawnTimeObject = 0.5f;

    [SerializeField]
    GameObject text;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouvabel.IsMooving)
        {
            timerWall += Time.deltaTime;
            timerObject += Time.deltaTime;
        }

        if (timerWall >= SpawnTimeWall)
        {
            timerWall = 0;
            timerObject = 0;
            GameObject block = Instantiate(mouvabels[0], transform);

            Obstacle obstacle = block.GetComponent<Obstacle>();

            if (obstacle != null)
            {
                obstacle.text = text;
            }

        }

        if (timerObject >= SpawnTimeObject)
        {

            timerObject = 0;
            int rSpawn = Random.Range(0, 100);

            if (rSpawn < 10)
            {
                Instantiate(mouvabels[1], transform);
            }
            else if (rSpawn >= 10 && rSpawn < 20)
            {
                Instantiate(mouvabels[2], transform);
            }
            else if (rSpawn >= 20 && rSpawn < 30)
            {
                Instantiate(mouvabels[3], transform);
            }
            else if (rSpawn >= 30 && rSpawn < 40)
            {
                Instantiate(mouvabels[2], transform);
                Instantiate(mouvabels[3], transform);
            }
        }
    }
}

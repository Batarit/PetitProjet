using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawners = null;

    [SerializeField]
    GameObject chute;

    GameObject platformRef = null;

    int conteur = 0;

    int id = 0;
    // Start is called before the first frame update
    void Start()
    {
        Spawning(id);
    }

    void Spawning(int spawnerId)
    {

        Spawner spawner = spawners[spawnerId].GetComponent<Spawner>();
        if (spawner != null)
        {
            platformRef = transform.GetChild(transform.childCount - 1).gameObject;
            spawner.platform = platformRef;
            spawner.spawn(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawner spawner = spawners[id].GetComponent<Spawner>();

            transform.Translate(0, -0.5f, 0);

            if (spawner != null)
            {

                GameObject platform = spawner.StopPlatform();
                Vector3 distance = platformRef.transform.position - platform.transform.position;
                if (distance.z < platformRef.transform.localScale.z / 20 && distance.z > -platformRef.transform.localScale.z / 20
                    && distance.x < platformRef.transform.localScale.x / 20 && distance.x > -platformRef.transform.localScale.x / 20)
                {
                    Vector3 tempVector = new Vector3(platformRef.transform.position.x, 0, platformRef.transform.position.z);
                    platform.transform.SetPositionAndRotation(tempVector, Quaternion.identity);


                }
                else if (distance.magnitude > platform.transform.localScale.magnitude)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {

                    Vector3 tempScale = new Vector3(platform.transform.localScale.x - Math.Abs(distance.x), 0.5f, platform.transform.localScale.z - Math.Abs(distance.z));

                    platform.transform.localScale = tempScale;
                    Vector3 tempPose = new Vector3(distance.x / 2, 0, distance.z / 2);
                    platform.transform.Translate(tempPose);
                    GameObject tempChute = Instantiate(chute);
                    tempChute.transform.position = platform.transform.position;
                    tempChute.transform.Translate(-tempPose);

                    if (distance.x == 0)
                    {
                        tempChute.transform.localScale = new Vector3(platform.transform.localScale.x, 0.5f, Math.Abs(distance.z));
                        Vector3 poseSpawn = new Vector3(spawners[1].transform.position.x, spawners[1].transform.position.y, platform.transform.position.z);
                        spawners[1].transform.position = poseSpawn;
                    }
                    if (distance.z == 0)
                    {
                        tempChute.transform.localScale = new Vector3(Math.Abs(distance.x), 0.5f, platform.transform.localScale.z);
                        Vector3 poseSpawn = new Vector3(platform.transform.position.x, spawners[0].transform.position.y, spawners[0].transform.position.z);
                        spawners[0].transform.position = poseSpawn;
                    }
                }
                if (platform.transform.localScale.x <= 0 || platform.transform.localScale.z <= 0)
                {
                    SceneManager.LoadScene(0);
                }
                id++;
                conteur++;
                if (id >= spawners.Length)
                {
                    id = 0;
                }
                if(conteur >= 15)
                {
                    if (spawners[id].GetComponent<Spawner>() != null)
                    {
                        spawners[id].GetComponent<Spawner>().Accelerate();
                    }
                }
                Spawning(id);
            }
        }
    }
}

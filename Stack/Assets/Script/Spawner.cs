using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    Vector3 velocity;

    Vector3 velocityTemp;

    [SerializeField]
    Vector3 limit;

    public GameObject platform;

    GameObject platformActive;

    bool spawned = false;

    [SerializeField]
    Gradient gradient;

    [SerializeField]
    float valueGradient = 0f;

    // Start is called before the first frame update
    void Start()
    {
        velocityTemp = velocity;
        limit = -transform.position / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned)
        {
            platformActive.transform.position += velocityTemp * Time.deltaTime;
            if (limit.z < 0)
            {
                if (platformActive.transform.position.z < limit.z)
                {
                    velocityTemp *= -1;
                    limit *= -1;
                }
            }
            else if (limit.z > 0)
            {
                if (platformActive.transform.position.z > limit.z)
                {
                    velocityTemp *= -1;
                    limit *= -1;
                }
            }
            if (limit.x < 0)
            {
                if (platformActive.transform.position.x < limit.x)
                {
                    velocityTemp *= -1;
                    limit *= -1;
                }
            }
            else if (limit.x > 0)
            {
                if (platformActive.transform.position.x > limit.x)
                {
                    velocityTemp *= -1;
                    limit *= -1;
                }
            }
        }
    }

    public void spawn(Transform parent)
    {
        platformActive = Instantiate(platform, parent);
        platformActive.transform.position = transform.position;
        if (platformActive.GetComponent<Renderer>() != null) 
            platformActive.GetComponent<Renderer>().material.color = gradient.Evaluate(valueGradient);
        spawned = true;
    }

    public GameObject StopPlatform()
    {
        spawned = false;
        valueGradient += 0.02f;
        return platformActive;
    }

    public void Accelerate()
    {
        if (velocity.magnitude < 30)
        {

            if (velocity.x < 0)
            {
                velocity.x -= 5;
            }
            if (velocity.z < 0)
            {
                velocity.z -= 5;
            }
        }
    }
}

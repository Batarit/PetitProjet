using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{

    [SerializeField]
    GameObject platform;

    [SerializeField]
    GameObject point;

    [SerializeField]
    bool isStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        //limite x 2.828428 decalage x 0.707108
        //decalage z 0.7071065
        if (transform.position.z < 25 && !isStarted)
        {

            int isScoreRand = Random.Range(0, 10);

            int positionGOD = Random.Range(0, 2);

            if (platform != null)
            {
                GameObject platf = Instantiate(platform, transform.parent);
                float ofssetX = 0.707108f;
                if (positionGOD == 0 && transform.position.x > -2.828428)
                {
                    ofssetX = platf.transform.position.x - ofssetX;
                }
                else if (transform.position.x < 2.828428)
                {
                    ofssetX = platf.transform.position.x + ofssetX;
                }
                else
                {
                    ofssetX = platf.transform.position.x - ofssetX;
                }
                platf.transform.position = new Vector3(ofssetX, platf.transform.position.y, platf.transform.position.z + 0.7071065f);
            }

            if (isScoreRand == 0)
            {
                GameObject p = Instantiate(point, transform.parent);
                p.transform.position = new Vector3(transform.position.x, p.transform.position.y, transform.position.z);
            }

            isStarted = true;
        }
    }

    private void Update()
    {
        if (!isStarted && transform.position.z < 25)
        {
            Start();
        }
        if (transform.position.z < -1)
        {
            transform.Translate(Vector3.down * 2 * Time.deltaTime);
        }
        if (transform.position.z < -9)
        {
            Destroy(gameObject);
        }
    }


}

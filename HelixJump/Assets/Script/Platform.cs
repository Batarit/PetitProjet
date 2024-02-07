using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField]
    GameObject platformJump;

    [SerializeField]
    GameObject platformDeath;


    public int nbMaxDeath = 1;

    public int nbMinPath = 4;


    // Start is called before the first frame update
    void Start()
    {
        int idGen = 0;
        for (int i = 0; i < 18; i++)
        {
            if (idGen != 2)
            {
                idGen = Random.Range(0, 3);
                if (nbMinPath <= 0 || i < 18 - nbMinPath)
                {

                    if (idGen == 0 || (idGen == 1 && nbMaxDeath <= 0) || (idGen == 2 && nbMinPath <= 0))
                    {
                        GameObject newPlatform = Instantiate(platformJump, transform);
                        newPlatform.transform.Rotate(0, i * 20, 0);
                    }
                    else if (idGen == 1)
                    {
                        GameObject newPlatform = Instantiate(platformDeath, transform);
                        newPlatform.transform.Rotate(0, i * 20, 0);
                        nbMaxDeath--;
                    }
                    else if (idGen == 2)
                    {
                        nbMinPath--;
                    }
                }
            }
            else
            {
                nbMinPath--;
                idGen = 0;
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    [SerializeField]
    NavMeshAgent agent;


    // Update is called once per frame
    void Update()
    {
        if (agent != null)
        {
            if(Input.GetMouseButton(0))
            {
                agent.isStopped = false;

                var v3 = Input.mousePosition;

                v3 = Camera.main.ScreenToWorldPoint(v3);
                v3.y = 0;
                v3.z = 0;
                agent.SetDestination(v3);
            }
            if (Input.GetMouseButtonUp(0))
            {
                agent.isStopped = true;
            }
        }
    }

}

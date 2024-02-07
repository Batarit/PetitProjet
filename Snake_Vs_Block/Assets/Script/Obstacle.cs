using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : Mouvabel
{
    public int pvRemouve = 0;


    public GameObject text;

    private void Start()
    {
        pvRemouve = Random.Range(1, FindObjectOfType<PlayerBody>().Pv);
        text.GetComponent<TMP_Text>().text = pvRemouve.ToString();
    }

    public void LostHP()
    {
        text.GetComponent<TMP_Text>().text = pvRemouve.ToString();
    }

    public override void Beavior()
    {
        if(pvRemouve <= 0)
        {
            Destroy(gameObject);
        }
    }
}

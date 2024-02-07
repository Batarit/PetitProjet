using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("HighScore").ToString(); 
    }
}

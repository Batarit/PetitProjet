using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UndestroyRule : MonoBehaviour
{

    public static UndestroyRule instance;

    [SerializeField, Min(1)]
    int nbLigne;

    [SerializeField, Min(1)]
    int nbColone;

    public int NbLigne { get { return nbLigne; } set { nbLigne = value; } }
    public int NbColone { get { return nbColone; } set { nbColone = value; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}

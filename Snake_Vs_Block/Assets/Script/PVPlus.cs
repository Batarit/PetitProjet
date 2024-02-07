using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVPlus : Mouvabel
{
    int PvAdded = 0;

    private void Start()
    {
        PvAdded = Random.Range(1, 10);
    }


    public int AddPV()
    { return PvAdded; }
}

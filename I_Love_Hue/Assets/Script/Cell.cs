using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public PlayerC player;

    public Color cBase;

    public bool isGood = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerC>();
        isGood = cBase == GetComponent<Image>().color;
    }

    public bool IsGood() 
    { 
        return isGood = cBase == GetComponent<Image>().color;
    }

    public void OnClick()
    { 
        if(!isGood)
        {
            if(player.c == Color.white)
            {
                player.c = GetComponent<Image>().color;
                player.cell = this;
                GetComponent<Image>().color = Color.white;
            }
            else
            {
                player.cell.GetComponent<Image>().color = GetComponent<Image>().color;
                GetComponent<Image>().color = player.c;
                player.c = Color.white;
                isGood = cBase == GetComponent<Image>().color;
                player.cell.isGood = player.cell.cBase == player.cell.GetComponent<Image>().color;
                if(isGood)
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
                if (player.cell.isGood)
                {
                    player.cell.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }
}

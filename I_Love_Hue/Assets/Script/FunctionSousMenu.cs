using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionSousMenu : MonoBehaviour
{

    public void Play1()
    {
        UndestroyRule.instance.NbLigne = 3;
        UndestroyRule.instance.NbColone = 10;
        SceneManager.LoadScene(1);
    }

    public void Play2()
    {
        UndestroyRule.instance.NbLigne = 5;
        UndestroyRule.instance.NbColone = 18;
        SceneManager.LoadScene(1);
    }

    public void Play3()
    {
        UndestroyRule.instance.NbLigne = 10;
        UndestroyRule.instance.NbColone = 10;
        SceneManager.LoadScene(1);
    }

    public void Play4()
    {
        UndestroyRule.instance.NbLigne = 15;
        UndestroyRule.instance.NbColone = 15;
        SceneManager.LoadScene(1);
    }
    public void Play5()
    {
        UndestroyRule.instance.NbLigne = 18;
        UndestroyRule.instance.NbColone = 18;
        SceneManager.LoadScene(1);
    }

}

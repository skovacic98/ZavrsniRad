using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPick : MonoBehaviour
{
    public void PickMap1()
    {
        SceneManager.LoadScene("Map1");
    }
    public void PickMap2()
    {
        SceneManager.LoadScene("Map2");
    }
    public void PickMap3()
    {
        SceneManager.LoadScene("Map3");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1MenuEvents : MonoBehaviour
{
    public void RestartLevel()
    {
        Debug.Log("click");
        SceneManager.LoadScene(1);
    }
    public void GoToLevel2()
    {
        SceneManager.LoadScene(2);
    }
}

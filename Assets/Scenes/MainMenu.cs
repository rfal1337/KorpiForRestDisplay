using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void GoToSelection()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void GoToRegister()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void GoToExperience()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void GoToRos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
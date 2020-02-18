using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void GoToRegister()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void GoToExperience()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
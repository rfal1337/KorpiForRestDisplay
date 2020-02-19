using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseHandler : MonoBehaviour {

    public InputField nameField;
    public InputField pinField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("pin", pinField.text);

        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 3 && pinField.text.Length == 4);
    }
}

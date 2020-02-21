using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public int userID;
    Button b;
    private FillUsers fillUs;

    public void CallLogin()
    {
        Debug.Log(fillUs.pinField.GetComponent<InputField>().text.Length);
        if(fillUs.pinField.GetComponent<InputField>().text.Length == 4)
            StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        form.AddField("pin", fillUs.pinField.GetComponent<InputField>().text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;

        Debug.Log(www.text);
        if (www.text[0] == '0')
        {
            DBManager.userID = userID;
        }
        else
        {
            fillUs.pinField.GetComponent<InputField>().text = string.Empty;
        }   

    }

    void Awake()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(PromptPin);
        fillUs = GameObject.Find("DatabaseManager").GetComponent<FillUsers>();
        fillUs.pinField.GetComponent<InputField>().onValueChanged.AddListener(delegate { CallLogin(); });
    }

    void PromptPin()
    {
        fillUs.pinField.SetActive(true);
    }
}

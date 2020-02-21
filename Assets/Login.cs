using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public InputField pinField;
    public int userID;
    Button b;
    private FillUsers fillUs;

    public void CallLogin()
    {
        if(fillUs.pinField.GetComponent<InputField>().text.Length == 4)
            StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        form.AddField("pin", pinField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;

        Debug.Log(www.text);
        if (www.text[0] == '0')
        {
            DBManager.userID = userID;
            DBManager.username = www.text.Split('\t')[1];
        }
        else
        {
            pinField.text = string.Empty;
        }   

    }

    void Awake()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(PromptPin);
        fillUs = GameObject.Find("DatabaseManager").GetComponent<FillUsers>();
    }

    void PromptPin()
    {
        fillUs.pinField.SetActive(true);
    }
}

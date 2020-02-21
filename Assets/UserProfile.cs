using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserProfile : MonoBehaviour {

    public Profile profile;
    public InputField pinField;
    Button b;
    GameObject pf;

    public void Awake()
    {
        pf = GameObject.Find("PinField");
        pinField = pf.GetComponent<InputField>();
        b = GetComponent<Button>();
        b.onClick.AddListener(PromptPin);
    }

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("pin", pinField.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php");
        yield return www;
        
        if(www.text[0] == '0')
        {
            
        }

    }

    void PromptPin()
    {
        pf.SetActive(true);
    }

}

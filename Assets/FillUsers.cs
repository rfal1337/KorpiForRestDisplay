using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillUsers : MonoBehaviour
{

    public GameObject userObject;
    public GameObject content;
    private GameObject user;
    public GameObject pinField;
    Dictionary<int, string> userDetails = new Dictionary<int, string>();

    // Use this for initialization
    void Awake()
    {
        pinField = GameObject.Find("PinField");
        StartCoroutine(GetUsers());
    }

    void PromptPin()
    {
        GameObject.Find("PinField").SetActive(true);
    }

    IEnumerator GetUsers()
    {
        WWW www = new WWW("http://localhost/sqlconnect/getusers.php");
        yield return www;
        string[] webResults = www.text.Split('\t');

        foreach (string s in webResults)
        {
            string[] info = s.Split('|');
            int i;
            if (Int32.TryParse(info[0], out i))
            {
                userDetails.Add(i, info[1]);
            }
        }

        foreach (var item in userDetails)
        {
            Debug.Log(item);
            user = Instantiate(userObject, content.transform);
            user.GetComponent<Login>().userID = item.Key;
            user.GetComponentInChildren<Text>().text = item.Value;
        }

        pinField.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillUsers : MonoBehaviour {

    public GameObject userObject;
    public GameObject content;
    private GameObject user;
    private UserProfile up;
    public GameObject pf;

	// Use this for initialization
	void Start () {
        pf = GameObject.Find("PinField");
        StartCoroutine(GetUsers());
    }

    IEnumerator GetUsers()
    {
        WWWForm form = new WWWForm();

        WWW www = new WWW("http://localhost/sqlconnect/getusers.php");
        user = Instantiate(userObject, content.transform);
        up = user.GetComponent<UserProfile>();
        pf.SetActive(false);
        yield return www;
    }
}

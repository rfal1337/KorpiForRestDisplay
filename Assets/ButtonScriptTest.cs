using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScriptTest : MonoBehaviour {

    Button b;
	// Use this for initialization
	void Start () {
        b = GetComponent<Button>();
        b.onClick.AddListener(ButtonTest);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ButtonTest()
    {
        GetComponent<Networkingv2>().SendMyDataMessage();
    }
}

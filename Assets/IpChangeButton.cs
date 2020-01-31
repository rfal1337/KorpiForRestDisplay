using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IpChangeButton : MonoBehaviour {

    Button b;

	// Use this for initialization
	void Start () {
        b = GetComponent<Button>();
        b.onClick.AddListener(OpenTextInput);
	}
	
	private void OpenTextInput()
    {

    }
}

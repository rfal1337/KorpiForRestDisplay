using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScriptTest : MonoBehaviour {

    Button b;
    Texture tex;
    GameObject cam;

	// Use this for initialization
	void Start () {
        b = GetComponent<Button>();
        b.onClick.AddListener(ButtonTest);
	}
	
    void ButtonTest()
    {
        if (gameObject.name != "PictureButton")
            GetComponent<Networkingv2>().SendMyDataMessage();
        else
        {
            cam = GameObject.Find("UserImage");
            tex = cam.GetComponent<RawImage>().texture;
            cam.GetComponent<DeviceCamera>().StopCamera();
            cam.GetComponent<RawImage>().texture = tex;
            
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScriptTest : MonoBehaviour {

    Button b;
    public Texture tex;
    GameObject cam;

	// Use this for initialization
	void Start () {
        b = GetComponent<Button>();
        b.onClick.AddListener(ButtonTest);
	}
	
    //Used for 2 different buttons (not exactly a great way to do it)
    void ButtonTest()
    {
        if (gameObject.name != "PictureButton")
        {
            try
            {
                //Get user details from the opening screen, then send it to the server via network
                string userName = GameObject.Find("UserNameInput").GetComponent<Text>().text;
                tex = GameObject.Find("UserImage").GetComponent<RawImage>().texture;
                Profile userProfile = new Profile(Mathf.RoundToInt(Random.Range(1, Mathf.Pow(2, 32) - 1)), userName, tex);
                //GameObject.Find("NetworkManager").GetComponent<Networkingv2>().RegisterUser(userName, userProfile.userID);
                GameObject.Find("NetworkManager").GetComponent<Networkingv2>().SendMyDataMessage();
            }
            catch
            {
                Debug.Log("Name or Image not yet set");
            }
        }
        else
        {
            //If the take a picture button is pressed, the code saves the current texture in a variable, stops the camera
            //Then replaces the texture with the saved texture, thus taking a picture. This picture hasn't been saved anywhere
            cam = GameObject.Find("UserImage");
            tex = cam.GetComponent<RawImage>().texture;
            cam.GetComponent<DeviceCamera>().StopCamera();
            cam.GetComponent<RawImage>().texture = tex;

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Drive : MonoBehaviour {

    public float speed = 100.0f;
	
	// Update is called once per frame
	void Update () {
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);
	}
}

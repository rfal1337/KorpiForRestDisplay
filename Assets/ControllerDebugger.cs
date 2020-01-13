using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControllerDebugger : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Debug.Log(CrossPlatformInputManager.GetAxis("Vertical") * 20f);
	}
}

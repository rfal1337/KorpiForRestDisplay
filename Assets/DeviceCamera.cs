using UnityEngine;
using UnityEngine.UI;

//Used to replace a texture of a Raw Image to show what the camera sees
public class DeviceCamera : MonoBehaviour
{
    //Getting the cameras (unity assigns automaticly the phone camera to the mCamera)
    public WebCamTexture mCamera = null;
    public GameObject userImage;

    public bool useCamera = false;

    //Listing all the cameras within the devices (0 being back camera, 1 being the front camera)
    WebCamDevice[] devices;

    // Use this for initialization
    void Start()
    {
        if (useCamera)
        {
            //Getting the devices to add in the devices list
            devices = WebCamTexture.devices;
            userImage = gameObject;

            mCamera = new WebCamTexture();

            //Picking the front camera
            mCamera.deviceName = devices[1].name;

            //Setting the camera to display on the Raw Image, replacing it's texture
            userImage.GetComponent<RawImage>().texture = mCamera;
            mCamera.Play();
        }
    }

    //Used from a button to stop the camera
    public void StopCamera()
    {
        mCamera.Stop();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class DeviceCamera : MonoBehaviour
{
    public WebCamTexture mCamera = null;
    public GameObject userImage;
    WebCamDevice[] devices;

    // Use this for initialization
    void Start()
    {
        devices = WebCamTexture.devices;
        userImage = gameObject;

        mCamera = new WebCamTexture();
        mCamera.deviceName = devices[1].name;
        userImage.GetComponent<RawImage>().texture = mCamera;
        mCamera.Play();

    }

    public void StopCamera()
    {
        mCamera.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawIm;
    public VideoPlayer vidPlay;
    public AudioSource aSource;
    public bool play = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();

        if(play)
            StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        vidPlay.Prepare();
        WaitForSeconds waitfors = new WaitForSeconds(1);
        while (!vidPlay.isPrepared)
        {
            yield return waitfors;
            break;
        }

        rawIm.texture = vidPlay.texture;
        vidPlay.Play();
        aSource.Play();
    }
}

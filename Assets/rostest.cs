using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class rostest : MonoBehaviour {

    public string startTime;
    public string endTime;
    int presses = 0;



    public void TimerStart()
    {
        if (presses == 0)
        {
            startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Debug.Log(startTime);
            presses++;
        }
        else if(presses == 1)
        {
            endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Debug.Log(endTime);
            presses++;
            StartCoroutine(CallRos());
        }


    }

    IEnumerator CallRos()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", 15);
        form.AddField("starttime", startTime);
        form.AddField("endtime", endTime);
        form.AddField("simulationtime", 5);
        form.AddField("startROS", "111111");
        form.AddField("endROS", "777777");
        WWW www = new WWW("http://localhost/sqlconnect/ros.php", form);
        yield return www;
        Debug.Log(www.text);
    }
}
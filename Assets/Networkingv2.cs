using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Networkingv2 : MonoBehaviour
{

    public bool isAtStartup = true;

    NetworkClient myClient;
    public const short MyDataMsgID = 815;

    public bool isServer = false;
    public bool isClient = false;


    class MyMsgType
    {
        public static short ID = 815;
    }

    class MyDataMsg : MessageBase
    {
        public int userID;
        public string rosResults;

        public MyDataMsg(int userID, string rosResults)
        {
            this.userID = userID;
            this.rosResults = rosResults;
        }
    }


    void Update()
    {
        if (isAtStartup)
        {
            if (isServer)
            {
                // Now this is the SERVER
                SetupServer();
            }

            if (isClient)
            {
                // Now this is the CLIENT
                SetupClient();
            }

            if (isServer && isClient)
            {
                // Now this is a SERVER and a Local CLIENT too
                SetupServer();
                SetupLocalClient();
            }
        }
    }

    // Create a server and listen on a port
    public void SetupServer()
    {
        NetworkServer.Listen(4444);
        NetworkServer.RegisterHandler(MyMsgType.ID, OnRecievingData);
        isAtStartup = false;
        isServer = true;
        isClient = false;
    }

    // Create a client and connect to the server port
    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("192.168.1.250", 4444);
        isAtStartup = false;
        isClient = true;
        isServer = false;
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        isAtStartup = false;
    }


    // What the CLIENT should do when connected
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }

    // Call this with the CLIENT to send a message
    public void SendMyDataMessage()
    {
        var msg = new MyDataMsg();
        msg.position = new Vector3(0.0f, 0.0f, 0.0f);
        msg.angle = -21.74f;
        msg.message = "lets hope this comes through";

        myClient.Send(MyMsgType.ID, msg);
    }

    // What the SERVCER should do when getting a message
    public void OnRecievingData(NetworkMessage netMsg)
    {
        MyDataMsg myMsg = netMsg.ReadMessage<MyDataMsg>();

        // use the values from the message here
        Debug.Log("position: " + myMsg.position);
        Debug.Log("angle: " + myMsg.angle);
        Debug.Log("message: " + myMsg.message);
    }
}
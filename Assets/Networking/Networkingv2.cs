using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Networkingv2 : MonoBehaviour
{

    NetworkClient myClient;
    public const short MyDataMsgID = 815;

    public bool atStart = true;

    public bool isServer = false;
    public bool isClient = false;

    public MyDataMsg msgHolder;

    //Message ID
    class MyMsgType
    {
        public static short ID = 815;
    }

    //Network message data and contents
    public class MyDataMsg : MessageBase
    {
        public int userID = 0;
        public string rosResults = "";
        public string userName = "";

        public MyDataMsg() { }
        public MyDataMsg(int userID, string rosResults)
        {
            this.userID = userID;
            this.rosResults = rosResults;
        }

        public MyDataMsg(string userName, int userID)
        {
            this.userID = userID;
            this.userName = userName;
        }
    }

    void Update()
    {
        if (atStart)
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
        atStart = false;
    }

    // Create a client and connect to the server port
    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        atStart = false;
    }

    public void Connect(string ipAddress)
    {
        myClient.Connect(ipAddress, 4444);
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        atStart = false;
    }


    // What the CLIENT should do when connected
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }

    #region Server-Client communication

    // Call this with the CLIENT to send a message
    public void SendMyDataMessage()
    {
        var msg = new MyDataMsg();
        msg.userID = 1337;
        msg.rosResults = "068594";

        myClient.Send(MyMsgType.ID, msg);

    }

    //Method on creating a user and sending it to server
    public void RegisterUser(string name, int id)
    {
        var msg = new MyDataMsg();
        msg.userID = id;
        msg.userName = name;
        myClient.Send(MyMsgType.ID, msg);
    }

    //Method on creating a instance of ROS results and sending to server
    public void SendROSResults(int id, string ros)
    {
        var msg = new MyDataMsg(ros, id);
        myClient.Send(MyMsgType.ID, msg);
    }

    // What the SERVER should do when getting a message
    public void OnRecievingData(NetworkMessage netMsg)
    {
        MyDataMsg myMsg = netMsg.ReadMessage<MyDataMsg>();

        // use the values from the message here
        Debug.Log("userID: " + myMsg.userID);
        Debug.Log("Username: " + myMsg.userName);
        msgHolder = myMsg;
    }

    #endregion


    public MyDataMsg GetData()
    {
        return msgHolder;
    }

    void OnGUI()
    {
        if(isServer)
            GUI.TextArea(new Rect(-320, 173, 160, 35), "IP Address");

        if (isClient)
        {
            if (!myClient.isConnected)
            {
                if (GUI.Button(new Rect(20, 120, 180, 100), "Connect"))
                {
                    Connect(GameObject.Find("IPFieldText").GetComponent<Text>().text);
                }
            }
        }

        GUI.Box(new Rect(10, Screen.height - 50, 100, 50), Network.player.ipAddress);
    }
}
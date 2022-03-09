using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        //base.OnStartServer();
        Debug.Log("Server started!");
    }

    public override void OnStopServer()
    {
        //base.OnStopServer();
        Debug.Log("Server disconnected!");
    }

    [System.Obsolete]
    public override void OnClientConnect(NetworkConnection connection)
    {
        //base.OnClientConnect();
        Debug.Log("Client connected to server!");
    }

    [System.Obsolete]
    public override void OnClientDisconnect(NetworkConnection connection)
    {
        //base.OnClientDisconnect();
        Debug.Log("Client disconnected from server!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP.SocketIO3;
using BestHTTP.SocketIO3.Events;

public class SocketIOConnecter : MonoBehaviour
{
    [SerializeField] private string address = "";
    private SocketManager socketManager = null;
    // Start is called before the first frame update
    void Start()
    {
        SocketIO3Connect();
    }

    private void SocketIO3Connect()
    {
        SocketOptions options = new SocketOptions();
        options.AutoConnect = false;

        socketManager = new SocketManager(new System.Uri(address), options);
        socketManager.Open();

        socketManager.Socket.On<ConnectResponse>(SocketIOEventTypes.Connect, OnConnected);
        socketManager.Socket.On("connect", PlayerConnected);
    }

    private void OnConnected(ConnectResponse res)
    {
        Debug.Log("Connected! Socket.IO");
    }

    private void PlayerConnected()
    {
        Debug.Log("Player Connected!!");
    }

    private void Destory()
    {
        if (this.socketManager != null)
        {
            this.socketManager.Close();
            this.socketManager = null;
        }
    }
}

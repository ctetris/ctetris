using UnityEngine;
using System.Collections;

public class LAN : MonoBehaviour
{
    #region public member

    public static string gameTypeName = "BayYao_Lan";

    public bool useNat;
    [HideInInspector]
    public string remoteIP;
    [HideInInspector]
    public int remotePort;
    /// <summary>
    /// 监听端口
    /// </summary>
    [HideInInspector]
    public int listenPort = 25000;

    [HideInInspector]
    public string remoteGUID = "";

    [HideInInspector]
    public int connections = 10;

    #endregion


    #region public method
    public void StartServer()
    {
        Network.InitializeServer(connections, listenPort, useNat);
    }

    public void RegisterHost(string gameName, string comment)
    {
        MasterServer.RegisterHost(gameTypeName,gameName, comment);
    }

    public void CannelServer()
    {
        Network.Disconnect();
    }
    #endregion

    #region event

    void OnServerInitialized()
    {
        if (useNat)
        {
            Debug.Log("==> GUID is " + Network.player.guid + ". Use this on clients to connect with NAT punchthrough.");
            remoteGUID = Network.player.guid;
        }
        Debug.Log("==> Local IP/port is " + Network.player.ipAddress + "/" + Network.player.port + ". Use this on clients to connect directly.");
    }

    void OnConnectedToServer()
    {
        // Notify our objects that the level and the network is ready
        Debug.Log(" Notify our objects that the level and the network is ready");
        foreach (var go in FindObjectsOfType(typeof(GameObject)))
            ((GameObject)go).SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
    }

    void OnFailedToConnect(NetworkConnectionError error)
    {
        Debug.Log("Could not connect to server: " + error);
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        Debug.Log("Player " + " connected from " + player.ipAddress + ":" + player.port);
        //CIP = "Player " + " connected from " + player.ipAddress + ":" + player.port;
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
       //CIP = "Player " + " Disconnected from " + player.ipAddress + ":" + player.port;
    }


    #endregion


    private static LAN _Lan;

    public static LAN instance
    {
        get {

            if (_Lan == null)
            {
                GameObject lan = new GameObject("LAN");
                _Lan = lan.AddComponent<LAN>();
            }

            return LAN._Lan; 
        }
    }


}

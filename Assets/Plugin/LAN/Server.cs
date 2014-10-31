using UnityEngine;
using System.Collections;

public class Server : MonoBehaviour
{

    #region pulic member

    public string remoteIP;

    public int remotePort;

    public int listenPort = 25000;

    public bool useNat;

    #endregion

    #region private member

    string CIP;
    string remoteGUID = "";
    #endregion

    #region mono

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.2f), CIP);

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Space(10);
        //Debug.Log(Network.peerType);
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            useNat = GUILayout.Toggle(useNat, "Use NAT punchthrough");
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);

            GUILayout.BeginVertical();
            if (GUILayout.Button("Connect"))
            {
                if (useNat)
                {
                    if (!string.IsNullOrEmpty(remoteGUID))
                        Debug.LogWarning("Invalid GUID given, must be a valid one as reported by Network.player.guid or returned in a HostData struture from the master server");
                    else
                        Network.Connect(remoteGUID);
                }
                else
                {
                    Network.Connect(remoteIP, remotePort);
                }
            }
            if (GUILayout.Button("Start Server"))
            {
                Network.InitializeServer(32, listenPort, useNat);
                // Notify our objects that the level and the network is ready
                foreach (var go in FindObjectsOfType(typeof(GameObject)))
                    ((GameObject)go).SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
            }
            GUILayout.EndVertical();
            if (useNat)
            {
                remoteGUID = GUILayout.TextField(remoteGUID, GUILayout.MinWidth(145));
            }
            else
            {
                remoteIP = GUILayout.TextField(remoteIP, GUILayout.MinWidth(100));
                remotePort = int.Parse(GUILayout.TextField(remotePort.ToString()));
            }
        }
        else
        {
            if (useNat)
                GUILayout.Label("GUID: " + Network.player.guid + " - ");
            GUILayout.Label("Local IP/port: " + Network.player.ipAddress + "/" + Network.player.port);
            GUILayout.Label(" - External IP/port: " + Network.player.externalIP + "/" + Network.player.externalPort);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Disconnect"))
                Network.Disconnect(200);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

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

    #endregion

    void OnPlayerConnected(NetworkPlayer player)
    {
        Debug.Log("Player " + " connected from " + player.ipAddress + ":" + player.port);
        CIP = "Player " + " connected from " + player.ipAddress + ":" + player.port;
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        CIP = "Player " + " Disconnected from " + player.ipAddress + ":" + player.port;
    }

    #region pulic method

    #endregion

    #region private method

    #endregion
}

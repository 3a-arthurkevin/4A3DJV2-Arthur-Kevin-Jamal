using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LobbyNetworkManager : MonoBehaviour
{
    [SerializeField]
    private NetworkView m_networkView;

    private int m_prefixLevel = 0;

    [SerializeField]
    private bool m_buildServer;
    public bool BuildServer
    {
        get { return m_buildServer; }
        set { m_buildServer = value; }
    }

    [SerializeField]
    private string m_ip;
    public string Ip
    {
        get { return m_ip; }
        set { m_ip = value; }
    }


    [SerializeField]
    private int m_port;
    public int Port
    {
        get { return m_port; }
        set { m_port = value; }
    }
    public void setPort(string port)
    {
        try
        {
            m_port = System.Int32.Parse(port);
        }
        catch (System.Exception)
        {
            m_port = 9000;
        }
    }

    [SerializeField]
    private int m_maxPlayer = 2;
    public int MaxPlayer
    {
        get { return m_maxPlayer; }
        set { m_maxPlayer = value; }
    }

    private bool m_setup;
    public bool IsSetup
    {
        get { return m_setup; }
    }

    //Event on Network setup
    public LobbyDelegateDefinition.NetworkIsSetup networkIsSetup;

    //Event on new player connect
    public LobbyDelegateDefinition.NewPlayerConnected newPlayerConnected;

    /* ********************************** */

    void setupServer()
    {
        Network.InitializeSecurity();
        NetworkConnectionError err = Network.InitializeServer(m_maxPlayer, m_port, false);

        if (err != NetworkConnectionError.NoError)
            Debug.Log(err.ToString());
        else
            Debug.Log("Server start");
    }

    void setupClient()
    {
        NetworkConnectionError err = Network.Connect(m_ip, m_port);

        if (err != NetworkConnectionError.NoError)
            Debug.Log(err.ToString());
        else
            Debug.Log("Client connect");
    }

    public void setupNetwork()
    {
        if (m_buildServer)
            setupServer();
        else
            setupClient();

        networkIsSetup();

        m_setup = true;
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        if(m_setup)
        {
            if(Network.isServer)
            {
                if (NetworkManager.Players.Count < m_maxPlayer)
                {
                    m_networkView.RPC("addPlayer", RPCMode.AllBuffered, player);

                    if (NetworkManager.Players.Count == m_maxPlayer)
                    {
                        m_networkView.RPC("LoadGameLevel", RPCMode.AllBuffered, m_prefixLevel++);
                    }
                }
            }
        }
    }

    [RPC]
    void addPlayer(NetworkPlayer newPlayer)
    {
        NetworkManager.addPlayer(newPlayer);
        newPlayerConnected();
    }

    [RPC]
    void LoadGameLevel(int levelPrefix)
    {
        Network.SetSendingEnabled(0, false);
        Network.isMessageQueueRunning = false;

        Network.SetLevelPrefix(levelPrefix);

        Application.LoadLevel("Game");

        Network.isMessageQueueRunning = true;
        Network.SetSendingEnabled(0, true);
    }
}

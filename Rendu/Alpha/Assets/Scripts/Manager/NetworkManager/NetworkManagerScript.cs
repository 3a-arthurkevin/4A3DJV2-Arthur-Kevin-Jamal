using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManagerScript : MonoBehaviour
{
    public static NetworkManagerScript m_instance;

    [SerializeField]
    private NetworkView m_networkView;

    private string m_ip;
    public string Ip
    {
        get { return m_ip; }
        set { m_ip = value; }
    }

    private short m_port;
    public short Port
    {
        get { return m_port; }
        set { m_port = value; }
    }

    private bool m_buildServer;
    public bool BuildServer
    {
        get { return m_buildServer; }
        set { m_buildServer = value; }
    }

    private int m_maxPlayer;
    public int MaxPlayer
    {
        get { return m_maxPlayer; }
        set { m_maxPlayer = value; }
    }

    private List<NetworkPlayer> m_players;
    public List<NetworkPlayer> Players
    {
        get { return m_players; }
    }


    void Awake()
    {
        if(m_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            m_instance = this;

            m_players = new List<NetworkPlayer>();
        }
        else if(m_instance != this)
        {
            mergeInstance();
            Destroy(gameObject);
        }
    }

    void mergeInstance()
    {
        
    }

	void Start ()
    {
        if (Application.loadedLevelName == "Lobby")
        {
            if (m_buildServer)
                setupServer();
            else
                setupClient();
        }
	}
	
    void setupServer()
    {
        Network.InitializeSecurity();
        NetworkConnectionError err = Network.InitializeServer(m_maxPlayer, m_port, !Network.HavePublicAddress());

        if (err != NetworkConnectionError.NoError)
            Debug.LogError(err.ToString());
        else
            Debug.Log("Server start");
    }

    void setupClient()
    {
        NetworkConnectionError err = Network.Connect(m_ip, m_port);

        if (err != NetworkConnectionError.NoError)
            Debug.LogError(err.ToString());
        else
            Debug.LogError("Client connect");
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        if(m_players.Count < m_maxPlayer)
        {
            m_players.Add(player);

            if( m_players.Count == m_maxPlayer - 1)
            {
                Network.RemoveRPCsInGroup(0);
                Network.RemoveRPCsInGroup(1);
                m_networkView.RPC("RPCLoadLevel", RPCMode.AllBuffered, "Planification");
            }
        }
    }

    [RPC]
    void RPCLoadLevel(string name)
    {
        Network.SetSendingEnabled(0, false);

        Network.isMessageQueueRunning = false;
    }
}

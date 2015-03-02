using UnityEngine;
using System.Collections;

public class LobbyGameManager : MonoBehaviour
{
    [SerializeField]
    private LobbyNetworkManager m_networkManager;

    [SerializeField]
    private LobbyUIManager m_uiManager;

    public void newPlayer()
    {
        //New player connected;
        //Set player count to UIManage

        m_uiManager.setWaitPlayerCount(m_networkManager.MaxPlayer - NetworkManager.Players.Count);
    }

    void Start()
    {
        m_networkManager.newPlayerConnected = newPlayer;
        m_networkManager.networkIsSetup = m_uiManager.waitMode;
    }
}

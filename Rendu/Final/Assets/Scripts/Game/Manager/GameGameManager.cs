using UnityEngine;
using System.Collections;

public class GameGameManager : MonoBehaviour
{
    [SerializeField]
    private GameNetworkManager m_networkManager;

    [SerializeField]
    private GameUIManager m_uiManager;

    [SerializeField]
    private GamePlayerManager m_playerManager;


    public void commitPlayerAction()
    {
        Debug.Log("Commit player action");
    }

    public void launchSimulation()
    {
        Debug.Log("Launch simu");
    }

    void Start()
    {
        m_playerManager.m_getIdPlayer = m_networkManager.getIdPlayer;

        m_uiManager.m_commitPlayerAction = commitPlayerAction;
        m_uiManager.m_launchSimulation = launchSimulation;

        m_uiManager.m_pushAction = m_playerManager.pushAction;
        m_uiManager.m_removeAction = m_playerManager.removeAction;
    }
}

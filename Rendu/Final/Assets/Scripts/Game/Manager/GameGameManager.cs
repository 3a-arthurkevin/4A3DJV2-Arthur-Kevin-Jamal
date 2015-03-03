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

    void Start()
    {
        m_uiManager.m_pushAction = m_playerManager.pushAction;
        m_uiManager.m_removeAction = m_playerManager.removeAction;
    }
}

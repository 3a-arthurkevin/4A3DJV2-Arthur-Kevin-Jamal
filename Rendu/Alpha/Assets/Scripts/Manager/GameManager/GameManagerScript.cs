/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : GameManager, utiliser pour la persistance des données lors des chargement de scènes
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{
    /**
     * Instance persistante des données durant les chargements de scène
     */
    public static GameManagerScript m_instance;

    [SerializeField]
    private NetworkView m_networkView;

    [SerializeField]
    private UIManagerScript m_uiManager;

    [SerializeField]
    private PlayerManagerScript m_playerManager;

    [SerializeField]
    private NetworkManagerScript m_networkManager;

    private int m_levelPrefix;

    /**
     * Check Global instance is same instance of this
     */
    void Awake()
    {
        if (m_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            m_instance = this;
            m_levelPrefix = 0;
        }
        else if (m_instance != this)
        {
            mergeInstance();
            Destroy(gameObject);
        }
    }

    /**
     * Remplace les GameObject de la scène précédente par les versions de scène nouvellement chargé
     * (Ex : Camera de scene, Player, ...)
     */
    protected void mergeInstance()
    {
    }

    public void newPlayer(int playerId)
    {
        m_playerManager.addPlayer(playerId);
    }

    public void pushAction(PlayerAction action)
    {
        int playerId = m_networkManager.getPlayerId(Network.player);

        if (playerId >= 0)
        {
            m_playerManager.pushAction(playerId, action);
            m_uiManager.appendAction(action);
        }
        else
            Debug.Log("Player id invalid");

        m_uiManager.displayChooseAction(false);
    }

    public void removeAction(int index)
    {
        int playerId = m_networkManager.getPlayerId(Network.player);

        if (playerId != -1)
        {
            m_playerManager.removeAction(playerId, index);
            m_uiManager.RemoveAction(index);
        }
        else
            Debug.Log("Player id invalid");
    }

    public void commitPlayerAction()
    {
        int playerId = m_networkManager.getPlayerId(Network.player);

        if (playerId >= 0)
            m_playerManager.synchronisePlayerActionWithServer(playerId);

        else
            Debug.LogError("Player not found");
    }

    public void syncFinish(bool syncFailed)
    {
        if(syncFailed)
        {
            m_uiManager.resetPlayerAction();
            m_playerManager.resetPlayerAction(m_networkManager.getPlayerId(Network.player));
        }
        else
        {
            m_uiManager.playerHasCommit();
        }
    }

    public void startSimulation()
    {

    }

    public void allPlayerSync()
    {
        m_networkView.RPC("LoadLevel", RPCMode.AllBuffered, "Figthing", m_levelPrefix++);
    }

    [RPC]
    void LoadLevel(string levelName, int levelPrefix)
    {
        Network.SetSendingEnabled(0, false);
        Network.isMessageQueueRunning = false;

        Network.SetLevelPrefix(levelPrefix);

        Application.LoadLevel(levelName);

        Network.isMessageQueueRunning = true;
        Network.SetSendingEnabled(0, true);
    }

    public void playerDead(int player)
    {
        Debug.Log("Player : " + player + " are dead");
    }
}
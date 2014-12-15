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

    /**
     * Check Global instance is same instance of this
     */
    void Awake()
    {
        if (m_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            m_instance = this;
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
        Debug.LogError("Push action " + action);

        int playerId = m_networkManager.getPlayerId(Network.player);

        if (playerId >= 0)
        {
            m_playerManager.pushAction(playerId, action);
            m_uiManager.appendAction(action);
        }
        else
            Debug.LogError("Player id invalid");

        m_uiManager.displayChooseAction(false);
    }
}
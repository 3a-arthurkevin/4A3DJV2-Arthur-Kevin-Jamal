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

    void Start()
    {
    }

    [RPC]
    void tryAddAction(NetworkPlayer player, PlayerAction action)
    {
        if (Network.isServer)
        {
            
        }
        else
        {
            m_uiManager.appendAction(action);
            m_uiManager.displayChooseAction(false);
        }
    }

    public void pushAction(PlayerAction action)
    {
        m_networkView.RPC("tryAddAction", RPCMode.Server, Network.player, action);
    }
}
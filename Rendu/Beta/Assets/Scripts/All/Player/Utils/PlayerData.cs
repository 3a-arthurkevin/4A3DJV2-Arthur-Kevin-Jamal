/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : Description des informations d'un joueur
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    private int m_playerId;
    public int PlayerId
    {
        get { return m_playerId; }
        set { m_playerId = value; }
    }

    [SerializeField]
    private Transform m_transform;
    public Transform Transform
    {
        get { return m_transform; }
        set { m_transform = value; }
    }

    [SerializeField]
    private ActionsManager m_actionManager;
    public ActionsManager ActionManager
    {
        get { return m_actionManager; }
        set { m_actionManager = value; }
    }

    [SerializeField]
    private HealtManager m_healManager;

    private List<PlayerAction> m_playerAction;
    public List<PlayerAction> PlayerAction
    {
        get { return m_playerAction; }
    }

    private bool m_isSync;
    public bool IsSync
    {
        get { return m_isSync; }
        set { m_isSync = value; }
    }

    public PlayerData(int playerId, Transform transform = null, int health = 100, List<PlayerAction> playerAction = null)
    {
        m_playerId = playerId;
        m_transform = transform;
        m_isSync = false;

        if (playerAction == null)
            m_playerAction = new List<PlayerAction>();
        else
            m_playerAction = playerAction;

        //m_healManager.PlayerId = playerId;
        //m_healManager.CurLife = m_healManager.MaxLife;
    }
}

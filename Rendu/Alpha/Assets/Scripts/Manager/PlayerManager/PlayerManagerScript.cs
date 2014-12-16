/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Gestion des joueurs
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class PlayerManagerScript : MonoBehaviour
{
    public static PlayerManagerScript m_instance;

    [SerializeField]
    private PlayerData m_playerOne;

    [SerializeField]
    private PlayerData m_playerTwo;

    void Awake()
    {
        if(m_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            m_instance = this;
        }
        else if (m_instance != this)
        {
            mergeInstace();
            Destroy(gameObject);
        }
    }

    protected void mergeInstace()
    {
        m_instance.m_playerOne.Transform = m_playerOne.Transform;
        m_instance.m_playerTwo.Transform = m_playerTwo.Transform;
    }

    public void addPlayer(int playerId)
    {
        if (playerId == 0)
            m_playerOne = new PlayerData(playerId);

        else
            m_playerTwo = new PlayerData(playerId);
    }

    public void pushAction(int playerId, PlayerAction action)
    {
        PlayerData player = (playerId == m_playerOne.PlayerId) ? m_playerOne : m_playerTwo;

        if (player.PlayerAction.Count < Constants.MAXSIZEPLAYERACTION)
        {
            player.PlayerAction.Add(action);
        }
        else
            Debug.Log("Player " + playerId.ToString() + " has to much action");
    }

    public void removeAction(int playerId, int index)
    {
        PlayerData player = (playerId == m_playerOne.PlayerId) ? m_playerOne : m_playerTwo;

        if (player.PlayerAction.Count > 0 && index >= 0 && index < player.PlayerAction.Count)
        {
            for(int i = index; i < player.PlayerAction.Count - 1; ++i)
                player.PlayerAction[i] = player.PlayerAction[i + 1];

            player.PlayerAction.RemoveAt(player.PlayerAction.Count - 1);
        }
        else
            Debug.Log("Invalid Index");
    }
}

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
    private GameManagerScript m_gameManager;

    [SerializeField]
    private NetworkView m_networkView;

    [SerializeField]
    private PlayerData m_playerOne;

    [SerializeField]
    private PlayerData m_playerTwo;

    [SerializeField]
    private bool m_fightGame;

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

        if(Network.isServer)
            if (m_fightGame)
                m_instance.fightGame();
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

    public void synchronisePlayerActionWithServer(int playerId)
    {
        PlayerData player = playerId == m_playerOne.PlayerId ? m_playerOne : m_playerTwo;

        int[] playerAction = new int[player.PlayerAction.Count];

        for (int i = 0; i < player.PlayerAction.Count; ++i)
            playerAction[i] = (int)player.PlayerAction[i];

        m_networkView.RPC("sendPlayerAction", RPCMode.Server, Network.player, playerId, playerAction);
    }

    [RPC]
    private void sendPlayerAction(NetworkPlayer player, int playerId, int[] playerAction)
    {
        if(Network.isServer)
        {
            bool synValid = false;

            if (playerAction.Length > Constants.MAXSIZEPLAYERACTION)
                Debug.LogError("To many action into playerAction tab");

            else
            {
                PlayerData playerData = null;

                if (playerId == m_playerOne.PlayerId)
                    playerData = m_playerOne;
                
                else if (playerId == m_playerTwo.PlayerId)
                    playerData = m_playerTwo;

                if(playerData == null)
                    Debug.LogError("Unknow player");

                else
                {
                    foreach(int playerActionInteger in playerAction)
                        playerData.PlayerAction.Add((PlayerAction)playerActionInteger);

                    playerData.IsSync = true;

                    if (m_playerOne.IsSync && m_playerTwo.IsSync)
                        m_gameManager.allPlayerSync();

                    synValid = true;
                }
            }

            m_networkView.RPC("syncIsValid", player, synValid);
        }
    }

    [RPC]
    private void syncIsValid(bool syncValid)
    {
        if(Network.isClient)
            m_gameManager.syncFinish(!syncValid);
    }

    public void resetPlayerAction(int playerId)
    {
        PlayerData player = null;

        if (m_playerOne.PlayerId == playerId)
            player = m_playerOne;

        else if (m_playerTwo.PlayerId == playerId)
            player = m_playerTwo;

        if (player == null)
            Debug.LogError("Player not found");

        else
        {
            player.IsSync = false;
            player.PlayerAction.Clear();
        }        
    }

    private void fightGame()
    {
        Debug.LogError("Player1");

        foreach (PlayerAction pAction in m_playerOne.PlayerAction)
            Debug.LogError(pAction.ToString());

        Debug.LogError("Player2");

        foreach (PlayerAction pAction in m_playerTwo.PlayerAction)
            Debug.LogError(pAction.ToString());
    }
   
}

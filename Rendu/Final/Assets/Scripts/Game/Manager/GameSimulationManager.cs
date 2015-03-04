using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSimulationManager : MonoBehaviour
{
    [SerializeField]
    private NetworkView m_networkView;

    [SerializeField]
    private Animator m_player1Animatior;

    [SerializeField]
    private Animator m_player2Animatior;

    private List<PlayerAction> m_player1Actions;
    public List<PlayerAction> Player1Actions
    {
        get { return m_player1Actions; }
        set { m_player1Actions = value; }
    }

    private List<PlayerAction> m_player2Actions;
    public List<PlayerAction> Player2Actions
    {
        get { return m_player2Actions; }
        set { m_player2Actions = value; }
    }

    public GameDelegateDefinition.SyncActionWithServer m_syncCallBack;

    void Start()
    {
        m_player1Actions = new List<PlayerAction>();
        m_player2Actions = new List<PlayerAction>();
    }

    public void sendActionToServer(int idPlayer, PlayerAction[] actions)
    {
        if (idPlayer > 0)
            m_networkView.RPC("setActionForPlayer", RPCMode.Server, Network.player, idPlayer, actions);
        
        else
            validateSyncWithServer(false);
    }
    [RPC]
    public void setActionForPlayer(NetworkPlayer player, int idPlayer, PlayerAction[] actions)
    {
        if (Network.isServer)
        {
            bool success = false;

            if (idPlayer == 1)
            {
                m_player1Actions.Clear();

                foreach (PlayerAction action in actions)
                    m_player1Actions.Add(action);

                success = true;
            }
            else if (idPlayer == 2)
            {
                m_player2Actions.Clear();

                foreach (PlayerAction action in actions)
                    m_player2Actions.Add(action);

                success = true;
            }
            else
            {
                Debug.LogError("idPlayer Error");
            }

            m_networkView.RPC("validateSyncWithServer", player, success);
        }
    }

    [RPC]
    void validateSyncWithServer(bool success)
    {
        m_syncCallBack(success);
    }


    IEnumerator lunchActionPlayerOne(int index)
    {
        m_player1Animatior.SetInteger("IdAction", (int)m_player1Actions[index]);
        m_player1Animatior.SetInteger("IdAction", 0);
        yield return new WaitForSeconds(m_player1Animatior.GetCurrentAnimatorStateInfo(0).length);
    }

    IEnumerator lunchActionPlayerTwo(int index)
    {
        m_player2Animatior.SetInteger("IdAction", (int)m_player2Actions[index]);
        m_player2Animatior.SetInteger("IdAction", 0);
        yield return new WaitForSeconds(m_player2Animatior.GetCurrentAnimatorStateInfo(0).length);
    }
    void lunchPlayersActions()
    {
        int maxCount = (m_player1Actions.Count > m_player2Actions.Count ? 
            m_player1Actions.Count : m_player2Actions.Count);

        for (int i = 0; i < maxCount; ++i)
        {
            if (i < m_player1Actions.Count)
            {
                StartCoroutine(lunchActionPlayerOne(i));
            }

            if (i < m_player2Actions.Count)
            {
                StartCoroutine(lunchActionPlayerTwo(i));
            }
        }
    }
}
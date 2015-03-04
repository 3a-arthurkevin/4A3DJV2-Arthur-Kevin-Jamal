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

    private int m_commitCount;

    public GameDelegateDefinition.SyncActionWithServer m_syncCallBack;
    public GameDelegateDefinition.GetNetworkPlayer m_getNetworkPlayer;

    void Start()
    {
        m_player1Actions = new List<PlayerAction>();
        m_player2Actions = new List<PlayerAction>();

        m_commitCount = 0;
    }

    public void sendActionToServer(int idPlayer, PlayerAction[] actions)
    {
        if (idPlayer > 0)
        {
            m_networkView.RPC("setActionForPlayer", RPCMode.Server, Network.player, idPlayer, GameUtils.PlayerActionsArrayToString(actions));
        }
        else
            validateSyncWithServer(false);
    }
    [RPC]
    public void setActionForPlayer(NetworkPlayer sendValidation, int idPlayer, string actions)
    {
        PlayerAction[] listAction = GameUtils.PlayerActionsStringToArray(actions);

        Debug.LogError("Receive actions for player : " + idPlayer + ", actionsCount : " + listAction.Length);

        bool success = false;

        if (idPlayer == 1)
        {
            m_player1Actions.Clear();

            foreach (PlayerAction action in listAction)
                m_player1Actions.Add(action);

            success = true;
        }
        else if (idPlayer == 2)
        {
            m_player2Actions.Clear();

            foreach (PlayerAction action in listAction)
                m_player2Actions.Add(action);

            success = true;
        }
        else
        {
            Debug.LogError("idPlayer Error");
        }

        m_networkView.RPC("validateSyncWithServer", sendValidation, success);

        if (Network.isServer)
        {
            if (success)
                ++m_commitCount;

            if (m_commitCount == 2)
            {
                setupSimulation();
                m_commitCount = 0;
            }
        }
    }

    [RPC]
    void validateSyncWithServer(bool success)
    {
        if (Network.isServer)
        {
            //Server send sync all player
        }
        else //Commit client
            m_syncCallBack(success);
    }

    private void setupSimulation()
    {
        if(Network.isServer)
        {
            //Send RPC to client for sync PlayerAction array
            m_networkView.RPC("setActionForPlayer", m_getNetworkPlayer(1), Network.player, 1, GameUtils.PlayerActionsArrayToString(m_player1Actions.ToArray()));
            m_networkView.RPC("setActionForPlayer", m_getNetworkPlayer(1), Network.player, 2, GameUtils.PlayerActionsArrayToString(m_player2Actions.ToArray()));
            m_networkView.RPC("setActionForPlayer", m_getNetworkPlayer(2), Network.player, 1, GameUtils.PlayerActionsArrayToString(m_player1Actions.ToArray()));
            m_networkView.RPC("setActionForPlayer", m_getNetworkPlayer(2), Network.player, 2, GameUtils.PlayerActionsArrayToString(m_player2Actions.ToArray()));

            //Send RPC to all (Server + client) and start simulation
            m_networkView.RPC("startSimulation", RPCMode.All);
        }
    }

    [RPC]
    private void startSimulation()
    {
        launchPlayersActions();
    }


    IEnumerator launchActionPlayerOne()
    {
        for (int i = 0; i < m_player1Actions.Count; ++i)
        {
            m_player1Animatior.SetInteger("IdAction", (int)m_player1Actions[i]);
            m_player1Animatior.SetInteger("IdAction", 0);
            yield return new WaitForSeconds(m_player1Animatior.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    IEnumerator launchActionPlayerTwo()
    {
        for (int i = 0; i < m_player2Actions.Count; ++i)
        {
            m_player2Animatior.SetInteger("IdAction", (int)m_player2Actions[i]);
            m_player2Animatior.SetInteger("IdAction", 0);
            yield return new WaitForSeconds(m_player2Animatior.GetCurrentAnimatorStateInfo(0).length);
        }
    }
    void launchPlayersActions()
    {
        StartCoroutine(launchActionPlayerOne());
        StartCoroutine(launchActionPlayerTwo());
    }
}
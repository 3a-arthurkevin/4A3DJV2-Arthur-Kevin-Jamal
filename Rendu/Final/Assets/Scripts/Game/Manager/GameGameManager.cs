using UnityEngine;
using System.Collections;

public class GameGameManager : CustomActionScript
{
    [SerializeField]
    private GameNetworkManager m_networkManager;

    [SerializeField]
    private GameUIManager m_uiManager;

    [SerializeField]
    private GamePlayerManager m_playerManager;

    [SerializeField]
    private GameSimulationManager m_simulationManager;


    public void commitPlayerAction()
    {
        m_simulationManager.sendActionToServer(m_networkManager.getIdPlayer(Network.player), m_playerManager.PlayerActions.ToArray());
    }

    public void launchSimulation()
    {
        Debug.Log("Launch simu");
    }

    override public void Start()
    {
        base.Start();

        m_playerManager.m_getIdPlayer = m_networkManager.getIdPlayer;

        m_uiManager.m_commitPlayerAction = commitPlayerAction;
        m_uiManager.m_launchSimulation = launchSimulation;

        m_uiManager.m_pushAction = m_playerManager.pushAction;
        m_uiManager.m_removeAction = m_playerManager.removeAction;

        m_simulationManager.m_syncCallBack = m_uiManager.commitSuccess;
        m_simulationManager.m_getNetworkPlayer = m_networkManager.getNetworkPlayer;
    }

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {

        yield return null;
    }
}

using UnityEngine;
using System.Collections;

public class StartSimulationAction : CustomActionScript
{
    [SerializeField]
    private GameManagerScript m_gameManager;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_gameManager.startSimulation();

        return null;
    }
}

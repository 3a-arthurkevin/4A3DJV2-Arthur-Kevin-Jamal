using UnityEngine;
using System.Collections;

public class LobbySetupNetworkAction : CustomActionScript
{
    [SerializeField]
    private LobbyNetworkManager m_networkManager;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_networkManager.setupNetwork();

        yield return null;
    }
}

using UnityEngine;
using System.Collections;

public class NetworkSetupAction : CustomActionScript
{
    [SerializeField]
    private NetworkManagerScript m_networkManager;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_networkManager.setupNetwork();
        Application.LoadLevel("Planification");
        yield return null;
    }
}

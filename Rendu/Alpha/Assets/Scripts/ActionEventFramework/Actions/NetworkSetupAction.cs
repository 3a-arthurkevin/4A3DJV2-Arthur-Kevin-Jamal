using UnityEngine;
using System.Collections;

public class NetworkSetupAction : CustomActionScript
{
    [SerializeField]
    private NetworkManagerScript m_networkManager;

    [SerializeField]
    private GameObject m_form;

    [SerializeField]
    private GameObject m_wait;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_networkManager.setupNetwork();
        
        m_form.SetActive(false);
        m_wait.SetActive(true);

        yield return null;
    }
}

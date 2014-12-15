using UnityEngine;
using System.Collections;

public class ApplyHighKickDamageAction : CustomActionScript
{
    [SerializeField]
    private MonoBehaviour m_highKickDamageScript;

    [SerializeField]
    private bool m_active;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_highKickDamageScript.enabled = m_active;

        yield return null;
    }
}

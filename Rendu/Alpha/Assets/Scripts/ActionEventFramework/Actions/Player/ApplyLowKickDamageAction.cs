using UnityEngine;
using System.Collections;

public class ApplyLowKickDamageAction : CustomActionScript
{
    [SerializeField]
    private MonoBehaviour m_lowKickDamageScript;

    [SerializeField]
    private bool m_active;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_lowKickDamageScript.enabled = m_active;

        yield return null;
    }
}

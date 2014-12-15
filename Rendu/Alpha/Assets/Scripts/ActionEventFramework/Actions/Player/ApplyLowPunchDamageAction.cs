using UnityEngine;
using System.Collections;

public class ApplyLowPunchDamageAction : CustomActionScript
{
    [SerializeField]
    private MonoBehaviour m_lowPunchDamageScript;

    [SerializeField]
    private bool m_active;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_lowPunchDamageScript.enabled = m_active;

        yield return null;
    }
}

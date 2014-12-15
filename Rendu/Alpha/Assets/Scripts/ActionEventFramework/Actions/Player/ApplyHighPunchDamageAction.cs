using UnityEngine;
using System.Collections;

public class ApplyHighPunchDamageAction : CustomActionScript 
{
    [SerializeField]
    private MonoBehaviour m_highPunchDamageScript;

    [SerializeField]
    private bool m_active;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_highPunchDamageScript.enabled = m_active;

        yield return null;
    }
}

using UnityEngine;
using System.Collections;

public class EnableScriptAction : CustomActionScript
{
    [SerializeField]
    private MonoBehaviour m_script;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_script.enabled = true;

        yield return null;
    }
}

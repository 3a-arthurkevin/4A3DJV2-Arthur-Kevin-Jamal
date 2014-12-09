using UnityEngine;
using System.Collections;

public class EnableGameObjectAction : CustomActionScript
{
    [SerializeField]
    private GameObject m_gameObject;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_gameObject.SetActive(true);

        yield return null;
    }
}

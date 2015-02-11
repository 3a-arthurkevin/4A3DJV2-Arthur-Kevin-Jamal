using UnityEngine;
using System.Collections;

public class CommitPlayerAction : CustomActionScript
{
    [SerializeField]
    private GameManagerScript m_gameManager;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_gameManager.commitPlayerAction();

        yield return null;
    }
}

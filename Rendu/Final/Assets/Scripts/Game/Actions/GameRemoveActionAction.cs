using UnityEngine;
using System.Collections;

public class GameRemoveActionAction : CustomActionScript
{
    [SerializeField]
    private GameUIManager m_uiManager;

    [SerializeField]
    private int m_index;

    public void OnClick()
    {
        m_uiManager.wantToDeleteAction(m_index);
    }

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        throw new System.NotImplementedException();
    }
}

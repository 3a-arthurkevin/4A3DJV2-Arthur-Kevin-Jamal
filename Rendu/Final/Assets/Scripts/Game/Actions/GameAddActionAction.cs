using UnityEngine;
using System.Collections;

public class GameAddActionAction : CustomActionScript
{
    [SerializeField]
    private GameUIManager m_uiManager;

    [SerializeField]
    private PlayerAction m_action;

    public void OnClick()
    {
        m_uiManager.wantToAPushAction(m_action);
    }

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        throw new System.NotImplementedException();
    }
}

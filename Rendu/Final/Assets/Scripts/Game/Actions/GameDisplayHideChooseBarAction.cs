using UnityEngine;
using System.Collections;

public class GameDisplayHideChooseBarAction : CustomActionScript
{

    [SerializeField]
    private GameUIManager m_uiManager;

    [SerializeField]
    private GameObject m_showButton;

    [SerializeField]
    private bool m_showChooseBar;

    public void OnClick()
    {
        if(m_showChooseBar)
        {
            m_uiManager.displayChoose();
        }
        else
        {
            m_uiManager.hideChoose();
        }

        m_showButton.SetActive(true);
        gameObject.SetActive(false);
    }

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        throw new System.NotImplementedException();
    }
}

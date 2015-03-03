using UnityEngine;
using System.Collections;

public class GameAddActionAction : MonoBehaviour
{
    [SerializeField]
    private GameUIManager m_uiManager;

    [SerializeField]
    private PlayerAction m_action;

    public void OnClick()
    {
        m_uiManager.wantToAPushAction(m_action);
    }
}

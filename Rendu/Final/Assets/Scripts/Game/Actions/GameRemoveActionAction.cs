using UnityEngine;
using System.Collections;

public class GameRemoveActionAction : MonoBehaviour
{
    [SerializeField]
    private GameUIManager m_uiManager;

    [SerializeField]
    private int m_index;

    public void OnClick()
    {
        m_uiManager.wantToDeleteAction(m_index);
    }
}

using UnityEngine;
using System.Collections;

public class AddActionScript : MonoBehaviour
{
    [SerializeField]
    private GameManagerScript m_manager;

    [SerializeField]
    private PlayerAction m_action;

    public void addAction()
    {
        m_manager.pushAction(m_action);
    }
}

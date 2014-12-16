using UnityEngine;
using System.Collections;

public class HealtManager : MonoBehaviour
{
    [SerializeField]
    private UIManagerScript m_uiManager;

    [SerializeField]
    private GameManagerScript m_gameManager;

    [SerializeField]
    private int m_playerId;
    public int PlayerId
    {
        get { return m_playerId; }
        set { m_playerId = value; }
    }

    [SerializeField]
    private int m_maxLife;
    public int MaxLife
    {
        get { return m_maxLife; }
        set { m_maxLife = value; }
    }

    [SerializeField]
    private int m_curLife;
    public int CurLife
    {
        get { return m_curLife; }
        set
        {
            m_curLife = Mathf.Clamp(value, 0, 100);

            if (m_curLife <= 0)
                m_gameManager.playerDead(m_playerId);
        }
    }
}

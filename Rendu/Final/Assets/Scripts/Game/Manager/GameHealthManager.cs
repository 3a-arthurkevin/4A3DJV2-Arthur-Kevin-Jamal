using UnityEngine;
using System.Collections;

public class GameHealthManager : CustomEventScript
{
    [SerializeField]
    private int m_playerId;

    public int PlayerId
    {
        get { return m_playerId; }
        set { m_playerId = value; }
    }

    [SerializeField]
    private int m_maxLife;

    [SerializeField]
    private int m_curLife;

    public GameDelegateDefinition.haveTakeDamage m_haveTakeDamage;

    public void takeDamage(int value)
    {
        m_curLife = Mathf.Clamp(m_curLife - value, 0, m_maxLife);

        m_haveTakeDamage(m_playerId, value);

        if (m_curLife == 0)
            death();
    }

    void death()
    {
        throwEvent(this, gameObject);
    }
}

using UnityEngine;
using System.Collections;

public class PlayerManagerScript : MonoBehaviour
{
    public static PlayerManagerScript m_instance;

    [SerializeField]
    private PlayerData m_playerOne;

    [SerializeField]
    private PlayerData m_playerTwo;

    void Awake()
    {
        if(m_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            m_instance = this;
        }
        else if (m_instance != this)
        {
            mergeInstace();
            Destroy(gameObject);
        }
    }

    protected void mergeInstace()
    {
        m_instance.m_playerOne.Transform = m_playerOne.Transform;
        m_instance.m_playerTwo.Transform = m_playerTwo.Transform;
    }
}

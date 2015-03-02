using UnityEngine;
using System.Collections;

public class DontDestroyRootManagerScript : MonoBehaviour
{
    public static DontDestroyRootManagerScript m_instance;

    void Awake()
    {
        if(m_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            m_instance = this;
        }
        else if(m_instance != this)
        {
            Destroy(gameObject);
        }
    }
}

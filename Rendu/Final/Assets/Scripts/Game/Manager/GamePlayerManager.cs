using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerManager : MonoBehaviour
{
    private List<PlayerAction> m_playerActions;

    void Start()
    {
        m_playerActions = new List<PlayerAction>();
    }

    public bool pushAction(PlayerAction action)
    {
        if(m_playerActions.Count < Constants.MAXSIZEPLAYERACTION)
        {
            m_playerActions.Add(action);
            return true;
        }

        return false;
    }

    public bool removeAction(int index)
    {
        if(index >= 0 && index < m_playerActions.Count)
        {
            int playerActionCount = m_playerActions.Count;

            for (int i = index; i < playerActionCount - 1; ++i)
                m_playerActions[i] = m_playerActions[i + 1];

            m_playerActions.RemoveAt(playerActionCount - 1);

            return true;
        }

        return false;
    }
}

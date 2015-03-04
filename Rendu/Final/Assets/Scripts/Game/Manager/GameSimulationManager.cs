using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSimulationManager : MonoBehaviour
{
    private List<PlayerAction> m_player1Actions;
    public List<PlayerAction> Player1Actions
    {
        get { return m_player1Actions; }
        set { m_player1Actions = value; }
    }

    private List<PlayerAction> m_player2Action;
    public List<PlayerAction> Player2Action
    {
        get { return m_player2Action; }
        set { m_player2Action = value; }
    }

    void Start()
    {
        m_player1Actions = new List<PlayerAction>();
        m_player2Action = new List<PlayerAction>();
    }


}
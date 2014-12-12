/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : GameManager, utiliser pour la persistance des données lors des chargement de scènes
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum PlayerAction
{
    Move,
    Jump,
    UpperPunch,
    LowerPunch,
    UpperKick,
    LowerKick
}

public class GameManagerScript : MonoBehaviour
{
    /**
     * Instance persistante des données durant les chargements de scène
     */
    public static GameManagerScript m_gameManager;
    
    /* Tableau d'action choisit par le joueur */
    protected static List<PlayerAction> m_playerAction;

    public SlotActionContainer m_slotsAction;


    /**
     * Check Global instance is same instance of this
     */
    void Awake()
    {
        if(m_gameManager == null)
        {
            DontDestroyOnLoad(gameObject);

            m_playerAction = new List<PlayerAction>();
            m_gameManager = this;
        }
        else if(m_gameManager != this)
        {
            MergeGameManagerInstance();
            Destroy(gameObject);
        }
    }

    /**
     * Remplace les GameObject de la scène précédente par les versions de scène nouvellement chargé
     * (Ex : Camera de scene, Player, ...)
     */
    void MergeGameManagerInstance()
    {
        m_gameManager.m_slotsAction = m_slotsAction;
    }

    bool addActionIsPossible()
    {
        return m_playerAction.Count < Constants.MAXSIZEPLAYERACTION;
    }

    void addAction(PlayerAction action)
    {
        if(addActionIsPossible())
            m_playerAction.Add(action);
    }

    public void addMoveAction()
    {
        addAction(PlayerAction.Move);
    }

    public void addJumpAction()
    {
        addAction(PlayerAction.Jump);
    }

    public void addUpperPunchAction()
    {
        addAction(PlayerAction.UpperPunch);
    }

    public void addLowerPunch()
    {
        addAction(PlayerAction.LowerPunch);
    }

    public void addUpperKick()
    {
        addAction(PlayerAction.UpperKick);
    }

    public void addLowerKick()
    {
        addAction(PlayerAction.LowerKick);
    }
}
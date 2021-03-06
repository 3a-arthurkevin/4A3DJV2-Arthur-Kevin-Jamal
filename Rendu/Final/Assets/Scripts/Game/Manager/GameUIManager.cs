﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private Slider m_healthPlayer1;

    [SerializeField]
    private Slider m_healthPlayer2;

    /**
     * Set sprite into ispector with this order
     * 
     * MoveForward
     * MoveBackWard
     * Jump
     * LowPunch
     * HighPunch
     * LowKick
     * HighKick
     * Guard
     */
    [SerializeField]
    private List<Sprite> m_sprites;

    [SerializeField]
    private GameObject m_chooseAction;

    [SerializeField]
    private List<Image> m_playerActionsImages;

    [SerializeField]
    private List<Button> m_playerActionsButtons;

    [SerializeField]
    private List<Button> m_buttonLockAfterCommit;

    [SerializeField]
    private GameObject m_waitCommitObject;

    [SerializeField]
    private GameObject m_errorCommitObject;

    [SerializeField]
    private GameObject m_showChooseBarButton;

    [SerializeField]
    private GameObject m_hideChooseBarButton;

    [SerializeField]
    private GameObject m_winPanel;

    [SerializeField]
    private Text m_playerIdWinText;


    private int m_currentActionNumber;

    //Delegate can addAction event
    public GameDelegateDefinition.PushAction m_pushAction;
    public GameDelegateDefinition.RemoveAction m_removeAction;
    public GameDelegateDefinition.CommitPlayerAction m_commitPlayerAction;
    public GameDelegateDefinition.LaunchSimulation m_launchSimulation;

    void Start()
    {
        m_currentActionNumber = 0;
    }


    void setLifeForPlayer(int player, int newLife)
    {
        if (player == 1)
        {
            m_healthPlayer1.value = newLife;
        }
        else
        {
            m_healthPlayer2.value = newLife;
        }
    }

    Sprite getSpriteByAction(PlayerAction action)
    {
        Sprite actionSprite = null;

        switch(action)
        {
            case PlayerAction.MoveForward:
                actionSprite = m_sprites[0];
                break;

            case PlayerAction.MoveBackWard:
                actionSprite = m_sprites[1];
                break;

            case PlayerAction.Jump:
                actionSprite = m_sprites[2];
                break;

            case PlayerAction.LowPunch:
                actionSprite = m_sprites[3];
                break;

            case PlayerAction.HighPunch:
                actionSprite = m_sprites[4];
                break;

            case PlayerAction.LowKick:
                actionSprite = m_sprites[5];
                break;

            case PlayerAction.HighKick:
                actionSprite = m_sprites[6];
                break;

            case PlayerAction.Guard:
                actionSprite = m_sprites[7];
                break;
            
            default:
                Debug.Log("Unknow action");
                break;
        }

        return actionSprite;
    }

    public void wantToDeleteAction(int index)
    {
        if (m_removeAction(index))
        {
            for (int i = index; i < m_currentActionNumber - 1; ++i)
                m_playerActionsImages[i].sprite = m_playerActionsImages[i + 1].sprite;

            --m_currentActionNumber;
            m_playerActionsImages[m_currentActionNumber].enabled = false;
            m_playerActionsButtons[m_currentActionNumber].enabled = false;
        }
        else
        {
            Debug.LogError("Out of bounds");
        }
    }

    public void wantToAPushAction(PlayerAction action)
    {
        if (m_pushAction(action))
        {
            Sprite sprite = getSpriteByAction(action);
            
            m_playerActionsImages[m_currentActionNumber].sprite = sprite;
            m_playerActionsImages[m_currentActionNumber].enabled = true;
            m_playerActionsButtons[m_currentActionNumber].enabled = true;
            
            ++m_currentActionNumber;
        }
    }

    public void displayChoose()
    {
        m_chooseAction.SetActive(true);
        m_hideChooseBarButton.SetActive(true);
        m_showChooseBarButton.SetActive(false);
    }

    public void hideChoose()
    {
        m_chooseAction.SetActive(false);
        m_hideChooseBarButton.SetActive(false);
        m_showChooseBarButton.SetActive(true);
    }

    public void commitPlayerAction()
    {
        m_commitPlayerAction();
    }

    public void commitSuccess(bool success)
    {
        if (success)
        {
            foreach (Button button in m_buttonLockAfterCommit)
                button.interactable = false;

            m_waitCommitObject.SetActive(true);
            hideChoose();
        }
        else
        {
            m_errorCommitObject.SetActive(true);
        }
    }
    public void launchSimulation()
    {
        m_launchSimulation();
    }

    public void removeLife(int playerId, int value)
    {
        if(playerId == 1)
        {
            m_healthPlayer1.value = Mathf.Clamp(m_healthPlayer1.value - value, 0, 100);
        }
        else if(playerId == 2)
        {
            m_healthPlayer2.value = Mathf.Clamp(m_healthPlayer2.value - value, 0, 100);
        }
    }

    public void playerWin(int playerId)
    {
        m_winPanel.SetActive(true);
        m_playerIdWinText.text = playerId.ToString();

        foreach (Button button in m_buttonLockAfterCommit)
            button.interactable = false;
    }
}

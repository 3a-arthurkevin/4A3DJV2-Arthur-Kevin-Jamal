/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Gestion de l'IHM
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript m_instance;

    [SerializeField]
    private GameObject m_ui;

    [SerializeField]
    private Image[] m_playerActionsImages;

    [SerializeField]
    private Sprite m_errorSprite;

    [SerializeField]
    private Sprite m_moveForwardSprite;

    [SerializeField]
    private Sprite m_moveBackwardSprite;

    [SerializeField]
    private Sprite m_jumpSprite;

    [SerializeField]
    private Sprite m_lowPunchSprite;

    [SerializeField]
    private Sprite m_highPunchSprite;

    [SerializeField]
    private Sprite m_lowKickSprite;

    [SerializeField]
    private Sprite m_highKickSprite;

    [SerializeField]
    private Sprite m_guardSprite;

    [SerializeField]
    private GameObject m_playerChooseAction;

    [SerializeField]
    private Slider[] m_healtBar;


    void Awake()
    {
        if(m_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            m_instance = this;
        }
        else if(m_instance != this)
        {
            mergeInstance();
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (Network.isServer)
            m_ui.SetActive(false);
    }

    protected void mergeInstance()
    {
    }

    private int getSlotEmpty()
    {
        for(int i = 0; i < m_playerActionsImages.Length; ++i)
            if (!m_playerActionsImages[i].enabled)
                return i;

        return -1;
    }

    public void appendAction(PlayerAction action)
    {
        int emptySlot = getSlotEmpty();

        if(emptySlot == -1 )
            Debug.Log("Aucun slot vide");

        else
        {
            Sprite sprite;

            switch(action)
            {
                case PlayerAction.MoveForward:
                    sprite = m_moveForwardSprite;
                    break;

                case PlayerAction.MoveBackWard:
                    sprite = m_moveBackwardSprite;
                    break;

                case PlayerAction.Jump:
                    sprite = m_jumpSprite;
                    break;

                case PlayerAction.HighPunch:
                    sprite = m_highPunchSprite;
                    break;
                
                case PlayerAction.LowPunch:
                    sprite = m_lowPunchSprite;
                    break;

                case PlayerAction.HighKick:
                    sprite = m_highKickSprite;
                    break;

                case PlayerAction.LowKick:
                    sprite = m_lowKickSprite;
                    break;

                case PlayerAction.Guard:
                    sprite = m_lowKickSprite;
                    break;

                default:
                    sprite = m_errorSprite;
                    break;
            }

            m_playerActionsImages[emptySlot].sprite = sprite;
        }
    }

    public void RemoveAction(int slot)
    {
        if (slot < 0 || slot > Constants.MAXSIZEPLAYERACTION)
            Debug.Log("Remove en dehors du tableau");
        else
            m_playerActionsImages[slot].enabled = false;
    }

    void setHealt(int player, int value)
    {
        if(player >= 0 && player <= 1)
        {
            m_healtBar[player].value = (float)Mathf.Clamp(value, 0, 100);
        }
    }

    public void displayChooseAction(bool display)
    {
        m_playerChooseAction.SetActive(display);
    }
}

using UnityEngine;
using System.Collections;

public class ActionsManager : MonoBehaviour 
{
    [SerializeField]
    private WalkForwardScript m_walkForwardScript;

    [SerializeField]
    private WalkBackwardScript m_walkBackWardScript;

    [SerializeField]
    private JumpScript m_jumpScript;

    [SerializeField]
    private GuardScript m_guardScript;

    [SerializeField]
    private TakeDamageScript m_takeDamageScript;

    [SerializeField]
    private HighPunchScript m_highPunchScript;

    [SerializeField]
    private LowPunchScript m_lowPunchScript;

    [SerializeField]
    private HighKickScript m_highKickScript;

    [SerializeField]
    private LowKickScript m_lowKickScript;

    public void lunchAction(PlayerAction action)
    {
        switch (action)
        { 
            case PlayerAction.MoveForward:
                m_walkForwardScript.enabled = true;
                break;

            case PlayerAction.MoveBackWard:
                m_walkBackWardScript.enabled = true;
                break;

            case PlayerAction.Jump:
                m_jumpScript.enabled = true;
                break;

            case PlayerAction.Guard:
                m_guardScript.enabled = true;
                break;

            case PlayerAction.TakeDamage:
                m_takeDamageScript.enabled = true;
                break;

            case PlayerAction.HighPunch:
                m_highPunchScript.enabled = true;
                break;

            case PlayerAction.LowPunch:
                m_lowPunchScript.enabled = true;
                break;

            case PlayerAction.HighKick:
                m_highKickScript.enabled = true;
                break;

            case PlayerAction.LowKick:
                m_lowKickScript.enabled = true;
                break;

            default:
                /*Problem with the parameter ?*/
                break;

        }
    }
}

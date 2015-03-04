using UnityEngine;
using System.Collections;

public class PlayerAnimationsManager : MonoBehaviour 
{
    [SerializeField]
    private AnimationClip m_noMove;
    [SerializeField]
    private AnimationClip m_Guard;
    [SerializeField]
    private AnimationClip m_walkForward;
    [SerializeField]
    private AnimationClip m_walkBackward;
    [SerializeField]
    private AnimationClip m_lowPunch;
    [SerializeField]
    private AnimationClip m_highPunch;
    [SerializeField]
    private AnimationClip m_highKick;
    [SerializeField]
    private AnimationClip m_lowKick;
    [SerializeField]
    private AnimationClip m_takeDamage;


    public float getAnimationLenght(PlayerAction action)
    {
        float lenght = 0.0f;

        switch (action)
        {
            case PlayerAction.MoveForward:
                return m_walkForward.length;

            case PlayerAction.MoveBackWard:
                return m_walkBackward.length;

            case PlayerAction.LowPunch:
                return m_lowPunch.length;

            case PlayerAction.HighPunch:
                return m_highPunch.length;

            case PlayerAction.LowKick:
                return m_lowKick.length;

            case PlayerAction.HighKick:
                return m_highKick.length;

            case PlayerAction.Guard:
                return m_Guard.length;

            default:
                Debug.Log("Unknow action");
                break;
        }

        return lenght;
    }
}

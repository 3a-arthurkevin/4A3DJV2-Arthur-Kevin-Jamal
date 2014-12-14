/**
 * @Author : Kevin WATHTHUHEWA
 * @Date : 13/12/2014
 * @Desc : Script Lancant une animation du joueur selon son action
 * @LastModifier : Kevin WATHTHUHEWA
 */

using UnityEngine;
using System.Collections;

public class CharacterAnimationsScript : MonoBehaviour {

    [SerializeField]
    private Animator m_playerAnimator;

    /*
     *      \\ Player Animation ActionId Value //
     * 1    WalkForward
     * 2    WalkBackward
     * 3    Guard
     * 4    Jump
     * 5    HighPunch
     * 6    LowPunch
     * 7    HighKick
     * 8    LowKick
     * 9    TakeDamage
     */

    public void lunchAction(int value)
    {
        m_playerAnimator.SetInteger("IdAction", value);
    }
}

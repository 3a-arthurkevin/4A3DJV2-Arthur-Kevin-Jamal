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
     * 0    None
     * 1    WalkForward
     * 2    WalkBackward
     * 3    Jump
     * 4    Guard
     * 5    HighPunch
     * 6    LowPunch
     * 7    HighKick
     * 8    LowKick
     * 9    TakeDamage
     */

    public void LunchAction(int value)
    {
        //Changement du paramètre IdAction pour lancer l'animation demandée selon le paramètre
        m_playerAnimator.SetInteger("ActionId", value);
    }
}

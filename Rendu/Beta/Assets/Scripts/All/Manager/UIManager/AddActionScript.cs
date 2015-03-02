/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : Fonction ajoutant une action à la liste courante des actions du joueur
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class AddActionScript : MonoBehaviour
{
    [SerializeField]
    private GameManagerScript m_manager;

    [SerializeField]
    private PlayerAction m_action;

    public void addAction()
    {
        m_manager.pushAction(m_action);
    }
}

/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : Fonction appeler par un bouton situer dans la barre des actions choisit par le joueur pour qu'elle soit supprimé
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class RemoveActionScript : MonoBehaviour
{
    [SerializeField]
    private GameManagerScript m_gameManager;

    [SerializeField]
    private int m_index;

    public void OnClick()
    {
        m_gameManager.removeAction(m_index);
    }
}

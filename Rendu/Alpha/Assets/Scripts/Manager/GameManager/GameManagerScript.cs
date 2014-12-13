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
    
    /**
     * Check Global instance is same instance of this
     */
    void Awake()
    {
        if(m_gameManager == null)
        {
            DontDestroyOnLoad(gameObject);
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
    }
}
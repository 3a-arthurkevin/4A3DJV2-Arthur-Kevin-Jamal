/**
 * @Author : Arthur TORRENTE
 * @Date : 10/12/2014
 * @Desc : Enumération des actions que peut effectuer le joueur
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public enum PlayerAction
{
    None,           //0
    MoveForward,    //1
    MoveBackWard,   //2
    Jump,           //3
    Guard,          //4
    HighPunch,      //5
    LowPunch,       //6
    HighKick,       //7
    LowKick,        //8
    TakeDamage      //9
}

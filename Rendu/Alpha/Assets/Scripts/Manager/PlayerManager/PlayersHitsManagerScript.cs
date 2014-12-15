/**
* @Author : Kevin WATHTHUHEWA
* @Date : 14/12/2014
* @Desc : Script gérant la possibilité de recevoir un coup
* @LastModifier : Kevin WATHTHUHEWA
*/

using UnityEngine;
using System.Collections;

public class PlayersHitsManagerScript : CustomActionScript 
{
    [SerializeField]
    private Collider m_playerOneCollider;

    [SerializeField]
    private Collider m_playerTwoCollider;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {


        yield return null;
    }
}

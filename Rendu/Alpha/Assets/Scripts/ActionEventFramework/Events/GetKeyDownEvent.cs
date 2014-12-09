/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Évènement d'appuis sur une touche
 */

using UnityEngine;
using System.Collections;

public class GetKeyDownEvent : CustomEventScript
{
    public KeyCode m_keyCode;

    void Update()
    {
        if (Input.GetKeyDown(m_keyCode))
            throwEvent(this, this.gameObject);
    }
}

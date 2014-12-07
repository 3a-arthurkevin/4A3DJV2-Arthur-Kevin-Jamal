/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Évènement de click sur un bouton
 */

using UnityEngine;
using System.Collections;

public class OnButtonClick : CustomEventScript
{
    public void OnButtonClicked()
    {
        throwEvent(this, this.gameObject);
    }
}

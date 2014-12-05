using UnityEngine;
using System.Collections;

public class OnButtonClick : CustomEventScript
{
    public void OnButtonClicked()
    {
        throwEvent(this, this.gameObject);
    }
}

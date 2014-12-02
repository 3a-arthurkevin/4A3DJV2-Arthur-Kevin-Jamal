using UnityEngine;
using System.Collections;

public class GetKeyDownEventScript : CustomEventScript
{
    public KeyCode m_keyCode;

    void Update()
    {
        if (Input.GetKeyDown(m_keyCode))
            throwEvent(this, this.gameObject);
    }
}

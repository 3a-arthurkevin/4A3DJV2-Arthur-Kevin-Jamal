using UnityEngine;
using System.Collections;

public class LoadLevelActionScript : CustomActionScript
{
    public string m_levelName;

    protected override IEnumerator DoActionOnAvent(MonoBehaviour eventSender, GameObject args)
    {
        Application.LoadLevel(m_levelName);

        yield return null;
    }
}

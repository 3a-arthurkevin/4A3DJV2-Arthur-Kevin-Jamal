/**
 * @Author : Arthur TORRENTE
 * @Date : 07/12/2014
 * @Desc : Active un script
 * @LastModifier : Arthur TORRENTE
 */

using UnityEngine;
using System.Collections;

public class SetEnableScriptAction : CustomActionScript
{
    [SerializeField]
    private MonoBehaviour m_script;

    [SerializeField]
    private bool m_active;

    protected override IEnumerator DoActionOnEvent(MonoBehaviour eventSender, GameObject args)
    {
        m_script.enabled = m_active;

        yield return null;
    }
}

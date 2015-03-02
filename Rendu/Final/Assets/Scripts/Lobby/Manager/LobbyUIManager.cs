using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField]
    private Text m_waitPlayerCountText;

    [SerializeField]
    private GameObject m_form;

    [SerializeField]
    private GameObject m_wait;

    public void setWaitPlayerCount(int waitPlayerCount)
    {
        m_waitPlayerCountText.text = waitPlayerCount.ToString();
    }

    public void waitMode()
    {
        m_form.SetActive(false);
        m_wait.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LPGD.CommandLine
{
    public class CommandInputHandler : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI m_CommandHistory;
        [SerializeField] SOArchitecture.StringUnityEvent m_OnCommandProcessed;

        System.Text.StringBuilder m_StringBuilder = new System.Text.StringBuilder();

        public void OnCommandInput(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return;
            }

            m_StringBuilder.Clear();
            m_StringBuilder.Append(m_CommandHistory.text);

            m_StringBuilder.Append('\n');
            m_StringBuilder.Append(command);

            m_CommandHistory.SetText(m_StringBuilder.ToString());

            m_OnCommandProcessed?.Invoke(command);
        }
    }
}
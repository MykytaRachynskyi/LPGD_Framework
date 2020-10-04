using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LPGD.CommandLine
{
    [CreateAssetMenu(menuName = "CommandLine/ScriptableCommand")]
    public class ScriptableCommand : ScriptableObject
    {
        [SerializeField] bool m_CommandEnabled = true;

        [SerializeField] CommandData m_CommandData;
    }
}
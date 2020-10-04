using UnityEngine;

namespace LPGD.SOArchitecture
{
    [System.Serializable]
    public class StringUnityEvent : UnityEngine.Events.UnityEvent<string> { }

    [CreateAssetMenu(menuName = m_SOArchitectureMenuName + "StringGameEvent")]
    public class StringGameEvent : GameEvent<string>
    {

    }
}
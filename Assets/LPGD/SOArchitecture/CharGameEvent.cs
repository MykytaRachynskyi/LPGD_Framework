using UnityEngine;

namespace LPGD.SOArchitecture
{
    [System.Serializable]
    public class CharUnityEvent : UnityEngine.Events.UnityEvent<char> { }

    [CreateAssetMenu(menuName = m_SOArchitectureMenuName + "CharGameEvent")]
    public class CharGameEvent : GameEvent<char>
    {

    }
}
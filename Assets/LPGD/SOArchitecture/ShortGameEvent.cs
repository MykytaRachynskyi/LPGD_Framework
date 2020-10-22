using UnityEngine;

namespace LPGD.SOArchitecture
{
    [System.Serializable]
    public class ShortUnityEvent : UnityEngine.Events.UnityEvent<short> { }

    [CreateAssetMenu(menuName = m_SOArchitectureMenuName + "ShortGameEvent")]
    public class ShortGameEvent : GameEvent<short>
    {

    }
}
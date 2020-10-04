using UnityEngine;

namespace LPGD.SOArchitecture
{
    [System.Serializable]
    public class LongUnityEvent : UnityEngine.Events.UnityEvent<long> { }

    [CreateAssetMenu(menuName = m_SOArchitectureMenuName + "LongGameEvent")]
    public class LongGameEvent : GameEvent<long>
    {

    }
}
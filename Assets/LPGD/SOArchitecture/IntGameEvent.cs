using UnityEngine;

namespace LPGD.SOArchitecture
{
    [System.Serializable]
    public class IntUnityEvent : UnityEngine.Events.UnityEvent<int> {}

    [CreateAssetMenu(menuName = m_SOArchitectureMenuName + "IntGameEvent")]
    public class IntGameEvent : GameEvent<int>
    {

    }
}
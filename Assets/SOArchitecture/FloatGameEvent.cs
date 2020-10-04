using UnityEngine;

namespace LPGD.SOArchitecture
{
    [System.Serializable]
    public class FlatUnityEvent : UnityEngine.Events.UnityEvent<float> { }

    [CreateAssetMenu(menuName = m_SOArchitectureMenuName + "FloatGameEvent")]
    public class FloatGameEvent : GameEvent<float>
    {

    }
}
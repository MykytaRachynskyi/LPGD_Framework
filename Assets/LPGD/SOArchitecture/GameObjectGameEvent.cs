using UnityEngine;

namespace LPGD.SOArchitecture
{
    [System.Serializable]
    public class GameObjectUnityEvent : UnityEngine.Events.UnityEvent<GameObject> { }

    [CreateAssetMenu(menuName = m_SOArchitectureMenuName + "GameObjectGameEvent")]
    public class GameObjectGameEvent : GameEvent<GameObject>
    {
        
    }
}
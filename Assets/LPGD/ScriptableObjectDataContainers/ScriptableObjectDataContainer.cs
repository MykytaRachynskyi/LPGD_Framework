namespace LPGD
{
    public class ScriptableObjectDataContainer<T> : UnityEngine.ScriptableObject
    {
        public T Value;

        public static implicit operator T(ScriptableObjectDataContainer<T> container)
        {
            return container.Value;
        }
    }
}
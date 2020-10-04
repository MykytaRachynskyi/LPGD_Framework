using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LPGD.SOArchitecture
{
    using GameEventListenerDelegate = DelegateFactory.GameEventListenerDelegate;

    public interface IGameEventListener
    {
        void Invoke(object sender);
    }

    public static class DelegateFactory
    {
        public delegate void ListenerDelegate(object sender);

        class GameEventListenerDelegateAction : GameEventListenerDelegate
        {
            System.Action<object> m_Action;

            public GameEventListenerDelegateAction(System.Action<object> listener)
            {
                m_Action = listener;
            }

            public GameEventListenerDelegateAction(System.Action<object> listener, string debugName)
            {
                m_Action = listener;
                m_DebugName = debugName;
            }

            public override void Invoke(object sender)
            {
                m_Action?.Invoke(sender);
            }
        }

        class GameEventListenerDelegateListener : GameEventListenerDelegate
        {
            ListenerDelegate m_Action;

            public GameEventListenerDelegateListener(ListenerDelegate listener)
            {
                m_Action = listener;
            }

            public GameEventListenerDelegateListener(ListenerDelegate listener, string debugName)
            {
                m_Action = listener;
                m_DebugName = debugName;
            }

            public override void Invoke(object sender)
            {
                m_Action?.Invoke(sender);
            }
        }

        class GameEventListenerDelegateListenerInterface : GameEventListenerDelegate
        {
            IGameEventListener m_Action;

            public GameEventListenerDelegateListenerInterface(IGameEventListener listener)
            {
                m_Action = listener;
            }

            public GameEventListenerDelegateListenerInterface(IGameEventListener listener, string debugName)
            {
                m_Action = listener;
                m_DebugName = debugName;
            }

            public override void Invoke(object sender)
            {
                m_Action?.Invoke(sender);
            }
        }

        public abstract class GameEventListenerDelegate
        {
            protected string m_DebugName;

            public static implicit operator GameEventListenerDelegate(System.Action<object> action) => CreateListener(action);
            public static implicit operator GameEventListenerDelegate(ListenerDelegate @delegate) => CreateListener(@delegate);

            public abstract void Invoke(object sender);

            public override string ToString()
            {
                return m_DebugName;
            }
        }

        public static GameEventListenerDelegate CreateListener(System.Action<object> listener)
        {
            return new GameEventListenerDelegateAction(listener);
        }

        public static GameEventListenerDelegate CreateListener(System.Action<object> listener, string debugName)
        {
            return new GameEventListenerDelegateAction(listener, debugName);
        }

        public static GameEventListenerDelegate CreateListener(ListenerDelegate listener)
        {
            return new GameEventListenerDelegateListener(listener);
        }

        public static GameEventListenerDelegate CreateListener(ListenerDelegate listener, string debugName)
        {
            return new GameEventListenerDelegateListener(listener, debugName);
        }

        public static GameEventListenerDelegate CreateListener(IGameEventListener listener)
        {
            return new GameEventListenerDelegateListenerInterface(listener);
        }

        public static GameEventListenerDelegate CreateListener(IGameEventListener listener, string debugName)
        {
            return new GameEventListenerDelegateListenerInterface(listener, debugName);
        }
    }

    public abstract class GameEventBase : ScriptableObject
    {
        public const string m_SOArchitectureMenuName = "SOArchitecture/";

        List<GameEventListenerDelegate> m_Listeners = new List<GameEventListenerDelegate>();

        public void AddListener(System.Action<object> action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(System.Action<object> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory.CreateListener(action, debugName));
        }

        public void AddListener(DelegateFactory.ListenerDelegate action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(DelegateFactory.ListenerDelegate action, string debugName)
        {
            m_Listeners.Add(DelegateFactory.CreateListener(action, debugName));
        }

        public void AddListener(IGameEventListener action)
        {
            m_Listeners.Add(DelegateFactory.CreateListener(action));
        }

        public void AddListener(IGameEventListener action, string debugName)
        {
            m_Listeners.Add(DelegateFactory.CreateListener(action, debugName));
        }
    }

    public abstract class GameEvent<T> : GameEventBase
    {
        List<GameEventListenerDelegate<T>> m_Listeners = new List<GameEventListenerDelegate<T>>();

        public delegate void ListenerDelegate(object sender, T arg);

        public void AddListener(System.Action<object, T> action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(System.Action<object, T> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T>.CreateListener(action, debugName));
        }

        public void AddListener(DelegateFactory<T>.ListenerDelegate action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(DelegateFactory<T>.ListenerDelegate action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T>.CreateListener(action, debugName));
        }

        public void AddListener(IGameEventListener<T> action)
        {
            m_Listeners.Add(DelegateFactory<T>.CreateListener(action));
        }

        public void AddListener(IGameEventListener<T> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T>.CreateListener(action, debugName));
        }
    }

    public abstract class GameEvent<T1, T2> : GameEventBase
    {
        List<GameEventListenerDelegate<T1, T2>> m_Listeners = new List<GameEventListenerDelegate<T1, T2>>();

        public delegate void ListenerDelegate(object sender, T1 arg1, T2 arg2);

        public void AddListener(System.Action<object, T1, T2> action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(System.Action<object, T1, T2> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2>.CreateListener(action, debugName));
        }

        public void AddListener(DelegateFactory<T1, T2>.ListenerDelegate action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(DelegateFactory<T1, T2>.ListenerDelegate action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2>.CreateListener(action, debugName));
        }

        public void AddListener(IGameEventListener<T1, T2> action)
        {
            m_Listeners.Add(DelegateFactory<T1, T2>.CreateListener(action));
        }

        public void AddListener(IGameEventListener<T1, T2> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2>.CreateListener(action, debugName));
        }
    }

    public abstract class GameEvent<T1, T2, T3> : GameEventBase
    {
        List<GameEventListenerDelegate<T1, T2, T3>> m_Listeners = new List<GameEventListenerDelegate<T1, T2, T3>>();

        public delegate void ListenerDelegate(object sender, T1 arg1, T2 arg2, T3 arg3);

        public void AddListener(System.Action<object, T1, T2, T3> action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(System.Action<object, T1, T2, T3> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2, T3>.CreateListener(action, debugName));
        }

        public void AddListener(DelegateFactory<T1, T2, T3>.ListenerDelegate action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(DelegateFactory<T1, T2, T3>.ListenerDelegate action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2, T3>.CreateListener(action, debugName));
        }

        public void AddListener(IGameEventListener<T1, T2, T3> action)
        {
            m_Listeners.Add(DelegateFactory<T1, T2, T3>.CreateListener(action));
        }

        public void AddListener(IGameEventListener<T1, T2, T3> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2, T3>.CreateListener(action, debugName));
        }
    }

    public abstract class GameEvent<T1, T2, T3, T4> : GameEventBase
    {
        List<GameEventListenerDelegate<T1, T2, T3, T4>> m_Listeners = new List<GameEventListenerDelegate<T1, T2, T3, T4>>();

        public delegate void ListenerDelegate(object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

        public void AddListener(System.Action<object, T1, T2, T3, T4> action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(System.Action<object, T1, T2, T3, T4> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2, T3, T4>.CreateListener(action, debugName));
        }

        public void AddListener(DelegateFactory<T1, T2, T3, T4>.ListenerDelegate action)
        {
            m_Listeners.Add(action);
        }

        public void AddListener(DelegateFactory<T1, T2, T3, T4>.ListenerDelegate action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2, T3, T4>.CreateListener(action, debugName));
        }

        public void AddListener(IGameEventListener<T1, T2, T3, T4> action)
        {
            m_Listeners.Add(DelegateFactory<T1, T2, T3, T4>.CreateListener(action));
        }

        public void AddListener(IGameEventListener<T1, T2, T3, T4> action, string debugName)
        {
            m_Listeners.Add(DelegateFactory<T1, T2, T3, T4>.CreateListener(action, debugName));
        }
    }
}

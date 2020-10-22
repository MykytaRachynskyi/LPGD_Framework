#region GameEventListener<T>
public interface IGameEventListener<T>
{
    void Invoke(object sender, T arg);
}

public abstract class GameEventListenerDelegate<T>
{
    protected string m_DebugName;

    public static implicit operator GameEventListenerDelegate<T>(System.Action<object, T> action)
                                                                        => DelegateFactory<T>.CreateListener(action);
    public static implicit operator GameEventListenerDelegate<T>(DelegateFactory<T>.ListenerDelegate @delegate)
                                                                        => DelegateFactory<T>.CreateListener(@delegate);

    public abstract void Invoke(object sender, T arg);

    public override string ToString()
    {
        return m_DebugName;
    }
}

public static class DelegateFactory<T>
{
    public delegate void ListenerDelegate(object sender, T arg);

    class GameEventListenerDelegateAction : GameEventListenerDelegate<T>
    {
        System.Action<object, T> m_Action;

        public GameEventListenerDelegateAction(System.Action<object, T> listener)
        {
            m_Action = listener;
        }

        public GameEventListenerDelegateAction(System.Action<object, T> listener, string debugName)
        {
            m_Action = listener;
            m_DebugName = debugName;
        }

        public override void Invoke(object sender, T arg)
        {
            m_Action?.Invoke(sender, arg);
        }
    }

    class GameEventListenerDelegateListener : GameEventListenerDelegate<T>
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

        public override void Invoke(object sender, T arg)
        {
            m_Action?.Invoke(sender, arg);
        }
    }

    class GameEventListenerDelegateListenerInterface : GameEventListenerDelegate<T>
    {
        IGameEventListener<T> m_Action;

        public GameEventListenerDelegateListenerInterface(IGameEventListener<T> listener)
        {
            m_Action = listener;
        }

        public GameEventListenerDelegateListenerInterface(IGameEventListener<T> listener, string debugName)
        {
            m_Action = listener;
            m_DebugName = debugName;
        }

        public override void Invoke(object sender, T arg)
        {
            m_Action?.Invoke(sender, arg);
        }
    }

    public static GameEventListenerDelegate<T> CreateListener(System.Action<object, T> listener)
    {
        return new GameEventListenerDelegateAction(listener);
    }

    public static GameEventListenerDelegate<T> CreateListener(System.Action<object, T> listener, string debugName)
    {
        return new GameEventListenerDelegateAction(listener, debugName);
    }

    public static GameEventListenerDelegate<T> CreateListener(ListenerDelegate listener)
    {
        return new GameEventListenerDelegateListener(listener);
    }

    public static GameEventListenerDelegate<T> CreateListener(ListenerDelegate listener, string debugName)
    {
        return new GameEventListenerDelegateListener(listener, debugName);
    }

    public static GameEventListenerDelegate<T> CreateListener(IGameEventListener<T> listener)
    {
        return new GameEventListenerDelegateListenerInterface(listener);
    }

    public static GameEventListenerDelegate<T> CreateListener(IGameEventListener<T> listener, string debugName)
    {
        return new GameEventListenerDelegateListenerInterface(listener, debugName);
    }
}
#endregion

#region GameEventListener<T1, T2>
public interface IGameEventListener<T1, T2>
{
    void Invoke(object sender, T1 arg1, T2 arg2);
}

public abstract class GameEventListenerDelegate<T1, T2>
{
    protected string m_DebugName;

    public static implicit operator GameEventListenerDelegate<T1, T2>(System.Action<object, T1, T2> action)
                                                                        => DelegateFactory<T1, T2>.CreateListener(action);
    public static implicit operator GameEventListenerDelegate<T1, T2>(DelegateFactory<T1, T2>.ListenerDelegate @delegate)
                                                                        => DelegateFactory<T1, T2>.CreateListener(@delegate);

    public abstract void Invoke(object sender, T1 arg1, T2 arg2);

    public override string ToString()
    {
        return m_DebugName;
    }
}

public static class DelegateFactory<T1, T2>
{
    public delegate void ListenerDelegate(object sender, T1 arg1, T2 arg2);

    class GameEventListenerDelegateAction : GameEventListenerDelegate<T1, T2>
    {
        System.Action<object, T1, T2> m_Action;

        public GameEventListenerDelegateAction(System.Action<object, T1, T2> listener)
        {
            m_Action = listener;
        }

        public GameEventListenerDelegateAction(System.Action<object, T1, T2> listener, string debugName)
        {
            m_Action = listener;
            m_DebugName = debugName;
        }

        public override void Invoke(object sender, T1 arg1, T2 arg2)
        {
            m_Action?.Invoke(sender, arg1, arg2);
        }
    }

    class GameEventListenerDelegateListener : GameEventListenerDelegate<T1, T2>
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

        public override void Invoke(object sender, T1 arg1, T2 arg2)
        {
            m_Action?.Invoke(sender, arg1, arg2);
        }
    }

    class GameEventListenerDelegateListenerInterface : GameEventListenerDelegate<T1, T2>
    {
        IGameEventListener<T1, T2> m_Action;

        public GameEventListenerDelegateListenerInterface(IGameEventListener<T1, T2> listener)
        {
            m_Action = listener;
        }

        public GameEventListenerDelegateListenerInterface(IGameEventListener<T1, T2> listener, string debugName)
        {
            m_Action = listener;
            m_DebugName = debugName;
        }

        public override void Invoke(object sender, T1 arg1, T2 arg2)
        {
            m_Action?.Invoke(sender, arg1, arg2);
        }
    }

    public static GameEventListenerDelegate<T1, T2> CreateListener(System.Action<object, T1, T2> listener)
    {
        return new GameEventListenerDelegateAction(listener);
    }

    public static GameEventListenerDelegate<T1, T2> CreateListener(System.Action<object, T1, T2> listener, string debugName)
    {
        return new GameEventListenerDelegateAction(listener, debugName);
    }

    public static GameEventListenerDelegate<T1, T2> CreateListener(ListenerDelegate listener)
    {
        return new GameEventListenerDelegateListener(listener);
    }

    public static GameEventListenerDelegate<T1, T2> CreateListener(ListenerDelegate listener, string debugName)
    {
        return new GameEventListenerDelegateListener(listener, debugName);
    }

    public static GameEventListenerDelegate<T1, T2> CreateListener(IGameEventListener<T1, T2> listener)
    {
        return new GameEventListenerDelegateListenerInterface(listener);
    }

    public static GameEventListenerDelegate<T1, T2> CreateListener(IGameEventListener<T1, T2> listener, string debugName)
    {
        return new GameEventListenerDelegateListenerInterface(listener, debugName);
    }
}
#endregion

#region GameEventListener<T1, T2, T3>
public interface IGameEventListener<T1, T2, T3>
{
    void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3);
}

public abstract class GameEventListenerDelegate<T1, T2, T3>
{
    protected string m_DebugName;

    public static implicit operator GameEventListenerDelegate<T1, T2, T3>(System.Action<object, T1, T2, T3> action)
                                                                        => DelegateFactory<T1, T2, T3>.CreateListener(action);
    public static implicit operator GameEventListenerDelegate<T1, T2, T3>(DelegateFactory<T1, T2, T3>.ListenerDelegate @delegate)
                                                                        => DelegateFactory<T1, T2, T3>.CreateListener(@delegate);

    public abstract void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3);

    public override string ToString()
    {
        return m_DebugName;
    }
}

public static class DelegateFactory<T1, T2, T3>
{
    public delegate void ListenerDelegate(object sender, T1 arg1, T2 arg2, T3 arg3);

    class GameEventListenerDelegateAction : GameEventListenerDelegate<T1, T2, T3>
    {
        System.Action<object, T1, T2, T3> m_Action;

        public GameEventListenerDelegateAction(System.Action<object, T1, T2, T3> listener)
        {
            m_Action = listener;
        }

        public GameEventListenerDelegateAction(System.Action<object, T1, T2, T3> listener, string debugName)
        {
            m_Action = listener;
            m_DebugName = debugName;
        }

        public override void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3)
        {
            m_Action?.Invoke(sender, arg1, arg2, arg3);
        }
    }

    class GameEventListenerDelegateListener : GameEventListenerDelegate<T1, T2, T3>
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

        public override void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3)
        {
            m_Action?.Invoke(sender, arg1, arg2, arg3);
        }
    }

    class GameEventListenerDelegateListenerInterface : GameEventListenerDelegate<T1, T2, T3>
    {
        IGameEventListener<T1, T2, T3> m_Action;

        public GameEventListenerDelegateListenerInterface(IGameEventListener<T1, T2, T3> listener)
        {
            m_Action = listener;
        }

        public GameEventListenerDelegateListenerInterface(IGameEventListener<T1, T2, T3> listener, string debugName)
        {
            m_Action = listener;
            m_DebugName = debugName;
        }

        public override void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3)
        {
            m_Action?.Invoke(sender, arg1, arg2, arg3);
        }
    }

    public static GameEventListenerDelegate<T1, T2, T3> CreateListener(System.Action<object, T1, T2, T3> listener)
    {
        return new GameEventListenerDelegateAction(listener);
    }

    public static GameEventListenerDelegate<T1, T2, T3> CreateListener(System.Action<object, T1, T2, T3> listener, string debugName)
    {
        return new GameEventListenerDelegateAction(listener, debugName);
    }

    public static GameEventListenerDelegate<T1, T2, T3> CreateListener(ListenerDelegate listener)
    {
        return new GameEventListenerDelegateListener(listener);
    }

    public static GameEventListenerDelegate<T1, T2, T3> CreateListener(ListenerDelegate listener, string debugName)
    {
        return new GameEventListenerDelegateListener(listener, debugName);
    }

    public static GameEventListenerDelegate<T1, T2, T3> CreateListener(IGameEventListener<T1, T2, T3> listener)
    {
        return new GameEventListenerDelegateListenerInterface(listener);
    }

    public static GameEventListenerDelegate<T1, T2, T3> CreateListener(IGameEventListener<T1, T2, T3> listener, string debugName)
    {
        return new GameEventListenerDelegateListenerInterface(listener, debugName);
    }
}
#endregion

#region GameEventListener<T1, T2, T3, T4>
public interface IGameEventListener<T1, T2, T3, T4>
{
    void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
}

public abstract class GameEventListenerDelegate<T1, T2, T3, T4>
{
    protected string m_DebugName;

    public static implicit operator GameEventListenerDelegate<T1, T2, T3, T4>(System.Action<object, T1, T2, T3, T4> action)
                                                                        => DelegateFactory<T1, T2, T3, T4>.CreateListener(action);
    public static implicit operator GameEventListenerDelegate<T1, T2, T3, T4>(DelegateFactory<T1, T2, T3, T4>.ListenerDelegate @delegate)
                                                                        => DelegateFactory<T1, T2, T3, T4>.CreateListener(@delegate);

    public abstract void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    public override string ToString()
    {
        return m_DebugName;
    }
}

public static class DelegateFactory<T1, T2, T3, T4>
{
    public delegate void ListenerDelegate(object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4);

    class GameEventListenerDelegateAction : GameEventListenerDelegate<T1, T2, T3, T4>
    {
        System.Action<object, T1, T2, T3, T4> m_Action;

        public GameEventListenerDelegateAction(System.Action<object, T1, T2, T3, T4> listener)
        {
            m_Action = listener;
        }

        public GameEventListenerDelegateAction(System.Action<object, T1, T2, T3, T4> listener, string debugName)
        {
            m_Action = listener;
            m_DebugName = debugName;
        }

        public override void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            m_Action?.Invoke(sender, arg1, arg2, arg3, arg4);
        }
    }

    class GameEventListenerDelegateListener : GameEventListenerDelegate<T1, T2, T3, T4>
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

        public override void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            m_Action?.Invoke(sender, arg1, arg2, arg3, arg4);
        }
    }

    class GameEventListenerDelegateListenerInterface : GameEventListenerDelegate<T1, T2, T3, T4>
    {
        IGameEventListener<T1, T2, T3, T4> m_Action;

        public GameEventListenerDelegateListenerInterface(IGameEventListener<T1, T2, T3, T4> listener)
        {
            m_Action = listener;
        }

        public GameEventListenerDelegateListenerInterface(IGameEventListener<T1, T2, T3, T4> listener, string debugName)
        {
            m_Action = listener;
            m_DebugName = debugName;
        }

        public override void Invoke(object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            m_Action?.Invoke(sender, arg1, arg2, arg3, arg4);
        }
    }

    public static GameEventListenerDelegate<T1, T2, T3, T4> CreateListener(System.Action<object, T1, T2, T3, T4> listener)
    {
        return new GameEventListenerDelegateAction(listener);
    }

    public static GameEventListenerDelegate<T1, T2, T3, T4> CreateListener(System.Action<object, T1, T2, T3, T4> listener, string debugName)
    {
        return new GameEventListenerDelegateAction(listener, debugName);
    }

    public static GameEventListenerDelegate<T1, T2, T3, T4> CreateListener(ListenerDelegate listener)
    {
        return new GameEventListenerDelegateListener(listener);
    }

    public static GameEventListenerDelegate<T1, T2, T3, T4> CreateListener(ListenerDelegate listener, string debugName)
    {
        return new GameEventListenerDelegateListener(listener, debugName);
    }

    public static GameEventListenerDelegate<T1, T2, T3, T4> CreateListener(IGameEventListener<T1, T2, T3, T4> listener)
    {
        return new GameEventListenerDelegateListenerInterface(listener);
    }

    public static GameEventListenerDelegate<T1, T2, T3, T4> CreateListener(IGameEventListener<T1, T2, T3, T4> listener, string debugName)
    {
        return new GameEventListenerDelegateListenerInterface(listener, debugName);
    }
}
#endregion


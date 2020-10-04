using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LPGD.Tween
{
    public abstract class Tween
    {
        Coroutine m_Routine;
        MonoBehaviour m_Driver;

        public static Tween MakeFloatTween(MonoBehaviour driver, float fromValue, float toValue,
                                           float durationInSeconds, AnimationCurve animationCurve = null)
        {
            return new Tween<float>(Mathf.Lerp, fromValue, toValue, durationInSeconds, animationCurve);
        }

        public static Tween MakeVector2Tween(MonoBehaviour driver, Vector2 fromValue, Vector2 toValue,
                                           float durationInSeconds, AnimationCurve animationCurve = null)
        {
            return new Tween<Vector2>(Vector2.Lerp, fromValue, toValue, durationInSeconds, animationCurve);
        }

        public static Tween MakeVector3Tween(MonoBehaviour driver, Vector3 fromValue, Vector3 toValue,
                                           float durationInSeconds, AnimationCurve animationCurve = null)
        {
            return new Tween<Vector3>(Vector3.Lerp, fromValue, toValue, durationInSeconds, animationCurve);
        }

        public static Tween MakeColorTween(MonoBehaviour driver, Color fromValue, Color toValue,
                                           float durationInSeconds, AnimationCurve animationCurve = null)
        {
            return new Tween<Color>(Color.Lerp, fromValue, toValue, durationInSeconds, animationCurve);
        }

        public Tween Play()
        {
            if (m_Driver == null)
            {
                Debug.Log("Driver is null! Can't start coroutine whithout a monobehaviour to start it on.");
                return null;
            }

            m_Routine = m_Driver.StartCoroutine(TweenRoutine());
            return this;
        }

        public Tween Stop()
        {
            if (m_Driver == null)
            {
                Debug.Log("Driver is null! Can't stop coroutine whithout a monobehaviour to start it on.");
                return null;
            }

            if (m_Routine != null)
            {
                m_Driver.StopCoroutine(m_Routine);
            }

            return this;
        }

        protected abstract IEnumerator TweenRoutine();
    }

    class Tween<T> : Tween
    {
        public delegate void OnTweenStart(T val);
        public delegate void OnTweenUpdate(T val);
        public delegate void OnTweenEnd(T val);

        System.Func<T, T, float, T> m_LerpFunction;
        OnTweenStart m_OnTweenStart;
        OnTweenEnd m_OnTweenEnd;
        OnTweenUpdate m_OnTweenUpdate;

        T m_From;
        T m_To;
        T m_CurrentValue;

        float m_TimeInSeconds;

        AnimationCurve m_AnimationCurve;

        public Tween(System.Func<T, T, float, T> lerpFunction, T from, T to, float timeInSeconds, AnimationCurve animationCurve)
        {
            m_From = from;
            m_To = to;
            m_TimeInSeconds = timeInSeconds;
            m_AnimationCurve = animationCurve;
            m_LerpFunction = lerpFunction;
        }

        protected override IEnumerator TweenRoutine()
        {
            return ParamterizedRoutine();
        }

        public T GetValue() => m_CurrentValue;

        IEnumerator ParamterizedRoutine()
        {
            if (m_TimeInSeconds <= 0f)
            {
                Debug.LogWarning("Time in seconds for this tween is either 0 or less than 0. Clamping it to 1!");
                m_TimeInSeconds = 1f;
            }

            m_OnTweenStart?.Invoke(m_From);
            float progress = 0f;
            while (progress < 1f)
            {
                progress += Time.deltaTime / m_TimeInSeconds;
                float curveProgress = m_AnimationCurve == null ? progress : m_AnimationCurve.Evaluate(progress);
                m_CurrentValue = m_LerpFunction(m_From, m_To, curveProgress);
                m_OnTweenUpdate?.Invoke(m_CurrentValue);
                yield return null;
            }

            m_CurrentValue = m_To;
            m_OnTweenEnd?.Invoke(m_CurrentValue);
        }
    }
}
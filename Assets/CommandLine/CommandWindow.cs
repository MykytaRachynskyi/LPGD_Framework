using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LPGD.CommandLine
{
    public class CommandWindow : MonoBehaviour
    {
        [System.Serializable]
        class WindowElementData
        {
            public enum PositionSpace { Global, Local, Anchored }
            public RectTransform rectTransform;
            public bool setWidthToFullScreen;
            public bool setHeightToFullScreen;
            [Header("Open position settings")]
            public bool useWidthForOpenPos;
            public bool useHeightForOpenPos;
            public float widthMultiplierForOpenPos;
            public float heightMultiplierForOpenPos;
            public Vector3 openPosition;
            public PositionSpace openAnimationPositionSpace;
            [Header("Open position settings")]
            public bool useWidthForClosedPos;
            public bool useHeightForClosedPos;
            public float widthMultiplierForClosedPos;
            public float heightMultiplierForClosedPos;
            public Vector3 closedPosition;
            public PositionSpace closeAnimationPositionSpace;
        }

        [SerializeField] float m_MoveAnimationTimeInSeconds;
        [SerializeField] WindowElementData[] m_WindowElementData;

        bool m_IsShown = false;
        bool m_IsMoving = false;

        Canvas m_ParentCanvas;
        RectTransform m_ParentCanvasRectTransform;

        private void Awake()
        {
            InitializeWindowElements();
        }

        void InitializeWindowElements()
        {
            m_ParentCanvas = GetComponentInParent<Canvas>();
            if (m_ParentCanvas == null)
            {
                Debug.LogError("No parent canvas found!");
                return;
            }
            m_ParentCanvasRectTransform = m_ParentCanvas.GetComponent<RectTransform>();
            if (m_ParentCanvasRectTransform == null)
            {
                Debug.LogError("No parent canvas recttransform found!");
                return;
            }

            for (int i = 0; i < m_WindowElementData.Length; i++)
            {
                m_WindowElementData[i].rectTransform.sizeDelta = new Vector2(
                    m_WindowElementData[i].setWidthToFullScreen ? m_ParentCanvasRectTransform.rect.width : m_WindowElementData[i].rectTransform.sizeDelta.x,
                    m_WindowElementData[i].setHeightToFullScreen ? m_ParentCanvasRectTransform.rect.height : m_WindowElementData[i].rectTransform.sizeDelta.y
                );
            }
        }

        [ContextMenu("Toggle")]
        public void Toggle()
        {
            if (m_IsMoving)
            {
                Debug.Log("Can't Toggle when moving!");
                return;
            }

            Debug.Log($"Toggling - currently isShown : {m_IsShown}");

            if (!m_IsShown) ShowWindow();
            else HideWindow();
        }

        public void ShowWindow()
        {
            if (m_IsShown)
                return;
            if (m_IsMoving)
                return;

            for (int i = 0; i < m_WindowElementData.Length; i++)
            {
                Vector3 targetPosition = m_WindowElementData[i].openPosition;

                if (m_WindowElementData[i].useWidthForOpenPos)
                    targetPosition.x = m_WindowElementData[i].rectTransform.rect.width * m_WindowElementData[i].widthMultiplierForOpenPos;
                if (m_WindowElementData[i].useHeightForOpenPos)
                    targetPosition.y = m_WindowElementData[i].rectTransform.rect.height * m_WindowElementData[i].heightMultiplierForOpenPos;

                switch (m_WindowElementData[i].openAnimationPositionSpace)
                {
                    case WindowElementData.PositionSpace.Anchored:
                        StartCoroutine(MoveAnimAnchored(m_WindowElementData[i].rectTransform, targetPosition));
                        break;
                    case WindowElementData.PositionSpace.Local:
                        StartCoroutine(MoveAnimLocal(m_WindowElementData[i].rectTransform, targetPosition));
                        break;
                    case WindowElementData.PositionSpace.Global:
                        StartCoroutine(MoveAnimGlobal(m_WindowElementData[i].rectTransform, targetPosition));
                        break;
                    default:
                        break;
                }
            }

            m_IsShown = true;
        }

        public void HideWindow()
        {
            if (!m_IsShown)
                return;
            if (m_IsMoving)
                return;

            for (int i = 0; i < m_WindowElementData.Length; i++)
            {
                Vector3 targetPosition = m_WindowElementData[i].closedPosition;

                if (m_WindowElementData[i].useWidthForClosedPos)
                    targetPosition.x = m_WindowElementData[i].rectTransform.rect.width * m_WindowElementData[i].widthMultiplierForClosedPos;
                if (m_WindowElementData[i].useHeightForClosedPos)
                    targetPosition.y = m_WindowElementData[i].rectTransform.rect.height * m_WindowElementData[i].heightMultiplierForClosedPos;

                switch (m_WindowElementData[i].closeAnimationPositionSpace)
                {
                    case WindowElementData.PositionSpace.Anchored:
                        StartCoroutine(MoveAnimAnchored(m_WindowElementData[i].rectTransform, targetPosition));
                        break;
                    case WindowElementData.PositionSpace.Local:
                        StartCoroutine(MoveAnimLocal(m_WindowElementData[i].rectTransform, targetPosition));
                        break;
                    case WindowElementData.PositionSpace.Global:
                        StartCoroutine(MoveAnimGlobal(m_WindowElementData[i].rectTransform, targetPosition));
                        break;
                    default:
                        break;
                }
            }

            m_IsShown = false;
        }

        // TODO: Extract this into a static Tweening class or smth. Absolutely need to avoid all this boiler plate!
        IEnumerator MoveAnimAnchored(RectTransform targetTransform, Vector3 targetAnchoredPosition)
        {
            m_IsMoving = true;

            float progress = 0;

            Vector3 currentAnchoredPosition = targetTransform.anchoredPosition;

            while (progress < 1f)
            {
                progress += Time.deltaTime / m_MoveAnimationTimeInSeconds;
                targetTransform.anchoredPosition = Vector3.Lerp(currentAnchoredPosition, targetAnchoredPosition, progress);
                yield return null;
            }

            targetTransform.anchoredPosition = targetAnchoredPosition;

            m_IsMoving = false;
        }

        // TODO: Extract this into a static Tweening class or smth. Absolutely need to avoid all this boiler plate!
        IEnumerator MoveAnimGlobal(RectTransform targetTransform, Vector3 targetGlobalSpacePosition)
        {
            m_IsMoving = true;

            float progress = 0;

            Vector3 currentGlobalSpacePosition = targetTransform.position;

            while (progress < 1f)
            {
                progress += Time.deltaTime / m_MoveAnimationTimeInSeconds;
                targetTransform.position = Vector3.Lerp(currentGlobalSpacePosition, targetGlobalSpacePosition, progress);
                yield return null;
            }

            targetTransform.position = targetGlobalSpacePosition;

            m_IsMoving = false;
        }

        // TODO: Extract this into a static Tweening class or smth. Absolutely need to avoid all this boiler plate!
        IEnumerator MoveAnimLocal(RectTransform targetTransform, Vector3 targetLocalSpacePosition)
        {
            m_IsMoving = true;

            float progress = 0;

            Vector3 currentLocalSpacePosition = targetTransform.localPosition;

            while (progress < 1f)
            {
                progress += Time.deltaTime / m_MoveAnimationTimeInSeconds;
                targetTransform.localPosition = Vector3.Lerp(currentLocalSpacePosition, targetLocalSpacePosition, progress);
                yield return null;
            }

            targetTransform.localPosition = targetLocalSpacePosition;

            m_IsMoving = false;
        }
    }
}
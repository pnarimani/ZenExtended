#if UNITASK && OPEN_JUICE

using UnityEngine;

namespace ZenExtended
{
    internal readonly struct TransformInfo
    {
        private readonly Vector2 _anchorMin, _anchorMax, _anchoredPosition, _sizeDelta;
        private readonly Vector3 _scale;
        private readonly Quaternion _rotation;
        
        public TransformInfo(Vector2 anchorMin, Vector2 anchorMax, Vector2 anchoredPosition, Vector2 sizeDelta, Quaternion rotation, Vector3 scale)
        {
            _anchorMin = anchorMin;
            _anchorMax = anchorMax;
            _anchoredPosition = anchoredPosition;
            _sizeDelta = sizeDelta;
            _rotation = rotation;
            _scale = scale;
        }

        public TransformInfo(RectTransform t) : this(t.anchorMin, t.anchorMax, t.anchoredPosition, t.sizeDelta, t.rotation, t.localScale)
        {
        }

        public void ApplyTo(RectTransform t)
        {
            t.anchorMin = _anchorMin;
            t.anchorMax = _anchorMax;
            t.anchoredPosition = _anchoredPosition;
            t.sizeDelta = _sizeDelta;
            t.rotation = _rotation;
            t.localScale = _scale;
        }
    }
}
#endif

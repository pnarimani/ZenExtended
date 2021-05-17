#if UNITASK && OPEN_JUICE

using UnityEngine;

namespace ZenExtended
{
    internal readonly struct TransformInfo
    {
        private readonly Vector2 AnchorMin, AnchorMax, AnchoredPosition, SizeDelta;
        private readonly Vector3 Scale;
        private readonly Quaternion Rotation;


        public TransformInfo(Vector2 anchorMin, Vector2 anchorMax, Vector2 anchoredPosition, Vector2 sizeDelta, Quaternion rotation, Vector3 scale)
        {
            AnchorMin = anchorMin;
            AnchorMax = anchorMax;
            AnchoredPosition = anchoredPosition;
            SizeDelta = sizeDelta;
            Rotation = rotation;
            Scale = scale;
        }

        public TransformInfo(RectTransform t) : this(t.anchorMin, t.anchorMax, t.anchoredPosition, t.sizeDelta, t.rotation, t.localScale)
        {
        }

        public void ApplyTo(RectTransform t)
        {
            t.anchorMin = AnchorMin;
            t.anchorMax = AnchorMax;
            t.anchoredPosition = AnchoredPosition;
            t.sizeDelta = SizeDelta;
            t.rotation = Rotation;
            t.localScale = Scale;
        }
    }
}
#endif

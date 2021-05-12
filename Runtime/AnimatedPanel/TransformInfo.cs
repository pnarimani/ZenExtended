#if UNITASK && OPEN_JUICE

using UnityEngine;

namespace ZenExtended
{
    internal readonly struct TransformInfo
    {
        public readonly Vector2 AnchorMin, AnchorMax, AnchoredPosition, SizeDelta;

        public TransformInfo(Vector2 anchorMin, Vector2 anchorMax, Vector2 anchoredPosition, Vector2 sizeDelta)
        {
            AnchorMin = anchorMin;
            AnchorMax = anchorMax;
            AnchoredPosition = anchoredPosition;
            SizeDelta = sizeDelta;
        }

        public TransformInfo(RectTransform t) : this(t.anchorMin, t.anchorMax, t.anchoredPosition, t.sizeDelta)
        {
        }

        public void ApplyTo(RectTransform t)
        {
            t.anchorMin = AnchorMin;
            t.anchorMax = AnchorMax;
            t.anchoredPosition = AnchoredPosition;
            t.sizeDelta = SizeDelta;
        }
    }
}
#endif

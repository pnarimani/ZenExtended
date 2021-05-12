#if OPEN_JUICE && UNITASK
using System;
using UnityEngine.UI;
using YoYoStudio.OpenJuice;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace ZenExtended
{
#if ODIN_INSPECTOR
    [InlineProperty]
    [HideLabel]
#endif
    [Serializable]
    internal class AnimatedPanelComponents
    {
#if ODIN_INSPECTOR
        [BoxGroup("Animated Panel")]
#endif
        public Button CloseButton;

#if ODIN_INSPECTOR
        [BoxGroup("Animated Panel")]
#endif
        public BaseTransition PrimaryTransition;

#if ODIN_INSPECTOR
        [BoxGroup("Animated Panel")]
#endif
        public BaseTransition[] SecondaryTransitions;
    }
}
#endif
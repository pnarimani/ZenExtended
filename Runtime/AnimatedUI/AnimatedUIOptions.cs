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
    public class AnimatedUIOptions
    {
#if ODIN_INSPECTOR
        [BoxGroup("Animated UI")]
#endif
        public Button CloseButton;

#if ODIN_INSPECTOR
        [BoxGroup("Animated UI")]
#endif
        public bool PlayReverseOnClose = true;

#if ODIN_INSPECTOR
        [BoxGroup("Animated UI")]
#endif
        public BaseTransition PrimaryTransition;

#if ODIN_INSPECTOR
        [BoxGroup("Animated UI")]
#endif
        public BaseTransition[] SecondaryTransitions;
    }
}
#endif
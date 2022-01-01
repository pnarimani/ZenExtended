#if (OPEN_JUICE || ANIMATION_SEQUENCER) && UNITASK
using System;
using BrunoMikoski.AnimationSequencer;
using UnityEngine.UI;
using YoYoStudio.OpenJuice;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace ZenExtended
{
    [InlineProperty]
    [HideLabel]
    [Serializable]
    public class AnimatedUIOptions
    {
        [BoxGroup("Animated UI")]
        public Button CloseButton;

        [BoxGroup("Animated UI")]
        public bool PlayReverseOnClose = true;
        
        [BoxGroup("Animated UI")]
        [ShowIf(nameof(PlayReverseOnClose))]
        public float RewindTimescale = 2;

#if OPEN_JUICE
        [BoxGroup("Animated UI")]
        public BaseTransition PrimaryTransition;

        [BoxGroup("Animated UI")]
        public BaseTransition[] SecondaryTransitions;
#else
        [BoxGroup("Animated UI")] 
        public AnimationSequencerController Sequence;
#endif
    }
}
#endif
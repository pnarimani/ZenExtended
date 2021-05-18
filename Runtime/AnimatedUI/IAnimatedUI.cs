#if OPEN_JUICE && UNITASK

using Cysharp.Threading.Tasks;

namespace ZenExtended
{
    public interface IAnimatedUI
    {
        float TransitionDuration { get; }
        
        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// </summary>
        void CloseAnimated();
        
        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        UniTask WaitUntilCloseClicked();
    }
}
#endif

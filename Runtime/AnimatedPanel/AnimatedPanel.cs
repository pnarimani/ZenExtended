#if OPEN_JUICE && UNITASK

using System;

#if ODIN_INSPECTOR
#elif NAUGHTY_ATTRIBUTES
#endif

namespace ZenExtended
{
    /// <summary>
    /// A class that you can use if you don't want your main class to inherit from <see cref="AnimatedPanel{T}"/>.
    /// (Or you are using SubContainers and you want this class to be part of composition).
    /// In that case, subscribe to <see cref="DisposeRequested"/> event from your main class and when the event is fired dispose the panel. 
    /// </summary>
    public sealed class AnimatedPanel : AnimatedPanel<AnimatedPanel>
    {
        /// <summary>
        /// DisposeRequired is fired when all exit transitions have been played and now it's time to deactivate the panel.
        /// </summary>
        public event Action DisposeRequested;

        public override void Dispose()
        {
            DisposeRequested?.Invoke();
        }
    }
}
#endif
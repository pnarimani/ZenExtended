#if OPEN_JUICE && UNITASK
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZenExtended
{
    public class AnimatedPanel<T> : MonoSpawnable<T>, IAnimatedPanel
    {
        [SerializeField] private AnimatedPanelComponents _animatedPanel;

        private AnimatedPanelLogic _logic;

        public float TransitionDuration => _logic.TransitionDuration;

        protected virtual void Awake()
        {
            _logic = new AnimatedPanelLogic(gameObject, _animatedPanel, Dispose);
            _logic.Awake();
        }

        protected virtual void OnEnable()
        {
            _logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated panel with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TClass}.Dispose"/>.
        /// </summary>
        public void CloseAnimated()
        {
            _logic.OnCloseClicked().Forget();
        }

        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        public UniTask WaitUntilCloseClicked()
        {
            return _logic.WaitUntilCloseClick();
        }
    }

    public class AnimatedPanel<TParam1, T> : MonoSpawnable<TParam1, T>, IAnimatedPanel
    {
        [SerializeField] private AnimatedPanelComponents _animatedPanel;
        private AnimatedPanelLogic _logic;

        public float TransitionDuration => _logic.TransitionDuration;

        protected virtual void Awake()
        {
            _logic = new AnimatedPanelLogic(gameObject, _animatedPanel, Dispose);
            _logic.Awake();
        }

        protected virtual void OnEnable()
        {
            _logic.OnEnable();
        }
        
        /// <summary>
        /// Closes the animated panel with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam, TClass}.Dispose"/>.
        /// </summary>
        public void CloseAnimated()
        {
            _logic.OnCloseClicked().Forget();
        }
        
        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        public UniTask WaitUntilCloseClicked()
        {
            return _logic.WaitUntilCloseClick();
        }
    }

    public class AnimatedPanel<TParam1, TParam2, T> : MonoSpawnable<TParam1, TParam2, T>, IAnimatedPanel
    {
        [SerializeField] private AnimatedPanelComponents _animatedPanel;
        private AnimatedPanelLogic _logic;

        public float TransitionDuration => _logic.TransitionDuration;

        protected virtual void Awake()
        {
            _logic = new AnimatedPanelLogic(gameObject, _animatedPanel, Dispose);
            _logic.Awake();
        }

        protected virtual void OnEnable()
        {
            _logic.OnEnable();
        }
        
        /// <summary>
        /// Closes the animated panel with playing outro animations. This has the same functionality has pressing the close button.
           /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TClass}.Dispose"/>.
        /// </summary>
        public void CloseAnimated()
        {
            _logic.OnCloseClicked().Forget();
        }
        
        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        public UniTask WaitUntilCloseClicked()
        {
            return _logic.WaitUntilCloseClick();
        }
    }

    public class AnimatedPanel<TParam1, TParam2, TParam3, T> : MonoSpawnable<TParam1, TParam2, TParam3, T>, IAnimatedPanel
    {
        [SerializeField] private AnimatedPanelComponents _animatedPanel;
        private AnimatedPanelLogic _logic;

        public float TransitionDuration => _logic.TransitionDuration;

        protected virtual void Awake()
        {
            _logic = new AnimatedPanelLogic(gameObject, _animatedPanel, Dispose);
            _logic.Awake();
        }

        protected virtual void OnEnable()
        {
            _logic.OnEnable();
        }
        
        /// <summary>
        /// Closes the animated panel with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParma3, TClass}.Dispose"/>.
        /// </summary>
        public void CloseAnimated()
        {
            _logic.OnCloseClicked().Forget();
        }

        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        public UniTask WaitUntilCloseClicked()
        {
            return _logic.WaitUntilCloseClick();
        }
    }
}
#endif
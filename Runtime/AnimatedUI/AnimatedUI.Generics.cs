#if OPEN_JUICE && UNITASK
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ZenExtended
{
    public class AnimatedUI<T> : MonoSpawnable<T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options;

        private AnimatedUILogic? _logic;

        private AnimatedUILogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new AnimatedUILogic(gameObject, _options, Dispose);
                return _logic.Value;
            }
        }

        protected Button CloseButton => _options?.CloseButton;

        public float TransitionDuration => Logic.TransitionDuration;

        protected virtual void Awake()
        {
            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TClass}.Dispose"/>.
        /// </summary>
        public void CloseAnimated()
        {
            Logic.OnCloseClicked().Forget();
        }

        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        public UniTask WaitUntilCloseClicked()
        {
            return Logic.WaitUntilCloseClick();
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            Logic.ValidateTransitions();
        }
#endif
    }

    public class AnimatedUI<TParam1, T> : MonoSpawnable<TParam1, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options;

        private AnimatedUILogic? _logic;

        private AnimatedUILogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new AnimatedUILogic(gameObject, _options, Dispose);
                return _logic.Value;
            }
        }

        protected Button CloseButton => _options?.CloseButton;

        public float TransitionDuration => Logic.TransitionDuration;

        protected virtual void Awake()
        {
            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam, TClass}.Dispose"/>.
        /// </summary>
        public void CloseAnimated()
        {
            Logic.OnCloseClicked().Forget();
        }

        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        public UniTask WaitUntilCloseClicked()
        {
            return Logic.WaitUntilCloseClick();
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            Logic.ValidateTransitions();
        }
#endif
    }

    public class AnimatedUI<TParam1, TParam2, T> : MonoSpawnable<TParam1, TParam2, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options;

        private AnimatedUILogic? _logic;

        private AnimatedUILogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new AnimatedUILogic(gameObject, _options, Dispose);
                return _logic.Value;
            }
        }

        protected Button CloseButton => _options?.CloseButton;
        public float TransitionDuration => Logic.TransitionDuration;

        protected virtual void Awake()
        {
            _logic = new AnimatedUILogic(gameObject, _options, Dispose);
            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TClass}.Dispose"/>.
        /// </summary>
        public void CloseAnimated()
        {
            Logic.OnCloseClicked().Forget();
        }

        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        public UniTask WaitUntilCloseClicked()
        {
            return Logic.WaitUntilCloseClick();
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            Logic.ValidateTransitions();
        }
#endif
    }

    public class AnimatedUI<TParam1, TParam2, TParam3, T> : MonoSpawnable<TParam1, TParam2, TParam3, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options;

        private AnimatedUILogic? _logic;

        private AnimatedUILogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new AnimatedUILogic(gameObject, _options, Dispose);
                return _logic.Value;
            }
        }

        protected Button CloseButton => _options?.CloseButton;
        public float TransitionDuration => Logic.TransitionDuration;

        protected virtual void Awake()
        {
            _logic = new AnimatedUILogic(gameObject, _options, Dispose);
            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParma3, TClass}.Dispose"/>.
        /// </summary>
        public void CloseAnimated()
        {
            Logic.OnCloseClicked().Forget();
        }

        /// <summary>
        /// Waits until the close button is clicked (or <see cref="CloseAnimated"/> is called)
        /// </summary>
        public UniTask WaitUntilCloseClicked()
        {
            return Logic.WaitUntilCloseClick();
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            Logic.ValidateTransitions();
        }
#endif
    }
}
#endif

#if OPEN_JUICE && UNITASK
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ZenExtended
{
    /// <summary>
    /// Base class for all animated UI elements which accepts 0 runtime parameters
    /// </summary>
    public abstract class AnimatedUI< T> : MonoSpawnable< T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{ TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{ TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 1 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, T> : MonoSpawnable<TParam1, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 2 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, TParam2, T> : MonoSpawnable<TParam1, TParam2, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

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
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 3 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, TParam2, TParam3, T> : MonoSpawnable<TParam1, TParam2, TParam3, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 4 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, TParam2, TParam3, TParam4, T> : MonoSpawnable<TParam1, TParam2, TParam3, TParam4, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 5 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, TParam2, TParam3, TParam4, TParam5, T> : MonoSpawnable<TParam1, TParam2, TParam3, TParam4, TParam5, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 6 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, T> : MonoSpawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 7 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, T> : MonoSpawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 8 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, T> : MonoSpawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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

    /// <summary>
    /// Base class for all animated UI elements which accepts 9 runtime parameters
    /// </summary>
    public abstract class AnimatedUI<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, T> : MonoSpawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, T>, IAnimatedUI
    {
        [FormerlySerializedAs("_animatedPanel")] [SerializeField]
        private AnimatedUIOptions _options = new AnimatedUIOptions();

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

        public AnimatedUIOptions AnimatedUIOptions => _options;
        public float TransitionDuration => Logic.TransitionDuration;
        protected Button CloseButton => _options?.CloseButton;

        protected virtual void Awake()
        {
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(CloseAnimated);

            Logic.Awake();
        }

        protected virtual void OnEnable()
        {
            Logic.OnEnable();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TClass}.Dispose"/>.
        /// </summary>
        public virtual void CloseAnimated()
        {
            CloseAnimatedAsync().Forget();
        }

        /// <summary>
        /// Closes the animated ui with playing outro animations. This has the same functionality has pressing the close button.
        /// If you don't want to play outro animations, use <see cref="MonoSpawnable{TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TClass}.Dispose"/>.
        /// </summary>
        public virtual UniTask CloseAnimatedAsync()
        {
            return Logic.OnCloseClicked();
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
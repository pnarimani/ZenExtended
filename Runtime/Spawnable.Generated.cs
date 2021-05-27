
using System;
using UnityEngine;
using Zenject;

namespace ZenExtended
{
    public abstract class Spawnable< TClass> : IPoolable< IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable< IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable< IMemoryPool>.OnSpawned( IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned();
        }

        protected virtual void OnPoolSpawned()
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory< TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TClass> : IPoolable<TParam1, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, IMemoryPool>.OnSpawned(TParam1 param1, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1);
        }

        protected virtual void OnPoolSpawned(TParam1 param1)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TParam2, TClass> : IPoolable<TParam1, TParam2, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, TParam2, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, IMemoryPool>.OnSpawned(TParam1 param1, TParam2 param2, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1, param2);
        }

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TParam2, TParam3, TClass> : IPoolable<TParam1, TParam2, TParam3, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, TParam2, TParam3, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, TParam3, IMemoryPool>.OnSpawned(TParam1 param1, TParam2 param2, TParam3 param3, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1, param2, param3);
        }

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TParam2, TParam3, TParam4, TClass> : IPoolable<TParam1, TParam2, TParam3, TParam4, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, TParam2, TParam3, TParam4, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, TParam3, TParam4, IMemoryPool>.OnSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1, param2, param3, param4);
        }

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TClass> : IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, IMemoryPool>.OnSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1, param2, param3, param4, param5);
        }

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TClass> : IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, IMemoryPool>.OnSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1, param2, param3, param4, param5, param6);
        }

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TClass> : IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, IMemoryPool>.OnSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1, param2, param3, param4, param5, param6, param7);
        }

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TClass> : IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, IMemoryPool>.OnSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1, param2, param3, param4, param5, param6, param7, param8);
        }

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TClass>
        {
        }
    }
    public abstract class Spawnable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TClass> : IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (ReferenceEquals(animatedUI, this))
                return;
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, IMemoryPool>.OnSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param1, param2, param3, param4, param5, param6, param7, param8, param9);
        }

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

        public virtual void Dispose()
        {
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TClass>
        {
        }
    }
}
using System;
using UnityEngine;
using Zenject;

namespace ZenExtended
{
    public abstract class MonoSpawnable<TClass> : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
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

        void IPoolable<IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<IMemoryPool>.OnSpawned(IMemoryPool pool)
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
            if (this == null || gameObject == null)
                return;

            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TClass>
        {
        }
    }

    public abstract class MonoSpawnable<TParam1, TClass> : MonoBehaviour, IPoolable<TParam1, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        protected virtual void OnPoolSpawned(TParam1 param1)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

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

        public virtual void Dispose()
        {
            if (this == null || gameObject == null)
                return;

            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TClass>
        {
        }
    }

    public abstract class MonoSpawnable<TParam1, TParam2, TClass> : MonoBehaviour, IPoolable<TParam1, TParam2, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

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

        public virtual void Dispose()
        {
            if (this == null || gameObject == null)
                return;

            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TClass>
        {
        }
    }

    public abstract class MonoSpawnable<TParam1, TParam2, TParam3, TClass> : MonoBehaviour, IPoolable<TParam1, TParam2, TParam3, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

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

        public virtual void Dispose()
        {
            if (this == null || gameObject == null)
                return;

            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TClass>
        {
        }
    }

    public abstract class MonoSpawnable<TParam1, TParam2, TParam3, TParam4, TClass> : MonoBehaviour, IPoolable<TParam1, TParam2, TParam3, TParam4, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

#if OPEN_JUICE && UNITASK
        [Inject]
        private void GetAnimatedUI([InjectOptional] AnimatedUI animatedUI)
        {
            if (animatedUI != null)
                animatedUI.DisposeRequested += Dispose;
        }
#endif

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
        {
        }

        protected virtual void OnPoolDespawned()
        {
        }

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

        public virtual void Dispose()
        {
            if (this == null || gameObject == null)
                return;

            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TClass>
        {
        }
    }
}
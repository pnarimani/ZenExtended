using System;
using Zenject;

namespace ZenExtended
{
    public abstract class Spawnable<TClass> : IPoolable<IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

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
            if (_isPooled)
            {
                _pool?.Despawn(this);
                _pool = null;
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class Factory : PlaceholderFactory<TClass>
        {
        }
    }

    public abstract class Spawnable<TParam1, TClass> : IPoolable<TParam1, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        private bool _isPooled;

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
}
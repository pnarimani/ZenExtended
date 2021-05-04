using System;
using UnityEngine;
using Zenject;

namespace ZenExtended
{
    public abstract class MonoSpawnable<TClass> : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
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
        { }

        public void Dispose()
        {
            if (this == null)
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

        protected virtual void OnPoolSpawned(TParam1 param1)
        {
        }

        protected virtual void OnPoolDespawned()
        { }

        void IPoolable<TParam1, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, IMemoryPool>.OnSpawned(TParam1 param, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param);
        }

        public void Dispose()
        {
            if (this == null)
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

        protected virtual void OnPoolSpawned(TParam1 param1, TParam2 param2)
        {
        }

        protected virtual void OnPoolDespawned()
        { }

        void IPoolable<TParam1, TParam2, IMemoryPool>.OnDespawned()
        {
            OnPoolDespawned();
        }

        void IPoolable<TParam1, TParam2, IMemoryPool>.OnSpawned(TParam1 param, TParam2 param2, IMemoryPool pool)
        {
            _pool = pool;
            _isPooled = true;
            OnPoolSpawned(param, param2);
        }

        public void Dispose()
        {
            if (this == null)
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
}
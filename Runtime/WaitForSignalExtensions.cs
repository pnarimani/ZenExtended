#if UNITASK

using Cysharp.Threading.Tasks;
using Zenject;

namespace ZenExtended
{
    public static class WaitForSignalExtensions
    {
        public static UniTask<T> WaitForSignal<T>(this SignalBus signalBus)
        {
            var source = AutoResetUniTaskCompletionSource<T>.Create();
            signalBus.Subscribe<T>(Received);
            return source.Task;

            void Received(T t)
            {
                signalBus.Unsubscribe<T>(Received);
                source.TrySetResult(t);
            }
        }
    }
}
#endif
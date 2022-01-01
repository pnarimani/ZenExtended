#if UNITASK && (OPEN_JUICE || ANIMATION_SEQUENCER)
using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using YoYoStudio.OpenJuice;

namespace ZenExtended
{
    // Using this class as composition since we don't have multi inheritance in C# 
    internal readonly struct AnimatedUILogic
    {
        private readonly Queue<AutoResetUniTaskCompletionSource> _waitForClose;
        private readonly GameObject _gameObject;
        private readonly Dictionary<RectTransform, TransformInfo> _originalStates;
        private readonly AnimatedUIOptions _options;
        private readonly Action _dispose;
        private readonly CancellationToken _cancellationToken;

        public AnimatedUILogic(GameObject gameObject, AnimatedUIOptions options, Action dispose)
        {
            _dispose = dispose;
            _options = options;
            _waitForClose = new Queue<AutoResetUniTaskCompletionSource>();
            _originalStates = new Dictionary<RectTransform, TransformInfo>();
            _gameObject = gameObject;
            _cancellationToken = gameObject.GetCancellationTokenOnDestroy();
        }

#if OPEN_JUICE
        public float TransitionDuration => _options.PrimaryTransition != null ? _options.PrimaryTransition.Duration + _options.PrimaryTransition.Delay : 0;
#else
        public float TransitionDuration => _options.Sequence.PlayingSequence.Duration();
#endif

        public void Awake()
        {
            ValidateTransitions();
        }

        public void OnEnable()
        {
#if OPEN_JUICE
            if (_originalStates.Count == 0)
            {
                // We don't want to call ForceUpdateCanvases when un-animated ui is showing up.
                if (_options.PrimaryTransition != null)
                    Canvas.ForceUpdateCanvases();
            }

            CaptureOriginalStates();

            if (_options.PrimaryTransition != null)
                _options.PrimaryTransition.Play(_cancellationToken);

            foreach (BaseTransition t in _options.SecondaryTransitions)
            {
                if (t == null)
                    continue;

                RestoreTransformState(t);
                t.Play(_cancellationToken);
            }
#endif
        }

        public UniTask WaitUntilCloseClick()
        {
            if (!_gameObject.activeSelf)
                return UniTask.CompletedTask;

            var tcs = AutoResetUniTaskCompletionSource.Create();
            _waitForClose.Enqueue(tcs);
            return tcs.Task;
        }

        public async UniTask OnCloseClicked()
        {
            while (_waitForClose.Count > 0)
            {
                try
                {
                    _waitForClose.Dequeue().TrySetResult();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            if (_options.PlayReverseOnClose)
            {
#if OPEN_JUICE
                foreach (BaseTransition t in _options.SecondaryTransitions)
                {
                    if (t == null)
                        continue;

                    if (!t.gameObject.activeSelf)
                        continue;

                    // We don't await here because:
                    // 1. We want all secondary transitions to play at once
                    // 2. We want to call dispose only after the primary transition has ended.
                    // ReSharper disable once MethodHasAsyncOverload
                    t.PlayReverse(_cancellationToken);
                }

                if (_options.PrimaryTransition != null)
                    await _options.PrimaryTransition.PlayReverseAsync(_cancellationToken);
#else
                _options.Sequence.PlayingSequence.timeScale = _options.RewindTimescale;
                _options.Sequence.PlayingSequence.Goto(TransitionDuration);
                _options.Sequence.PlayingSequence.PlayBackwards();
                await UniTask.Delay(TimeSpan.FromSeconds(TransitionDuration / _options.RewindTimescale));
#endif
            }

            _dispose();

#if OPEN_JUICE
            RestoreTransformState(_options.PrimaryTransition);
            foreach (BaseTransition t in _options.SecondaryTransitions)
            {
                RestoreTransformState(t);
            }
#endif
        }

        public void ValidateTransitions()
        {
#if OPEN_JUICE
            if (_options.PrimaryTransition != null)
                _options.PrimaryTransition.PlayOnEnable = !_options.PrimaryTransition.gameObject.activeSelf;

            if (_options.SecondaryTransitions != null)
            {
                foreach (BaseTransition t in _options.SecondaryTransitions)
                {
                    if (t != null)
                        t.PlayOnEnable = !t.gameObject.activeSelf;
                }
            }
#endif
        }

        private void RestoreTransformState(BaseTransition transition)
        {
            if (transition == null)
                return;

            var casted = (RectTransform) transition.transform;

            if (_originalStates.ContainsKey(casted))
                _originalStates[casted].ApplyTo(casted);
        }

        private void CaptureOriginalStates()
        {
#if OPEN_JUICE
            Add(_originalStates, _options.PrimaryTransition);
            foreach (BaseTransition t in _options.SecondaryTransitions)
            {
                Add(_originalStates, t);
            }


            static void Add(Dictionary<RectTransform, TransformInfo> dict, BaseTransition t)
            {
                if (t == null)
                    return;

                var casted = (RectTransform) t.transform;
                if (!dict.ContainsKey(casted))
                    dict.Add(casted, new TransformInfo(casted));
            }
#endif
        }
    }
}
#endif
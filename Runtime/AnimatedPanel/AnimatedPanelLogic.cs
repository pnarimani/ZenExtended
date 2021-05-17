#if UNITASK && OPEN_JUICE
using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YoYoStudio.OpenJuice;

namespace ZenExtended
{
    // Using this class as composition since we don't have multi inheritance in C# 
    internal readonly struct AnimatedPanelLogic
    {
        private readonly Queue<AutoResetUniTaskCompletionSource> _waitForClose;
        private readonly GameObject _gameObject;
        private readonly Dictionary<RectTransform, TransformInfo> _originalStates;
        private readonly AnimatedPanelOptions _options;
        private readonly Action _dispose;
        private readonly CancellationToken _cancellationToken;

        public AnimatedPanelLogic(GameObject gameObject, AnimatedPanelOptions options, Action dispose)
        {
            _dispose = dispose;
            _options = options;
            _waitForClose = new Queue<AutoResetUniTaskCompletionSource>();
            _originalStates = new Dictionary<RectTransform, TransformInfo>();
            _gameObject = gameObject;
            _cancellationToken = gameObject.GetCancellationTokenOnDestroy();
        }

        public float TransitionDuration => _options.PrimaryTransition != null ? _options.PrimaryTransition.Duration + _options.PrimaryTransition.Delay : 0;

        public void Awake()
        {
            ValidateTransitions();
            if (_options.CloseButton != null)
                _options.CloseButton.onClick.AddListener(UniTask.UnityAction(OnCloseClicked));
        }

        public void OnEnable()
        {
            if (_originalStates.Count == 0)
            {
                // We don't want to call ForceUpdateCanvases when un-animated panel is showing up.
                if (_options.PrimaryTransition != null)
                    Canvas.ForceUpdateCanvases();
                
                CaptureOriginalStates();
            }

            if (_options.PrimaryTransition != null)
                _options.PrimaryTransition.Play(_cancellationToken);

            foreach (BaseTransition t in _options.SecondaryTransitions)
            {
                if (t == null)
                    continue;

                RestoreTransformState(t);
                t.Play(_cancellationToken);
            }
        }

        public UniTask WaitUntilCloseClick()
        {
            if (!_gameObject.activeSelf)
                return UniTask.CompletedTask;

            var tcs = AutoResetUniTaskCompletionSource.Create();
            _waitForClose.Enqueue(tcs);
            return tcs.Task;
        }

        public async UniTaskVoid OnCloseClicked()
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
                foreach (BaseTransition t in _options.SecondaryTransitions)
                {
                    if (t == null)
                        continue;

                    // We don't await here because:
                    // 1. We want all secondary transitions to play at once
                    // 2. We want to call dispose only after the primary transition has ended.
                    // ReSharper disable once MethodHasAsyncOverload
                    t.PlayReverse(_cancellationToken);
                }

                if (_options.PrimaryTransition != null)
                    await _options.PrimaryTransition.PlayReverseAsync(_cancellationToken);
            }

            _dispose();

            RestoreTransformState(_options.PrimaryTransition);
            foreach (BaseTransition t in _options.SecondaryTransitions)
            {
                RestoreTransformState(t);
            }
        }

        public void ValidateTransitions()
        {
            if (_options.PrimaryTransition != null)
                _options.PrimaryTransition.PlayOnEnable = false;

            if (_options.SecondaryTransitions != null)
            {
                foreach (BaseTransition t in _options.SecondaryTransitions)
                {
                    if (t != null)
                        t.PlayOnEnable = false;
                }
            }
        }

        private void RestoreTransformState(BaseTransition transition)
        {
            if (transition == null)
                return;
            _originalStates[(RectTransform) transition.transform].ApplyTo((RectTransform) transition.transform);
        }

        private void CaptureOriginalStates()
        {
            Add(_originalStates, _options.PrimaryTransition);
            foreach (BaseTransition st in _options.SecondaryTransitions)
            {
                Add(_originalStates, st);
            }


            static void Add(Dictionary<RectTransform, TransformInfo> dict, BaseTransition t)
            {
                if (t == null)
                    return;

                var casted = (RectTransform) t.transform;
                if (!dict.ContainsKey(casted))
                    dict.Add(casted, new TransformInfo(casted));
            }
        }
    }
}
#endif
#if UNITASK && OPEN_JUICE
using System;
using System.Collections.Generic;
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
        private readonly Action _dispose;
        private readonly Button _close;
        private readonly BaseTransition _primaryTransition;
        private readonly BaseTransition[] _secondaryTransitions;
        private readonly Dictionary<RectTransform, TransformInfo> _originalStates;

        public AnimatedPanelLogic(GameObject gameObject, AnimatedPanelComponents components, Action dispose)
        {
            _waitForClose = new Queue<AutoResetUniTaskCompletionSource>();
            _originalStates = new Dictionary<RectTransform, TransformInfo>();
            _gameObject = gameObject;
            _dispose = dispose;
            _secondaryTransitions = components.SecondaryTransitions;
            _primaryTransition = components.PrimaryTransition;
            _close = components.CloseButton;
        }

        public float TransitionDuration => _primaryTransition != null ? _primaryTransition.Duration + _primaryTransition.Delay : 0;

        public void Awake()
        {
            ValidateTransitions();
            CaptureOriginalStates();
            if (_close != null)
                _close.onClick.AddListener(UniTask.UnityAction(OnCloseClicked));
        }

        public void OnEnable()
        {
            RestoreTransformState(_primaryTransition);

            if (_primaryTransition != null)
                _primaryTransition.Play();

            foreach (BaseTransition t in _secondaryTransitions)
            {
                if (t == null)
                    continue;
                
                RestoreTransformState(t);
                t.Play();
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

            foreach (BaseTransition t in _secondaryTransitions)
            {
                if (t == null)
                    continue;

                // We don't await here because:
                // 1. We want all secondary transitions to play at once
                // 2. We want to call dispose only after the primary transition has ended.
                // ReSharper disable once MethodHasAsyncOverload
                t.PlayReverse();
            }

            if (_primaryTransition != null)
                await _primaryTransition.PlayReverseAsync();

            _dispose();
        }

        private void ValidateTransitions()
        {
            if (_primaryTransition != null)
                _primaryTransition.PlayOnEnable = false;

            if (_secondaryTransitions != null)
            {
                foreach (BaseTransition t in _secondaryTransitions)
                {
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
            Add(_originalStates, _primaryTransition);
            foreach (BaseTransition st in _secondaryTransitions)
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
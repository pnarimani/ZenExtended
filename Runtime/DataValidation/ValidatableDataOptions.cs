using System;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#elif NAUGHTY_ATTRIBUTES
using NaughtyAttributes;
using ValueDropdown = NaughtyAttributes.DropdownAttribute;
#endif
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace ZenExtended.DataValidation
{
#if ODIN_INSPECTOR
    [BoxGroup]
#endif
    [Serializable]
    public class ValidatableDataOptions : IValidatableData
    {
        [SerializeField] private bool _allowInNonDevBuilds = true;

        [SerializeField] private bool _validatePackageName;

#if ODIN_INSPECTOR || NAUGHTY_ATTRIBUTES
        [ShowIf(nameof(_validatePackageName))]
#endif
        [SerializeField]
        private string _targetPackageName;

        [SerializeField] private bool _validatePlatform;

#if ODIN_INSPECTOR || NAUGHTY_ATTRIBUTES
        [ShowIf(nameof(_validatePlatform))]
        [ValueDropdown("TargetPlatformOptions")]
#endif
        [SerializeField]
        private string _targetPlatform;

        [SerializeField] private bool _checkScriptingDefineSymbols;

#if ODIN_INSPECTOR || NAUGHTY_ATTRIBUTES
        [ShowIf(nameof(_checkScriptingDefineSymbols))]
#endif
        [SerializeField]
        private string[] _scriptingDefineSymbols;

#if UNITY_EDITOR && (ODIN_INSPECTOR || NAUGHTY_ATTRIBUTES)
        private string[] TargetPlatformOptions => Enum.GetNames(typeof(BuildTargetGroup));
#endif

        public int TargetPlatform
        {
            get
            {
#if UNITY_EDITOR

                if (!Enum.TryParse(_targetPlatform, out BuildTargetGroup target))
                    target = BuildTargetGroup.Unknown;

                return (int) target;
#else
                return 0;
#endif
            }
        }

        public bool ValidatePackageName => _validatePackageName;
        public string TargetPackageName => _targetPackageName;
        public bool ValidatePlatform => _validatePlatform;
        public bool AllowInNonDevBuilds => _allowInNonDevBuilds;
        public bool CheckScriptingDefineSymbols => _checkScriptingDefineSymbols;
        public string[] ScriptingDefineSymbols => _scriptingDefineSymbols;
    }
}
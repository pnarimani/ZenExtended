using UnityEngine;

namespace ZenExtended.DataValidation
{
    public abstract class ValidatableData : ScriptableObject, IValidatableData
    {
        [SerializeField]
        private ValidatableDataOptions _validatableData;

        bool IValidatableData.ValidatePackageName => ((IValidatableData) _validatableData).ValidatePackageName;

        string IValidatableData.TargetPackageName => ((IValidatableData) _validatableData).TargetPackageName;

        bool IValidatableData.ValidatePlatform => ((IValidatableData) _validatableData).ValidatePlatform;

        int IValidatableData.TargetPlatform => ((IValidatableData) _validatableData).TargetPlatform;

        bool IValidatableData.AllowInNonDevBuilds => ((IValidatableData) _validatableData).AllowInNonDevBuilds;

        bool IValidatableData.CheckScriptingDefineSymbols => ((IValidatableData) _validatableData).CheckScriptingDefineSymbols;

        string[] IValidatableData.ScriptingDefineSymbols => ((IValidatableData) _validatableData).ScriptingDefineSymbols;
    }
}
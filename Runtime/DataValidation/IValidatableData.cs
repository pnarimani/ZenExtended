namespace ZenExtended.DataValidation
{
    public interface IValidatableData
    {
        bool ValidatePackageName { get; }
        
        string TargetPackageName { get; }
        
        bool ValidatePlatform { get; }
        
        int TargetPlatform { get; }

        bool AllowInNonDevBuilds { get; }
        
        bool CheckScriptingDefineSymbols { get; }
        
        string[] ScriptingDefineSymbols { get; }
    }
}
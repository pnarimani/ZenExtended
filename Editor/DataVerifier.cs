using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using ZenExtended.DataValidation;

namespace ZenExtended.Editor
{
    public class DataVerifier : IPreprocessBuildWithReport
    {
        public int callbackOrder { get; }

        public void OnPreprocessBuild(BuildReport report)
        {
            List<DataInstallerBase> installers = AssetDatabase.FindAssets("t:" + nameof(DataInstallerBase))
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<DataInstallerBase>)
                .ToList();

            foreach (DataInstallerBase installer in installers)
            {
                SerializedObject obj = new SerializedObject(installer);

                SerializedProperty iterator = obj.GetIterator();

                while (iterator.NextVisible(true))
                {
                    if (iterator.propertyType != SerializedPropertyType.ObjectReference)
                        continue;

                    if (iterator.objectReferenceValue == null)
                        throw new BuildFailedException($"Field `{iterator.name}` is not assigned in DataInstaller `{installer.name}`");

                    var validatableData = iterator.objectReferenceValue as IValidatableData;

                    if (validatableData == null)
                        continue;

                    if (validatableData.ValidatePackageName && PlayerSettings.applicationIdentifier != validatableData.TargetPackageName)
                        throw new BuildFailedException($"Failed to validate field `{iterator.name}` in `{installer.name}`. Package Name Validation Failed. Package Name in Data: `{validatableData.TargetPackageName}`, Package Name in Player Settings: `{PlayerSettings.applicationIdentifier}`.");

                    if (validatableData.ValidatePlatform && report.summary.platformGroup != (BuildTargetGroup) validatableData.TargetPlatform)
                        throw new BuildFailedException($"Failed to validate field `{iterator.name}` in `{installer.name}`. Build Platform Group Validation Failed. Build Group in Data: `{(BuildTarget) validatableData.TargetPlatform}`, Selected Build Group: `{report.summary.platformGroup}`.");

                    if (!validatableData.AllowInNonDevBuilds && (report.summary.options & BuildOptions.Development) == 0)
                        throw new BuildFailedException($"Failed to validate field `{iterator.name}` in `{installer.name}`. Current assigned object is not allowed to be in non-development builds.");


                    if (validatableData.CheckScriptingDefineSymbols)
                    {
                        DefineSymbolOrGroup[] symbols = validatableData.ScriptingDefineSymbols
                            .Select(s => s.Split(new[] {" OR "}, StringSplitOptions.RemoveEmptyEntries))
                            .Select(g => new DefineSymbolOrGroup {Symbols = new List<string>(g)})
                            .ToArray();

                        PlayerSettings.GetScriptingDefineSymbolsForGroup(report.summary.platformGroup, out string[] defined);

                        foreach (DefineSymbolOrGroup g in symbols)
                        {
                            g.Symbols.RemoveAll(string.IsNullOrEmpty);
                            bool check = g.Symbols.Any(s =>
                            {
                                bool presence = !s.StartsWith("!");
                                return defined.Any(definedSymbol => definedSymbol.Equals(s.Trim('!'))) == presence;
                            });

                            if (!check)
                            {
                                List<string> expectedDefinesList = g.Symbols.Where(x => !x.StartsWith("!")).ToList();
                                string expectedDefines = "";
                                if (expectedDefinesList.Count > 0)
                                    expectedDefines = expectedDefinesList.Aggregate((s, s1) => s + "/" + s1);

                                List<string> notExpectedDefinesList = g.Symbols.Where(x => x.StartsWith("!")).Select(s => s.TrimStart('!')).ToList();
                                string notExpectedDefines = "";
                                if (notExpectedDefinesList.Count > 0)
                                    notExpectedDefines = notExpectedDefinesList.Aggregate((s, s1) => s + "/" + s1);

                                throw new BuildFailedException($"Failed to validate field `{iterator.name}` in `{installer.name}`. Scripting Define Symbol check failed. " +
                                                               $"`{iterator.name}` expects one of `{expectedDefines}` to be defined or one of `{notExpectedDefines}` to not be defined.");
                            }
                        }
                    }
                }
            }
        }

        private struct DefineSymbolOrGroup
        {
            public List<string> Symbols;
        }
    }
}
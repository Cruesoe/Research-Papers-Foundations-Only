using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using BetterResearchMenu;

namespace ResearchPapersFoundationsOnly
{
    [StaticConstructorOnStartup]
    public static class ResearchPapersFoundationsOnlyMod
    {
        static ResearchPapersFoundationsOnlyMod()
        {
            new Harmony("cruesoe.researchpapersfoundationsonly").PatchAll();
        }
    }

    // Targets Research Papers by name, so the mod builds without its assembly
    [HarmonyPatch]
    public static class Patch_Utilities_IsExcluded
    {
        public static MethodBase TargetMethod()
        {
            return AccessTools.Method("ResearchPapers.Utilities:IsExcluded", new[] { typeof(ResearchProjectDef) });
        }

        public static void Postfix(ResearchProjectDef project, ref bool __result)
        {
            if (__result)
            {
                return;
            }

            if (!project.IsFoundation())
            {
                __result = true;
            }
        }
    }
}

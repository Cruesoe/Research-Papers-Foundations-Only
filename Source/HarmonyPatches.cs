using HarmonyLib;
using RimWorld;
using Verse;
using ResearchPapers;
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

    [HarmonyPatch(typeof(Utilities), nameof(Utilities.IsExcluded))]
    public static class Patch_Utilities_IsExcluded
    {
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

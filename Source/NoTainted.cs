using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace NoTainted;

public class NoTaintedMod : Mod
{
    public NoTaintedMod(ModContentPack content) : base(content)
    {
        new Harmony("tiagocc0.notainted").PatchAll();
    }
}

// lets the vanilla method run (comps still need Notify_WearerDied) and puts the tainted flag back
[HarmonyPatch(typeof(Apparel), nameof(Apparel.Notify_PawnKilled))]
public static class Apparel_Notify_PawnKilled_Patch
{
    public static void Prefix(Apparel __instance, out bool __state)
    {
        __state = __instance.WornByCorpse;
    }

    public static void Postfix(Apparel __instance, bool __state)
    {
        __instance.WornByCorpse = __state;
    }
}

// same thing for pawns turning into shamblers (Anomaly)
[HarmonyPatch(typeof(Pawn_MutantTracker), "HandleEquipment")]
public static class Pawn_MutantTracker_HandleEquipment_Patch
{
    public static void Prefix(Pawn ___pawn, out List<(Apparel apparel, bool wornByCorpse)> __state)
    {
        __state = new List<(Apparel, bool)>();
        if (___pawn.apparel == null)
        {
            return;
        }
        foreach (Apparel apparel in ___pawn.apparel.WornApparel)
        {
            __state.Add((apparel, apparel.WornByCorpse));
        }
    }

    public static void Postfix(List<(Apparel apparel, bool wornByCorpse)> __state)
    {
        foreach ((Apparel apparel, bool wornByCorpse) in __state)
        {
            apparel.WornByCorpse = wornByCorpse;
        }
    }
}

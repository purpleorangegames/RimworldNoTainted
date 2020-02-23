using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Verse;

using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Verse.Steam;

namespace NoTainted
{
    [StaticConstructorOnStartup]
    class NoTainted : Mod
    {
        public NoTainted(ModContentPack content) : base(content)
        {
            var harmony = new Harmony("net.pog.rimworld.mod.notainted");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }

    [HarmonyPatch(typeof(Apparel))]
    [HarmonyPatch(nameof(Apparel.Notify_PawnKilled))]
    class Patch
    {
        static bool Prefix()
        {
            //Log.Error("Is it running?", false);
            return false;
        }
    }

}

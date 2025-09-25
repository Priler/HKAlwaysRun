using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

[BepInPlugin("com.priler.hkalwaysrun", "HK Always Run", "1.0.0")]
public class HKMod : BaseUnityPlugin
{
    internal new static ManualLogSource Logger;

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo("Plugin loaded and initialized.");

        Harmony.CreateAndPatchAll(typeof(HKMod), null);
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(HeroController), "Move")]
    private static void MovePrefix(HeroController __instance, float move_direction)
    {
        __instance.playerData.equippedCharm_37 = !__instance.cState.nearBench;
    }
}
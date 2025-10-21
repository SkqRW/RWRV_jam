using BepInEx;
using BepInEx.Logging;
using System.Drawing;
using System;
using System.Security.Permissions;
using LDEBUG = Plugin.DevTools;

namespace RoomsScripts;

class ShelterTravel
{
    private static string denA = "CC_S05";
    private static string denB = "SL_S13";

    public static void Init()
    {
        On.SaveState.LoadGame += SaveState_LoadGame;
    }

    private static void SaveState_LoadGame(On.SaveState.orig_LoadGame orig, SaveState self, string str, RainWorldGame game)
    {
        orig(self, str, game);

        if (self.denPosition == denA)
        {
            self.denPosition = denB;
            UnityEngine.Debug.Log($"Changin from {denA} to {denB}");
            return;
        }

        if (self.denPosition == denB)
        {
            self.denPosition = denA;
            UnityEngine.Debug.Log($"Changin from {denB} to {denA}");
            return;
        }
    }
}


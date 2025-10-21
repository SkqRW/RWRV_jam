using BepInEx;
using BepInEx.Logging;
using System.Drawing;
using System;
using System.Security.Permissions;
using LDEBUG = Plugin.DevTools;

// Allows access to private members
#pragma warning disable CS0618
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618

namespace Plugin;

[BepInPlugin("rwrv.jam", "RWRV Region Jam", "0.0.1")]
sealed class Plugin : BaseUnityPlugin
{
    public static new ManualLogSource Logger;
    bool IsInit;

    public void OnEnable()
    {
        Logger = base.Logger;
        On.RainWorld.OnModsInit += OnModsInit;
    }

    private void OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);

        if (IsInit) return;
        IsInit = true;

        // Initialize assets, your mod config, and anything that uses RainWorld here
        Logger.LogDebug("Hello world!");

        On.PlayerGraphics.DrawSprites += PlayerGraphics_DrawSprites;
        RoomsScripts.ShelterTravel.Init();

    }

    private void PlayerGraphics_DrawSprites(On.PlayerGraphics.orig_DrawSprites orig, PlayerGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, UnityEngine.Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        if (self.player.slugcatStats.name != SlugcatStats.Name.White) return;
        sLeaser.sprites[2].color = UnityEngine.Color.magenta;
    }

}

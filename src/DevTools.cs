using UnityEngine;
using LDEBUG = Plugin.DevTools;
using System;
namespace Plugin;

//Custom functions to test the code, i test some PlayerUpdateEnlightenedElectricExplosion here
class DevTools
{
    public static void Initialize()
    {
        On.Player.Update += Player_Update;
        //On.PlayerGraphics.DrawSprites += VisualFormToSeeIfTheModIsEnabled;
    }

    public static void Terminate()
    {

        On.Player.Update -= Player_Update;
        //On.PlayerGraphics.DrawSprites += VisualFormToSeeIfTheModIsEnabled;
    }

    private static void VisualFormToSeeIfTheModIsEnabled(On.PlayerGraphics.orig_DrawSprites orig, PlayerGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        orig(self, sLeaser, rCam, timeStacker, camPos);
        sLeaser.sprites[3].color = Color.red;
    }

    private static void Player_Update(On.Player.orig_Update orig, Player self, bool eu)
    {
        orig(self, eu);
            newKey(self); 
        
        //LDEBUG.Log("Player Update called for Enlightened slugcat: " + self.slugcatStats.name);
    }

    private static bool DevLight = false;

    //Debug custom keys 
    private static void newKey(Player self)
    {
        //LDEBUG.LogInfo("DevLight status: " + self.room.GetWorldCoordinate(self.mainBodyChunk.pos) + ", DevToolsActive: " + self.mainBodyChunk.pos);

        if (!DevLight && !self.room.game.devToolsActive)
        {
            return;
        }

        
    }

  

    // Custom Log message
    public static void Log(string msg)
    {
        UnityEngine.Debug.Log("[Enlightened] " + msg);
    }

    public static void LogInfo(string msg)
    {
        UnityEngine.Debug.Log("[INFO Enlightened] " + msg);
    }

    public static void LogWarn(string msg)
    {
        UnityEngine.Debug.Log("[WARN Enlightened] " + msg);
    }

    public static void LogERR(string msg)
    {
        UnityEngine.Debug.Log("[ERR Enlightened] " + msg);
    }
}

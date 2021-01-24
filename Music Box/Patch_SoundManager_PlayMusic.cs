using HarmonyLib;
using XRL.Core;
using XRL.World.Parts;

[HarmonyPatch(typeof(SoundManager))]
[HarmonyPatch("PlayMusic")]
class helado_MusicBox_Patch_SoundManager_PlayMusic
{
    static bool Prefix()
    {
        // If the music lock is on, do not allow tracks to be changed.
        return !helado_MusicBox_MusicPlayer.IsMusicLockOn();
    }
}

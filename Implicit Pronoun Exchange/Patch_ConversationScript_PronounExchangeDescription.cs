using HarmonyLib;
using XRL.World.Parts;

[HarmonyPatch(typeof(ConversationScript))]
[HarmonyPatch("PronounExchangeDescription")]
public class helado_ImplicitPronounExchange_Patch_ConversationScript_PronounExchangeDescription
{
    public static bool Prefix(string __result)
    {
        __result = null;
        return false;
    }
}

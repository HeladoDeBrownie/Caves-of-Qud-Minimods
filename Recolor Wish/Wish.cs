using XRL; // The
using static XRL.UI.Popup; // ShowColorPicker
using XRL.Wish; // HasWishCommand, WishCommand
using XRL.World.Parts; // HDBrownie_RecolorWish_Recolor

[HasWishCommand]
public static class HDBrownie_RecolorWish_WishHandler
{
    [WishCommand(Command = "recolor")]
    public static void HandleRecolorWish()
    {
        var recolor = The.Player.RequirePart<HDBrownie_RecolorWish_Recolor>();
        recolor.ForegroundColor = ShowColorPicker("Choose a main color.");
        recolor.DetailColor = ShowColorPicker("Choose a detail color.");
    }

    [WishCommand(Command = "unrecolor")]
    public static void HandleUnrecolorWish()
    {
        The.Player.RemovePart<HDBrownie_RecolorWish_Recolor>();
    }
}

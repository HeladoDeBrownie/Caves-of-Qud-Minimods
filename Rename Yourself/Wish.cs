using static XRL.UI.Popup;  // AskString, Show
using XRL.Wish;
using XRL.World;

[HasWishCommand]
public static class helado_RenameYourself_WishHandler
{
    public const string WISH_NAME = "renameme";

    [WishCommand(Command = WISH_NAME)]
    public static bool HandleWish()
    {
        var newName = AskString("What will you be known as?");

        if (newName == "")
        {
            Show("Okay, never mind then.");
        } else {
            XRL.Core.XRLCore.Core.Game.Player.Body.DisplayName = newName;
            Show($"Welcome to your new name, {newName}!");
        }

        return true;
    }
}

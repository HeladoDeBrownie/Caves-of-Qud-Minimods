using System.Collections.Generic; // List
using System.Text.RegularExpressions; // Match
using XRL; // The
using static XRL.UI.Popup;  // Show
using XRL.Wish; // HasWishCommand, WishCommand
using XRL.World.Parts; // LiquidVolume

[HasWishCommand]
public static class helado_LiquidWish_WishHandler
{
    public const string WISH_NAME = "liquid";

    [WishCommand(Regex = "^liquid:(.+):(.+)$")]
    public static void HandleWish(Match match)
    {
        var liquid = match.Groups[1].Value;
        int drams = 100;
        int.TryParse(match.Groups[2].Value, out drams);

        var currentCell = The.Player.CurrentCell;
        var targetCell = currentCell.GetRandomLocalAdjacentCell(cell =>
            !cell.HasOpenLiquidVolume()
        );

        if (targetCell == currentCell)
        {
            Show("I need an adjacent cell with no open liquid in it.");
        }
        else
        {
            targetCell.AddObject(
                LiquidVolume.create(new List<string> { liquid }, drams)
            );
        }
    }
}

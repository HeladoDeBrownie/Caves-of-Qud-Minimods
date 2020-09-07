using static XRL.UI.Popup;

public class helado_MutationBGone_Wish
{
    [XRL.Wish.WishCommand(Command = "mutationbgone")]
    public static bool MutationBGone()
    {
        Show("Usage:\n\nmutationbgone:[mutation id]");
        return true;
    }

    [XRL.Wish.WishCommand(Command = "mutationbgone")]
    public static bool MutationBGone(string argument)
    {
        var mutations = XRL.Core.XRLCore.Core.Game.Player.Body.GetPart<XRL.World.Parts.Mutations>();
        var chosenMutation = mutations.GetMutation(argument);

        if (chosenMutation == null)
        {
            Show("Didn't find that one. Try again?");
        }
        else
        {
            mutations.RemoveMutation(chosenMutation);
            Show("Om nom nom! It's gone!");
        }

        return true;
    }
}

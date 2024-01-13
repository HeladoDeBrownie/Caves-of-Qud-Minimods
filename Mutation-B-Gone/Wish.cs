using static XRL.UI.Popup;
using XRL.Wish;
using XRL.World.Parts;
using XRL.World.Parts.Mutation;

public class HDBrownie_MutationBGone_Wish
{
    public const string WishName = "mutationbgone";

    [WishCommand(Command = WishName)]
    public static bool MutationBGone()
    {
        var mutations = GetMutations();
        var mutationList = mutations.MutationList;

        if (mutationList.Count > 0)
        {
            var index = ShowOptionList(
                Title: "Choose a mutation for me to gobble up!",

                Options: mutationList.ConvertAll(delegate (BaseMutation mutation)
                {
                    return mutation.DisplayName;
                }).ToArray(),

                AllowEscape: true
            );

            if (index != -1)
            {
                RemoveMutation(mutations, mutationList[index]);
            }
        }
        else
        {
            Show("Huh? Get some mutations first if you want me to eat them!");
        }

        return true;
    }

    [WishCommand(Command = WishName)]
    public static bool MutationBGone(string mutationName)
    {
        var mutations = GetMutations();
        var chosenMutation = mutations.GetMutation(mutationName);

        if (chosenMutation == null)
        {
            Show("Didn't find that one. Maybe try wishing just {{Y|mutationbgone}}?");
        }
        else
        {
            RemoveMutation(mutations, chosenMutation);
        }

        return true;
    }

    public static Mutations GetMutations()
    {
        return XRL.Core.XRLCore.Core.Game.Player.Body.GetPart<Mutations>();
    }

    public static void RemoveMutation(Mutations mutations, BaseMutation mutation)
    {
        mutations.RemoveMutation(mutation);
        Show($"Om nom nom! {mutation.DisplayName} is gone! {{{{w|*belch*}}}}");
    }
}

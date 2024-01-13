using XRL.World;

namespace XRL.World.Parts
{
    public class HDBrownie_WantMeFearMe_Cap : IPart
    {
        public override void Attach()
        {
            var desiredFaction = Factions.GetRandomFaction();

            var reviledFaction =
                75.in100()      ? Factions.Get("Fish")
                /* otherwise */ : Factions.GetRandomFaction();

            ParentObject.AddPart(new AddsRep(desiredFaction.Name,  100));
            ParentObject.AddPart(new AddsRep(reviledFaction.Name, -100));

            ParentObject.GetPart<Description>().Short = $"A legend boldly proclaims the allegiances of the wearer of this strange piece of billed fabric for all to see:\n\nI am desired by {desiredFaction.GetFormattedName()}\nAnd reviled by {reviledFaction.GetFormattedName()}";
        }
    }
}

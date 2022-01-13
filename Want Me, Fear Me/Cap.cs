using XRL.World;

namespace XRL.World.Parts
{
    public class helado_WantMeFearMe_Cap : IPart
    {
        public override void Attach()
        {
            var desiredFaction = Factions.GetRandomFaction();

            var reviledFaction =
                75.in100()      ? Factions.get("Fish")
                /* otherwise */ : Factions.GetRandomFaction();

            ParentObject.AddPart(new AddsRep(desiredFaction.Name,  100));
            ParentObject.AddPart(new AddsRep(reviledFaction.Name, -100));

            ParentObject.GetPart<Description>().Short = $"A legend boldly proclaims the allegiances of the wearer of this strange piece of billed fabric for all to see:\n\nI am desired by {desiredFaction.getFormattedName()}\nAnd reviled by {reviledFaction.getFormattedName()}";
        }
    }
}

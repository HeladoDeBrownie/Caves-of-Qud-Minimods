using System; // Serializable

namespace XRL.World.Parts
{
    [Serializable]
    public class HDBrownie_CorralCourtesy_Autoclose : IPart
    {
        public override bool WantEvent(int ID, int cascade)
        {
            return
                base.WantEvent(ID, cascade)
                || ID == ObjectLeavingCellEvent.ID
            ;
        }

        public override bool HandleEvent(ObjectLeavingCellEvent @event)
        {
            var door = ParentObject.GetPart<Door>();

            if (
                @event.Actor.IsPlayer() &&
                door != null &&
                !@event.Forced
            )
            {
                // At this moment, the player is still in the same cell as the
                // door, so cannot close it yet. I'm not aware of an event that
                // fires later than ObjectLeavingCellEvent on objects in the
                // vacated cell, so we use a part to delay the closing until
                // we're sure the player has vacated the cell.
                @event.Actor.AddPart(
                    new HDBrownie_CorralCourtesy_AboutToClose
                    {
                        Door = ParentObject
                    }
                );
            }

            return base.HandleEvent(@event);
        }
    }

    public class HDBrownie_CorralCourtesy_AboutToClose : IPart
    {
        public GameObject Door;

        public override bool WantEvent(int ID, int cascade)
        {
            return
                base.WantEvent(ID, cascade)
                || ID == EnteredCellEvent.ID
            ;
        }

        public override bool HandleEvent(EnteredCellEvent @event)
        {
            // As of 2.0.204.102, `AttemptClose` does not check for the
            // `Grazer` tag. In order to prevent the player from closing a door
            // they cannot open again, `AttemptOpen` is used here instead,
            // which does the check and then turns into `AttemptClose` if the
            // door is already open.
            var door = Door?.GetPart<Door>();
            if (door != null && door.bOpen)
            {
                door.AttemptOpen(
                    Opener: ParentObject,
                    FromMove: true,
                    Silent: true
                );
            }

            ParentObject.RemovePart(this);
            return base.HandleEvent(@event);
        }
    }
}

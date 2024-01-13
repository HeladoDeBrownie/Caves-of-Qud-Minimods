namespace XRL.World.Parts
{
    [System.Serializable]
    public class HDBrownie_PetSaver_PetSaver : IPart
    {
        public override bool WantEvent(int id, int _)
        {
            return
                id == ObjectCreatedEvent.ID ||
                base.WantEvent(id, _);
        }

        public override bool HandleEvent(ObjectCreatedEvent _)
        {
            if (ParentObject.HasTag("Pet"))
            {
                ParentObject.RequirePart<NoDamage>();
            }

            return true;
        }
    }
}

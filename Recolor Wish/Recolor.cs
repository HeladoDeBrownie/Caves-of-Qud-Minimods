namespace XRL.World.Parts
{
    public class HDBrownie_RecolorWish_Recolor : IPart
    {
        public string ForegroundColor;
        public string DetailColor;

        // XRL.Parts.Mutation.PhotosyntheticSkin does this same thing.
        public static readonly int ICON_COLOR_PRIORITY = 80;

        public override bool Render(RenderEvent @event)
        {
            if (!string.IsNullOrEmpty(ForegroundColor))
            {
                @event.ApplyColors($"&{ForegroundColor}", ICON_COLOR_PRIORITY);
            }

            if (!string.IsNullOrEmpty(DetailColor))
            {
                @event.ApplyDetailColor(DetailColor, ICON_COLOR_PRIORITY);
            }

            return true;
        }
    }
}

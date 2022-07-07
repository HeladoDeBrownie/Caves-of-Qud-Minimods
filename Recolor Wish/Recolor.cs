namespace XRL.World.Parts
{
    public class helado_RecolorWish_Recolor : IPart
    {
        public string ForegroundColor;
        public string DetailColor;

        public override bool Render(RenderEvent @event)
        {
            if (!string.IsNullOrEmpty(ForegroundColor))
            {
                @event.ColorString = $"&{ForegroundColor}";
            }

            if (!string.IsNullOrEmpty(DetailColor))
            {
                @event.DetailColor = DetailColor;
            }

            return true;
        }
    }
}

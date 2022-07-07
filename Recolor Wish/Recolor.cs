namespace XRL.World.Parts
{
    public class helado_RecolorWish_Recolor : IPart
    {
        public string ForegroundColor;
        public string DetailColor;

        public override bool Render(RenderEvent @event)
        {
            if (ForegroundColor != null)
            {
                @event.ColorString = $"&{ForegroundColor}";
            }

            if (DetailColor != null)
            {
                @event.DetailColor = DetailColor;
            }

            return true;
        }
    }
}

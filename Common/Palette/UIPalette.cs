using Microsoft.Xna.Framework;

namespace Selenate.Common.Palette
{
    // To-Do: Make the palette customizable.
    public class UIPalette
    {
        public static class Defaults
        {
            public static Color PanelBackground => new Color(60, 65, 70) * 0.7f;

            public static Color PanelBorder => new Color(220, 225, 250);

            public static Color ButtonActiveImage => Color.White;

            public static Color ButtonInactiveImage => Color.White * 0.7f;

            public static Color ButtonActiveBackground => Color.White * 0.33f;

            public static Color ButtonInactiveBackground => Color.Transparent;

            public static Color ButtonOutline => new Color(255, 215, 125) * 0.9f;
        }

        public static Color PanelBackground { get; private set; } = Defaults.PanelBackground;

        public static Color PanelBorder { get; private set; } = Defaults.PanelBorder;

        public static Color ButtonActiveImage { get; private set; } = Defaults.ButtonActiveImage;

        public static Color ButtonInactiveImage { get; private set; } = Defaults.ButtonInactiveImage;

        public static Color ButtonActiveBackground { get; private set; } = Defaults.ButtonActiveBackground;

        public static Color ButtonInactiveBackground { get; private set; } = Defaults.ButtonInactiveBackground;

        public static Color ButtonOutline { get; private set; } = Defaults.ButtonOutline;
    }
}

using Selenate.Common.UI;
using System.Collections.Generic;

namespace Selenate.Content.UI
{
    public class HotBar : SUIPanel
    {
        public static IList<HotBarIcon> LoadedFeatures { get; set; } = new List<HotBarIcon>();

        public override void OnInitialize()
        {
            SUIButtonDisplay mainHotBar = new SUIButtonDisplay();

            // Stinky code notice: these values are throwaways because they're needed to properly calculate the inner dimensions.
            mainHotBar.Width.Pixels = LoadedFeatures.Count * 100;
            mainHotBar.Height.Pixels = 100;

            mainHotBar.AddRange(LoadedFeatures);
            mainHotBar.Recalculate();
            float width = mainHotBar.InnerListWidth;
            float height = mainHotBar.GetTotalHeight();
            Append(mainHotBar);

            Width.Pixels = PaddingLeft + PaddingRight + width;
            Height.Pixels = height + PaddingTop + PaddingBottom;
        }
    }
}
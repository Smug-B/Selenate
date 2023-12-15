using Selenate.Common.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenate.Content.UI
{
    public class HotBar : SUIPanel
    {
        public static IList<HotBarIcon> LoadedFeatures { get; set; } = new List<HotBarIcon>();

        public override void OnInitialize()
        {
            int interIconPadding = 4;
            Height.Pixels = 44 + PaddingTop + PaddingBottom;

            int left = 0;
            // Consider: should a new instance be created?
            foreach (HotBarIcon icon in LoadedFeatures)
            {
                icon.Left.Pixels = left;
                Append(icon);

                left += 44 + interIconPadding;
            }

            Width.Pixels = left + PaddingLeft + PaddingRight;
        }
    }
}
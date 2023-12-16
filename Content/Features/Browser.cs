﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Selenate.Content.UI;
using System.Collections.Generic;
using Terraria;

namespace Selenate.Content.Features
{
    public class Browser : HotBarIcon
    {
        public static IList<HotBarIcon> BrowserFeatures { get; private set; } = new List<HotBarIcon>();

        public Browser() : base()
        {
            OnLeftClick += Browser_OnLeftClick;
        }

        private void Browser_OnLeftClick(Terraria.UI.UIMouseEvent evt, Terraria.UI.UIElement listeningElement)
        {
            if (Parent.Parent.Parent.Parent is not HotBar hotBar)
            {
                return;
            }

            if (Toggle == true)
            {
                hotBar.PopulateSecondaryHotBar(BrowserFeatures);
                hotBar.SecondaryHotBarActive = true;
            }
            else
            {
                hotBar.SecondaryHotBarActive = false;
            }
        }
    }
}
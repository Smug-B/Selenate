using Microsoft.Xna.Framework;
using Selenate.Common.UI;
using System;
using System.Collections.Generic;
using Terraria.UI;

namespace Selenate.Content.UI
{
    public class HotBar : UIElement
    {
        public static IList<HotBarIcon> LoadedFeatures { get; private set; } = new List<HotBarIcon>();

        public SUIPanel MainBackground { get; private set; }

        public SUIButtonDisplay MainHotBar { get; private set; }

        protected SUITransPanel SecondaryBackground { get; private set; }

        protected SUIButtonDisplay SecondaryHotBar { get; set; }

        public bool SecondaryHotBarActive { get => SecondaryBackground.Active; set => SecondaryBackground.Active = value; }

        public override void OnInitialize()
        {
            SecondaryBackground = new SUITransPanel(Vector2.Zero, new Vector2(0, 100));
            SecondaryBackground.HAlign = 0.5f;
            SecondaryBackground.VAlign = 1f;
            SecondaryHotBar = new SUIButtonDisplay();
            SecondaryBackground.Append(SecondaryHotBar);
            Append(SecondaryBackground);

            MainBackground = new SUIPanel();
            MainBackground.VAlign = 1f;
            MainHotBar = new SUIButtonDisplay();
            PopulateHotBar(MainHotBar, LoadedFeatures, out float width, out float height);
            MainBackground.Width.Set(MainBackground.PaddingLeft + MainBackground.PaddingRight + width, 0);
            MainBackground.Height.Set(MainBackground.PaddingTop + MainBackground.PaddingBottom + height, 0);
            MainBackground.Append(MainHotBar);
            Append(MainBackground);

            Width.Pixels = MainBackground.Width.Pixels;
            Height.Pixels = MainBackground.Height.Pixels * 2 + 10;
        }

        protected void PopulateHotBar(SUIButtonDisplay hotBar, IList<HotBarIcon> hotBarIcons, out float width, out float height, int constructionSize = 100)
        {
            hotBar.Clear();
            // Stinky code notice: these values are throwaways because they're needed to properly calculate the inner dimensions.
            hotBar.Width.Pixels = hotBarIcons.Count * constructionSize;
            hotBar.Height.Pixels = constructionSize;
            hotBar.AddRange(hotBarIcons);
            hotBar.Recalculate();
            width = hotBar.InnerListWidth;
            height = hotBar.GetTotalHeight();
        }

        public virtual void PopulateSecondaryHotBar(IList<HotBarIcon> hotBarIcons, int constructionSize = 100)
        {
            SecondaryBackground.Width.Pixels = hotBarIcons.Count * constructionSize;
            SecondaryBackground.Height.Pixels = constructionSize;
            SecondaryBackground.Recalculate();
            PopulateHotBar(SecondaryHotBar, hotBarIcons, out float width, out float height, constructionSize);
            SecondaryBackground.Width.Set(SecondaryBackground.PaddingLeft + SecondaryBackground.PaddingRight + width, 0);
            SecondaryBackground.Height.Set(SecondaryBackground.PaddingTop + SecondaryBackground.PaddingBottom + height, 0);
            SecondaryBackground.ToPosPixel = new Vector2(0, -MainBackground.Height.Pixels);
            SecondaryBackground.Visible = true;
        }

        public override void Update(GameTime gameTime)
        {
            // Recalculate();
            base.Update(gameTime);
        }
    }
}
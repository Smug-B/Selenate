using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        protected SUIPanel SecondaryBackground { get; private set; }

        protected SUIButtonDisplay SecondaryHotBar { get; set; }

        public bool SecondaryHotBarActive { get; set; }

        public float SecondaryHotBarTransition
        {
            get => secondaryHotBarTransition;
            set => secondaryHotBarTransition = Math.Clamp(value, 0f, 1f);
        }

        private float secondaryHotBarTransition;

        public float SecondaryHotBarTransitionValue { get; set; } = 0.1f;

        public override async void OnInitialize()
        {
            SecondaryBackground = new SUIPanel();
            SecondaryBackground.Top.Pixels = 10;
            SecondaryHotBar = new SUIButtonDisplay();
            SecondaryBackground.VAlign = 1f;
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
        }

        public override void Update(GameTime gameTime)
        {
            SecondaryHotBarTransition += SecondaryHotBarActive ? SecondaryHotBarTransitionValue : -SecondaryHotBarTransitionValue;

            SecondaryBackground.Top.Pixels = MainBackground.Height.Pixels + 10 - (MainBackground.Height.Pixels + SecondaryBackground.Height.Pixels + 10) * SecondaryHotBarTransition;
            // Recalculate();
            base.Update(gameTime);
        }
    }
}
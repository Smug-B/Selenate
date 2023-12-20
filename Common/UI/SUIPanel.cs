using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Selenate.Common.Palette;
using Terraria.GameContent.UI.Elements;

namespace Selenate.Common.UI
{
    public class SUIPanel : UIPanel
    {
        // To-Do: Make visibility impact whether or not this element can be interacted with, but better.
        public bool Visible
        {
            get => visible;
            set
            {
                visible = value;
                IgnoresMouseInteraction = !visible;
            }
        }

        private bool visible = true;

        public SUIPanel() :
            base(Selenate.Request<Texture2D>("Assets/UI/PanelBackground"), Selenate.Request<Texture2D>("Assets/UI/PanelBorder")) => DefaultColors();

        public SUIPanel(Asset<Texture2D> background, Asset<Texture2D> border, int cornerSize = 12, int barSize = 4) :
            base(background, border, cornerSize, barSize) => DefaultColors();

        public void DefaultColors()
        {
            BorderColor = UIPalette.PanelBorder;
            BackgroundColor = UIPalette.PanelBackground;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible)
            {
                return;
            }

            base.Draw(spriteBatch);
        }
    }
}
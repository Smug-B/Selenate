using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Selenate.Content.UI;
using Terraria;
using Terraria.ModLoader;

namespace Selenate.Content.Features
{
    public class ItemBrowser : HotBarIcon
    {
        public ItemBrowser() : base()
        {
        }

        public override void Load(Mod mod)
        {
            Browser.BrowserFeatures.Add(this);
        }

        public override void DrawImage(SpriteBatch spriteBatch, Rectangle dimensions)
        {
            Texture2D texture = Image.Value;
            if (texture == null)
            {
                return;
            }

            spriteBatch.Draw(texture, dimensions.Center(), null, ImageColor, 0f, texture.Size() / 2 - new Vector2(2, 4), 1f, SpriteEffects.None, 0f);
        }
    }
}
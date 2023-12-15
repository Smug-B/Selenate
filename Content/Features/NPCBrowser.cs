using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Selenate.Content.UI;
using Terraria;

namespace Selenate.Content.Features
{
    public class NPCBrowser : HotBarIcon
    {
        public NPCBrowser() : base()
        {
        }

        public override void DrawImage(SpriteBatch spriteBatch, Rectangle dimensions)
        {
            Texture2D texture = Image.Value;
            if (texture == null)
            {
                return;
            }

            Vector2 frameSize = new Vector2(texture.Width, texture.Height / 2);
            Vector2 origin = frameSize / 2 - new Vector2(2, 4);
            spriteBatch.Draw(texture, dimensions.Center(), new Rectangle(0, 0, (int)frameSize.X, (int)frameSize.Y), ImageColor, 0f, origin, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture, dimensions.Center(), new Rectangle(0, (int)frameSize.Y, (int)frameSize.X, (int)frameSize.Y), ImageColor, 0f, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ModLoader;
using Selenate.Common.UI;

namespace Selenate.Content.UI
{
    public abstract class HotBarIcon : SUIImageButton, ILoadable
    {
        public IList<HotBarIcon> MutuallyExclusiveIcons;

        public HotBarIcon() : base(null)
        {
            // Icons are ideally 40x40.
            Image = ModContent.Request<Texture2D>(GetType().FullName.Replace('.', '/'));
            Width.Pixels = 44;
            Height.Pixels = 44;
        }

        public void Load(Mod mod)
        {
            HotBar.LoadedFeatures.Add(this);
        }

        public void Unload() { }
    }
}
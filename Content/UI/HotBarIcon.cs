using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ModLoader;
using Selenate.Common.UI;

namespace Selenate.Content.UI
{
    public abstract class HotBarIcon : SUIImageButton, ILoadable
    {
        // To-Do: Investigate if splitting and joining is faster than replacing twice. 
        public string TexturePath => GetType().FullName.Replace('.', '/').Replace("Selenate/Content", "Assets");

        public IList<HotBarIcon> MutuallyExclusiveIcons;

        public HotBarIcon() : base(null)
        {
            // Icons are ideally 40x40.
            Image = Selenate.Request<Texture2D>(TexturePath);
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
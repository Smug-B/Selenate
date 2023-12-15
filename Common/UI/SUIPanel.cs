using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Selenate.Common.Palette;
using Terraria.GameContent.UI.Elements;

namespace Selenate.Common.UI
{
	public class SUIPanel : UIPanel
	{
		public SUIPanel() : 
			base(Selenate.Request<Texture2D>("Assets/UI/PanelBackground"), Selenate.Request<Texture2D>("Assets/UI/PanelBorder")) => DefaultColors();

		public SUIPanel(Asset<Texture2D> background, Asset<Texture2D> border, int cornerSize = 12, int barSize = 4) :
			base(background, border, cornerSize, barSize) => DefaultColors();

		public void DefaultColors()
		{
			BorderColor = UIPalette.PanelBorder;
			BackgroundColor = UIPalette.PanelBackground;
		}
	}
}
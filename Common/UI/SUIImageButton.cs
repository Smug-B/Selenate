using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Selenate.Common.Palette;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.UI;

namespace Selenate.Common.UI
{
	public class SUIImageButton : UIElement
	{
		public Asset<Texture2D> Image { get; set; }

		/// <summary>
		/// null: not togglable 
		/// true: toggled
		/// false: not toggled
		/// </summary>
		public bool? Toggle { get; set; }

		public Color ImageColor => Toggle == true ? ActiveImageColor : Color.Lerp(InactiveImageColor, ActiveImageColor, ActivityLerp.Value);

		public Color ActiveImageColor { get; set; } = UIPalette.ButtonActiveImage;

		public Color InactiveImageColor { get; set; } = UIPalette.ButtonInactiveImage;

		public Asset<Texture2D> BackgroundTexture { get; set; }

		public Color BackgroundColor => Toggle == true ? ActiveBackgroundColor : Color.Lerp(InactiveBackgroundColor, ActiveBackgroundColor, ActivityLerp.Value);

		public Color ActiveBackgroundColor { get; set; } = UIPalette.ButtonActiveBackground;

		public Color InactiveBackgroundColor { get; set; } = UIPalette.ButtonInactiveBackground;
		
		public float? ActivityLerp
		{
			get => activityLerp;
			set => activityLerp = value.HasValue ? activityLerp = Math.Clamp(value.Value, 0f, 1f) : null;
		}

		private float? activityLerp = 0f;

		public float ActivityLerpValue { get; set; } = 0.1f;

		public Asset<Texture2D> OutlineTexture { get; set; }

		public Color OutlineColor { get; set; } = UIPalette.ButtonOutline;

        public int CornerSize { get; set; } = 12;

		public int BarSize { get; set; } = 4;

		public SoundStyle? HoverSound { get; set; }

		public SoundStyle? ClickSound { get; set; }

		public SUIImageButton(Asset<Texture2D> imageAsset, bool isTogglable = true)
		{
			Image = imageAsset;
			Toggle = isTogglable ? false : null;
			BackgroundTexture = Selenate.Request<Texture2D>("Assets/UI/ButtonBackground");
			OutlineTexture = Selenate.Request<Texture2D>("Assets/UI/ButtonOutline");
		}

		public override void LeftClick(UIMouseEvent evt)
		{
			if (Toggle.HasValue)
			{
				Toggle = !Toggle;
			}

			if (ClickSound.HasValue)
			{
				SoundStyle style = ClickSound.Value;
				SoundEngine.PlaySound(in style);
			}

			base.LeftClick(evt);
		}

		public override void Update(GameTime gameTime) => ActivityLerp += IsMouseHovering ? ActivityLerpValue : -ActivityLerpValue;

		public override void MouseOver(UIMouseEvent evt)
		{
			if (HoverSound.HasValue)
			{
				SoundStyle style = HoverSound.Value;
				SoundEngine.PlaySound(in style);
			}

			base.MouseOver(evt);
		}

		private void NineSlice(SpriteBatch spriteBatch, Texture2D texture, Rectangle dimensions, Color color)
		{
			Point topLeft = dimensions.Location;
			Point bottomRight = new Point(dimensions.Right - CornerSize, dimensions.Bottom - CornerSize);
			int width = bottomRight.X - topLeft.X - CornerSize;
			int height = bottomRight.Y - topLeft.Y - CornerSize;
			spriteBatch.Draw(texture, new Rectangle(topLeft.X, topLeft.Y, CornerSize, CornerSize), new Rectangle(0, 0, CornerSize, CornerSize), color);
			spriteBatch.Draw(texture, new Rectangle(bottomRight.X, topLeft.Y, CornerSize, CornerSize), new Rectangle(CornerSize + BarSize, 0, CornerSize, CornerSize), color);
			spriteBatch.Draw(texture, new Rectangle(topLeft.X, bottomRight.Y, CornerSize, CornerSize), new Rectangle(0, CornerSize + BarSize, CornerSize, CornerSize), color);
			spriteBatch.Draw(texture, new Rectangle(bottomRight.X, bottomRight.Y, CornerSize, CornerSize), new Rectangle(CornerSize + BarSize, CornerSize + BarSize, CornerSize, CornerSize), color);
			spriteBatch.Draw(texture, new Rectangle(topLeft.X + CornerSize, topLeft.Y, width, CornerSize), new Rectangle(CornerSize, 0, BarSize, CornerSize), color);
			spriteBatch.Draw(texture, new Rectangle(topLeft.X + CornerSize, bottomRight.Y, width, CornerSize), new Rectangle(CornerSize, CornerSize + BarSize, BarSize, CornerSize), color);
			spriteBatch.Draw(texture, new Rectangle(topLeft.X, topLeft.Y + CornerSize, CornerSize, height), new Rectangle(0, CornerSize, CornerSize, BarSize), color);
			spriteBatch.Draw(texture, new Rectangle(bottomRight.X, topLeft.Y + CornerSize, CornerSize, height), new Rectangle(CornerSize + BarSize, CornerSize, CornerSize, BarSize), color);
			spriteBatch.Draw(texture, new Rectangle(topLeft.X + CornerSize, topLeft.Y + CornerSize, width, height), new Rectangle(CornerSize, CornerSize, BarSize, BarSize), color);
		}

		public virtual void DrawBackground(SpriteBatch spriteBatch, Rectangle dimensions)
		{
			if (BackgroundTexture.Value == null)
			{
				return;
			}

			NineSlice(spriteBatch, BackgroundTexture.Value, dimensions, BackgroundColor);
		}

		public virtual void DrawImage(SpriteBatch spriteBatch, Rectangle dimensions)
		{
			Texture2D texture = Image.Value;
			if (texture == null)
			{
				return;
			}

			spriteBatch.Draw(texture, dimensions.Center(), null, ImageColor, 0f, texture.Size() / 2, 1f, SpriteEffects.None, 0f);
		}

		public virtual void DrawOutline(SpriteBatch spriteBatch, Rectangle dimensions)
		{
			if (Toggle == false || OutlineTexture.Value == null)
			{
				return;
			}

			Rectangle outlineRect = dimensions;
			outlineRect.Inflate(2, 2);
			NineSlice(spriteBatch, OutlineTexture.Value, outlineRect, OutlineColor);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Rectangle dimensions = GetDimensions().ToRectangle();

			DrawBackground(spriteBatch, dimensions);
			DrawImage(spriteBatch, dimensions);
			DrawOutline(spriteBatch, dimensions);
		}
	}
}

using Microsoft.Xna.Framework;
using System;

namespace Selenate.Common.UI
{
    public class SUITransPanel : SUIPanel
    {
        public Vector2 ToPosPixel { get; set; }

        public Vector2 FromPosPixel { get; set; }

        public bool Active { get; set; }

        public float TransProgress
        {
            get => transProgress;
            set => transProgress = Math.Clamp(value, 0f, 1f);
        }

        private float transProgress;

        public float TransValue { get; set; } = 0.1f;

        public SUITransPanel(Vector2 toPos, Vector2 fromPos)
        {
            ToPosPixel = toPos;
            FromPosPixel = fromPos;
            Left.Pixels = FromPosPixel.X;
            Top.Pixels = FromPosPixel.Y;
        }

        public override void Update(GameTime gameTime)
        {
            TransProgress += Active ? TransValue : -TransValue;

            Vector2 posDifference = ToPosPixel - FromPosPixel;
            Left.Pixels = FromPosPixel.X + posDifference.X * TransProgress;
            Top.Pixels = FromPosPixel.Y + posDifference.Y * TransProgress;

            base.Update(gameTime);
        }
    }
}

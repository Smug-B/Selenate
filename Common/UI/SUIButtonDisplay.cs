using Microsoft.Xna.Framework;
using System;
using System.Reflection;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Selenate.Common.UI
{
    public class SUIButtonDisplay : UIList
    {
        public static readonly FieldInfo InnerListHeight = typeof(UIList).GetField("_innerListHeight", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        public int MaxAxialElements
        {
            get => maxAxialElements;
            set
            {
                maxAxialElements = value;
                Recalculate();
            }
        }

        private int maxAxialElements;

        public bool PrioritizeVerticalGrowth
        {
            get => prioritizeVerticalGrowth;
            set
            {
                prioritizeVerticalGrowth = value;
                Recalculate();
            }
        }

        private bool prioritizeVerticalGrowth;

        // Inconsistent with Vanilla's UIList but God, that's garbage.
        public float InnerListWidth { get; protected set; }

        public SUIButtonDisplay(int allottedAxialElements = -1) : base()
        {
            maxAxialElements = allottedAxialElements;
        }

        public override void RecalculateChildren()
        {
            base.RecalculateChildren();

            if (_items.Count == 0)
            {
                return;
            }

            Vector2 inner = Vector2.Zero;
            Vector2 max = Vector2.Zero;
            float padding = _items.Count == 1 ? 0f : ListPadding;

            int totalElements = 0;
            int maxAxialElements = MaxAxialElements >= 0 ? MaxAxialElements : _items.Count;
            while (true)
            {
                float largestGrowth = 0;
                for (int i = 0; i < maxAxialElements; i++)
                {
                    UIElement currentElement = _items[totalElements];
                    currentElement.Left.Set(inner.X, 0);
                    currentElement.Top.Set(inner.Y, 0);
                    currentElement.Recalculate();

                    float elementWidth = currentElement.GetOuterDimensions().Width;
                    float elementHeight = currentElement.GetOuterDimensions().Height;
                    float widthGrowth = inner.X + elementWidth + padding;
                    float heightGrowth = inner.Y + elementHeight + padding;

                    max.X = Math.Max(max.X, widthGrowth);
                    max.Y = Math.Max(max.Y, heightGrowth);

                    float consideredAxis = PrioritizeVerticalGrowth ? elementWidth : elementHeight;
                    if (largestGrowth < consideredAxis)
                    {
                        largestGrowth = consideredAxis;
                    }

                    if (PrioritizeVerticalGrowth)
                    {
                        inner.Y = heightGrowth;
                    }
                    else
                    {
                        inner.X += elementWidth + padding;
                    }

                    if (++totalElements >= _items.Count)
                    {
                        InnerListWidth = max.X - padding;
                        InnerListHeight.SetValue(this, max.Y - padding);
                        return;
                    }
                }

                if (PrioritizeVerticalGrowth)
                {
                    inner.X += largestGrowth + padding;
                    inner.Y = 0;
                }
                else
                {
                    inner.X = 0;
                    inner.Y += largestGrowth + padding;
                }
            }
        }
    }
}
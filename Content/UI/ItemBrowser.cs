using ReLogic.Threading;
using Selenate.Common.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace Selenate.Content.UI
{
    public class ItemBrowser : UIPanel
    {
        public SUIButtonDisplay Items { get; set; }

        public int HorizontalElementLimit
        {
            get => horizontalElementLimit;
            set
            {
                horizontalElementLimit = value;
            }
        }

        private int horizontalElementLimit = 10;

        public override void OnInitialize()
        {
            Items = new SUIButtonDisplay(HorizontalElementLimit);
            Items.Top.Pixels = 100;
            List<ItemButton> allItems = new List<ItemButton>();
            void loadItem(int from, int to, object context)
            {
                for (int i = from; i < to; i++)
                {
                    ItemButton itemButton = new ItemButton(i);
                    itemButton.Width.Pixels = 40;
                    itemButton.Height.Pixels = 40;
                    allItems.Add(itemButton);
                }
            }
            FastParallel.For(0, ItemID.Count - 1, loadItem);
            allItems.Sort();
            Items.AddRange(allItems);
            Items.Width.Pixels = 500;
            Items.Height.Pixels = 500;

            FixedUIScrollbar DescriptionScrollbar = new FixedUIScrollbar(UserInterface.ActiveInstance);
            DescriptionScrollbar.Left.Set(4, 0f);
            DescriptionScrollbar.Height.Set(0, 1f);
            DescriptionScrollbar.HAlign = 1f;
            Items.Append(DescriptionScrollbar);
            Items.SetScrollbar(DescriptionScrollbar);

            Width.Pixels = 500;
            Height.Pixels = 650;
            Append(Items);
        }
    }
}

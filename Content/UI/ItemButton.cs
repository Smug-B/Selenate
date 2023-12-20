using Selenate.Common.UI;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.UI;

namespace Selenate.Content.UI
{
    public class ItemButton : SUIImageButton
    {
        public int ItemID { get; }

        public Item Item { get; private set; }

        public ItemButton(int itemID) : base(null, false)
        {
            ItemID = itemID;
            Main.instance.LoadItem(itemID);
            Image = TextureAssets.Item[itemID];
            Item = new Item(itemID);
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
        }

        public override int CompareTo(object obj)
        {
            if (obj is not ItemButton itemButton || ItemID == itemButton.ItemID)
            {
                return 0;
            }

            return ItemID > itemButton.ItemID ? 1 : -1;
        }
    }
}

using Selenate.Core.UI;

namespace Selenate.Content.UI.States
{
    public class FeaturesState : AutoUIState
    {
        public override void PreLoad(ref string name)
        {
            AutoSetState = true;
            AutoAddHandler = true;
        }

        public override UIHandler Load() => new UIHandler(UserInterface, "Vanilla: Inventory", LayerName);

        public HotBar HotBar { get; private set; }

        public ItemBrowser ItemBrowser { get; private set; }

        public override void OnInitialize()
        {
            HotBar = new HotBar
            {
                HAlign = 0.5f,
                VAlign = 1f
            };
            HotBar.Top.Pixels = -10;
            HotBar.OnLeftClick += HotBar_OnLeftClick;
            Append(HotBar);

            ItemBrowser = new ItemBrowser();
            ItemBrowser.Left.Pixels = 100;
            ItemBrowser.Top.Pixels = 100;
            Append(ItemBrowser);
        }

        private void HotBar_OnLeftClick(Terraria.UI.UIMouseEvent evt, Terraria.UI.UIElement listeningElement)
        {
            // Main.NewText("There is nothing beyond this world, to think otherwise would be to folly.");
        }
    }
}
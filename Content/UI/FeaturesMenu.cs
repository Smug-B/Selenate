using Selenate.Core.UI;

namespace Selenate.Content.UI
{
    public class FeaturesMenu : AutoUIState
    {
        public override void PreLoad(ref string name)
        {
            AutoSetState = true;
            AutoAddHandler = true;
        }

        public override UIHandler Load() => new UIHandler(UserInterface, "Vanilla: Inventory", LayerName);

        public override void OnInitialize()
        {
            HotBar hotBar = new HotBar
            {
                HAlign = 0.5f,
                VAlign = 1f
            };
            hotBar.Top.Pixels = -10;
            hotBar.OnLeftClick += HotBar_OnLeftClick;
            Append(hotBar);
        }

        private void HotBar_OnLeftClick(Terraria.UI.UIMouseEvent evt, Terraria.UI.UIElement listeningElement)
        {
            // Main.NewText("There is nothing beyond this world, to think otherwise would be to folly.");
        }
    }
}
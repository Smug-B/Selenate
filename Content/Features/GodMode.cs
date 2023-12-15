using Selenate.Content.UI;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.UI;

namespace Selenate.Content.Features
{
    public class GodMode : HotBarIcon
    {
        public static bool Enabled;

        public GodMode() : base()
        {
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            base.LeftClick(evt);

            Enabled = Toggle.Value;
        }
    }

    public class GodModePlayer : ModPlayer
    {
        public override bool ImmuneTo(PlayerDeathReason damageSource, int cooldownCounter, bool dodgeable) =>
            GodMode.Enabled ? true : base.ImmuneTo(damageSource, cooldownCounter, dodgeable);

        public override void PreUpdate()
        {
            if (!GodMode.Enabled)
            {
                return;
            }

            Player.statLife = Player.statLifeMax2;
            Player.statMana = Player.statManaMax2;
            Player.wingTime = Player.wingTimeMax;
        }
    }
}

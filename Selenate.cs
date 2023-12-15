using ReLogic.Content;
using Terraria.ModLoader;

namespace Selenate
{
	public class Selenate : Mod
	{
		public static Selenate Mod { get; private set; }

		public Selenate() => Mod = this;

		public static Asset<T> Request<T>(string assetName, AssetRequestMode mode = AssetRequestMode.AsyncLoad) where T : class => Mod.Assets.Request<T>(assetName, mode);
	}
}
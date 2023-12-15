using Terraria.ModLoader;

namespace Selenate
{
	public class Selenate : Mod
	{
		public static Selenate Mod { get; private set; }

		public Selenate() => Mod = this;
	}
}
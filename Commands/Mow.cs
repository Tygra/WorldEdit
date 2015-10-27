using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using TShockAPI;

namespace WorldEdit.Commands
{
	public class Mow : WECommand
	{
		private static ushort[] mowedTiles = new[]
		{
			TileID.CorruptPlants,
			TileID.CorruptThorns,
			TileID.CrimsonVines,
			TileID.DyePlants,
			TileID.FleshWeeds,
			TileID.HallowedPlants,
			TileID.HallowedPlants2,
			TileID.HallowedVines,
			TileID.JunglePlants,
			TileID.JunglePlants2,
			TileID.JungleThorns,
			TileID.JungleVines,
			TileID.MushroomPlants,
			TileID.Plants,
			TileID.Plants2,
			TileID.Vines,
		};

		public Mow(int x, int y, int x2, int y2, TSPlayer plr)
			: base(x, y, x2, y2, plr)
		{
		}

		public override void Execute()
		{
			Tools.PrepareUndo(x, y, x2, y2, plr);
			int edits = 0;
			for (int i = x; i <= x2; i++)
			{
				for (int j = y; j <= y2; j++)
				{
					var tile = Main.tile[i, j];
					if (mowedTiles.Contains(tile.type))
					{
						tile.active(false);
						tile.type = 0;
						edits++;
					}
				}
			}
			ResetSection();
			plr.SendSuccessMessage("Mowed grass, thorns, and vines. ({0})", edits);
		}
	}
}

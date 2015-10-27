using System;
using Terraria;
using TShockAPI;

namespace WorldEdit.Commands
{
	public class Biome : WECommand
	{
		private string biome1;
		private string biome2;

		public Biome(int x, int y, int x2, int y2, TSPlayer plr, string biome1, string biome2)
			: base(x, y, x2, y2, plr)
		{
			this.biome1 = biome1;
			this.biome2 = biome2;
		}

		public override void Execute()
		{
			int edits = 0;
			if (biome1 != biome2)
			{
				Tools.PrepareUndo(x, y, x2, y2, plr);
				for (int i = x; i <= x2; i++)
				{
					for (int j = y; j <= y2; j++)
					{
						var tile = Main.tile[i, j];
						if (select(i, j, plr) && tile.active())
						{
							for (int k = 0; k < WorldEdit.Biomes[biome1].Length; k++)
							{
								int conv = WorldEdit.Biomes[biome1][k];
								if ((conv >= 0 && tile.active() && tile.type == conv) ||
									(conv == -1 && !tile.active()))
								{
									SetTile(i, j, WorldEdit.Biomes[biome2][k]);
									edits++;
									break;
								}
							}
						}
					}
				}
				ResetSection();
			}
			plr.SendSuccessMessage("Converted biomes. ({0})", edits);
		}
	}
}

using System;
using System.Diagnostics;
using Terraria;
using TShockAPI;
using WorldEdit.Expressions;

namespace WorldEdit.Commands
{
	public class Set : WECommand
	{
		private Expression expression;
		private int tileType;

		public Set(int x, int y, int x2, int y2, TSPlayer plr, int tileType, Expression expression)
			: base(x, y, x2, y2, plr)
		{
			this.tileType = tileType;
			this.expression = expression ?? new TestExpression(new Test(t => true));
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
					if (((tileType >= 0 && (!tile.active() || tile.type != tileType)) ||
						(tileType == -1 && tile.active()) ||
						(tileType == -2 && (tile.liquid == 0 || tile.liquidType() != 1)) ||
						(tileType == -3 && (tile.liquid == 0 || tile.liquidType() != 2)) ||
						(tileType == -4 && (tile.liquid == 0 || tile.liquidType() != 0))) &&
						select(i, j, plr) && expression.Evaluate(tile))
					{
						SetTile(i, j, tileType);
						edits++;
					}
				}
			}
			ResetSection();
			plr.SendSuccessMessage("Set tiles. ({0})", edits);
		}
	}
}
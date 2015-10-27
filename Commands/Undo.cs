using System;
using TShockAPI;

namespace WorldEdit.Commands
{
	public class Undo : WECommand
	{
		private string accountName;
		private int steps;

		public Undo(TSPlayer plr, string accountName, int steps)
			: base(0, 0, 0, 0, plr)
		{
			this.accountName = accountName;
			this.steps = steps;
		}

		public override void Execute()
		{
			int i = -1;
			while (++i < steps && Tools.Undo(accountName));
			if (i == 0)
				plr.SendErrorMessage("Failed to undo any actions.");
			else
				plr.SendSuccessMessage("Undid {0}'s last {1}action{2}.", accountName, i == 1 ? "" : i + " ", i == 1 ? "" : "s");
		}
	}
}
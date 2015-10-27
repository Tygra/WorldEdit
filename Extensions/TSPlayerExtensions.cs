﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TShockAPI;

namespace WorldEdit.Extensions
{
	public static class TSPlayerExtensions
	{
		private static ConditionalWeakTable<TSPlayer, PlayerInfo> players = new ConditionalWeakTable<TSPlayer, PlayerInfo>();

		public static PlayerInfo GetPlayerInfo(this TSPlayer tsplayer)
		{
			return players.GetOrCreateValue(tsplayer);
		}
	}
}

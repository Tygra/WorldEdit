using System;
using Terraria;

namespace WorldEdit.Expressions
{
	public delegate bool Test(Tile tile);

	public sealed class TestExpression : Expression
	{
		public Test Test;

		public TestExpression(Test test)
		{
			Test = test;
		}

		public override bool Evaluate(Tile tile)
		{
			return Test(tile);
		}
	}
}

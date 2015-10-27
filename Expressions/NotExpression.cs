using System;
using Terraria;

namespace WorldEdit.Expressions
{
	public class NotExpression : Expression
	{
		public NotExpression(Expression expression)
		{
			Left = expression;
		}

		public override bool Evaluate(Tile tile)
		{
			return !Left.Evaluate(tile);
		}
	}
}
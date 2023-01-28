using System;

namespace Jint.Expressions
{
	// Token: 0x0200003E RID: 62
	public interface IStatementVisitor
	{
		// Token: 0x060002CD RID: 717
		void Visit(global::Jint.Expressions.Program expression);

		// Token: 0x060002CE RID: 718
		void Visit(global::Jint.Expressions.AssignmentExpression expression);

		// Token: 0x060002CF RID: 719
		void Visit(global::Jint.Expressions.BlockStatement expression);

		// Token: 0x060002D0 RID: 720
		void Visit(global::Jint.Expressions.BreakStatement expression);

		// Token: 0x060002D1 RID: 721
		void Visit(global::Jint.Expressions.ContinueStatement expression);

		// Token: 0x060002D2 RID: 722
		void Visit(global::Jint.Expressions.DoWhileStatement expression);

		// Token: 0x060002D3 RID: 723
		void Visit(global::Jint.Expressions.EmptyStatement expression);

		// Token: 0x060002D4 RID: 724
		void Visit(global::Jint.Expressions.ExpressionStatement expression);

		// Token: 0x060002D5 RID: 725
		void Visit(global::Jint.Expressions.ForEachInStatement expression);

		// Token: 0x060002D6 RID: 726
		void Visit(global::Jint.Expressions.ForStatement expression);

		// Token: 0x060002D7 RID: 727
		void Visit(global::Jint.Expressions.FunctionDeclarationStatement expression);

		// Token: 0x060002D8 RID: 728
		void Visit(global::Jint.Expressions.IfStatement expression);

		// Token: 0x060002D9 RID: 729
		void Visit(global::Jint.Expressions.ReturnStatement expression);

		// Token: 0x060002DA RID: 730
		void Visit(global::Jint.Expressions.SwitchStatement expression);

		// Token: 0x060002DB RID: 731
		void Visit(global::Jint.Expressions.WithStatement expression);

		// Token: 0x060002DC RID: 732
		void Visit(global::Jint.Expressions.ThrowStatement expression);

		// Token: 0x060002DD RID: 733
		void Visit(global::Jint.Expressions.TryStatement expression);

		// Token: 0x060002DE RID: 734
		void Visit(global::Jint.Expressions.VariableDeclarationStatement expression);

		// Token: 0x060002DF RID: 735
		void Visit(global::Jint.Expressions.WhileStatement expression);

		// Token: 0x060002E0 RID: 736
		void Visit(global::Jint.Expressions.ArrayDeclaration expression);

		// Token: 0x060002E1 RID: 737
		void Visit(global::Jint.Expressions.CommaOperatorStatement expression);

		// Token: 0x060002E2 RID: 738
		void Visit(global::Jint.Expressions.FunctionExpression expression);

		// Token: 0x060002E3 RID: 739
		void Visit(global::Jint.Expressions.MemberExpression expression);

		// Token: 0x060002E4 RID: 740
		void Visit(global::Jint.Expressions.MethodCall expression);

		// Token: 0x060002E5 RID: 741
		void Visit(global::Jint.Expressions.Indexer expression);

		// Token: 0x060002E6 RID: 742
		void Visit(global::Jint.Expressions.PropertyExpression expression);

		// Token: 0x060002E7 RID: 743
		void Visit(global::Jint.Expressions.PropertyDeclarationExpression expression);

		// Token: 0x060002E8 RID: 744
		void Visit(global::Jint.Expressions.Identifier expression);

		// Token: 0x060002E9 RID: 745
		void Visit(global::Jint.Expressions.JsonExpression expression);

		// Token: 0x060002EA RID: 746
		void Visit(global::Jint.Expressions.NewExpression expression);

		// Token: 0x060002EB RID: 747
		void Visit(global::Jint.Expressions.BinaryExpression expression);

		// Token: 0x060002EC RID: 748
		void Visit(global::Jint.Expressions.TernaryExpression expression);

		// Token: 0x060002ED RID: 749
		void Visit(global::Jint.Expressions.UnaryExpression expression);

		// Token: 0x060002EE RID: 750
		void Visit(global::Jint.Expressions.ValueExpression expression);

		// Token: 0x060002EF RID: 751
		void Visit(global::Jint.Expressions.RegexpExpression expression);

		// Token: 0x060002F0 RID: 752
		void Visit(global::Jint.Expressions.Statement expression);
	}
}

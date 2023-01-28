using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000031 RID: 49
	[global::System.Serializable]
	public class PropertyDeclarationExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x06000272 RID: 626 RVA: 0x0001B8E0 File Offset: 0x00019AE0
		public PropertyDeclarationExpression()
		{
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000273 RID: 627 RVA: 0x0001B8E8 File Offset: 0x00019AE8
		// (set) Token: 0x06000274 RID: 628 RVA: 0x0001B8F0 File Offset: 0x00019AF0
		public string Name
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Name>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Name>k__BackingField = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000275 RID: 629 RVA: 0x0001B8FC File Offset: 0x00019AFC
		// (set) Token: 0x06000276 RID: 630 RVA: 0x0001B904 File Offset: 0x00019B04
		public global::Jint.Expressions.Expression Expression
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Expression>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Expression>k__BackingField = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000277 RID: 631 RVA: 0x0001B910 File Offset: 0x00019B10
		// (set) Token: 0x06000278 RID: 632 RVA: 0x0001B918 File Offset: 0x00019B18
		public global::Jint.Expressions.PropertyExpressionType Mode
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Mode>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Mode>k__BackingField = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000279 RID: 633 RVA: 0x0001B924 File Offset: 0x00019B24
		// (set) Token: 0x0600027A RID: 634 RVA: 0x0001B92C File Offset: 0x00019B2C
		public global::Jint.Expressions.Expression GetExpression
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<GetExpression>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<GetExpression>k__BackingField = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600027B RID: 635 RVA: 0x0001B938 File Offset: 0x00019B38
		// (set) Token: 0x0600027C RID: 636 RVA: 0x0001B940 File Offset: 0x00019B40
		public global::Jint.Expressions.Expression SetExpression
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<SetExpression>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<SetExpression>k__BackingField = value;
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0001B94C File Offset: 0x00019B4C
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0001B958 File Offset: 0x00019B58
		internal void SetSet(global::Jint.Expressions.PropertyDeclarationExpression propertyExpression)
		{
			this.SetExpression = propertyExpression.Expression;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0001B968 File Offset: 0x00019B68
		internal void SetGet(global::Jint.Expressions.PropertyDeclarationExpression propertyExpression)
		{
			this.GetExpression = propertyExpression.Expression;
		}

		// Token: 0x040001DC RID: 476
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Name>k__BackingField;

		// Token: 0x040001DD RID: 477
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <Expression>k__BackingField;

		// Token: 0x040001DE RID: 478
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.PropertyExpressionType <Mode>k__BackingField;

		// Token: 0x040001DF RID: 479
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <GetExpression>k__BackingField;

		// Token: 0x040001E0 RID: 480
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Expression <SetExpression>k__BackingField;
	}
}

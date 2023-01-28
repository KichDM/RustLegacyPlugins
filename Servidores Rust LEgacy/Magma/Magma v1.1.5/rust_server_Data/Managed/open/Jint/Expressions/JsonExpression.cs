using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jint.Expressions
{
	// Token: 0x02000064 RID: 100
	[global::System.Serializable]
	public class JsonExpression : global::Jint.Expressions.Expression
	{
		// Token: 0x0600051B RID: 1307 RVA: 0x00027B7C File Offset: 0x00025D7C
		public JsonExpression()
		{
			this.Values = new global::System.Collections.Generic.Dictionary<string, global::Jint.Expressions.Expression>();
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00027B90 File Offset: 0x00025D90
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x00027B98 File Offset: 0x00025D98
		public global::System.Collections.Generic.Dictionary<string, global::Jint.Expressions.Expression> Values
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Values>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Values>k__BackingField = value;
			}
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x00027BA4 File Offset: 0x00025DA4
		[global::System.Diagnostics.DebuggerStepThrough]
		public override void Accept(global::Jint.Expressions.IStatementVisitor visitor)
		{
			visitor.Visit(this);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00027BB0 File Offset: 0x00025DB0
		internal void Push(global::Jint.Expressions.PropertyDeclarationExpression propertyExpression)
		{
			if (propertyExpression.Name == null)
			{
				propertyExpression.Name = propertyExpression.Mode.ToString().ToLower();
				propertyExpression.Mode = global::Jint.Expressions.PropertyExpressionType.Data;
			}
			if (this.Values.ContainsKey(propertyExpression.Name))
			{
				global::Jint.Expressions.PropertyDeclarationExpression propertyDeclarationExpression = this.Values[propertyExpression.Name] as global::Jint.Expressions.PropertyDeclarationExpression;
				if (propertyDeclarationExpression == null)
				{
					throw new global::Jint.JintException("A property cannot be both an accessor and data");
				}
				switch (propertyExpression.Mode)
				{
				case global::Jint.Expressions.PropertyExpressionType.Data:
					if (propertyExpression.Mode == global::Jint.Expressions.PropertyExpressionType.Data)
					{
						this.Values[propertyExpression.Name] = propertyExpression.Expression;
						return;
					}
					throw new global::Jint.JintException("A property cannot be both an accessor and data");
				case global::Jint.Expressions.PropertyExpressionType.Get:
					propertyDeclarationExpression.SetGet(propertyExpression);
					return;
				case global::Jint.Expressions.PropertyExpressionType.Set:
					propertyDeclarationExpression.SetSet(propertyExpression);
					return;
				default:
					return;
				}
			}
			else
			{
				this.Values.Add(propertyExpression.Name, propertyExpression);
				switch (propertyExpression.Mode)
				{
				case global::Jint.Expressions.PropertyExpressionType.Data:
					this.Values[propertyExpression.Name] = propertyExpression;
					return;
				case global::Jint.Expressions.PropertyExpressionType.Get:
					propertyExpression.SetGet(propertyExpression);
					return;
				case global::Jint.Expressions.PropertyExpressionType.Set:
					propertyExpression.SetSet(propertyExpression);
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x0400024A RID: 586
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.Dictionary<string, global::Jint.Expressions.Expression> <Values>k__BackingField;
	}
}

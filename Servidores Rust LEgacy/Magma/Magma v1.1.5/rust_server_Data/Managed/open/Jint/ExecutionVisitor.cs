using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;
using Jint.Debugger;
using Jint.Expressions;
using Jint.Native;

namespace Jint
{
	// Token: 0x02000040 RID: 64
	public class ExecutionVisitor : global::Jint.Expressions.IStatementVisitor, global::Jint.Expressions.IJintVisitor
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0001C150 File Offset: 0x0001A350
		// (set) Token: 0x060002FA RID: 762 RVA: 0x0001C158 File Offset: 0x0001A358
		public global::Jint.Native.IGlobal Global
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Global>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<Global>k__BackingField = value;
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0001C164 File Offset: 0x0001A364
		// (set) Token: 0x060002FC RID: 764 RVA: 0x0001C16C File Offset: 0x0001A36C
		public global::Jint.Native.JsScope GlobalScope
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<GlobalScope>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<GlobalScope>k__BackingField = value;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060002FD RID: 765 RVA: 0x0001C178 File Offset: 0x0001A378
		// (remove) Token: 0x060002FE RID: 766 RVA: 0x0001C1B4 File Offset: 0x0001A3B4
		public event global::System.EventHandler<global::Jint.Debugger.DebugInformation> Step
		{
			add
			{
				global::System.EventHandler<global::Jint.Debugger.DebugInformation> eventHandler = this.Step;
				global::System.EventHandler<global::Jint.Debugger.DebugInformation> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					global::System.EventHandler<global::Jint.Debugger.DebugInformation> value2 = (global::System.EventHandler<global::Jint.Debugger.DebugInformation>)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler<global::Jint.Debugger.DebugInformation>>(ref this.Step, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				global::System.EventHandler<global::Jint.Debugger.DebugInformation> eventHandler = this.Step;
				global::System.EventHandler<global::Jint.Debugger.DebugInformation> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					global::System.EventHandler<global::Jint.Debugger.DebugInformation> value2 = (global::System.EventHandler<global::Jint.Debugger.DebugInformation>)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler<global::Jint.Debugger.DebugInformation>>(ref this.Step, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0001C1F0 File Offset: 0x0001A3F0
		// (set) Token: 0x06000300 RID: 768 RVA: 0x0001C1F8 File Offset: 0x0001A3F8
		public global::System.Collections.Generic.Stack<string> CallStack
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<CallStack>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<CallStack>k__BackingField = value;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0001C204 File Offset: 0x0001A404
		// (set) Token: 0x06000302 RID: 770 RVA: 0x0001C20C File Offset: 0x0001A40C
		public global::Jint.Expressions.Statement CurrentStatement
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<CurrentStatement>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<CurrentStatement>k__BackingField = value;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000303 RID: 771 RVA: 0x0001C218 File Offset: 0x0001A418
		// (set) Token: 0x06000304 RID: 772 RVA: 0x0001C220 File Offset: 0x0001A420
		public bool DebugMode
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<DebugMode>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<DebugMode>k__BackingField = value;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0001C22C File Offset: 0x0001A42C
		// (set) Token: 0x06000306 RID: 774 RVA: 0x0001C234 File Offset: 0x0001A434
		public int MaxRecursions
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<MaxRecursions>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<MaxRecursions>k__BackingField = value;
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000307 RID: 775 RVA: 0x0001C240 File Offset: 0x0001A440
		public global::Jint.Native.JsInstance Returned
		{
			get
			{
				return this.returnInstance;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000308 RID: 776 RVA: 0x0001C248 File Offset: 0x0001A448
		// (set) Token: 0x06000309 RID: 777 RVA: 0x0001C250 File Offset: 0x0001A450
		public bool AllowClr
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<AllowClr>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<AllowClr>k__BackingField = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600030A RID: 778 RVA: 0x0001C25C File Offset: 0x0001A45C
		// (set) Token: 0x0600030B RID: 779 RVA: 0x0001C264 File Offset: 0x0001A464
		public global::System.Security.PermissionSet PermissionSet
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<PermissionSet>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<PermissionSet>k__BackingField = value;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600030C RID: 780 RVA: 0x0001C270 File Offset: 0x0001A470
		public global::Jint.Native.JsDictionaryObject CallTarget
		{
			get
			{
				return this.lastResult.baseObject;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600030D RID: 781 RVA: 0x0001C280 File Offset: 0x0001A480
		// (set) Token: 0x0600030E RID: 782 RVA: 0x0001C290 File Offset: 0x0001A490
		public global::Jint.Native.JsInstance Result
		{
			get
			{
				return this.lastResult.result;
			}
			set
			{
				this.lastResult.result = value;
				this.lastResult.baseObject = null;
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0001C2AC File Offset: 0x0001A4AC
		public void SetResult(global::Jint.Native.JsInstance value, global::Jint.Native.JsDictionaryObject baseObject)
		{
			this.lastResult.result = value;
			this.lastResult.baseObject = baseObject;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0001C2C8 File Offset: 0x0001A4C8
		public ExecutionVisitor(global::Jint.Options options)
		{
			this.typeResolver = global::Jint.CachedTypeResolver.Default;
			this.Global = new global::Jint.Native.JsGlobal(this, options);
			this.GlobalScope = new global::Jint.Native.JsScope(this.Global as global::Jint.Native.JsObject);
			this.EnterScope(this.GlobalScope);
			this.CallStack = new global::System.Collections.Generic.Stack<string>();
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0001C348 File Offset: 0x0001A548
		public ExecutionVisitor(global::Jint.Native.IGlobal GlobalObject, global::Jint.Native.JsScope Scope)
		{
			if (GlobalObject == null)
			{
				throw new global::System.ArgumentNullException("GlobalObject");
			}
			if (Scope == null)
			{
				throw new global::System.ArgumentNullException("Scope");
			}
			this.typeResolver = global::Jint.CachedTypeResolver.Default;
			this.Global = GlobalObject;
			this.GlobalScope = Scope.Global;
			this.MaxRecursions = 0x1F4;
			this.EnterScope(Scope);
			this.CallStack = new global::System.Collections.Generic.Stack<string>();
		}

		// Token: 0x06000312 RID: 786 RVA: 0x0001C3E0 File Offset: 0x0001A5E0
		public void OnStep(global::Jint.Debugger.DebugInformation info)
		{
			if (this.Step != null && info.CurrentStatement != null && info.CurrentStatement.Source != null)
			{
				this.Step(this, info);
			}
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0001C418 File Offset: 0x0001A618
		public global::Jint.Debugger.DebugInformation CreateDebugInformation(global::Jint.Expressions.Statement statement)
		{
			global::Jint.Debugger.DebugInformation debugInformation = new global::Jint.Debugger.DebugInformation();
			debugInformation.CurrentStatement = statement;
			debugInformation.CallStack = this.CallStack;
			debugInformation.Locals = new global::Jint.Native.JsObject(global::Jint.Native.JsNull.Instance);
			this.DebugMode = false;
			foreach (string index in this.CurrentScope.GetKeys())
			{
				debugInformation.Locals[index] = this.CurrentScope[index];
			}
			this.DebugMode = true;
			return debugInformation;
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0001C4BC File Offset: 0x0001A6BC
		public global::Jint.Native.JsScope CurrentScope
		{
			get
			{
				return this.Scopes.Peek();
			}
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0001C4CC File Offset: 0x0001A6CC
		protected void EnterScope(global::Jint.Native.JsDictionaryObject scope)
		{
			this.Scopes.Push(new global::Jint.Native.JsScope(this.CurrentScope, scope));
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0001C4E8 File Offset: 0x0001A6E8
		protected void EnterScope(global::Jint.Native.JsScope scope)
		{
			this.Scopes.Push(scope);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0001C4F8 File Offset: 0x0001A6F8
		protected void ExitScope()
		{
			this.Scopes.Pop();
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0001C508 File Offset: 0x0001A708
		public void Visit(global::Jint.Expressions.Program program)
		{
			this.typeFullname = null;
			this.exit = false;
			this.lastIdentifier = string.Empty;
			foreach (global::Jint.Expressions.Statement statement in program.Statements)
			{
				this.CurrentStatement = statement;
				if (this.DebugMode)
				{
					this.OnStep(this.CreateDebugInformation(statement));
				}
				this.Result = null;
				statement.Accept(this);
				if (this.exit)
				{
					this.exit = false;
					break;
				}
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0001C5B8 File Offset: 0x0001A7B8
		public void Visit(global::Jint.Expressions.AssignmentExpression statement)
		{
			switch (statement.AssignmentOperator)
			{
			case global::Jint.Expressions.AssignmentOperator.Assign:
				statement.Right.Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.Multiply:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Times, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.Divide:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Div, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.Modulo:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Modulo, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.Add:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Plus, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.Substract:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Minus, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.ShiftLeft:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.LeftShift, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.ShiftRight:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.RightShift, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.UnsignedRightShift:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.UnsignedRightShift, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.And:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseAnd, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.Or:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseOr, statement.Left, statement.Right).Accept(this);
				break;
			case global::Jint.Expressions.AssignmentOperator.XOr:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.BitwiseXOr, statement.Left, statement.Right).Accept(this);
				break;
			default:
				throw new global::System.NotSupportedException();
			}
			global::Jint.Native.JsInstance result = this.Result;
			global::Jint.Expressions.MemberExpression memberExpression = statement.Left as global::Jint.Expressions.MemberExpression;
			if (memberExpression == null)
			{
				memberExpression = new global::Jint.Expressions.MemberExpression(statement.Left, null);
			}
			this.Assign(memberExpression, result);
			this.Result = result;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0001C7A0 File Offset: 0x0001A9A0
		public void Assign(global::Jint.Expressions.MemberExpression left, global::Jint.Native.JsInstance value)
		{
			global::Jint.Native.Descriptor descriptor = null;
			if (!(left.Member is global::Jint.Expressions.IAssignable))
			{
				throw new global::Jint.JintException("The left member of an assignment must be a member");
			}
			this.EnsureIdentifierIsDefined(value);
			global::Jint.Native.JsDictionaryObject jsDictionaryObject;
			if (left.Previous != null)
			{
				left.Previous.Accept(this);
				jsDictionaryObject = (this.Result as global::Jint.Native.JsDictionaryObject);
				if (jsDictionaryObject == null)
				{
					throw new global::Jint.JintException("Attempt to assign to an undefined variable.");
				}
			}
			else
			{
				jsDictionaryObject = this.CurrentScope;
				string text = ((global::Jint.Expressions.Identifier)left.Member).Text;
				this.CurrentScope.TryGetDescriptor(text, out descriptor);
				if (descriptor == null && this.HasOption(global::Jint.Options.Strict))
				{
					throw new global::Jint.Native.JsException(this.Global.ReferenceErrorClass.New(text + " is not defined"));
				}
			}
			if (left.Member is global::Jint.Expressions.Identifier)
			{
				string text = ((global::Jint.Expressions.Identifier)left.Member).Text;
				jsDictionaryObject[text] = value;
				this.Result = value;
				return;
			}
			global::Jint.Expressions.Indexer indexer = left.Member as global::Jint.Expressions.Indexer;
			indexer.Index.Accept(this);
			if (jsDictionaryObject is global::Jint.Native.JsObject)
			{
				global::Jint.Native.JsObject jsObject = jsDictionaryObject as global::Jint.Native.JsObject;
				if (jsObject.Indexer != null)
				{
					jsObject.Indexer.set(jsObject, this.Result, value);
					this.Result = value;
					return;
				}
			}
			jsDictionaryObject[this.Result] = value;
			this.Result = value;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0001C904 File Offset: 0x0001AB04
		public void Visit(global::Jint.Expressions.CommaOperatorStatement statement)
		{
			foreach (global::Jint.Expressions.Statement statement2 in statement.Statements)
			{
				if (this.DebugMode)
				{
					this.OnStep(this.CreateDebugInformation(statement2));
				}
				statement2.Accept(this);
				if (this.StopStatementFlow())
				{
					break;
				}
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0001C988 File Offset: 0x0001AB88
		public void Visit(global::Jint.Expressions.BlockStatement statement)
		{
			global::Jint.Expressions.Statement currentStatement = this.CurrentStatement;
			foreach (global::Jint.Expressions.Statement statement2 in statement.Statements)
			{
				this.CurrentStatement = statement2;
				if (this.DebugMode)
				{
					this.OnStep(this.CreateDebugInformation(statement2));
				}
				this.Result = null;
				this.typeFullname = null;
				statement2.Accept(this);
				if (this.StopStatementFlow())
				{
					return;
				}
			}
			this.CurrentStatement = currentStatement;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0001CA2C File Offset: 0x0001AC2C
		public void Visit(global::Jint.Expressions.ContinueStatement statement)
		{
			this.continueStatement = statement;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0001CA38 File Offset: 0x0001AC38
		public void Visit(global::Jint.Expressions.BreakStatement statement)
		{
			this.breakStatement = statement;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0001CA44 File Offset: 0x0001AC44
		public void Visit(global::Jint.Expressions.DoWhileStatement statement)
		{
			for (;;)
			{
				statement.Statement.Accept(this);
				this.ResetContinueIfPresent(statement.Label);
				if (this.StopStatementFlow())
				{
					break;
				}
				statement.Condition.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				if (!this.Result.ToBoolean())
				{
					return;
				}
			}
			if (this.breakStatement != null && statement.Label == this.breakStatement.Label)
			{
				this.breakStatement = null;
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0001CACC File Offset: 0x0001ACCC
		public void Visit(global::Jint.Expressions.EmptyStatement statement)
		{
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0001CAD0 File Offset: 0x0001ACD0
		[global::System.Diagnostics.DebuggerStepThrough]
		public void Visit(global::Jint.Expressions.ExpressionStatement statement)
		{
			statement.Expression.Accept(this);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0001CAE0 File Offset: 0x0001ACE0
		public void Visit(global::Jint.Expressions.ForEachInStatement statement)
		{
			string index = string.Empty;
			if (statement.InitialisationStatement is global::Jint.Expressions.VariableDeclarationStatement)
			{
				bool global = ((global::Jint.Expressions.VariableDeclarationStatement)statement.InitialisationStatement).Global;
				index = ((global::Jint.Expressions.VariableDeclarationStatement)statement.InitialisationStatement).Identifier;
			}
			else
			{
				if (!(statement.InitialisationStatement is global::Jint.Expressions.Identifier))
				{
					throw new global::System.NotSupportedException("Only variable declaration are allowed in a for in loop");
				}
				index = ((global::Jint.Expressions.Identifier)statement.InitialisationStatement).Text;
			}
			statement.Expression.Accept(this);
			global::Jint.Native.JsDictionaryObject jsDictionaryObject = this.Result as global::Jint.Native.JsDictionaryObject;
			if (this.Result.Value is global::System.Collections.IEnumerable)
			{
				using (global::System.Collections.IEnumerator enumerator = ((global::System.Collections.IEnumerable)this.Result.Value).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object value = enumerator.Current;
						this.CurrentScope[index] = this.Global.WrapClr(value);
						statement.Statement.Accept(this);
						this.ResetContinueIfPresent(statement.Label);
						if (this.StopStatementFlow())
						{
							if (this.breakStatement != null && statement.Label == this.breakStatement.Label)
							{
								this.breakStatement = null;
							}
							return;
						}
						this.ResetContinueIfPresent(statement.Label);
					}
					return;
				}
			}
			if (jsDictionaryObject != null)
			{
				global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>(jsDictionaryObject.GetKeys());
				int i = 0;
				while (i < list.Count)
				{
					string value2 = list[i];
					this.CurrentScope[index] = this.Global.StringClass.New(value2);
					statement.Statement.Accept(this);
					this.ResetContinueIfPresent(statement.Label);
					if (this.StopStatementFlow())
					{
						if (this.breakStatement != null && statement.Label == this.breakStatement.Label)
						{
							this.breakStatement = null;
							return;
						}
						return;
					}
					else
					{
						this.ResetContinueIfPresent(statement.Label);
						i++;
					}
				}
				return;
			}
			throw new global::System.InvalidOperationException("The property can't be enumerated");
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0001CD1C File Offset: 0x0001AF1C
		public void Visit(global::Jint.Expressions.WithStatement statement)
		{
			statement.Expression.Accept(this);
			if (!(this.Result is global::Jint.Native.JsDictionaryObject))
			{
				throw new global::Jint.Native.JsException(this.Global.StringClass.New("Invalid expression in 'with' statement"));
			}
			this.EnterScope((global::Jint.Native.JsDictionaryObject)this.Result);
			try
			{
				statement.Statement.Accept(this);
			}
			finally
			{
				this.ExitScope();
			}
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0001CD9C File Offset: 0x0001AF9C
		public void Visit(global::Jint.Expressions.ForStatement statement)
		{
			if (statement.InitialisationStatement != null)
			{
				statement.InitialisationStatement.Accept(this);
			}
			if (statement.ConditionExpression != null)
			{
				statement.ConditionExpression.Accept(this);
			}
			else
			{
				this.Result = this.Global.BooleanClass.New(true);
			}
			this.EnsureIdentifierIsDefined(this.Result);
			while (this.Result.ToBoolean())
			{
				statement.Statement.Accept(this);
				this.ResetContinueIfPresent(statement.Label);
				if (this.StopStatementFlow())
				{
					if (this.breakStatement != null && statement.Label == this.breakStatement.Label)
					{
						this.breakStatement = null;
					}
					return;
				}
				if (statement.IncrementExpression != null)
				{
					statement.IncrementExpression.Accept(this);
				}
				if (statement.ConditionExpression != null)
				{
					statement.ConditionExpression.Accept(this);
				}
				else
				{
					this.Result = this.Global.BooleanClass.New(true);
				}
			}
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0001CEB4 File Offset: 0x0001B0B4
		public global::Jint.Native.JsFunction CreateFunction(global::Jint.Expressions.IFunctionDeclaration functionDeclaration)
		{
			global::Jint.Native.JsFunction jsFunction = this.Global.FunctionClass.New();
			global::Jint.Expressions.BlockStatement blockStatement = new global::Jint.Expressions.BlockStatement();
			blockStatement.Statements.AddLast(functionDeclaration.Statement);
			blockStatement.Statements.AddLast(new global::Jint.Expressions.ReturnStatement(new global::Jint.Expressions.Identifier("undefined")));
			jsFunction.Statement = blockStatement;
			jsFunction.Name = functionDeclaration.Name;
			jsFunction.Scope = this.CurrentScope;
			jsFunction.Arguments = functionDeclaration.Parameters;
			if (this.HasOption(global::Jint.Options.Strict))
			{
				foreach (string a in jsFunction.Arguments)
				{
					if (a == "eval" || a == "arguments")
					{
						throw new global::Jint.Native.JsException(this.Global.StringClass.New("The parameters do not respect strict mode"));
					}
				}
			}
			return jsFunction;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0001CFC0 File Offset: 0x0001B1C0
		public void Visit(global::Jint.Expressions.FunctionDeclarationStatement statement)
		{
			global::Jint.Native.JsFunction value = this.CreateFunction(statement);
			this.CurrentScope.DefineOwnProperty(statement.Name, value);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0001CFEC File Offset: 0x0001B1EC
		public void Visit(global::Jint.Expressions.IfStatement statement)
		{
			statement.Expression.Accept(this);
			this.EnsureIdentifierIsDefined(this.Result);
			if (this.Result.ToBoolean())
			{
				statement.Then.Accept(this);
				return;
			}
			if (statement.Else != null)
			{
				statement.Else.Accept(this);
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0001D04C File Offset: 0x0001B24C
		public void Visit(global::Jint.Expressions.ReturnStatement statement)
		{
			if (statement.Expression != null)
			{
				statement.Expression.Accept(this);
				this.Return(this.Result);
			}
			this.exit = true;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0001D088 File Offset: 0x0001B288
		public global::Jint.Native.JsInstance Return(global::Jint.Native.JsInstance instance)
		{
			this.returnInstance = instance;
			return this.returnInstance;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0001D098 File Offset: 0x0001B298
		public void Visit(global::Jint.Expressions.SwitchStatement statement)
		{
			this.CurrentStatement = statement.Expression;
			bool flag = false;
			if (statement.CaseClauses != null)
			{
				foreach (global::Jint.Expressions.CaseClause caseClause in statement.CaseClauses)
				{
					this.CurrentStatement = caseClause.Expression;
					if (flag)
					{
						caseClause.Statements.Accept(this);
						if (this.exit)
						{
							break;
						}
					}
					else
					{
						new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Equal, (global::Jint.Expressions.Expression)statement.Expression, caseClause.Expression).Accept(this);
						if (this.Result.ToBoolean())
						{
							caseClause.Statements.Accept(this);
							flag = true;
							if (this.exit)
							{
								break;
							}
						}
					}
					if (this.breakStatement != null)
					{
						this.breakStatement = null;
						break;
					}
				}
			}
			if (!flag && statement.DefaultStatements != null)
			{
				statement.DefaultStatements.Accept(this);
				if (this.breakStatement != null)
				{
					this.breakStatement = null;
				}
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0001D1C0 File Offset: 0x0001B3C0
		public void Visit(global::Jint.Expressions.ThrowStatement statement)
		{
			this.Result = global::Jint.Native.JsUndefined.Instance;
			if (statement.Expression != null)
			{
				statement.Expression.Accept(this);
			}
			throw new global::Jint.Native.JsException(this.Result);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0001D1F0 File Offset: 0x0001B3F0
		public void Visit(global::Jint.Expressions.TryStatement statement)
		{
			try
			{
				statement.Statement.Accept(this);
			}
			catch (global::System.Exception ex)
			{
				if (statement.Catch == null)
				{
					throw;
				}
				global::Jint.Native.JsException ex2 = ex as global::Jint.Native.JsException;
				if (ex2 == null)
				{
					ex2 = new global::Jint.Native.JsException(this.Global.ErrorClass.New(ex.Message));
				}
				if (statement.Catch.Identifier != null)
				{
					this.CurrentScope.DefineOwnProperty(statement.Catch.Identifier, global::Jint.Native.JsUndefined.Instance);
					this.Assign(new global::Jint.Expressions.MemberExpression(new global::Jint.Expressions.PropertyExpression(statement.Catch.Identifier), null), ex2.Value);
				}
				statement.Catch.Statement.Accept(this);
			}
			finally
			{
				if (statement.Finally != null)
				{
					new global::Jint.Native.JsObject();
					statement.Finally.Statement.Accept(this);
				}
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0001D2F4 File Offset: 0x0001B4F4
		public void Visit(global::Jint.Expressions.VariableDeclarationStatement statement)
		{
			this.Result = global::Jint.Native.JsUndefined.Instance;
			if (statement.Expression == null)
			{
				if (!this.CurrentScope.HasOwnProperty(statement.Identifier))
				{
					this.CurrentScope.DefineOwnProperty(statement.Identifier, global::Jint.Native.JsUndefined.Instance);
				}
				return;
			}
			statement.Expression.Accept(this);
			if (statement.Global)
			{
				throw new global::System.InvalidOperationException("Cant declare a global variable");
			}
			if (!this.CurrentScope.HasOwnProperty(statement.Identifier))
			{
				this.CurrentScope.DefineOwnProperty(statement.Identifier, this.Result);
				return;
			}
			this.CurrentScope[statement.Identifier] = this.Result;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0001D3B0 File Offset: 0x0001B5B0
		public void Visit(global::Jint.Expressions.WhileStatement statement)
		{
			statement.Condition.Accept(this);
			this.EnsureIdentifierIsDefined(this.Result);
			while (this.Result.ToBoolean())
			{
				statement.Statement.Accept(this);
				this.ResetContinueIfPresent(statement.Label);
				if (this.StopStatementFlow())
				{
					if (this.breakStatement != null && statement.Label == this.breakStatement.Label)
					{
						this.breakStatement = null;
					}
					return;
				}
				statement.Condition.Accept(this);
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0001D448 File Offset: 0x0001B648
		public void Visit(global::Jint.Expressions.NewExpression expression)
		{
			this.Result = null;
			expression.Expression.Accept(this);
			if (this.AllowClr && this.Result == global::Jint.Native.JsUndefined.Instance && this.typeFullname != null && this.typeFullname.Length > 0 && expression.Generics.Count > 0)
			{
				string text = this.typeFullname.ToString();
				this.typeFullname = new global::System.Text.StringBuilder();
				global::System.Type[] array = new global::System.Type[expression.Generics.Count];
				try
				{
					int num = 0;
					foreach (global::Jint.Expressions.Expression expression2 in expression.Generics)
					{
						expression2.Accept(this);
						array[num] = this.Global.Marshaller.MarshalJsValue<global::System.Type>(this.Result);
						num++;
					}
				}
				catch (global::System.Exception innerException)
				{
					throw new global::Jint.JintException("A type parameter is required", innerException);
				}
				text = text + "`" + array.Length;
				this.Result = this.Global.Marshaller.MarshalClrValue<global::System.Type>(this.typeResolver.ResolveType(text).MakeGenericType(array));
			}
			if (this.Result != null && this.Result is global::Jint.Native.JsFunction)
			{
				global::Jint.Native.JsFunction jsFunction = (global::Jint.Native.JsFunction)this.Result;
				global::Jint.Native.JsInstance[] array2 = new global::Jint.Native.JsInstance[expression.Arguments.Count];
				for (int i = 0; i < expression.Arguments.Count; i++)
				{
					expression.Arguments[i].Accept(this);
					array2[i] = this.Result;
				}
				this.Result = jsFunction.Construct(array2, null, this);
				return;
			}
			throw new global::Jint.Native.JsException(this.Global.ErrorClass.New("Function expected."));
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0001D64C File Offset: 0x0001B84C
		public void Visit(global::Jint.Expressions.TernaryExpression expression)
		{
			this.Result = null;
			expression.LeftExpression.Accept(this);
			global::Jint.Native.JsInstance result = this.Result;
			this.Result = null;
			this.EnsureIdentifierIsDefined(result);
			if (result.ToBoolean())
			{
				expression.MiddleExpression.Accept(this);
				return;
			}
			expression.RightExpression.Accept(this);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0001D6AC File Offset: 0x0001B8AC
		public static bool IsNullOrUndefined(global::Jint.Native.JsInstance o)
		{
			return o == global::Jint.Native.JsUndefined.Instance || o == global::Jint.Native.JsNull.Instance || (o.IsClr && o.Value == null);
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0001D6DC File Offset: 0x0001B8DC
		public global::Jint.Native.JsBoolean Compare(global::Jint.Native.JsInstance x, global::Jint.Native.JsInstance y)
		{
			if (x.IsClr && y.IsClr)
			{
				return this.Global.BooleanClass.New(x.Value.Equals(y.Value));
			}
			if (x.Type == y.Type)
			{
				if (x == global::Jint.Native.JsUndefined.Instance)
				{
					return this.Global.BooleanClass.True;
				}
				if (x == global::Jint.Native.JsNull.Instance)
				{
					return this.Global.BooleanClass.True;
				}
				if (x.Type == "number")
				{
					if (x.ToNumber() == double.NaN)
					{
						return this.Global.BooleanClass.False;
					}
					if (y.ToNumber() == double.NaN)
					{
						return this.Global.BooleanClass.False;
					}
					if (x.ToNumber() == y.ToNumber())
					{
						return this.Global.BooleanClass.True;
					}
					return this.Global.BooleanClass.False;
				}
				else
				{
					if (x.Type == "string")
					{
						return this.Global.BooleanClass.New(x.ToString() == y.ToString());
					}
					if (x.Type == "boolean")
					{
						return this.Global.BooleanClass.New(x.ToBoolean() == y.ToBoolean());
					}
					if (x.Type == "object")
					{
						return this.Global.BooleanClass.New(x == y);
					}
					return this.Global.BooleanClass.New(x.Value.Equals(y.Value));
				}
			}
			else
			{
				if (x == global::Jint.Native.JsNull.Instance && y == global::Jint.Native.JsUndefined.Instance)
				{
					return this.Global.BooleanClass.True;
				}
				if (x == global::Jint.Native.JsUndefined.Instance && y == global::Jint.Native.JsNull.Instance)
				{
					return this.Global.BooleanClass.True;
				}
				if (x.Type == "number" && y.Type == "string")
				{
					return this.Global.BooleanClass.New(x.ToNumber() == y.ToNumber());
				}
				if (x.Type == "string" && y.Type == "number")
				{
					return this.Global.BooleanClass.New(x.ToNumber() == y.ToNumber());
				}
				if (x.Type == "boolean" || y.Type == "boolean")
				{
					return this.Global.BooleanClass.New(x.ToNumber() == y.ToNumber());
				}
				if (y.Type == "object" && (x.Type == "string" || x.Type == "number"))
				{
					return this.Compare(x, y.ToPrimitive(this.Global));
				}
				if (x.Type == "object" && (y.Type == "string" || y.Type == "number"))
				{
					return this.Compare(x.ToPrimitive(this.Global), y);
				}
				return this.Global.BooleanClass.False;
			}
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0001DA9C File Offset: 0x0001BC9C
		public bool CompareTo(global::Jint.Native.JsInstance x, global::Jint.Native.JsInstance y, out int result)
		{
			result = 0;
			if (x.IsClr && y.IsClr)
			{
				global::System.IComparable comparable = x.Value as global::System.IComparable;
				if (comparable == null || y.Value == null || comparable.GetType() != y.Value.GetType())
				{
					return false;
				}
				result = comparable.CompareTo(y.Value);
			}
			else
			{
				double num = x.ToNumber();
				double num2 = y.ToNumber();
				if (double.IsNaN(num) || double.IsNaN(num2))
				{
					return false;
				}
				if (num < num2)
				{
					result = -1;
				}
				else if (num == num2)
				{
					result = 0;
				}
				else
				{
					result = 1;
				}
			}
			return true;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0001DB58 File Offset: 0x0001BD58
		public void Visit(global::Jint.Expressions.BinaryExpression expression)
		{
			expression.LeftExpression.Accept(this);
			this.EnsureIdentifierIsDefined(this.Result);
			global::Jint.Native.JsInstance result = this.Result;
			if (expression.Type == global::Jint.Expressions.BinaryExpressionType.And && !result.ToBoolean())
			{
				this.Result = result;
				return;
			}
			if (expression.Type == global::Jint.Expressions.BinaryExpressionType.Or && result.ToBoolean())
			{
				this.Result = result;
				return;
			}
			expression.RightExpression.Accept(this);
			this.EnsureIdentifierIsDefined(this.Result);
			global::Jint.Native.JsInstance result2 = this.Result;
			switch (expression.Type)
			{
			case global::Jint.Expressions.BinaryExpressionType.And:
				if (result.ToBoolean())
				{
					this.Result = result2;
					return;
				}
				this.Result = this.Global.BooleanClass.False;
				return;
			case global::Jint.Expressions.BinaryExpressionType.Or:
				if (result.ToBoolean())
				{
					this.Result = result;
					return;
				}
				this.Result = result2;
				return;
			case global::Jint.Expressions.BinaryExpressionType.NotEqual:
				this.Result = this.Global.BooleanClass.New(!this.Compare(result, result2).ToBoolean());
				return;
			case global::Jint.Expressions.BinaryExpressionType.LesserOrEqual:
			{
				int num;
				this.Result = ((this.CompareTo(result, result2, out num) && num <= 0) ? this.Global.BooleanClass.True : this.Global.BooleanClass.False);
				return;
			}
			case global::Jint.Expressions.BinaryExpressionType.GreaterOrEqual:
			{
				int num;
				this.Result = ((this.CompareTo(result, result2, out num) && num >= 0) ? this.Global.BooleanClass.True : this.Global.BooleanClass.False);
				return;
			}
			case global::Jint.Expressions.BinaryExpressionType.Lesser:
			{
				int num;
				this.Result = ((this.CompareTo(result, result2, out num) && num < 0) ? this.Global.BooleanClass.True : this.Global.BooleanClass.False);
				return;
			}
			case global::Jint.Expressions.BinaryExpressionType.Greater:
			{
				int num;
				this.Result = ((this.CompareTo(result, result2, out num) && num > 0) ? this.Global.BooleanClass.True : this.Global.BooleanClass.False);
				return;
			}
			case global::Jint.Expressions.BinaryExpressionType.Equal:
				this.Result = this.Compare(result, result2);
				return;
			case global::Jint.Expressions.BinaryExpressionType.Minus:
				this.Result = this.Global.NumberClass.New(result.ToNumber() - result2.ToNumber());
				return;
			case global::Jint.Expressions.BinaryExpressionType.Plus:
			{
				global::Jint.Native.JsInstance jsInstance = result.ToPrimitive(this.Global);
				global::Jint.Native.JsInstance jsInstance2 = result2.ToPrimitive(this.Global);
				if (jsInstance.Class == "String" || jsInstance2.Class == "String")
				{
					this.Result = this.Global.StringClass.New(jsInstance.ToString() + jsInstance2.ToString());
					return;
				}
				this.Result = this.Global.NumberClass.New(jsInstance.ToNumber() + jsInstance2.ToNumber());
				return;
			}
			case global::Jint.Expressions.BinaryExpressionType.Modulo:
				if (result2 == this.Global.NumberClass["NEGATIVE_INFINITY"] || result2 == this.Global.NumberClass["POSITIVE_INFINITY"])
				{
					this.Result = this.Global.NumberClass["POSITIVE_INFINITY"];
					return;
				}
				if (result2.ToNumber() == 0.0)
				{
					this.Result = this.Global.NumberClass["NaN"];
					return;
				}
				this.Result = this.Global.NumberClass.New(result.ToNumber() % result2.ToNumber());
				return;
			case global::Jint.Expressions.BinaryExpressionType.Div:
			{
				double num2 = result2.ToNumber();
				double num3 = result.ToNumber();
				if (result2 == this.Global.NumberClass["NEGATIVE_INFINITY"] || result2 == this.Global.NumberClass["POSITIVE_INFINITY"])
				{
					this.Result = this.Global.NumberClass.New(0.0);
					return;
				}
				if (num2 == 0.0)
				{
					this.Result = ((num3 > 0.0) ? this.Global.NumberClass["POSITIVE_INFINITY"] : this.Global.NumberClass["NEGATIVE_INFINITY"]);
					return;
				}
				this.Result = this.Global.NumberClass.New(num3 / num2);
				return;
			}
			case global::Jint.Expressions.BinaryExpressionType.Times:
				this.Result = this.Global.NumberClass.New(result.ToNumber() * result2.ToNumber());
				return;
			case global::Jint.Expressions.BinaryExpressionType.Pow:
				this.Result = this.Global.NumberClass.New(global::System.Math.Pow(result.ToNumber(), result2.ToNumber()));
				return;
			case global::Jint.Expressions.BinaryExpressionType.BitwiseAnd:
				if (result == global::Jint.Native.JsUndefined.Instance || result2 == global::Jint.Native.JsUndefined.Instance)
				{
					this.Result = this.Global.NumberClass.New(0.0);
					return;
				}
				this.Result = this.Global.NumberClass.New((double)(global::System.Convert.ToInt64(result.ToNumber()) & global::System.Convert.ToInt64(result2.ToNumber())));
				return;
			case global::Jint.Expressions.BinaryExpressionType.BitwiseOr:
				if (result == global::Jint.Native.JsUndefined.Instance)
				{
					if (result2 == global::Jint.Native.JsUndefined.Instance)
					{
						this.Result = this.Global.NumberClass.New(1.0);
						return;
					}
					this.Result = this.Global.NumberClass.New((double)global::System.Convert.ToInt64(result2.ToNumber()));
					return;
				}
				else
				{
					if (result2 == global::Jint.Native.JsUndefined.Instance)
					{
						this.Result = this.Global.NumberClass.New((double)global::System.Convert.ToInt64(result.ToNumber()));
						return;
					}
					this.Result = this.Global.NumberClass.New((double)(global::System.Convert.ToInt64(result.ToNumber()) | global::System.Convert.ToInt64(result2.ToNumber())));
					return;
				}
				break;
			case global::Jint.Expressions.BinaryExpressionType.BitwiseXOr:
				if (result == global::Jint.Native.JsUndefined.Instance)
				{
					if (result2 == global::Jint.Native.JsUndefined.Instance)
					{
						this.Result = this.Global.NumberClass.New(1.0);
						return;
					}
					this.Result = this.Global.NumberClass.New((double)global::System.Convert.ToInt64(result2.ToNumber()));
					return;
				}
				else
				{
					if (result2 == global::Jint.Native.JsUndefined.Instance)
					{
						this.Result = this.Global.NumberClass.New((double)global::System.Convert.ToInt64(result.ToNumber()));
						return;
					}
					this.Result = this.Global.NumberClass.New((double)(global::System.Convert.ToInt64(result.ToNumber()) ^ global::System.Convert.ToInt64(result2.ToNumber())));
					return;
				}
				break;
			case global::Jint.Expressions.BinaryExpressionType.Same:
				this.Result = global::Jint.Native.JsInstance.StrictlyEquals(this.Global, result, result2);
				return;
			case global::Jint.Expressions.BinaryExpressionType.NotSame:
				new global::Jint.Expressions.BinaryExpression(global::Jint.Expressions.BinaryExpressionType.Same, expression.LeftExpression, expression.RightExpression).Accept(this);
				this.Result = this.Global.BooleanClass.New(!this.Result.ToBoolean());
				return;
			case global::Jint.Expressions.BinaryExpressionType.LeftShift:
				if (result == global::Jint.Native.JsUndefined.Instance)
				{
					this.Result = this.Global.NumberClass.New(0.0);
					return;
				}
				if (result2 == global::Jint.Native.JsUndefined.Instance)
				{
					this.Result = this.Global.NumberClass.New((double)global::System.Convert.ToInt64(result.ToNumber()));
					return;
				}
				this.Result = this.Global.NumberClass.New((double)(global::System.Convert.ToInt64(result.ToNumber()) << (int)global::System.Convert.ToUInt16(result2.ToNumber())));
				return;
			case global::Jint.Expressions.BinaryExpressionType.RightShift:
				if (result == global::Jint.Native.JsUndefined.Instance)
				{
					this.Result = this.Global.NumberClass.New(0.0);
					return;
				}
				if (result2 == global::Jint.Native.JsUndefined.Instance)
				{
					this.Result = this.Global.NumberClass.New((double)global::System.Convert.ToInt64(result.ToNumber()));
					return;
				}
				this.Result = this.Global.NumberClass.New((double)(global::System.Convert.ToInt64(result.ToNumber()) >> (int)global::System.Convert.ToUInt16(result2.ToNumber())));
				return;
			case global::Jint.Expressions.BinaryExpressionType.UnsignedRightShift:
				if (result == global::Jint.Native.JsUndefined.Instance)
				{
					this.Result = this.Global.NumberClass.New(0.0);
					return;
				}
				if (result2 == global::Jint.Native.JsUndefined.Instance)
				{
					this.Result = this.Global.NumberClass.New((double)global::System.Convert.ToInt64(result.ToNumber()));
					return;
				}
				this.Result = this.Global.NumberClass.New((double)(global::System.Convert.ToInt64(result.ToNumber()) >> (int)global::System.Convert.ToUInt16(result2.ToNumber())));
				return;
			case global::Jint.Expressions.BinaryExpressionType.InstanceOf:
			{
				global::Jint.Native.JsFunction jsFunction = result2 as global::Jint.Native.JsFunction;
				global::Jint.Native.JsObject jsObject = result as global::Jint.Native.JsObject;
				if (jsFunction == null)
				{
					throw new global::Jint.Native.JsException(this.Global.TypeErrorClass.New("Right argument should be a function: " + expression.RightExpression.ToString()));
				}
				if (jsObject == null)
				{
					throw new global::Jint.Native.JsException(this.Global.TypeErrorClass.New("Left argument should be an object: " + expression.LeftExpression.ToString()));
				}
				this.Result = this.Global.BooleanClass.New(jsFunction.HasInstance(jsObject));
				return;
			}
			case global::Jint.Expressions.BinaryExpressionType.In:
				if (result2 is global::Jint.Native.ILiteral)
				{
					throw new global::Jint.Native.JsException(this.Global.ErrorClass.New("Cannot apply 'in' operator to the specified member."));
				}
				this.Result = this.Global.BooleanClass.New(((global::Jint.Native.JsDictionaryObject)result2).HasProperty(result));
				return;
			default:
				throw new global::System.NotSupportedException("Unkown binary operator");
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0001E50C File Offset: 0x0001C70C
		public void Visit(global::Jint.Expressions.UnaryExpression expression)
		{
			switch (expression.Type)
			{
			case global::Jint.Expressions.UnaryExpressionType.TypeOf:
				expression.Expression.Accept(this);
				if (this.Result == null)
				{
					this.Result = this.Global.StringClass.New(global::Jint.Native.JsUndefined.Instance.Type);
					return;
				}
				if (this.Result is global::Jint.Native.JsNull)
				{
					this.Result = this.Global.StringClass.New("object");
					return;
				}
				if (this.Result is global::Jint.Native.JsFunction)
				{
					this.Result = this.Global.StringClass.New("function");
					return;
				}
				this.Result = this.Global.StringClass.New(this.Result.Type);
				return;
			case global::Jint.Expressions.UnaryExpressionType.New:
				break;
			case global::Jint.Expressions.UnaryExpressionType.Not:
				expression.Expression.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				this.Result = this.Global.BooleanClass.New(!this.Result.ToBoolean());
				return;
			case global::Jint.Expressions.UnaryExpressionType.Negate:
				expression.Expression.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				this.Result = this.Global.NumberClass.New(-this.Result.ToNumber());
				return;
			case global::Jint.Expressions.UnaryExpressionType.Positive:
				expression.Expression.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				this.Result = this.Global.NumberClass.New(this.Result.ToNumber());
				return;
			case global::Jint.Expressions.UnaryExpressionType.PrefixPlusPlus:
			{
				expression.Expression.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				global::Jint.Native.JsInstance jsInstance = this.Global.NumberClass.New(this.Result.ToNumber() + 1.0);
				global::Jint.Expressions.MemberExpression memberExpression = (expression.Expression as global::Jint.Expressions.MemberExpression) ?? new global::Jint.Expressions.MemberExpression(expression.Expression, null);
				this.Assign(memberExpression, jsInstance);
				return;
			}
			case global::Jint.Expressions.UnaryExpressionType.PrefixMinusMinus:
			{
				expression.Expression.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				global::Jint.Native.JsInstance jsInstance = this.Global.NumberClass.New(this.Result.ToNumber() - 1.0);
				global::Jint.Expressions.MemberExpression memberExpression = (expression.Expression as global::Jint.Expressions.MemberExpression) ?? new global::Jint.Expressions.MemberExpression(expression.Expression, null);
				this.Assign(memberExpression, jsInstance);
				return;
			}
			case global::Jint.Expressions.UnaryExpressionType.PostfixPlusPlus:
			{
				expression.Expression.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				global::Jint.Native.JsInstance jsInstance = this.Result;
				global::Jint.Expressions.MemberExpression memberExpression = (expression.Expression as global::Jint.Expressions.MemberExpression) ?? new global::Jint.Expressions.MemberExpression(expression.Expression, null);
				this.Assign(memberExpression, this.Global.NumberClass.New(jsInstance.ToNumber() + 1.0));
				this.Result = jsInstance;
				return;
			}
			case global::Jint.Expressions.UnaryExpressionType.PostfixMinusMinus:
			{
				expression.Expression.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				global::Jint.Native.JsInstance jsInstance = this.Result;
				global::Jint.Expressions.MemberExpression memberExpression = (expression.Expression as global::Jint.Expressions.MemberExpression) ?? new global::Jint.Expressions.MemberExpression(expression.Expression, null);
				this.Assign(memberExpression, this.Global.NumberClass.New(jsInstance.ToNumber() - 1.0));
				this.Result = jsInstance;
				return;
			}
			case global::Jint.Expressions.UnaryExpressionType.Delete:
			{
				global::Jint.Expressions.MemberExpression memberExpression = expression.Expression as global::Jint.Expressions.MemberExpression;
				if (memberExpression == null)
				{
					throw new global::System.NotImplementedException("delete");
				}
				memberExpression.Previous.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				global::Jint.Native.JsInstance jsInstance = this.Result;
				string text = null;
				if (memberExpression.Member is global::Jint.Expressions.PropertyExpression)
				{
					text = ((global::Jint.Expressions.PropertyExpression)memberExpression.Member).Text;
				}
				if (memberExpression.Member is global::Jint.Expressions.Indexer)
				{
					((global::Jint.Expressions.Indexer)memberExpression.Member).Index.Accept(this);
					text = this.Result.ToString();
				}
				if (string.IsNullOrEmpty(text))
				{
					throw new global::Jint.Native.JsException(this.Global.TypeErrorClass.New());
				}
				try
				{
					((global::Jint.Native.JsDictionaryObject)jsInstance).Delete(text);
				}
				catch (global::Jint.JintException)
				{
					throw new global::Jint.Native.JsException(this.Global.TypeErrorClass.New());
				}
				this.Result = jsInstance;
				return;
			}
			case global::Jint.Expressions.UnaryExpressionType.Void:
				expression.Expression.Accept(this);
				this.Result = global::Jint.Native.JsUndefined.Instance;
				return;
			case global::Jint.Expressions.UnaryExpressionType.Inv:
				expression.Expression.Accept(this);
				this.EnsureIdentifierIsDefined(this.Result);
				this.Result = this.Global.NumberClass.New(0.0 - this.Result.ToNumber() - 1.0);
				break;
			default:
				return;
			}
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0001E9B8 File Offset: 0x0001CBB8
		public void Visit(global::Jint.Expressions.ValueExpression expression)
		{
			global::System.TypeCode typeCode = expression.TypeCode;
			if (typeCode <= global::System.TypeCode.Int32)
			{
				if (typeCode == global::System.TypeCode.Boolean)
				{
					this.Result = this.Global.BooleanClass.New((bool)expression.Value);
					return;
				}
				if (typeCode != global::System.TypeCode.Int32)
				{
					goto IL_A7;
				}
			}
			else
			{
				switch (typeCode)
				{
				case global::System.TypeCode.Single:
				case global::System.TypeCode.Double:
					break;
				default:
					if (typeCode != global::System.TypeCode.String)
					{
						goto IL_A7;
					}
					this.Result = this.Global.StringClass.New((string)expression.Value);
					return;
				}
			}
			this.Result = this.Global.NumberClass.New(global::System.Convert.ToDouble(expression.Value));
			return;
			IL_A7:
			this.Result = (expression.Value as global::Jint.Native.JsInstance);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0001EA84 File Offset: 0x0001CC84
		public void Visit(global::Jint.Expressions.FunctionExpression fe)
		{
			this.Result = this.CreateFunction(fe);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0001EA94 File Offset: 0x0001CC94
		public void Visit(global::Jint.Expressions.Statement expression)
		{
			throw new global::System.NotImplementedException();
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0001EA9C File Offset: 0x0001CC9C
		public void Visit(global::Jint.Expressions.MemberExpression expression)
		{
			if (expression.Previous != null)
			{
				expression.Previous.Accept(this);
			}
			expression.Member.Accept(this);
			if (this.AllowClr && this.Result == global::Jint.Native.JsUndefined.Instance && this.typeFullname != null && this.typeFullname.Length > 0)
			{
				this.EnsureClrAllowed();
				global::System.Type type = this.typeResolver.ResolveType(this.typeFullname.ToString());
				if (type != null)
				{
					this.Result = this.Global.WrapClr(type);
					this.typeFullname = new global::System.Text.StringBuilder();
				}
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0001EB48 File Offset: 0x0001CD48
		public void EnsureIdentifierIsDefined(object value)
		{
			if (value == null)
			{
				throw new global::Jint.Native.JsException(this.Global.ReferenceErrorClass.New(this.lastIdentifier + " is not defined"));
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0001EB78 File Offset: 0x0001CD78
		public void Visit(global::Jint.Expressions.Indexer indexer)
		{
			this.EnsureIdentifierIsDefined(this.Result);
			global::Jint.Native.JsObject jsObject = (global::Jint.Native.JsObject)this.Result;
			indexer.Index.Accept(this);
			if (jsObject.IsClr)
			{
				this.EnsureClrAllowed();
			}
			if (jsObject.Class == "String")
			{
				try
				{
					this.SetResult(this.Global.StringClass.New(jsObject.ToString()[global::System.Convert.ToInt32(this.Result.ToNumber())].ToString()), jsObject);
					return;
				}
				catch
				{
				}
			}
			if (jsObject.Indexer != null)
			{
				this.SetResult(jsObject.Indexer.get(jsObject, this.Result), jsObject);
				return;
			}
			this.SetResult(jsObject[this.Result], jsObject);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0001EC5C File Offset: 0x0001CE5C
		public void Visit(global::Jint.Expressions.MethodCall methodCall)
		{
			global::Jint.Native.JsDictionaryObject callTarget = this.CallTarget;
			global::Jint.Native.JsInstance result = this.Result;
			if ((result == global::Jint.Native.JsUndefined.Instance || this.Result == null) && string.IsNullOrEmpty(this.lastIdentifier))
			{
				throw new global::Jint.Native.JsException(this.Global.TypeErrorClass.New("Method isn't defined"));
			}
			global::System.Type[] array = null;
			if (this.AllowClr && methodCall.Generics.Count > 0)
			{
				array = new global::System.Type[methodCall.Generics.Count];
				try
				{
					int num = 0;
					foreach (global::Jint.Expressions.Expression expression in methodCall.Generics)
					{
						expression.Accept(this);
						array[num] = this.Global.Marshaller.MarshalJsValue<global::System.Type>(this.Result);
						num++;
					}
				}
				catch (global::System.Exception innerException)
				{
					throw new global::Jint.JintException("A type parameter is required", innerException);
				}
			}
			global::Jint.Native.JsInstance[] array2 = new global::Jint.Native.JsInstance[methodCall.Arguments.Count];
			if (methodCall.Arguments.Count > 0)
			{
				for (int i = 0; i < methodCall.Arguments.Count; i++)
				{
					methodCall.Arguments[i].Accept(this);
					array2[i] = this.Result;
				}
			}
			global::Jint.Native.JsFunction jsFunction = result as global::Jint.Native.JsFunction;
			if (jsFunction != null)
			{
				if (this.DebugMode)
				{
					string text = jsFunction.Name + "(";
					string[] array3 = new string[array2.Length];
					for (int j = 0; j < array2.Length; j++)
					{
						if (array2[j] != null)
						{
							array3[j] = array2[j].ToSource();
						}
						else
						{
							array3[j] = "null";
						}
					}
					text += string.Join(", ", array3);
					text += ")";
					this.CallStack.Push(text);
				}
				this.returnInstance = global::Jint.Native.JsUndefined.Instance;
				global::Jint.Native.JsInstance[] array4 = new global::Jint.Native.JsInstance[array2.Length];
				array2.CopyTo(array4, 0);
				this.ExecuteFunction(jsFunction, callTarget, array2, array);
				for (int k = 0; k < array4.Length; k++)
				{
					if (array4[k] != array2[k])
					{
						if (methodCall.Arguments[k] is global::Jint.Expressions.MemberExpression && ((global::Jint.Expressions.MemberExpression)methodCall.Arguments[k]).Member is global::Jint.Expressions.IAssignable)
						{
							this.Assign((global::Jint.Expressions.MemberExpression)methodCall.Arguments[k], array2[k]);
						}
						else if (methodCall.Arguments[k] is global::Jint.Expressions.Identifier)
						{
							this.Assign(new global::Jint.Expressions.MemberExpression(methodCall.Arguments[k], null), array2[k]);
						}
					}
				}
				if (this.DebugMode)
				{
					this.CallStack.Pop();
				}
				this.Result = this.returnInstance;
				this.returnInstance = global::Jint.Native.JsUndefined.Instance;
				return;
			}
			throw new global::Jint.Native.JsException(this.Global.ErrorClass.New("Function expected."));
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0001EFD0 File Offset: 0x0001D1D0
		public void ExecuteFunction(global::Jint.Native.JsFunction function, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			this.ExecuteFunction(function, that, parameters, null);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0001EFDC File Offset: 0x0001D1DC
		public void ExecuteFunction(global::Jint.Native.JsFunction function, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericParameters)
		{
			if (function == null)
			{
				return;
			}
			if (this.recursionLevel++ > this.MaxRecursions)
			{
				throw new global::Jint.Native.JsException(this.Global.ErrorClass.New("Too many recursions in the script."));
			}
			global::Jint.Native.JsArguments jsArguments = new global::Jint.Native.JsArguments(this.Global, function, parameters);
			global::Jint.Native.JsScope jsScope = new global::Jint.Native.JsScope(function.Scope ?? this.GlobalScope);
			for (int i = 0; i < function.Arguments.Count; i++)
			{
				if (i < parameters.Length)
				{
					jsScope.DefineOwnProperty(new global::Jint.Native.LinkedDescriptor(jsScope, function.Arguments[i], jsArguments.GetDescriptor(i.ToString()), jsArguments));
				}
				else
				{
					jsScope.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(jsScope, function.Arguments[i], global::Jint.Native.JsUndefined.Instance));
				}
			}
			if (this.HasOption(global::Jint.Options.Strict))
			{
				jsScope.DefineOwnProperty(global::Jint.Native.JsScope.ARGUMENTS, jsArguments);
			}
			else
			{
				jsArguments.DefineOwnProperty(global::Jint.Native.JsScope.ARGUMENTS, jsArguments);
			}
			if (that != null)
			{
				jsScope.DefineOwnProperty(global::Jint.Native.JsScope.THIS, that);
			}
			else
			{
				jsScope.DefineOwnProperty(global::Jint.Native.JsScope.THIS, that = (this.Global as global::Jint.Native.JsObject));
			}
			this.EnterScope(jsScope);
			try
			{
				if (this.AllowClr)
				{
					this.PermissionSet.PermitOnly();
				}
				if (this.AllowClr && genericParameters != null && genericParameters.Length > 0)
				{
					this.Result = function.Execute(this, that, parameters, genericParameters);
				}
				else
				{
					this.Result = function.Execute(this, that, parameters);
				}
				if (this.exit)
				{
					this.exit = false;
				}
			}
			finally
			{
				this.ExitScope();
				if (this.AllowClr)
				{
					global::System.Security.CodeAccessPermission.RevertPermitOnly();
				}
				this.recursionLevel--;
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0001F1BC File Offset: 0x0001D3BC
		private bool HasOption(global::Jint.Options options)
		{
			return this.Global.HasOption(options);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0001F1CC File Offset: 0x0001D3CC
		public void Visit(global::Jint.Expressions.PropertyExpression expression)
		{
			global::Jint.Native.JsDictionaryObject jsDictionaryObject = this.Result as global::Jint.Native.JsDictionaryObject;
			this.Result = null;
			string text = this.lastIdentifier = expression.Text;
			global::Jint.Native.JsInstance value = null;
			if (jsDictionaryObject != null && jsDictionaryObject.TryGetProperty(text, out value))
			{
				this.SetResult(value, jsDictionaryObject);
				return;
			}
			if (this.Result == null && this.typeFullname != null && this.typeFullname.Length > 0)
			{
				this.typeFullname.Append('.').Append(text);
			}
			this.SetResult(global::Jint.Native.JsUndefined.Instance, jsDictionaryObject);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0001F268 File Offset: 0x0001D468
		public void Visit(global::Jint.Expressions.PropertyDeclarationExpression expression)
		{
			global::Jint.Native.JsDictionaryObject jsDictionaryObject = this.Result as global::Jint.Native.JsDictionaryObject;
			switch (expression.Mode)
			{
			case global::Jint.Expressions.PropertyExpressionType.Data:
				expression.Expression.Accept(this);
				jsDictionaryObject.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(jsDictionaryObject, expression.Name, this.Result));
				return;
			case global::Jint.Expressions.PropertyExpressionType.Get:
			case global::Jint.Expressions.PropertyExpressionType.Set:
			{
				global::Jint.Native.JsFunction getFunction = null;
				global::Jint.Native.JsFunction setFunction = null;
				if (expression.GetExpression != null)
				{
					expression.GetExpression.Accept(this);
					getFunction = (global::Jint.Native.JsFunction)this.Result;
				}
				if (expression.SetExpression != null)
				{
					expression.SetExpression.Accept(this);
					setFunction = (global::Jint.Native.JsFunction)this.Result;
				}
				jsDictionaryObject.DefineOwnProperty(new global::Jint.Native.PropertyDescriptor(this.Global, jsDictionaryObject, expression.Name)
				{
					GetFunction = getFunction,
					SetFunction = setFunction,
					Enumerable = true
				});
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0001F344 File Offset: 0x0001D544
		public void Visit(global::Jint.Expressions.Identifier expression)
		{
			this.Result = null;
			string text = this.lastIdentifier = expression.Text;
			global::Jint.Native.Descriptor descriptor = null;
			if (this.CurrentScope.TryGetDescriptor(text, out descriptor))
			{
				if (!descriptor.isReference)
				{
					this.Result = descriptor.Get(this.CurrentScope);
				}
				else
				{
					global::Jint.Native.LinkedDescriptor linkedDescriptor = descriptor as global::Jint.Native.LinkedDescriptor;
					this.SetResult(linkedDescriptor.Get(this.CurrentScope), linkedDescriptor.targetObject);
				}
				if (this.Result != null)
				{
					return;
				}
			}
			if (text == "null")
			{
				this.Result = global::Jint.Native.JsNull.Instance;
			}
			if (text == "undefined")
			{
				this.Result = global::Jint.Native.JsUndefined.Instance;
			}
			if (this.Result == null)
			{
				if (this.typeFullname == null)
				{
					this.typeFullname = new global::System.Text.StringBuilder();
				}
				this.typeFullname.Append(text);
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0001F434 File Offset: 0x0001D634
		private void EnsureClrAllowed()
		{
			if (!this.AllowClr)
			{
				throw new global::System.Security.SecurityException("Use of Clr is not allowed");
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0001F44C File Offset: 0x0001D64C
		public void Visit(global::Jint.Expressions.JsonExpression json)
		{
			global::Jint.Native.JsObject result = this.Global.ObjectClass.New();
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::Jint.Expressions.Expression> keyValuePair in json.Values)
			{
				this.Result = result;
				keyValuePair.Value.Accept(this);
			}
			this.Result = result;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0001F4CC File Offset: 0x0001D6CC
		protected void ResetContinueIfPresent(string label)
		{
			if (this.continueStatement != null && this.continueStatement.Label == label)
			{
				this.continueStatement = null;
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0001F4F8 File Offset: 0x0001D6F8
		protected bool StopStatementFlow()
		{
			return this.exit || this.breakStatement != null || this.continueStatement != null;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0001F520 File Offset: 0x0001D720
		public void Visit(global::Jint.Expressions.ArrayDeclaration expression)
		{
			global::Jint.Native.JsArray jsArray = this.Global.ArrayClass.New();
			int count = expression.Parameters.Count;
			for (int i = 0; i < expression.Parameters.Count; i++)
			{
				expression.Parameters[i].Accept(this);
				jsArray[i.ToString()] = this.Result;
			}
			this.Result = jsArray;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0001F594 File Offset: 0x0001D794
		public void Visit(global::Jint.Expressions.RegexpExpression expression)
		{
			this.Result = this.Global.RegExpClass.New(expression.Regexp, expression.Options.Contains("g"), expression.Options.Contains("i"), expression.Options.Contains("m"));
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0001F5F4 File Offset: 0x0001D7F4
		public void OnDeserialization(object sender)
		{
			this.typeResolver = new global::Jint.CachedTypeResolver();
		}

		// Token: 0x040001F2 RID: 498
		protected internal global::Jint.ITypeResolver typeResolver;

		// Token: 0x040001F3 RID: 499
		protected global::System.Collections.Generic.Stack<global::Jint.Native.JsScope> Scopes = new global::System.Collections.Generic.Stack<global::Jint.Native.JsScope>();

		// Token: 0x040001F4 RID: 500
		protected bool exit;

		// Token: 0x040001F5 RID: 501
		protected global::Jint.Native.JsInstance returnInstance;

		// Token: 0x040001F6 RID: 502
		protected int recursionLevel;

		// Token: 0x040001F7 RID: 503
		private global::System.EventHandler<global::Jint.Debugger.DebugInformation> Step;

		// Token: 0x040001F8 RID: 504
		private global::System.Text.StringBuilder typeFullname;

		// Token: 0x040001F9 RID: 505
		private string lastIdentifier = string.Empty;

		// Token: 0x040001FA RID: 506
		private global::Jint.ExecutionVisitor.ResultInfo lastResult;

		// Token: 0x040001FB RID: 507
		private global::System.Collections.Generic.Stack<global::Jint.ExecutionVisitor.ResultInfo> stackResults = new global::System.Collections.Generic.Stack<global::Jint.ExecutionVisitor.ResultInfo>();

		// Token: 0x040001FC RID: 508
		protected global::Jint.Expressions.ContinueStatement continueStatement;

		// Token: 0x040001FD RID: 509
		protected global::Jint.Expressions.BreakStatement breakStatement;

		// Token: 0x040001FE RID: 510
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.IGlobal <Global>k__BackingField;

		// Token: 0x040001FF RID: 511
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsScope <GlobalScope>k__BackingField;

		// Token: 0x04000200 RID: 512
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.Stack<string> <CallStack>k__BackingField;

		// Token: 0x04000201 RID: 513
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Expressions.Statement <CurrentStatement>k__BackingField;

		// Token: 0x04000202 RID: 514
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <DebugMode>k__BackingField;

		// Token: 0x04000203 RID: 515
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <MaxRecursions>k__BackingField;

		// Token: 0x04000204 RID: 516
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <AllowClr>k__BackingField;

		// Token: 0x04000205 RID: 517
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Security.PermissionSet <PermissionSet>k__BackingField;

		// Token: 0x02000148 RID: 328
		private struct ResultInfo
		{
			// Token: 0x040006AD RID: 1709
			public global::Jint.Native.JsDictionaryObject baseObject;

			// Token: 0x040006AE RID: 1710
			public global::Jint.Native.JsInstance result;
		}
	}
}

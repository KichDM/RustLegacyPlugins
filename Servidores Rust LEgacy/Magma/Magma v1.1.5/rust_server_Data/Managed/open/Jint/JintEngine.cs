using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Antlr.Runtime;
using Jint.Debugger;
using Jint.Expressions;
using Jint.Native;

namespace Jint
{
	// Token: 0x02000069 RID: 105
	[global::System.Serializable]
	public class JintEngine
	{
		// Token: 0x0600053D RID: 1341 RVA: 0x00027E60 File Offset: 0x00026060
		[global::System.Diagnostics.DebuggerStepThrough]
		public JintEngine() : this(global::Jint.Options.Strict | global::Jint.Options.Ecmascript5)
		{
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00027E6C File Offset: 0x0002606C
		[global::System.Diagnostics.DebuggerStepThrough]
		public JintEngine(global::Jint.Options options)
		{
			this.Visitor = new global::Jint.ExecutionVisitor(options);
			this.permissionSet = new global::System.Security.PermissionSet(global::System.Security.Permissions.PermissionState.None);
			this.Visitor.AllowClr = this.allowClr;
			this.MaxRecursions = 0x190;
			global::Jint.Native.JsObject jsObject = this.Visitor.Global as global::Jint.Native.JsObject;
			jsObject["ToBoolean"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, bool>(global::System.Convert.ToBoolean));
			jsObject["ToByte"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, byte>(global::System.Convert.ToByte));
			jsObject["ToChar"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, char>(global::System.Convert.ToChar));
			jsObject["ToDateTime"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, global::System.DateTime>(global::System.Convert.ToDateTime));
			jsObject["ToDecimal"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, decimal>(global::System.Convert.ToDecimal));
			jsObject["ToDouble"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, double>(global::System.Convert.ToDouble));
			jsObject["ToInt16"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, short>(global::System.Convert.ToInt16));
			jsObject["ToInt32"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, int>(global::System.Convert.ToInt32));
			jsObject["ToInt64"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, long>(global::System.Convert.ToInt64));
			jsObject["ToSByte"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, sbyte>(global::System.Convert.ToSByte));
			jsObject["ToSingle"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, float>(global::System.Convert.ToSingle));
			jsObject["ToString"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, string>(global::System.Convert.ToString));
			jsObject["ToUInt16"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, ushort>(global::System.Convert.ToUInt16));
			jsObject["ToUInt32"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, uint>(global::System.Convert.ToUInt32));
			jsObject["ToUInt64"] = this.Visitor.Global.FunctionClass.New(new global::System.Func<object, ulong>(global::System.Convert.ToUInt64));
			this.BreakPoints = new global::System.Collections.Generic.List<global::Jint.Debugger.BreakPoint>();
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x00028168 File Offset: 0x00026368
		public global::Jint.Native.IGlobal Global
		{
			get
			{
				return this.Visitor.Global;
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00028178 File Offset: 0x00026378
		public static global::Jint.Expressions.Program Compile(string source, bool debugInformation)
		{
			global::Jint.Expressions.Program result = null;
			if (!string.IsNullOrEmpty(source))
			{
				global::ES3Lexer tokenSource = new global::ES3Lexer(new global::Antlr.Runtime.ANTLRStringStream(source));
				global::ES3Parser es3Parser = new global::ES3Parser(new global::Antlr.Runtime.CommonTokenStream(tokenSource))
				{
					DebugMode = debugInformation
				};
				result = es3Parser.program().value;
				if (es3Parser.Errors != null && es3Parser.Errors.Count > 0)
				{
					throw new global::Jint.JintException(string.Join(global::System.Environment.NewLine, es3Parser.Errors.ToArray()));
				}
			}
			return result;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x000281FC File Offset: 0x000263FC
		public static bool HasErrors(string script, out string errors)
		{
			bool result;
			try
			{
				errors = null;
				global::Jint.Expressions.Program program = global::Jint.JintEngine.Compile(script, false);
				result = (program != null);
			}
			catch (global::System.Exception ex)
			{
				errors = ex.Message;
				result = true;
			}
			return result;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00028244 File Offset: 0x00026444
		public object Run(string script)
		{
			return this.Run(script, true);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00028250 File Offset: 0x00026450
		public object Run(global::Jint.Expressions.Program program)
		{
			return this.Run(program, true);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0002825C File Offset: 0x0002645C
		public object Run(global::System.IO.TextReader reader)
		{
			return this.Run(reader.ReadToEnd());
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0002826C File Offset: 0x0002646C
		public object Run(global::System.IO.TextReader reader, bool unwrap)
		{
			return this.Run(reader.ReadToEnd(), unwrap);
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0002827C File Offset: 0x0002647C
		public object Run(string script, bool unwrap)
		{
			if (script == null)
			{
				throw new global::System.ArgumentException("Script can't be null", "script");
			}
			global::Jint.Expressions.Program program;
			try
			{
				program = global::Jint.JintEngine.Compile(script, this.DebugMode);
			}
			catch (global::System.Exception innerException)
			{
				throw new global::Jint.JintException("An unexpected error occured while parsing the script", innerException);
			}
			if (program == null)
			{
				return null;
			}
			return this.Run(program, unwrap);
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x000282E0 File Offset: 0x000264E0
		public object Run(global::Jint.Expressions.Program program, bool unwrap)
		{
			if (program == null)
			{
				throw new global::System.ArgumentException("Script can't be null", "script");
			}
			this.Visitor.DebugMode = this.DebugMode;
			this.Visitor.MaxRecursions = this.MaxRecursions;
			this.Visitor.PermissionSet = this.permissionSet;
			this.Visitor.AllowClr = this.allowClr;
			this.Visitor.Result = null;
			if (this.DebugMode)
			{
				this.Visitor.Step += this.OnStep;
			}
			try
			{
				this.Visitor.Visit(program);
			}
			catch (global::System.Security.SecurityException)
			{
				throw;
			}
			catch (global::Jint.Native.JsException ex)
			{
				string arg = ex.Message;
				if (ex.Value is global::Jint.Native.JsError)
				{
					arg = ex.Value.Value.ToString();
				}
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				string arg2 = string.Empty;
				if (this.DebugMode)
				{
					while (this.Visitor.CallStack.Count > 0)
					{
						stringBuilder.AppendLine(this.Visitor.CallStack.Pop());
					}
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Insert(0, global::System.Environment.NewLine + "------ Stack Trace:" + global::System.Environment.NewLine);
					}
				}
				if (this.Visitor.CurrentStatement.Source != null)
				{
					arg2 = global::System.Environment.NewLine + this.Visitor.CurrentStatement.Source.ToString() + global::System.Environment.NewLine + this.Visitor.CurrentStatement.Source.Code;
				}
				throw new global::Jint.JintException(arg + arg2 + stringBuilder, ex);
			}
			catch (global::System.Exception ex2)
			{
				global::System.Text.StringBuilder stringBuilder2 = new global::System.Text.StringBuilder();
				string arg3 = string.Empty;
				if (this.DebugMode)
				{
					while (this.Visitor.CallStack.Count > 0)
					{
						stringBuilder2.AppendLine(this.Visitor.CallStack.Pop());
					}
					if (stringBuilder2.Length > 0)
					{
						stringBuilder2.Insert(0, global::System.Environment.NewLine + "------ Stack Trace:" + global::System.Environment.NewLine);
					}
				}
				if (this.Visitor.CurrentStatement != null && this.Visitor.CurrentStatement.Source != null)
				{
					arg3 = global::System.Environment.NewLine + this.Visitor.CurrentStatement.Source.ToString() + global::System.Environment.NewLine + this.Visitor.CurrentStatement.Source.Code;
				}
				throw new global::Jint.JintException(ex2.Message + arg3 + stringBuilder2, ex2);
			}
			finally
			{
				this.Visitor.Step -= this.OnStep;
			}
			if (this.Visitor.Result == null)
			{
				return null;
			}
			if (!unwrap)
			{
				return this.Visitor.Result;
			}
			return this.Visitor.Global.Marshaller.MarshalJsValue<object>(this.Visitor.Result);
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000548 RID: 1352 RVA: 0x00028630 File Offset: 0x00026830
		// (remove) Token: 0x06000549 RID: 1353 RVA: 0x0002866C File Offset: 0x0002686C
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

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600054A RID: 1354 RVA: 0x000286A8 File Offset: 0x000268A8
		// (remove) Token: 0x0600054B RID: 1355 RVA: 0x000286E4 File Offset: 0x000268E4
		public event global::System.EventHandler<global::Jint.Debugger.DebugInformation> Break
		{
			add
			{
				global::System.EventHandler<global::Jint.Debugger.DebugInformation> eventHandler = this.Break;
				global::System.EventHandler<global::Jint.Debugger.DebugInformation> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					global::System.EventHandler<global::Jint.Debugger.DebugInformation> value2 = (global::System.EventHandler<global::Jint.Debugger.DebugInformation>)global::System.Delegate.Combine(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler<global::Jint.Debugger.DebugInformation>>(ref this.Break, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				global::System.EventHandler<global::Jint.Debugger.DebugInformation> eventHandler = this.Break;
				global::System.EventHandler<global::Jint.Debugger.DebugInformation> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					global::System.EventHandler<global::Jint.Debugger.DebugInformation> value2 = (global::System.EventHandler<global::Jint.Debugger.DebugInformation>)global::System.Delegate.Remove(eventHandler2, value);
					eventHandler = global::System.Threading.Interlocked.CompareExchange<global::System.EventHandler<global::Jint.Debugger.DebugInformation>>(ref this.Break, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x00028720 File Offset: 0x00026920
		// (set) Token: 0x0600054D RID: 1357 RVA: 0x00028728 File Offset: 0x00026928
		public global::System.Collections.Generic.List<global::Jint.Debugger.BreakPoint> BreakPoints
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<BreakPoints>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<BreakPoints>k__BackingField = value;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x00028734 File Offset: 0x00026934
		// (set) Token: 0x0600054F RID: 1359 RVA: 0x0002873C File Offset: 0x0002693C
		public bool DebugMode
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<DebugMode>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<DebugMode>k__BackingField = value;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000550 RID: 1360 RVA: 0x00028748 File Offset: 0x00026948
		// (set) Token: 0x06000551 RID: 1361 RVA: 0x00028750 File Offset: 0x00026950
		public int MaxRecursions
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<MaxRecursions>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<MaxRecursions>k__BackingField = value;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000552 RID: 1362 RVA: 0x0002875C File Offset: 0x0002695C
		// (set) Token: 0x06000553 RID: 1363 RVA: 0x00028764 File Offset: 0x00026964
		public global::System.Collections.Generic.List<string> WatchList
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<WatchList>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<WatchList>k__BackingField = value;
			}
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00028770 File Offset: 0x00026970
		public global::Jint.JintEngine SetDebugMode(bool debugMode)
		{
			this.DebugMode = debugMode;
			return this;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0002877C File Offset: 0x0002697C
		public global::Jint.JintEngine SetMaxRecursions(int maxRecursions)
		{
			this.MaxRecursions = maxRecursions;
			return this;
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00028788 File Offset: 0x00026988
		public global::Jint.JintEngine SetParameter(string name, object value)
		{
			this.Visitor.GlobalScope[name] = this.Visitor.Global.WrapClr(value);
			return this;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x000287BC File Offset: 0x000269BC
		public global::Jint.JintEngine SetParameter(string name, double value)
		{
			this.Visitor.GlobalScope[name] = this.Visitor.Global.NumberClass.New(value);
			return this;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x000287F8 File Offset: 0x000269F8
		public global::Jint.JintEngine SetParameter(string name, string value)
		{
			if (value == null)
			{
				this.Visitor.GlobalScope[name] = global::Jint.Native.JsNull.Instance;
			}
			else
			{
				this.Visitor.GlobalScope[name] = this.Visitor.Global.StringClass.New(value);
			}
			return this;
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00028854 File Offset: 0x00026A54
		public global::Jint.JintEngine SetParameter(string name, int value)
		{
			this.Visitor.GlobalScope[name] = this.Visitor.Global.WrapClr(value);
			return this;
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00028890 File Offset: 0x00026A90
		public global::Jint.JintEngine SetParameter(string name, bool value)
		{
			this.Visitor.GlobalScope[name] = this.Visitor.Global.BooleanClass.New(value);
			return this;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x000288CC File Offset: 0x00026ACC
		public global::Jint.JintEngine SetParameter(string name, global::System.DateTime value)
		{
			this.Visitor.GlobalScope[name] = this.Visitor.Global.DateClass.New(value);
			return this;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00028908 File Offset: 0x00026B08
		public global::Jint.JintEngine AddPermission(global::System.Security.IPermission perm)
		{
			this.permissionSet.AddPermission(perm);
			return this;
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00028918 File Offset: 0x00026B18
		public global::Jint.JintEngine SetFunction(string name, global::Jint.Native.JsFunction function)
		{
			this.Visitor.GlobalScope[name] = function;
			return this;
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00028930 File Offset: 0x00026B30
		public object CallFunction(string name, params object[] args)
		{
			global::Jint.Native.JsInstance result = this.Visitor.Result;
			this.Visitor.Visit(new global::Jint.Expressions.Identifier(name));
			object result2 = this.CallFunction((global::Jint.Native.JsFunction)this.Visitor.Result, args);
			this.Visitor.Result = result;
			return result2;
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00028984 File Offset: 0x00026B84
		public object CallFunction(global::Jint.Native.JsFunction function, params object[] args)
		{
			this.Visitor.ExecuteFunction(function, null, global::System.Array.ConvertAll<object, global::Jint.Native.JsInstance>(args, (object x) => this.Visitor.Global.Marshaller.MarshalClrValue<object>(x)));
			return this.Visitor.Global.Marshaller.MarshalJsValue<object>(this.Visitor.Returned);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x000289D4 File Offset: 0x00026BD4
		public global::Jint.JintEngine SetFunction(string name, global::System.Delegate function)
		{
			this.Visitor.GlobalScope[name] = this.Visitor.Global.FunctionClass.New(function);
			return this;
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x00028A10 File Offset: 0x00026C10
		public static string EscapteStringLiteral(string value)
		{
			return value.Replace("\\", "\\\\").Replace("'", "\\'").Replace(global::System.Environment.NewLine, "\\r\\n");
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00028A40 File Offset: 0x00026C40
		protected void OnStep(object sender, global::Jint.Debugger.DebugInformation info)
		{
			if (this.Step != null)
			{
				this.Step(this, info);
			}
			if (this.Break != null)
			{
				global::Jint.Debugger.BreakPoint breakPoint = this.BreakPoints.Find((global::Jint.Debugger.BreakPoint l) => (l.Line > info.CurrentStatement.Source.Start.Line || (l.Line == info.CurrentStatement.Source.Start.Line && l.Char >= info.CurrentStatement.Source.Start.Char)) && (l.Line < info.CurrentStatement.Source.Stop.Line || (l.Line == info.CurrentStatement.Source.Stop.Line && l.Char <= info.CurrentStatement.Source.Stop.Char)) && (string.IsNullOrEmpty(l.Condition) || global::System.Convert.ToBoolean(this.Run(l.Condition))));
				if (breakPoint != null)
				{
					this.Break(this, info);
				}
			}
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00028AC8 File Offset: 0x00026CC8
		protected void OnBreak(object sender, global::Jint.Debugger.DebugInformation info)
		{
			if (this.Break != null)
			{
				this.Break(this, info);
			}
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00028AE4 File Offset: 0x00026CE4
		public global::Jint.JintEngine DisableSecurity()
		{
			this.permissionSet = new global::System.Security.PermissionSet(global::System.Security.Permissions.PermissionState.Unrestricted);
			return this;
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00028AF4 File Offset: 0x00026CF4
		public global::Jint.JintEngine AllowClr()
		{
			this.allowClr = true;
			return this;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00028B00 File Offset: 0x00026D00
		public global::Jint.JintEngine AllowClr(bool value)
		{
			this.allowClr = value;
			return this;
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00028B0C File Offset: 0x00026D0C
		public global::Jint.JintEngine EnableSecurity()
		{
			this.permissionSet = new global::System.Security.PermissionSet(global::System.Security.Permissions.PermissionState.None);
			return this;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00028B1C File Offset: 0x00026D1C
		public void Save(global::System.IO.Stream s)
		{
			global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			binaryFormatter.Serialize(s, this.Visitor);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00028B40 File Offset: 0x00026D40
		public static void Load(global::Jint.JintEngine engine, global::System.IO.Stream s)
		{
			global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new global::System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			global::Jint.ExecutionVisitor visitor = (global::Jint.ExecutionVisitor)binaryFormatter.Deserialize(s);
			engine.Visitor = visitor;
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00028B6C File Offset: 0x00026D6C
		public static global::Jint.JintEngine Load(global::System.IO.Stream s)
		{
			global::Jint.JintEngine jintEngine = new global::Jint.JintEngine();
			global::Jint.JintEngine.Load(jintEngine, s);
			return jintEngine;
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00028B8C File Offset: 0x00026D8C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsInstance <CallFunction>b__1(object x)
		{
			return this.Visitor.Global.Marshaller.MarshalClrValue<object>(x);
		}

		// Token: 0x04000255 RID: 597
		protected global::Jint.ExecutionVisitor Visitor;

		// Token: 0x04000256 RID: 598
		private bool allowClr;

		// Token: 0x04000257 RID: 599
		private global::System.Security.PermissionSet permissionSet;

		// Token: 0x04000258 RID: 600
		private global::System.EventHandler<global::Jint.Debugger.DebugInformation> Step;

		// Token: 0x04000259 RID: 601
		private global::System.EventHandler<global::Jint.Debugger.DebugInformation> Break;

		// Token: 0x0400025A RID: 602
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<global::Jint.Debugger.BreakPoint> <BreakPoints>k__BackingField;

		// Token: 0x0400025B RID: 603
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <DebugMode>k__BackingField;

		// Token: 0x0400025C RID: 604
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <MaxRecursions>k__BackingField;

		// Token: 0x0400025D RID: 605
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::System.Collections.Generic.List<string> <WatchList>k__BackingField;

		// Token: 0x02000154 RID: 340
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass4
		{
			// Token: 0x06000C0E RID: 3086 RVA: 0x0003C8D4 File Offset: 0x0003AAD4
			public <>c__DisplayClass4()
			{
			}

			// Token: 0x06000C0F RID: 3087 RVA: 0x0003C8DC File Offset: 0x0003AADC
			public bool <OnStep>b__2(global::Jint.Debugger.BreakPoint l)
			{
				return (l.Line > this.info.CurrentStatement.Source.Start.Line || (l.Line == this.info.CurrentStatement.Source.Start.Line && l.Char >= this.info.CurrentStatement.Source.Start.Char)) && (l.Line < this.info.CurrentStatement.Source.Stop.Line || (l.Line == this.info.CurrentStatement.Source.Stop.Line && l.Char <= this.info.CurrentStatement.Source.Stop.Char)) && (string.IsNullOrEmpty(l.Condition) || global::System.Convert.ToBoolean(this.<>4__this.Run(l.Condition)));
			}

			// Token: 0x040006E2 RID: 1762
			public global::Jint.JintEngine <>4__this;

			// Token: 0x040006E3 RID: 1763
			public global::Jint.Debugger.DebugInformation info;
		}
	}
}

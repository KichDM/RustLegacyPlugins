using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch;
using UnityEngine;

// Token: 0x020005A5 RID: 1445
public class ContextTest : global::Facepunch.MonoBehaviour, global::IContextRequestable, global::IContextRequestableMenu, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06002FB3 RID: 12211 RVA: 0x000B5FFC File Offset: 0x000B41FC
	public ContextTest()
	{
	}

	// Token: 0x06002FB4 RID: 12212 RVA: 0x000B6004 File Offset: 0x000B4204
	public global::ContextExecution ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick | global::ContextExecution.Menu;
	}

	// Token: 0x06002FB5 RID: 12213 RVA: 0x000B6008 File Offset: 0x000B4208
	public global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> ContextQueryMenu(global::Controllable controllable, ulong timestamp)
	{
		yield return new global::ContextTest.ContextCallback(0, "Option1", new global::ContextTest.CallbackFunction(this.Option1));
		yield return new global::ContextTest.ContextCallback(1, "Option2", new global::ContextTest.CallbackFunction(this.Option2));
		yield break;
	}

	// Token: 0x06002FB6 RID: 12214 RVA: 0x000B602C File Offset: 0x000B422C
	public global::ContextResponse ContextRespondMenu(global::Controllable controllable, global::ContextActionPrototype action, ulong timestamp)
	{
		global::ContextTest.ContextCallback contextCallback = (global::ContextTest.ContextCallback)action;
		return contextCallback.func(controllable);
	}

	// Token: 0x06002FB7 RID: 12215 RVA: 0x000B604C File Offset: 0x000B424C
	private global::ContextResponse Option1(global::Controllable control)
	{
		global::UnityEngine.Debug.Log("Wee option 1");
		return global::ContextResponse.DoneBreak;
	}

	// Token: 0x06002FB8 RID: 12216 RVA: 0x000B605C File Offset: 0x000B425C
	private global::ContextResponse Option2(global::Controllable control)
	{
		global::UnityEngine.Debug.Log("Wee option 2");
		return global::ContextResponse.DoneBreak;
	}

	// Token: 0x020005A6 RID: 1446
	private class ContextCallback : global::ContextActionPrototype
	{
		// Token: 0x06002FB9 RID: 12217 RVA: 0x000B606C File Offset: 0x000B426C
		public ContextCallback(int name, string text, global::ContextTest.CallbackFunction function)
		{
			this.name = name;
			this.text = text;
			this.func = function;
		}

		// Token: 0x0400199E RID: 6558
		public global::ContextTest.CallbackFunction func;
	}

	// Token: 0x020005A7 RID: 1447
	// (Invoke) Token: 0x06002FBB RID: 12219
	private delegate global::ContextResponse CallbackFunction(global::Controllable controllable);

	// Token: 0x020005A8 RID: 1448
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <ContextQueryMenu>c__Iterator43 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype>, global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype>
	{
		// Token: 0x06002FBE RID: 12222 RVA: 0x000B608C File Offset: 0x000B428C
		public <ContextQueryMenu>c__Iterator43()
		{
		}

		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x06002FBF RID: 12223 RVA: 0x000B6094 File Offset: 0x000B4294
		global::ContextActionPrototype global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000A1C RID: 2588
		// (get) Token: 0x06002FC0 RID: 12224 RVA: 0x000B609C File Offset: 0x000B429C
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002FC1 RID: 12225 RVA: 0x000B60A4 File Offset: 0x000B42A4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<ContextActionPrototype>.GetEnumerator();
		}

		// Token: 0x06002FC2 RID: 12226 RVA: 0x000B60AC File Offset: 0x000B42AC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype> global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ContextTest.<ContextQueryMenu>c__Iterator43 <ContextQueryMenu>c__Iterator = new global::ContextTest.<ContextQueryMenu>c__Iterator43();
			<ContextQueryMenu>c__Iterator.<>f__this = this;
			return <ContextQueryMenu>c__Iterator;
		}

		// Token: 0x06002FC3 RID: 12227 RVA: 0x000B60E0 File Offset: 0x000B42E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.$current = new global::ContextTest.ContextCallback(0, "Option1", new global::ContextTest.CallbackFunction(base.Option1));
				this.$PC = 1;
				return true;
			case 1U:
				this.$current = new global::ContextTest.ContextCallback(1, "Option2", new global::ContextTest.CallbackFunction(base.Option2));
				this.$PC = 2;
				return true;
			case 2U:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06002FC4 RID: 12228 RVA: 0x000B617C File Offset: 0x000B437C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06002FC5 RID: 12229 RVA: 0x000B6188 File Offset: 0x000B4388
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400199F RID: 6559
		internal int $PC;

		// Token: 0x040019A0 RID: 6560
		internal global::ContextActionPrototype $current;

		// Token: 0x040019A1 RID: 6561
		internal global::ContextTest <>f__this;
	}
}

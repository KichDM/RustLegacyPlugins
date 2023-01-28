using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch;

// Token: 0x020005A9 RID: 1449
public class ContextMessenger : global::Facepunch.MonoBehaviour, global::IContextRequestable, global::IContextRequestableMenu, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06002FC6 RID: 12230 RVA: 0x000B6190 File Offset: 0x000B4390
	public ContextMessenger()
	{
	}

	// Token: 0x06002FC7 RID: 12231 RVA: 0x000B6198 File Offset: 0x000B4398
	public global::ContextExecution ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return (this.messageOptions != null && this.messageOptions.Length != 0) ? global::ContextExecution.Menu : global::ContextExecution.NotAvailable;
	}

	// Token: 0x06002FC8 RID: 12232 RVA: 0x000B61BC File Offset: 0x000B43BC
	public global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> ContextQueryMenu(global::Controllable controllable, ulong timestamp)
	{
		int name = 0;
		foreach (string message in this.messageOptions)
		{
			int name2;
			name = (name2 = name) + 1;
			yield return new global::ContextMessenger.MessageAction(name2, message, message);
		}
		yield break;
	}

	// Token: 0x06002FC9 RID: 12233 RVA: 0x000B61E0 File Offset: 0x000B43E0
	public global::ContextResponse ContextRespondMenu(global::Controllable controllable, global::ContextActionPrototype action, ulong timestamp)
	{
		base.SendMessage(((global::ContextMessenger.MessageAction)action).message, controllable);
		return global::ContextResponse.DoneBreak;
	}

	// Token: 0x040019A2 RID: 6562
	public string[] messageOptions;

	// Token: 0x020005AA RID: 1450
	private class MessageAction : global::ContextActionPrototype
	{
		// Token: 0x06002FCA RID: 12234 RVA: 0x000B61F8 File Offset: 0x000B43F8
		public MessageAction(int name, string text, string message)
		{
			this.name = name;
			this.text = text;
			this.message = message;
		}

		// Token: 0x040019A3 RID: 6563
		public string message;
	}

	// Token: 0x020005AB RID: 1451
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <ContextQueryMenu>c__Iterator44 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype>, global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype>
	{
		// Token: 0x06002FCB RID: 12235 RVA: 0x000B6218 File Offset: 0x000B4418
		public <ContextQueryMenu>c__Iterator44()
		{
		}

		// Token: 0x17000A1D RID: 2589
		// (get) Token: 0x06002FCC RID: 12236 RVA: 0x000B6220 File Offset: 0x000B4420
		global::ContextActionPrototype global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000A1E RID: 2590
		// (get) Token: 0x06002FCD RID: 12237 RVA: 0x000B6228 File Offset: 0x000B4428
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002FCE RID: 12238 RVA: 0x000B6230 File Offset: 0x000B4430
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<ContextActionPrototype>.GetEnumerator();
		}

		// Token: 0x06002FCF RID: 12239 RVA: 0x000B6238 File Offset: 0x000B4438
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype> global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ContextMessenger.<ContextQueryMenu>c__Iterator44 <ContextQueryMenu>c__Iterator = new global::ContextMessenger.<ContextQueryMenu>c__Iterator44();
			<ContextQueryMenu>c__Iterator.<>f__this = this;
			return <ContextQueryMenu>c__Iterator;
		}

		// Token: 0x06002FD0 RID: 12240 RVA: 0x000B626C File Offset: 0x000B446C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				name = 0;
				array = this.messageOptions;
				i = 0;
				break;
			case 1U:
				i++;
				break;
			default:
				return false;
			}
			if (i < array.Length)
			{
				message = array[i];
				this.$current = new global::ContextMessenger.MessageAction(name++, message, message);
				this.$PC = 1;
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06002FD1 RID: 12241 RVA: 0x000B6334 File Offset: 0x000B4534
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06002FD2 RID: 12242 RVA: 0x000B6340 File Offset: 0x000B4540
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040019A4 RID: 6564
		internal int <name>__0;

		// Token: 0x040019A5 RID: 6565
		internal string[] <$s_438>__1;

		// Token: 0x040019A6 RID: 6566
		internal int <$s_439>__2;

		// Token: 0x040019A7 RID: 6567
		internal string <message>__3;

		// Token: 0x040019A8 RID: 6568
		internal int $PC;

		// Token: 0x040019A9 RID: 6569
		internal global::ContextActionPrototype $current;

		// Token: 0x040019AA RID: 6570
		internal global::ContextMessenger <>f__this;
	}
}

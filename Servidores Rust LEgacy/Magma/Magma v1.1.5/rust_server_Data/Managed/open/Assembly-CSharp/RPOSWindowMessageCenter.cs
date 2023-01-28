using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000542 RID: 1346
public struct RPOSWindowMessageCenter
{
	// Token: 0x06002DFE RID: 11774 RVA: 0x000AEBC0 File Offset: 0x000ACDC0
	// Note: this type is marked as 'beforefieldinit'.
	static RPOSWindowMessageCenter()
	{
	}

	// Token: 0x06002DFF RID: 11775 RVA: 0x000AEBD0 File Offset: 0x000ACDD0
	public void Fire(global::RPOSWindow window, global::RPOSWindowMessage message)
	{
		if (this.init && message >= global::RPOSWindowMessage.WillShow && message <= global::RPOSWindowMessage.DidHide)
		{
			this.responders[message - global::RPOSWindowMessage.WillShow].Invoke(window, message);
		}
	}

	// Token: 0x06002E00 RID: 11776 RVA: 0x000AEC0C File Offset: 0x000ACE0C
	public bool Add(global::RPOSWindowMessage message, global::RPOSWindowMessageHandler handler)
	{
		if (message < global::RPOSWindowMessage.WillShow || message > global::RPOSWindowMessage.DidHide || handler == null)
		{
			return false;
		}
		if (!this.init)
		{
			this.responders = new global::RPOSWindowMessageCenter.RPOSWindowMessageResponder[4];
			this.init = true;
		}
		return this.responders[message - global::RPOSWindowMessage.WillShow].Add(handler);
	}

	// Token: 0x06002E01 RID: 11777 RVA: 0x000AEC64 File Offset: 0x000ACE64
	public bool Remove(global::RPOSWindowMessage message, global::RPOSWindowMessageHandler handler)
	{
		return this.init && message >= global::RPOSWindowMessage.WillShow && message <= global::RPOSWindowMessage.DidHide && handler != null && this.responders[message - global::RPOSWindowMessage.WillShow].Remove(handler);
	}

	// Token: 0x06002E02 RID: 11778 RVA: 0x000AEC9C File Offset: 0x000ACE9C
	public global::System.Collections.Generic.IEnumerable<global::RPOSWindowMessageHandler> EnumerateHandlers(global::RPOSWindowMessage message)
	{
		if (!this.init || message < global::RPOSWindowMessage.WillShow || message > global::RPOSWindowMessage.DidHide)
		{
			return global::RPOSWindowMessageCenter.none;
		}
		int num = message - global::RPOSWindowMessage.WillShow;
		if (!this.responders[num].init || this.responders[num].count == 0)
		{
			return global::RPOSWindowMessageCenter.none;
		}
		return this.responders[num].handlers;
	}

	// Token: 0x06002E03 RID: 11779 RVA: 0x000AED10 File Offset: 0x000ACF10
	public int CountHandlers(global::RPOSWindowMessage message)
	{
		return (this.init && message >= global::RPOSWindowMessage.WillShow && message <= global::RPOSWindowMessage.DidHide) ? this.responders[message - global::RPOSWindowMessage.WillShow].count : 0;
	}

	// Token: 0x040017BA RID: 6074
	public const global::RPOSWindowMessage kBegin = global::RPOSWindowMessage.WillShow;

	// Token: 0x040017BB RID: 6075
	public const global::RPOSWindowMessage kLast = global::RPOSWindowMessage.DidHide;

	// Token: 0x040017BC RID: 6076
	public const global::RPOSWindowMessage kEnd = global::RPOSWindowMessage.WillClose;

	// Token: 0x040017BD RID: 6077
	public const int kMessageCount = 4;

	// Token: 0x040017BE RID: 6078
	private global::RPOSWindowMessageCenter.RPOSWindowMessageResponder[] responders;

	// Token: 0x040017BF RID: 6079
	private bool init;

	// Token: 0x040017C0 RID: 6080
	private static readonly global::RPOSWindowMessageHandler[] none = new global::RPOSWindowMessageHandler[0];

	// Token: 0x02000543 RID: 1347
	private struct RPOSWindowMessageResponder
	{
		// Token: 0x06002E04 RID: 11780 RVA: 0x000AED50 File Offset: 0x000ACF50
		public bool Add(global::RPOSWindowMessageHandler handler)
		{
			if (handler == null)
			{
				return false;
			}
			if (!this.init)
			{
				this.handlerGate = new global::System.Collections.Generic.HashSet<global::RPOSWindowMessageHandler>();
				this.handlers = new global::System.Collections.Generic.List<global::RPOSWindowMessageHandler>();
				this.init = true;
				this.handlerGate.Add(handler);
			}
			else if (!this.handlerGate.Add(handler))
			{
				return false;
			}
			this.handlers.Add(handler);
			this.count++;
			return true;
		}

		// Token: 0x06002E05 RID: 11781 RVA: 0x000AEDD0 File Offset: 0x000ACFD0
		public bool Remove(global::RPOSWindowMessageHandler handler)
		{
			if (!this.init || handler == null || !this.handlerGate.Remove(handler))
			{
				return false;
			}
			this.handlers.Remove(handler);
			this.count--;
			return true;
		}

		// Token: 0x06002E06 RID: 11782 RVA: 0x000AEE20 File Offset: 0x000AD020
		private bool TryInvoke(global::RPOSWindow window, global::RPOSWindowMessage message, int i)
		{
			global::RPOSWindowMessageHandler rposwindowMessageHandler = this.handlers[i];
			bool result;
			try
			{
				result = rposwindowMessageHandler(window, message);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogError(string.Concat(new object[]
				{
					"handler ",
					rposwindowMessageHandler,
					" threw exception with message ",
					message,
					" on window ",
					window,
					" and will no longer execute. The exception is below\r\n",
					ex
				}), window);
				result = false;
			}
			return result;
		}

		// Token: 0x06002E07 RID: 11783 RVA: 0x000AEEB4 File Offset: 0x000AD0B4
		public void Invoke(global::RPOSWindow window, global::RPOSWindowMessage message)
		{
			if (!this.init || this.count == 0)
			{
				return;
			}
			if ((message - global::RPOSWindowMessage.WillShow & 1) == 1)
			{
				for (int i = this.count - 1; i >= 0; i--)
				{
					if (!this.TryInvoke(window, message, i))
					{
						this.handlerGate.Remove(this.handlers[i]);
						this.handlers.RemoveAt(i);
						this.count--;
					}
				}
			}
			else
			{
				for (int j = 0; j < this.count; j++)
				{
					if (!this.TryInvoke(window, message, j))
					{
						this.handlerGate.Remove(this.handlers[j]);
						this.handlers.RemoveAt(j--);
						this.count--;
					}
				}
			}
		}

		// Token: 0x040017C1 RID: 6081
		public global::System.Collections.Generic.HashSet<global::RPOSWindowMessageHandler> handlerGate;

		// Token: 0x040017C2 RID: 6082
		public global::System.Collections.Generic.List<global::RPOSWindowMessageHandler> handlers;

		// Token: 0x040017C3 RID: 6083
		public int count;

		// Token: 0x040017C4 RID: 6084
		public bool init;
	}
}

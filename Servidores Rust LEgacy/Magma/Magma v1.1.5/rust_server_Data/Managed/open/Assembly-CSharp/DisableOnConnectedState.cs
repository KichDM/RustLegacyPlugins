using System;
using UnityEngine;

// Token: 0x02000059 RID: 89
public class DisableOnConnectedState : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600028C RID: 652 RVA: 0x0000D150 File Offset: 0x0000B350
	public DisableOnConnectedState()
	{
	}

	// Token: 0x0600028D RID: 653 RVA: 0x0000D158 File Offset: 0x0000B358
	// Note: this type is marked as 'beforefieldinit'.
	static DisableOnConnectedState()
	{
	}

	// Token: 0x0600028E RID: 654 RVA: 0x0000D15C File Offset: 0x0000B35C
	public static void OnDisconnected()
	{
		global::DisableOnConnectedState.connectedStatus = false;
		global::UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::DisableOnConnectedState));
		foreach (global::DisableOnConnectedState disableOnConnectedState in array)
		{
			if (disableOnConnectedState.gameObject == null)
			{
				return;
			}
			disableOnConnectedState.DoOnDisconnected();
		}
	}

	// Token: 0x0600028F RID: 655 RVA: 0x0000D1B8 File Offset: 0x0000B3B8
	public static void OnConnected()
	{
		global::DisableOnConnectedState.connectedStatus = true;
		global::UnityEngine.Object[] array = global::Resources.FindObjectsOfTypeAll(typeof(global::DisableOnConnectedState));
		foreach (global::DisableOnConnectedState disableOnConnectedState in array)
		{
			if (disableOnConnectedState.gameObject == null)
			{
				return;
			}
			disableOnConnectedState.DoOnConnected();
		}
	}

	// Token: 0x06000290 RID: 656 RVA: 0x0000D214 File Offset: 0x0000B414
	private void Start()
	{
		if (global::DisableOnConnectedState.connectedStatus)
		{
			this.DoOnConnected();
		}
		else
		{
			this.DoOnDisconnected();
		}
	}

	// Token: 0x06000291 RID: 657 RVA: 0x0000D234 File Offset: 0x0000B434
	protected void DoOnDisconnected()
	{
		base.gameObject.SetActive(this.disableWhenConnected);
		global::dfControl component = base.gameObject.GetComponent<global::dfControl>();
		if (component)
		{
			if (!this.disableWhenConnected)
			{
				component.Hide();
			}
			else
			{
				component.Show();
			}
		}
	}

	// Token: 0x06000292 RID: 658 RVA: 0x0000D288 File Offset: 0x0000B488
	protected void DoOnConnected()
	{
		base.gameObject.SetActive(!this.disableWhenConnected);
		global::dfControl component = base.gameObject.GetComponent<global::dfControl>();
		if (component)
		{
			if (this.disableWhenConnected)
			{
				component.Hide();
			}
			else
			{
				component.Show();
			}
		}
	}

	// Token: 0x040001D4 RID: 468
	protected static bool connectedStatus;

	// Token: 0x040001D5 RID: 469
	public bool disableWhenConnected;
}

using System;
using UnityEngine;

// Token: 0x0200005D RID: 93
public class HeatZone : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060002A7 RID: 679 RVA: 0x0000D820 File Offset: 0x0000BA20
	public HeatZone()
	{
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x0000D828 File Offset: 0x0000BA28
	public void SetOn(bool on)
	{
		this._isOn = on;
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x0000D834 File Offset: 0x0000BA34
	public global::Metabolism GetFromCollider(global::UnityEngine.Collider other)
	{
		return other.gameObject.GetComponent<global::Metabolism>();
	}

	// Token: 0x060002AA RID: 682 RVA: 0x0000D850 File Offset: 0x0000BA50
	public void OnTriggerStay(global::UnityEngine.Collider other)
	{
		if (!this._isOn)
		{
			return;
		}
		global::Metabolism fromCollider = this.GetFromCollider(other);
		if (!fromCollider)
		{
			return;
		}
		fromCollider.MarkWarm();
	}

	// Token: 0x040001DD RID: 477
	private bool _isOn;
}

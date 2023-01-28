using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000518 RID: 1304
public class PopupUI : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C60 RID: 11360 RVA: 0x000A75EC File Offset: 0x000A57EC
	public PopupUI()
	{
	}

	// Token: 0x06002C61 RID: 11361 RVA: 0x000A75F4 File Offset: 0x000A57F4
	private void Start()
	{
		global::PopupUI.singleton = this;
		this.panelLocal = base.GetComponent<global::dfPanel>();
	}

	// Token: 0x06002C62 RID: 11362 RVA: 0x000A7608 File Offset: 0x000A5808
	public global::System.Collections.IEnumerator DoTests()
	{
		this.CreateNotice(10f, "", "You've woken up from 24 days of unconsciousness.");
		yield return new global::UnityEngine.WaitForSeconds(1f);
		this.CreateNotice(3f, "", "ONE");
		this.CreateInventory("10 x Wood");
		yield return new global::UnityEngine.WaitForSeconds(1f);
		this.CreateNotice(3f, "", "You TWO.");
		yield return new global::UnityEngine.WaitForSeconds(1f);
		this.CreateNotice(3f, "", "TGHREEEE wank.");
		yield return new global::UnityEngine.WaitForSeconds(1f);
		this.CreateInventory("10 x Wood");
		this.CreateNotice(3f, "", "FOUR wank.");
		yield return new global::UnityEngine.WaitForSeconds(1f);
		this.CreateNotice(3f, "", "FIVE wank.");
		yield return new global::UnityEngine.WaitForSeconds(1f);
		this.CreateInventory("1 x Rock");
		yield return new global::UnityEngine.WaitForSeconds(0.2f);
		this.CreateInventory("10 x Wood");
		yield return new global::UnityEngine.WaitForSeconds(1.2f);
		this.CreateInventory("7 x Rock");
		yield return new global::UnityEngine.WaitForSeconds(1.2f);
		this.CreateInventory("10 x Wood");
		yield return new global::UnityEngine.WaitForSeconds(1.3f);
		this.CreateInventory("1 x Rock");
		yield return new global::UnityEngine.WaitForSeconds(0.1f);
		this.CreateInventory("10 x Wood");
		yield return new global::UnityEngine.WaitForSeconds(0.7f);
		this.CreateInventory("7 x Rock");
		yield return new global::UnityEngine.WaitForSeconds(0.3f);
		this.CreateInventory("10 x Wood");
		yield return new global::UnityEngine.WaitForSeconds(2.4f);
		this.CreateInventory("1 x Rock");
		yield return new global::UnityEngine.WaitForSeconds(0.5f);
		this.CreateInventory("10 x Wood");
		yield return new global::UnityEngine.WaitForSeconds(0.3f);
		this.CreateInventory("7 x Rock");
		yield return new global::UnityEngine.WaitForSeconds(0.3f);
		this.CreateNotice(3f, "", "Big sweaty testicles");
		yield return new global::UnityEngine.WaitForSeconds(1f);
		this.CreateNotice(3f, "", "Dry testicles");
		yield break;
	}

	// Token: 0x06002C63 RID: 11363 RVA: 0x000A7624 File Offset: 0x000A5824
	public void CreateNotice(float fSeconds, string strIcon, string strText)
	{
		global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(this.prefabNotice);
		this.panelLocal.AddControl(gameObject.GetComponent<global::dfPanel>());
		global::PopupNotice component = gameObject.GetComponent<global::PopupNotice>();
		component.Setup(fSeconds, strIcon, strText);
	}

	// Token: 0x06002C64 RID: 11364 RVA: 0x000A7664 File Offset: 0x000A5864
	public void CreateInventory(string strText)
	{
		global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(this.prefabInventory);
		this.panelLocal.AddControl(gameObject.GetComponent<global::dfPanel>());
		global::PopupInventory component = gameObject.GetComponent<global::PopupInventory>();
		component.Setup(1.5f, strText);
	}

	// Token: 0x040016AB RID: 5803
	public static global::PopupUI singleton;

	// Token: 0x040016AC RID: 5804
	public global::UnityEngine.Object prefabNotice;

	// Token: 0x040016AD RID: 5805
	public global::UnityEngine.Object prefabInventory;

	// Token: 0x040016AE RID: 5806
	protected global::dfPanel panelLocal;

	// Token: 0x02000519 RID: 1305
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoTests>c__Iterator3F : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06002C65 RID: 11365 RVA: 0x000A76A8 File Offset: 0x000A58A8
		public <DoTests>c__Iterator3F()
		{
		}

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x06002C66 RID: 11366 RVA: 0x000A76B0 File Offset: 0x000A58B0
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x06002C67 RID: 11367 RVA: 0x000A76B8 File Offset: 0x000A58B8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002C68 RID: 11368 RVA: 0x000A76C0 File Offset: 0x000A58C0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				base.CreateNotice(10f, "", "You've woken up from 24 days of unconsciousness.");
				this.$current = new global::UnityEngine.WaitForSeconds(1f);
				this.$PC = 1;
				return true;
			case 1U:
				base.CreateNotice(3f, "", "ONE");
				base.CreateInventory("10 x Wood");
				this.$current = new global::UnityEngine.WaitForSeconds(1f);
				this.$PC = 2;
				return true;
			case 2U:
				base.CreateNotice(3f, "", "You TWO.");
				this.$current = new global::UnityEngine.WaitForSeconds(1f);
				this.$PC = 3;
				return true;
			case 3U:
				base.CreateNotice(3f, "", "TGHREEEE wank.");
				this.$current = new global::UnityEngine.WaitForSeconds(1f);
				this.$PC = 4;
				return true;
			case 4U:
				base.CreateInventory("10 x Wood");
				base.CreateNotice(3f, "", "FOUR wank.");
				this.$current = new global::UnityEngine.WaitForSeconds(1f);
				this.$PC = 5;
				return true;
			case 5U:
				base.CreateNotice(3f, "", "FIVE wank.");
				this.$current = new global::UnityEngine.WaitForSeconds(1f);
				this.$PC = 6;
				return true;
			case 6U:
				base.CreateInventory("1 x Rock");
				this.$current = new global::UnityEngine.WaitForSeconds(0.2f);
				this.$PC = 7;
				return true;
			case 7U:
				base.CreateInventory("10 x Wood");
				this.$current = new global::UnityEngine.WaitForSeconds(1.2f);
				this.$PC = 8;
				return true;
			case 8U:
				base.CreateInventory("7 x Rock");
				this.$current = new global::UnityEngine.WaitForSeconds(1.2f);
				this.$PC = 9;
				return true;
			case 9U:
				base.CreateInventory("10 x Wood");
				this.$current = new global::UnityEngine.WaitForSeconds(1.3f);
				this.$PC = 0xA;
				return true;
			case 0xAU:
				base.CreateInventory("1 x Rock");
				this.$current = new global::UnityEngine.WaitForSeconds(0.1f);
				this.$PC = 0xB;
				return true;
			case 0xBU:
				base.CreateInventory("10 x Wood");
				this.$current = new global::UnityEngine.WaitForSeconds(0.7f);
				this.$PC = 0xC;
				return true;
			case 0xCU:
				base.CreateInventory("7 x Rock");
				this.$current = new global::UnityEngine.WaitForSeconds(0.3f);
				this.$PC = 0xD;
				return true;
			case 0xDU:
				base.CreateInventory("10 x Wood");
				this.$current = new global::UnityEngine.WaitForSeconds(2.4f);
				this.$PC = 0xE;
				return true;
			case 0xEU:
				base.CreateInventory("1 x Rock");
				this.$current = new global::UnityEngine.WaitForSeconds(0.5f);
				this.$PC = 0xF;
				return true;
			case 0xFU:
				base.CreateInventory("10 x Wood");
				this.$current = new global::UnityEngine.WaitForSeconds(0.3f);
				this.$PC = 0x10;
				return true;
			case 0x10U:
				base.CreateInventory("7 x Rock");
				this.$current = new global::UnityEngine.WaitForSeconds(0.3f);
				this.$PC = 0x11;
				return true;
			case 0x11U:
				base.CreateNotice(3f, "", "Big sweaty testicles");
				this.$current = new global::UnityEngine.WaitForSeconds(1f);
				this.$PC = 0x12;
				return true;
			case 0x12U:
				base.CreateNotice(3f, "", "Dry testicles");
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06002C69 RID: 11369 RVA: 0x000A7AE0 File Offset: 0x000A5CE0
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06002C6A RID: 11370 RVA: 0x000A7AEC File Offset: 0x000A5CEC
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040016AF RID: 5807
		internal int $PC;

		// Token: 0x040016B0 RID: 5808
		internal object $current;

		// Token: 0x040016B1 RID: 5809
		internal global::PopupUI <>f__this;
	}
}

using System;
using UnityEngine;

// Token: 0x0200052A RID: 1322
public class ServerItem : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C9D RID: 11421 RVA: 0x000A87A4 File Offset: 0x000A69A4
	public ServerItem()
	{
	}

	// Token: 0x06002C9E RID: 11422 RVA: 0x000A87AC File Offset: 0x000A69AC
	public void Init(ref global::ServerBrowser.Server s)
	{
		this.server = s;
		this.textLabel.Text = this.server.name;
		this.textPlayers.Text = this.server.currentplayers.ToString() + " / " + this.server.maxplayers.ToString();
		this.textPing.Text = this.server.ping.ToString();
		global::dfScrollPanel component = base.transform.parent.GetComponent<global::dfScrollPanel>();
		if (component)
		{
			base.GetComponent<global::dfControl>().Width = component.Width;
			base.GetComponent<global::dfControl>().ResetLayout(true, false);
		}
		this.UpdateColours();
	}

	// Token: 0x06002C9F RID: 11423 RVA: 0x000A8868 File Offset: 0x000A6A68
	public void Connect()
	{
		global::UnityEngine.Debug.Log("> net.connect " + this.server.address + ":" + this.server.port.ToString());
		global::ConsoleSystem.Run("net.connect " + this.server.address + ":" + this.server.port.ToString(), false);
	}

	// Token: 0x06002CA0 RID: 11424 RVA: 0x000A88D8 File Offset: 0x000A6AD8
	public void SelectThis()
	{
		this.selectedItem = this;
	}

	// Token: 0x06002CA1 RID: 11425 RVA: 0x000A88E4 File Offset: 0x000A6AE4
	public void OnClickFave()
	{
		this.server.fave = !this.server.fave;
		this.UpdateColours();
		base.SendMessageUpwards("UpdateServerList");
		if (this.server.fave)
		{
			global::ConsoleSystem.Run("serverfavourite.add " + this.server.address + ":" + this.server.port.ToString(), false);
		}
		else
		{
			global::ConsoleSystem.Run("serverfavourite.remove " + this.server.address + ":" + this.server.port.ToString(), false);
		}
		global::ConsoleSystem.Run("serverfavourite.save", false);
	}

	// Token: 0x06002CA2 RID: 11426 RVA: 0x000A89A0 File Offset: 0x000A6BA0
	protected void UpdateColours()
	{
		if (this.server.fave)
		{
			this.btnFave.Opacity = 1f;
		}
		else
		{
			this.btnFave.Opacity = 0.2f;
		}
	}

	// Token: 0x040016E0 RID: 5856
	public global::ServerItem selectedItem;

	// Token: 0x040016E1 RID: 5857
	public global::dfButton textLabel;

	// Token: 0x040016E2 RID: 5858
	public global::dfLabel textPlayers;

	// Token: 0x040016E3 RID: 5859
	public global::dfLabel textPing;

	// Token: 0x040016E4 RID: 5860
	public global::dfButton btnFave;

	// Token: 0x040016E5 RID: 5861
	public global::ServerBrowser.Server server;
}

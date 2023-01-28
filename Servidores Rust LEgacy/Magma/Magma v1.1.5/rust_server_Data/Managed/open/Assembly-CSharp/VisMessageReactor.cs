using System;
using UnityEngine;

// Token: 0x020004BF RID: 1215
public sealed class VisMessageReactor : global::VisReactor
{
	// Token: 0x06002A35 RID: 10805 RVA: 0x0009F864 File Offset: 0x0009DA64
	public VisMessageReactor()
	{
	}

	// Token: 0x06002A36 RID: 10806 RVA: 0x0009F8D0 File Offset: 0x0009DAD0
	private void Exec(string message, global::VisNode arg, global::VisMessageInfo.Kind kind)
	{
	}

	// Token: 0x06002A37 RID: 10807 RVA: 0x0009F8D4 File Offset: 0x0009DAD4
	private void Exec(string message, global::VisMessageInfo.Kind kind)
	{
		this.Exec(message, null, kind);
	}

	// Token: 0x06002A38 RID: 10808 RVA: 0x0009F8E0 File Offset: 0x0009DAE0
	protected override void React_AwareEnter()
	{
		this.Exec(this.awareEnter, global::VisMessageInfo.Kind.SeeEnter);
	}

	// Token: 0x06002A39 RID: 10809 RVA: 0x0009F8F0 File Offset: 0x0009DAF0
	protected override void React_AwareExit()
	{
		this.Exec(this.awareEnter, global::VisMessageInfo.Kind.SeeExit);
	}

	// Token: 0x06002A3A RID: 10810 RVA: 0x0009F900 File Offset: 0x0009DB00
	protected override void React_SeeAdd(global::VisNode node)
	{
		this.Exec(this.awareEnter, node, global::VisMessageInfo.Kind.SeeAdd);
	}

	// Token: 0x06002A3B RID: 10811 RVA: 0x0009F910 File Offset: 0x0009DB10
	protected override void React_SeeRemove(global::VisNode node)
	{
		this.Exec(this.awareEnter, node, global::VisMessageInfo.Kind.SeeRemove);
	}

	// Token: 0x06002A3C RID: 10812 RVA: 0x0009F920 File Offset: 0x0009DB20
	protected override void React_SpectatedEnter()
	{
		this.Exec(this.awareEnter, global::VisMessageInfo.Kind.SpectatedEnter);
	}

	// Token: 0x06002A3D RID: 10813 RVA: 0x0009F930 File Offset: 0x0009DB30
	protected override void React_SpectatedExit()
	{
		this.Exec(this.awareEnter, global::VisMessageInfo.Kind.SpectatorExit);
	}

	// Token: 0x06002A3E RID: 10814 RVA: 0x0009F940 File Offset: 0x0009DB40
	protected override void React_SpectatorAdd(global::VisNode node)
	{
		this.Exec(this.awareEnter, node, global::VisMessageInfo.Kind.SpectatorAdd);
	}

	// Token: 0x06002A3F RID: 10815 RVA: 0x0009F950 File Offset: 0x0009DB50
	protected override void React_SpectatorRemove(global::VisNode node)
	{
		this.Exec(this.awareEnter, node, global::VisMessageInfo.Kind.SpectatorRemove);
	}

	// Token: 0x06002A40 RID: 10816 RVA: 0x0009F964 File Offset: 0x0009DB64
	private new void Reset()
	{
		base.Reset();
	}

	// Token: 0x04001528 RID: 5416
	public global::UnityEngine.GameObject messageReceiver;

	// Token: 0x04001529 RID: 5417
	public string awareEnter = "Vis_Sight_Enter";

	// Token: 0x0400152A RID: 5418
	public string seeAdd = "Vis_Sight_Add";

	// Token: 0x0400152B RID: 5419
	public string seeRemove = "Vis_Sight_Remove";

	// Token: 0x0400152C RID: 5420
	public string awareExit = "Vis_Sight_Exit";

	// Token: 0x0400152D RID: 5421
	public string spectatedEnter = "Vis_Spect_Enter";

	// Token: 0x0400152E RID: 5422
	public string spectatorAdd = "Vis_Spect_Add";

	// Token: 0x0400152F RID: 5423
	public string spectatorRemove = "Vis_Spect_Remove";

	// Token: 0x04001530 RID: 5424
	public string spectatedExit = "Vis_Spect_Exit";
}

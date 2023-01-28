using System;

// Token: 0x020005D5 RID: 1493
public class VMAttachmentSocketOverride : global::ViewModelAttachment
{
	// Token: 0x060030B5 RID: 12469 RVA: 0x000B98A8 File Offset: 0x000B7AA8
	public VMAttachmentSocketOverride()
	{
	}

	// Token: 0x060030B6 RID: 12470 RVA: 0x000B98B0 File Offset: 0x000B7AB0
	private void OnDrawGizmosSelected()
	{
		this.socketOverride.DrawGizmos("socketOverride");
	}

	// Token: 0x04001A69 RID: 6761
	public global::Socket.CameraSpace socketOverride;
}

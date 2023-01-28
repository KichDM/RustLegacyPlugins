using System;
using Facepunch.Intersect;

// Token: 0x020001CF RID: 463
public class HitBoxSystem : global::Facepunch.Intersect.HitBoxSystem
{
	// Token: 0x06000D4D RID: 3405 RVA: 0x000344AC File Offset: 0x000326AC
	public HitBoxSystem()
	{
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x000344B4 File Offset: 0x000326B4
	private void CheckLayer()
	{
		if (base.gameObject.layer != 0x11)
		{
			base.gameObject.layer = 0x11;
		}
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x000344E0 File Offset: 0x000326E0
	protected void Awake()
	{
		base.Awake();
		this.CheckLayer();
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x000344F0 File Offset: 0x000326F0
	protected void Start()
	{
		this.CheckLayer();
	}
}

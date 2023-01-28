using System;

// Token: 0x02000775 RID: 1909
public class DeployableCorpse : global::IDMain
{
	// Token: 0x06003F51 RID: 16209 RVA: 0x000E2128 File Offset: 0x000E0328
	public DeployableCorpse() : this(0)
	{
	}

	// Token: 0x06003F52 RID: 16210 RVA: 0x000E2134 File Offset: 0x000E0334
	protected DeployableCorpse(global::IDFlags flags) : base(flags)
	{
	}

	// Token: 0x06003F53 RID: 16211 RVA: 0x000E2148 File Offset: 0x000E0348
	private void Awake()
	{
		base.Invoke("NetDestroy", this.lifeTime);
	}

	// Token: 0x06003F54 RID: 16212 RVA: 0x000E215C File Offset: 0x000E035C
	public void NetDestroy()
	{
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x040020A5 RID: 8357
	private float lifeTime = 300f;
}

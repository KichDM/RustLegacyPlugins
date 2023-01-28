using System;

// Token: 0x020004C0 RID: 1216
public sealed class VisMessageInfo : global::System.IDisposable
{
	// Token: 0x06002A41 RID: 10817 RVA: 0x0009F96C File Offset: 0x0009DB6C
	private VisMessageInfo()
	{
	}

	// Token: 0x06002A42 RID: 10818 RVA: 0x0009F974 File Offset: 0x0009DB74
	void global::System.IDisposable.Dispose()
	{
		if (this._kind != (global::VisMessageInfo.Kind)0)
		{
			this._kind = (global::VisMessageInfo.Kind)0;
			this.next = global::VisMessageInfo.dump;
			global::VisMessageInfo.dump = this;
			this._other = null;
			this._self = null;
		}
	}

	// Token: 0x17000952 RID: 2386
	// (get) Token: 0x06002A43 RID: 10819 RVA: 0x0009F9A8 File Offset: 0x0009DBA8
	public bool isSpectatingEvent
	{
		get
		{
			return (this._kind - global::VisMessageInfo.Kind.SeeEnter & 1) == 1;
		}
	}

	// Token: 0x17000953 RID: 2387
	// (get) Token: 0x06002A44 RID: 10820 RVA: 0x0009F9B8 File Offset: 0x0009DBB8
	public bool isSeeEvent
	{
		get
		{
			return (this._kind & global::VisMessageInfo.Kind.SeeEnter) == global::VisMessageInfo.Kind.SeeEnter;
		}
	}

	// Token: 0x17000954 RID: 2388
	// (get) Token: 0x06002A45 RID: 10821 RVA: 0x0009F9C8 File Offset: 0x0009DBC8
	public global::VisMessageInfo.Kind kind
	{
		get
		{
			return this._kind;
		}
	}

	// Token: 0x17000955 RID: 2389
	// (get) Token: 0x06002A46 RID: 10822 RVA: 0x0009F9D0 File Offset: 0x0009DBD0
	public global::VisNode sender
	{
		get
		{
			return this._self.node;
		}
	}

	// Token: 0x17000956 RID: 2390
	// (get) Token: 0x06002A47 RID: 10823 RVA: 0x0009F9E0 File Offset: 0x0009DBE0
	public global::VisNode self
	{
		get
		{
			return this._self.node;
		}
	}

	// Token: 0x17000957 RID: 2391
	// (get) Token: 0x06002A48 RID: 10824 RVA: 0x0009F9F0 File Offset: 0x0009DBF0
	public global::VisReactor issuer
	{
		get
		{
			return this._self;
		}
	}

	// Token: 0x17000958 RID: 2392
	// (get) Token: 0x06002A49 RID: 10825 RVA: 0x0009F9F8 File Offset: 0x0009DBF8
	public global::VisNode target
	{
		get
		{
			return this._other;
		}
	}

	// Token: 0x17000959 RID: 2393
	// (get) Token: 0x06002A4A RID: 10826 RVA: 0x0009FA00 File Offset: 0x0009DC00
	public global::VisNode other
	{
		get
		{
			return this._other;
		}
	}

	// Token: 0x1700095A RID: 2394
	// (get) Token: 0x06002A4B RID: 10827 RVA: 0x0009FA08 File Offset: 0x0009DC08
	public bool isTwoNodeEvent
	{
		get
		{
			return this._kind > global::VisMessageInfo.Kind.SpectatorExit;
		}
	}

	// Token: 0x1700095B RID: 2395
	// (get) Token: 0x06002A4C RID: 10828 RVA: 0x0009FA14 File Offset: 0x0009DC14
	public global::VisNode spectator
	{
		get
		{
			return (!this.isSpectatingEvent) ? this.self : this._other;
		}
	}

	// Token: 0x1700095C RID: 2396
	// (get) Token: 0x06002A4D RID: 10829 RVA: 0x0009FA34 File Offset: 0x0009DC34
	public global::VisNode spectated
	{
		get
		{
			return (!this.isSeeEvent) ? this.self : this._other;
		}
	}

	// Token: 0x1700095D RID: 2397
	// (get) Token: 0x06002A4E RID: 10830 RVA: 0x0009FA54 File Offset: 0x0009DC54
	public global::VisNode seenNode
	{
		get
		{
			return this.spectated;
		}
	}

	// Token: 0x1700095E RID: 2398
	// (get) Token: 0x06002A4F RID: 10831 RVA: 0x0009FA5C File Offset: 0x0009DC5C
	public global::VisNode seeer
	{
		get
		{
			return this.spectator;
		}
	}

	// Token: 0x06002A50 RID: 10832 RVA: 0x0009FA64 File Offset: 0x0009DC64
	public static global::VisMessageInfo Create(global::VisReactor issuer, global::VisNode other, global::VisMessageInfo.Kind kind)
	{
		global::VisMessageInfo visMessageInfo;
		if (global::VisMessageInfo.dump != null)
		{
			visMessageInfo = global::VisMessageInfo.dump;
			global::VisMessageInfo.dump = visMessageInfo.next;
			visMessageInfo.next = null;
		}
		else
		{
			visMessageInfo = new global::VisMessageInfo();
		}
		visMessageInfo._self = issuer;
		visMessageInfo._other = other;
		visMessageInfo._kind = kind;
		return visMessageInfo;
	}

	// Token: 0x06002A51 RID: 10833 RVA: 0x0009FAB4 File Offset: 0x0009DCB4
	public static global::VisMessageInfo Create(global::VisReactor issuer, global::VisMessageInfo.Kind kind)
	{
		global::VisMessageInfo visMessageInfo;
		if (global::VisMessageInfo.dump != null)
		{
			visMessageInfo = global::VisMessageInfo.dump;
			global::VisMessageInfo.dump = visMessageInfo.next;
			visMessageInfo.next = null;
		}
		else
		{
			visMessageInfo = new global::VisMessageInfo();
		}
		visMessageInfo._self = issuer;
		visMessageInfo._other = null;
		visMessageInfo._kind = kind;
		return visMessageInfo;
	}

	// Token: 0x04001531 RID: 5425
	private global::VisNode _other;

	// Token: 0x04001532 RID: 5426
	private global::VisReactor _self;

	// Token: 0x04001533 RID: 5427
	private global::VisMessageInfo next;

	// Token: 0x04001534 RID: 5428
	private global::VisMessageInfo.Kind _kind;

	// Token: 0x04001535 RID: 5429
	private static global::VisMessageInfo dump;

	// Token: 0x020004C1 RID: 1217
	public enum Kind : byte
	{
		// Token: 0x04001537 RID: 5431
		SeeEnter = 1,
		// Token: 0x04001538 RID: 5432
		SeeExit = 3,
		// Token: 0x04001539 RID: 5433
		SeeAdd = 5,
		// Token: 0x0400153A RID: 5434
		SeeRemove = 7,
		// Token: 0x0400153B RID: 5435
		SpectatedEnter = 2,
		// Token: 0x0400153C RID: 5436
		SpectatorExit = 4,
		// Token: 0x0400153D RID: 5437
		SpectatorAdd = 8,
		// Token: 0x0400153E RID: 5438
		SpectatorRemove = 0xA
	}
}

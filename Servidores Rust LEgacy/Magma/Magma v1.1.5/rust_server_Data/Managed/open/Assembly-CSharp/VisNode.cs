using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020004C3 RID: 1219
[global::UnityEngine.AddComponentMenu("Vis/Node")]
public class VisNode : global::IDLocal
{
	// Token: 0x06002A53 RID: 10835 RVA: 0x0009FB04 File Offset: 0x0009DD04
	public VisNode()
	{
	}

	// Token: 0x06002A54 RID: 10836 RVA: 0x0009FB3C File Offset: 0x0009DD3C
	// Note: this type is marked as 'beforefieldinit'.
	static VisNode()
	{
	}

	// Token: 0x1700095F RID: 2399
	// (set) Token: 0x06002A55 RID: 10837 RVA: 0x0009FB70 File Offset: 0x0009DD70
	internal global::VisReactor __reactor
	{
		set
		{
			this.reactor = value;
		}
	}

	// Token: 0x17000960 RID: 2400
	// (get) Token: 0x06002A56 RID: 10838 RVA: 0x0009FB7C File Offset: 0x0009DD7C
	// (set) Token: 0x06002A57 RID: 10839 RVA: 0x0009FB84 File Offset: 0x0009DD84
	public float arc
	{
		get
		{
			return this.dotArc;
		}
		set
		{
			this.dotArc = global::UnityEngine.Mathf.Clamp01(value);
		}
	}

	// Token: 0x17000961 RID: 2401
	// (get) Token: 0x06002A58 RID: 10840 RVA: 0x0009FB94 File Offset: 0x0009DD94
	// (set) Token: 0x06002A59 RID: 10841 RVA: 0x0009FB9C File Offset: 0x0009DD9C
	public float radius
	{
		get
		{
			return this.distance;
		}
		set
		{
			this.distance = value;
		}
	}

	// Token: 0x17000962 RID: 2402
	// (get) Token: 0x06002A5A RID: 10842 RVA: 0x0009FBA8 File Offset: 0x0009DDA8
	// (set) Token: 0x06002A5B RID: 10843 RVA: 0x0009FBD0 File Offset: 0x0009DDD0
	public global::Vis.Mask viewMask
	{
		get
		{
			return new global::Vis.Mask
			{
				data = this._sightMask
			};
		}
		set
		{
			this._sightMask = value.data;
		}
	}

	// Token: 0x17000963 RID: 2403
	// (get) Token: 0x06002A5C RID: 10844 RVA: 0x0009FBE0 File Offset: 0x0009DDE0
	// (set) Token: 0x06002A5D RID: 10845 RVA: 0x0009FC08 File Offset: 0x0009DE08
	public global::Vis.Mask spectMask
	{
		get
		{
			return new global::Vis.Mask
			{
				data = this._spectMask
			};
		}
		set
		{
			this._spectMask = value.data;
		}
	}

	// Token: 0x17000964 RID: 2404
	// (get) Token: 0x06002A5E RID: 10846 RVA: 0x0009FC18 File Offset: 0x0009DE18
	// (set) Token: 0x06002A5F RID: 10847 RVA: 0x0009FC40 File Offset: 0x0009DE40
	public global::Vis.Mask traitMask
	{
		get
		{
			return new global::Vis.Mask
			{
				data = this._traitMask
			};
		}
		set
		{
			this._traitMask = value.data;
		}
	}

	// Token: 0x17000965 RID: 2405
	// (get) Token: 0x06002A60 RID: 10848 RVA: 0x0009FC50 File Offset: 0x0009DE50
	public global::Vis.Mask seenMask
	{
		get
		{
			return new global::Vis.Mask
			{
				data = this._seeMask
			};
		}
	}

	// Token: 0x17000966 RID: 2406
	// (get) Token: 0x06002A61 RID: 10849 RVA: 0x0009FC78 File Offset: 0x0009DE78
	public global::Vis.Stamp stamp
	{
		get
		{
			return this._stamp;
		}
	}

	// Token: 0x17000967 RID: 2407
	// (get) Token: 0x06002A62 RID: 10850 RVA: 0x0009FC80 File Offset: 0x0009DE80
	public global::UnityEngine.Vector3 position
	{
		get
		{
			return this._stamp.position;
		}
	}

	// Token: 0x17000968 RID: 2408
	// (get) Token: 0x06002A63 RID: 10851 RVA: 0x0009FC90 File Offset: 0x0009DE90
	public global::UnityEngine.Vector3 forward
	{
		get
		{
			return this._stamp.forward;
		}
	}

	// Token: 0x17000969 RID: 2409
	// (get) Token: 0x06002A64 RID: 10852 RVA: 0x0009FCA0 File Offset: 0x0009DEA0
	public global::UnityEngine.Quaternion rotation
	{
		get
		{
			return this._stamp.rotation;
		}
	}

	// Token: 0x1700096A RID: 2410
	// (get) Token: 0x06002A65 RID: 10853 RVA: 0x0009FCB0 File Offset: 0x0009DEB0
	public global::UnityEngine.Plane plane
	{
		get
		{
			global::UnityEngine.Vector4 vector = this._stamp.forward;
			return new global::UnityEngine.Plane(new global::UnityEngine.Vector3(vector.x, vector.y, vector.z), vector.w);
		}
	}

	// Token: 0x1700096B RID: 2411
	// (get) Token: 0x06002A66 RID: 10854 RVA: 0x0009FCF4 File Offset: 0x0009DEF4
	public int numSight
	{
		get
		{
			return this.sight.count;
		}
	}

	// Token: 0x1700096C RID: 2412
	// (get) Token: 0x06002A67 RID: 10855 RVA: 0x0009FD04 File Offset: 0x0009DF04
	public bool anySight
	{
		get
		{
			return this.sight.any;
		}
	}

	// Token: 0x1700096D RID: 2413
	// (get) Token: 0x06002A68 RID: 10856 RVA: 0x0009FD14 File Offset: 0x0009DF14
	public bool anySightNew
	{
		get
		{
			return this.sight.add;
		}
	}

	// Token: 0x1700096E RID: 2414
	// (get) Token: 0x06002A69 RID: 10857 RVA: 0x0009FD24 File Offset: 0x0009DF24
	public bool anySightLost
	{
		get
		{
			return this.sight.rem;
		}
	}

	// Token: 0x1700096F RID: 2415
	// (get) Token: 0x06002A6A RID: 10858 RVA: 0x0009FD34 File Offset: 0x0009DF34
	public bool anySightHad
	{
		get
		{
			return this.sight.had;
		}
	}

	// Token: 0x17000970 RID: 2416
	// (get) Token: 0x06002A6B RID: 10859 RVA: 0x0009FD44 File Offset: 0x0009DF44
	public int numSpectators
	{
		get
		{
			return this.spect.count;
		}
	}

	// Token: 0x17000971 RID: 2417
	// (get) Token: 0x06002A6C RID: 10860 RVA: 0x0009FD54 File Offset: 0x0009DF54
	public bool anySpectators
	{
		get
		{
			return this.spect.any;
		}
	}

	// Token: 0x17000972 RID: 2418
	// (get) Token: 0x06002A6D RID: 10861 RVA: 0x0009FD64 File Offset: 0x0009DF64
	public bool anySpectatorsNew
	{
		get
		{
			return this.spect.add;
		}
	}

	// Token: 0x17000973 RID: 2419
	// (get) Token: 0x06002A6E RID: 10862 RVA: 0x0009FD74 File Offset: 0x0009DF74
	public bool anySpectatorsLost
	{
		get
		{
			return this.spect.rem;
		}
	}

	// Token: 0x17000974 RID: 2420
	// (get) Token: 0x06002A6F RID: 10863 RVA: 0x0009FD84 File Offset: 0x0009DF84
	public bool anySpectatorsHad
	{
		get
		{
			return this.spect.had;
		}
	}

	// Token: 0x06002A70 RID: 10864 RVA: 0x0009FD94 File Offset: 0x0009DF94
	public bool CanSeeAny(global::Vis.Life life)
	{
		return (this._seeMask & (int)life) != 0;
	}

	// Token: 0x06002A71 RID: 10865 RVA: 0x0009FDA4 File Offset: 0x0009DFA4
	public bool CanSeeAny(global::Vis.Status status)
	{
		return (this._seeMask & (int)((int)status << 8)) != 0;
	}

	// Token: 0x06002A72 RID: 10866 RVA: 0x0009FDB8 File Offset: 0x0009DFB8
	public bool CanSeeAny(global::Vis.Role role)
	{
		return (this._seeMask & (int)((int)role << 0x18)) != 0;
	}

	// Token: 0x06002A73 RID: 10867 RVA: 0x0009FDCC File Offset: 0x0009DFCC
	public bool CanSeeAny(global::Vis.Mask mask)
	{
		return (this._seeMask & mask.data) != 0;
	}

	// Token: 0x06002A74 RID: 10868 RVA: 0x0009FDE4 File Offset: 0x0009DFE4
	public bool CanSee(global::Vis.Trait trait)
	{
		return (this._seeMask & 1 << (int)trait) != 0;
	}

	// Token: 0x06002A75 RID: 10869 RVA: 0x0009FDFC File Offset: 0x0009DFFC
	public bool CanSee(global::Vis.Life life)
	{
		return (this._seeMask & (int)life) == (int)life;
	}

	// Token: 0x06002A76 RID: 10870 RVA: 0x0009FE0C File Offset: 0x0009E00C
	public bool CanSee(global::Vis.Status status)
	{
		return (this._seeMask >> 8 & (int)status) == (int)status;
	}

	// Token: 0x06002A77 RID: 10871 RVA: 0x0009FE1C File Offset: 0x0009E01C
	public bool CanSee(global::Vis.Role role)
	{
		return (this._seeMask >> 0x18 & (int)role) == (int)role;
	}

	// Token: 0x06002A78 RID: 10872 RVA: 0x0009FE2C File Offset: 0x0009E02C
	public bool CanSee(global::Vis.Mask mask)
	{
		return (this._seeMask & mask.data) == mask.data;
	}

	// Token: 0x06002A79 RID: 10873 RVA: 0x0009FE48 File Offset: 0x0009E048
	public bool CanSeeOnly(global::Vis.Life life)
	{
		return (this._seeMask & 7) == (int)life;
	}

	// Token: 0x06002A7A RID: 10874 RVA: 0x0009FE58 File Offset: 0x0009E058
	public bool CanSeeOnly(global::Vis.Status status)
	{
		return (this._seeMask & 0x7F00) == (int)((int)status << 8);
	}

	// Token: 0x06002A7B RID: 10875 RVA: 0x0009FE6C File Offset: 0x0009E06C
	public bool CanSeeOnly(global::Vis.Role role)
	{
		return (this._seeMask & -0x1000000) == (int)((int)role << 0x18);
	}

	// Token: 0x06002A7C RID: 10876 RVA: 0x0009FE80 File Offset: 0x0009E080
	public bool CanSeeOnly(global::Vis.Mask mask)
	{
		return this._seeMask == mask.data;
	}

	// Token: 0x06002A7D RID: 10877 RVA: 0x0009FE94 File Offset: 0x0009E094
	public bool CanSeeOnly(global::Vis.Trait trait)
	{
		return this._seeMask == 1 << (int)trait;
	}

	// Token: 0x17000975 RID: 2421
	// (get) Token: 0x06002A7E RID: 10878 RVA: 0x0009FEA4 File Offset: 0x0009E0A4
	// (set) Token: 0x06002A7F RID: 10879 RVA: 0x0009FEAC File Offset: 0x0009E0AC
	public global::UnityEngine.Transform head
	{
		get
		{
			return this._transform;
		}
		set
		{
			if (value)
			{
				this._transform = value;
			}
			else
			{
				this._transform = base.transform;
			}
		}
	}

	// Token: 0x06002A80 RID: 10880 RVA: 0x0009FED4 File Offset: 0x0009E0D4
	protected void Reset()
	{
		base.Reset();
		global::VisReactor component = base.GetComponent<global::VisReactor>();
		if (component)
		{
			this.reactor = component;
			this.reactor.__visNode = this;
		}
	}

	// Token: 0x06002A81 RID: 10881 RVA: 0x0009FF0C File Offset: 0x0009E10C
	private void Register()
	{
		if (!this.awake || this.active)
		{
			return;
		}
		if (global::VisManager.guardedUpdate)
		{
			throw new global::System.InvalidOperationException("DO NOT INSTANTIATE WHILE VisibilityManager.isUpdatingVisibility!!");
		}
		if (!global::VisNode.manager)
		{
			global::VisNode.manager = new global::UnityEngine.GameObject("__Vis", new global::System.Type[]
			{
				typeof(global::VisManager)
			}).GetComponent<global::VisManager>();
		}
		if (!this.dataConstructed)
		{
			this.sight.list = new global::ODBSet<global::VisNode>();
			this.sight.last = new global::ODBSet<global::VisNode>();
			this.spect.list = new global::ODBSet<global::VisNode>();
			this.spect.last = new global::ODBSet<global::VisNode>();
			this.enter = new global::ODBSet<global::VisNode>();
			this.exit = new global::ODBSet<global::VisNode>();
			this.cleanList = new global::System.Collections.Generic.List<global::VisNode>();
			this.dataConstructed = true;
		}
		else if (!global::VisNode.recentlyDisabled.Remove(this))
		{
			global::VisNode.disabledLastStep.Remove(this);
		}
		this.item = global::VisNode.db.Register(this);
		this.active = (this.item == this);
	}

	// Token: 0x06002A82 RID: 10882 RVA: 0x000A0034 File Offset: 0x0009E234
	private void Unregister()
	{
		if (this.active)
		{
			if (global::VisManager.guardedUpdate)
			{
				throw new global::System.InvalidOperationException("DO NOT OR DISABLE DESTROY WHILE VisibilityManager.isUpdatingVisibility!!");
			}
			global::VisNode.db.Unregister(ref this.item);
			this.active = (this.item == this);
		}
	}

	// Token: 0x06002A83 RID: 10883 RVA: 0x000A0084 File Offset: 0x0009E284
	private void Awake()
	{
		this.awake = true;
		if (!this._transform)
		{
			this._transform = base.transform;
		}
		if (base.enabled)
		{
			global::UnityEngine.Debug.LogWarning("VisNode was enabled prior to awake. VisNode's enabled button should always be off when the game is not running");
			this.Register();
		}
		this.histSight.last = 0;
		this.histSpect.last = this._spectMask;
		this.histTrait.last = this._traitMask;
		this.statusHandler = (this.idMain as global::IVisHandler);
		this.hasStatusHandler = (this.statusHandler != null);
		if (this._class)
		{
			this._handle = this._class.handle;
		}
	}

	// Token: 0x06002A84 RID: 10884 RVA: 0x000A0144 File Offset: 0x0009E344
	private void OnDestroy()
	{
		if (global::VisManager.guardedUpdate)
		{
			global::UnityEngine.Debug.LogError("DESTROYING IN GUARDED UPDATE! " + base.name, this);
		}
		this.Unregister();
		global::VisNode.RemoveNow(this);
	}

	// Token: 0x06002A85 RID: 10885 RVA: 0x000A0180 File Offset: 0x0009E380
	private void OnEnable()
	{
		if (this.awake)
		{
			this.Register();
		}
	}

	// Token: 0x06002A86 RID: 10886 RVA: 0x000A0194 File Offset: 0x0009E394
	private void OnDisable()
	{
		if (this.awake)
		{
			bool flag = this.active;
			this.Unregister();
			if (flag && !this.active)
			{
				global::VisNode.recentlyDisabled.Add(this);
			}
		}
	}

	// Token: 0x06002A87 RID: 10887 RVA: 0x000A01D8 File Offset: 0x0009E3D8
	private static void ResolveSee()
	{
		if (global::VisNode.operandA.sight.list.Add(global::VisNode.operandB))
		{
			global::VisNode visNode = global::VisNode.operandB;
			visNode.spect.add = (visNode.spect.add | global::VisNode.operandB.spect.list.Add(global::VisNode.operandA));
			global::VisNode.operandA.sight.add = true;
			global::VisNode.operandA.enter.Add(global::VisNode.operandB);
		}
	}

	// Token: 0x06002A88 RID: 10888 RVA: 0x000A0258 File Offset: 0x0009E458
	private static void ResolveHide()
	{
		if (global::VisNode.operandA.sight.list.Remove(global::VisNode.operandB))
		{
			global::VisNode visNode = global::VisNode.operandB;
			visNode.spect.rem = (visNode.spect.rem | global::VisNode.operandB.spect.list.Remove(global::VisNode.operandA));
			global::VisNode.operandA.exit.Add(global::VisNode.operandB);
			global::VisNode.operandB.cleanList.Add(global::VisNode.operandA);
		}
	}

	// Token: 0x06002A89 RID: 10889 RVA: 0x000A02DC File Offset: 0x0009E4DC
	private static void RemoveLinkNow(global::VisNode node, global::VisNode didSee)
	{
		if (node.sight.list.Remove(node))
		{
			node.sight.rem = true;
			didSee.spect.rem = (didSee.spect.rem | didSee.spect.list.Remove(node));
		}
		if (!node.sight.last.Remove(didSee))
		{
			node.enter.Remove(didSee);
		}
		else
		{
			didSee.spect.last.Remove(node);
		}
		if ((node.sight.count = node.sight.count - 1) == 0)
		{
			node.sight.any = false;
		}
		if ((didSee.spect.count = didSee.spect.count - 1) == 0)
		{
			didSee.spect.any = false;
		}
	}

	// Token: 0x06002A8A RID: 10890 RVA: 0x000A03B8 File Offset: 0x0009E5B8
	internal static void RemoveNow(global::VisNode node)
	{
		if (!node.dataConstructed)
		{
			return;
		}
		if (!global::VisNode.recentlyDisabled.Remove(node))
		{
			global::VisNode.disabledLastStep.Remove(node);
		}
		for (int i = 0; i < node.cleanList.Count; i++)
		{
			node.cleanList[i].exit.Remove(node);
		}
		global::ODBForwardEnumerator<global::VisNode> enumerator = node.exit.GetEnumerator();
		while (enumerator.MoveNext())
		{
			global::VisNode current = enumerator.Current;
			current.cleanList.Remove(node);
		}
		enumerator.Dispose();
		node.cleanList.Clear();
		node.cleanList.AddRange(node.sight.list);
		for (int i = 0; i < node.cleanList.Count; i++)
		{
			global::VisNode.RemoveLinkNow(node, node.cleanList[i]);
		}
		node.cleanList.Clear();
		node.cleanList.AddRange(node.spect.list);
		for (int i = 0; i < node.cleanList.Count; i++)
		{
			global::VisNode.RemoveLinkNow(node.cleanList[i], node);
		}
		node.cleanList.Clear();
	}

	// Token: 0x06002A8B RID: 10891 RVA: 0x000A0504 File Offset: 0x0009E704
	private static void Copy(global::ODBSet<global::VisNode> src, global::ODBSet<global::VisNode> dst)
	{
		dst.Clear();
		dst.UnionWith(src);
	}

	// Token: 0x06002A8C RID: 10892 RVA: 0x000A0514 File Offset: 0x0009E714
	private static void Transfer(global::ODBSet<global::VisNode> src, global::ODBSet<global::VisNode> dst, bool addAny, bool remAny)
	{
		if (addAny)
		{
			if (remAny)
			{
				global::VisNode.Copy(src, dst);
			}
			else
			{
				dst.UnionWith(src);
			}
		}
		else if (remAny)
		{
			dst.ExceptWith(src);
		}
	}

	// Token: 0x06002A8D RID: 10893 RVA: 0x000A0548 File Offset: 0x0009E748
	private void Stamp()
	{
		this._stamp.Collect(this._transform);
		global::VisNode.Transfer(this.sight.list, this.sight.last, this.sight.add, this.sight.rem);
		global::VisNode.Transfer(this.spect.list, this.spect.last, this.spect.add, this.spect.rem);
		if (this.sight.add)
		{
			this.enter.Clear();
			this.sight.add = false;
		}
		if (this.sight.rem)
		{
			this.exit.Clear();
			this.sight.rem = false;
		}
		this.spect.add = false;
		if (this.spect.rem)
		{
			this.spect.rem = false;
			this.cleanList.Clear();
		}
		if (this.hasStatusHandler)
		{
			this._traitMask = this.statusHandler.VisPoll(this.traitMask).data;
		}
		this.histTrait.Upd(this._traitMask);
		this._sightCurrentMask = 0;
		this.histSight.Upd(this._sightCurrentMask);
		this.histSpect.Upd(this._spectMask);
		this._seeMask = 0;
		this.anySeenTraitChanges = false;
	}

	// Token: 0x06002A8E RID: 10894 RVA: 0x000A06C0 File Offset: 0x0009E8C0
	internal static void Stage1(global::VisNode self)
	{
		self.Stamp();
	}

	// Token: 0x06002A8F RID: 10895 RVA: 0x000A06C8 File Offset: 0x0009E8C8
	private static bool LogicSight()
	{
		if (!global::VisNode.operandB.active)
		{
			return false;
		}
		global::VisNode.bX = global::VisNode.operandB._stamp.position.x;
		global::VisNode.bY = global::VisNode.operandB._stamp.position.y;
		global::VisNode.bZ = global::VisNode.operandB._stamp.position.z;
		global::VisNode.planeDot = global::VisNode.bX * global::VisNode.fX + global::VisNode.bY * global::VisNode.fY + global::VisNode.bZ * global::VisNode.fZ;
		if (global::VisNode.planeDot < global::VisNode.fW || global::VisNode.planeDot > global::VisNode.PLANEDOTSIGHT)
		{
			return false;
		}
		global::VisNode.dX = global::VisNode.bX - global::VisNode.pX;
		global::VisNode.dY = global::VisNode.bY - global::VisNode.pY;
		global::VisNode.dZ = global::VisNode.bZ - global::VisNode.pZ;
		global::VisNode.dV2 = global::VisNode.dX * global::VisNode.dX + global::VisNode.dY * global::VisNode.dY + global::VisNode.dZ * global::VisNode.dZ;
		if (global::VisNode.dV2 > global::VisNode.SIGHT2)
		{
			return false;
		}
		if (global::VisNode.dV2 < 4E-45f)
		{
			return global::VisNode.FALLBACK_TOO_CLOSE;
		}
		global::VisNode.dV = global::UnityEngine.Mathf.Sqrt(global::VisNode.dV2);
		global::VisNode.nX = global::VisNode.dX / global::VisNode.dV;
		global::VisNode.nY = global::VisNode.dY / global::VisNode.dV;
		global::VisNode.nZ = global::VisNode.dZ / global::VisNode.dV;
		global::VisNode.dot = global::VisNode.fX * global::VisNode.nX + global::VisNode.fY * global::VisNode.nY + global::VisNode.fZ * global::VisNode.nZ;
		return global::VisNode.DOT < global::VisNode.dot;
	}

	// Token: 0x06002A90 RID: 10896 RVA: 0x000A086C File Offset: 0x0009EA6C
	private static void UpdateVis(global::ODBSibling<global::VisNode> first_sib)
	{
		global::VisNode.FALLBACK_TOO_CLOSE = false;
		global::ODBSibling<global::VisNode> odbsibling = first_sib;
		do
		{
			global::VisNode.operandA = odbsibling.item.self;
			odbsibling = odbsibling.item.n;
			if (global::VisNode.operandA._sightCurrentMask == 0)
			{
				if (global::VisNode.operandA.sight.any)
				{
					global::ODBSibling<global::VisNode> odbsibling2 = global::VisNode.operandA.sight.last.first;
					do
					{
						global::VisNode.operandB = odbsibling2.item.self;
						odbsibling2 = odbsibling2.item.n;
						global::VisNode.ResolveHide();
					}
					while (odbsibling2.has);
					global::VisNode.operandB = null;
				}
			}
			else
			{
				global::VisNode.pX = global::VisNode.operandA._stamp.position.x;
				global::VisNode.pY = global::VisNode.operandA._stamp.position.y;
				global::VisNode.pZ = global::VisNode.operandA._stamp.position.z;
				global::VisNode.fX = global::VisNode.operandA._stamp.plane.x;
				global::VisNode.fY = global::VisNode.operandA._stamp.plane.y;
				global::VisNode.fZ = global::VisNode.operandA._stamp.plane.z;
				global::VisNode.fW = global::VisNode.operandA._stamp.plane.w;
				global::VisNode.DOT = global::VisNode.operandA.dotArc;
				global::VisNode.SIGHT = global::VisNode.operandA.distance;
				global::VisNode.SIGHT2 = global::VisNode.SIGHT * global::VisNode.SIGHT;
				global::VisNode.PLANEDOTSIGHT = global::VisNode.fW + global::VisNode.SIGHT;
				if (global::VisNode.operandA.sight.any)
				{
					global::VisNode.FALLBACK_TOO_CLOSE = true;
					global::ODBSibling<global::VisNode> odbsibling3 = global::VisNode.operandA.sight.last.first;
					if (global::VisNode.operandA.histSight.changed)
					{
						do
						{
							global::VisNode.operandB = odbsibling3.item.self;
							odbsibling3 = odbsibling3.item.n;
							if (!global::VisNode.operandB.active)
							{
								global::VisNode.ResolveHide();
							}
							else
							{
								global::VisNode.operandB.__skipOnce_ = true;
								global::VisNode.temp_bTraits = global::VisNode.operandB._traitMask;
								if ((global::VisNode.temp_bTraits & global::VisNode.operandA._sightCurrentMask) == 0 || !global::VisNode.LogicSight())
								{
									global::VisNode.ResolveHide();
								}
								else
								{
									global::VisNode.operandA._seeMask |= global::VisNode.temp_bTraits;
								}
							}
						}
						while (odbsibling3.has);
					}
					else
					{
						global::VisNode.operandB = odbsibling3.item.self;
						do
						{
							global::VisNode.operandB = odbsibling3.item.self;
							odbsibling3 = odbsibling3.item.n;
							if (!global::VisNode.operandB.active)
							{
								global::VisNode.ResolveHide();
							}
							else
							{
								global::VisNode.operandB.__skipOnce_ = true;
								global::VisNode.temp_bTraits = global::VisNode.operandB._traitMask;
								if (global::VisNode.operandB.histTrait.changed)
								{
									if ((global::VisNode.temp_bTraits & global::VisNode.operandA._sightCurrentMask) == 0 || !global::VisNode.LogicSight())
									{
										global::VisNode.ResolveHide();
										goto IL_342;
									}
									global::VisNode.operandA.anySeenTraitChanges = true;
								}
								else if (!global::VisNode.LogicSight())
								{
									global::VisNode.ResolveHide();
									goto IL_342;
								}
								global::VisNode.operandA._seeMask |= global::VisNode.temp_bTraits;
							}
							IL_342:;
						}
						while (odbsibling3.has);
					}
					global::VisNode.FALLBACK_TOO_CLOSE = false;
				}
				global::VisNode.operandA.__skipOnce_ = true;
				global::ODBSibling<global::VisNode> odbsibling4 = first_sib;
				do
				{
					global::VisNode.operandB = odbsibling4.item.self;
					odbsibling4 = odbsibling4.item.n;
					if (global::VisNode.operandB.__skipOnce_)
					{
						global::VisNode.operandB.__skipOnce_ = false;
					}
					else
					{
						global::VisNode.temp_bTraits = global::VisNode.operandB._traitMask;
						if ((global::VisNode.temp_bTraits & global::VisNode.operandA._sightCurrentMask) != 0 && global::VisNode.LogicSight())
						{
							global::VisNode.ResolveSee();
							global::VisNode.operandA._seeMask |= global::VisNode.temp_bTraits;
						}
					}
				}
				while (odbsibling4.has);
				global::VisNode.operandB = null;
			}
		}
		while (odbsibling.has);
		global::VisNode.operandA = null;
	}

	// Token: 0x06002A91 RID: 10897 RVA: 0x000A0C84 File Offset: 0x0009EE84
	private static void ClearVis(global::ODBSibling<global::VisNode> iter)
	{
		do
		{
			global::VisNode.operandA = iter.item.self;
			iter = iter.item.n;
			if (global::VisNode.operandA.sight.any)
			{
				global::ODBSibling<global::VisNode> odbsibling = global::VisNode.operandA.sight.last.first;
				do
				{
					global::VisNode.operandB = odbsibling.item.self;
					odbsibling = odbsibling.item.n;
					global::VisNode.ResolveHide();
				}
				while (odbsibling.has);
				global::VisNode.operandB = null;
			}
		}
		while (iter.has);
		global::VisNode.operandA = null;
	}

	// Token: 0x06002A92 RID: 10898 RVA: 0x000A0D20 File Offset: 0x0009EF20
	private static void RunStamp(global::ODBSibling<global::VisNode> sib)
	{
		do
		{
			global::VisNode.operandA = sib.item.self;
			sib = sib.item.n;
			global::VisNode.operandA.Stamp();
		}
		while (sib.has);
		global::VisNode.operandA = null;
	}

	// Token: 0x06002A93 RID: 10899 RVA: 0x000A0D60 File Offset: 0x0009EF60
	private static void RunStat(global::ODBSibling<global::VisNode> sib)
	{
		do
		{
			global::VisNode.operandA = sib.item.self;
			sib = sib.item.n;
			global::VisNode.operandA.StatUpdate();
		}
		while (sib.has);
		global::VisNode.operandA = null;
	}

	// Token: 0x06002A94 RID: 10900 RVA: 0x000A0DA0 File Offset: 0x0009EFA0
	private static void RunHiddenCalls(global::ODBSibling<global::VisNode> sib)
	{
		do
		{
			global::VisNode.operandA = sib.item.self;
			sib = sib.item.n;
			if (global::VisNode.operandA.sight.rem)
			{
				global::ODBSibling<global::VisNode> odbsibling = global::VisNode.operandA.exit.first;
				do
				{
					global::VisNode.operandB = odbsibling.item.self;
					odbsibling = odbsibling.item.n;
					global::VisNode.operandB._CB_OnHiddenFrom_(global::VisNode.operandA);
				}
				while (odbsibling.has);
				global::VisNode.operandB = null;
			}
		}
		while (sib.has);
		global::VisNode.operandA = null;
	}

	// Token: 0x06002A95 RID: 10901 RVA: 0x000A0E44 File Offset: 0x0009F044
	private static void RunVoidSeenHiddenCalls(global::ODBSibling<global::VisNode> sib)
	{
		do
		{
			global::VisNode.operandA = sib.item.self;
			sib = sib.item.p;
			if (global::VisNode.operandA.spect.had)
			{
				if (!global::VisNode.operandA.spect.any)
				{
					global::VisNode.operandA._CB_OnHidden_();
					global::VisNode.operandA.spect.had = false;
				}
			}
			else if (global::VisNode.operandA.spect.any)
			{
				global::VisNode.operandA._CB_OnSeen_();
				global::VisNode.operandA.spect.had = true;
			}
			global::VisNode.operandA.sight.had = global::VisNode.operandA.sight.any;
		}
		while (sib.has);
		global::VisNode.operandA = null;
	}

	// Token: 0x06002A96 RID: 10902 RVA: 0x000A0F18 File Offset: 0x0009F118
	private static void RunSeenCalls(global::ODBSibling<global::VisNode> sib)
	{
		do
		{
			global::VisNode.operandA = sib.item.self;
			sib = sib.item.n;
			if (global::VisNode.operandA.sight.add)
			{
				global::ODBSibling<global::VisNode> odbsibling = global::VisNode.operandA.enter.last;
				do
				{
					global::VisNode.operandB = odbsibling.item.self;
					odbsibling = odbsibling.item.p;
					global::VisNode.operandB._CB_OnSeenBy_(global::VisNode.operandA);
				}
				while (odbsibling.has);
				global::VisNode.operandB = null;
			}
		}
		while (sib.has);
		global::VisNode.operandA = null;
	}

	// Token: 0x06002A97 RID: 10903 RVA: 0x000A0FBC File Offset: 0x0009F1BC
	private static void RunQueries(global::ODBSibling<global::VisNode> sib)
	{
		do
		{
			global::VisNode.operandA = sib.item.self;
			sib = sib.item.p;
			if (global::VisNode.operandA.reactor)
			{
				global::VisNode.operandA.CheckReactions();
			}
			global::VisNode.operandA.CheckQueries();
		}
		while (sib.has);
		global::VisNode.operandA = null;
	}

	// Token: 0x06002A98 RID: 10904 RVA: 0x000A1024 File Offset: 0x0009F224
	public static void Process()
	{
		if (global::VisNode.db.any)
		{
			if (global::VisNode.recentlyDisabled.any)
			{
				global::VisNode.RunStamp(global::VisNode.db.first);
				global::VisNode.RunStamp(global::VisNode.recentlyDisabled.first);
				global::VisNode.ClearVis(global::VisNode.recentlyDisabled.first);
				global::VisNode.UpdateVis(global::VisNode.db.first);
				global::VisNode.RunStat(global::VisNode.recentlyDisabled.first);
				global::VisNode.RunStat(global::VisNode.db.first);
				global::VisNode.RunHiddenCalls(global::VisNode.recentlyDisabled.first);
				global::VisNode.RunHiddenCalls(global::VisNode.db.first);
				global::VisNode.RunVoidSeenHiddenCalls(global::VisNode.recentlyDisabled.last);
				global::VisNode.RunVoidSeenHiddenCalls(global::VisNode.db.last);
				global::VisNode.RunSeenCalls(global::VisNode.recentlyDisabled.first);
				global::VisNode.RunSeenCalls(global::VisNode.db.first);
				global::VisNode.RunQueries(global::VisNode.recentlyDisabled.last);
				global::VisNode.RunQueries(global::VisNode.db.last);
				global::VisNode.Finally();
				global::VisNode.SwapDisabled();
			}
			else
			{
				global::VisNode.RunStamp(global::VisNode.db.first);
				global::VisNode.UpdateVis(global::VisNode.db.first);
				global::VisNode.RunStat(global::VisNode.db.first);
				global::VisNode.RunHiddenCalls(global::VisNode.db.first);
				global::VisNode.RunVoidSeenHiddenCalls(global::VisNode.db.last);
				global::VisNode.RunSeenCalls(global::VisNode.db.first);
				global::VisNode.RunQueries(global::VisNode.db.last);
				global::VisNode.Finally();
			}
		}
		else if (global::VisNode.recentlyDisabled.any)
		{
			global::VisNode.RunStamp(global::VisNode.recentlyDisabled.first);
			global::VisNode.ClearVis(global::VisNode.recentlyDisabled.first);
			global::VisNode.RunStat(global::VisNode.recentlyDisabled.first);
			global::VisNode.RunHiddenCalls(global::VisNode.recentlyDisabled.first);
			global::VisNode.RunVoidSeenHiddenCalls(global::VisNode.recentlyDisabled.last);
			global::VisNode.RunSeenCalls(global::VisNode.recentlyDisabled.first);
			global::VisNode.RunQueries(global::VisNode.recentlyDisabled.last);
			global::VisNode.Finally();
			global::VisNode.SwapDisabled();
		}
	}

	// Token: 0x06002A99 RID: 10905 RVA: 0x000A1228 File Offset: 0x0009F428
	private void StatUpdate()
	{
		this.sight.count = this.sight.list.count;
		this.sight.any = (this.sight.count > 0);
		this.spect.count = this.spect.list.count;
		this.spect.any = (this.spect.count > 0);
	}

	// Token: 0x06002A9A RID: 10906 RVA: 0x000A12A0 File Offset: 0x0009F4A0
	private void SeenHideFire()
	{
		if (this.spect.had != this.spect.any)
		{
			if (this.spect.any)
			{
				this._CB_OnSeen_();
			}
			else
			{
				this._CB_OnHidden_();
			}
			this.spect.had = this.spect.any;
		}
		this.sight.had = this.sight.any;
	}

	// Token: 0x06002A9B RID: 10907 RVA: 0x000A1318 File Offset: 0x0009F518
	private void DoQueryRecurse(int i, global::VisNode other)
	{
		if (i >= this._handle.Length)
		{
			return;
		}
		global::VisQuery.Instance instance = this._handle[i];
		switch (instance.TryAdd(this, other))
		{
		case global::VisQuery.TryResult.Enter:
			this.DoQueryRecurse(i + 1, other);
			instance.ExecuteEnter(this, other);
			return;
		case global::VisQuery.TryResult.Exit:
			instance.ExecuteExit(this, other);
			this.DoQueryRecurse(i + 1, other);
			return;
		}
		this.DoQueryRecurse(i + 1, other);
	}

	// Token: 0x06002A9C RID: 10908 RVA: 0x000A13A4 File Offset: 0x0009F5A4
	private void DoQueryRemAdd(global::ODBSibling<global::VisNode> sib)
	{
		if (this._handle.valid && this._handle.Length > 0)
		{
			while (sib.has)
			{
				global::VisNode self = sib.item.self;
				sib = sib.item.n;
				this.DoQueryRecurse(0, self);
			}
		}
	}

	// Token: 0x06002A9D RID: 10909 RVA: 0x000A1408 File Offset: 0x0009F608
	private void DoQueryRem(global::ODBSibling<global::VisNode> sib)
	{
		int length;
		if (this._handle.valid && (length = this._handle.Length) > 0)
		{
			while (sib.has)
			{
				global::VisNode self = sib.item.self;
				sib = sib.item.n;
				for (int i = 0; i < length; i++)
				{
					global::VisQuery.Instance instance = this._handle[i];
					if (instance.TryRemove(this, self) == global::VisQuery.TryResult.Exit)
					{
						instance.ExecuteExit(this, self);
					}
				}
			}
		}
	}

	// Token: 0x06002A9E RID: 10910 RVA: 0x000A149C File Offset: 0x0009F69C
	private void _REACTOR_SEE_REMOVE(global::ODBSibling<global::VisNode> sib)
	{
		while (sib.has)
		{
			global::VisNode self = sib.item.self;
			sib = sib.item.n;
			this.reactor.SEE_REMOVE(self);
		}
	}

	// Token: 0x06002A9F RID: 10911 RVA: 0x000A14E4 File Offset: 0x0009F6E4
	private void _REACTOR_SEE_ADD(global::ODBSibling<global::VisNode> sib)
	{
		while (sib.has)
		{
			global::VisNode self = sib.item.self;
			sib = sib.item.n;
			this.reactor.SEE_ADD(self);
		}
	}

	// Token: 0x06002AA0 RID: 10912 RVA: 0x000A152C File Offset: 0x0009F72C
	private void CheckReactions()
	{
		if (this.sight.rem)
		{
			this._REACTOR_SEE_REMOVE(this.exit.first);
			if (!this.sight.add && !this.sight.any)
			{
				this.reactor.AWARE_EXIT();
			}
		}
		if (this.sight.add)
		{
			if (!this.sight.had)
			{
				this.reactor.AWARE_ENTER();
			}
			this._REACTOR_SEE_ADD(this.enter.first);
		}
	}

	// Token: 0x06002AA1 RID: 10913 RVA: 0x000A15C4 File Offset: 0x0009F7C4
	private void CheckQueries()
	{
		this.histSeen.Upd(this._seeMask);
		if (this._handle.valid)
		{
			if (this.sight.rem)
			{
				this.DoQueryRem(this.exit.first);
			}
			if (this.anySeenTraitChanges || this.histTrait.changed)
			{
				this.DoQueryRemAdd(this.sight.list.first);
			}
			else if (this.sight.add)
			{
				this.DoQueryRemAdd(this.enter.first);
			}
		}
	}

	// Token: 0x06002AA2 RID: 10914 RVA: 0x000A166C File Offset: 0x0009F86C
	private static void Finally()
	{
		if (global::VisNode.disabledLastStep.any)
		{
			global::VisNode.RunStamp(global::VisNode.disabledLastStep.first);
			global::VisNode.disabledLastStep.Clear();
		}
	}

	// Token: 0x06002AA3 RID: 10915 RVA: 0x000A16A4 File Offset: 0x0009F8A4
	private static void SwapDisabled()
	{
		global::ODBSet<global::VisNode> odbset = global::VisNode.disabledLastStep;
		global::VisNode.disabledLastStep = global::VisNode.recentlyDisabled;
		global::VisNode.recentlyDisabled = odbset;
	}

	// Token: 0x06002AA4 RID: 10916 RVA: 0x000A16C8 File Offset: 0x0009F8C8
	protected void _CB_OnSeen_()
	{
		if (this.reactor)
		{
			this.reactor.SPECTATED_ENTER();
		}
	}

	// Token: 0x06002AA5 RID: 10917 RVA: 0x000A16E8 File Offset: 0x0009F8E8
	protected void _CB_OnHidden_()
	{
		if (this.reactor)
		{
			this.reactor.SPECTATED_EXIT();
		}
	}

	// Token: 0x06002AA6 RID: 10918 RVA: 0x000A1708 File Offset: 0x0009F908
	protected void _CB_OnSeenBy_(global::VisNode spectator)
	{
		if (this.reactor)
		{
			this.reactor.SPECTATOR_ADD(spectator);
		}
	}

	// Token: 0x06002AA7 RID: 10919 RVA: 0x000A1728 File Offset: 0x0009F928
	protected void _CB_OnHiddenFrom_(global::VisNode spectator)
	{
		if (this.reactor)
		{
			this.reactor.SPECTATOR_REMOVE(spectator);
		}
	}

	// Token: 0x06002AA8 RID: 10920 RVA: 0x000A1748 File Offset: 0x0009F948
	public bool CanSee(global::VisNode other)
	{
		return global::VisNode.CanSee(this, other);
	}

	// Token: 0x06002AA9 RID: 10921 RVA: 0x000A1754 File Offset: 0x0009F954
	public bool IsSeenBy(global::VisNode other)
	{
		return global::VisNode.IsSeenBy(this, other);
	}

	// Token: 0x06002AAA RID: 10922 RVA: 0x000A1760 File Offset: 0x0009F960
	public bool CanSeeUnobstructed(global::VisNode other)
	{
		return this.CanSee(other) && this.Unobstructed(other);
	}

	// Token: 0x06002AAB RID: 10923 RVA: 0x000A1778 File Offset: 0x0009F978
	public bool Unobstructed(global::VisNode other)
	{
		return global::UnityEngine.Physics.Linecast(this._stamp.position, other._stamp.position, 1);
	}

	// Token: 0x06002AAC RID: 10924 RVA: 0x000A1798 File Offset: 0x0009F998
	public static bool CanSee(global::VisNode instigator, global::VisNode target)
	{
		return instigator == target || instigator._CanSee(target);
	}

	// Token: 0x06002AAD RID: 10925 RVA: 0x000A17B0 File Offset: 0x0009F9B0
	public static bool IsSeenBy(global::VisNode instigator, global::VisNode target)
	{
		return instigator == target || instigator._IsSeenBy(target);
	}

	// Token: 0x06002AAE RID: 10926 RVA: 0x000A17C8 File Offset: 0x0009F9C8
	public static bool AreAware(global::VisNode instigator, global::VisNode target)
	{
		return global::VisNode.CanSee(instigator, target) && instigator._IsSeenBy(target);
	}

	// Token: 0x06002AAF RID: 10927 RVA: 0x000A17E0 File Offset: 0x0009F9E0
	public static bool IsStealthly(global::VisNode instigator, global::VisNode target)
	{
		return global::VisNode.CanSee(instigator, target) && !instigator._IsSeenBy(target);
	}

	// Token: 0x06002AB0 RID: 10928 RVA: 0x000A17FC File Offset: 0x0009F9FC
	public static bool AreOblivious(global::VisNode instigator, global::VisNode target)
	{
		return !global::VisNode.CanSee(instigator, target) && !instigator._IsSeenBy(target);
	}

	// Token: 0x06002AB1 RID: 10929 RVA: 0x000A1818 File Offset: 0x0009FA18
	public static global::Vis.Comparison Compare(global::VisNode self, global::VisNode target)
	{
		if (self == target)
		{
			return global::Vis.Comparison.IsSelf;
		}
		if (self._CanSee(target))
		{
			if (self._IsSeenBy(target))
			{
				return global::Vis.Comparison.Contact;
			}
			return global::Vis.Comparison.Stealthy;
		}
		else
		{
			if (self._IsSeenBy(target))
			{
				return global::Vis.Comparison.Prey;
			}
			return global::Vis.Comparison.Oblivious;
		}
	}

	// Token: 0x06002AB2 RID: 10930 RVA: 0x000A1864 File Offset: 0x0009FA64
	private bool _CanSee(global::VisNode other)
	{
		return (other.spect.count >= this.sight.count) ? this.sight.list.Contains(other) : other.spect.list.Contains(this);
	}

	// Token: 0x06002AB3 RID: 10931 RVA: 0x000A18B4 File Offset: 0x0009FAB4
	private bool _IsSeenBy(global::VisNode other)
	{
		return (other.sight.count >= this.spect.count) ? this.spect.list.Contains(other) : other.sight.list.Contains(this);
	}

	// Token: 0x06002AB4 RID: 10932 RVA: 0x000A1904 File Offset: 0x0009FB04
	[global::System.Diagnostics.Conditional("UNITY_EDITOR")]
	private static void _VALIDATE(global::VisNode vis)
	{
		if (vis.sight.count > 0 != vis.sight.any)
		{
			global::UnityEngine.Debug.LogError(string.Format("buzz {0} {1}", vis.sight.count, vis.sight.any), vis);
		}
		if (vis.sight.list.count != vis.sight.count)
		{
			global::UnityEngine.Debug.LogError(string.Format("buzz {0} {1}", vis.sight.list.count, vis.sight.count), vis);
		}
		if (vis.spect.count > 0 != vis.spect.any)
		{
			global::UnityEngine.Debug.LogError(string.Format("buzz {0} {1}", vis.spect.count, vis.spect.any), vis);
		}
		if (vis.spect.list.count != vis.spect.count)
		{
			global::UnityEngine.Debug.LogError(string.Format("buzz {0} {1}", vis.spect.list.count, vis.spect.count), vis);
		}
	}

	// Token: 0x06002AB5 RID: 10933 RVA: 0x000A1A58 File Offset: 0x0009FC58
	private static void RouteMessageHSet(global::ODBSet<global::VisNode> list, string msg, object arg)
	{
		if (list.any)
		{
			global::ODBSibling<global::VisNode> odbsibling = list.first;
			do
			{
				global::VisNode self = odbsibling.item.self;
				odbsibling = odbsibling.item.n;
				try
				{
					self.SendMessage(msg, arg, 1);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex, self);
				}
			}
			while (odbsibling.has);
		}
	}

	// Token: 0x06002AB6 RID: 10934 RVA: 0x000A1AD4 File Offset: 0x0009FCD4
	private static void RouteMessageList(global::RecycleList<global::VisNode> list, string msg)
	{
		global::VisNode.RouteMessageList(list, msg, null);
	}

	// Token: 0x06002AB7 RID: 10935 RVA: 0x000A1AE0 File Offset: 0x0009FCE0
	private static void RouteMessageList(global::RecycleList<global::VisNode> list, string msg, object arg)
	{
		using (global::RecycleListIter<global::VisNode> recycleListIter = list.MakeIter())
		{
			while (recycleListIter.MoveNext())
			{
				try
				{
					recycleListIter.Current.SendMessage(msg, arg, 1);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex, recycleListIter.Current);
				}
			}
		}
	}

	// Token: 0x06002AB8 RID: 10936 RVA: 0x000A1B70 File Offset: 0x0009FD70
	private static void RouteMessageOp(global::HSetOper op, global::ODBSet<global::VisNode> a, global::System.Collections.Generic.IEnumerable<global::VisNode> b, string msg, object arg)
	{
		global::RecycleList<global::VisNode> recycleList = a.OperList(op, b);
		global::VisNode.RouteMessageList(recycleList, msg, arg);
		recycleList.Dispose();
	}

	// Token: 0x06002AB9 RID: 10937 RVA: 0x000A1B98 File Offset: 0x0009FD98
	private static void RouteMessageOpUnionFirst(global::HSetOper op, global::ODBSet<global::VisNode> a, global::ODBSet<global::VisNode> aa, global::System.Collections.Generic.IEnumerable<global::VisNode> b, string msg, object arg)
	{
		global::ODBSet<global::VisNode> odbset = new global::ODBSet<global::VisNode>(a);
		odbset.UnionWith(aa);
		global::VisNode.RouteMessageOp(op, odbset, b, msg, arg);
	}

	// Token: 0x06002ABA RID: 10938 RVA: 0x000A1BC0 File Offset: 0x0009FDC0
	private static void RouteMessageOpUnionFirst(global::HSetOper op, global::ODBSet<global::VisNode> a, global::ODBSet<global::VisNode> aa, global::System.Collections.Generic.IEnumerable<global::VisNode> b, string msg)
	{
		global::VisNode.RouteMessageOpUnionFirst(op, a, aa, b, msg, null);
	}

	// Token: 0x06002ABB RID: 10939 RVA: 0x000A1BD0 File Offset: 0x0009FDD0
	private static void RouteMessageOp(global::HSetOper op, global::ODBSet<global::VisNode> a, global::System.Collections.Generic.IEnumerable<global::VisNode> b, string msg)
	{
		global::VisNode.RouteMessageOp(op, a, b, msg, null);
	}

	// Token: 0x06002ABC RID: 10940 RVA: 0x000A1BDC File Offset: 0x0009FDDC
	private static void DoGestureMessage(global::VisNode instigator, string message, object arg)
	{
		global::VisNode.RouteMessageHSet(instigator.spect.list, message, arg);
	}

	// Token: 0x06002ABD RID: 10941 RVA: 0x000A1BF0 File Offset: 0x0009FDF0
	public static bool GestureMessage(global::VisNode instigator, string message, object arg)
	{
		if (!instigator || !instigator.enabled)
		{
			return false;
		}
		global::VisNode.DoGestureMessage(instigator, message, arg);
		return true;
	}

	// Token: 0x06002ABE RID: 10942 RVA: 0x000A1C14 File Offset: 0x0009FE14
	private static void DoAttentionMessage(global::VisNode instigator, string message, object arg)
	{
		global::VisNode.RouteMessageHSet(instigator.sight.list, message, arg);
	}

	// Token: 0x06002ABF RID: 10943 RVA: 0x000A1C28 File Offset: 0x0009FE28
	public static bool AttentionMessage(global::VisNode instigator, string message, object arg)
	{
		return false;
	}

	// Token: 0x06002AC0 RID: 10944 RVA: 0x000A1C2C File Offset: 0x0009FE2C
	private static void DoStealthMessage(global::VisNode instigator, string message, object arg)
	{
		global::VisNode.RouteMessageOp(global::HSetOper.Except, instigator.sight.list, instigator.spect.list, message, arg);
	}

	// Token: 0x06002AC1 RID: 10945 RVA: 0x000A1C4C File Offset: 0x0009FE4C
	public static bool StealthMessage(global::VisNode instigator, string message, object arg)
	{
		return false;
	}

	// Token: 0x06002AC2 RID: 10946 RVA: 0x000A1C50 File Offset: 0x0009FE50
	private static void DoPreyMessage(global::VisNode instigator, string message, object arg)
	{
		global::VisNode.RouteMessageOp(global::HSetOper.Except, instigator.spect.list, instigator.sight.list, message, arg);
	}

	// Token: 0x06002AC3 RID: 10947 RVA: 0x000A1C70 File Offset: 0x0009FE70
	public static bool PreyMessage(global::VisNode instigator, string message, object arg)
	{
		return false;
	}

	// Token: 0x06002AC4 RID: 10948 RVA: 0x000A1C74 File Offset: 0x0009FE74
	private static void DoContactMessage(global::VisNode instigator, string message, object arg)
	{
		if (instigator.spect.count < instigator.sight.count)
		{
			global::VisNode.RouteMessageOp(global::HSetOper.Intersect, instigator.spect.list, instigator.sight.list, message, arg);
		}
		else
		{
			global::VisNode.RouteMessageOp(global::HSetOper.Intersect, instigator.sight.list, instigator.spect.list, message, arg);
		}
	}

	// Token: 0x06002AC5 RID: 10949 RVA: 0x000A1CE0 File Offset: 0x0009FEE0
	public static bool ContactMessage(global::VisNode instigator, string message, object arg)
	{
		return false;
	}

	// Token: 0x06002AC6 RID: 10950 RVA: 0x000A1CE4 File Offset: 0x0009FEE4
	private static void DoObliviousMessage(global::VisNode instigator, string message, object arg)
	{
		if (instigator.spect.count < instigator.sight.count)
		{
			global::VisNode.RouteMessageOpUnionFirst(global::HSetOper.SymmetricExcept, instigator.spect.list, instigator.sight.list, global::VisNode.db, message, arg);
		}
		else
		{
			global::VisNode.RouteMessageOpUnionFirst(global::HSetOper.SymmetricExcept, instigator.sight.list, instigator.spect.list, global::VisNode.db, message, arg);
		}
	}

	// Token: 0x06002AC7 RID: 10951 RVA: 0x000A1D58 File Offset: 0x0009FF58
	public static bool ObliviousMessage(global::VisNode instigator, string message, object arg)
	{
		if (!instigator || !instigator.enabled)
		{
			return false;
		}
		global::VisNode.DoObliviousMessage(instigator, message, arg);
		return true;
	}

	// Token: 0x06002AC8 RID: 10952 RVA: 0x000A1D7C File Offset: 0x0009FF7C
	public static void GlobalMessage(string message, object arg)
	{
		using (global::ODBForwardEnumerator<global::VisNode> enumerator = global::VisNode.db.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.SendMessage(message, arg, 1);
			}
		}
	}

	// Token: 0x06002AC9 RID: 10953 RVA: 0x000A1DE0 File Offset: 0x0009FFE0
	public static bool ComparisonMessage(global::VisNode instigator, global::Vis.Comparison comparison, string message, object arg)
	{
		switch (comparison)
		{
		case global::Vis.Comparison.Prey:
			return global::VisNode.PreyMessage(instigator, message, arg);
		default:
			if (comparison == global::Vis.Comparison.Oblivious)
			{
				return global::VisNode.ObliviousMessage(instigator, message, arg);
			}
			if (comparison != global::Vis.Comparison.Stealthy)
			{
				throw new global::System.ArgumentException(" do not know what to do with " + comparison, "comparison");
			}
			return global::VisNode.StealthMessage(instigator, message, arg);
		case global::Vis.Comparison.IsSelf:
			if (!instigator || !instigator.enabled)
			{
				return false;
			}
			instigator.SendMessage(message, arg, 1);
			return true;
		case global::Vis.Comparison.Contact:
			return global::VisNode.ContactMessage(instigator, message, arg);
		}
	}

	// Token: 0x06002ACA RID: 10954 RVA: 0x000A1E80 File Offset: 0x000A0080
	private static void DoAudibleMessage(global::VisNode instigator, global::UnityEngine.Vector3 position, float radius, string message, object arg)
	{
		global::VisNode.Search.Radial.Enumerator nodesInRadius = global::Vis.GetNodesInRadius(position, radius);
		if (!instigator.deaf)
		{
			while (nodesInRadius.MoveNext())
			{
				if (object.ReferenceEquals(nodesInRadius.Current, instigator))
				{
					break;
				}
				nodesInRadius.Current.SendMessage(message, arg, 1);
			}
		}
		while (nodesInRadius.MoveNext())
		{
			nodesInRadius.Current.SendMessage(message, arg, 1);
		}
		nodesInRadius.Dispose();
	}

	// Token: 0x06002ACB RID: 10955 RVA: 0x000A1F00 File Offset: 0x000A0100
	public static bool AudibleMessage(global::VisNode instigator, global::UnityEngine.Vector3 position, float radius, string message, object arg)
	{
		if (!instigator || instigator.mute || radius <= 0f || !instigator.enabled)
		{
			return false;
		}
		global::VisNode.DoAudibleMessage(instigator, position, radius, message, arg);
		return true;
	}

	// Token: 0x06002ACC RID: 10956 RVA: 0x000A1F48 File Offset: 0x000A0148
	public static bool AudibleMessage(global::VisNode instigator, float radius, string message, object arg)
	{
		if (!instigator || instigator.mute || radius <= 0f || !instigator.enabled)
		{
			return false;
		}
		global::VisNode.DoAudibleMessage(instigator, instigator._stamp.position, radius, message, arg);
		return true;
	}

	// Token: 0x06002ACD RID: 10957 RVA: 0x000A1F98 File Offset: 0x000A0198
	public static bool AudibleMessage(global::VisNode instigator, global::UnityEngine.Vector3 position, float radius, string message)
	{
		if (!instigator || instigator.mute || radius <= 0f || !instigator.enabled)
		{
			return false;
		}
		global::VisNode.DoAudibleMessage(instigator, position, radius, message, null);
		return true;
	}

	// Token: 0x06002ACE RID: 10958 RVA: 0x000A1FE0 File Offset: 0x000A01E0
	public static bool AudibleMessage(global::VisNode instigator, float radius, string message)
	{
		if (!instigator || instigator.mute || radius <= 0f || !instigator.enabled)
		{
			return false;
		}
		global::VisNode.DoAudibleMessage(instigator, instigator._stamp.position, radius, message, null);
		return true;
	}

	// Token: 0x06002ACF RID: 10959 RVA: 0x000A2030 File Offset: 0x000A0230
	public static bool GestureMessage(global::VisNode instigator, string message)
	{
		return global::VisNode.GestureMessage(instigator, message, null);
	}

	// Token: 0x06002AD0 RID: 10960 RVA: 0x000A203C File Offset: 0x000A023C
	public static bool AttentionMessage(global::VisNode instigator, string message)
	{
		return global::VisNode.AttentionMessage(instigator, message, null);
	}

	// Token: 0x06002AD1 RID: 10961 RVA: 0x000A2048 File Offset: 0x000A0248
	public static bool StealthMessage(global::VisNode instigator, string message)
	{
		return global::VisNode.StealthMessage(instigator, message, null);
	}

	// Token: 0x06002AD2 RID: 10962 RVA: 0x000A2054 File Offset: 0x000A0254
	public static bool PreyMessage(global::VisNode instigator, string message)
	{
		return global::VisNode.GestureMessage(instigator, message, null);
	}

	// Token: 0x06002AD3 RID: 10963 RVA: 0x000A2060 File Offset: 0x000A0260
	public static bool ContactMessage(global::VisNode instigator, string message)
	{
		return global::VisNode.AttentionMessage(instigator, message, null);
	}

	// Token: 0x06002AD4 RID: 10964 RVA: 0x000A206C File Offset: 0x000A026C
	public static bool ObliviousMessage(global::VisNode instigator, string message)
	{
		return global::VisNode.StealthMessage(instigator, message, null);
	}

	// Token: 0x06002AD5 RID: 10965 RVA: 0x000A2078 File Offset: 0x000A0278
	public static bool ComparisonMessage(global::VisNode instigator, global::Vis.Comparison comparison, string message)
	{
		return global::VisNode.ComparisonMessage(instigator, comparison, message, null);
	}

	// Token: 0x06002AD6 RID: 10966 RVA: 0x000A2084 File Offset: 0x000A0284
	public bool GestureMessage(string message, object arg)
	{
		if (!base.enabled)
		{
			return false;
		}
		global::VisNode.DoGestureMessage(this, message, arg);
		return true;
	}

	// Token: 0x06002AD7 RID: 10967 RVA: 0x000A209C File Offset: 0x000A029C
	public bool GestureMessage(string message)
	{
		if (!base.enabled)
		{
			return false;
		}
		global::VisNode.DoGestureMessage(this, message, null);
		return true;
	}

	// Token: 0x06002AD8 RID: 10968 RVA: 0x000A20B4 File Offset: 0x000A02B4
	public bool AttentionMessage(string message, object arg)
	{
		return false;
	}

	// Token: 0x06002AD9 RID: 10969 RVA: 0x000A20B8 File Offset: 0x000A02B8
	public bool AttentionMessage(string message)
	{
		return false;
	}

	// Token: 0x06002ADA RID: 10970 RVA: 0x000A20BC File Offset: 0x000A02BC
	public bool StealthMessage(string message, object arg)
	{
		return false;
	}

	// Token: 0x06002ADB RID: 10971 RVA: 0x000A20C0 File Offset: 0x000A02C0
	public bool PreyMessage(string message)
	{
		return false;
	}

	// Token: 0x06002ADC RID: 10972 RVA: 0x000A20C4 File Offset: 0x000A02C4
	public bool ContactMessage(string message, object arg)
	{
		return false;
	}

	// Token: 0x06002ADD RID: 10973 RVA: 0x000A20C8 File Offset: 0x000A02C8
	public bool ContactMessage(string message)
	{
		return false;
	}

	// Token: 0x06002ADE RID: 10974 RVA: 0x000A20CC File Offset: 0x000A02CC
	public bool ObliviousMessage(string message, object arg)
	{
		if (!base.enabled)
		{
			return false;
		}
		global::VisNode.ContactMessage(this, message, arg);
		return true;
	}

	// Token: 0x06002ADF RID: 10975 RVA: 0x000A20E8 File Offset: 0x000A02E8
	public bool ObliviousMessage(string message)
	{
		if (!base.enabled)
		{
			return false;
		}
		global::VisNode.ContactMessage(this, message, null);
		return true;
	}

	// Token: 0x06002AE0 RID: 10976 RVA: 0x000A2104 File Offset: 0x000A0304
	public bool ComparisonMessage(global::Vis.Comparison comparison, string message, object arg)
	{
		return global::VisNode.ComparisonMessage(this, comparison, message, arg);
	}

	// Token: 0x06002AE1 RID: 10977 RVA: 0x000A2110 File Offset: 0x000A0310
	public bool ComparisonMessage(global::Vis.Comparison comparison, string message)
	{
		return global::VisNode.ComparisonMessage(this, comparison, message, null);
	}

	// Token: 0x06002AE2 RID: 10978 RVA: 0x000A211C File Offset: 0x000A031C
	public bool AudibleMessage(float radius, string message, object arg)
	{
		if (this.mute || !base.enabled || radius <= 0f)
		{
			return false;
		}
		global::VisNode.DoAudibleMessage(this, this._stamp.position, radius, message, arg);
		return true;
	}

	// Token: 0x06002AE3 RID: 10979 RVA: 0x000A2164 File Offset: 0x000A0364
	public bool AudibleMessage(float radius, string message)
	{
		if (this.mute || !base.enabled || radius <= 0f)
		{
			return false;
		}
		global::VisNode.DoAudibleMessage(this, this._stamp.position, radius, message, null);
		return true;
	}

	// Token: 0x06002AE4 RID: 10980 RVA: 0x000A21AC File Offset: 0x000A03AC
	public bool AudibleMessage(global::UnityEngine.Vector3 point, float radius, string message, object arg)
	{
		if (this.mute || !base.enabled || radius <= 0f)
		{
			return false;
		}
		global::VisNode.DoAudibleMessage(this, point, radius, message, arg);
		return true;
	}

	// Token: 0x06002AE5 RID: 10981 RVA: 0x000A21E8 File Offset: 0x000A03E8
	public bool AudibleMessage(global::UnityEngine.Vector3 point, float radius, string message)
	{
		if (this.mute || !base.enabled || radius <= 0f)
		{
			return false;
		}
		global::VisNode.DoAudibleMessage(this, point, radius, message, null);
		return true;
	}

	// Token: 0x06002AE6 RID: 10982 RVA: 0x000A2224 File Offset: 0x000A0424
	private void DrawConnections(global::ODBSet<global::VisNode> list)
	{
		if (list != null)
		{
			global::ODBForwardEnumerator<global::VisNode> enumerator = list.GetEnumerator();
			while (enumerator.MoveNext())
			{
				global::UnityEngine.Vector3 position = enumerator.Current._stamp.position;
				global::UnityEngine.Gizmos.DrawLine(this._stamp.position, position);
				global::UnityEngine.Gizmos.DrawWireSphere(position, 0.5f);
			}
			enumerator.Dispose();
		}
	}

	// Token: 0x06002AE7 RID: 10983 RVA: 0x000A2284 File Offset: 0x000A0484
	private void OnDrawGizmosSelected()
	{
		global::VisGizmosUtility.ResetMatrixStack();
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0f, 1f, 0f, 0.5f);
		this.DrawConnections(this.sight.list);
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0f, 0f, 1f, 0.5f);
		this.DrawConnections(this.spect.list);
		global::UnityEngine.Transform transform = (!this._transform) ? base.transform : this._transform;
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(1f, 1f, 1f, 0.9f);
		global::UnityEngine.Vector3 normalized = transform.forward.normalized;
		global::UnityEngine.Vector3 position = transform.position;
		global::UnityEngine.Vector3 vector = position + normalized * this.distance;
		global::UnityEngine.Gizmos.DrawLine(position, vector);
		global::VisGizmosUtility.DrawDotArc(position, transform, this.distance, this.dotArc, this.dotArcBegin);
	}

	// Token: 0x0400153F RID: 5439
	private const int defaultUnobstructedLayers = 1;

	// Token: 0x04001540 RID: 5440
	[global::PrefetchComponent]
	[global::UnityEngine.SerializeField]
	private global::VisReactor reactor;

	// Token: 0x04001541 RID: 5441
	[global::UnityEngine.SerializeField]
	private float dotArc = 0.75f;

	// Token: 0x04001542 RID: 5442
	[global::UnityEngine.SerializeField]
	private float distance = 10f;

	// Token: 0x04001543 RID: 5443
	[global::UnityEngine.SerializeField]
	private float dotArcBegin;

	// Token: 0x04001544 RID: 5444
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int _sightMask = -1;

	// Token: 0x04001545 RID: 5445
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int _spectMask = -1;

	// Token: 0x04001546 RID: 5446
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int _traitMask = 0x1000001;

	// Token: 0x04001547 RID: 5447
	[global::System.NonSerialized]
	private int _sightCurrentMask;

	// Token: 0x04001548 RID: 5448
	[global::System.NonSerialized]
	private int _seeMask;

	// Token: 0x04001549 RID: 5449
	[global::System.NonSerialized]
	private bool anySeenTraitChanges;

	// Token: 0x0400154A RID: 5450
	[global::System.NonSerialized]
	private bool hasStatusHandler;

	// Token: 0x0400154B RID: 5451
	[global::System.NonSerialized]
	private bool __skipOnce_;

	// Token: 0x0400154C RID: 5452
	[global::System.NonSerialized]
	private bool awake;

	// Token: 0x0400154D RID: 5453
	[global::System.NonSerialized]
	private bool active;

	// Token: 0x0400154E RID: 5454
	[global::System.NonSerialized]
	private bool dataConstructed;

	// Token: 0x0400154F RID: 5455
	public bool blind;

	// Token: 0x04001550 RID: 5456
	public bool deaf;

	// Token: 0x04001551 RID: 5457
	public bool mute;

	// Token: 0x04001552 RID: 5458
	[global::UnityEngine.SerializeField]
	private global::VisClass _class;

	// Token: 0x04001553 RID: 5459
	[global::System.NonSerialized]
	private global::VisClass.Handle _handle;

	// Token: 0x04001554 RID: 5460
	private long queriesBitMask;

	// Token: 0x04001555 RID: 5461
	private global::IVisHandler statusHandler;

	// Token: 0x04001556 RID: 5462
	[global::System.NonSerialized]
	private global::VisNode.TraitHistory histSight;

	// Token: 0x04001557 RID: 5463
	[global::System.NonSerialized]
	private global::VisNode.TraitHistory histSpect;

	// Token: 0x04001558 RID: 5464
	[global::System.NonSerialized]
	private global::VisNode.TraitHistory histTrait;

	// Token: 0x04001559 RID: 5465
	[global::System.NonSerialized]
	private global::VisNode.TraitHistory histSeen;

	// Token: 0x0400155A RID: 5466
	private global::VisNode.VisMem spect;

	// Token: 0x0400155B RID: 5467
	private global::VisNode.VisMem sight;

	// Token: 0x0400155C RID: 5468
	private global::ODBSet<global::VisNode> enter;

	// Token: 0x0400155D RID: 5469
	private global::ODBSet<global::VisNode> exit;

	// Token: 0x0400155E RID: 5470
	internal global::ODBItem<global::VisNode> item;

	// Token: 0x0400155F RID: 5471
	private global::System.Collections.Generic.List<global::VisNode> cleanList;

	// Token: 0x04001560 RID: 5472
	[global::System.NonSerialized]
	[global::UnityEngine.HideInInspector]
	private global::UnityEngine.Transform _transform;

	// Token: 0x04001561 RID: 5473
	[global::System.NonSerialized]
	private global::Vis.Stamp _stamp;

	// Token: 0x04001562 RID: 5474
	private static global::ObjectDB<global::VisNode> db = new global::ObjectDB<global::VisNode>();

	// Token: 0x04001563 RID: 5475
	private static global::VisManager manager;

	// Token: 0x04001564 RID: 5476
	private static global::ODBSet<global::VisNode> recentlyDisabled = new global::ODBSet<global::VisNode>();

	// Token: 0x04001565 RID: 5477
	private static global::ODBSet<global::VisNode> disabledLastStep = new global::ODBSet<global::VisNode>();

	// Token: 0x04001566 RID: 5478
	private static global::VisNode operandA;

	// Token: 0x04001567 RID: 5479
	private static global::VisNode operandB;

	// Token: 0x04001568 RID: 5480
	private static float pX;

	// Token: 0x04001569 RID: 5481
	private static float pY;

	// Token: 0x0400156A RID: 5482
	private static float pZ;

	// Token: 0x0400156B RID: 5483
	private static float bX;

	// Token: 0x0400156C RID: 5484
	private static float bY;

	// Token: 0x0400156D RID: 5485
	private static float bZ;

	// Token: 0x0400156E RID: 5486
	private static float fX;

	// Token: 0x0400156F RID: 5487
	private static float fY;

	// Token: 0x04001570 RID: 5488
	private static float fZ;

	// Token: 0x04001571 RID: 5489
	private static float fW;

	// Token: 0x04001572 RID: 5490
	private static float dX;

	// Token: 0x04001573 RID: 5491
	private static float dY;

	// Token: 0x04001574 RID: 5492
	private static float dZ;

	// Token: 0x04001575 RID: 5493
	private static float nX;

	// Token: 0x04001576 RID: 5494
	private static float nY;

	// Token: 0x04001577 RID: 5495
	private static float nZ;

	// Token: 0x04001578 RID: 5496
	private static float dV;

	// Token: 0x04001579 RID: 5497
	private static float dV2;

	// Token: 0x0400157A RID: 5498
	private static float dot;

	// Token: 0x0400157B RID: 5499
	private static float planeDot;

	// Token: 0x0400157C RID: 5500
	private static float SIGHT;

	// Token: 0x0400157D RID: 5501
	private static float PLANEDOTSIGHT;

	// Token: 0x0400157E RID: 5502
	private static float SIGHT2;

	// Token: 0x0400157F RID: 5503
	private static float DOT;

	// Token: 0x04001580 RID: 5504
	private static bool FALLBACK_TOO_CLOSE = false;

	// Token: 0x04001581 RID: 5505
	private static int temp_bTraits;

	// Token: 0x020004C4 RID: 1220
	private struct TraitHistory
	{
		// Token: 0x06002AE8 RID: 10984 RVA: 0x000A2380 File Offset: 0x000A0580
		public int Upd(int newTraits)
		{
			int num = newTraits ^ this.last;
			this.changed = (num != 0);
			this.last = newTraits;
			return num;
		}

		// Token: 0x04001582 RID: 5506
		public int last;

		// Token: 0x04001583 RID: 5507
		public bool changed;
	}

	// Token: 0x020004C5 RID: 1221
	private struct VisMem
	{
		// Token: 0x04001584 RID: 5508
		public global::ODBSet<global::VisNode> list;

		// Token: 0x04001585 RID: 5509
		public global::ODBSet<global::VisNode> last;

		// Token: 0x04001586 RID: 5510
		public int count;

		// Token: 0x04001587 RID: 5511
		public bool add;

		// Token: 0x04001588 RID: 5512
		public bool rem;

		// Token: 0x04001589 RID: 5513
		public bool any;

		// Token: 0x0400158A RID: 5514
		public bool had;
	}

	// Token: 0x020004C6 RID: 1222
	public static class Search
	{
		// Token: 0x020004C7 RID: 1223
		public interface ISearch : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::VisNode>
		{
		}

		// Token: 0x020004C8 RID: 1224
		public interface ISearch<TEnumerator> : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode> where TEnumerator : struct, global::System.Collections.Generic.IEnumerator<global::VisNode>
		{
			// Token: 0x06002AE9 RID: 10985
			TEnumerator GetEnumerator();
		}

		// Token: 0x020004C9 RID: 1225
		public struct PointRadiusData
		{
			// Token: 0x06002AEA RID: 10986 RVA: 0x000A23AC File Offset: 0x000A05AC
			public PointRadiusData(global::UnityEngine.Vector3 pos, float radius)
			{
				this.x = pos.x;
				this.y = pos.y;
				this.z = pos.z;
				this.radiusSquare = radius * radius;
				this.dX = 0f;
				this.dY = 0f;
				this.dZ = 0f;
				this.d2 = 0f;
			}

			// Token: 0x06002AEB RID: 10987 RVA: 0x000A2418 File Offset: 0x000A0618
			public bool Pass(global::VisNode current)
			{
				this.dX = this.x - current._stamp.position.x;
				this.dY = this.y - current._stamp.position.y;
				this.dZ = this.z - current._stamp.position.z;
				this.d2 = this.dX * this.dX + this.dY * this.dY + this.dZ * this.dZ;
				return this.d2 <= this.radiusSquare;
			}

			// Token: 0x0400158B RID: 5515
			public float radiusSquare;

			// Token: 0x0400158C RID: 5516
			public float x;

			// Token: 0x0400158D RID: 5517
			public float y;

			// Token: 0x0400158E RID: 5518
			public float z;

			// Token: 0x0400158F RID: 5519
			public float dX;

			// Token: 0x04001590 RID: 5520
			public float dY;

			// Token: 0x04001591 RID: 5521
			public float dZ;

			// Token: 0x04001592 RID: 5522
			public float d2;
		}

		// Token: 0x020004CA RID: 1226
		public struct PointVisibilityData
		{
			// Token: 0x06002AEC RID: 10988 RVA: 0x000A24C0 File Offset: 0x000A06C0
			public PointVisibilityData(global::UnityEngine.Vector3 point)
			{
				this.x = point.x;
				this.y = point.y;
				this.z = point.z;
				this.dX = 0f;
				this.dY = 0f;
				this.dZ = 0f;
				this.d2 = 0f;
				this.d = 0f;
				this.nX = 0f;
				this.nY = 0f;
				this.nZ = 0f;
				this.radius = 0f;
				this.radiusSquare = 0f;
			}

			// Token: 0x06002AED RID: 10989 RVA: 0x000A2564 File Offset: 0x000A0764
			public bool Pass(global::VisNode Current)
			{
				this.radius = Current.distance;
				this.radiusSquare *= this.radiusSquare;
				this.dX = this.x - Current._stamp.position.x;
				this.dY = this.y - Current._stamp.position.y;
				this.dZ = this.z - Current._stamp.position.z;
				this.d2 = this.dX * this.dX + this.dY * this.dY + this.dZ * this.dZ;
				if (this.d2 < 4E-45f)
				{
					return true;
				}
				this.d = global::UnityEngine.Mathf.Sqrt(this.d2);
				this.nX = this.dX / this.d;
				this.nY = this.dY / this.d;
				this.nZ = this.dZ / this.d;
				global::VisNode.dot = Current._stamp.plane.x * this.nX + Current._stamp.plane.y * this.nY + Current._stamp.plane.z * this.nZ;
				return global::VisNode.dot >= Current.dotArc;
			}

			// Token: 0x04001593 RID: 5523
			public float x;

			// Token: 0x04001594 RID: 5524
			public float y;

			// Token: 0x04001595 RID: 5525
			public float z;

			// Token: 0x04001596 RID: 5526
			public float dX;

			// Token: 0x04001597 RID: 5527
			public float dY;

			// Token: 0x04001598 RID: 5528
			public float dZ;

			// Token: 0x04001599 RID: 5529
			public float d2;

			// Token: 0x0400159A RID: 5530
			public float d;

			// Token: 0x0400159B RID: 5531
			public float nX;

			// Token: 0x0400159C RID: 5532
			public float nY;

			// Token: 0x0400159D RID: 5533
			public float nZ;

			// Token: 0x0400159E RID: 5534
			public float radius;

			// Token: 0x0400159F RID: 5535
			public float radiusSquare;
		}

		// Token: 0x020004CB RID: 1227
		public struct MaskCompareData
		{
			// Token: 0x06002AEE RID: 10990 RVA: 0x000A26D4 File Offset: 0x000A08D4
			public MaskCompareData(global::Vis.Op op, global::Vis.Mask mask)
			{
				this.op = op;
				this.mask = mask.data;
			}

			// Token: 0x06002AEF RID: 10991 RVA: 0x000A26EC File Offset: 0x000A08EC
			public bool Pass(int mask)
			{
				return global::Vis.Evaluate(this.op, this.mask, mask);
			}

			// Token: 0x040015A0 RID: 5536
			public global::Vis.Op op;

			// Token: 0x040015A1 RID: 5537
			public int mask;
		}

		// Token: 0x020004CC RID: 1228
		public struct PointRadiusMaskData
		{
			// Token: 0x06002AF0 RID: 10992 RVA: 0x000A2700 File Offset: 0x000A0900
			public PointRadiusMaskData(global::UnityEngine.Vector3 pos, float radius, global::Vis.Op op, global::Vis.Mask mask)
			{
				this = new global::VisNode.Search.PointRadiusMaskData(new global::VisNode.Search.PointRadiusData(pos, radius), new global::VisNode.Search.MaskCompareData(op, mask));
			}

			// Token: 0x06002AF1 RID: 10993 RVA: 0x000A2718 File Offset: 0x000A0918
			public PointRadiusMaskData(global::VisNode.Search.PointRadiusData pr, global::VisNode.Search.MaskCompareData mc)
			{
				this.pr = pr;
				this.mc = mc;
			}

			// Token: 0x06002AF2 RID: 10994 RVA: 0x000A2728 File Offset: 0x000A0928
			public bool Pass(global::VisNode current, int mask)
			{
				return this.mc.Pass(mask) && this.pr.Pass(current);
			}

			// Token: 0x040015A2 RID: 5538
			public global::VisNode.Search.PointRadiusData pr;

			// Token: 0x040015A3 RID: 5539
			public global::VisNode.Search.MaskCompareData mc;
		}

		// Token: 0x020004CD RID: 1229
		public struct Radial : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Radial.Enumerator>
		{
			// Token: 0x06002AF3 RID: 10995 RVA: 0x000A2758 File Offset: 0x000A0958
			public Radial(global::UnityEngine.Vector3 point, float radius)
			{
				this.point = point;
				this.radius = radius;
			}

			// Token: 0x06002AF4 RID: 10996 RVA: 0x000A2768 File Offset: 0x000A0968
			global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06002AF5 RID: 10997 RVA: 0x000A2778 File Offset: 0x000A0978
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06002AF6 RID: 10998 RVA: 0x000A2788 File Offset: 0x000A0988
			public global::VisNode.Search.Radial.Enumerator GetEnumerator()
			{
				return new global::VisNode.Search.Radial.Enumerator(new global::VisNode.Search.PointRadiusData(this.point, this.radius));
			}

			// Token: 0x040015A4 RID: 5540
			public global::UnityEngine.Vector3 point;

			// Token: 0x040015A5 RID: 5541
			public float radius;

			// Token: 0x020004CE RID: 1230
			public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
			{
				// Token: 0x06002AF7 RID: 10999 RVA: 0x000A27A0 File Offset: 0x000A09A0
				public Enumerator(global::VisNode.Search.PointRadiusData pr)
				{
					this.Current = null;
					this.d = false;
					this.e = global::VisNode.db.GetEnumerator();
					this.data = pr;
				}

				// Token: 0x17000976 RID: 2422
				// (get) Token: 0x06002AF8 RID: 11000 RVA: 0x000A27C8 File Offset: 0x000A09C8
				global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
				{
					get
					{
						return this.Current;
					}
				}

				// Token: 0x17000977 RID: 2423
				// (get) Token: 0x06002AF9 RID: 11001 RVA: 0x000A27D0 File Offset: 0x000A09D0
				object global::System.Collections.IEnumerator.Current
				{
					get
					{
						return this.Current;
					}
				}

				// Token: 0x06002AFA RID: 11002 RVA: 0x000A27D8 File Offset: 0x000A09D8
				public bool MoveNext()
				{
					while (this.e.MoveNext())
					{
						if (this.Pass(this.e.Current))
						{
							return true;
						}
					}
					this.Current = null;
					return false;
				}

				// Token: 0x06002AFB RID: 11003 RVA: 0x000A2810 File Offset: 0x000A0A10
				public void Dispose()
				{
					if (!this.d)
					{
						this.e.Dispose();
						this.d = true;
					}
				}

				// Token: 0x06002AFC RID: 11004 RVA: 0x000A2830 File Offset: 0x000A0A30
				public void Reset()
				{
					this.Dispose();
					this.d = false;
					this.e = global::VisNode.db.GetEnumerator();
				}

				// Token: 0x06002AFD RID: 11005 RVA: 0x000A2850 File Offset: 0x000A0A50
				private bool Pass(global::VisNode cur)
				{
					if (this.data.Pass(cur))
					{
						this.Current = cur;
						return true;
					}
					return false;
				}

				// Token: 0x040015A6 RID: 5542
				public global::ODBForwardEnumerator<global::VisNode> e;

				// Token: 0x040015A7 RID: 5543
				public global::VisNode Current;

				// Token: 0x040015A8 RID: 5544
				private bool d;

				// Token: 0x040015A9 RID: 5545
				public global::VisNode.Search.PointRadiusData data;
			}

			// Token: 0x020004CF RID: 1231
			public struct TraitMasked : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Radial.TraitMasked.Enumerator>
			{
				// Token: 0x06002AFE RID: 11006 RVA: 0x000A2870 File Offset: 0x000A0A70
				public TraitMasked(global::UnityEngine.Vector3 point, float radius, global::Vis.Mask mask, global::Vis.Op op)
				{
					this.point = point;
					this.radius = radius;
					this.maskComp = new global::VisNode.Search.MaskCompareData(op, mask);
				}

				// Token: 0x06002AFF RID: 11007 RVA: 0x000A2890 File Offset: 0x000A0A90
				global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B00 RID: 11008 RVA: 0x000A28A0 File Offset: 0x000A0AA0
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B01 RID: 11009 RVA: 0x000A28B0 File Offset: 0x000A0AB0
				public global::VisNode.Search.Radial.TraitMasked.Enumerator GetEnumerator()
				{
					return new global::VisNode.Search.Radial.TraitMasked.Enumerator(new global::VisNode.Search.PointRadiusData(this.point, this.radius), this.maskComp);
				}

				// Token: 0x040015AA RID: 5546
				public global::UnityEngine.Vector3 point;

				// Token: 0x040015AB RID: 5547
				public float radius;

				// Token: 0x040015AC RID: 5548
				public global::VisNode.Search.MaskCompareData maskComp;

				// Token: 0x020004D0 RID: 1232
				public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
				{
					// Token: 0x06002B02 RID: 11010 RVA: 0x000A28D0 File Offset: 0x000A0AD0
					public Enumerator(global::VisNode.Search.PointRadiusData pr, global::VisNode.Search.MaskCompareData mc)
					{
						this.Current = null;
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
						this.data = pr;
						this.traitComp = mc;
					}

					// Token: 0x17000978 RID: 2424
					// (get) Token: 0x06002B03 RID: 11011 RVA: 0x000A290C File Offset: 0x000A0B0C
					global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x17000979 RID: 2425
					// (get) Token: 0x06002B04 RID: 11012 RVA: 0x000A2914 File Offset: 0x000A0B14
					object global::System.Collections.IEnumerator.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x06002B05 RID: 11013 RVA: 0x000A291C File Offset: 0x000A0B1C
					public bool MoveNext()
					{
						while (this.e.MoveNext())
						{
							if (this.Pass(this.e.Current))
							{
								return true;
							}
						}
						this.Current = null;
						return false;
					}

					// Token: 0x06002B06 RID: 11014 RVA: 0x000A2954 File Offset: 0x000A0B54
					public void Dispose()
					{
						if (!this.d)
						{
							this.e.Dispose();
							this.d = true;
						}
					}

					// Token: 0x06002B07 RID: 11015 RVA: 0x000A2974 File Offset: 0x000A0B74
					public void Reset()
					{
						this.Dispose();
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
					}

					// Token: 0x06002B08 RID: 11016 RVA: 0x000A2994 File Offset: 0x000A0B94
					private bool Pass(global::VisNode cur)
					{
						if (this.traitComp.Pass(cur._traitMask) && this.data.Pass(cur))
						{
							this.Current = cur;
							return true;
						}
						return false;
					}

					// Token: 0x040015AD RID: 5549
					public global::ODBForwardEnumerator<global::VisNode> e;

					// Token: 0x040015AE RID: 5550
					public global::VisNode Current;

					// Token: 0x040015AF RID: 5551
					private bool d;

					// Token: 0x040015B0 RID: 5552
					public global::VisNode.Search.PointRadiusData data;

					// Token: 0x040015B1 RID: 5553
					public global::VisNode.Search.MaskCompareData traitComp;
				}
			}

			// Token: 0x020004D1 RID: 1233
			public struct SightMasked : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Radial.SightMasked.Enumerator>
			{
				// Token: 0x06002B09 RID: 11017 RVA: 0x000A29C8 File Offset: 0x000A0BC8
				public SightMasked(global::UnityEngine.Vector3 point, float radius, global::Vis.Mask mask, global::Vis.Op op)
				{
					this.point = point;
					this.radius = radius;
					this.maskComp = new global::VisNode.Search.MaskCompareData(op, mask);
				}

				// Token: 0x06002B0A RID: 11018 RVA: 0x000A29E8 File Offset: 0x000A0BE8
				global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B0B RID: 11019 RVA: 0x000A29F8 File Offset: 0x000A0BF8
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B0C RID: 11020 RVA: 0x000A2A08 File Offset: 0x000A0C08
				public global::VisNode.Search.Radial.SightMasked.Enumerator GetEnumerator()
				{
					return new global::VisNode.Search.Radial.SightMasked.Enumerator(new global::VisNode.Search.PointRadiusData(this.point, this.radius), this.maskComp);
				}

				// Token: 0x040015B2 RID: 5554
				public global::UnityEngine.Vector3 point;

				// Token: 0x040015B3 RID: 5555
				public float radius;

				// Token: 0x040015B4 RID: 5556
				public global::VisNode.Search.MaskCompareData maskComp;

				// Token: 0x020004D2 RID: 1234
				public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
				{
					// Token: 0x06002B0D RID: 11021 RVA: 0x000A2A28 File Offset: 0x000A0C28
					public Enumerator(global::VisNode.Search.PointRadiusData pr, global::VisNode.Search.MaskCompareData mc)
					{
						this.Current = null;
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
						this.data = pr;
						this.viewComp = mc;
					}

					// Token: 0x1700097A RID: 2426
					// (get) Token: 0x06002B0E RID: 11022 RVA: 0x000A2A64 File Offset: 0x000A0C64
					global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x1700097B RID: 2427
					// (get) Token: 0x06002B0F RID: 11023 RVA: 0x000A2A6C File Offset: 0x000A0C6C
					object global::System.Collections.IEnumerator.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x06002B10 RID: 11024 RVA: 0x000A2A74 File Offset: 0x000A0C74
					public bool MoveNext()
					{
						while (this.e.MoveNext())
						{
							if (this.Pass(this.e.Current))
							{
								return true;
							}
						}
						this.Current = null;
						return false;
					}

					// Token: 0x06002B11 RID: 11025 RVA: 0x000A2AAC File Offset: 0x000A0CAC
					public void Dispose()
					{
						if (!this.d)
						{
							this.e.Dispose();
							this.d = true;
						}
					}

					// Token: 0x06002B12 RID: 11026 RVA: 0x000A2ACC File Offset: 0x000A0CCC
					public void Reset()
					{
						this.Dispose();
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
					}

					// Token: 0x06002B13 RID: 11027 RVA: 0x000A2AEC File Offset: 0x000A0CEC
					private bool Pass(global::VisNode cur)
					{
						if (this.viewComp.Pass(cur._sightMask) && this.data.Pass(cur))
						{
							this.Current = cur;
							return true;
						}
						return false;
					}

					// Token: 0x040015B5 RID: 5557
					public global::ODBForwardEnumerator<global::VisNode> e;

					// Token: 0x040015B6 RID: 5558
					public global::VisNode Current;

					// Token: 0x040015B7 RID: 5559
					private bool d;

					// Token: 0x040015B8 RID: 5560
					public global::VisNode.Search.PointRadiusData data;

					// Token: 0x040015B9 RID: 5561
					public global::VisNode.Search.MaskCompareData viewComp;
				}
			}

			// Token: 0x020004D3 RID: 1235
			public struct Audible : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Radial.Audible.Enumerator>
			{
				// Token: 0x06002B14 RID: 11028 RVA: 0x000A2B20 File Offset: 0x000A0D20
				public Audible(global::UnityEngine.Vector3 point, float radius)
				{
					this.point = point;
					this.radius = radius;
				}

				// Token: 0x06002B15 RID: 11029 RVA: 0x000A2B30 File Offset: 0x000A0D30
				global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B16 RID: 11030 RVA: 0x000A2B40 File Offset: 0x000A0D40
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B17 RID: 11031 RVA: 0x000A2B50 File Offset: 0x000A0D50
				public global::VisNode.Search.Radial.Audible.Enumerator GetEnumerator()
				{
					return new global::VisNode.Search.Radial.Audible.Enumerator(new global::VisNode.Search.PointRadiusData(this.point, this.radius));
				}

				// Token: 0x040015BA RID: 5562
				public global::UnityEngine.Vector3 point;

				// Token: 0x040015BB RID: 5563
				public float radius;

				// Token: 0x020004D4 RID: 1236
				public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
				{
					// Token: 0x06002B18 RID: 11032 RVA: 0x000A2B68 File Offset: 0x000A0D68
					public Enumerator(global::VisNode.Search.PointRadiusData pr)
					{
						this.Current = null;
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
						this.data = pr;
					}

					// Token: 0x1700097C RID: 2428
					// (get) Token: 0x06002B19 RID: 11033 RVA: 0x000A2B90 File Offset: 0x000A0D90
					global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x1700097D RID: 2429
					// (get) Token: 0x06002B1A RID: 11034 RVA: 0x000A2B98 File Offset: 0x000A0D98
					object global::System.Collections.IEnumerator.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x06002B1B RID: 11035 RVA: 0x000A2BA0 File Offset: 0x000A0DA0
					public bool MoveNext()
					{
						while (this.e.MoveNext())
						{
							if (this.Pass(this.e.Current))
							{
								return true;
							}
						}
						this.Current = null;
						return false;
					}

					// Token: 0x06002B1C RID: 11036 RVA: 0x000A2BD8 File Offset: 0x000A0DD8
					public void Dispose()
					{
						if (!this.d)
						{
							this.e.Dispose();
							this.d = true;
						}
					}

					// Token: 0x06002B1D RID: 11037 RVA: 0x000A2BF8 File Offset: 0x000A0DF8
					public void Reset()
					{
						this.Dispose();
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
					}

					// Token: 0x06002B1E RID: 11038 RVA: 0x000A2C18 File Offset: 0x000A0E18
					private bool Pass(global::VisNode cur)
					{
						if (!cur.deaf && this.data.Pass(cur))
						{
							this.Current = cur;
							return true;
						}
						return false;
					}

					// Token: 0x040015BC RID: 5564
					public global::ODBForwardEnumerator<global::VisNode> e;

					// Token: 0x040015BD RID: 5565
					public global::VisNode Current;

					// Token: 0x040015BE RID: 5566
					private bool d;

					// Token: 0x040015BF RID: 5567
					public global::VisNode.Search.PointRadiusData data;
				}

				// Token: 0x020004D5 RID: 1237
				public struct TraitMasked : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Radial.Audible.TraitMasked.Enumerator>
				{
					// Token: 0x06002B1F RID: 11039 RVA: 0x000A2C4C File Offset: 0x000A0E4C
					public TraitMasked(global::UnityEngine.Vector3 point, float radius, global::Vis.Mask mask, global::Vis.Op op)
					{
						this.point = point;
						this.radius = radius;
						this.maskComp = new global::VisNode.Search.MaskCompareData(op, mask);
					}

					// Token: 0x06002B20 RID: 11040 RVA: 0x000A2C6C File Offset: 0x000A0E6C
					global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
					{
						return this.GetEnumerator();
					}

					// Token: 0x06002B21 RID: 11041 RVA: 0x000A2C7C File Offset: 0x000A0E7C
					global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
					{
						return this.GetEnumerator();
					}

					// Token: 0x06002B22 RID: 11042 RVA: 0x000A2C8C File Offset: 0x000A0E8C
					public global::VisNode.Search.Radial.Audible.TraitMasked.Enumerator GetEnumerator()
					{
						return new global::VisNode.Search.Radial.Audible.TraitMasked.Enumerator(new global::VisNode.Search.PointRadiusData(this.point, this.radius), this.maskComp);
					}

					// Token: 0x040015C0 RID: 5568
					public global::UnityEngine.Vector3 point;

					// Token: 0x040015C1 RID: 5569
					public float radius;

					// Token: 0x040015C2 RID: 5570
					public global::VisNode.Search.MaskCompareData maskComp;

					// Token: 0x020004D6 RID: 1238
					public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
					{
						// Token: 0x06002B23 RID: 11043 RVA: 0x000A2CAC File Offset: 0x000A0EAC
						public Enumerator(global::VisNode.Search.PointRadiusData pr, global::VisNode.Search.MaskCompareData mc)
						{
							this.Current = null;
							this.d = false;
							this.e = global::VisNode.db.GetEnumerator();
							this.data = pr;
							this.traitComp = mc;
						}

						// Token: 0x1700097E RID: 2430
						// (get) Token: 0x06002B24 RID: 11044 RVA: 0x000A2CE8 File Offset: 0x000A0EE8
						global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
						{
							get
							{
								return this.Current;
							}
						}

						// Token: 0x1700097F RID: 2431
						// (get) Token: 0x06002B25 RID: 11045 RVA: 0x000A2CF0 File Offset: 0x000A0EF0
						object global::System.Collections.IEnumerator.Current
						{
							get
							{
								return this.Current;
							}
						}

						// Token: 0x06002B26 RID: 11046 RVA: 0x000A2CF8 File Offset: 0x000A0EF8
						public bool MoveNext()
						{
							while (this.e.MoveNext())
							{
								if (this.Pass(this.e.Current))
								{
									return true;
								}
							}
							this.Current = null;
							return false;
						}

						// Token: 0x06002B27 RID: 11047 RVA: 0x000A2D30 File Offset: 0x000A0F30
						public void Dispose()
						{
							if (!this.d)
							{
								this.e.Dispose();
								this.d = true;
							}
						}

						// Token: 0x06002B28 RID: 11048 RVA: 0x000A2D50 File Offset: 0x000A0F50
						public void Reset()
						{
							this.Dispose();
							this.d = false;
							this.e = global::VisNode.db.GetEnumerator();
						}

						// Token: 0x06002B29 RID: 11049 RVA: 0x000A2D70 File Offset: 0x000A0F70
						private bool Pass(global::VisNode cur)
						{
							if (!cur.deaf && this.traitComp.Pass(cur._traitMask) && this.data.Pass(cur))
							{
								this.Current = cur;
								return true;
							}
							return false;
						}

						// Token: 0x040015C3 RID: 5571
						public global::ODBForwardEnumerator<global::VisNode> e;

						// Token: 0x040015C4 RID: 5572
						public global::VisNode Current;

						// Token: 0x040015C5 RID: 5573
						private bool d;

						// Token: 0x040015C6 RID: 5574
						public global::VisNode.Search.PointRadiusData data;

						// Token: 0x040015C7 RID: 5575
						public global::VisNode.Search.MaskCompareData traitComp;
					}
				}

				// Token: 0x020004D7 RID: 1239
				public struct SightMasked : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Radial.Audible.SightMasked.Enumerator>
				{
					// Token: 0x06002B2A RID: 11050 RVA: 0x000A2DBC File Offset: 0x000A0FBC
					public SightMasked(global::UnityEngine.Vector3 point, float radius, global::Vis.Mask mask, global::Vis.Op op)
					{
						this.point = point;
						this.radius = radius;
						this.maskComp = new global::VisNode.Search.MaskCompareData(op, mask);
					}

					// Token: 0x06002B2B RID: 11051 RVA: 0x000A2DDC File Offset: 0x000A0FDC
					global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
					{
						return this.GetEnumerator();
					}

					// Token: 0x06002B2C RID: 11052 RVA: 0x000A2DEC File Offset: 0x000A0FEC
					global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
					{
						return this.GetEnumerator();
					}

					// Token: 0x06002B2D RID: 11053 RVA: 0x000A2DFC File Offset: 0x000A0FFC
					public global::VisNode.Search.Radial.Audible.SightMasked.Enumerator GetEnumerator()
					{
						return new global::VisNode.Search.Radial.Audible.SightMasked.Enumerator(new global::VisNode.Search.PointRadiusData(this.point, this.radius), this.maskComp);
					}

					// Token: 0x040015C8 RID: 5576
					public global::UnityEngine.Vector3 point;

					// Token: 0x040015C9 RID: 5577
					public float radius;

					// Token: 0x040015CA RID: 5578
					public global::VisNode.Search.MaskCompareData maskComp;

					// Token: 0x020004D8 RID: 1240
					public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
					{
						// Token: 0x06002B2E RID: 11054 RVA: 0x000A2E1C File Offset: 0x000A101C
						public Enumerator(global::VisNode.Search.PointRadiusData pr, global::VisNode.Search.MaskCompareData mc)
						{
							this.Current = null;
							this.d = false;
							this.e = global::VisNode.db.GetEnumerator();
							this.data = pr;
							this.viewComp = mc;
						}

						// Token: 0x17000980 RID: 2432
						// (get) Token: 0x06002B2F RID: 11055 RVA: 0x000A2E58 File Offset: 0x000A1058
						global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
						{
							get
							{
								return this.Current;
							}
						}

						// Token: 0x17000981 RID: 2433
						// (get) Token: 0x06002B30 RID: 11056 RVA: 0x000A2E60 File Offset: 0x000A1060
						object global::System.Collections.IEnumerator.Current
						{
							get
							{
								return this.Current;
							}
						}

						// Token: 0x06002B31 RID: 11057 RVA: 0x000A2E68 File Offset: 0x000A1068
						public bool MoveNext()
						{
							while (this.e.MoveNext())
							{
								if (this.Pass(this.e.Current))
								{
									return true;
								}
							}
							this.Current = null;
							return false;
						}

						// Token: 0x06002B32 RID: 11058 RVA: 0x000A2EA0 File Offset: 0x000A10A0
						public void Dispose()
						{
							if (!this.d)
							{
								this.e.Dispose();
								this.d = true;
							}
						}

						// Token: 0x06002B33 RID: 11059 RVA: 0x000A2EC0 File Offset: 0x000A10C0
						public void Reset()
						{
							this.Dispose();
							this.d = false;
							this.e = global::VisNode.db.GetEnumerator();
						}

						// Token: 0x06002B34 RID: 11060 RVA: 0x000A2EE0 File Offset: 0x000A10E0
						private bool Pass(global::VisNode cur)
						{
							if (!cur.deaf && this.viewComp.Pass(cur._sightMask) && this.data.Pass(cur))
							{
								this.Current = cur;
								return true;
							}
							return false;
						}

						// Token: 0x040015CB RID: 5579
						public global::ODBForwardEnumerator<global::VisNode> e;

						// Token: 0x040015CC RID: 5580
						public global::VisNode Current;

						// Token: 0x040015CD RID: 5581
						private bool d;

						// Token: 0x040015CE RID: 5582
						public global::VisNode.Search.PointRadiusData data;

						// Token: 0x040015CF RID: 5583
						public global::VisNode.Search.MaskCompareData viewComp;
					}
				}
			}
		}

		// Token: 0x020004D9 RID: 1241
		public struct Point : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Point.Enumerator>
		{
			// Token: 0x06002B35 RID: 11061 RVA: 0x000A2F2C File Offset: 0x000A112C
			public Point(global::UnityEngine.Vector3 point)
			{
				this.point = point;
			}

			// Token: 0x06002B36 RID: 11062 RVA: 0x000A2F38 File Offset: 0x000A1138
			global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06002B37 RID: 11063 RVA: 0x000A2F48 File Offset: 0x000A1148
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x06002B38 RID: 11064 RVA: 0x000A2F58 File Offset: 0x000A1158
			public global::VisNode.Search.Point.Enumerator GetEnumerator()
			{
				return new global::VisNode.Search.Point.Enumerator(new global::VisNode.Search.PointVisibilityData(this.point));
			}

			// Token: 0x040015D0 RID: 5584
			public global::UnityEngine.Vector3 point;

			// Token: 0x020004DA RID: 1242
			public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
			{
				// Token: 0x06002B39 RID: 11065 RVA: 0x000A2F6C File Offset: 0x000A116C
				public Enumerator(global::VisNode.Search.PointVisibilityData pv)
				{
					this.Current = null;
					this.d = false;
					this.e = global::VisNode.db.GetEnumerator();
					this.data = pv;
				}

				// Token: 0x17000982 RID: 2434
				// (get) Token: 0x06002B3A RID: 11066 RVA: 0x000A2F94 File Offset: 0x000A1194
				global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
				{
					get
					{
						return this.Current;
					}
				}

				// Token: 0x17000983 RID: 2435
				// (get) Token: 0x06002B3B RID: 11067 RVA: 0x000A2F9C File Offset: 0x000A119C
				object global::System.Collections.IEnumerator.Current
				{
					get
					{
						return this.Current;
					}
				}

				// Token: 0x06002B3C RID: 11068 RVA: 0x000A2FA4 File Offset: 0x000A11A4
				public bool MoveNext()
				{
					while (this.e.MoveNext())
					{
						if (this.Pass(this.e.Current))
						{
							return true;
						}
					}
					this.Current = null;
					return false;
				}

				// Token: 0x06002B3D RID: 11069 RVA: 0x000A2FDC File Offset: 0x000A11DC
				public void Dispose()
				{
					if (!this.d)
					{
						this.e.Dispose();
						this.d = true;
					}
				}

				// Token: 0x06002B3E RID: 11070 RVA: 0x000A2FFC File Offset: 0x000A11FC
				public void Reset()
				{
					this.Dispose();
					this.d = false;
					this.e = global::VisNode.db.GetEnumerator();
				}

				// Token: 0x06002B3F RID: 11071 RVA: 0x000A301C File Offset: 0x000A121C
				private bool Pass(global::VisNode cur)
				{
					if (this.data.Pass(cur))
					{
						this.Current = cur;
						return true;
					}
					return false;
				}

				// Token: 0x040015D1 RID: 5585
				public global::ODBForwardEnumerator<global::VisNode> e;

				// Token: 0x040015D2 RID: 5586
				public global::VisNode Current;

				// Token: 0x040015D3 RID: 5587
				private bool d;

				// Token: 0x040015D4 RID: 5588
				public global::VisNode.Search.PointVisibilityData data;
			}

			// Token: 0x020004DB RID: 1243
			public struct TraitMasked : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Point.TraitMasked.Enumerator>
			{
				// Token: 0x06002B40 RID: 11072 RVA: 0x000A303C File Offset: 0x000A123C
				public TraitMasked(global::UnityEngine.Vector3 point, global::Vis.Mask mask, global::Vis.Op op)
				{
					this.point = point;
					this.maskComp = new global::VisNode.Search.MaskCompareData(op, mask);
				}

				// Token: 0x06002B41 RID: 11073 RVA: 0x000A3054 File Offset: 0x000A1254
				global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B42 RID: 11074 RVA: 0x000A3064 File Offset: 0x000A1264
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B43 RID: 11075 RVA: 0x000A3074 File Offset: 0x000A1274
				public global::VisNode.Search.Point.TraitMasked.Enumerator GetEnumerator()
				{
					return new global::VisNode.Search.Point.TraitMasked.Enumerator(new global::VisNode.Search.PointVisibilityData(this.point), this.maskComp);
				}

				// Token: 0x040015D5 RID: 5589
				public global::UnityEngine.Vector3 point;

				// Token: 0x040015D6 RID: 5590
				public global::VisNode.Search.MaskCompareData maskComp;

				// Token: 0x020004DC RID: 1244
				public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
				{
					// Token: 0x06002B44 RID: 11076 RVA: 0x000A308C File Offset: 0x000A128C
					public Enumerator(global::VisNode.Search.PointVisibilityData pv, global::VisNode.Search.MaskCompareData mc)
					{
						this.Current = null;
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
						this.data = pv;
						this.traitComp = mc;
					}

					// Token: 0x17000984 RID: 2436
					// (get) Token: 0x06002B45 RID: 11077 RVA: 0x000A30C8 File Offset: 0x000A12C8
					global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x17000985 RID: 2437
					// (get) Token: 0x06002B46 RID: 11078 RVA: 0x000A30D0 File Offset: 0x000A12D0
					object global::System.Collections.IEnumerator.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x06002B47 RID: 11079 RVA: 0x000A30D8 File Offset: 0x000A12D8
					public bool MoveNext()
					{
						while (this.e.MoveNext())
						{
							if (this.Pass(this.e.Current))
							{
								return true;
							}
						}
						this.Current = null;
						return false;
					}

					// Token: 0x06002B48 RID: 11080 RVA: 0x000A3110 File Offset: 0x000A1310
					public void Dispose()
					{
						if (!this.d)
						{
							this.e.Dispose();
							this.d = true;
						}
					}

					// Token: 0x06002B49 RID: 11081 RVA: 0x000A3130 File Offset: 0x000A1330
					public void Reset()
					{
						this.Dispose();
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
					}

					// Token: 0x06002B4A RID: 11082 RVA: 0x000A3150 File Offset: 0x000A1350
					private bool Pass(global::VisNode cur)
					{
						if (this.traitComp.Pass(cur._traitMask) && this.data.Pass(cur))
						{
							this.Current = cur;
							return true;
						}
						return false;
					}

					// Token: 0x040015D7 RID: 5591
					public global::ODBForwardEnumerator<global::VisNode> e;

					// Token: 0x040015D8 RID: 5592
					public global::VisNode Current;

					// Token: 0x040015D9 RID: 5593
					private bool d;

					// Token: 0x040015DA RID: 5594
					public global::VisNode.Search.PointVisibilityData data;

					// Token: 0x040015DB RID: 5595
					public global::VisNode.Search.MaskCompareData traitComp;
				}
			}

			// Token: 0x020004DD RID: 1245
			public struct SightMasked : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Point.SightMasked.Enumerator>
			{
				// Token: 0x06002B4B RID: 11083 RVA: 0x000A3184 File Offset: 0x000A1384
				public SightMasked(global::UnityEngine.Vector3 point, global::Vis.Mask mask, global::Vis.Op op)
				{
					this.point = point;
					this.maskComp = new global::VisNode.Search.MaskCompareData(op, mask);
				}

				// Token: 0x06002B4C RID: 11084 RVA: 0x000A319C File Offset: 0x000A139C
				global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B4D RID: 11085 RVA: 0x000A31AC File Offset: 0x000A13AC
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B4E RID: 11086 RVA: 0x000A31BC File Offset: 0x000A13BC
				public global::VisNode.Search.Point.SightMasked.Enumerator GetEnumerator()
				{
					return new global::VisNode.Search.Point.SightMasked.Enumerator(new global::VisNode.Search.PointVisibilityData(this.point), this.maskComp);
				}

				// Token: 0x040015DC RID: 5596
				public global::UnityEngine.Vector3 point;

				// Token: 0x040015DD RID: 5597
				public global::VisNode.Search.MaskCompareData maskComp;

				// Token: 0x020004DE RID: 1246
				public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
				{
					// Token: 0x06002B4F RID: 11087 RVA: 0x000A31D4 File Offset: 0x000A13D4
					public Enumerator(global::VisNode.Search.PointVisibilityData pv, global::VisNode.Search.MaskCompareData mc)
					{
						this.Current = null;
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
						this.data = pv;
						this.viewComp = mc;
					}

					// Token: 0x17000986 RID: 2438
					// (get) Token: 0x06002B50 RID: 11088 RVA: 0x000A3210 File Offset: 0x000A1410
					global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x17000987 RID: 2439
					// (get) Token: 0x06002B51 RID: 11089 RVA: 0x000A3218 File Offset: 0x000A1418
					object global::System.Collections.IEnumerator.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x06002B52 RID: 11090 RVA: 0x000A3220 File Offset: 0x000A1420
					public bool MoveNext()
					{
						while (this.e.MoveNext())
						{
							if (this.Pass(this.e.Current))
							{
								return true;
							}
						}
						this.Current = null;
						return false;
					}

					// Token: 0x06002B53 RID: 11091 RVA: 0x000A3258 File Offset: 0x000A1458
					public void Dispose()
					{
						if (!this.d)
						{
							this.e.Dispose();
							this.d = true;
						}
					}

					// Token: 0x06002B54 RID: 11092 RVA: 0x000A3278 File Offset: 0x000A1478
					public void Reset()
					{
						this.Dispose();
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
					}

					// Token: 0x06002B55 RID: 11093 RVA: 0x000A3298 File Offset: 0x000A1498
					private bool Pass(global::VisNode cur)
					{
						if (this.viewComp.Pass(cur._sightMask) && this.data.Pass(cur))
						{
							this.Current = cur;
							return true;
						}
						return false;
					}

					// Token: 0x040015DE RID: 5598
					public global::ODBForwardEnumerator<global::VisNode> e;

					// Token: 0x040015DF RID: 5599
					public global::VisNode Current;

					// Token: 0x040015E0 RID: 5600
					private bool d;

					// Token: 0x040015E1 RID: 5601
					public global::VisNode.Search.PointVisibilityData data;

					// Token: 0x040015E2 RID: 5602
					public global::VisNode.Search.MaskCompareData viewComp;
				}
			}

			// Token: 0x020004DF RID: 1247
			public struct Visual : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Point.Visual.Enumerator>
			{
				// Token: 0x06002B56 RID: 11094 RVA: 0x000A32CC File Offset: 0x000A14CC
				public Visual(global::UnityEngine.Vector3 point)
				{
					this.point = point;
				}

				// Token: 0x06002B57 RID: 11095 RVA: 0x000A32D8 File Offset: 0x000A14D8
				global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B58 RID: 11096 RVA: 0x000A32E8 File Offset: 0x000A14E8
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06002B59 RID: 11097 RVA: 0x000A32F8 File Offset: 0x000A14F8
				public global::VisNode.Search.Point.Visual.Enumerator GetEnumerator()
				{
					return new global::VisNode.Search.Point.Visual.Enumerator(new global::VisNode.Search.PointVisibilityData(this.point));
				}

				// Token: 0x040015E3 RID: 5603
				public global::UnityEngine.Vector3 point;

				// Token: 0x020004E0 RID: 1248
				public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
				{
					// Token: 0x06002B5A RID: 11098 RVA: 0x000A330C File Offset: 0x000A150C
					public Enumerator(global::VisNode.Search.PointVisibilityData pv)
					{
						this.Current = null;
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
						this.data = pv;
					}

					// Token: 0x17000988 RID: 2440
					// (get) Token: 0x06002B5B RID: 11099 RVA: 0x000A3334 File Offset: 0x000A1534
					global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x17000989 RID: 2441
					// (get) Token: 0x06002B5C RID: 11100 RVA: 0x000A333C File Offset: 0x000A153C
					object global::System.Collections.IEnumerator.Current
					{
						get
						{
							return this.Current;
						}
					}

					// Token: 0x06002B5D RID: 11101 RVA: 0x000A3344 File Offset: 0x000A1544
					public bool MoveNext()
					{
						while (this.e.MoveNext())
						{
							if (this.Pass(this.e.Current))
							{
								return true;
							}
						}
						this.Current = null;
						return false;
					}

					// Token: 0x06002B5E RID: 11102 RVA: 0x000A337C File Offset: 0x000A157C
					public void Dispose()
					{
						if (!this.d)
						{
							this.e.Dispose();
							this.d = true;
						}
					}

					// Token: 0x06002B5F RID: 11103 RVA: 0x000A339C File Offset: 0x000A159C
					public void Reset()
					{
						this.Dispose();
						this.d = false;
						this.e = global::VisNode.db.GetEnumerator();
					}

					// Token: 0x06002B60 RID: 11104 RVA: 0x000A33BC File Offset: 0x000A15BC
					private bool Pass(global::VisNode cur)
					{
						return false;
					}

					// Token: 0x040015E4 RID: 5604
					public global::ODBForwardEnumerator<global::VisNode> e;

					// Token: 0x040015E5 RID: 5605
					public global::VisNode Current;

					// Token: 0x040015E6 RID: 5606
					private bool d;

					// Token: 0x040015E7 RID: 5607
					public global::VisNode.Search.PointVisibilityData data;
				}

				// Token: 0x020004E1 RID: 1249
				public struct TraitMasked : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Point.Visual.TraitMasked.Enumerator>
				{
					// Token: 0x06002B61 RID: 11105 RVA: 0x000A33C0 File Offset: 0x000A15C0
					public TraitMasked(global::UnityEngine.Vector3 point, global::Vis.Mask mask, global::Vis.Op op)
					{
						this.point = point;
						this.maskComp = new global::VisNode.Search.MaskCompareData(op, mask);
					}

					// Token: 0x06002B62 RID: 11106 RVA: 0x000A33D8 File Offset: 0x000A15D8
					global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
					{
						return this.GetEnumerator();
					}

					// Token: 0x06002B63 RID: 11107 RVA: 0x000A33E8 File Offset: 0x000A15E8
					global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
					{
						return this.GetEnumerator();
					}

					// Token: 0x06002B64 RID: 11108 RVA: 0x000A33F8 File Offset: 0x000A15F8
					public global::VisNode.Search.Point.Visual.TraitMasked.Enumerator GetEnumerator()
					{
						return new global::VisNode.Search.Point.Visual.TraitMasked.Enumerator(new global::VisNode.Search.PointVisibilityData(this.point), this.maskComp);
					}

					// Token: 0x040015E8 RID: 5608
					public global::UnityEngine.Vector3 point;

					// Token: 0x040015E9 RID: 5609
					public global::VisNode.Search.MaskCompareData maskComp;

					// Token: 0x020004E2 RID: 1250
					public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
					{
						// Token: 0x06002B65 RID: 11109 RVA: 0x000A3410 File Offset: 0x000A1610
						public Enumerator(global::VisNode.Search.PointVisibilityData pv, global::VisNode.Search.MaskCompareData mc)
						{
							this.Current = null;
							this.d = false;
							this.e = global::VisNode.db.GetEnumerator();
							this.data = pv;
							this.traitComp = mc;
						}

						// Token: 0x1700098A RID: 2442
						// (get) Token: 0x06002B66 RID: 11110 RVA: 0x000A344C File Offset: 0x000A164C
						global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
						{
							get
							{
								return this.Current;
							}
						}

						// Token: 0x1700098B RID: 2443
						// (get) Token: 0x06002B67 RID: 11111 RVA: 0x000A3454 File Offset: 0x000A1654
						object global::System.Collections.IEnumerator.Current
						{
							get
							{
								return this.Current;
							}
						}

						// Token: 0x06002B68 RID: 11112 RVA: 0x000A345C File Offset: 0x000A165C
						public bool MoveNext()
						{
							while (this.e.MoveNext())
							{
								if (this.Pass(this.e.Current))
								{
									return true;
								}
							}
							this.Current = null;
							return false;
						}

						// Token: 0x06002B69 RID: 11113 RVA: 0x000A3494 File Offset: 0x000A1694
						public void Dispose()
						{
							if (!this.d)
							{
								this.e.Dispose();
								this.d = true;
							}
						}

						// Token: 0x06002B6A RID: 11114 RVA: 0x000A34B4 File Offset: 0x000A16B4
						public void Reset()
						{
							this.Dispose();
							this.d = false;
							this.e = global::VisNode.db.GetEnumerator();
						}

						// Token: 0x06002B6B RID: 11115 RVA: 0x000A34D4 File Offset: 0x000A16D4
						private bool Pass(global::VisNode cur)
						{
							return false;
						}

						// Token: 0x040015EA RID: 5610
						public global::ODBForwardEnumerator<global::VisNode> e;

						// Token: 0x040015EB RID: 5611
						public global::VisNode Current;

						// Token: 0x040015EC RID: 5612
						private bool d;

						// Token: 0x040015ED RID: 5613
						public global::VisNode.Search.PointVisibilityData data;

						// Token: 0x040015EE RID: 5614
						public global::VisNode.Search.MaskCompareData traitComp;
					}
				}

				// Token: 0x020004E3 RID: 1251
				public struct SightMasked : global::System.Collections.IEnumerable, global::VisNode.Search.ISearch, global::System.Collections.Generic.IEnumerable<global::VisNode>, global::VisNode.Search.ISearch<global::VisNode.Search.Point.Visual.SightMasked.Enumerator>
				{
					// Token: 0x06002B6C RID: 11116 RVA: 0x000A34D8 File Offset: 0x000A16D8
					public SightMasked(global::UnityEngine.Vector3 point, global::Vis.Mask mask, global::Vis.Op op)
					{
						this.point = point;
						this.maskComp = new global::VisNode.Search.MaskCompareData(op, mask);
					}

					// Token: 0x06002B6D RID: 11117 RVA: 0x000A34F0 File Offset: 0x000A16F0
					global::System.Collections.Generic.IEnumerator<global::VisNode> global::System.Collections.Generic.IEnumerable<global::VisNode>.GetEnumerator()
					{
						return this.GetEnumerator();
					}

					// Token: 0x06002B6E RID: 11118 RVA: 0x000A3500 File Offset: 0x000A1700
					global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
					{
						return this.GetEnumerator();
					}

					// Token: 0x06002B6F RID: 11119 RVA: 0x000A3510 File Offset: 0x000A1710
					public global::VisNode.Search.Point.Visual.SightMasked.Enumerator GetEnumerator()
					{
						return new global::VisNode.Search.Point.Visual.SightMasked.Enumerator(new global::VisNode.Search.PointVisibilityData(this.point), this.maskComp);
					}

					// Token: 0x040015EF RID: 5615
					public global::UnityEngine.Vector3 point;

					// Token: 0x040015F0 RID: 5616
					public global::VisNode.Search.MaskCompareData maskComp;

					// Token: 0x020004E4 RID: 1252
					public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::VisNode>
					{
						// Token: 0x06002B70 RID: 11120 RVA: 0x000A3528 File Offset: 0x000A1728
						public Enumerator(global::VisNode.Search.PointVisibilityData pv, global::VisNode.Search.MaskCompareData mc)
						{
							this.Current = null;
							this.d = false;
							this.e = global::VisNode.db.GetEnumerator();
							this.data = pv;
							this.viewComp = mc;
						}

						// Token: 0x1700098C RID: 2444
						// (get) Token: 0x06002B71 RID: 11121 RVA: 0x000A3564 File Offset: 0x000A1764
						global::VisNode global::System.Collections.Generic.IEnumerator<global::VisNode>.Current
						{
							get
							{
								return this.Current;
							}
						}

						// Token: 0x1700098D RID: 2445
						// (get) Token: 0x06002B72 RID: 11122 RVA: 0x000A356C File Offset: 0x000A176C
						object global::System.Collections.IEnumerator.Current
						{
							get
							{
								return this.Current;
							}
						}

						// Token: 0x06002B73 RID: 11123 RVA: 0x000A3574 File Offset: 0x000A1774
						public bool MoveNext()
						{
							while (this.e.MoveNext())
							{
								if (this.Pass(this.e.Current))
								{
									return true;
								}
							}
							this.Current = null;
							return false;
						}

						// Token: 0x06002B74 RID: 11124 RVA: 0x000A35AC File Offset: 0x000A17AC
						public void Dispose()
						{
							if (!this.d)
							{
								this.e.Dispose();
								this.d = true;
							}
						}

						// Token: 0x06002B75 RID: 11125 RVA: 0x000A35CC File Offset: 0x000A17CC
						public void Reset()
						{
							this.Dispose();
							this.d = false;
							this.e = global::VisNode.db.GetEnumerator();
						}

						// Token: 0x06002B76 RID: 11126 RVA: 0x000A35EC File Offset: 0x000A17EC
						private bool Pass(global::VisNode cur)
						{
							return false;
						}

						// Token: 0x040015F1 RID: 5617
						public global::ODBForwardEnumerator<global::VisNode> e;

						// Token: 0x040015F2 RID: 5618
						public global::VisNode Current;

						// Token: 0x040015F3 RID: 5619
						private bool d;

						// Token: 0x040015F4 RID: 5620
						public global::VisNode.Search.PointVisibilityData data;

						// Token: 0x040015F5 RID: 5621
						public global::VisNode.Search.MaskCompareData viewComp;
					}
				}
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200059D RID: 1437
[global::InterfaceDriverComponent(typeof(global::IContextRequestable), "_contextRequestable", "contextRequestable", AlwaysSaveDisabled = true, SearchRoute = (global::InterfaceSearchRoute.GameObject | global::InterfaceSearchRoute.Parents), AdditionalProperties = "renderer;meshFilter")]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshRenderer))]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshFilter))]
public class ContextSprite : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002F82 RID: 12162 RVA: 0x000B52B8 File Offset: 0x000B34B8
	public ContextSprite()
	{
	}

	// Token: 0x06002F83 RID: 12163 RVA: 0x000B52CC File Offset: 0x000B34CC
	// Note: this type is marked as 'beforefieldinit'.
	static ContextSprite()
	{
	}

	// Token: 0x17000A13 RID: 2579
	// (get) Token: 0x06002F84 RID: 12164 RVA: 0x000B52E4 File Offset: 0x000B34E4
	public static int layer
	{
		get
		{
			return global::ContextSprite.layerinfo.index;
		}
	}

	// Token: 0x17000A14 RID: 2580
	// (get) Token: 0x06002F85 RID: 12165 RVA: 0x000B52EC File Offset: 0x000B34EC
	public static int layerMask
	{
		get
		{
			return global::ContextSprite.layerinfo.mask;
		}
	}

	// Token: 0x06002F86 RID: 12166 RVA: 0x000B52F4 File Offset: 0x000B34F4
	private static bool CalculateFadeOut(ref double fade, float elapsed)
	{
		if ((double)elapsed <= 0.0)
		{
			return false;
		}
		if (fade < 0.0)
		{
			fade = 0.0;
			return true;
		}
		if (fade == 0.0)
		{
			return false;
		}
		double num = (double)elapsed / 0.15;
		if (num >= fade)
		{
			fade = 0.0;
		}
		else
		{
			fade -= num;
		}
		return true;
	}

	// Token: 0x06002F87 RID: 12167 RVA: 0x000B5370 File Offset: 0x000B3570
	private static bool CalculateFadeDim(ref double fade, float elapsed)
	{
		if (fade < 0.15)
		{
			if (global::ContextSprite.CalculateFadeIn(ref fade, elapsed))
			{
				if (fade > 0.15)
				{
					fade = 0.15;
				}
				return true;
			}
		}
		else if (fade > 0.15 && global::ContextSprite.CalculateFadeOut(ref fade, elapsed))
		{
			if (fade < 0.15)
			{
				fade = 0.15;
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002F88 RID: 12168 RVA: 0x000B53F8 File Offset: 0x000B35F8
	private static bool CalculateFadeIn(ref double fade, float elapsed)
	{
		if ((double)elapsed <= 0.0)
		{
			return false;
		}
		if (fade > 1.2)
		{
			fade = 1.2;
			return true;
		}
		if (fade == 1.2)
		{
			return false;
		}
		double num = (double)elapsed / 0.15;
		if (1.2 - fade <= num)
		{
			fade = 1.2;
		}
		else
		{
			fade += num;
		}
		return true;
	}

	// Token: 0x06002F89 RID: 12169 RVA: 0x000B547C File Offset: 0x000B367C
	private void Awake()
	{
		this.contextRequestable = this._contextRequestable;
		if (!this.contextRequestable)
		{
			if (!this.SearchForContextRequestable(out this.contextRequestable))
			{
				global::UnityEngine.Debug.LogError("Could not locate a IContextRequestable! -- destroying self.(component)", base.gameObject);
				global::UnityEngine.Object.Destroy(this);
				return;
			}
			global::UnityEngine.Debug.LogWarning("Please set the interface in inspector! had to search for it!", this.contextRequestable);
		}
		else
		{
			this._contextRequestable = null;
		}
		if ((this.requestable = (this.contextRequestable as global::IContextRequestable)) == null)
		{
			global::UnityEngine.Debug.LogError("Context Requestable is not a IContextRequestable", base.gameObject);
			global::UnityEngine.Object.Destroy(this);
			return;
		}
		if (!base.transform.IsChildOf(this.contextRequestable.transform))
		{
			global::UnityEngine.Debug.LogWarning(string.Format("Sprite for {0} is not a child of {0}.", this.contextRequestable), this);
		}
		this.requestableVisibility = (this.contextRequestable as global::IContextRequestableVisibility);
		this.requestableIsVisibility = (this.requestableVisibility != null);
		this.requestableStatus = (this.contextRequestable as global::IContextRequestableStatus);
		this.requestableHasStatus = (this.requestableStatus != null);
		this.renderer.SetPropertyBlock(this.materialProperties = new global::UnityEngine.MaterialPropertyBlock());
	}

	// Token: 0x06002F8A RID: 12170 RVA: 0x000B55B0 File Offset: 0x000B37B0
	private void UpdateMaterialProperties()
	{
		float num = global::UnityEngine.Mathf.Clamp01((float)this.fade);
		if (num != this.lastBoundFade)
		{
			this.materialProperties.Clear();
			this.materialProperties.AddFloat(global::ContextSprite.matHelper.fadeProp, num);
			this.lastBoundFade = num;
			this.renderer.SetPropertyBlock(this.materialProperties);
		}
	}

	// Token: 0x06002F8B RID: 12171 RVA: 0x000B560C File Offset: 0x000B380C
	private bool SearchForContextRequestable(out global::UnityEngine.MonoBehaviour impl)
	{
		global::Contextual contextual;
		if (global::Contextual.FindUp(base.transform, out contextual))
		{
			global::UnityEngine.MonoBehaviour implementor;
			impl = (implementor = contextual.implementor);
			if (implementor)
			{
				return true;
			}
		}
		impl = null;
		return false;
	}

	// Token: 0x06002F8C RID: 12172 RVA: 0x000B5648 File Offset: 0x000B3848
	private void Reset()
	{
		if (!this.renderer)
		{
			this.renderer = (base.renderer as global::UnityEngine.MeshRenderer);
		}
		if (!this.meshFilter)
		{
			this.meshFilter = base.GetComponent<global::UnityEngine.MeshFilter>();
		}
		if (!this._contextRequestable && !this.SearchForContextRequestable(out this._contextRequestable))
		{
			global::UnityEngine.Debug.LogWarning("Please add a script implementing IContextRequestable on this or a parent game object", this);
		}
	}

	// Token: 0x06002F8D RID: 12173 RVA: 0x000B56C0 File Offset: 0x000B38C0
	private static bool CheckRelation(global::UnityEngine.Collider collider, global::UnityEngine.Rigidbody rigidbody, global::UnityEngine.Transform self)
	{
		return collider.transform.IsChildOf(self) || self.IsChildOf(collider.transform) || (rigidbody && collider.transform != rigidbody.transform && (rigidbody.transform.IsChildOf(self) || self.IsChildOf(rigidbody.transform)));
	}

	// Token: 0x06002F8E RID: 12174 RVA: 0x000B573C File Offset: 0x000B393C
	private bool IsSeeThrough(ref global::UnityEngine.RaycastHit hit)
	{
		global::UnityEngine.Transform transform = base.transform;
		global::UnityEngine.Transform transform3;
		if (this.contextRequestable)
		{
			global::UnityEngine.Transform transform2 = this.contextRequestable.transform;
			if (transform != transform2)
			{
				if (transform.IsChildOf(transform2))
				{
					transform = transform2;
				}
				else if (!transform2.IsChildOf(transform))
				{
					transform3 = hit.collider.transform;
					return transform3 == transform2 || transform3 == transform || transform3.IsChildOf(transform) || transform3.IsChildOf(transform2);
				}
			}
		}
		transform3 = hit.collider.transform;
		return transform3 == transform || transform3.IsChildOf(transform);
	}

	// Token: 0x06002F8F RID: 12175 RVA: 0x000B57F4 File Offset: 0x000B39F4
	private void OnBecameVisible()
	{
		if (!this.selfVisible)
		{
			global::ContextSprite.g.Add(this);
			this.selfVisible = true;
			if (this.requestableIsVisibility && this.contextRequestable)
			{
				this.requestableVisibility.OnContextVisibilityChanged(this, true);
			}
		}
	}

	// Token: 0x06002F90 RID: 12176 RVA: 0x000B5844 File Offset: 0x000B3A44
	private global::System.Collections.IEnumerator Retry()
	{
		this.renderer.enabled = false;
		yield return global::ContextSprite.r.wait;
		this.renderer.enabled = true;
		yield break;
	}

	// Token: 0x06002F91 RID: 12177 RVA: 0x000B5860 File Offset: 0x000B3A60
	private void OnBecameInvisible()
	{
		if (this.selfVisible)
		{
			this.selfVisible = false;
			global::ContextSprite.g.Remove(this);
			if (this.requestableIsVisibility && this.contextRequestable)
			{
				this.requestableVisibility.OnContextVisibilityChanged(this, false);
			}
		}
		else if (this.denied)
		{
			this.denied = false;
		}
	}

	// Token: 0x06002F92 RID: 12178 RVA: 0x000B58C4 File Offset: 0x000B3AC4
	private void OnDestroy()
	{
		try
		{
			this.OnBecameInvisible();
		}
		finally
		{
			this.contextRequestable = null;
			this.requestable = null;
			this.requestableVisibility = null;
			this.requestableIsVisibility = false;
			this.requestableStatus = null;
			this.requestableHasStatus = false;
		}
	}

	// Token: 0x06002F93 RID: 12179 RVA: 0x000B5924 File Offset: 0x000B3B24
	public static bool Raycast(global::UnityEngine.Ray ray, out global::ContextSprite sprite)
	{
		bool result = false;
		sprite = null;
		float num = float.PositiveInfinity;
		foreach (global::ContextSprite contextSprite in global::ContextSprite.g.visible)
		{
			if (contextSprite.contextRequestable)
			{
				global::UnityEngine.Collider collider = contextSprite.contextRequestable.collider;
				if (!collider)
				{
					collider = contextSprite.collider;
				}
				if (collider)
				{
					if (!collider.enabled)
					{
						continue;
					}
					global::UnityEngine.RaycastHit raycastHit;
					if (contextSprite.collider.Raycast(ray, ref raycastHit, 5f))
					{
						float num2 = raycastHit.distance;
						num2 *= num2;
						if (num2 < num)
						{
							result = true;
							num = num2;
							sprite = contextSprite;
						}
					}
				}
				float num3;
				if (contextSprite.renderer.bounds.IntersectRay(ray, ref num3))
				{
					num3 *= num3;
					if (num3 < num)
					{
						result = true;
						num = num3;
						sprite = contextSprite;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x17000A15 RID: 2581
	// (get) Token: 0x06002F94 RID: 12180 RVA: 0x000B5A54 File Offset: 0x000B3C54
	public static global::ContextSprite.VisibleList AllVisible
	{
		get
		{
			return global::ContextSprite.visibleList;
		}
	}

	// Token: 0x06002F95 RID: 12181 RVA: 0x000B5A5C File Offset: 0x000B3C5C
	public static global::System.Collections.Generic.IEnumerable<global::ContextSprite> AllVisibleForRequestable(global::IContextRequestableVisibility requestable)
	{
		global::UnityEngine.MonoBehaviour monoBehaviour;
		if (global::ContextSprite.g.visible.Count == 0 || !(monoBehaviour = (requestable as global::UnityEngine.MonoBehaviour)))
		{
			return global::ContextSprite.empty;
		}
		return global::ContextSprite.AllVisibleForRequestable(monoBehaviour);
	}

	// Token: 0x06002F96 RID: 12182 RVA: 0x000B5A98 File Offset: 0x000B3C98
	private static global::System.Collections.Generic.IEnumerable<global::ContextSprite> AllVisibleForRequestable(global::UnityEngine.MonoBehaviour requestable)
	{
		foreach (global::ContextSprite sprite in global::ContextSprite.g.visible)
		{
			if (sprite.contextRequestable == requestable)
			{
				yield return sprite;
			}
		}
		yield break;
	}

	// Token: 0x06002F97 RID: 12183 RVA: 0x000B5AC4 File Offset: 0x000B3CC4
	public static bool FindSprite(global::UnityEngine.Component component, out global::ContextSprite sprite)
	{
		if (component is global::ContextSprite)
		{
			sprite = (global::ContextSprite)component;
			return true;
		}
		if (component is global::IContextRequestable)
		{
			sprite = component.GetComponentInChildren<global::ContextSprite>();
			return sprite && ((!sprite.contextRequestable) ? sprite._contextRequestable : sprite.contextRequestable) == component;
		}
		sprite = component.GetComponentInChildren<global::ContextSprite>();
		return sprite;
	}

	// Token: 0x04001972 RID: 6514
	private const double kFadeInRate = 8.0;

	// Token: 0x04001973 RID: 6515
	private const double kFadeOutRate = 8.0;

	// Token: 0x04001974 RID: 6516
	private const double kMinFade = 0.0;

	// Token: 0x04001975 RID: 6517
	private const double kMaxFade = 1.2;

	// Token: 0x04001976 RID: 6518
	private const double kGhostFade = 0.15;

	// Token: 0x04001977 RID: 6519
	private const double kFadeDurationInFull = 0.15;

	// Token: 0x04001978 RID: 6520
	private const double kFadeDurationOutFull = 0.15;

	// Token: 0x04001979 RID: 6521
	private const float kRayDistance = 5f;

	// Token: 0x0400197A RID: 6522
	private static bool gInit;

	// Token: 0x0400197B RID: 6523
	private float timeRemoved;

	// Token: 0x0400197C RID: 6524
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.MonoBehaviour _contextRequestable;

	// Token: 0x0400197D RID: 6525
	private global::UnityEngine.MonoBehaviour contextRequestable;

	// Token: 0x0400197E RID: 6526
	[global::PrefetchComponent]
	public global::UnityEngine.MeshFilter meshFilter;

	// Token: 0x0400197F RID: 6527
	[global::PrefetchComponent]
	public global::UnityEngine.MeshRenderer renderer;

	// Token: 0x04001980 RID: 6528
	private global::IContextRequestable requestable;

	// Token: 0x04001981 RID: 6529
	private global::IContextRequestableVisibility requestableVisibility;

	// Token: 0x04001982 RID: 6530
	private global::IContextRequestableStatus requestableStatus;

	// Token: 0x04001983 RID: 6531
	private bool requestableIsVisibility;

	// Token: 0x04001984 RID: 6532
	private bool requestableHasStatus;

	// Token: 0x04001985 RID: 6533
	private bool selfVisible;

	// Token: 0x04001986 RID: 6534
	private bool denied;

	// Token: 0x04001987 RID: 6535
	private double fade;

	// Token: 0x04001988 RID: 6536
	private global::UnityEngine.MaterialPropertyBlock materialProperties;

	// Token: 0x04001989 RID: 6537
	private float lastBoundFade = float.NegativeInfinity;

	// Token: 0x0400198A RID: 6538
	private static readonly global::ContextSprite.VisibleList visibleList = new global::ContextSprite.VisibleList();

	// Token: 0x0400198B RID: 6539
	private static global::ContextSprite[] empty = new global::ContextSprite[0];

	// Token: 0x0200059E RID: 1438
	private static class layerinfo
	{
		// Token: 0x06002F98 RID: 12184 RVA: 0x000B5B48 File Offset: 0x000B3D48
		static layerinfo()
		{
		}

		// Token: 0x0400198C RID: 6540
		public static readonly int index = global::UnityEngine.LayerMask.NameToLayer("Sprite");

		// Token: 0x0400198D RID: 6541
		public static readonly int mask = 1 << global::ContextSprite.layerinfo.index;
	}

	// Token: 0x0200059F RID: 1439
	private static class g
	{
		// Token: 0x06002F99 RID: 12185 RVA: 0x000B5B68 File Offset: 0x000B3D68
		static g()
		{
			global::ContextSprite.gInit = true;
		}

		// Token: 0x06002F9A RID: 12186 RVA: 0x000B5B9C File Offset: 0x000B3D9C
		public static void Add(global::ContextSprite sprite)
		{
			global::ContextSprite.g.visible.Add(sprite);
			global::ContextSprite.g.count++;
			global::System.Collections.Generic.HashSet<global::ContextSprite> hashSet;
			if (!global::ContextSprite.g.requestableVisibleSprites.TryGetValue(sprite.contextRequestable, out hashSet))
			{
				hashSet = ((global::ContextSprite.g.hashRecycle.Count <= 0) ? new global::System.Collections.Generic.HashSet<global::ContextSprite>() : global::ContextSprite.g.hashRecycle.Dequeue());
				global::ContextSprite.g.requestableVisibleSprites[sprite.contextRequestable] = hashSet;
			}
			hashSet.Add(sprite);
			if (global::ContextSprite.CalculateFadeOut(ref sprite.fade, global::UnityEngine.Time.time - sprite.timeRemoved))
			{
				sprite.UpdateMaterialProperties();
			}
		}

		// Token: 0x06002F9B RID: 12187 RVA: 0x000B5C38 File Offset: 0x000B3E38
		private static bool PhysRaycast(ref global::UnityEngine.Ray ray, out global::UnityEngine.RaycastHit hit, float distanceTo, int layerMask)
		{
			if (global::UnityEngine.Physics.Raycast(ray, ref hit, distanceTo, layerMask))
			{
				global::UnityEngine.Debug.DrawLine(ray.origin, ray.GetPoint(hit.distance), global::UnityEngine.Color.green);
				global::UnityEngine.Debug.DrawLine(ray.GetPoint(hit.distance), ray.GetPoint(distanceTo), global::UnityEngine.Color.red);
				return true;
			}
			return false;
		}

		// Token: 0x06002F9C RID: 12188 RVA: 0x000B5C94 File Offset: 0x000B3E94
		public static void Remove(global::ContextSprite sprite)
		{
			global::ContextSprite.g.visible.Remove(sprite);
			global::ContextSprite.g.count--;
			global::System.Collections.Generic.HashSet<global::ContextSprite> hashSet;
			if (global::ContextSprite.g.requestableVisibleSprites.TryGetValue(sprite.contextRequestable, out hashSet))
			{
				if (hashSet.Count == 1)
				{
					hashSet.Clear();
					if (global::ContextSprite.g.hashRecycle.Count < 5)
					{
						global::ContextSprite.g.hashRecycle.Enqueue(hashSet);
					}
					global::ContextSprite.g.requestableVisibleSprites.Remove(sprite.contextRequestable);
				}
				else
				{
					hashSet.Remove(sprite);
				}
			}
			sprite.timeRemoved = global::UnityEngine.Time.time;
		}

		// Token: 0x0400198E RID: 6542
		private const int kMaxRecycleCount = 5;

		// Token: 0x0400198F RID: 6543
		public static global::System.Collections.Generic.HashSet<global::ContextSprite> visible = new global::System.Collections.Generic.HashSet<global::ContextSprite>();

		// Token: 0x04001990 RID: 6544
		public static global::System.Collections.Generic.Queue<global::System.Collections.Generic.HashSet<global::ContextSprite>> hashRecycle = new global::System.Collections.Generic.Queue<global::System.Collections.Generic.HashSet<global::ContextSprite>>();

		// Token: 0x04001991 RID: 6545
		public static global::System.Collections.Generic.Dictionary<global::UnityEngine.MonoBehaviour, global::System.Collections.Generic.HashSet<global::ContextSprite>> requestableVisibleSprites = new global::System.Collections.Generic.Dictionary<global::UnityEngine.MonoBehaviour, global::System.Collections.Generic.HashSet<global::ContextSprite>>();

		// Token: 0x04001992 RID: 6546
		private static int count;
	}

	// Token: 0x020005A0 RID: 1440
	private static class matHelper
	{
		// Token: 0x06002F9D RID: 12189 RVA: 0x000B5D28 File Offset: 0x000B3F28
		// Note: this type is marked as 'beforefieldinit'.
		static matHelper()
		{
		}

		// Token: 0x04001993 RID: 6547
		public static int fadeProp = global::UnityEngine.Shader.PropertyToID("_Fade");
	}

	// Token: 0x020005A1 RID: 1441
	private static class r
	{
		// Token: 0x06002F9E RID: 12190 RVA: 0x000B5D3C File Offset: 0x000B3F3C
		// Note: this type is marked as 'beforefieldinit'.
		static r()
		{
		}

		// Token: 0x04001994 RID: 6548
		public static global::UnityEngine.WaitForEndOfFrame wait = new global::UnityEngine.WaitForEndOfFrame();
	}

	// Token: 0x020005A2 RID: 1442
	public sealed class VisibleList : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ContextSprite>
	{
		// Token: 0x06002F9F RID: 12191 RVA: 0x000B5D48 File Offset: 0x000B3F48
		internal VisibleList()
		{
		}

		// Token: 0x06002FA0 RID: 12192 RVA: 0x000B5D50 File Offset: 0x000B3F50
		global::System.Collections.Generic.IEnumerator<global::ContextSprite> global::System.Collections.Generic.IEnumerable<global::ContextSprite>.GetEnumerator()
		{
			return ((global::System.Collections.Generic.IEnumerable<global::ContextSprite>)global::ContextSprite.g.visible).GetEnumerator();
		}

		// Token: 0x06002FA1 RID: 12193 RVA: 0x000B5D5C File Offset: 0x000B3F5C
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return ((global::System.Collections.IEnumerable)global::ContextSprite.g.visible).GetEnumerator();
		}

		// Token: 0x17000A16 RID: 2582
		// (get) Token: 0x06002FA2 RID: 12194 RVA: 0x000B5D68 File Offset: 0x000B3F68
		public int Count
		{
			get
			{
				return global::ContextSprite.g.visible.Count;
			}
		}

		// Token: 0x06002FA3 RID: 12195 RVA: 0x000B5D74 File Offset: 0x000B3F74
		public bool Contains(global::ContextSprite sprite)
		{
			return sprite && sprite.selfVisible && global::ContextSprite.g.visible.Contains(sprite);
		}

		// Token: 0x06002FA4 RID: 12196 RVA: 0x000B5DA8 File Offset: 0x000B3FA8
		public global::System.Collections.Generic.HashSet<global::ContextSprite>.Enumerator GetEnumerator()
		{
			return global::ContextSprite.g.visible.GetEnumerator();
		}
	}

	// Token: 0x020005A3 RID: 1443
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Retry>c__Iterator41 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06002FA5 RID: 12197 RVA: 0x000B5DB4 File Offset: 0x000B3FB4
		public <Retry>c__Iterator41()
		{
		}

		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x06002FA6 RID: 12198 RVA: 0x000B5DBC File Offset: 0x000B3FBC
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x06002FA7 RID: 12199 RVA: 0x000B5DC4 File Offset: 0x000B3FC4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002FA8 RID: 12200 RVA: 0x000B5DCC File Offset: 0x000B3FCC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.renderer.enabled = false;
				this.$current = global::ContextSprite.r.wait;
				this.$PC = 1;
				return true;
			case 1U:
				this.renderer.enabled = true;
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06002FA9 RID: 12201 RVA: 0x000B5E40 File Offset: 0x000B4040
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06002FAA RID: 12202 RVA: 0x000B5E4C File Offset: 0x000B404C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001995 RID: 6549
		internal int $PC;

		// Token: 0x04001996 RID: 6550
		internal object $current;

		// Token: 0x04001997 RID: 6551
		internal global::ContextSprite <>f__this;
	}

	// Token: 0x020005A4 RID: 1444
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <AllVisibleForRequestable>c__Iterator42 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ContextSprite>, global::System.Collections.Generic.IEnumerator<global::ContextSprite>
	{
		// Token: 0x06002FAB RID: 12203 RVA: 0x000B5E54 File Offset: 0x000B4054
		public <AllVisibleForRequestable>c__Iterator42()
		{
		}

		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x06002FAC RID: 12204 RVA: 0x000B5E5C File Offset: 0x000B405C
		global::ContextSprite global::System.Collections.Generic.IEnumerator<global::ContextSprite>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x06002FAD RID: 12205 RVA: 0x000B5E64 File Offset: 0x000B4064
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002FAE RID: 12206 RVA: 0x000B5E6C File Offset: 0x000B406C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<ContextSprite>.GetEnumerator();
		}

		// Token: 0x06002FAF RID: 12207 RVA: 0x000B5E74 File Offset: 0x000B4074
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::ContextSprite> global::System.Collections.Generic.IEnumerable<global::ContextSprite>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::ContextSprite.<AllVisibleForRequestable>c__Iterator42 <AllVisibleForRequestable>c__Iterator = new global::ContextSprite.<AllVisibleForRequestable>c__Iterator42();
			<AllVisibleForRequestable>c__Iterator.requestable = requestable;
			return <AllVisibleForRequestable>c__Iterator;
		}

		// Token: 0x06002FB0 RID: 12208 RVA: 0x000B5EA8 File Offset: 0x000B40A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = global::ContextSprite.g.visible.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					sprite = enumerator.Current;
					if (sprite.contextRequestable == requestable)
					{
						this.$current = sprite;
						this.$PC = 1;
						flag = true;
						return true;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06002FB1 RID: 12209 RVA: 0x000B5F94 File Offset: 0x000B4194
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06002FB2 RID: 12210 RVA: 0x000B5FF4 File Offset: 0x000B41F4
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001998 RID: 6552
		internal global::System.Collections.Generic.HashSet<global::ContextSprite>.Enumerator <$s_437>__0;

		// Token: 0x04001999 RID: 6553
		internal global::ContextSprite <sprite>__1;

		// Token: 0x0400199A RID: 6554
		internal global::UnityEngine.MonoBehaviour requestable;

		// Token: 0x0400199B RID: 6555
		internal int $PC;

		// Token: 0x0400199C RID: 6556
		internal global::ContextSprite $current;

		// Token: 0x0400199D RID: 6557
		internal global::UnityEngine.MonoBehaviour <$>requestable;
	}
}

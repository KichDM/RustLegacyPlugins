using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Facepunch.Progress;
using UnityEngine;

// Token: 0x02000065 RID: 101
public sealed class TreeUnpack : global::ThrottledTask, global::Facepunch.Progress.IProgress
{
	// Token: 0x060002D1 RID: 721 RVA: 0x0000E3EC File Offset: 0x0000C5EC
	public TreeUnpack()
	{
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x0000E3F4 File Offset: 0x0000C5F4
	private new void Awake()
	{
		base.Awake();
		base.StartCoroutine("DoUnpack");
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x060002D3 RID: 723 RVA: 0x0000E408 File Offset: 0x0000C608
	public float progress
	{
		get
		{
			return (this.totalTrees <= 0) ? 1f : ((float)this.currentTreeIndex / (float)this.totalTrees);
		}
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0000E430 File Offset: 0x0000C630
	private global::System.Collections.IEnumerator DoUnpack()
	{
		this.totalTrees = 0;
		this.currentTreeIndex = 0;
		foreach (global::TreeUnpackGroup grp in this.unpackGroups)
		{
			this.totalTrees += grp.meshes.Length;
		}
		base.Working = true;
		this.groupEnumerator = ((global::System.Collections.Generic.IEnumerable<global::TreeUnpackGroup>)this.unpackGroups).GetEnumerator();
		global::ThrottledTask.Timer timer = base.Begin;
		while (this.MoveNext())
		{
			global::UnityEngine.GameObject col = new global::UnityEngine.GameObject(string.Empty, new global::System.Type[]
			{
				typeof(global::UnityEngine.MeshCollider)
			})
			{
				hideFlags = 9,
				tag = this.currentGroup.tag,
				layer = ((this.currentGroup.layer != 0) ? this.currentGroup.layer : 0xA)
			};
			global::UnityEngine.MeshCollider mc = (global::UnityEngine.MeshCollider)col.collider;
			mc.smoothSphereCollisions = this.currentGroup.spherical;
			mc.sharedMesh = this.currentMesh;
			if (!timer.Continue)
			{
				yield return new global::UnityEngine.WaitForEndOfFrame();
				timer = base.Begin;
			}
		}
		base.Working = false;
		global::UnityEngine.Object.Destroy(this);
		yield break;
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x0000E44C File Offset: 0x0000C64C
	private bool MoveNext()
	{
		if (this.meshEnumerator != null)
		{
			while (this.meshEnumerator.MoveNext())
			{
				this.currentTreeIndex++;
				this.currentMesh = this.meshEnumerator.Current;
				if (this.currentMesh)
				{
					return true;
				}
			}
		}
		if (this.groupEnumerator.MoveNext())
		{
			this.currentGroup = this.groupEnumerator.Current;
			this.meshEnumerator = this.currentGroup.meshes.GetEnumerator();
			return this.MoveNext();
		}
		return false;
	}

	// Token: 0x040001F3 RID: 499
	[global::UnityEngine.SerializeField]
	private global::TreeUnpackGroup[] unpackGroups;

	// Token: 0x040001F4 RID: 500
	private global::System.Collections.Generic.IEnumerator<global::UnityEngine.Mesh> meshEnumerator;

	// Token: 0x040001F5 RID: 501
	private global::System.Collections.Generic.IEnumerator<global::TreeUnpackGroup> groupEnumerator;

	// Token: 0x040001F6 RID: 502
	private global::TreeUnpackGroup currentGroup;

	// Token: 0x040001F7 RID: 503
	private global::UnityEngine.Mesh currentMesh;

	// Token: 0x040001F8 RID: 504
	[global::System.NonSerialized]
	private int totalTrees;

	// Token: 0x040001F9 RID: 505
	[global::System.NonSerialized]
	private int currentTreeIndex;

	// Token: 0x02000066 RID: 102
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoUnpack>c__IteratorE : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x060002D6 RID: 726 RVA: 0x0000E4EC File Offset: 0x0000C6EC
		public <DoUnpack>c__IteratorE()
		{
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x0000E4F4 File Offset: 0x0000C6F4
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000E4FC File Offset: 0x0000C6FC
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000E504 File Offset: 0x0000C704
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.totalTrees = 0;
				this.currentTreeIndex = 0;
				array = this.unpackGroups;
				for (i = 0; i < array.Length; i++)
				{
					grp = array[i];
					this.totalTrees += grp.meshes.Length;
				}
				base.Working = true;
				this.groupEnumerator = ((global::System.Collections.Generic.IEnumerable<global::TreeUnpackGroup>)this.unpackGroups).GetEnumerator();
				timer = base.Begin;
				break;
			case 1U:
				timer = base.Begin;
				break;
			default:
				return false;
			}
			while (base.MoveNext())
			{
				col = new global::UnityEngine.GameObject(string.Empty, new global::System.Type[]
				{
					typeof(global::UnityEngine.MeshCollider)
				})
				{
					hideFlags = 9,
					tag = this.currentGroup.tag,
					layer = ((this.currentGroup.layer != 0) ? this.currentGroup.layer : 0xA)
				};
				mc = (global::UnityEngine.MeshCollider)col.collider;
				mc.smoothSphereCollisions = this.currentGroup.spherical;
				mc.sharedMesh = this.currentMesh;
				if (!timer.Continue)
				{
					this.$current = new global::UnityEngine.WaitForEndOfFrame();
					this.$PC = 1;
					return true;
				}
			}
			base.Working = false;
			global::UnityEngine.Object.Destroy(this);
			this.$PC = -1;
			return false;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000E720 File Offset: 0x0000C920
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000E72C File Offset: 0x0000C92C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040001FA RID: 506
		internal global::TreeUnpackGroup[] <$s_107>__0;

		// Token: 0x040001FB RID: 507
		internal int <$s_108>__1;

		// Token: 0x040001FC RID: 508
		internal global::TreeUnpackGroup <grp>__2;

		// Token: 0x040001FD RID: 509
		internal global::ThrottledTask.Timer <timer>__3;

		// Token: 0x040001FE RID: 510
		internal global::UnityEngine.GameObject <col>__4;

		// Token: 0x040001FF RID: 511
		internal global::UnityEngine.MeshCollider <mc>__5;

		// Token: 0x04000200 RID: 512
		internal int $PC;

		// Token: 0x04000201 RID: 513
		internal object $current;

		// Token: 0x04000202 RID: 514
		internal global::TreeUnpack <>f__this;
	}
}

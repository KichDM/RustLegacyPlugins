using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch.Progress;
using UnityEngine;

// Token: 0x0200060F RID: 1551
public class SlowSpawn : global::ThrottledTask, global::Facepunch.Progress.IProgress
{
	// Token: 0x0600316C RID: 12652 RVA: 0x000BD8C4 File Offset: 0x000BBAC4
	public SlowSpawn()
	{
	}

	// Token: 0x17000A4D RID: 2637
	public global::SlowSpawn.InstanceParameters this[int i]
	{
		get
		{
			return new global::SlowSpawn.InstanceParameters(this, i);
		}
	}

	// Token: 0x17000A4E RID: 2638
	// (get) Token: 0x0600316E RID: 12654 RVA: 0x000BD8F4 File Offset: 0x000BBAF4
	public int Count
	{
		get
		{
			return (this.ps != null) ? this.ps.Length : 0;
		}
	}

	// Token: 0x17000A4F RID: 2639
	// (get) Token: 0x0600316F RID: 12655 RVA: 0x000BD910 File Offset: 0x000BBB10
	public int CountSpawned
	{
		get
		{
			return (!base.Working) ? ((this.iter != -1) ? this.Count : 0) : this.iter;
		}
	}

	// Token: 0x17000A50 RID: 2640
	// (get) Token: 0x06003170 RID: 12656 RVA: 0x000BD94C File Offset: 0x000BBB4C
	public float progress
	{
		get
		{
			return (!base.Working) ? ((this.iter != -1 || !base.enabled) ? 1f : 0f) : ((float)((double)this.iter / (double)this.Count));
		}
	}

	// Token: 0x06003171 RID: 12657 RVA: 0x000BD9A0 File Offset: 0x000BBBA0
	private global::System.Collections.IEnumerator Start()
	{
		if (!base.Working && ++this.iter < (this.iter_end = this.Count))
		{
			base.Working = true;
			for (;;)
			{
				global::ThrottledTask.Timer timer = base.Begin;
				do
				{
					try
					{
						this[this.iter].Spawn(this.runtimeLoad, 9);
					}
					catch (global::System.Exception ex)
					{
						global::System.Exception e = ex;
						global::UnityEngine.Debug.LogException(e, this);
					}
					if (++this.iter >= this.iter_end)
					{
						goto IL_FC;
					}
				}
				while (timer.Continue);
				yield return null;
			}
			IL_FC:
			base.Working = false;
			yield break;
		}
		yield break;
	}

	// Token: 0x06003172 RID: 12658 RVA: 0x000BD9BC File Offset: 0x000BBBBC
	public global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject> SpawnAll(global::SlowSpawn.SpawnFlags SpawnFlags = global::SlowSpawn.SpawnFlags.Collider, global::UnityEngine.HideFlags HideFlags = 9)
	{
		int i = 0;
		while (i < this.Count)
		{
			global::UnityEngine.GameObject newSpawn;
			try
			{
				newSpawn = this[i].Spawn(SpawnFlags, HideFlags);
			}
			catch (global::System.Exception ex)
			{
				global::System.Exception e = ex;
				global::UnityEngine.Debug.LogException(e);
				goto IL_92;
			}
			goto IL_7A;
			IL_92:
			i++;
			continue;
			IL_7A:
			yield return newSpawn;
			goto IL_92;
		}
		yield break;
	}

	// Token: 0x04001B96 RID: 7062
	[global::UnityEngine.SerializeField]
	private string findSequence = "_decor_";

	// Token: 0x04001B97 RID: 7063
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Mesh[] meshes;

	// Token: 0x04001B98 RID: 7064
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material sharedMaterial;

	// Token: 0x04001B99 RID: 7065
	[global::UnityEngine.SerializeField]
	private global::SlowSpawn.SpawnFlags runtimeLoad = global::SlowSpawn.SpawnFlags.Collider;

	// Token: 0x04001B9A RID: 7066
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int[] meshIndex;

	// Token: 0x04001B9B RID: 7067
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector4[] ps;

	// Token: 0x04001B9C RID: 7068
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Quaternion[] r;

	// Token: 0x04001B9D RID: 7069
	[global::System.NonSerialized]
	private int iter = -1;

	// Token: 0x04001B9E RID: 7070
	[global::System.NonSerialized]
	private int iter_end;

	// Token: 0x02000610 RID: 1552
	[global::System.Flags]
	public enum SpawnFlags
	{
		// Token: 0x04001BA0 RID: 7072
		Collider = 1,
		// Token: 0x04001BA1 RID: 7073
		Renderer = 2,
		// Token: 0x04001BA2 RID: 7074
		MeshFilter = 4,
		// Token: 0x04001BA3 RID: 7075
		All = 7,
		// Token: 0x04001BA4 RID: 7076
		Graphics = 6
	}

	// Token: 0x02000611 RID: 1553
	public struct InstanceParameters
	{
		// Token: 0x06003173 RID: 12659 RVA: 0x000BD9FC File Offset: 0x000BBBFC
		public InstanceParameters(global::SlowSpawn SlowSpawn, int Index)
		{
			this.Index = Index;
			this.Layer = SlowSpawn.gameObject.layer;
			global::UnityEngine.Vector4 vector = SlowSpawn.ps[Index];
			this.Position.x = vector.x;
			this.Position.y = vector.y;
			this.Position.z = vector.z;
			this.Scale.x = (this.Scale.y = (this.Scale.z = vector.w));
			this.Rotation = SlowSpawn.r[Index];
			this.Mesh = SlowSpawn.meshes[SlowSpawn.meshIndex[Index]];
			this.SharedMaterial = SlowSpawn.sharedMaterial;
		}

		// Token: 0x06003174 RID: 12660 RVA: 0x000BDAD0 File Offset: 0x000BBCD0
		public global::UnityEngine.MeshCollider AddCollider(global::UnityEngine.GameObject go)
		{
			global::UnityEngine.MeshCollider meshCollider = go.AddComponent<global::UnityEngine.MeshCollider>();
			meshCollider.sharedMesh = this.Mesh;
			return meshCollider;
		}

		// Token: 0x06003175 RID: 12661 RVA: 0x000BDAF4 File Offset: 0x000BBCF4
		public global::UnityEngine.MeshRenderer AddRenderer(global::UnityEngine.GameObject go)
		{
			global::UnityEngine.MeshRenderer meshRenderer = go.AddComponent<global::UnityEngine.MeshRenderer>();
			meshRenderer.sharedMaterial = this.SharedMaterial;
			return meshRenderer;
		}

		// Token: 0x06003176 RID: 12662 RVA: 0x000BDB18 File Offset: 0x000BBD18
		public global::UnityEngine.MeshFilter AddMeshFilter(global::UnityEngine.GameObject go)
		{
			global::UnityEngine.MeshFilter meshFilter = go.AddComponent<global::UnityEngine.MeshFilter>();
			meshFilter.sharedMesh = this.Mesh;
			return meshFilter;
		}

		// Token: 0x06003177 RID: 12663 RVA: 0x000BDB3C File Offset: 0x000BBD3C
		private global::SlowSpawn.SpawnFlags AddTo(global::UnityEngine.GameObject go, global::SlowSpawn.SpawnFlags spawnFlags, bool safe)
		{
			global::SlowSpawn.SpawnFlags spawnFlags2 = (global::SlowSpawn.SpawnFlags)0;
			if ((spawnFlags & global::SlowSpawn.SpawnFlags.MeshFilter) == global::SlowSpawn.SpawnFlags.MeshFilter && (safe || !go.GetComponent<global::UnityEngine.MeshFilter>()))
			{
				spawnFlags2 |= global::SlowSpawn.SpawnFlags.MeshFilter;
				this.AddMeshFilter(go);
			}
			if ((spawnFlags & global::SlowSpawn.SpawnFlags.Renderer) == global::SlowSpawn.SpawnFlags.Renderer && (safe || !go.renderer))
			{
				spawnFlags2 |= global::SlowSpawn.SpawnFlags.Renderer;
				this.AddRenderer(go);
			}
			if ((spawnFlags & global::SlowSpawn.SpawnFlags.Collider) == global::SlowSpawn.SpawnFlags.Collider && (safe || !go.collider))
			{
				spawnFlags2 |= global::SlowSpawn.SpawnFlags.Collider;
				this.AddCollider(go);
			}
			return spawnFlags2;
		}

		// Token: 0x06003178 RID: 12664 RVA: 0x000BDBD0 File Offset: 0x000BBDD0
		public global::SlowSpawn.SpawnFlags AddTo(global::UnityEngine.GameObject go, global::SlowSpawn.SpawnFlags spawnFlags = global::SlowSpawn.SpawnFlags.Collider)
		{
			return this.AddTo(go, spawnFlags, false);
		}

		// Token: 0x06003179 RID: 12665 RVA: 0x000BDBDC File Offset: 0x000BBDDC
		public global::UnityEngine.GameObject Spawn(global::SlowSpawn.SpawnFlags spawnFlags = global::SlowSpawn.SpawnFlags.Collider, global::UnityEngine.HideFlags HideFlags = 9)
		{
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject(string.Empty)
			{
				hideFlags = HideFlags,
				layer = this.Layer,
				transform = 
				{
					position = this.Position,
					rotation = this.Rotation
				}
			};
			this.AddTo(gameObject, spawnFlags, true);
			return gameObject;
		}

		// Token: 0x04001BA5 RID: 7077
		public const global::SlowSpawn.SpawnFlags DefaultSpawnFlags = global::SlowSpawn.SpawnFlags.Collider;

		// Token: 0x04001BA6 RID: 7078
		public const global::UnityEngine.HideFlags DefaultHideFlags = 9;

		// Token: 0x04001BA7 RID: 7079
		public readonly global::UnityEngine.Vector3 Position;

		// Token: 0x04001BA8 RID: 7080
		public readonly global::UnityEngine.Vector3 Scale;

		// Token: 0x04001BA9 RID: 7081
		public readonly global::UnityEngine.Quaternion Rotation;

		// Token: 0x04001BAA RID: 7082
		public readonly global::UnityEngine.Mesh Mesh;

		// Token: 0x04001BAB RID: 7083
		public readonly global::UnityEngine.Material SharedMaterial;

		// Token: 0x04001BAC RID: 7084
		public readonly int Layer;

		// Token: 0x04001BAD RID: 7085
		public readonly int Index;
	}

	// Token: 0x02000612 RID: 1554
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Start>c__Iterator45 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x0600317A RID: 12666 RVA: 0x000BDC38 File Offset: 0x000BBE38
		public <Start>c__Iterator45()
		{
		}

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x0600317B RID: 12667 RVA: 0x000BDC40 File Offset: 0x000BBE40
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x0600317C RID: 12668 RVA: 0x000BDC48 File Offset: 0x000BBE48
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600317D RID: 12669 RVA: 0x000BDC50 File Offset: 0x000BBE50
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				if (base.Working || ++this.iter >= (this.iter_end = base.Count))
				{
					this.$PC = -1;
					return false;
				}
				base.Working = true;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			timer = base.Begin;
			for (;;)
			{
				try
				{
					base[this.iter].Spawn(this.runtimeLoad, 9);
				}
				catch (global::System.Exception ex)
				{
					e = ex;
					global::UnityEngine.Debug.LogException(e, this);
				}
				if (++this.iter >= this.iter_end)
				{
					break;
				}
				if (!timer.Continue)
				{
					goto Block_6;
				}
			}
			base.Working = false;
			return false;
			Block_6:
			this.$current = null;
			this.$PC = 1;
			return true;
		}

		// Token: 0x0600317E RID: 12670 RVA: 0x000BDDBC File Offset: 0x000BBFBC
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x0600317F RID: 12671 RVA: 0x000BDDC8 File Offset: 0x000BBFC8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001BAE RID: 7086
		internal global::ThrottledTask.Timer <timer>__0;

		// Token: 0x04001BAF RID: 7087
		internal global::System.Exception <e>__1;

		// Token: 0x04001BB0 RID: 7088
		internal int $PC;

		// Token: 0x04001BB1 RID: 7089
		internal object $current;

		// Token: 0x04001BB2 RID: 7090
		internal global::SlowSpawn <>f__this;
	}

	// Token: 0x02000613 RID: 1555
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <SpawnAll>c__Iterator46 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.GameObject>
	{
		// Token: 0x06003180 RID: 12672 RVA: 0x000BDDD0 File Offset: 0x000BBFD0
		public <SpawnAll>c__Iterator46()
		{
		}

		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06003181 RID: 12673 RVA: 0x000BDDD8 File Offset: 0x000BBFD8
		global::UnityEngine.GameObject global::System.Collections.Generic.IEnumerator<global::UnityEngine.GameObject>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06003182 RID: 12674 RVA: 0x000BDDE0 File Offset: 0x000BBFE0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003183 RID: 12675 RVA: 0x000BDDE8 File Offset: 0x000BBFE8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<UnityEngine.GameObject>.GetEnumerator();
		}

		// Token: 0x06003184 RID: 12676 RVA: 0x000BDDF0 File Offset: 0x000BBFF0
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::UnityEngine.GameObject> global::System.Collections.Generic.IEnumerable<global::UnityEngine.GameObject>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::SlowSpawn.<SpawnAll>c__Iterator46 <SpawnAll>c__Iterator = new global::SlowSpawn.<SpawnAll>c__Iterator46();
			<SpawnAll>c__Iterator.<>f__this = this;
			<SpawnAll>c__Iterator.SpawnFlags = SpawnFlags;
			<SpawnAll>c__Iterator.HideFlags = HideFlags;
			return <SpawnAll>c__Iterator;
		}

		// Token: 0x06003185 RID: 12677 RVA: 0x000BDE3C File Offset: 0x000BC03C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				i = 0;
				break;
			case 1U:
				IL_92:
				i++;
				break;
			default:
				return false;
			}
			if (i < base.Count)
			{
				try
				{
					newSpawn = base[i].Spawn(SpawnFlags, HideFlags);
				}
				catch (global::System.Exception ex)
				{
					e = ex;
					global::UnityEngine.Debug.LogException(e);
					goto IL_92;
				}
				this.$current = newSpawn;
				this.$PC = 1;
				return true;
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06003186 RID: 12678 RVA: 0x000BDF28 File Offset: 0x000BC128
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06003187 RID: 12679 RVA: 0x000BDF34 File Offset: 0x000BC134
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001BB3 RID: 7091
		internal int <i>__0;

		// Token: 0x04001BB4 RID: 7092
		internal global::SlowSpawn.SpawnFlags SpawnFlags;

		// Token: 0x04001BB5 RID: 7093
		internal global::UnityEngine.HideFlags HideFlags;

		// Token: 0x04001BB6 RID: 7094
		internal global::UnityEngine.GameObject <newSpawn>__1;

		// Token: 0x04001BB7 RID: 7095
		internal global::System.Exception <e>__2;

		// Token: 0x04001BB8 RID: 7096
		internal int $PC;

		// Token: 0x04001BB9 RID: 7097
		internal global::UnityEngine.GameObject $current;

		// Token: 0x04001BBA RID: 7098
		internal global::SlowSpawn.SpawnFlags <$>SpawnFlags;

		// Token: 0x04001BBB RID: 7099
		internal global::UnityEngine.HideFlags <$>HideFlags;

		// Token: 0x04001BBC RID: 7100
		internal global::SlowSpawn <>f__this;
	}
}

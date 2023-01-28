using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200090A RID: 2314
[global::UnityEngine.AddComponentMenu("NGUI/Internal/Update Manager")]
[global::UnityEngine.ExecuteInEditMode]
public class UpdateManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004F53 RID: 20307 RVA: 0x001342B4 File Offset: 0x001324B4
	public UpdateManager()
	{
	}

	// Token: 0x06004F54 RID: 20308 RVA: 0x001342F4 File Offset: 0x001324F4
	private static int Compare(global::UpdateManager.UpdateEntry a, global::UpdateManager.UpdateEntry b)
	{
		if (a.index < b.index)
		{
			return 1;
		}
		if (a.index > b.index)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06004F55 RID: 20309 RVA: 0x00134320 File Offset: 0x00132520
	private static void CreateInstance()
	{
		if (global::UpdateManager.mInst == null)
		{
			global::UpdateManager.mInst = (global::UnityEngine.Object.FindObjectOfType(typeof(global::UpdateManager)) as global::UpdateManager);
			if (global::UpdateManager.mInst == null && global::UnityEngine.Application.isPlaying)
			{
				global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("_UpdateManager");
				global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
				global::UpdateManager.mInst = gameObject.AddComponent<global::UpdateManager>();
			}
		}
	}

	// Token: 0x06004F56 RID: 20310 RVA: 0x0013438C File Offset: 0x0013258C
	private void UpdateList(global::System.Collections.Generic.List<global::UpdateManager.UpdateEntry> list, float delta)
	{
		int i = list.Count;
		while (i > 0)
		{
			global::UpdateManager.UpdateEntry updateEntry = list[--i];
			if (updateEntry.isMonoBehaviour)
			{
				if (updateEntry.mb == null)
				{
					list.RemoveAt(i);
					continue;
				}
				if (!updateEntry.mb.enabled || !updateEntry.mb.gameObject.activeInHierarchy)
				{
					continue;
				}
			}
			updateEntry.func(delta);
		}
	}

	// Token: 0x06004F57 RID: 20311 RVA: 0x00134418 File Offset: 0x00132618
	private void Start()
	{
		if (global::UnityEngine.Application.isPlaying)
		{
			this.mTime = global::UnityEngine.Time.realtimeSinceStartup;
			base.StartCoroutine(this.CoroutineFunction());
		}
	}

	// Token: 0x06004F58 RID: 20312 RVA: 0x00134448 File Offset: 0x00132648
	private void OnApplicationQuit()
	{
		global::UnityEngine.Object.DestroyImmediate(base.gameObject);
	}

	// Token: 0x06004F59 RID: 20313 RVA: 0x00134458 File Offset: 0x00132658
	private void Update()
	{
		if (global::UpdateManager.mInst != this)
		{
			global::NGUITools.Destroy(base.gameObject);
		}
		else
		{
			this.UpdateList(this.mOnUpdate, global::UnityEngine.Time.deltaTime);
		}
	}

	// Token: 0x06004F5A RID: 20314 RVA: 0x00134498 File Offset: 0x00132698
	private void LateUpdate()
	{
		this.UpdateList(this.mOnLate, global::UnityEngine.Time.deltaTime);
		if (!global::UnityEngine.Application.isPlaying)
		{
			this.CoroutineUpdate();
		}
	}

	// Token: 0x06004F5B RID: 20315 RVA: 0x001344C8 File Offset: 0x001326C8
	private bool CoroutineUpdate()
	{
		float realtimeSinceStartup = global::UnityEngine.Time.realtimeSinceStartup;
		float num = realtimeSinceStartup - this.mTime;
		if (num < 0.001f)
		{
			return true;
		}
		this.mTime = realtimeSinceStartup;
		this.UpdateList(this.mOnCoro, num);
		bool isPlaying = global::UnityEngine.Application.isPlaying;
		int i = this.mDest.Count;
		while (i > 0)
		{
			global::UpdateManager.DestroyEntry destroyEntry = this.mDest[--i];
			if (!isPlaying || destroyEntry.time < this.mTime)
			{
				if (destroyEntry.obj != null)
				{
					global::NGUITools.Destroy(destroyEntry.obj);
					destroyEntry.obj = null;
				}
				this.mDest.RemoveAt(i);
			}
		}
		if (this.mOnUpdate.Count == 0 && this.mOnLate.Count == 0 && this.mOnCoro.Count == 0 && this.mDest.Count == 0)
		{
			global::NGUITools.Destroy(base.gameObject);
			return false;
		}
		return true;
	}

	// Token: 0x06004F5C RID: 20316 RVA: 0x001345D0 File Offset: 0x001327D0
	private global::System.Collections.IEnumerator CoroutineFunction()
	{
		while (global::UnityEngine.Application.isPlaying)
		{
			if (!this.CoroutineUpdate())
			{
				break;
			}
			yield return null;
		}
		yield break;
	}

	// Token: 0x06004F5D RID: 20317 RVA: 0x001345EC File Offset: 0x001327EC
	private void Add(global::UnityEngine.MonoBehaviour mb, int updateOrder, global::UpdateManager.OnUpdate func, global::System.Collections.Generic.List<global::UpdateManager.UpdateEntry> list)
	{
		int i = 0;
		int count = list.Count;
		while (i < count)
		{
			global::UpdateManager.UpdateEntry updateEntry = list[i];
			if (updateEntry.func == func)
			{
				return;
			}
			i++;
		}
		list.Add(new global::UpdateManager.UpdateEntry
		{
			index = updateOrder,
			func = func,
			mb = mb,
			isMonoBehaviour = (mb != null)
		});
		if (updateOrder != 0)
		{
			list.Sort(new global::System.Comparison<global::UpdateManager.UpdateEntry>(global::UpdateManager.Compare));
		}
	}

	// Token: 0x06004F5E RID: 20318 RVA: 0x00134678 File Offset: 0x00132878
	public static void AddUpdate(global::UnityEngine.MonoBehaviour mb, int updateOrder, global::UpdateManager.OnUpdate func)
	{
		global::UpdateManager.CreateInstance();
		global::UpdateManager.mInst.Add(mb, updateOrder, func, global::UpdateManager.mInst.mOnUpdate);
	}

	// Token: 0x06004F5F RID: 20319 RVA: 0x00134698 File Offset: 0x00132898
	public static void AddLateUpdate(global::UnityEngine.MonoBehaviour mb, int updateOrder, global::UpdateManager.OnUpdate func)
	{
		global::UpdateManager.CreateInstance();
		global::UpdateManager.mInst.Add(mb, updateOrder, func, global::UpdateManager.mInst.mOnLate);
	}

	// Token: 0x06004F60 RID: 20320 RVA: 0x001346B8 File Offset: 0x001328B8
	public static void AddCoroutine(global::UnityEngine.MonoBehaviour mb, int updateOrder, global::UpdateManager.OnUpdate func)
	{
		global::UpdateManager.CreateInstance();
		global::UpdateManager.mInst.Add(mb, updateOrder, func, global::UpdateManager.mInst.mOnCoro);
	}

	// Token: 0x06004F61 RID: 20321 RVA: 0x001346D8 File Offset: 0x001328D8
	public static void AddDestroy(global::UnityEngine.Object obj, float delay)
	{
		if (obj == null)
		{
			return;
		}
		if (global::UnityEngine.Application.isPlaying)
		{
			if (delay > 0f)
			{
				global::UpdateManager.CreateInstance();
				global::UpdateManager.DestroyEntry destroyEntry = new global::UpdateManager.DestroyEntry();
				destroyEntry.obj = obj;
				destroyEntry.time = global::UnityEngine.Time.realtimeSinceStartup + delay;
				global::UpdateManager.mInst.mDest.Add(destroyEntry);
			}
			else
			{
				global::UnityEngine.Object.Destroy(obj);
			}
		}
		else
		{
			global::UnityEngine.Object.DestroyImmediate(obj);
		}
	}

	// Token: 0x04002BD6 RID: 11222
	private static global::UpdateManager mInst;

	// Token: 0x04002BD7 RID: 11223
	private global::System.Collections.Generic.List<global::UpdateManager.UpdateEntry> mOnUpdate = new global::System.Collections.Generic.List<global::UpdateManager.UpdateEntry>();

	// Token: 0x04002BD8 RID: 11224
	private global::System.Collections.Generic.List<global::UpdateManager.UpdateEntry> mOnLate = new global::System.Collections.Generic.List<global::UpdateManager.UpdateEntry>();

	// Token: 0x04002BD9 RID: 11225
	private global::System.Collections.Generic.List<global::UpdateManager.UpdateEntry> mOnCoro = new global::System.Collections.Generic.List<global::UpdateManager.UpdateEntry>();

	// Token: 0x04002BDA RID: 11226
	private global::System.Collections.Generic.List<global::UpdateManager.DestroyEntry> mDest = new global::System.Collections.Generic.List<global::UpdateManager.DestroyEntry>();

	// Token: 0x04002BDB RID: 11227
	private float mTime;

	// Token: 0x0200090B RID: 2315
	public class UpdateEntry
	{
		// Token: 0x06004F62 RID: 20322 RVA: 0x0013474C File Offset: 0x0013294C
		public UpdateEntry()
		{
		}

		// Token: 0x04002BDC RID: 11228
		public int index;

		// Token: 0x04002BDD RID: 11229
		public global::UpdateManager.OnUpdate func;

		// Token: 0x04002BDE RID: 11230
		public global::UnityEngine.MonoBehaviour mb;

		// Token: 0x04002BDF RID: 11231
		public bool isMonoBehaviour;
	}

	// Token: 0x0200090C RID: 2316
	public class DestroyEntry
	{
		// Token: 0x06004F63 RID: 20323 RVA: 0x00134754 File Offset: 0x00132954
		public DestroyEntry()
		{
		}

		// Token: 0x04002BE0 RID: 11232
		public global::UnityEngine.Object obj;

		// Token: 0x04002BE1 RID: 11233
		public float time;
	}

	// Token: 0x0200090D RID: 2317
	// (Invoke) Token: 0x06004F65 RID: 20325
	public delegate void OnUpdate(float delta);

	// Token: 0x0200090E RID: 2318
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <CoroutineFunction>c__Iterator59 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06004F68 RID: 20328 RVA: 0x0013475C File Offset: 0x0013295C
		public <CoroutineFunction>c__Iterator59()
		{
		}

		// Token: 0x17000EA1 RID: 3745
		// (get) Token: 0x06004F69 RID: 20329 RVA: 0x00134764 File Offset: 0x00132964
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000EA2 RID: 3746
		// (get) Token: 0x06004F6A RID: 20330 RVA: 0x0013476C File Offset: 0x0013296C
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004F6B RID: 20331 RVA: 0x00134774 File Offset: 0x00132974
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				break;
			case 1U:
				break;
			default:
				return false;
			}
			if (global::UnityEngine.Application.isPlaying)
			{
				if (base.CoroutineUpdate())
				{
					this.$current = null;
					this.$PC = 1;
					return true;
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06004F6C RID: 20332 RVA: 0x001347EC File Offset: 0x001329EC
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06004F6D RID: 20333 RVA: 0x001347F8 File Offset: 0x001329F8
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04002BE2 RID: 11234
		internal int $PC;

		// Token: 0x04002BE3 RID: 11235
		internal object $current;

		// Token: 0x04002BE4 RID: 11236
		internal global::UpdateManager <>f__this;
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200029D RID: 669
public sealed class GFxCameraDepthTextureControl : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060017C0 RID: 6080 RVA: 0x00059280 File Offset: 0x00057480
	public GFxCameraDepthTextureControl()
	{
	}

	// Token: 0x060017C1 RID: 6081 RVA: 0x00059288 File Offset: 0x00057488
	// Note: this type is marked as 'beforefieldinit'.
	static GFxCameraDepthTextureControl()
	{
	}

	// Token: 0x17000682 RID: 1666
	// (get) Token: 0x060017C2 RID: 6082 RVA: 0x00059294 File Offset: 0x00057494
	// (set) Token: 0x060017C3 RID: 6083 RVA: 0x0005929C File Offset: 0x0005749C
	private global::UnityEngine.DepthTextureMode depthTextureMode
	{
		get
		{
			return this._setDepthTextureMode;
		}
		set
		{
			this._setDepthTextureMode = value;
			if (this.ignoreChangeLock || this.changeLockCount == 0)
			{
				global::UnityEngine.Camera camera = base.camera;
				if (value == 2)
				{
					camera.depthTextureMode = 3;
				}
				else
				{
					camera.depthTextureMode = value;
				}
				this._setDepthTextureMode = camera.depthTextureMode;
				if (this._setDepthTextureMode == 3)
				{
					this._setDepthTextureMode = 2;
				}
			}
		}
	}

	// Token: 0x060017C4 RID: 6084 RVA: 0x00059308 File Offset: 0x00057508
	internal static void FrameCheck()
	{
		if (global::GFxCameraDepthTextureControl.onceHoldCreate)
		{
			int frameCount = global::UnityEngine.Time.frameCount;
			if (global::GFxCameraDepthTextureControl.lastGCCheckFrame != frameCount)
			{
				global::GFxCameraDepthTextureControl.gcChanged = false;
				if (global::GFxCameraDepthTextureControl.controlCount > 0)
				{
					global::GFxCameraDepthTextureControl.ignoredGCEmpty = false;
					object gcLock = global::GFxCameraDepthTextureControl.gcHelp.gcLock;
					lock (gcLock)
					{
						if (global::GFxCameraDepthTextureControl.gcHelp.gcChanged)
						{
							global::GFxCameraDepthTextureControl.gcChanged = true;
							global::GFxCameraDepthTextureControl.gcHelp.gcChanged = false;
						}
					}
				}
				else if (!global::GFxCameraDepthTextureControl.ignoredGCEmpty)
				{
					object gcLock2 = global::GFxCameraDepthTextureControl.gcHelp.gcLock;
					lock (gcLock2)
					{
						global::GFxCameraDepthTextureControl.gcHelp.gcChanged = false;
					}
				}
				global::GFxCameraDepthTextureControl.lastGCCheckFrame = frameCount;
				if (global::GFxCameraDepthTextureControl.gcChanged)
				{
					global::GFxCameraDepthTextureControl.g.FixLeaks();
				}
				else
				{
					global::GFxCameraDepthTextureControl.g.EnsureValues();
				}
			}
		}
	}

	// Token: 0x060017C5 RID: 6085 RVA: 0x000593F8 File Offset: 0x000575F8
	private void UnWant(global::UnityEngine.DepthTextureMode depthTextureMode, global::System.WeakReference wr)
	{
		switch (depthTextureMode)
		{
		case 1:
			if (--this.wantDepth == 0 && this.wantDepthNormal == 0)
			{
				this.depthTextureMode = 0;
			}
			break;
		case 2:
			if (--this.wantDepthNormal == 0)
			{
				this.depthTextureMode = ((this.wantDepth != 0) ? 1 : 0);
			}
			break;
		}
		this.refs.Remove(wr);
	}

	// Token: 0x060017C6 RID: 6086 RVA: 0x00059490 File Offset: 0x00057690
	public bool Want(global::UnityEngine.DepthTextureMode depthTextureMode, ref global::GFxCameraDepthTextureControl.Hold oldHold)
	{
		if (oldHold == null)
		{
			if (depthTextureMode == null)
			{
				return true;
			}
			oldHold = this.Want(depthTextureMode);
			return oldHold != null;
		}
		else
		{
			oldHold.EnsureMine(this);
			if (depthTextureMode == oldHold.depthTextureMode)
			{
				return true;
			}
			if (depthTextureMode != null)
			{
				global::GFxCameraDepthTextureControl.Hold hold = oldHold;
				oldHold = this.Want(depthTextureMode);
				hold.Dispose();
				return oldHold != null;
			}
			oldHold.Dispose();
			oldHold = null;
			return true;
		}
	}

	// Token: 0x060017C7 RID: 6087 RVA: 0x00059504 File Offset: 0x00057704
	public global::GFxCameraDepthTextureControl.Hold Want(global::UnityEngine.DepthTextureMode wantedMinimumDepthTextureMode)
	{
		global::GFxCameraDepthTextureControl.Hold hold;
		switch (wantedMinimumDepthTextureMode)
		{
		case 0:
			hold = new global::GFxCameraDepthTextureControl.Hold(0, this);
			break;
		case 1:
		{
			if (this.wantDepth++ == 0 && this.wantDepthNormal == 0)
			{
				bool flag = this.ignoreChangeLock;
				try
				{
					this.ignoreChangeLock = true;
					this.depthTextureMode = 1;
					if (this.depthTextureMode != 1)
					{
						this.wantDepth--;
						return null;
					}
				}
				finally
				{
					this.ignoreChangeLock = flag;
				}
			}
			hold = new global::GFxCameraDepthTextureControl.Hold(1, this);
			global::System.Collections.Generic.List<global::System.WeakReference> list;
			if ((list = this.refs) == null)
			{
				list = (this.refs = new global::System.Collections.Generic.List<global::System.WeakReference>());
			}
			list.Add(hold.wr);
			break;
		}
		case 2:
		{
			if (this.wantDepthNormal++ == 0)
			{
				bool flag2 = this.ignoreChangeLock;
				try
				{
					this.ignoreChangeLock = true;
					this.depthTextureMode = 2;
					if (this.depthTextureMode != 2)
					{
						this.wantDepthNormal--;
						return null;
					}
				}
				finally
				{
					this.ignoreChangeLock = flag2;
				}
			}
			hold = new global::GFxCameraDepthTextureControl.Hold(2, this);
			global::System.Collections.Generic.List<global::System.WeakReference> list2;
			if ((list2 = this.refs) == null)
			{
				list2 = (this.refs = new global::System.Collections.Generic.List<global::System.WeakReference>());
			}
			list2.Add(hold.wr);
			break;
		}
		default:
			throw new global::System.NotImplementedException();
		}
		return hold;
	}

	// Token: 0x060017C8 RID: 6088 RVA: 0x000596A4 File Offset: 0x000578A4
	private void Awake()
	{
		global::GFxCameraDepthTextureControl.g.Add(this);
	}

	// Token: 0x060017C9 RID: 6089 RVA: 0x000596AC File Offset: 0x000578AC
	public global::GFxCameraDepthTextureControl.ChangeLock LockChanges()
	{
		return new global::GFxCameraDepthTextureControl.ChangeLock(this);
	}

	// Token: 0x060017CA RID: 6090 RVA: 0x000596B4 File Offset: 0x000578B4
	private void FixHoldLeaks()
	{
		if (this.refs != null)
		{
			int num = this.refs.Count - 1;
			global::System.Collections.Generic.List<global::GFxCameraDepthTextureControl.Hold> list = new global::System.Collections.Generic.List<global::GFxCameraDepthTextureControl.Hold>(num + 1);
			for (int i = num; i >= 0; i--)
			{
				global::System.WeakReference weakReference = this.refs[i];
				if (!weakReference.IsAlive)
				{
					int num2 = i;
					int num3 = i;
					while (--i >= 0)
					{
						weakReference = this.refs[i];
						if (weakReference.IsAlive)
						{
							global::System.Collections.Generic.List<global::GFxCameraDepthTextureControl.Hold> list2;
							if ((list2 = list) == null)
							{
								list2 = (list = new global::System.Collections.Generic.List<global::GFxCameraDepthTextureControl.Hold>());
							}
							list2.Add((global::GFxCameraDepthTextureControl.Hold)weakReference.Target);
							break;
						}
						num3 = i;
					}
					if (i < 0)
					{
						if (num2 == num)
						{
							this.refs.Clear();
							this.depthTextureMode = 0;
							this.wantDepth = 0;
							this.wantDepthNormal = 0;
							return;
						}
						this.refs.RemoveRange(num3, num2 - num3 + 1);
					}
					else
					{
						this.refs.RemoveRange(num3, num2 - num3 + 1);
						while (--i >= 0)
						{
							weakReference = this.refs[i];
							if (!weakReference.IsAlive)
							{
								this.refs.RemoveAt(i);
							}
							else
							{
								list.Add((global::GFxCameraDepthTextureControl.Hold)weakReference.Target);
							}
						}
					}
					this.wantDepth = 0;
					this.wantDepthNormal = 0;
					foreach (global::GFxCameraDepthTextureControl.Hold hold in list)
					{
						switch (hold.depthTextureMode)
						{
						case 0:
							break;
						case 1:
							this.wantDepth++;
							break;
						case 2:
							this.wantDepthNormal++;
							break;
						default:
							throw new global::System.NotImplementedException();
						}
					}
					if (this.wantDepthNormal != 0)
					{
						this.depthTextureMode = 2;
					}
					else if (this.wantDepth != 0)
					{
						this.depthTextureMode = 1;
					}
					else
					{
						this.depthTextureMode = 0;
					}
					return;
				}
				global::System.Collections.Generic.List<global::GFxCameraDepthTextureControl.Hold> list3;
				if ((list3 = list) == null)
				{
					list3 = (list = new global::System.Collections.Generic.List<global::GFxCameraDepthTextureControl.Hold>());
				}
				list3.Add((global::GFxCameraDepthTextureControl.Hold)weakReference.Target);
			}
		}
	}

	// Token: 0x060017CB RID: 6091 RVA: 0x00059914 File Offset: 0x00057B14
	private void OnDestroy()
	{
		global::GFxCameraDepthTextureControl.g.Remove(this);
	}

	// Token: 0x04000C88 RID: 3208
	private int wantDepth;

	// Token: 0x04000C89 RID: 3209
	private int wantDepthNormal;

	// Token: 0x04000C8A RID: 3210
	private static bool ignoredGCEmpty;

	// Token: 0x04000C8B RID: 3211
	private int changeLockCount;

	// Token: 0x04000C8C RID: 3212
	private global::UnityEngine.DepthTextureMode _setDepthTextureMode;

	// Token: 0x04000C8D RID: 3213
	private bool ignoreChangeLock;

	// Token: 0x04000C8E RID: 3214
	private static int controlCount;

	// Token: 0x04000C8F RID: 3215
	private bool isRoot;

	// Token: 0x04000C90 RID: 3216
	private static bool gcChanged;

	// Token: 0x04000C91 RID: 3217
	private static bool onceHoldCreate;

	// Token: 0x04000C92 RID: 3218
	private static int lastGCCheckFrame = int.MinValue;

	// Token: 0x04000C93 RID: 3219
	private global::System.Collections.Generic.List<global::System.WeakReference> refs;

	// Token: 0x0200029E RID: 670
	public struct ChangeLock : global::System.IDisposable
	{
		// Token: 0x060017CC RID: 6092 RVA: 0x00059920 File Offset: 0x00057B20
		internal ChangeLock(global::GFxCameraDepthTextureControl control)
		{
			this.disposed = !control;
			if (!this.disposed)
			{
				this.control = control;
				this.control.changeLockCount++;
			}
			else
			{
				this.control = null;
			}
		}

		// Token: 0x060017CD RID: 6093 RVA: 0x00059970 File Offset: 0x00057B70
		public void Dispose()
		{
			if (!this.disposed)
			{
				try
				{
					if (this.control && --this.control.changeLockCount == 0)
					{
						this.control.depthTextureMode = this.control._setDepthTextureMode;
					}
				}
				finally
				{
					this.disposed = true;
				}
			}
		}

		// Token: 0x04000C94 RID: 3220
		internal global::GFxCameraDepthTextureControl control;

		// Token: 0x04000C95 RID: 3221
		private bool disposed;
	}

	// Token: 0x0200029F RID: 671
	private static class g
	{
		// Token: 0x060017CE RID: 6094 RVA: 0x000599F4 File Offset: 0x00057BF4
		static g()
		{
			global::GFxFrameAnalyst.EnsureRunning();
		}

		// Token: 0x060017CF RID: 6095 RVA: 0x00059A08 File Offset: 0x00057C08
		public static void Add(global::GFxCameraDepthTextureControl instance)
		{
			global::GFxCameraDepthTextureControl.g.allControlls.Add(instance);
			global::GFxCameraDepthTextureControl.controlCount++;
		}

		// Token: 0x060017D0 RID: 6096 RVA: 0x00059A24 File Offset: 0x00057C24
		public static bool Remove(global::GFxCameraDepthTextureControl instance)
		{
			if (global::GFxCameraDepthTextureControl.g.allControlls.Remove(instance))
			{
				global::GFxCameraDepthTextureControl.controlCount--;
				return true;
			}
			return false;
		}

		// Token: 0x060017D1 RID: 6097 RVA: 0x00059A48 File Offset: 0x00057C48
		public static void FixLeaks()
		{
			foreach (global::GFxCameraDepthTextureControl gfxCameraDepthTextureControl in global::GFxCameraDepthTextureControl.g.allControlls)
			{
				gfxCameraDepthTextureControl.FixHoldLeaks();
			}
		}

		// Token: 0x060017D2 RID: 6098 RVA: 0x00059AAC File Offset: 0x00057CAC
		public static void EnsureValues()
		{
		}

		// Token: 0x04000C96 RID: 3222
		private static readonly global::System.Collections.Generic.List<global::GFxCameraDepthTextureControl> allControlls = new global::System.Collections.Generic.List<global::GFxCameraDepthTextureControl>();
	}

	// Token: 0x020002A0 RID: 672
	private static class gcHelp
	{
		// Token: 0x060017D3 RID: 6099 RVA: 0x00059AB0 File Offset: 0x00057CB0
		// Note: this type is marked as 'beforefieldinit'.
		static gcHelp()
		{
		}

		// Token: 0x04000C97 RID: 3223
		public static object gcLock = new object();

		// Token: 0x04000C98 RID: 3224
		public static bool gcChanged;
	}

	// Token: 0x020002A1 RID: 673
	public class Hold : global::System.IDisposable
	{
		// Token: 0x060017D4 RID: 6100 RVA: 0x00059ABC File Offset: 0x00057CBC
		public Hold(global::UnityEngine.DepthTextureMode mode, global::GFxCameraDepthTextureControl control)
		{
			this.mode = mode;
			this.control = control;
			global::GFxCameraDepthTextureControl.onceHoldCreate = true;
			if (mode == null)
			{
				global::System.GC.SuppressFinalize(this);
			}
		}

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x060017D5 RID: 6101 RVA: 0x00059AF0 File Offset: 0x00057CF0
		public global::UnityEngine.DepthTextureMode depthTextureMode
		{
			get
			{
				return this.mode;
			}
		}

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x060017D6 RID: 6102 RVA: 0x00059AF8 File Offset: 0x00057CF8
		internal global::System.WeakReference wr
		{
			get
			{
				return this.selfWeak;
			}
		}

		// Token: 0x060017D7 RID: 6103 RVA: 0x00059B00 File Offset: 0x00057D00
		internal void EnsureMine(global::GFxCameraDepthTextureControl control)
		{
			if (!object.ReferenceEquals(control, this.control))
			{
				throw new global::System.InvalidOperationException("Something went wrong, a Hold was used in a control it was not made in");
			}
		}

		// Token: 0x060017D8 RID: 6104 RVA: 0x00059B20 File Offset: 0x00057D20
		public void Dispose()
		{
			if (this.mode != null)
			{
				if (this.control)
				{
					global::GFxCameraDepthTextureControl gfxCameraDepthTextureControl = this.control;
					global::UnityEngine.DepthTextureMode depthTextureMode = this.mode;
					this.mode = 0;
					this.control = null;
					this.selfWeak = null;
					global::System.GC.SuppressFinalize(this);
					gfxCameraDepthTextureControl.UnWant(depthTextureMode, this.selfWeak);
				}
				else
				{
					this.mode = 0;
					this.control = null;
					global::System.GC.SuppressFinalize(this);
				}
			}
			else if (this.control)
			{
				this.control = null;
				global::System.GC.SuppressFinalize(this);
			}
		}

		// Token: 0x060017D9 RID: 6105 RVA: 0x00059BBC File Offset: 0x00057DBC
		protected override void Finalize()
		{
			try
			{
				object gcLock = global::GFxCameraDepthTextureControl.gcHelp.gcLock;
				lock (gcLock)
				{
					global::GFxCameraDepthTextureControl.gcChanged = true;
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x04000C99 RID: 3225
		private global::UnityEngine.DepthTextureMode mode;

		// Token: 0x04000C9A RID: 3226
		private global::GFxCameraDepthTextureControl control;

		// Token: 0x04000C9B RID: 3227
		private global::System.WeakReference selfWeak;
	}
}

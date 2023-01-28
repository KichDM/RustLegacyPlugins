using System;
using System.Collections;
using UnityEngine;

namespace Facepunch.Load
{
	// Token: 0x020002E4 RID: 740
	public static class Utility
	{
		// Token: 0x06001965 RID: 6501 RVA: 0x000627E4 File Offset: 0x000609E4
		public static string GetBuildInvariantTypeName(this global::System.Type type)
		{
			string text = type.Assembly.FullName;
			int num = text.IndexOf(',');
			if (num != -1)
			{
				text = text.Substring(0, num);
			}
			return type.FullName + ", " + text;
		}

		// Token: 0x020002E5 RID: 741
		public sealed class ReferenceCountedCoroutine : global::System.Collections.IEnumerator
		{
			// Token: 0x06001966 RID: 6502 RVA: 0x00062828 File Offset: 0x00060A28
			private ReferenceCountedCoroutine(global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Runner runner, global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Callback callback, object yieldInstruction, object tag, bool skipOnce)
			{
				this.runner = runner;
				this.callback = callback;
				this.yieldInstruction = yieldInstruction;
				this.tag = tag;
				this.skipOnce = skipOnce;
			}

			// Token: 0x170006F3 RID: 1779
			// (get) Token: 0x06001967 RID: 6503 RVA: 0x00062858 File Offset: 0x00060A58
			object global::System.Collections.IEnumerator.Current
			{
				get
				{
					return this.yieldInstruction;
				}
			}

			// Token: 0x06001968 RID: 6504 RVA: 0x00062860 File Offset: 0x00060A60
			void global::System.Collections.IEnumerator.Reset()
			{
			}

			// Token: 0x06001969 RID: 6505 RVA: 0x00062864 File Offset: 0x00060A64
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				if (this.skipOnce)
				{
					this.skipOnce = false;
					return true;
				}
				bool flag;
				try
				{
					flag = this.callback(ref this.yieldInstruction, ref this.tag);
				}
				catch (global::System.Exception ex)
				{
					flag = false;
					global::UnityEngine.Debug.LogException(ex);
				}
				if (!flag)
				{
					this.runner.Release();
					this.tag = null;
					this.yieldInstruction = null;
					return false;
				}
				return true;
			}

			// Token: 0x04000E68 RID: 3688
			private readonly global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Runner runner;

			// Token: 0x04000E69 RID: 3689
			private readonly global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Callback callback;

			// Token: 0x04000E6A RID: 3690
			private object tag;

			// Token: 0x04000E6B RID: 3691
			private object yieldInstruction;

			// Token: 0x04000E6C RID: 3692
			private bool skipOnce;

			// Token: 0x020002E6 RID: 742
			public sealed class Runner
			{
				// Token: 0x0600196A RID: 6506 RVA: 0x000628F0 File Offset: 0x00060AF0
				public Runner(string gameObjectName)
				{
					this.gameObjectName = gameObjectName;
				}

				// Token: 0x0600196B RID: 6507 RVA: 0x00062900 File Offset: 0x00060B00
				public void Retain()
				{
					if (this.refCount++ == 0)
					{
						this.go = new global::UnityEngine.GameObject(this.gameObjectName, new global::System.Type[]
						{
							typeof(global::Facepunch.MonoBehaviour)
						});
						global::UnityEngine.Object.DontDestroyOnLoad(this.go);
						this.script = this.go.GetComponent<global::Facepunch.MonoBehaviour>();
					}
				}

				// Token: 0x0600196C RID: 6508 RVA: 0x00062964 File Offset: 0x00060B64
				public global::UnityEngine.Coroutine Install(global::Facepunch.Load.Utility.ReferenceCountedCoroutine.Callback callback, object tag, object defaultYieldInstruction, bool skipFirst)
				{
					this.Retain();
					return this.script.StartCoroutine(new global::Facepunch.Load.Utility.ReferenceCountedCoroutine(this, callback, defaultYieldInstruction, tag, skipFirst));
				}

				// Token: 0x0600196D RID: 6509 RVA: 0x00062990 File Offset: 0x00060B90
				public void Release()
				{
					if (--this.refCount == 0)
					{
						global::UnityEngine.Object.Destroy(this.go);
						global::UnityEngine.Object.Destroy(this.script);
						this.go = null;
						this.script = null;
					}
				}

				// Token: 0x04000E6D RID: 3693
				private readonly string gameObjectName;

				// Token: 0x04000E6E RID: 3694
				private global::UnityEngine.GameObject go;

				// Token: 0x04000E6F RID: 3695
				private global::Facepunch.MonoBehaviour script;

				// Token: 0x04000E70 RID: 3696
				private int refCount;
			}

			// Token: 0x020002E7 RID: 743
			// (Invoke) Token: 0x0600196F RID: 6511
			public delegate bool Callback(ref object yieldInstruction, ref object tag);
		}
	}
}

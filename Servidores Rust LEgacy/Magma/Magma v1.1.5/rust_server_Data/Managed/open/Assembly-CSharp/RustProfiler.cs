using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class RustProfiler : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C1E RID: 11294 RVA: 0x000A6228 File Offset: 0x000A4428
	public RustProfiler()
	{
	}

	// Token: 0x06002C1F RID: 11295 RVA: 0x000A6230 File Offset: 0x000A4430
	public void StartRecording(int iSeconds)
	{
		base.StartCoroutine("DoProfile", iSeconds);
	}

	// Token: 0x06002C20 RID: 11296 RVA: 0x000A6244 File Offset: 0x000A4444
	private global::System.Collections.IEnumerator DoProfile(int iSeconds)
	{
		if (!global::System.IO.Directory.Exists("profiles"))
		{
			global::System.IO.Directory.CreateDirectory("profiles");
		}
		string filename = "profiles/";
		filename += global::System.DateTime.Now.ToString("MM-dd-yyyy-h-mm");
		string text = filename;
		filename = string.Concat(new object[]
		{
			text,
			"-",
			iSeconds,
			"secs.profile"
		});
		global::UnityEngine.Debug.Log("Starting profile to " + filename);
		global::UnityEngine.Profiler.logFile = filename;
		global::UnityEngine.Profiler.enableBinaryLog = true;
		global::UnityEngine.Profiler.enabled = true;
		yield return new global::UnityEngine.WaitForSeconds((float)iSeconds);
		global::UnityEngine.Profiler.enabled = false;
		global::UnityEngine.Debug.Log("Profile finished!");
		global::UnityEngine.Profiler.logFile = "profiles/hack.profile";
		global::UnityEngine.Profiler.enableBinaryLog = true;
		global::UnityEngine.Profiler.enabled = true;
		yield return new global::UnityEngine.WaitForEndOfFrame();
		yield return new global::UnityEngine.WaitForEndOfFrame();
		global::UnityEngine.Profiler.enabled = false;
		global::UnityEngine.Object.Destroy(this);
		yield break;
	}

	// Token: 0x02000506 RID: 1286
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DoProfile>c__Iterator3E : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06002C21 RID: 11297 RVA: 0x000A6270 File Offset: 0x000A4470
		public <DoProfile>c__Iterator3E()
		{
		}

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x06002C22 RID: 11298 RVA: 0x000A6278 File Offset: 0x000A4478
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x06002C23 RID: 11299 RVA: 0x000A6280 File Offset: 0x000A4480
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002C24 RID: 11300 RVA: 0x000A6288 File Offset: 0x000A4488
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
			{
				if (!global::System.IO.Directory.Exists("profiles"))
				{
					global::System.IO.Directory.CreateDirectory("profiles");
				}
				filename = "profiles/";
				filename += global::System.DateTime.Now.ToString("MM-dd-yyyy-h-mm");
				string text = filename;
				filename = string.Concat(new object[]
				{
					text,
					"-",
					iSeconds,
					"secs.profile"
				});
				global::UnityEngine.Debug.Log("Starting profile to " + filename);
				global::UnityEngine.Profiler.logFile = filename;
				global::UnityEngine.Profiler.enableBinaryLog = true;
				global::UnityEngine.Profiler.enabled = true;
				this.$current = new global::UnityEngine.WaitForSeconds((float)iSeconds);
				this.$PC = 1;
				return true;
			}
			case 1U:
				global::UnityEngine.Profiler.enabled = false;
				global::UnityEngine.Debug.Log("Profile finished!");
				global::UnityEngine.Profiler.logFile = "profiles/hack.profile";
				global::UnityEngine.Profiler.enableBinaryLog = true;
				global::UnityEngine.Profiler.enabled = true;
				this.$current = new global::UnityEngine.WaitForEndOfFrame();
				this.$PC = 2;
				return true;
			case 2U:
				this.$current = new global::UnityEngine.WaitForEndOfFrame();
				this.$PC = 3;
				return true;
			case 3U:
				global::UnityEngine.Profiler.enabled = false;
				global::UnityEngine.Object.Destroy(this);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06002C25 RID: 11301 RVA: 0x000A63FC File Offset: 0x000A45FC
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06002C26 RID: 11302 RVA: 0x000A6408 File Offset: 0x000A4608
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400166B RID: 5739
		internal string <filename>__0;

		// Token: 0x0400166C RID: 5740
		internal int iSeconds;

		// Token: 0x0400166D RID: 5741
		internal int $PC;

		// Token: 0x0400166E RID: 5742
		internal object $current;

		// Token: 0x0400166F RID: 5743
		internal int <$>iSeconds;

		// Token: 0x04001670 RID: 5744
		internal global::RustProfiler <>f__this;
	}
}

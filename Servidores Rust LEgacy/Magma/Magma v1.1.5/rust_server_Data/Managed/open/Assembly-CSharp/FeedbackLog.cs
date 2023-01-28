using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02000068 RID: 104
public static class FeedbackLog
{
	// Token: 0x060002E0 RID: 736 RVA: 0x0000E7A0 File Offset: 0x0000C9A0
	// Note: this type is marked as 'beforefieldinit'.
	static FeedbackLog()
	{
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0000E7BC File Offset: 0x0000C9BC
	public static void Start(global::FeedbackLog.TYPE message_type)
	{
		global::FeedbackLog.memstream.Position = 0L;
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x0000E7CC File Offset: 0x0000C9CC
	public unsafe static void End(global::FeedbackLog.TYPE message_type)
	{
		fixed (byte* value = ref (global::FeedbackLog.memstream.GetBuffer() != null && global::FeedbackLog.memstream.GetBuffer().Length != 0) ? ref global::FeedbackLog.memstream.GetBuffer()[0] : ref *null)
		{
			global::System.IntPtr pData = (global::System.IntPtr)((void*)value);
			global::FeedbackLog.Client_Info((byte)message_type, pData, (uint)global::FeedbackLog.memstream.Position);
		}
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0000E830 File Offset: 0x0000CA30
	public static void WriteObject(global::UnityEngine.GameObject obj)
	{
		if (!obj)
		{
			global::FeedbackLog.Writer.Write(0);
			return;
		}
		global::Character component = obj.GetComponent<global::Character>();
		if (component)
		{
			if (component.playerClient != null)
			{
				global::FeedbackLog.Writer.Write(1);
				global::FeedbackLog.Writer.Write(component.playerClient.userID);
			}
			else
			{
				global::FeedbackLog.Writer.Write(2);
				global::FeedbackLog.Writer.Write(obj.ToString());
			}
			return;
		}
		global::FeedbackLog.Writer.Write(0x64);
		global::FeedbackLog.Writer.Write(obj.ToString());
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0000E8D4 File Offset: 0x0000CAD4
	public static void WriteVector(global::UnityEngine.Vector3 vec)
	{
		global::FeedbackLog.Writer.Write(vec.x);
		global::FeedbackLog.Writer.Write(vec.y);
		global::FeedbackLog.Writer.Write(vec.z);
	}

	// Token: 0x060002E5 RID: 741
	[global::System.Runtime.InteropServices.DllImport("librust")]
	private static extern void Client_Info(byte type, global::System.IntPtr pData, uint iSize);

	// Token: 0x04000204 RID: 516
	private static global::System.IO.MemoryStream memstream = new global::System.IO.MemoryStream();

	// Token: 0x04000205 RID: 517
	public static global::System.IO.BinaryWriter Writer = new global::System.IO.BinaryWriter(global::FeedbackLog.memstream);

	// Token: 0x02000069 RID: 105
	public enum TYPE
	{
		// Token: 0x04000207 RID: 519
		Connected = 2,
		// Token: 0x04000208 RID: 520
		StartConnect,
		// Token: 0x04000209 RID: 521
		LoadProgress,
		// Token: 0x0400020A RID: 522
		HardwareInfo,
		// Token: 0x0400020B RID: 523
		Mods = 7,
		// Token: 0x0400020C RID: 524
		SimpleExploit,
		// Token: 0x0400020D RID: 525
		Death,
		// Token: 0x0400020E RID: 526
		Chat
	}
}

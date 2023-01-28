using System;
using System.IO;
using System.Reflection;
using UnityEngine;

// Token: 0x0200052B RID: 1323
public class BrandingVersion : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002CA3 RID: 11427 RVA: 0x000A89D8 File Offset: 0x000A6BD8
	public BrandingVersion()
	{
	}

	// Token: 0x06002CA4 RID: 11428 RVA: 0x000A89E0 File Offset: 0x000A6BE0
	private void Start()
	{
		global::System.DateTime dateTime = this.RetrieveLinkerTimestamp();
		this.textVersion.Text = dateTime.ToString("d MMM yyyy\\, h:mmtt");
	}

	// Token: 0x06002CA5 RID: 11429 RVA: 0x000A8A0C File Offset: 0x000A6C0C
	private global::System.DateTime RetrieveLinkerTimestamp()
	{
		string location = global::System.Reflection.Assembly.GetCallingAssembly().Location;
		byte[] array = new byte[0x800];
		global::System.IO.Stream stream = null;
		try
		{
			stream = new global::System.IO.FileStream(location, global::System.IO.FileMode.Open, global::System.IO.FileAccess.Read);
			stream.Read(array, 0, 0x800);
		}
		finally
		{
			if (stream != null)
			{
				stream.Close();
			}
		}
		int num = global::System.BitConverter.ToInt32(array, 0x3C);
		int num2 = global::System.BitConverter.ToInt32(array, num + 8);
		global::System.DateTime dateTime = new global::System.DateTime(0x7B2, 1, 1, 0, 0, 0);
		dateTime = dateTime.AddSeconds((double)num2);
		dateTime = dateTime.AddHours((double)global::System.TimeZone.CurrentTimeZone.GetUtcOffset(dateTime).Hours);
		return dateTime;
	}

	// Token: 0x040016E6 RID: 5862
	public global::dfRichTextLabel textVersion;
}

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020008E1 RID: 2273
public class ByteReader
{
	// Token: 0x06004DE5 RID: 19941 RVA: 0x0012ABF0 File Offset: 0x00128DF0
	public ByteReader(byte[] bytes)
	{
		this.mBuffer = bytes;
	}

	// Token: 0x06004DE6 RID: 19942 RVA: 0x0012AC00 File Offset: 0x00128E00
	public ByteReader(global::UnityEngine.TextAsset asset)
	{
		this.mBuffer = asset.bytes;
	}

	// Token: 0x17000E76 RID: 3702
	// (get) Token: 0x06004DE7 RID: 19943 RVA: 0x0012AC14 File Offset: 0x00128E14
	public bool canRead
	{
		get
		{
			return this.mBuffer != null && this.mOffset < this.mBuffer.Length;
		}
	}

	// Token: 0x06004DE8 RID: 19944 RVA: 0x0012AC34 File Offset: 0x00128E34
	private static string ReadLine(byte[] buffer, int start, int count)
	{
		return global::System.Text.Encoding.UTF8.GetString(buffer, start, count);
	}

	// Token: 0x06004DE9 RID: 19945 RVA: 0x0012AC44 File Offset: 0x00128E44
	public string ReadLine()
	{
		int num = this.mBuffer.Length;
		while (this.mOffset < num && this.mBuffer[this.mOffset] < 0x20)
		{
			this.mOffset++;
		}
		int i = this.mOffset;
		if (i < num)
		{
			while (i < num)
			{
				int num2 = (int)this.mBuffer[i++];
				if (num2 == 0xA || num2 == 0xD)
				{
					IL_81:
					string result = global::ByteReader.ReadLine(this.mBuffer, this.mOffset, i - this.mOffset - 1);
					this.mOffset = i;
					return result;
				}
			}
			i++;
			goto IL_81;
		}
		this.mOffset = num;
		return null;
	}

	// Token: 0x06004DEA RID: 19946 RVA: 0x0012AD04 File Offset: 0x00128F04
	public global::System.Collections.Generic.Dictionary<string, string> ReadDictionary()
	{
		global::System.Collections.Generic.Dictionary<string, string> dictionary = new global::System.Collections.Generic.Dictionary<string, string>();
		char[] separator = new char[]
		{
			'='
		};
		while (this.canRead)
		{
			string text = this.ReadLine();
			if (text == null)
			{
				break;
			}
			string[] array = text.Split(separator, 2, global::System.StringSplitOptions.RemoveEmptyEntries);
			if (array.Length == 2)
			{
				string key = array[0].Trim();
				string value = array[1].Trim();
				dictionary[key] = value;
			}
		}
		return dictionary;
	}

	// Token: 0x04002AFA RID: 11002
	private byte[] mBuffer;

	// Token: 0x04002AFB RID: 11003
	private int mOffset;
}

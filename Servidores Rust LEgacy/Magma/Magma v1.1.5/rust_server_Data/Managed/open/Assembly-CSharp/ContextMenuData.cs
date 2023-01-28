using System;
using System.Collections.Generic;
using uLink;

// Token: 0x02000598 RID: 1432
internal class ContextMenuData
{
	// Token: 0x06002F78 RID: 12152 RVA: 0x000B4F04 File Offset: 0x000B3104
	public ContextMenuData(int optionCount, global::ContextMenuItemData[] data)
	{
		this.options_length = optionCount;
		this.options = data;
	}

	// Token: 0x06002F79 RID: 12153 RVA: 0x000B4F1C File Offset: 0x000B311C
	public ContextMenuData(global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> prototypeEnumerable)
	{
		if (prototypeEnumerable is global::System.Collections.Generic.ICollection<global::ContextActionPrototype>)
		{
			this.options = new global::ContextMenuItemData[((global::System.Collections.Generic.ICollection<global::ContextActionPrototype>)prototypeEnumerable).Count];
			int num = 0;
			foreach (global::ContextActionPrototype prototype in prototypeEnumerable)
			{
				this.options[num++] = new global::ContextMenuItemData(prototype);
			}
			if (num < this.options.Length)
			{
				global::System.Array.Resize<global::ContextMenuItemData>(ref this.options, this.options.Length);
			}
			this.options_length = this.options.Length;
		}
		else
		{
			this.options = global::ContextMenuData.ToArray(prototypeEnumerable, out this.options_length);
		}
	}

	// Token: 0x06002F7A RID: 12154 RVA: 0x000B5000 File Offset: 0x000B3200
	static ContextMenuData()
	{
		global::uLink.BitStreamCodec.Add<global::ContextMenuData>(global::ContextMenuData.deserializer, global::ContextMenuData.serializer);
	}

	// Token: 0x06002F7B RID: 12155 RVA: 0x000B5034 File Offset: 0x000B3234
	private static global::ContextMenuItemData[] ToArray(global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> enumerable, out int length)
	{
		global::ContextMenuItemData[] array;
		using (enumerable.GetEnumerator())
		{
			global::ContextMenuData.EnumerableConverter enumerableConverter = new global::ContextMenuData.EnumerableConverter
			{
				enumerator = enumerable.GetEnumerator()
			};
			enumerableConverter.R();
			length = enumerableConverter.length;
			array = enumerableConverter.array;
		}
		return array;
	}

	// Token: 0x06002F7C RID: 12156 RVA: 0x000B50B0 File Offset: 0x000B32B0
	private static void Serialize(global::uLink.BitStream stream, object value, params object[] codecOptions)
	{
		global::ContextMenuData contextMenuData = (global::ContextMenuData)value;
		stream.Write<int>(contextMenuData.options_length, codecOptions);
		for (int i = 0; i < contextMenuData.options_length; i++)
		{
			stream.Write<int>(contextMenuData.options[i].name, codecOptions);
			stream.WriteByteArray_MinimumCalls(contextMenuData.options[i].utf8_text, 0, contextMenuData.options[i].utf8_length, codecOptions);
		}
	}

	// Token: 0x06002F7D RID: 12157 RVA: 0x000B512C File Offset: 0x000B332C
	private static object Deserialize(global::uLink.BitStream stream, params object[] codecOptions)
	{
		int num = stream.Read<int>(codecOptions);
		global::ContextMenuItemData[] array = (num != 0) ? new global::ContextMenuItemData[num] : null;
		for (int i = 0; i < num; i++)
		{
			int name = stream.Read<int>(codecOptions);
			byte[] utf8_text;
			int utf8_length;
			stream.ReadByteArray_MinimalCalls(out utf8_text, out utf8_length, codecOptions);
			array[i] = new global::ContextMenuItemData(name, utf8_length, utf8_text);
		}
		return new global::ContextMenuData(num, array);
	}

	// Token: 0x04001952 RID: 6482
	[global::System.NonSerialized]
	public readonly int options_length;

	// Token: 0x04001953 RID: 6483
	[global::System.NonSerialized]
	public readonly global::ContextMenuItemData[] options;

	// Token: 0x04001954 RID: 6484
	private static readonly global::uLink.BitStreamCodec.Serializer serializer = new global::uLink.BitStreamCodec.Serializer(global::ContextMenuData.Serialize);

	// Token: 0x04001955 RID: 6485
	private static readonly global::uLink.BitStreamCodec.Deserializer deserializer = new global::uLink.BitStreamCodec.Deserializer(global::ContextMenuData.Deserialize);

	// Token: 0x02000599 RID: 1433
	private struct EnumerableConverter
	{
		// Token: 0x06002F7E RID: 12158 RVA: 0x000B5198 File Offset: 0x000B3398
		public void R()
		{
			if (this.enumerator.MoveNext())
			{
				this.length++;
				global::ContextActionPrototype prototype = this.enumerator.Current;
				this.R();
				this.array[--this.spot] = new global::ContextMenuItemData(prototype);
			}
			else if (this.length == 0)
			{
				this.array = null;
			}
			else
			{
				this.array = new global::ContextMenuItemData[this.length];
				this.spot = this.length;
			}
		}

		// Token: 0x04001956 RID: 6486
		public global::System.Collections.Generic.IEnumerator<global::ContextActionPrototype> enumerator;

		// Token: 0x04001957 RID: 6487
		public int length;

		// Token: 0x04001958 RID: 6488
		public int spot;

		// Token: 0x04001959 RID: 6489
		public global::ContextMenuItemData[] array;
	}
}

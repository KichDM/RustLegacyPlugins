using System;
using uLink;

// Token: 0x0200027D RID: 637
public static class uLinkAngle2Extensions
{
	// Token: 0x060016D5 RID: 5845 RVA: 0x00054538 File Offset: 0x00052738
	static uLinkAngle2Extensions()
	{
		global::uLinkAngle2Extensions.deserializer = new global::uLink.BitStreamCodec.Deserializer(global::uLinkAngle2Extensions.Deserializer);
		global::uLink.BitStreamCodec.Add<global::Angle2>(global::uLinkAngle2Extensions.deserializer, global::uLinkAngle2Extensions.serializer, 0xD, false);
	}

	// Token: 0x060016D6 RID: 5846 RVA: 0x00054594 File Offset: 0x00052794
	public static void Serialize(this global::uLink.BitStream stream, ref global::Angle2 value, params object[] codecOptions)
	{
		int encoded = value.encoded;
		int num = encoded;
		stream.Serialize(ref num, codecOptions);
		if (num != encoded)
		{
			value.encoded = num;
		}
	}

	// Token: 0x060016D7 RID: 5847 RVA: 0x000545C4 File Offset: 0x000527C4
	public static void WriteAngle2(this global::uLink.BitStream stream, global::Angle2 value)
	{
		stream.WriteInt32(value.encoded);
	}

	// Token: 0x060016D8 RID: 5848 RVA: 0x000545D4 File Offset: 0x000527D4
	public static global::Angle2 ReadAngle2(this global::uLink.BitStream stream)
	{
		return new global::Angle2
		{
			encoded = stream.ReadInt32()
		};
	}

	// Token: 0x060016D9 RID: 5849 RVA: 0x000545FC File Offset: 0x000527FC
	private static object Deserializer(global::uLink.BitStream stream, params object[] codecOptions)
	{
		object obj = global::uLinkAngle2Extensions.int32Codec.deserializer.Invoke(stream, codecOptions);
		if (obj is int)
		{
			return new global::Angle2
			{
				encoded = (int)obj
			};
		}
		return obj;
	}

	// Token: 0x060016DA RID: 5850 RVA: 0x00054648 File Offset: 0x00052848
	private static void Serializer(global::uLink.BitStream stream, object value, params object[] codecOptions)
	{
		global::uLinkAngle2Extensions.int32Codec.serializer.Invoke(stream, ((global::Angle2)value).encoded, codecOptions);
	}

	// Token: 0x060016DB RID: 5851 RVA: 0x0005467C File Offset: 0x0005287C
	public static void Register()
	{
	}

	// Token: 0x04000BC6 RID: 3014
	private const global::uLink.BitStreamTypeCode bitStreamTypeCode = 0xD;

	// Token: 0x04000BC7 RID: 3015
	private static readonly global::uLink.BitStreamCodec int32Codec = global::uLink.BitStreamCodec.Find(typeof(int).TypeHandle);

	// Token: 0x04000BC8 RID: 3016
	private static readonly global::uLink.BitStreamCodec.Deserializer deserializer;

	// Token: 0x04000BC9 RID: 3017
	private static readonly global::uLink.BitStreamCodec.Serializer serializer = new global::uLink.BitStreamCodec.Serializer(global::uLinkAngle2Extensions.Serializer);
}

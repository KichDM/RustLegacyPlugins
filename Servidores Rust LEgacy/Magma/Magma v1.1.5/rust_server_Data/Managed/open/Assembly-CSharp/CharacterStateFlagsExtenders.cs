using System;
using uLink;

// Token: 0x0200013E RID: 318
public static class CharacterStateFlagsExtenders
{
	// Token: 0x0600085B RID: 2139 RVA: 0x000224FC File Offset: 0x000206FC
	public static void WriteCharacterStateFlags(this global::uLink.BitStream stream, global::CharacterStateFlags v)
	{
		stream.WriteUInt16(v.flags);
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x0002250C File Offset: 0x0002070C
	public static global::CharacterStateFlags ReadCharacterStateFlags(this global::uLink.BitStream stream)
	{
		global::CharacterStateFlags result;
		result.flags = stream.ReadUInt16();
		return result;
	}

	// Token: 0x0600085D RID: 2141 RVA: 0x00022528 File Offset: 0x00020728
	public static void Serialize(this global::uLink.BitStream stream, ref global::CharacterStateFlags v)
	{
		stream.Serialize<ushort>(ref v.flags, new object[0]);
	}
}

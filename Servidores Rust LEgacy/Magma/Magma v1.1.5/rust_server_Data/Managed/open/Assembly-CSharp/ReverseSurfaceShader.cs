using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class ReverseSurfaceShader : global::UnityEngine.ScriptableObject
{
	// Token: 0x06002828 RID: 10280 RVA: 0x00099A7C File Offset: 0x00097C7C
	public ReverseSurfaceShader()
	{
	}

	// Token: 0x040013F4 RID: 5108
	public global::UnityEngine.Shader inputShader;

	// Token: 0x040013F5 RID: 5109
	public global::UnityEngine.Shader outputShader;

	// Token: 0x040013F6 RID: 5110
	public string outputShaderName;

	// Token: 0x040013F7 RID: 5111
	public bool pragmaDebug;

	// Token: 0x040013F8 RID: 5112
	public global::ShaderMod[] mods;
}

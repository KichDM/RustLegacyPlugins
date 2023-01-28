using System;
using Facepunch.Precision;

// Token: 0x0200056F RID: 1391
public struct PerspectiveMatrixBuilder
{
	// Token: 0x06002EFB RID: 12027 RVA: 0x000B3114 File Offset: 0x000B1314
	public void ToProjectionMatrix(out global::Facepunch.Precision.Matrix4x4G proj)
	{
		global::Facepunch.Precision.Matrix4x4G.Perspective(ref this.fieldOfView, ref this.aspectRatio, ref this.nearPlane, ref this.farPlane, ref proj);
	}

	// Token: 0x04001897 RID: 6295
	public double fieldOfView;

	// Token: 0x04001898 RID: 6296
	public double aspectRatio;

	// Token: 0x04001899 RID: 6297
	public double nearPlane;

	// Token: 0x0400189A RID: 6298
	public double farPlane;
}

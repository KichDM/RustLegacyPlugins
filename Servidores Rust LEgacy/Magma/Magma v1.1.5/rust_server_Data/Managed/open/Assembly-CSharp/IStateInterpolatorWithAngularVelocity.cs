using System;

// Token: 0x02000346 RID: 838
public interface IStateInterpolatorWithAngularVelocity
{
	// Token: 0x06001C32 RID: 7218
	bool SampleWorldVelocity(double timeStamp, out global::Angle2 angular);

	// Token: 0x06001C33 RID: 7219
	bool SampleWorldVelocity(out global::Angle2 angular);
}

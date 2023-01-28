using System;

// Token: 0x02000348 RID: 840
public interface IStateInterpolatorSampler<TSampleType>
{
	// Token: 0x06001C36 RID: 7222
	bool Sample(ref double timeStamp, out TSampleType sample);
}

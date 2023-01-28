using System;

// Token: 0x02000349 RID: 841
public interface IStateInterpolator<TSampleType> : global::IStateInterpolatorSampler<TSampleType>
{
	// Token: 0x06001C37 RID: 7223
	void SetGoals(ref TSampleType sample, ref double timeStamp);

	// Token: 0x06001C38 RID: 7224
	void SetGoals(ref global::TimeStamped<TSampleType> sample);
}

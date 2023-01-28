using System;

// Token: 0x0200043D RID: 1085
public struct TimeStamped<T>
{
	// Token: 0x060025C4 RID: 9668 RVA: 0x00090834 File Offset: 0x0008EA34
	public void Set(ref T value, ref double timeStamp)
	{
		this.timeStamp = timeStamp;
		this.value = value;
	}

	// Token: 0x0400133D RID: 4925
	public double timeStamp;

	// Token: 0x0400133E RID: 4926
	public int index;

	// Token: 0x0400133F RID: 4927
	public T value;
}

using System;

namespace Facepunch.Procedural
{
	// Token: 0x0200060A RID: 1546
	public struct Integrated<T> where T : struct
	{
		// Token: 0x06003164 RID: 12644 RVA: 0x000BD27C File Offset: 0x000BB47C
		public void SetImmediate(ref T value)
		{
			this.begin = (this.end = (this.current = value));
			this.clock.SetImmediate();
		}

		// Token: 0x04001B8D RID: 7053
		[global::System.NonSerialized]
		public global::Facepunch.Procedural.MillisClock clock;

		// Token: 0x04001B8E RID: 7054
		[global::System.NonSerialized]
		public T begin;

		// Token: 0x04001B8F RID: 7055
		[global::System.NonSerialized]
		public T end;

		// Token: 0x04001B90 RID: 7056
		[global::System.NonSerialized]
		public T current;
	}
}

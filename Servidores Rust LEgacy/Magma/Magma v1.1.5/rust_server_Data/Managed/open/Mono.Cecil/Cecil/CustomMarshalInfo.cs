using System;

namespace Mono.Cecil
{
	// Token: 0x02000066 RID: 102
	public sealed class CustomMarshalInfo : global::Mono.Cecil.MarshalInfo
	{
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000A9B1 File Offset: 0x00008BB1
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x0000A9B9 File Offset: 0x00008BB9
		public global::System.Guid Guid
		{
			get
			{
				return this.guid;
			}
			set
			{
				this.guid = value;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000A9C2 File Offset: 0x00008BC2
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000A9CA File Offset: 0x00008BCA
		public string UnmanagedType
		{
			get
			{
				return this.unmanaged_type;
			}
			set
			{
				this.unmanaged_type = value;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000A9D3 File Offset: 0x00008BD3
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x0000A9DB File Offset: 0x00008BDB
		public global::Mono.Cecil.TypeReference ManagedType
		{
			get
			{
				return this.managed_type;
			}
			set
			{
				this.managed_type = value;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0000A9E4 File Offset: 0x00008BE4
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x0000A9EC File Offset: 0x00008BEC
		public string Cookie
		{
			get
			{
				return this.cookie;
			}
			set
			{
				this.cookie = value;
			}
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0000A9F5 File Offset: 0x00008BF5
		public CustomMarshalInfo() : base(global::Mono.Cecil.NativeType.CustomMarshaler)
		{
		}

		// Token: 0x040002C4 RID: 708
		internal global::System.Guid guid;

		// Token: 0x040002C5 RID: 709
		internal string unmanaged_type;

		// Token: 0x040002C6 RID: 710
		internal global::Mono.Cecil.TypeReference managed_type;

		// Token: 0x040002C7 RID: 711
		internal string cookie;
	}
}

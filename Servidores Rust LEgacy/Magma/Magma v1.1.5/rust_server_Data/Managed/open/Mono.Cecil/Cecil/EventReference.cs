using System;

namespace Mono.Cecil
{
	// Token: 0x02000093 RID: 147
	public abstract class EventReference : global::Mono.Cecil.MemberReference
	{
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x0000FB4F File Offset: 0x0000DD4F
		// (set) Token: 0x06000638 RID: 1592 RVA: 0x0000FB57 File Offset: 0x0000DD57
		public global::Mono.Cecil.TypeReference EventType
		{
			get
			{
				return this.event_type;
			}
			set
			{
				this.event_type = value;
			}
		}

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x0000FB60 File Offset: 0x0000DD60
		public override string FullName
		{
			get
			{
				return this.event_type.FullName + " " + base.MemberFullName();
			}
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0000FB7D File Offset: 0x0000DD7D
		protected EventReference(string name, global::Mono.Cecil.TypeReference eventType) : base(name)
		{
			if (eventType == null)
			{
				throw new global::System.ArgumentNullException("eventType");
			}
			this.event_type = eventType;
		}

		// Token: 0x0600063B RID: 1595
		public abstract global::Mono.Cecil.EventDefinition Resolve();

		// Token: 0x040004C7 RID: 1223
		private global::Mono.Cecil.TypeReference event_type;
	}
}

using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000030 RID: 48
	public sealed class ExceptionHandler
	{
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x000084A0 File Offset: 0x000066A0
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x000084A8 File Offset: 0x000066A8
		public global::Mono.Cecil.Cil.Instruction TryStart
		{
			get
			{
				return this.try_start;
			}
			set
			{
				this.try_start = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x000084B1 File Offset: 0x000066B1
		// (set) Token: 0x060002BA RID: 698 RVA: 0x000084B9 File Offset: 0x000066B9
		public global::Mono.Cecil.Cil.Instruction TryEnd
		{
			get
			{
				return this.try_end;
			}
			set
			{
				this.try_end = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060002BB RID: 699 RVA: 0x000084C2 File Offset: 0x000066C2
		// (set) Token: 0x060002BC RID: 700 RVA: 0x000084CA File Offset: 0x000066CA
		public global::Mono.Cecil.Cil.Instruction FilterStart
		{
			get
			{
				return this.filter_start;
			}
			set
			{
				this.filter_start = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060002BD RID: 701 RVA: 0x000084D3 File Offset: 0x000066D3
		// (set) Token: 0x060002BE RID: 702 RVA: 0x000084DB File Offset: 0x000066DB
		public global::Mono.Cecil.Cil.Instruction HandlerStart
		{
			get
			{
				return this.handler_start;
			}
			set
			{
				this.handler_start = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060002BF RID: 703 RVA: 0x000084E4 File Offset: 0x000066E4
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x000084EC File Offset: 0x000066EC
		public global::Mono.Cecil.Cil.Instruction HandlerEnd
		{
			get
			{
				return this.handler_end;
			}
			set
			{
				this.handler_end = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x000084F5 File Offset: 0x000066F5
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x000084FD File Offset: 0x000066FD
		public global::Mono.Cecil.TypeReference CatchType
		{
			get
			{
				return this.catch_type;
			}
			set
			{
				this.catch_type = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x00008506 File Offset: 0x00006706
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x0000850E File Offset: 0x0000670E
		public global::Mono.Cecil.Cil.ExceptionHandlerType HandlerType
		{
			get
			{
				return this.handler_type;
			}
			set
			{
				this.handler_type = value;
			}
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00008517 File Offset: 0x00006717
		public ExceptionHandler(global::Mono.Cecil.Cil.ExceptionHandlerType handlerType)
		{
			this.handler_type = handlerType;
		}

		// Token: 0x040001CF RID: 463
		private global::Mono.Cecil.Cil.Instruction try_start;

		// Token: 0x040001D0 RID: 464
		private global::Mono.Cecil.Cil.Instruction try_end;

		// Token: 0x040001D1 RID: 465
		private global::Mono.Cecil.Cil.Instruction filter_start;

		// Token: 0x040001D2 RID: 466
		private global::Mono.Cecil.Cil.Instruction handler_start;

		// Token: 0x040001D3 RID: 467
		private global::Mono.Cecil.Cil.Instruction handler_end;

		// Token: 0x040001D4 RID: 468
		private global::Mono.Cecil.TypeReference catch_type;

		// Token: 0x040001D5 RID: 469
		private global::Mono.Cecil.Cil.ExceptionHandlerType handler_type;
	}
}

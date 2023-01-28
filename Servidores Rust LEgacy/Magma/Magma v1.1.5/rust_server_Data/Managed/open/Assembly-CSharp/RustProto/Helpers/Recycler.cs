using System;
using Google.ProtocolBuffers;

namespace RustProto.Helpers
{
	// Token: 0x02000237 RID: 567
	public sealed class Recycler<TMessage, TBuilder> : global::System.IDisposable where TMessage : global::Google.ProtocolBuffers.GeneratedMessage<TMessage, TBuilder> where TBuilder : global::Google.ProtocolBuffers.GeneratedBuilder<TMessage, TBuilder>, new()
	{
		// Token: 0x06000F2F RID: 3887 RVA: 0x0003A610 File Offset: 0x00038810
		private Recycler()
		{
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x0003A618 File Offset: 0x00038818
		void global::System.IDisposable.Dispose()
		{
			if (!this.Disposed)
			{
				this.Disposed = true;
				int count;
				global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Count = (count = global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Count) + 1;
				if (count == 0)
				{
					this.Next = null;
					global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Pile = this;
				}
				else
				{
					this.Next = global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Pile;
					global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Pile = this;
				}
				this.OpenCount = 0;
				if (this.Created && !this.Cleared)
				{
					this.Builder.Clear();
					this.Cleared = true;
				}
			}
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x0003A6BC File Offset: 0x000388BC
		public static global::RustProto.Helpers.Recycler<TMessage, TBuilder> Manufacture()
		{
			if (global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Count == 0)
			{
				return new global::RustProto.Helpers.Recycler<TMessage, TBuilder>();
			}
			global::RustProto.Helpers.Recycler<TMessage, TBuilder> pile = global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Pile;
			if (global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Count == 1)
			{
				global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery = default(global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Holding);
			}
			else
			{
				global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Count = global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Count - 1;
				global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Recovery.Pile = pile.Next;
				pile.Next = null;
			}
			pile.Disposed = false;
			return pile;
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x0003A740 File Offset: 0x00038940
		public TBuilder OpenBuilder()
		{
			if (this.OpenCount++ == 0)
			{
				if (!this.Created)
				{
					this.Builder = global::System.Activator.CreateInstance<TBuilder>();
					this.Created = true;
				}
				else
				{
					this.Cleared = false;
				}
			}
			return this.Builder;
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0003A794 File Offset: 0x00038994
		public TBuilder OpenBuilder(TMessage copyFrom)
		{
			TBuilder result = this.OpenBuilder();
			result.MergeFrom(copyFrom);
			return result;
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x0003A7B8 File Offset: 0x000389B8
		public void CloseBuilder(ref TBuilder builder)
		{
			if (this.Disposed)
			{
				throw new global::System.ObjectDisposedException("Recycler");
			}
			if (this.OpenCount == 0)
			{
				throw new global::System.InvalidOperationException("Close was called more than Open for this Recycler");
			}
			if (!object.ReferenceEquals(builder, this.Builder))
			{
				throw new global::System.ArgumentOutOfRangeException("builder", "Was not opened by this recycler");
			}
			builder = (TBuilder)((object)null);
			if (--this.OpenCount == 0 && !this.Cleared)
			{
				this.Builder.Clear();
				this.Cleared = true;
			}
		}

		// Token: 0x040009B0 RID: 2480
		private TBuilder Builder;

		// Token: 0x040009B1 RID: 2481
		private global::RustProto.Helpers.Recycler<TMessage, TBuilder> Next;

		// Token: 0x040009B2 RID: 2482
		private bool Disposed;

		// Token: 0x040009B3 RID: 2483
		private bool Cleared;

		// Token: 0x040009B4 RID: 2484
		private bool Created;

		// Token: 0x040009B5 RID: 2485
		private int OpenCount;

		// Token: 0x040009B6 RID: 2486
		private static global::RustProto.Helpers.Recycler<TMessage, TBuilder>.Holding Recovery;

		// Token: 0x02000238 RID: 568
		private struct Holding
		{
			// Token: 0x040009B7 RID: 2487
			public global::RustProto.Helpers.Recycler<TMessage, TBuilder> Pile;

			// Token: 0x040009B8 RID: 2488
			public int Count;
		}
	}
}

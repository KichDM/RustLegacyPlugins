using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Proto;

namespace RustProto
{
	// Token: 0x02000270 RID: 624
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class GameError : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.GameError, global::RustProto.GameError.Builder>
	{
		// Token: 0x060015E8 RID: 5608 RVA: 0x0004975C File Offset: 0x0004795C
		private GameError()
		{
		}

		// Token: 0x060015E9 RID: 5609 RVA: 0x00049784 File Offset: 0x00047984
		static GameError()
		{
			object.ReferenceEquals(global::RustProto.Proto.Error.Descriptor, null);
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x060015EA RID: 5610 RVA: 0x000497DC File Offset: 0x000479DC
		public static global::RustProto.GameError DefaultInstance
		{
			get
			{
				return global::RustProto.GameError.defaultInstance;
			}
		}

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x060015EB RID: 5611 RVA: 0x000497E4 File Offset: 0x000479E4
		public override global::RustProto.GameError DefaultInstanceForType
		{
			get
			{
				return global::RustProto.GameError.DefaultInstance;
			}
		}

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x060015EC RID: 5612 RVA: 0x000497EC File Offset: 0x000479EC
		protected override global::RustProto.GameError ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x060015ED RID: 5613 RVA: 0x000497F0 File Offset: 0x000479F0
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Error.internal__static_RustProto_GameError__Descriptor;
			}
		}

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x060015EE RID: 5614 RVA: 0x000497F8 File Offset: 0x000479F8
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.GameError, global::RustProto.GameError.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.Error.internal__static_RustProto_GameError__FieldAccessorTable;
			}
		}

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x060015EF RID: 5615 RVA: 0x00049800 File Offset: 0x00047A00
		public bool HasError
		{
			get
			{
				return this.hasError;
			}
		}

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x060015F0 RID: 5616 RVA: 0x00049808 File Offset: 0x00047A08
		public string Error
		{
			get
			{
				return this.error_;
			}
		}

		// Token: 0x17000614 RID: 1556
		// (get) Token: 0x060015F1 RID: 5617 RVA: 0x00049810 File Offset: 0x00047A10
		public bool HasTrace
		{
			get
			{
				return this.hasTrace;
			}
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x060015F2 RID: 5618 RVA: 0x00049818 File Offset: 0x00047A18
		public string Trace
		{
			get
			{
				return this.trace_;
			}
		}

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x060015F3 RID: 5619 RVA: 0x00049820 File Offset: 0x00047A20
		public override bool IsInitialized
		{
			get
			{
				return this.hasError && this.hasTrace;
			}
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x00049840 File Offset: 0x00047A40
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] gameErrorFieldNames = global::RustProto.GameError._gameErrorFieldNames;
			if (this.hasError)
			{
				output.WriteString(1, gameErrorFieldNames[0], this.Error);
			}
			if (this.hasTrace)
			{
				output.WriteString(2, gameErrorFieldNames[1], this.Trace);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x060015F5 RID: 5621 RVA: 0x0004989C File Offset: 0x00047A9C
		public override int SerializedSize
		{
			get
			{
				int num = this.memoizedSerializedSize;
				if (num != -1)
				{
					return num;
				}
				num = 0;
				if (this.hasError)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeStringSize(1, this.Error);
				}
				if (this.hasTrace)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeStringSize(2, this.Trace);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x00049908 File Offset: 0x00047B08
		public static global::RustProto.GameError ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.GameError.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x0004991C File Offset: 0x00047B1C
		public static global::RustProto.GameError ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.GameError.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015F8 RID: 5624 RVA: 0x00049930 File Offset: 0x00047B30
		public static global::RustProto.GameError ParseFrom(byte[] data)
		{
			return global::RustProto.GameError.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x00049944 File Offset: 0x00047B44
		public static global::RustProto.GameError ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.GameError.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x00049958 File Offset: 0x00047B58
		public static global::RustProto.GameError ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.GameError.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x0004996C File Offset: 0x00047B6C
		public static global::RustProto.GameError ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.GameError.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x00049980 File Offset: 0x00047B80
		public static global::RustProto.GameError ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.GameError.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x00049994 File Offset: 0x00047B94
		public static global::RustProto.GameError ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.GameError.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x000499A8 File Offset: 0x00047BA8
		public static global::RustProto.GameError ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.GameError.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x000499BC File Offset: 0x00047BBC
		public static global::RustProto.GameError ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.GameError.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x000499D0 File Offset: 0x00047BD0
		private global::RustProto.GameError MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x000499D4 File Offset: 0x00047BD4
		public static global::RustProto.GameError.Builder CreateBuilder()
		{
			return new global::RustProto.GameError.Builder();
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x000499DC File Offset: 0x00047BDC
		public override global::RustProto.GameError.Builder ToBuilder()
		{
			return global::RustProto.GameError.CreateBuilder(this);
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x000499E4 File Offset: 0x00047BE4
		public override global::RustProto.GameError.Builder CreateBuilderForType()
		{
			return new global::RustProto.GameError.Builder();
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x000499EC File Offset: 0x00047BEC
		public static global::RustProto.GameError.Builder CreateBuilder(global::RustProto.GameError prototype)
		{
			return new global::RustProto.GameError.Builder(prototype);
		}

		// Token: 0x04000B6C RID: 2924
		public const int ErrorFieldNumber = 1;

		// Token: 0x04000B6D RID: 2925
		public const int TraceFieldNumber = 2;

		// Token: 0x04000B6E RID: 2926
		private static readonly global::RustProto.GameError defaultInstance = new global::RustProto.GameError().MakeReadOnly();

		// Token: 0x04000B6F RID: 2927
		private static readonly string[] _gameErrorFieldNames = new string[]
		{
			"error",
			"trace"
		};

		// Token: 0x04000B70 RID: 2928
		private static readonly uint[] _gameErrorFieldTags = new uint[]
		{
			0xAU,
			0x12U
		};

		// Token: 0x04000B71 RID: 2929
		private bool hasError;

		// Token: 0x04000B72 RID: 2930
		private string error_ = string.Empty;

		// Token: 0x04000B73 RID: 2931
		private bool hasTrace;

		// Token: 0x04000B74 RID: 2932
		private string trace_ = string.Empty;

		// Token: 0x04000B75 RID: 2933
		private int memoizedSerializedSize = -1;

		// Token: 0x02000271 RID: 625
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.GameError, global::RustProto.GameError.Builder>
		{
			// Token: 0x06001605 RID: 5637 RVA: 0x000499F4 File Offset: 0x00047BF4
			public Builder()
			{
				this.result = global::RustProto.GameError.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001606 RID: 5638 RVA: 0x00049A10 File Offset: 0x00047C10
			internal Builder(global::RustProto.GameError cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000618 RID: 1560
			// (get) Token: 0x06001607 RID: 5639 RVA: 0x00049A28 File Offset: 0x00047C28
			protected override global::RustProto.GameError.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001608 RID: 5640 RVA: 0x00049A2C File Offset: 0x00047C2C
			private global::RustProto.GameError PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.GameError other = this.result;
					this.result = new global::RustProto.GameError();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000619 RID: 1561
			// (get) Token: 0x06001609 RID: 5641 RVA: 0x00049A6C File Offset: 0x00047C6C
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x1700061A RID: 1562
			// (get) Token: 0x0600160A RID: 5642 RVA: 0x00049A7C File Offset: 0x00047C7C
			protected override global::RustProto.GameError MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x0600160B RID: 5643 RVA: 0x00049A84 File Offset: 0x00047C84
			public override global::RustProto.GameError.Builder Clear()
			{
				this.result = global::RustProto.GameError.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x0600160C RID: 5644 RVA: 0x00049A9C File Offset: 0x00047C9C
			public override global::RustProto.GameError.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.GameError.Builder(this.result);
				}
				return new global::RustProto.GameError.Builder().MergeFrom(this.result);
			}

			// Token: 0x1700061B RID: 1563
			// (get) Token: 0x0600160D RID: 5645 RVA: 0x00049AC8 File Offset: 0x00047CC8
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.GameError.Descriptor;
				}
			}

			// Token: 0x1700061C RID: 1564
			// (get) Token: 0x0600160E RID: 5646 RVA: 0x00049AD0 File Offset: 0x00047CD0
			public override global::RustProto.GameError DefaultInstanceForType
			{
				get
				{
					return global::RustProto.GameError.DefaultInstance;
				}
			}

			// Token: 0x0600160F RID: 5647 RVA: 0x00049AD8 File Offset: 0x00047CD8
			public override global::RustProto.GameError BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001610 RID: 5648 RVA: 0x00049B0C File Offset: 0x00047D0C
			public override global::RustProto.GameError.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.GameError)
				{
					return this.MergeFrom((global::RustProto.GameError)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001611 RID: 5649 RVA: 0x00049B30 File Offset: 0x00047D30
			public override global::RustProto.GameError.Builder MergeFrom(global::RustProto.GameError other)
			{
				if (other == global::RustProto.GameError.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasError)
				{
					this.Error = other.Error;
				}
				if (other.HasTrace)
				{
					this.Trace = other.Trace;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001612 RID: 5650 RVA: 0x00049B90 File Offset: 0x00047D90
			public override global::RustProto.GameError.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001613 RID: 5651 RVA: 0x00049BA0 File Offset: 0x00047DA0
			public override global::RustProto.GameError.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.GameError._gameErrorFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.GameError._gameErrorFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 0xAU)
					{
						if (num3 != 0x12U)
						{
							if (global::Google.ProtocolBuffers.WireFormat.IsEndGroupTag(num))
							{
								if (builder != null)
								{
									this.UnknownFields = builder.Build();
								}
								return this;
							}
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
						}
						else
						{
							this.result.hasTrace = input.ReadString(ref this.result.trace_);
						}
					}
					else
					{
						this.result.hasError = input.ReadString(ref this.result.error_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x1700061D RID: 1565
			// (get) Token: 0x06001614 RID: 5652 RVA: 0x00049CE0 File Offset: 0x00047EE0
			public bool HasError
			{
				get
				{
					return this.result.hasError;
				}
			}

			// Token: 0x1700061E RID: 1566
			// (get) Token: 0x06001615 RID: 5653 RVA: 0x00049CF0 File Offset: 0x00047EF0
			// (set) Token: 0x06001616 RID: 5654 RVA: 0x00049D00 File Offset: 0x00047F00
			public string Error
			{
				get
				{
					return this.result.Error;
				}
				set
				{
					this.SetError(value);
				}
			}

			// Token: 0x06001617 RID: 5655 RVA: 0x00049D0C File Offset: 0x00047F0C
			public global::RustProto.GameError.Builder SetError(string value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasError = true;
				this.result.error_ = value;
				return this;
			}

			// Token: 0x06001618 RID: 5656 RVA: 0x00049D3C File Offset: 0x00047F3C
			public global::RustProto.GameError.Builder ClearError()
			{
				this.PrepareBuilder();
				this.result.hasError = false;
				this.result.error_ = string.Empty;
				return this;
			}

			// Token: 0x1700061F RID: 1567
			// (get) Token: 0x06001619 RID: 5657 RVA: 0x00049D70 File Offset: 0x00047F70
			public bool HasTrace
			{
				get
				{
					return this.result.hasTrace;
				}
			}

			// Token: 0x17000620 RID: 1568
			// (get) Token: 0x0600161A RID: 5658 RVA: 0x00049D80 File Offset: 0x00047F80
			// (set) Token: 0x0600161B RID: 5659 RVA: 0x00049D90 File Offset: 0x00047F90
			public string Trace
			{
				get
				{
					return this.result.Trace;
				}
				set
				{
					this.SetTrace(value);
				}
			}

			// Token: 0x0600161C RID: 5660 RVA: 0x00049D9C File Offset: 0x00047F9C
			public global::RustProto.GameError.Builder SetTrace(string value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasTrace = true;
				this.result.trace_ = value;
				return this;
			}

			// Token: 0x0600161D RID: 5661 RVA: 0x00049DCC File Offset: 0x00047FCC
			public global::RustProto.GameError.Builder ClearTrace()
			{
				this.PrepareBuilder();
				this.result.hasTrace = false;
				this.result.trace_ = string.Empty;
				return this;
			}

			// Token: 0x04000B76 RID: 2934
			private bool resultIsReadOnly;

			// Token: 0x04000B77 RID: 2935
			private global::RustProto.GameError result;
		}
	}
}

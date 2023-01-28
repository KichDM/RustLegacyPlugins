using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Proto;

namespace RustProto
{
	// Token: 0x0200026E RID: 622
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class Error : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.Error, global::RustProto.Error.Builder>
	{
		// Token: 0x060015B2 RID: 5554 RVA: 0x000490B8 File Offset: 0x000472B8
		private Error()
		{
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x000490E0 File Offset: 0x000472E0
		static Error()
		{
			object.ReferenceEquals(global::RustProto.Proto.Error.Descriptor, null);
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x060015B4 RID: 5556 RVA: 0x00049138 File Offset: 0x00047338
		public static global::RustProto.Error DefaultInstance
		{
			get
			{
				return global::RustProto.Error.defaultInstance;
			}
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x060015B5 RID: 5557 RVA: 0x00049140 File Offset: 0x00047340
		public override global::RustProto.Error DefaultInstanceForType
		{
			get
			{
				return global::RustProto.Error.DefaultInstance;
			}
		}

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x060015B6 RID: 5558 RVA: 0x00049148 File Offset: 0x00047348
		protected override global::RustProto.Error ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x060015B7 RID: 5559 RVA: 0x0004914C File Offset: 0x0004734C
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Error.internal__static_RustProto_Error__Descriptor;
			}
		}

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x060015B8 RID: 5560 RVA: 0x00049154 File Offset: 0x00047354
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Error, global::RustProto.Error.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.Error.internal__static_RustProto_Error__FieldAccessorTable;
			}
		}

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x060015B9 RID: 5561 RVA: 0x0004915C File Offset: 0x0004735C
		public bool HasStatus
		{
			get
			{
				return this.hasStatus;
			}
		}

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x060015BA RID: 5562 RVA: 0x00049164 File Offset: 0x00047364
		public string Status
		{
			get
			{
				return this.status_;
			}
		}

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x060015BB RID: 5563 RVA: 0x0004916C File Offset: 0x0004736C
		public bool HasMessage
		{
			get
			{
				return this.hasMessage;
			}
		}

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x060015BC RID: 5564 RVA: 0x00049174 File Offset: 0x00047374
		public string Message
		{
			get
			{
				return this.message_;
			}
		}

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x060015BD RID: 5565 RVA: 0x0004917C File Offset: 0x0004737C
		public override bool IsInitialized
		{
			get
			{
				return this.hasStatus && this.hasMessage;
			}
		}

		// Token: 0x060015BE RID: 5566 RVA: 0x0004919C File Offset: 0x0004739C
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] errorFieldNames = global::RustProto.Error._errorFieldNames;
			if (this.hasStatus)
			{
				output.WriteString(1, errorFieldNames[1], this.Status);
			}
			if (this.hasMessage)
			{
				output.WriteString(2, errorFieldNames[0], this.Message);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x060015BF RID: 5567 RVA: 0x000491F8 File Offset: 0x000473F8
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
				if (this.hasStatus)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeStringSize(1, this.Status);
				}
				if (this.hasMessage)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeStringSize(2, this.Message);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x00049264 File Offset: 0x00047464
		public static global::RustProto.Error ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.Error.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060015C1 RID: 5569 RVA: 0x00049278 File Offset: 0x00047478
		public static global::RustProto.Error ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Error.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015C2 RID: 5570 RVA: 0x0004928C File Offset: 0x0004748C
		public static global::RustProto.Error ParseFrom(byte[] data)
		{
			return global::RustProto.Error.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x000492A0 File Offset: 0x000474A0
		public static global::RustProto.Error ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Error.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015C4 RID: 5572 RVA: 0x000492B4 File Offset: 0x000474B4
		public static global::RustProto.Error ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Error.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x000492C8 File Offset: 0x000474C8
		public static global::RustProto.Error ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Error.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x000492DC File Offset: 0x000474DC
		public static global::RustProto.Error ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.Error.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060015C7 RID: 5575 RVA: 0x000492F0 File Offset: 0x000474F0
		public static global::RustProto.Error ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Error.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015C8 RID: 5576 RVA: 0x00049304 File Offset: 0x00047504
		public static global::RustProto.Error ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.Error.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x00049318 File Offset: 0x00047518
		public static global::RustProto.Error ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.Error.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x0004932C File Offset: 0x0004752C
		private global::RustProto.Error MakeReadOnly()
		{
			return this;
		}

		// Token: 0x060015CB RID: 5579 RVA: 0x00049330 File Offset: 0x00047530
		public static global::RustProto.Error.Builder CreateBuilder()
		{
			return new global::RustProto.Error.Builder();
		}

		// Token: 0x060015CC RID: 5580 RVA: 0x00049338 File Offset: 0x00047538
		public override global::RustProto.Error.Builder ToBuilder()
		{
			return global::RustProto.Error.CreateBuilder(this);
		}

		// Token: 0x060015CD RID: 5581 RVA: 0x00049340 File Offset: 0x00047540
		public override global::RustProto.Error.Builder CreateBuilderForType()
		{
			return new global::RustProto.Error.Builder();
		}

		// Token: 0x060015CE RID: 5582 RVA: 0x00049348 File Offset: 0x00047548
		public static global::RustProto.Error.Builder CreateBuilder(global::RustProto.Error prototype)
		{
			return new global::RustProto.Error.Builder(prototype);
		}

		// Token: 0x04000B60 RID: 2912
		public const int StatusFieldNumber = 1;

		// Token: 0x04000B61 RID: 2913
		public const int MessageFieldNumber = 2;

		// Token: 0x04000B62 RID: 2914
		private static readonly global::RustProto.Error defaultInstance = new global::RustProto.Error().MakeReadOnly();

		// Token: 0x04000B63 RID: 2915
		private static readonly string[] _errorFieldNames = new string[]
		{
			"message",
			"status"
		};

		// Token: 0x04000B64 RID: 2916
		private static readonly uint[] _errorFieldTags = new uint[]
		{
			0x12U,
			0xAU
		};

		// Token: 0x04000B65 RID: 2917
		private bool hasStatus;

		// Token: 0x04000B66 RID: 2918
		private string status_ = string.Empty;

		// Token: 0x04000B67 RID: 2919
		private bool hasMessage;

		// Token: 0x04000B68 RID: 2920
		private string message_ = string.Empty;

		// Token: 0x04000B69 RID: 2921
		private int memoizedSerializedSize = -1;

		// Token: 0x0200026F RID: 623
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.Error, global::RustProto.Error.Builder>
		{
			// Token: 0x060015CF RID: 5583 RVA: 0x00049350 File Offset: 0x00047550
			public Builder()
			{
				this.result = global::RustProto.Error.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x060015D0 RID: 5584 RVA: 0x0004936C File Offset: 0x0004756C
			internal Builder(global::RustProto.Error cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000604 RID: 1540
			// (get) Token: 0x060015D1 RID: 5585 RVA: 0x00049384 File Offset: 0x00047584
			protected override global::RustProto.Error.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060015D2 RID: 5586 RVA: 0x00049388 File Offset: 0x00047588
			private global::RustProto.Error PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.Error other = this.result;
					this.result = new global::RustProto.Error();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000605 RID: 1541
			// (get) Token: 0x060015D3 RID: 5587 RVA: 0x000493C8 File Offset: 0x000475C8
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000606 RID: 1542
			// (get) Token: 0x060015D4 RID: 5588 RVA: 0x000493D8 File Offset: 0x000475D8
			protected override global::RustProto.Error MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x060015D5 RID: 5589 RVA: 0x000493E0 File Offset: 0x000475E0
			public override global::RustProto.Error.Builder Clear()
			{
				this.result = global::RustProto.Error.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x060015D6 RID: 5590 RVA: 0x000493F8 File Offset: 0x000475F8
			public override global::RustProto.Error.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.Error.Builder(this.result);
				}
				return new global::RustProto.Error.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000607 RID: 1543
			// (get) Token: 0x060015D7 RID: 5591 RVA: 0x00049424 File Offset: 0x00047624
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.Error.Descriptor;
				}
			}

			// Token: 0x17000608 RID: 1544
			// (get) Token: 0x060015D8 RID: 5592 RVA: 0x0004942C File Offset: 0x0004762C
			public override global::RustProto.Error DefaultInstanceForType
			{
				get
				{
					return global::RustProto.Error.DefaultInstance;
				}
			}

			// Token: 0x060015D9 RID: 5593 RVA: 0x00049434 File Offset: 0x00047634
			public override global::RustProto.Error BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x060015DA RID: 5594 RVA: 0x00049468 File Offset: 0x00047668
			public override global::RustProto.Error.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.Error)
				{
					return this.MergeFrom((global::RustProto.Error)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x060015DB RID: 5595 RVA: 0x0004948C File Offset: 0x0004768C
			public override global::RustProto.Error.Builder MergeFrom(global::RustProto.Error other)
			{
				if (other == global::RustProto.Error.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasStatus)
				{
					this.Status = other.Status;
				}
				if (other.HasMessage)
				{
					this.Message = other.Message;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x060015DC RID: 5596 RVA: 0x000494EC File Offset: 0x000476EC
			public override global::RustProto.Error.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x060015DD RID: 5597 RVA: 0x000494FC File Offset: 0x000476FC
			public override global::RustProto.Error.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.Error._errorFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.Error._errorFieldTags[num2];
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
							this.result.hasMessage = input.ReadString(ref this.result.message_);
						}
					}
					else
					{
						this.result.hasStatus = input.ReadString(ref this.result.status_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x17000609 RID: 1545
			// (get) Token: 0x060015DE RID: 5598 RVA: 0x0004963C File Offset: 0x0004783C
			public bool HasStatus
			{
				get
				{
					return this.result.hasStatus;
				}
			}

			// Token: 0x1700060A RID: 1546
			// (get) Token: 0x060015DF RID: 5599 RVA: 0x0004964C File Offset: 0x0004784C
			// (set) Token: 0x060015E0 RID: 5600 RVA: 0x0004965C File Offset: 0x0004785C
			public string Status
			{
				get
				{
					return this.result.Status;
				}
				set
				{
					this.SetStatus(value);
				}
			}

			// Token: 0x060015E1 RID: 5601 RVA: 0x00049668 File Offset: 0x00047868
			public global::RustProto.Error.Builder SetStatus(string value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasStatus = true;
				this.result.status_ = value;
				return this;
			}

			// Token: 0x060015E2 RID: 5602 RVA: 0x00049698 File Offset: 0x00047898
			public global::RustProto.Error.Builder ClearStatus()
			{
				this.PrepareBuilder();
				this.result.hasStatus = false;
				this.result.status_ = string.Empty;
				return this;
			}

			// Token: 0x1700060B RID: 1547
			// (get) Token: 0x060015E3 RID: 5603 RVA: 0x000496CC File Offset: 0x000478CC
			public bool HasMessage
			{
				get
				{
					return this.result.hasMessage;
				}
			}

			// Token: 0x1700060C RID: 1548
			// (get) Token: 0x060015E4 RID: 5604 RVA: 0x000496DC File Offset: 0x000478DC
			// (set) Token: 0x060015E5 RID: 5605 RVA: 0x000496EC File Offset: 0x000478EC
			public string Message
			{
				get
				{
					return this.result.Message;
				}
				set
				{
					this.SetMessage(value);
				}
			}

			// Token: 0x060015E6 RID: 5606 RVA: 0x000496F8 File Offset: 0x000478F8
			public global::RustProto.Error.Builder SetMessage(string value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasMessage = true;
				this.result.message_ = value;
				return this;
			}

			// Token: 0x060015E7 RID: 5607 RVA: 0x00049728 File Offset: 0x00047928
			public global::RustProto.Error.Builder ClearMessage()
			{
				this.PrepareBuilder();
				this.result.hasMessage = false;
				this.result.message_ = string.Empty;
				return this;
			}

			// Token: 0x04000B6A RID: 2922
			private bool resultIsReadOnly;

			// Token: 0x04000B6B RID: 2923
			private global::RustProto.Error result;
		}
	}
}

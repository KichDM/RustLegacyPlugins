using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x0200024D RID: 589
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectDeployable : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder>
	{
		// Token: 0x060012A7 RID: 4775 RVA: 0x00043090 File Offset: 0x00041290
		private objectDeployable()
		{
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x000430A0 File Offset: 0x000412A0
		static objectDeployable()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x000430F8 File Offset: 0x000412F8
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder>.Manufacture();
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060012AA RID: 4778 RVA: 0x00043100 File Offset: 0x00041300
		public static global::RustProto.objectDeployable DefaultInstance
		{
			get
			{
				return global::RustProto.objectDeployable.defaultInstance;
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060012AB RID: 4779 RVA: 0x00043108 File Offset: 0x00041308
		public override global::RustProto.objectDeployable DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectDeployable.DefaultInstance;
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060012AC RID: 4780 RVA: 0x00043110 File Offset: 0x00041310
		protected override global::RustProto.objectDeployable ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060012AD RID: 4781 RVA: 0x00043114 File Offset: 0x00041314
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectDeployable__Descriptor;
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x060012AE RID: 4782 RVA: 0x0004311C File Offset: 0x0004131C
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectDeployable__FieldAccessorTable;
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x060012AF RID: 4783 RVA: 0x00043124 File Offset: 0x00041324
		public bool HasCreatorID
		{
			get
			{
				return this.hasCreatorID;
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x060012B0 RID: 4784 RVA: 0x0004312C File Offset: 0x0004132C
		[global::System.CLSCompliant(false)]
		public ulong CreatorID
		{
			get
			{
				return this.creatorID_;
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x060012B1 RID: 4785 RVA: 0x00043134 File Offset: 0x00041334
		public bool HasOwnerID
		{
			get
			{
				return this.hasOwnerID;
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x060012B2 RID: 4786 RVA: 0x0004313C File Offset: 0x0004133C
		[global::System.CLSCompliant(false)]
		public ulong OwnerID
		{
			get
			{
				return this.ownerID_;
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060012B3 RID: 4787 RVA: 0x00043144 File Offset: 0x00041344
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00043148 File Offset: 0x00041348
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectDeployableFieldNames = global::RustProto.objectDeployable._objectDeployableFieldNames;
			if (this.hasCreatorID)
			{
				output.WriteUInt64(1, objectDeployableFieldNames[0], this.CreatorID);
			}
			if (this.hasOwnerID)
			{
				output.WriteUInt64(2, objectDeployableFieldNames[1], this.OwnerID);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060012B5 RID: 4789 RVA: 0x000431A4 File Offset: 0x000413A4
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
				if (this.hasCreatorID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeUInt64Size(1, this.CreatorID);
				}
				if (this.hasOwnerID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeUInt64Size(2, this.OwnerID);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060012B6 RID: 4790 RVA: 0x00043210 File Offset: 0x00041410
		public static global::RustProto.objectDeployable ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060012B7 RID: 4791 RVA: 0x00043224 File Offset: 0x00041424
		public static global::RustProto.objectDeployable ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012B8 RID: 4792 RVA: 0x00043238 File Offset: 0x00041438
		public static global::RustProto.objectDeployable ParseFrom(byte[] data)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x0004324C File Offset: 0x0004144C
		public static global::RustProto.objectDeployable ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012BA RID: 4794 RVA: 0x00043260 File Offset: 0x00041460
		public static global::RustProto.objectDeployable ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060012BB RID: 4795 RVA: 0x00043274 File Offset: 0x00041474
		public static global::RustProto.objectDeployable ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x00043288 File Offset: 0x00041488
		public static global::RustProto.objectDeployable ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x0004329C File Offset: 0x0004149C
		public static global::RustProto.objectDeployable ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x000432B0 File Offset: 0x000414B0
		public static global::RustProto.objectDeployable ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x000432C4 File Offset: 0x000414C4
		public static global::RustProto.objectDeployable ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDeployable.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x000432D8 File Offset: 0x000414D8
		private global::RustProto.objectDeployable MakeReadOnly()
		{
			return this;
		}

		// Token: 0x060012C1 RID: 4801 RVA: 0x000432DC File Offset: 0x000414DC
		public static global::RustProto.objectDeployable.Builder CreateBuilder()
		{
			return new global::RustProto.objectDeployable.Builder();
		}

		// Token: 0x060012C2 RID: 4802 RVA: 0x000432E4 File Offset: 0x000414E4
		public override global::RustProto.objectDeployable.Builder ToBuilder()
		{
			return global::RustProto.objectDeployable.CreateBuilder(this);
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x000432EC File Offset: 0x000414EC
		public override global::RustProto.objectDeployable.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectDeployable.Builder();
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x000432F4 File Offset: 0x000414F4
		public static global::RustProto.objectDeployable.Builder CreateBuilder(global::RustProto.objectDeployable prototype)
		{
			return new global::RustProto.objectDeployable.Builder(prototype);
		}

		// Token: 0x04000A95 RID: 2709
		public const int CreatorIDFieldNumber = 1;

		// Token: 0x04000A96 RID: 2710
		public const int OwnerIDFieldNumber = 2;

		// Token: 0x04000A97 RID: 2711
		private static readonly global::RustProto.objectDeployable defaultInstance = new global::RustProto.objectDeployable().MakeReadOnly();

		// Token: 0x04000A98 RID: 2712
		private static readonly string[] _objectDeployableFieldNames = new string[]
		{
			"CreatorID",
			"OwnerID"
		};

		// Token: 0x04000A99 RID: 2713
		private static readonly uint[] _objectDeployableFieldTags = new uint[]
		{
			8U,
			0x10U
		};

		// Token: 0x04000A9A RID: 2714
		private bool hasCreatorID;

		// Token: 0x04000A9B RID: 2715
		private ulong creatorID_;

		// Token: 0x04000A9C RID: 2716
		private bool hasOwnerID;

		// Token: 0x04000A9D RID: 2717
		private ulong ownerID_;

		// Token: 0x04000A9E RID: 2718
		private int memoizedSerializedSize = -1;

		// Token: 0x0200024E RID: 590
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder>
		{
			// Token: 0x060012C5 RID: 4805 RVA: 0x000432FC File Offset: 0x000414FC
			public Builder()
			{
				this.result = global::RustProto.objectDeployable.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x060012C6 RID: 4806 RVA: 0x00043318 File Offset: 0x00041518
			internal Builder(global::RustProto.objectDeployable cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x170004EC RID: 1260
			// (get) Token: 0x060012C7 RID: 4807 RVA: 0x00043330 File Offset: 0x00041530
			protected override global::RustProto.objectDeployable.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060012C8 RID: 4808 RVA: 0x00043334 File Offset: 0x00041534
			private global::RustProto.objectDeployable PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectDeployable other = this.result;
					this.result = new global::RustProto.objectDeployable();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170004ED RID: 1261
			// (get) Token: 0x060012C9 RID: 4809 RVA: 0x00043374 File Offset: 0x00041574
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170004EE RID: 1262
			// (get) Token: 0x060012CA RID: 4810 RVA: 0x00043384 File Offset: 0x00041584
			protected override global::RustProto.objectDeployable MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x060012CB RID: 4811 RVA: 0x0004338C File Offset: 0x0004158C
			public override global::RustProto.objectDeployable.Builder Clear()
			{
				this.result = global::RustProto.objectDeployable.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x060012CC RID: 4812 RVA: 0x000433A4 File Offset: 0x000415A4
			public override global::RustProto.objectDeployable.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectDeployable.Builder(this.result);
				}
				return new global::RustProto.objectDeployable.Builder().MergeFrom(this.result);
			}

			// Token: 0x170004EF RID: 1263
			// (get) Token: 0x060012CD RID: 4813 RVA: 0x000433D0 File Offset: 0x000415D0
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectDeployable.Descriptor;
				}
			}

			// Token: 0x170004F0 RID: 1264
			// (get) Token: 0x060012CE RID: 4814 RVA: 0x000433D8 File Offset: 0x000415D8
			public override global::RustProto.objectDeployable DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectDeployable.DefaultInstance;
				}
			}

			// Token: 0x060012CF RID: 4815 RVA: 0x000433E0 File Offset: 0x000415E0
			public override global::RustProto.objectDeployable BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x060012D0 RID: 4816 RVA: 0x00043414 File Offset: 0x00041614
			public override global::RustProto.objectDeployable.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectDeployable)
				{
					return this.MergeFrom((global::RustProto.objectDeployable)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x060012D1 RID: 4817 RVA: 0x00043438 File Offset: 0x00041638
			public override global::RustProto.objectDeployable.Builder MergeFrom(global::RustProto.objectDeployable other)
			{
				if (other == global::RustProto.objectDeployable.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasCreatorID)
				{
					this.CreatorID = other.CreatorID;
				}
				if (other.HasOwnerID)
				{
					this.OwnerID = other.OwnerID;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x060012D2 RID: 4818 RVA: 0x00043498 File Offset: 0x00041698
			public override global::RustProto.objectDeployable.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x060012D3 RID: 4819 RVA: 0x000434A8 File Offset: 0x000416A8
			public override global::RustProto.objectDeployable.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectDeployable._objectDeployableFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectDeployable._objectDeployableFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 8U)
					{
						if (num3 != 0x10U)
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
							this.result.hasOwnerID = input.ReadUInt64(ref this.result.ownerID_);
						}
					}
					else
					{
						this.result.hasCreatorID = input.ReadUInt64(ref this.result.creatorID_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x170004F1 RID: 1265
			// (get) Token: 0x060012D4 RID: 4820 RVA: 0x000435E4 File Offset: 0x000417E4
			public bool HasCreatorID
			{
				get
				{
					return this.result.hasCreatorID;
				}
			}

			// Token: 0x170004F2 RID: 1266
			// (get) Token: 0x060012D5 RID: 4821 RVA: 0x000435F4 File Offset: 0x000417F4
			// (set) Token: 0x060012D6 RID: 4822 RVA: 0x00043604 File Offset: 0x00041804
			[global::System.CLSCompliant(false)]
			public ulong CreatorID
			{
				get
				{
					return this.result.CreatorID;
				}
				set
				{
					this.SetCreatorID(value);
				}
			}

			// Token: 0x060012D7 RID: 4823 RVA: 0x00043610 File Offset: 0x00041810
			[global::System.CLSCompliant(false)]
			public global::RustProto.objectDeployable.Builder SetCreatorID(ulong value)
			{
				this.PrepareBuilder();
				this.result.hasCreatorID = true;
				this.result.creatorID_ = value;
				return this;
			}

			// Token: 0x060012D8 RID: 4824 RVA: 0x00043640 File Offset: 0x00041840
			public global::RustProto.objectDeployable.Builder ClearCreatorID()
			{
				this.PrepareBuilder();
				this.result.hasCreatorID = false;
				this.result.creatorID_ = 0UL;
				return this;
			}

			// Token: 0x170004F3 RID: 1267
			// (get) Token: 0x060012D9 RID: 4825 RVA: 0x00043664 File Offset: 0x00041864
			public bool HasOwnerID
			{
				get
				{
					return this.result.hasOwnerID;
				}
			}

			// Token: 0x170004F4 RID: 1268
			// (get) Token: 0x060012DA RID: 4826 RVA: 0x00043674 File Offset: 0x00041874
			// (set) Token: 0x060012DB RID: 4827 RVA: 0x00043684 File Offset: 0x00041884
			[global::System.CLSCompliant(false)]
			public ulong OwnerID
			{
				get
				{
					return this.result.OwnerID;
				}
				set
				{
					this.SetOwnerID(value);
				}
			}

			// Token: 0x060012DC RID: 4828 RVA: 0x00043690 File Offset: 0x00041890
			[global::System.CLSCompliant(false)]
			public global::RustProto.objectDeployable.Builder SetOwnerID(ulong value)
			{
				this.PrepareBuilder();
				this.result.hasOwnerID = true;
				this.result.ownerID_ = value;
				return this;
			}

			// Token: 0x060012DD RID: 4829 RVA: 0x000436C0 File Offset: 0x000418C0
			public global::RustProto.objectDeployable.Builder ClearOwnerID()
			{
				this.PrepareBuilder();
				this.result.hasOwnerID = false;
				this.result.ownerID_ = 0UL;
				return this;
			}

			// Token: 0x04000A9F RID: 2719
			private bool resultIsReadOnly;

			// Token: 0x04000AA0 RID: 2720
			private global::RustProto.objectDeployable result;
		}
	}
}

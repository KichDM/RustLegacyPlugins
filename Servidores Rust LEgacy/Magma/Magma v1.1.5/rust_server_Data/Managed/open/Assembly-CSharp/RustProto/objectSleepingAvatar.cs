using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x0200024F RID: 591
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectSleepingAvatar : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder>
	{
		// Token: 0x060012DE RID: 4830 RVA: 0x000436E4 File Offset: 0x000418E4
		private objectSleepingAvatar()
		{
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x000436F4 File Offset: 0x000418F4
		static objectSleepingAvatar()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x00043770 File Offset: 0x00041970
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder>.Manufacture();
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x00043778 File Offset: 0x00041978
		public static global::RustProto.objectSleepingAvatar DefaultInstance
		{
			get
			{
				return global::RustProto.objectSleepingAvatar.defaultInstance;
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x060012E2 RID: 4834 RVA: 0x00043780 File Offset: 0x00041980
		public override global::RustProto.objectSleepingAvatar DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectSleepingAvatar.DefaultInstance;
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x060012E3 RID: 4835 RVA: 0x00043788 File Offset: 0x00041988
		protected override global::RustProto.objectSleepingAvatar ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x060012E4 RID: 4836 RVA: 0x0004378C File Offset: 0x0004198C
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectSleepingAvatar__Descriptor;
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x00043794 File Offset: 0x00041994
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectSleepingAvatar__FieldAccessorTable;
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x060012E6 RID: 4838 RVA: 0x0004379C File Offset: 0x0004199C
		public bool HasFootArmor
		{
			get
			{
				return this.hasFootArmor;
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x000437A4 File Offset: 0x000419A4
		public int FootArmor
		{
			get
			{
				return this.footArmor_;
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x060012E8 RID: 4840 RVA: 0x000437AC File Offset: 0x000419AC
		public bool HasLegArmor
		{
			get
			{
				return this.hasLegArmor;
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x060012E9 RID: 4841 RVA: 0x000437B4 File Offset: 0x000419B4
		public int LegArmor
		{
			get
			{
				return this.legArmor_;
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x060012EA RID: 4842 RVA: 0x000437BC File Offset: 0x000419BC
		public bool HasTorsoArmor
		{
			get
			{
				return this.hasTorsoArmor;
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x060012EB RID: 4843 RVA: 0x000437C4 File Offset: 0x000419C4
		public int TorsoArmor
		{
			get
			{
				return this.torsoArmor_;
			}
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x060012EC RID: 4844 RVA: 0x000437CC File Offset: 0x000419CC
		public bool HasHeadArmor
		{
			get
			{
				return this.hasHeadArmor;
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x060012ED RID: 4845 RVA: 0x000437D4 File Offset: 0x000419D4
		public int HeadArmor
		{
			get
			{
				return this.headArmor_;
			}
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x060012EE RID: 4846 RVA: 0x000437DC File Offset: 0x000419DC
		public bool HasTimestamp
		{
			get
			{
				return this.hasTimestamp;
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x060012EF RID: 4847 RVA: 0x000437E4 File Offset: 0x000419E4
		public int Timestamp
		{
			get
			{
				return this.timestamp_;
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x060012F0 RID: 4848 RVA: 0x000437EC File Offset: 0x000419EC
		public bool HasVitals
		{
			get
			{
				return this.hasVitals;
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x060012F1 RID: 4849 RVA: 0x000437F4 File Offset: 0x000419F4
		public global::RustProto.Vitals Vitals
		{
			get
			{
				return this.vitals_ ?? global::RustProto.Vitals.DefaultInstance;
			}
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x060012F2 RID: 4850 RVA: 0x00043808 File Offset: 0x00041A08
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x0004380C File Offset: 0x00041A0C
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectSleepingAvatarFieldNames = global::RustProto.objectSleepingAvatar._objectSleepingAvatarFieldNames;
			if (this.hasFootArmor)
			{
				output.WriteInt32(1, objectSleepingAvatarFieldNames[0], this.FootArmor);
			}
			if (this.hasLegArmor)
			{
				output.WriteInt32(2, objectSleepingAvatarFieldNames[2], this.LegArmor);
			}
			if (this.hasTorsoArmor)
			{
				output.WriteInt32(3, objectSleepingAvatarFieldNames[4], this.TorsoArmor);
			}
			if (this.hasHeadArmor)
			{
				output.WriteInt32(4, objectSleepingAvatarFieldNames[1], this.HeadArmor);
			}
			if (this.hasTimestamp)
			{
				output.WriteInt32(5, objectSleepingAvatarFieldNames[3], this.Timestamp);
			}
			if (this.hasVitals)
			{
				output.WriteMessage(6, objectSleepingAvatarFieldNames[5], this.Vitals);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x060012F4 RID: 4852 RVA: 0x000438D4 File Offset: 0x00041AD4
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
				if (this.hasFootArmor)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(1, this.FootArmor);
				}
				if (this.hasLegArmor)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(2, this.LegArmor);
				}
				if (this.hasTorsoArmor)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(3, this.TorsoArmor);
				}
				if (this.hasHeadArmor)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(4, this.HeadArmor);
				}
				if (this.hasTimestamp)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(5, this.Timestamp);
				}
				if (this.hasVitals)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(6, this.Vitals);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x000439A8 File Offset: 0x00041BA8
		public static global::RustProto.objectSleepingAvatar ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x000439BC File Offset: 0x00041BBC
		public static global::RustProto.objectSleepingAvatar ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x000439D0 File Offset: 0x00041BD0
		public static global::RustProto.objectSleepingAvatar ParseFrom(byte[] data)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x000439E4 File Offset: 0x00041BE4
		public static global::RustProto.objectSleepingAvatar ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x000439F8 File Offset: 0x00041BF8
		public static global::RustProto.objectSleepingAvatar ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x00043A0C File Offset: 0x00041C0C
		public static global::RustProto.objectSleepingAvatar ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012FB RID: 4859 RVA: 0x00043A20 File Offset: 0x00041C20
		public static global::RustProto.objectSleepingAvatar ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060012FC RID: 4860 RVA: 0x00043A34 File Offset: 0x00041C34
		public static global::RustProto.objectSleepingAvatar ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012FD RID: 4861 RVA: 0x00043A48 File Offset: 0x00041C48
		public static global::RustProto.objectSleepingAvatar ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060012FE RID: 4862 RVA: 0x00043A5C File Offset: 0x00041C5C
		public static global::RustProto.objectSleepingAvatar ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060012FF RID: 4863 RVA: 0x00043A70 File Offset: 0x00041C70
		private global::RustProto.objectSleepingAvatar MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001300 RID: 4864 RVA: 0x00043A74 File Offset: 0x00041C74
		public static global::RustProto.objectSleepingAvatar.Builder CreateBuilder()
		{
			return new global::RustProto.objectSleepingAvatar.Builder();
		}

		// Token: 0x06001301 RID: 4865 RVA: 0x00043A7C File Offset: 0x00041C7C
		public override global::RustProto.objectSleepingAvatar.Builder ToBuilder()
		{
			return global::RustProto.objectSleepingAvatar.CreateBuilder(this);
		}

		// Token: 0x06001302 RID: 4866 RVA: 0x00043A84 File Offset: 0x00041C84
		public override global::RustProto.objectSleepingAvatar.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectSleepingAvatar.Builder();
		}

		// Token: 0x06001303 RID: 4867 RVA: 0x00043A8C File Offset: 0x00041C8C
		public static global::RustProto.objectSleepingAvatar.Builder CreateBuilder(global::RustProto.objectSleepingAvatar prototype)
		{
			return new global::RustProto.objectSleepingAvatar.Builder(prototype);
		}

		// Token: 0x04000AA1 RID: 2721
		public const int FootArmorFieldNumber = 1;

		// Token: 0x04000AA2 RID: 2722
		public const int LegArmorFieldNumber = 2;

		// Token: 0x04000AA3 RID: 2723
		public const int TorsoArmorFieldNumber = 3;

		// Token: 0x04000AA4 RID: 2724
		public const int HeadArmorFieldNumber = 4;

		// Token: 0x04000AA5 RID: 2725
		public const int TimestampFieldNumber = 5;

		// Token: 0x04000AA6 RID: 2726
		public const int VitalsFieldNumber = 6;

		// Token: 0x04000AA7 RID: 2727
		private static readonly global::RustProto.objectSleepingAvatar defaultInstance = new global::RustProto.objectSleepingAvatar().MakeReadOnly();

		// Token: 0x04000AA8 RID: 2728
		private static readonly string[] _objectSleepingAvatarFieldNames = new string[]
		{
			"footArmor",
			"headArmor",
			"legArmor",
			"timestamp",
			"torsoArmor",
			"vitals"
		};

		// Token: 0x04000AA9 RID: 2729
		private static readonly uint[] _objectSleepingAvatarFieldTags = new uint[]
		{
			8U,
			0x20U,
			0x10U,
			0x28U,
			0x18U,
			0x32U
		};

		// Token: 0x04000AAA RID: 2730
		private bool hasFootArmor;

		// Token: 0x04000AAB RID: 2731
		private int footArmor_;

		// Token: 0x04000AAC RID: 2732
		private bool hasLegArmor;

		// Token: 0x04000AAD RID: 2733
		private int legArmor_;

		// Token: 0x04000AAE RID: 2734
		private bool hasTorsoArmor;

		// Token: 0x04000AAF RID: 2735
		private int torsoArmor_;

		// Token: 0x04000AB0 RID: 2736
		private bool hasHeadArmor;

		// Token: 0x04000AB1 RID: 2737
		private int headArmor_;

		// Token: 0x04000AB2 RID: 2738
		private bool hasTimestamp;

		// Token: 0x04000AB3 RID: 2739
		private int timestamp_;

		// Token: 0x04000AB4 RID: 2740
		private bool hasVitals;

		// Token: 0x04000AB5 RID: 2741
		private global::RustProto.Vitals vitals_;

		// Token: 0x04000AB6 RID: 2742
		private int memoizedSerializedSize = -1;

		// Token: 0x02000250 RID: 592
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder>
		{
			// Token: 0x06001304 RID: 4868 RVA: 0x00043A94 File Offset: 0x00041C94
			public Builder()
			{
				this.result = global::RustProto.objectSleepingAvatar.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001305 RID: 4869 RVA: 0x00043AB0 File Offset: 0x00041CB0
			internal Builder(global::RustProto.objectSleepingAvatar cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000508 RID: 1288
			// (get) Token: 0x06001306 RID: 4870 RVA: 0x00043AC8 File Offset: 0x00041CC8
			protected override global::RustProto.objectSleepingAvatar.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001307 RID: 4871 RVA: 0x00043ACC File Offset: 0x00041CCC
			private global::RustProto.objectSleepingAvatar PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectSleepingAvatar other = this.result;
					this.result = new global::RustProto.objectSleepingAvatar();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000509 RID: 1289
			// (get) Token: 0x06001308 RID: 4872 RVA: 0x00043B0C File Offset: 0x00041D0C
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x1700050A RID: 1290
			// (get) Token: 0x06001309 RID: 4873 RVA: 0x00043B1C File Offset: 0x00041D1C
			protected override global::RustProto.objectSleepingAvatar MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x0600130A RID: 4874 RVA: 0x00043B24 File Offset: 0x00041D24
			public override global::RustProto.objectSleepingAvatar.Builder Clear()
			{
				this.result = global::RustProto.objectSleepingAvatar.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x0600130B RID: 4875 RVA: 0x00043B3C File Offset: 0x00041D3C
			public override global::RustProto.objectSleepingAvatar.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectSleepingAvatar.Builder(this.result);
				}
				return new global::RustProto.objectSleepingAvatar.Builder().MergeFrom(this.result);
			}

			// Token: 0x1700050B RID: 1291
			// (get) Token: 0x0600130C RID: 4876 RVA: 0x00043B68 File Offset: 0x00041D68
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectSleepingAvatar.Descriptor;
				}
			}

			// Token: 0x1700050C RID: 1292
			// (get) Token: 0x0600130D RID: 4877 RVA: 0x00043B70 File Offset: 0x00041D70
			public override global::RustProto.objectSleepingAvatar DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectSleepingAvatar.DefaultInstance;
				}
			}

			// Token: 0x0600130E RID: 4878 RVA: 0x00043B78 File Offset: 0x00041D78
			public override global::RustProto.objectSleepingAvatar BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x0600130F RID: 4879 RVA: 0x00043BAC File Offset: 0x00041DAC
			public override global::RustProto.objectSleepingAvatar.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectSleepingAvatar)
				{
					return this.MergeFrom((global::RustProto.objectSleepingAvatar)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001310 RID: 4880 RVA: 0x00043BD0 File Offset: 0x00041DD0
			public override global::RustProto.objectSleepingAvatar.Builder MergeFrom(global::RustProto.objectSleepingAvatar other)
			{
				if (other == global::RustProto.objectSleepingAvatar.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasFootArmor)
				{
					this.FootArmor = other.FootArmor;
				}
				if (other.HasLegArmor)
				{
					this.LegArmor = other.LegArmor;
				}
				if (other.HasTorsoArmor)
				{
					this.TorsoArmor = other.TorsoArmor;
				}
				if (other.HasHeadArmor)
				{
					this.HeadArmor = other.HeadArmor;
				}
				if (other.HasTimestamp)
				{
					this.Timestamp = other.Timestamp;
				}
				if (other.HasVitals)
				{
					this.MergeVitals(other.Vitals);
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001311 RID: 4881 RVA: 0x00043C8C File Offset: 0x00041E8C
			public override global::RustProto.objectSleepingAvatar.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001312 RID: 4882 RVA: 0x00043C9C File Offset: 0x00041E9C
			public override global::RustProto.objectSleepingAvatar.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectSleepingAvatar._objectSleepingAvatarFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectSleepingAvatar._objectSleepingAvatarFieldTags[num2];
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
							if (num3 != 0x18U)
							{
								if (num3 != 0x20U)
								{
									if (num3 != 0x28U)
									{
										if (num3 != 0x32U)
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
											global::RustProto.Vitals.Builder builder2 = global::RustProto.Vitals.CreateBuilder();
											if (this.result.hasVitals)
											{
												builder2.MergeFrom(this.Vitals);
											}
											input.ReadMessage(builder2, extensionRegistry);
											this.Vitals = builder2.BuildPartial();
										}
									}
									else
									{
										this.result.hasTimestamp = input.ReadInt32(ref this.result.timestamp_);
									}
								}
								else
								{
									this.result.hasHeadArmor = input.ReadInt32(ref this.result.headArmor_);
								}
							}
							else
							{
								this.result.hasTorsoArmor = input.ReadInt32(ref this.result.torsoArmor_);
							}
						}
						else
						{
							this.result.hasLegArmor = input.ReadInt32(ref this.result.legArmor_);
						}
					}
					else
					{
						this.result.hasFootArmor = input.ReadInt32(ref this.result.footArmor_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x1700050D RID: 1293
			// (get) Token: 0x06001313 RID: 4883 RVA: 0x00043EA0 File Offset: 0x000420A0
			public bool HasFootArmor
			{
				get
				{
					return this.result.hasFootArmor;
				}
			}

			// Token: 0x1700050E RID: 1294
			// (get) Token: 0x06001314 RID: 4884 RVA: 0x00043EB0 File Offset: 0x000420B0
			// (set) Token: 0x06001315 RID: 4885 RVA: 0x00043EC0 File Offset: 0x000420C0
			public int FootArmor
			{
				get
				{
					return this.result.FootArmor;
				}
				set
				{
					this.SetFootArmor(value);
				}
			}

			// Token: 0x06001316 RID: 4886 RVA: 0x00043ECC File Offset: 0x000420CC
			public global::RustProto.objectSleepingAvatar.Builder SetFootArmor(int value)
			{
				this.PrepareBuilder();
				this.result.hasFootArmor = true;
				this.result.footArmor_ = value;
				return this;
			}

			// Token: 0x06001317 RID: 4887 RVA: 0x00043EFC File Offset: 0x000420FC
			public global::RustProto.objectSleepingAvatar.Builder ClearFootArmor()
			{
				this.PrepareBuilder();
				this.result.hasFootArmor = false;
				this.result.footArmor_ = 0;
				return this;
			}

			// Token: 0x1700050F RID: 1295
			// (get) Token: 0x06001318 RID: 4888 RVA: 0x00043F2C File Offset: 0x0004212C
			public bool HasLegArmor
			{
				get
				{
					return this.result.hasLegArmor;
				}
			}

			// Token: 0x17000510 RID: 1296
			// (get) Token: 0x06001319 RID: 4889 RVA: 0x00043F3C File Offset: 0x0004213C
			// (set) Token: 0x0600131A RID: 4890 RVA: 0x00043F4C File Offset: 0x0004214C
			public int LegArmor
			{
				get
				{
					return this.result.LegArmor;
				}
				set
				{
					this.SetLegArmor(value);
				}
			}

			// Token: 0x0600131B RID: 4891 RVA: 0x00043F58 File Offset: 0x00042158
			public global::RustProto.objectSleepingAvatar.Builder SetLegArmor(int value)
			{
				this.PrepareBuilder();
				this.result.hasLegArmor = true;
				this.result.legArmor_ = value;
				return this;
			}

			// Token: 0x0600131C RID: 4892 RVA: 0x00043F88 File Offset: 0x00042188
			public global::RustProto.objectSleepingAvatar.Builder ClearLegArmor()
			{
				this.PrepareBuilder();
				this.result.hasLegArmor = false;
				this.result.legArmor_ = 0;
				return this;
			}

			// Token: 0x17000511 RID: 1297
			// (get) Token: 0x0600131D RID: 4893 RVA: 0x00043FB8 File Offset: 0x000421B8
			public bool HasTorsoArmor
			{
				get
				{
					return this.result.hasTorsoArmor;
				}
			}

			// Token: 0x17000512 RID: 1298
			// (get) Token: 0x0600131E RID: 4894 RVA: 0x00043FC8 File Offset: 0x000421C8
			// (set) Token: 0x0600131F RID: 4895 RVA: 0x00043FD8 File Offset: 0x000421D8
			public int TorsoArmor
			{
				get
				{
					return this.result.TorsoArmor;
				}
				set
				{
					this.SetTorsoArmor(value);
				}
			}

			// Token: 0x06001320 RID: 4896 RVA: 0x00043FE4 File Offset: 0x000421E4
			public global::RustProto.objectSleepingAvatar.Builder SetTorsoArmor(int value)
			{
				this.PrepareBuilder();
				this.result.hasTorsoArmor = true;
				this.result.torsoArmor_ = value;
				return this;
			}

			// Token: 0x06001321 RID: 4897 RVA: 0x00044014 File Offset: 0x00042214
			public global::RustProto.objectSleepingAvatar.Builder ClearTorsoArmor()
			{
				this.PrepareBuilder();
				this.result.hasTorsoArmor = false;
				this.result.torsoArmor_ = 0;
				return this;
			}

			// Token: 0x17000513 RID: 1299
			// (get) Token: 0x06001322 RID: 4898 RVA: 0x00044044 File Offset: 0x00042244
			public bool HasHeadArmor
			{
				get
				{
					return this.result.hasHeadArmor;
				}
			}

			// Token: 0x17000514 RID: 1300
			// (get) Token: 0x06001323 RID: 4899 RVA: 0x00044054 File Offset: 0x00042254
			// (set) Token: 0x06001324 RID: 4900 RVA: 0x00044064 File Offset: 0x00042264
			public int HeadArmor
			{
				get
				{
					return this.result.HeadArmor;
				}
				set
				{
					this.SetHeadArmor(value);
				}
			}

			// Token: 0x06001325 RID: 4901 RVA: 0x00044070 File Offset: 0x00042270
			public global::RustProto.objectSleepingAvatar.Builder SetHeadArmor(int value)
			{
				this.PrepareBuilder();
				this.result.hasHeadArmor = true;
				this.result.headArmor_ = value;
				return this;
			}

			// Token: 0x06001326 RID: 4902 RVA: 0x000440A0 File Offset: 0x000422A0
			public global::RustProto.objectSleepingAvatar.Builder ClearHeadArmor()
			{
				this.PrepareBuilder();
				this.result.hasHeadArmor = false;
				this.result.headArmor_ = 0;
				return this;
			}

			// Token: 0x17000515 RID: 1301
			// (get) Token: 0x06001327 RID: 4903 RVA: 0x000440D0 File Offset: 0x000422D0
			public bool HasTimestamp
			{
				get
				{
					return this.result.hasTimestamp;
				}
			}

			// Token: 0x17000516 RID: 1302
			// (get) Token: 0x06001328 RID: 4904 RVA: 0x000440E0 File Offset: 0x000422E0
			// (set) Token: 0x06001329 RID: 4905 RVA: 0x000440F0 File Offset: 0x000422F0
			public int Timestamp
			{
				get
				{
					return this.result.Timestamp;
				}
				set
				{
					this.SetTimestamp(value);
				}
			}

			// Token: 0x0600132A RID: 4906 RVA: 0x000440FC File Offset: 0x000422FC
			public global::RustProto.objectSleepingAvatar.Builder SetTimestamp(int value)
			{
				this.PrepareBuilder();
				this.result.hasTimestamp = true;
				this.result.timestamp_ = value;
				return this;
			}

			// Token: 0x0600132B RID: 4907 RVA: 0x0004412C File Offset: 0x0004232C
			public global::RustProto.objectSleepingAvatar.Builder ClearTimestamp()
			{
				this.PrepareBuilder();
				this.result.hasTimestamp = false;
				this.result.timestamp_ = 0;
				return this;
			}

			// Token: 0x17000517 RID: 1303
			// (get) Token: 0x0600132C RID: 4908 RVA: 0x0004415C File Offset: 0x0004235C
			public bool HasVitals
			{
				get
				{
					return this.result.hasVitals;
				}
			}

			// Token: 0x17000518 RID: 1304
			// (get) Token: 0x0600132D RID: 4909 RVA: 0x0004416C File Offset: 0x0004236C
			// (set) Token: 0x0600132E RID: 4910 RVA: 0x0004417C File Offset: 0x0004237C
			public global::RustProto.Vitals Vitals
			{
				get
				{
					return this.result.Vitals;
				}
				set
				{
					this.SetVitals(value);
				}
			}

			// Token: 0x0600132F RID: 4911 RVA: 0x00044188 File Offset: 0x00042388
			public global::RustProto.objectSleepingAvatar.Builder SetVitals(global::RustProto.Vitals value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasVitals = true;
				this.result.vitals_ = value;
				return this;
			}

			// Token: 0x06001330 RID: 4912 RVA: 0x000441B8 File Offset: 0x000423B8
			public global::RustProto.objectSleepingAvatar.Builder SetVitals(global::RustProto.Vitals.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasVitals = true;
				this.result.vitals_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06001331 RID: 4913 RVA: 0x000441F8 File Offset: 0x000423F8
			public global::RustProto.objectSleepingAvatar.Builder MergeVitals(global::RustProto.Vitals value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasVitals && this.result.vitals_ != global::RustProto.Vitals.DefaultInstance)
				{
					this.result.vitals_ = global::RustProto.Vitals.CreateBuilder(this.result.vitals_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.vitals_ = value;
				}
				this.result.hasVitals = true;
				return this;
			}

			// Token: 0x06001332 RID: 4914 RVA: 0x00044280 File Offset: 0x00042480
			public global::RustProto.objectSleepingAvatar.Builder ClearVitals()
			{
				this.PrepareBuilder();
				this.result.hasVitals = false;
				this.result.vitals_ = null;
				return this;
			}

			// Token: 0x04000AB7 RID: 2743
			private bool resultIsReadOnly;

			// Token: 0x04000AB8 RID: 2744
			private global::RustProto.objectSleepingAvatar result;
		}
	}
}

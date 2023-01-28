using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x02000255 RID: 597
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectFireBarrel : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder>
	{
		// Token: 0x0600139A RID: 5018 RVA: 0x00044E70 File Offset: 0x00043070
		private objectFireBarrel()
		{
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x00044E80 File Offset: 0x00043080
		static objectFireBarrel()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x00044EC0 File Offset: 0x000430C0
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder>.Manufacture();
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x0600139D RID: 5021 RVA: 0x00044EC8 File Offset: 0x000430C8
		public static global::RustProto.objectFireBarrel DefaultInstance
		{
			get
			{
				return global::RustProto.objectFireBarrel.defaultInstance;
			}
		}

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x0600139E RID: 5022 RVA: 0x00044ED0 File Offset: 0x000430D0
		public override global::RustProto.objectFireBarrel DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectFireBarrel.DefaultInstance;
			}
		}

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x0600139F RID: 5023 RVA: 0x00044ED8 File Offset: 0x000430D8
		protected override global::RustProto.objectFireBarrel ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x060013A0 RID: 5024 RVA: 0x00044EDC File Offset: 0x000430DC
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectFireBarrel__Descriptor;
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x060013A1 RID: 5025 RVA: 0x00044EE4 File Offset: 0x000430E4
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectFireBarrel__FieldAccessorTable;
			}
		}

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x060013A2 RID: 5026 RVA: 0x00044EEC File Offset: 0x000430EC
		public bool HasOnFire
		{
			get
			{
				return this.hasOnFire;
			}
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x060013A3 RID: 5027 RVA: 0x00044EF4 File Offset: 0x000430F4
		public bool OnFire
		{
			get
			{
				return this.onFire_;
			}
		}

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x060013A4 RID: 5028 RVA: 0x00044EFC File Offset: 0x000430FC
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x00044F00 File Offset: 0x00043100
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectFireBarrelFieldNames = global::RustProto.objectFireBarrel._objectFireBarrelFieldNames;
			if (this.hasOnFire)
			{
				output.WriteBool(1, objectFireBarrelFieldNames[0], this.OnFire);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x060013A6 RID: 5030 RVA: 0x00044F44 File Offset: 0x00043144
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
				if (this.hasOnFire)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeBoolSize(1, this.OnFire);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x00044F94 File Offset: 0x00043194
		public static global::RustProto.objectFireBarrel ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x00044FA8 File Offset: 0x000431A8
		public static global::RustProto.objectFireBarrel ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x00044FBC File Offset: 0x000431BC
		public static global::RustProto.objectFireBarrel ParseFrom(byte[] data)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x00044FD0 File Offset: 0x000431D0
		public static global::RustProto.objectFireBarrel ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x00044FE4 File Offset: 0x000431E4
		public static global::RustProto.objectFireBarrel ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x00044FF8 File Offset: 0x000431F8
		public static global::RustProto.objectFireBarrel ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x0004500C File Offset: 0x0004320C
		public static global::RustProto.objectFireBarrel ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x00045020 File Offset: 0x00043220
		public static global::RustProto.objectFireBarrel ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x00045034 File Offset: 0x00043234
		public static global::RustProto.objectFireBarrel ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x00045048 File Offset: 0x00043248
		public static global::RustProto.objectFireBarrel ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectFireBarrel.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x0004505C File Offset: 0x0004325C
		private global::RustProto.objectFireBarrel MakeReadOnly()
		{
			return this;
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x00045060 File Offset: 0x00043260
		public static global::RustProto.objectFireBarrel.Builder CreateBuilder()
		{
			return new global::RustProto.objectFireBarrel.Builder();
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x00045068 File Offset: 0x00043268
		public override global::RustProto.objectFireBarrel.Builder ToBuilder()
		{
			return global::RustProto.objectFireBarrel.CreateBuilder(this);
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x00045070 File Offset: 0x00043270
		public override global::RustProto.objectFireBarrel.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectFireBarrel.Builder();
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x00045078 File Offset: 0x00043278
		public static global::RustProto.objectFireBarrel.Builder CreateBuilder(global::RustProto.objectFireBarrel prototype)
		{
			return new global::RustProto.objectFireBarrel.Builder(prototype);
		}

		// Token: 0x04000ACE RID: 2766
		public const int OnFireFieldNumber = 1;

		// Token: 0x04000ACF RID: 2767
		private static readonly global::RustProto.objectFireBarrel defaultInstance = new global::RustProto.objectFireBarrel().MakeReadOnly();

		// Token: 0x04000AD0 RID: 2768
		private static readonly string[] _objectFireBarrelFieldNames = new string[]
		{
			"OnFire"
		};

		// Token: 0x04000AD1 RID: 2769
		private static readonly uint[] _objectFireBarrelFieldTags = new uint[]
		{
			8U
		};

		// Token: 0x04000AD2 RID: 2770
		private bool hasOnFire;

		// Token: 0x04000AD3 RID: 2771
		private bool onFire_;

		// Token: 0x04000AD4 RID: 2772
		private int memoizedSerializedSize = -1;

		// Token: 0x02000256 RID: 598
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder>
		{
			// Token: 0x060013B6 RID: 5046 RVA: 0x00045080 File Offset: 0x00043280
			public Builder()
			{
				this.result = global::RustProto.objectFireBarrel.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x060013B7 RID: 5047 RVA: 0x0004509C File Offset: 0x0004329C
			internal Builder(global::RustProto.objectFireBarrel cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000546 RID: 1350
			// (get) Token: 0x060013B8 RID: 5048 RVA: 0x000450B4 File Offset: 0x000432B4
			protected override global::RustProto.objectFireBarrel.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060013B9 RID: 5049 RVA: 0x000450B8 File Offset: 0x000432B8
			private global::RustProto.objectFireBarrel PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectFireBarrel other = this.result;
					this.result = new global::RustProto.objectFireBarrel();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000547 RID: 1351
			// (get) Token: 0x060013BA RID: 5050 RVA: 0x000450F8 File Offset: 0x000432F8
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000548 RID: 1352
			// (get) Token: 0x060013BB RID: 5051 RVA: 0x00045108 File Offset: 0x00043308
			protected override global::RustProto.objectFireBarrel MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x060013BC RID: 5052 RVA: 0x00045110 File Offset: 0x00043310
			public override global::RustProto.objectFireBarrel.Builder Clear()
			{
				this.result = global::RustProto.objectFireBarrel.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x060013BD RID: 5053 RVA: 0x00045128 File Offset: 0x00043328
			public override global::RustProto.objectFireBarrel.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectFireBarrel.Builder(this.result);
				}
				return new global::RustProto.objectFireBarrel.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000549 RID: 1353
			// (get) Token: 0x060013BE RID: 5054 RVA: 0x00045154 File Offset: 0x00043354
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectFireBarrel.Descriptor;
				}
			}

			// Token: 0x1700054A RID: 1354
			// (get) Token: 0x060013BF RID: 5055 RVA: 0x0004515C File Offset: 0x0004335C
			public override global::RustProto.objectFireBarrel DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectFireBarrel.DefaultInstance;
				}
			}

			// Token: 0x060013C0 RID: 5056 RVA: 0x00045164 File Offset: 0x00043364
			public override global::RustProto.objectFireBarrel BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x060013C1 RID: 5057 RVA: 0x00045198 File Offset: 0x00043398
			public override global::RustProto.objectFireBarrel.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectFireBarrel)
				{
					return this.MergeFrom((global::RustProto.objectFireBarrel)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x060013C2 RID: 5058 RVA: 0x000451BC File Offset: 0x000433BC
			public override global::RustProto.objectFireBarrel.Builder MergeFrom(global::RustProto.objectFireBarrel other)
			{
				if (other == global::RustProto.objectFireBarrel.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasOnFire)
				{
					this.OnFire = other.OnFire;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x060013C3 RID: 5059 RVA: 0x00045204 File Offset: 0x00043404
			public override global::RustProto.objectFireBarrel.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x060013C4 RID: 5060 RVA: 0x00045214 File Offset: 0x00043414
			public override global::RustProto.objectFireBarrel.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectFireBarrel._objectFireBarrelFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectFireBarrel._objectFireBarrelFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 8U)
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
						this.result.hasOnFire = input.ReadBool(ref this.result.onFire_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x1700054B RID: 1355
			// (get) Token: 0x060013C5 RID: 5061 RVA: 0x00045328 File Offset: 0x00043528
			public bool HasOnFire
			{
				get
				{
					return this.result.hasOnFire;
				}
			}

			// Token: 0x1700054C RID: 1356
			// (get) Token: 0x060013C6 RID: 5062 RVA: 0x00045338 File Offset: 0x00043538
			// (set) Token: 0x060013C7 RID: 5063 RVA: 0x00045348 File Offset: 0x00043548
			public bool OnFire
			{
				get
				{
					return this.result.OnFire;
				}
				set
				{
					this.SetOnFire(value);
				}
			}

			// Token: 0x060013C8 RID: 5064 RVA: 0x00045354 File Offset: 0x00043554
			public global::RustProto.objectFireBarrel.Builder SetOnFire(bool value)
			{
				this.PrepareBuilder();
				this.result.hasOnFire = true;
				this.result.onFire_ = value;
				return this;
			}

			// Token: 0x060013C9 RID: 5065 RVA: 0x00045384 File Offset: 0x00043584
			public global::RustProto.objectFireBarrel.Builder ClearOnFire()
			{
				this.PrepareBuilder();
				this.result.hasOnFire = false;
				this.result.onFire_ = false;
				return this;
			}

			// Token: 0x04000AD5 RID: 2773
			private bool resultIsReadOnly;

			// Token: 0x04000AD6 RID: 2774
			private global::RustProto.objectFireBarrel result;
		}
	}
}

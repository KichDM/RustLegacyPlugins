using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x02000253 RID: 595
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectTakeDamage : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder>
	{
		// Token: 0x0600136A RID: 4970 RVA: 0x0004491C File Offset: 0x00042B1C
		private objectTakeDamage()
		{
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x0004492C File Offset: 0x00042B2C
		static objectTakeDamage()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x00044978 File Offset: 0x00042B78
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder>.Manufacture();
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x0600136D RID: 4973 RVA: 0x00044980 File Offset: 0x00042B80
		public static global::RustProto.objectTakeDamage DefaultInstance
		{
			get
			{
				return global::RustProto.objectTakeDamage.defaultInstance;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x0600136E RID: 4974 RVA: 0x00044988 File Offset: 0x00042B88
		public override global::RustProto.objectTakeDamage DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectTakeDamage.DefaultInstance;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x0600136F RID: 4975 RVA: 0x00044990 File Offset: 0x00042B90
		protected override global::RustProto.objectTakeDamage ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06001370 RID: 4976 RVA: 0x00044994 File Offset: 0x00042B94
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectTakeDamage__Descriptor;
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06001371 RID: 4977 RVA: 0x0004499C File Offset: 0x00042B9C
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectTakeDamage__FieldAccessorTable;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06001372 RID: 4978 RVA: 0x000449A4 File Offset: 0x00042BA4
		public bool HasHealth
		{
			get
			{
				return this.hasHealth;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06001373 RID: 4979 RVA: 0x000449AC File Offset: 0x00042BAC
		public float Health
		{
			get
			{
				return this.health_;
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06001374 RID: 4980 RVA: 0x000449B4 File Offset: 0x00042BB4
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001375 RID: 4981 RVA: 0x000449B8 File Offset: 0x00042BB8
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectTakeDamageFieldNames = global::RustProto.objectTakeDamage._objectTakeDamageFieldNames;
			if (this.hasHealth)
			{
				output.WriteFloat(1, objectTakeDamageFieldNames[0], this.Health);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06001376 RID: 4982 RVA: 0x000449FC File Offset: 0x00042BFC
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
				if (this.hasHealth)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeFloatSize(1, this.Health);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x06001377 RID: 4983 RVA: 0x00044A4C File Offset: 0x00042C4C
		public static global::RustProto.objectTakeDamage ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001378 RID: 4984 RVA: 0x00044A60 File Offset: 0x00042C60
		public static global::RustProto.objectTakeDamage ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001379 RID: 4985 RVA: 0x00044A74 File Offset: 0x00042C74
		public static global::RustProto.objectTakeDamage ParseFrom(byte[] data)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600137A RID: 4986 RVA: 0x00044A88 File Offset: 0x00042C88
		public static global::RustProto.objectTakeDamage ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600137B RID: 4987 RVA: 0x00044A9C File Offset: 0x00042C9C
		public static global::RustProto.objectTakeDamage ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x0600137C RID: 4988 RVA: 0x00044AB0 File Offset: 0x00042CB0
		public static global::RustProto.objectTakeDamage ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600137D RID: 4989 RVA: 0x00044AC4 File Offset: 0x00042CC4
		public static global::RustProto.objectTakeDamage ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x0600137E RID: 4990 RVA: 0x00044AD8 File Offset: 0x00042CD8
		public static global::RustProto.objectTakeDamage ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x00044AEC File Offset: 0x00042CEC
		public static global::RustProto.objectTakeDamage ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x00044B00 File Offset: 0x00042D00
		public static global::RustProto.objectTakeDamage ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectTakeDamage.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001381 RID: 4993 RVA: 0x00044B14 File Offset: 0x00042D14
		private global::RustProto.objectTakeDamage MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001382 RID: 4994 RVA: 0x00044B18 File Offset: 0x00042D18
		public static global::RustProto.objectTakeDamage.Builder CreateBuilder()
		{
			return new global::RustProto.objectTakeDamage.Builder();
		}

		// Token: 0x06001383 RID: 4995 RVA: 0x00044B20 File Offset: 0x00042D20
		public override global::RustProto.objectTakeDamage.Builder ToBuilder()
		{
			return global::RustProto.objectTakeDamage.CreateBuilder(this);
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x00044B28 File Offset: 0x00042D28
		public override global::RustProto.objectTakeDamage.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectTakeDamage.Builder();
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x00044B30 File Offset: 0x00042D30
		public static global::RustProto.objectTakeDamage.Builder CreateBuilder(global::RustProto.objectTakeDamage prototype)
		{
			return new global::RustProto.objectTakeDamage.Builder(prototype);
		}

		// Token: 0x04000AC5 RID: 2757
		public const int HealthFieldNumber = 1;

		// Token: 0x04000AC6 RID: 2758
		private static readonly global::RustProto.objectTakeDamage defaultInstance = new global::RustProto.objectTakeDamage().MakeReadOnly();

		// Token: 0x04000AC7 RID: 2759
		private static readonly string[] _objectTakeDamageFieldNames = new string[]
		{
			"health"
		};

		// Token: 0x04000AC8 RID: 2760
		private static readonly uint[] _objectTakeDamageFieldTags = new uint[]
		{
			0xDU
		};

		// Token: 0x04000AC9 RID: 2761
		private bool hasHealth;

		// Token: 0x04000ACA RID: 2762
		private float health_;

		// Token: 0x04000ACB RID: 2763
		private int memoizedSerializedSize = -1;

		// Token: 0x02000254 RID: 596
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder>
		{
			// Token: 0x06001386 RID: 4998 RVA: 0x00044B38 File Offset: 0x00042D38
			public Builder()
			{
				this.result = global::RustProto.objectTakeDamage.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001387 RID: 4999 RVA: 0x00044B54 File Offset: 0x00042D54
			internal Builder(global::RustProto.objectTakeDamage cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000536 RID: 1334
			// (get) Token: 0x06001388 RID: 5000 RVA: 0x00044B6C File Offset: 0x00042D6C
			protected override global::RustProto.objectTakeDamage.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001389 RID: 5001 RVA: 0x00044B70 File Offset: 0x00042D70
			private global::RustProto.objectTakeDamage PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectTakeDamage other = this.result;
					this.result = new global::RustProto.objectTakeDamage();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000537 RID: 1335
			// (get) Token: 0x0600138A RID: 5002 RVA: 0x00044BB0 File Offset: 0x00042DB0
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000538 RID: 1336
			// (get) Token: 0x0600138B RID: 5003 RVA: 0x00044BC0 File Offset: 0x00042DC0
			protected override global::RustProto.objectTakeDamage MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x0600138C RID: 5004 RVA: 0x00044BC8 File Offset: 0x00042DC8
			public override global::RustProto.objectTakeDamage.Builder Clear()
			{
				this.result = global::RustProto.objectTakeDamage.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x0600138D RID: 5005 RVA: 0x00044BE0 File Offset: 0x00042DE0
			public override global::RustProto.objectTakeDamage.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectTakeDamage.Builder(this.result);
				}
				return new global::RustProto.objectTakeDamage.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000539 RID: 1337
			// (get) Token: 0x0600138E RID: 5006 RVA: 0x00044C0C File Offset: 0x00042E0C
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectTakeDamage.Descriptor;
				}
			}

			// Token: 0x1700053A RID: 1338
			// (get) Token: 0x0600138F RID: 5007 RVA: 0x00044C14 File Offset: 0x00042E14
			public override global::RustProto.objectTakeDamage DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectTakeDamage.DefaultInstance;
				}
			}

			// Token: 0x06001390 RID: 5008 RVA: 0x00044C1C File Offset: 0x00042E1C
			public override global::RustProto.objectTakeDamage BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001391 RID: 5009 RVA: 0x00044C50 File Offset: 0x00042E50
			public override global::RustProto.objectTakeDamage.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectTakeDamage)
				{
					return this.MergeFrom((global::RustProto.objectTakeDamage)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001392 RID: 5010 RVA: 0x00044C74 File Offset: 0x00042E74
			public override global::RustProto.objectTakeDamage.Builder MergeFrom(global::RustProto.objectTakeDamage other)
			{
				if (other == global::RustProto.objectTakeDamage.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasHealth)
				{
					this.Health = other.Health;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001393 RID: 5011 RVA: 0x00044CBC File Offset: 0x00042EBC
			public override global::RustProto.objectTakeDamage.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001394 RID: 5012 RVA: 0x00044CCC File Offset: 0x00042ECC
			public override global::RustProto.objectTakeDamage.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectTakeDamage._objectTakeDamageFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectTakeDamage._objectTakeDamageFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 0xDU)
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
						this.result.hasHealth = input.ReadFloat(ref this.result.health_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x1700053B RID: 1339
			// (get) Token: 0x06001395 RID: 5013 RVA: 0x00044DE0 File Offset: 0x00042FE0
			public bool HasHealth
			{
				get
				{
					return this.result.hasHealth;
				}
			}

			// Token: 0x1700053C RID: 1340
			// (get) Token: 0x06001396 RID: 5014 RVA: 0x00044DF0 File Offset: 0x00042FF0
			// (set) Token: 0x06001397 RID: 5015 RVA: 0x00044E00 File Offset: 0x00043000
			public float Health
			{
				get
				{
					return this.result.Health;
				}
				set
				{
					this.SetHealth(value);
				}
			}

			// Token: 0x06001398 RID: 5016 RVA: 0x00044E0C File Offset: 0x0004300C
			public global::RustProto.objectTakeDamage.Builder SetHealth(float value)
			{
				this.PrepareBuilder();
				this.result.hasHealth = true;
				this.result.health_ = value;
				return this;
			}

			// Token: 0x06001399 RID: 5017 RVA: 0x00044E3C File Offset: 0x0004303C
			public global::RustProto.objectTakeDamage.Builder ClearHealth()
			{
				this.PrepareBuilder();
				this.result.hasHealth = false;
				this.result.health_ = 0f;
				return this;
			}

			// Token: 0x04000ACC RID: 2764
			private bool resultIsReadOnly;

			// Token: 0x04000ACD RID: 2765
			private global::RustProto.objectTakeDamage result;
		}
	}
}

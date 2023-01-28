using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x0200025D RID: 605
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectICarriableTrans : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder>
	{
		// Token: 0x0600148E RID: 5262 RVA: 0x00046C2C File Offset: 0x00044E2C
		private objectICarriableTrans()
		{
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x00046C3C File Offset: 0x00044E3C
		static objectICarriableTrans()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x00046C7C File Offset: 0x00044E7C
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder>.Manufacture();
		}

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06001491 RID: 5265 RVA: 0x00046C84 File Offset: 0x00044E84
		public static global::RustProto.objectICarriableTrans DefaultInstance
		{
			get
			{
				return global::RustProto.objectICarriableTrans.defaultInstance;
			}
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06001492 RID: 5266 RVA: 0x00046C8C File Offset: 0x00044E8C
		public override global::RustProto.objectICarriableTrans DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectICarriableTrans.DefaultInstance;
			}
		}

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06001493 RID: 5267 RVA: 0x00046C94 File Offset: 0x00044E94
		protected override global::RustProto.objectICarriableTrans ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06001494 RID: 5268 RVA: 0x00046C98 File Offset: 0x00044E98
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectICarriableTrans__Descriptor;
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06001495 RID: 5269 RVA: 0x00046CA0 File Offset: 0x00044EA0
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectICarriableTrans__FieldAccessorTable;
			}
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x06001496 RID: 5270 RVA: 0x00046CA8 File Offset: 0x00044EA8
		public bool HasTransCarrierID
		{
			get
			{
				return this.hasTransCarrierID;
			}
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06001497 RID: 5271 RVA: 0x00046CB0 File Offset: 0x00044EB0
		public int TransCarrierID
		{
			get
			{
				return this.transCarrierID_;
			}
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06001498 RID: 5272 RVA: 0x00046CB8 File Offset: 0x00044EB8
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x00046CBC File Offset: 0x00044EBC
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectICarriableTransFieldNames = global::RustProto.objectICarriableTrans._objectICarriableTransFieldNames;
			if (this.hasTransCarrierID)
			{
				output.WriteInt32(1, objectICarriableTransFieldNames[0], this.TransCarrierID);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x0600149A RID: 5274 RVA: 0x00046D00 File Offset: 0x00044F00
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
				if (this.hasTransCarrierID)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(1, this.TransCarrierID);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x00046D50 File Offset: 0x00044F50
		public static global::RustProto.objectICarriableTrans ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x00046D64 File Offset: 0x00044F64
		public static global::RustProto.objectICarriableTrans ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x00046D78 File Offset: 0x00044F78
		public static global::RustProto.objectICarriableTrans ParseFrom(byte[] data)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x00046D8C File Offset: 0x00044F8C
		public static global::RustProto.objectICarriableTrans ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x00046DA0 File Offset: 0x00044FA0
		public static global::RustProto.objectICarriableTrans ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x00046DB4 File Offset: 0x00044FB4
		public static global::RustProto.objectICarriableTrans ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x00046DC8 File Offset: 0x00044FC8
		public static global::RustProto.objectICarriableTrans ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x00046DDC File Offset: 0x00044FDC
		public static global::RustProto.objectICarriableTrans ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x00046DF0 File Offset: 0x00044FF0
		public static global::RustProto.objectICarriableTrans ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x00046E04 File Offset: 0x00045004
		public static global::RustProto.objectICarriableTrans ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x00046E18 File Offset: 0x00045018
		private global::RustProto.objectICarriableTrans MakeReadOnly()
		{
			return this;
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x00046E1C File Offset: 0x0004501C
		public static global::RustProto.objectICarriableTrans.Builder CreateBuilder()
		{
			return new global::RustProto.objectICarriableTrans.Builder();
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x00046E24 File Offset: 0x00045024
		public override global::RustProto.objectICarriableTrans.Builder ToBuilder()
		{
			return global::RustProto.objectICarriableTrans.CreateBuilder(this);
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x00046E2C File Offset: 0x0004502C
		public override global::RustProto.objectICarriableTrans.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectICarriableTrans.Builder();
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x00046E34 File Offset: 0x00045034
		public static global::RustProto.objectICarriableTrans.Builder CreateBuilder(global::RustProto.objectICarriableTrans prototype)
		{
			return new global::RustProto.objectICarriableTrans.Builder(prototype);
		}

		// Token: 0x04000B06 RID: 2822
		public const int TransCarrierIDFieldNumber = 1;

		// Token: 0x04000B07 RID: 2823
		private static readonly global::RustProto.objectICarriableTrans defaultInstance = new global::RustProto.objectICarriableTrans().MakeReadOnly();

		// Token: 0x04000B08 RID: 2824
		private static readonly string[] _objectICarriableTransFieldNames = new string[]
		{
			"transCarrierID"
		};

		// Token: 0x04000B09 RID: 2825
		private static readonly uint[] _objectICarriableTransFieldTags = new uint[]
		{
			8U
		};

		// Token: 0x04000B0A RID: 2826
		private bool hasTransCarrierID;

		// Token: 0x04000B0B RID: 2827
		private int transCarrierID_;

		// Token: 0x04000B0C RID: 2828
		private int memoizedSerializedSize = -1;

		// Token: 0x0200025E RID: 606
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder>
		{
			// Token: 0x060014AA RID: 5290 RVA: 0x00046E3C File Offset: 0x0004503C
			public Builder()
			{
				this.result = global::RustProto.objectICarriableTrans.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x060014AB RID: 5291 RVA: 0x00046E58 File Offset: 0x00045058
			internal Builder(global::RustProto.objectICarriableTrans cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x060014AC RID: 5292 RVA: 0x00046E70 File Offset: 0x00045070
			protected override global::RustProto.objectICarriableTrans.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060014AD RID: 5293 RVA: 0x00046E74 File Offset: 0x00045074
			private global::RustProto.objectICarriableTrans PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectICarriableTrans other = this.result;
					this.result = new global::RustProto.objectICarriableTrans();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x060014AE RID: 5294 RVA: 0x00046EB4 File Offset: 0x000450B4
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170005A4 RID: 1444
			// (get) Token: 0x060014AF RID: 5295 RVA: 0x00046EC4 File Offset: 0x000450C4
			protected override global::RustProto.objectICarriableTrans MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x060014B0 RID: 5296 RVA: 0x00046ECC File Offset: 0x000450CC
			public override global::RustProto.objectICarriableTrans.Builder Clear()
			{
				this.result = global::RustProto.objectICarriableTrans.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x060014B1 RID: 5297 RVA: 0x00046EE4 File Offset: 0x000450E4
			public override global::RustProto.objectICarriableTrans.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectICarriableTrans.Builder(this.result);
				}
				return new global::RustProto.objectICarriableTrans.Builder().MergeFrom(this.result);
			}

			// Token: 0x170005A5 RID: 1445
			// (get) Token: 0x060014B2 RID: 5298 RVA: 0x00046F10 File Offset: 0x00045110
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectICarriableTrans.Descriptor;
				}
			}

			// Token: 0x170005A6 RID: 1446
			// (get) Token: 0x060014B3 RID: 5299 RVA: 0x00046F18 File Offset: 0x00045118
			public override global::RustProto.objectICarriableTrans DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectICarriableTrans.DefaultInstance;
				}
			}

			// Token: 0x060014B4 RID: 5300 RVA: 0x00046F20 File Offset: 0x00045120
			public override global::RustProto.objectICarriableTrans BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x060014B5 RID: 5301 RVA: 0x00046F54 File Offset: 0x00045154
			public override global::RustProto.objectICarriableTrans.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectICarriableTrans)
				{
					return this.MergeFrom((global::RustProto.objectICarriableTrans)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x060014B6 RID: 5302 RVA: 0x00046F78 File Offset: 0x00045178
			public override global::RustProto.objectICarriableTrans.Builder MergeFrom(global::RustProto.objectICarriableTrans other)
			{
				if (other == global::RustProto.objectICarriableTrans.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasTransCarrierID)
				{
					this.TransCarrierID = other.TransCarrierID;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x060014B7 RID: 5303 RVA: 0x00046FC0 File Offset: 0x000451C0
			public override global::RustProto.objectICarriableTrans.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x060014B8 RID: 5304 RVA: 0x00046FD0 File Offset: 0x000451D0
			public override global::RustProto.objectICarriableTrans.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectICarriableTrans._objectICarriableTransFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectICarriableTrans._objectICarriableTransFieldTags[num2];
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
						this.result.hasTransCarrierID = input.ReadInt32(ref this.result.transCarrierID_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x170005A7 RID: 1447
			// (get) Token: 0x060014B9 RID: 5305 RVA: 0x000470E4 File Offset: 0x000452E4
			public bool HasTransCarrierID
			{
				get
				{
					return this.result.hasTransCarrierID;
				}
			}

			// Token: 0x170005A8 RID: 1448
			// (get) Token: 0x060014BA RID: 5306 RVA: 0x000470F4 File Offset: 0x000452F4
			// (set) Token: 0x060014BB RID: 5307 RVA: 0x00047104 File Offset: 0x00045304
			public int TransCarrierID
			{
				get
				{
					return this.result.TransCarrierID;
				}
				set
				{
					this.SetTransCarrierID(value);
				}
			}

			// Token: 0x060014BC RID: 5308 RVA: 0x00047110 File Offset: 0x00045310
			public global::RustProto.objectICarriableTrans.Builder SetTransCarrierID(int value)
			{
				this.PrepareBuilder();
				this.result.hasTransCarrierID = true;
				this.result.transCarrierID_ = value;
				return this;
			}

			// Token: 0x060014BD RID: 5309 RVA: 0x00047140 File Offset: 0x00045340
			public global::RustProto.objectICarriableTrans.Builder ClearTransCarrierID()
			{
				this.PrepareBuilder();
				this.result.hasTransCarrierID = false;
				this.result.transCarrierID_ = 0;
				return this;
			}

			// Token: 0x04000B0D RID: 2829
			private bool resultIsReadOnly;

			// Token: 0x04000B0E RID: 2830
			private global::RustProto.objectICarriableTrans result;
		}
	}
}

using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x02000251 RID: 593
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectDoor : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder>
	{
		// Token: 0x06001333 RID: 4915 RVA: 0x000442B0 File Offset: 0x000424B0
		private objectDoor()
		{
		}

		// Token: 0x06001334 RID: 4916 RVA: 0x000442C0 File Offset: 0x000424C0
		static objectDoor()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x00044318 File Offset: 0x00042518
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder>.Manufacture();
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06001336 RID: 4918 RVA: 0x00044320 File Offset: 0x00042520
		public static global::RustProto.objectDoor DefaultInstance
		{
			get
			{
				return global::RustProto.objectDoor.defaultInstance;
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06001337 RID: 4919 RVA: 0x00044328 File Offset: 0x00042528
		public override global::RustProto.objectDoor DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectDoor.DefaultInstance;
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06001338 RID: 4920 RVA: 0x00044330 File Offset: 0x00042530
		protected override global::RustProto.objectDoor ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06001339 RID: 4921 RVA: 0x00044334 File Offset: 0x00042534
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectDoor__Descriptor;
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x0600133A RID: 4922 RVA: 0x0004433C File Offset: 0x0004253C
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectDoor__FieldAccessorTable;
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x0600133B RID: 4923 RVA: 0x00044344 File Offset: 0x00042544
		public bool HasState
		{
			get
			{
				return this.hasState;
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x0600133C RID: 4924 RVA: 0x0004434C File Offset: 0x0004254C
		public int State
		{
			get
			{
				return this.state_;
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x0600133D RID: 4925 RVA: 0x00044354 File Offset: 0x00042554
		public bool HasOpen
		{
			get
			{
				return this.hasOpen;
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x0600133E RID: 4926 RVA: 0x0004435C File Offset: 0x0004255C
		public bool Open
		{
			get
			{
				return this.open_;
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x0600133F RID: 4927 RVA: 0x00044364 File Offset: 0x00042564
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06001340 RID: 4928 RVA: 0x00044368 File Offset: 0x00042568
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectDoorFieldNames = global::RustProto.objectDoor._objectDoorFieldNames;
			if (this.hasState)
			{
				output.WriteInt32(1, objectDoorFieldNames[1], this.State);
			}
			if (this.hasOpen)
			{
				output.WriteBool(2, objectDoorFieldNames[0], this.Open);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06001341 RID: 4929 RVA: 0x000443C4 File Offset: 0x000425C4
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
				if (this.hasState)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(1, this.State);
				}
				if (this.hasOpen)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeBoolSize(2, this.Open);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x06001342 RID: 4930 RVA: 0x00044430 File Offset: 0x00042630
		public static global::RustProto.objectDoor ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001343 RID: 4931 RVA: 0x00044444 File Offset: 0x00042644
		public static global::RustProto.objectDoor ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001344 RID: 4932 RVA: 0x00044458 File Offset: 0x00042658
		public static global::RustProto.objectDoor ParseFrom(byte[] data)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001345 RID: 4933 RVA: 0x0004446C File Offset: 0x0004266C
		public static global::RustProto.objectDoor ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001346 RID: 4934 RVA: 0x00044480 File Offset: 0x00042680
		public static global::RustProto.objectDoor ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001347 RID: 4935 RVA: 0x00044494 File Offset: 0x00042694
		public static global::RustProto.objectDoor ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x000444A8 File Offset: 0x000426A8
		public static global::RustProto.objectDoor ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x000444BC File Offset: 0x000426BC
		public static global::RustProto.objectDoor ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x000444D0 File Offset: 0x000426D0
		public static global::RustProto.objectDoor ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x000444E4 File Offset: 0x000426E4
		public static global::RustProto.objectDoor ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectDoor.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x000444F8 File Offset: 0x000426F8
		private global::RustProto.objectDoor MakeReadOnly()
		{
			return this;
		}

		// Token: 0x0600134D RID: 4941 RVA: 0x000444FC File Offset: 0x000426FC
		public static global::RustProto.objectDoor.Builder CreateBuilder()
		{
			return new global::RustProto.objectDoor.Builder();
		}

		// Token: 0x0600134E RID: 4942 RVA: 0x00044504 File Offset: 0x00042704
		public override global::RustProto.objectDoor.Builder ToBuilder()
		{
			return global::RustProto.objectDoor.CreateBuilder(this);
		}

		// Token: 0x0600134F RID: 4943 RVA: 0x0004450C File Offset: 0x0004270C
		public override global::RustProto.objectDoor.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectDoor.Builder();
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x00044514 File Offset: 0x00042714
		public static global::RustProto.objectDoor.Builder CreateBuilder(global::RustProto.objectDoor prototype)
		{
			return new global::RustProto.objectDoor.Builder(prototype);
		}

		// Token: 0x04000AB9 RID: 2745
		public const int StateFieldNumber = 1;

		// Token: 0x04000ABA RID: 2746
		public const int OpenFieldNumber = 2;

		// Token: 0x04000ABB RID: 2747
		private static readonly global::RustProto.objectDoor defaultInstance = new global::RustProto.objectDoor().MakeReadOnly();

		// Token: 0x04000ABC RID: 2748
		private static readonly string[] _objectDoorFieldNames = new string[]
		{
			"Open",
			"State"
		};

		// Token: 0x04000ABD RID: 2749
		private static readonly uint[] _objectDoorFieldTags = new uint[]
		{
			0x10U,
			8U
		};

		// Token: 0x04000ABE RID: 2750
		private bool hasState;

		// Token: 0x04000ABF RID: 2751
		private int state_;

		// Token: 0x04000AC0 RID: 2752
		private bool hasOpen;

		// Token: 0x04000AC1 RID: 2753
		private bool open_;

		// Token: 0x04000AC2 RID: 2754
		private int memoizedSerializedSize = -1;

		// Token: 0x02000252 RID: 594
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder>
		{
			// Token: 0x06001351 RID: 4945 RVA: 0x0004451C File Offset: 0x0004271C
			public Builder()
			{
				this.result = global::RustProto.objectDoor.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001352 RID: 4946 RVA: 0x00044538 File Offset: 0x00042738
			internal Builder(global::RustProto.objectDoor cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000524 RID: 1316
			// (get) Token: 0x06001353 RID: 4947 RVA: 0x00044550 File Offset: 0x00042750
			protected override global::RustProto.objectDoor.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001354 RID: 4948 RVA: 0x00044554 File Offset: 0x00042754
			private global::RustProto.objectDoor PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectDoor other = this.result;
					this.result = new global::RustProto.objectDoor();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000525 RID: 1317
			// (get) Token: 0x06001355 RID: 4949 RVA: 0x00044594 File Offset: 0x00042794
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000526 RID: 1318
			// (get) Token: 0x06001356 RID: 4950 RVA: 0x000445A4 File Offset: 0x000427A4
			protected override global::RustProto.objectDoor MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001357 RID: 4951 RVA: 0x000445AC File Offset: 0x000427AC
			public override global::RustProto.objectDoor.Builder Clear()
			{
				this.result = global::RustProto.objectDoor.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001358 RID: 4952 RVA: 0x000445C4 File Offset: 0x000427C4
			public override global::RustProto.objectDoor.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectDoor.Builder(this.result);
				}
				return new global::RustProto.objectDoor.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000527 RID: 1319
			// (get) Token: 0x06001359 RID: 4953 RVA: 0x000445F0 File Offset: 0x000427F0
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectDoor.Descriptor;
				}
			}

			// Token: 0x17000528 RID: 1320
			// (get) Token: 0x0600135A RID: 4954 RVA: 0x000445F8 File Offset: 0x000427F8
			public override global::RustProto.objectDoor DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectDoor.DefaultInstance;
				}
			}

			// Token: 0x0600135B RID: 4955 RVA: 0x00044600 File Offset: 0x00042800
			public override global::RustProto.objectDoor BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x0600135C RID: 4956 RVA: 0x00044634 File Offset: 0x00042834
			public override global::RustProto.objectDoor.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectDoor)
				{
					return this.MergeFrom((global::RustProto.objectDoor)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x0600135D RID: 4957 RVA: 0x00044658 File Offset: 0x00042858
			public override global::RustProto.objectDoor.Builder MergeFrom(global::RustProto.objectDoor other)
			{
				if (other == global::RustProto.objectDoor.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasState)
				{
					this.State = other.State;
				}
				if (other.HasOpen)
				{
					this.Open = other.Open;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x0600135E RID: 4958 RVA: 0x000446B8 File Offset: 0x000428B8
			public override global::RustProto.objectDoor.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x0600135F RID: 4959 RVA: 0x000446C8 File Offset: 0x000428C8
			public override global::RustProto.objectDoor.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectDoor._objectDoorFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectDoor._objectDoorFieldTags[num2];
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
							this.result.hasOpen = input.ReadBool(ref this.result.open_);
						}
					}
					else
					{
						this.result.hasState = input.ReadInt32(ref this.result.state_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x17000529 RID: 1321
			// (get) Token: 0x06001360 RID: 4960 RVA: 0x00044804 File Offset: 0x00042A04
			public bool HasState
			{
				get
				{
					return this.result.hasState;
				}
			}

			// Token: 0x1700052A RID: 1322
			// (get) Token: 0x06001361 RID: 4961 RVA: 0x00044814 File Offset: 0x00042A14
			// (set) Token: 0x06001362 RID: 4962 RVA: 0x00044824 File Offset: 0x00042A24
			public int State
			{
				get
				{
					return this.result.State;
				}
				set
				{
					this.SetState(value);
				}
			}

			// Token: 0x06001363 RID: 4963 RVA: 0x00044830 File Offset: 0x00042A30
			public global::RustProto.objectDoor.Builder SetState(int value)
			{
				this.PrepareBuilder();
				this.result.hasState = true;
				this.result.state_ = value;
				return this;
			}

			// Token: 0x06001364 RID: 4964 RVA: 0x00044860 File Offset: 0x00042A60
			public global::RustProto.objectDoor.Builder ClearState()
			{
				this.PrepareBuilder();
				this.result.hasState = false;
				this.result.state_ = 0;
				return this;
			}

			// Token: 0x1700052B RID: 1323
			// (get) Token: 0x06001365 RID: 4965 RVA: 0x00044890 File Offset: 0x00042A90
			public bool HasOpen
			{
				get
				{
					return this.result.hasOpen;
				}
			}

			// Token: 0x1700052C RID: 1324
			// (get) Token: 0x06001366 RID: 4966 RVA: 0x000448A0 File Offset: 0x00042AA0
			// (set) Token: 0x06001367 RID: 4967 RVA: 0x000448B0 File Offset: 0x00042AB0
			public bool Open
			{
				get
				{
					return this.result.Open;
				}
				set
				{
					this.SetOpen(value);
				}
			}

			// Token: 0x06001368 RID: 4968 RVA: 0x000448BC File Offset: 0x00042ABC
			public global::RustProto.objectDoor.Builder SetOpen(bool value)
			{
				this.PrepareBuilder();
				this.result.hasOpen = true;
				this.result.open_ = value;
				return this;
			}

			// Token: 0x06001369 RID: 4969 RVA: 0x000448EC File Offset: 0x00042AEC
			public global::RustProto.objectDoor.Builder ClearOpen()
			{
				this.PrepareBuilder();
				this.result.hasOpen = false;
				this.result.open_ = false;
				return this;
			}

			// Token: 0x04000AC3 RID: 2755
			private bool resultIsReadOnly;

			// Token: 0x04000AC4 RID: 2756
			private global::RustProto.objectDoor result;
		}
	}
}

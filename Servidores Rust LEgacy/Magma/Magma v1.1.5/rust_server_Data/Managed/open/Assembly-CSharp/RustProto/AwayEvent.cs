using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;
using RustProto.Proto;

namespace RustProto
{
	// Token: 0x02000263 RID: 611
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class AwayEvent : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder>
	{
		// Token: 0x06001545 RID: 5445 RVA: 0x00048350 File Offset: 0x00046550
		private AwayEvent()
		{
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x00048360 File Offset: 0x00046560
		static AwayEvent()
		{
			object.ReferenceEquals(global::RustProto.Proto.Avatar.Descriptor, null);
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x000483C4 File Offset: 0x000465C4
		public static global::RustProto.Helpers.Recycler<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder>.Manufacture();
		}

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x06001548 RID: 5448 RVA: 0x000483CC File Offset: 0x000465CC
		public static global::RustProto.AwayEvent DefaultInstance
		{
			get
			{
				return global::RustProto.AwayEvent.defaultInstance;
			}
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06001549 RID: 5449 RVA: 0x000483D4 File Offset: 0x000465D4
		public override global::RustProto.AwayEvent DefaultInstanceForType
		{
			get
			{
				return global::RustProto.AwayEvent.DefaultInstance;
			}
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x0600154A RID: 5450 RVA: 0x000483DC File Offset: 0x000465DC
		protected override global::RustProto.AwayEvent ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x0600154B RID: 5451 RVA: 0x000483E0 File Offset: 0x000465E0
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Avatar.internal__static_RustProto_AwayEvent__Descriptor;
			}
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x0600154C RID: 5452 RVA: 0x000483E8 File Offset: 0x000465E8
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.Avatar.internal__static_RustProto_AwayEvent__FieldAccessorTable;
			}
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x0600154D RID: 5453 RVA: 0x000483F0 File Offset: 0x000465F0
		public bool HasType
		{
			get
			{
				return this.hasType;
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x0600154E RID: 5454 RVA: 0x000483F8 File Offset: 0x000465F8
		public global::RustProto.AwayEvent.Types.AwayEventType Type
		{
			get
			{
				return this.type_;
			}
		}

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x0600154F RID: 5455 RVA: 0x00048400 File Offset: 0x00046600
		public bool HasTimestamp
		{
			get
			{
				return this.hasTimestamp;
			}
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06001550 RID: 5456 RVA: 0x00048408 File Offset: 0x00046608
		public int Timestamp
		{
			get
			{
				return this.timestamp_;
			}
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06001551 RID: 5457 RVA: 0x00048410 File Offset: 0x00046610
		public bool HasInstigator
		{
			get
			{
				return this.hasInstigator;
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06001552 RID: 5458 RVA: 0x00048418 File Offset: 0x00046618
		[global::System.CLSCompliant(false)]
		public ulong Instigator
		{
			get
			{
				return this.instigator_;
			}
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06001553 RID: 5459 RVA: 0x00048420 File Offset: 0x00046620
		public override bool IsInitialized
		{
			get
			{
				return this.hasType && this.hasTimestamp;
			}
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x00048440 File Offset: 0x00046640
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] awayEventFieldNames = global::RustProto.AwayEvent._awayEventFieldNames;
			if (this.hasType)
			{
				output.WriteEnum(1, awayEventFieldNames[2], (int)this.Type, this.Type);
			}
			if (this.hasTimestamp)
			{
				output.WriteInt32(2, awayEventFieldNames[1], this.Timestamp);
			}
			if (this.hasInstigator)
			{
				output.WriteUInt64(3, awayEventFieldNames[0], this.Instigator);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06001555 RID: 5461 RVA: 0x000484C4 File Offset: 0x000466C4
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
				if (this.hasType)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeEnumSize(1, (int)this.Type);
				}
				if (this.hasTimestamp)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeInt32Size(2, this.Timestamp);
				}
				if (this.hasInstigator)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeUInt64Size(3, this.Instigator);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x00048548 File Offset: 0x00046748
		public static global::RustProto.AwayEvent ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0004855C File Offset: 0x0004675C
		public static global::RustProto.AwayEvent ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001558 RID: 5464 RVA: 0x00048570 File Offset: 0x00046770
		public static global::RustProto.AwayEvent ParseFrom(byte[] data)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x00048584 File Offset: 0x00046784
		public static global::RustProto.AwayEvent ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x00048598 File Offset: 0x00046798
		public static global::RustProto.AwayEvent ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x000485AC File Offset: 0x000467AC
		public static global::RustProto.AwayEvent ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x000485C0 File Offset: 0x000467C0
		public static global::RustProto.AwayEvent ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x000485D4 File Offset: 0x000467D4
		public static global::RustProto.AwayEvent ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x000485E8 File Offset: 0x000467E8
		public static global::RustProto.AwayEvent ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x000485FC File Offset: 0x000467FC
		public static global::RustProto.AwayEvent ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.AwayEvent.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001560 RID: 5472 RVA: 0x00048610 File Offset: 0x00046810
		private global::RustProto.AwayEvent MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001561 RID: 5473 RVA: 0x00048614 File Offset: 0x00046814
		public static global::RustProto.AwayEvent.Builder CreateBuilder()
		{
			return new global::RustProto.AwayEvent.Builder();
		}

		// Token: 0x06001562 RID: 5474 RVA: 0x0004861C File Offset: 0x0004681C
		public override global::RustProto.AwayEvent.Builder ToBuilder()
		{
			return global::RustProto.AwayEvent.CreateBuilder(this);
		}

		// Token: 0x06001563 RID: 5475 RVA: 0x00048624 File Offset: 0x00046824
		public override global::RustProto.AwayEvent.Builder CreateBuilderForType()
		{
			return new global::RustProto.AwayEvent.Builder();
		}

		// Token: 0x06001564 RID: 5476 RVA: 0x0004862C File Offset: 0x0004682C
		public static global::RustProto.AwayEvent.Builder CreateBuilder(global::RustProto.AwayEvent prototype)
		{
			return new global::RustProto.AwayEvent.Builder(prototype);
		}

		// Token: 0x04000B30 RID: 2864
		public const int TypeFieldNumber = 1;

		// Token: 0x04000B31 RID: 2865
		public const int TimestampFieldNumber = 2;

		// Token: 0x04000B32 RID: 2866
		public const int InstigatorFieldNumber = 3;

		// Token: 0x04000B33 RID: 2867
		private static readonly global::RustProto.AwayEvent defaultInstance = new global::RustProto.AwayEvent().MakeReadOnly();

		// Token: 0x04000B34 RID: 2868
		private static readonly string[] _awayEventFieldNames = new string[]
		{
			"instigator",
			"timestamp",
			"type"
		};

		// Token: 0x04000B35 RID: 2869
		private static readonly uint[] _awayEventFieldTags = new uint[]
		{
			0x18U,
			0x10U,
			8U
		};

		// Token: 0x04000B36 RID: 2870
		private bool hasType;

		// Token: 0x04000B37 RID: 2871
		private global::RustProto.AwayEvent.Types.AwayEventType type_;

		// Token: 0x04000B38 RID: 2872
		private bool hasTimestamp;

		// Token: 0x04000B39 RID: 2873
		private int timestamp_;

		// Token: 0x04000B3A RID: 2874
		private bool hasInstigator;

		// Token: 0x04000B3B RID: 2875
		private ulong instigator_;

		// Token: 0x04000B3C RID: 2876
		private int memoizedSerializedSize = -1;

		// Token: 0x02000264 RID: 612
		[global::System.Diagnostics.DebuggerNonUserCode]
		public static class Types
		{
			// Token: 0x02000265 RID: 613
			public enum AwayEventType
			{
				// Token: 0x04000B3E RID: 2878
				UNKNOWN,
				// Token: 0x04000B3F RID: 2879
				SLUMBER,
				// Token: 0x04000B40 RID: 2880
				DIED
			}
		}

		// Token: 0x02000266 RID: 614
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder>
		{
			// Token: 0x06001565 RID: 5477 RVA: 0x00048634 File Offset: 0x00046834
			public Builder()
			{
				this.result = global::RustProto.AwayEvent.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001566 RID: 5478 RVA: 0x00048650 File Offset: 0x00046850
			internal Builder(global::RustProto.AwayEvent cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x170005EA RID: 1514
			// (get) Token: 0x06001567 RID: 5479 RVA: 0x00048668 File Offset: 0x00046868
			protected override global::RustProto.AwayEvent.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001568 RID: 5480 RVA: 0x0004866C File Offset: 0x0004686C
			private global::RustProto.AwayEvent PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.AwayEvent other = this.result;
					this.result = new global::RustProto.AwayEvent();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170005EB RID: 1515
			// (get) Token: 0x06001569 RID: 5481 RVA: 0x000486AC File Offset: 0x000468AC
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170005EC RID: 1516
			// (get) Token: 0x0600156A RID: 5482 RVA: 0x000486BC File Offset: 0x000468BC
			protected override global::RustProto.AwayEvent MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x0600156B RID: 5483 RVA: 0x000486C4 File Offset: 0x000468C4
			public override global::RustProto.AwayEvent.Builder Clear()
			{
				this.result = global::RustProto.AwayEvent.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x0600156C RID: 5484 RVA: 0x000486DC File Offset: 0x000468DC
			public override global::RustProto.AwayEvent.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.AwayEvent.Builder(this.result);
				}
				return new global::RustProto.AwayEvent.Builder().MergeFrom(this.result);
			}

			// Token: 0x170005ED RID: 1517
			// (get) Token: 0x0600156D RID: 5485 RVA: 0x00048708 File Offset: 0x00046908
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.AwayEvent.Descriptor;
				}
			}

			// Token: 0x170005EE RID: 1518
			// (get) Token: 0x0600156E RID: 5486 RVA: 0x00048710 File Offset: 0x00046910
			public override global::RustProto.AwayEvent DefaultInstanceForType
			{
				get
				{
					return global::RustProto.AwayEvent.DefaultInstance;
				}
			}

			// Token: 0x0600156F RID: 5487 RVA: 0x00048718 File Offset: 0x00046918
			public override global::RustProto.AwayEvent BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001570 RID: 5488 RVA: 0x0004874C File Offset: 0x0004694C
			public override global::RustProto.AwayEvent.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.AwayEvent)
				{
					return this.MergeFrom((global::RustProto.AwayEvent)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001571 RID: 5489 RVA: 0x00048770 File Offset: 0x00046970
			public override global::RustProto.AwayEvent.Builder MergeFrom(global::RustProto.AwayEvent other)
			{
				if (other == global::RustProto.AwayEvent.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasType)
				{
					this.Type = other.Type;
				}
				if (other.HasTimestamp)
				{
					this.Timestamp = other.Timestamp;
				}
				if (other.HasInstigator)
				{
					this.Instigator = other.Instigator;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001572 RID: 5490 RVA: 0x000487E4 File Offset: 0x000469E4
			public override global::RustProto.AwayEvent.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001573 RID: 5491 RVA: 0x000487F4 File Offset: 0x000469F4
			public override global::RustProto.AwayEvent.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.AwayEvent._awayEventFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.AwayEvent._awayEventFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					object obj;
					if (num3 != 8U)
					{
						if (num3 != 0x10U)
						{
							if (num3 != 0x18U)
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
								this.result.hasInstigator = input.ReadUInt64(ref this.result.instigator_);
							}
						}
						else
						{
							this.result.hasTimestamp = input.ReadInt32(ref this.result.timestamp_);
						}
					}
					else if (input.ReadEnum<global::RustProto.AwayEvent.Types.AwayEventType>(ref this.result.type_, ref obj))
					{
						this.result.hasType = true;
					}
					else if (obj is int)
					{
						if (builder == null)
						{
							builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
						}
						builder.MergeVarintField(1, (ulong)((long)((int)obj)));
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x170005EF RID: 1519
			// (get) Token: 0x06001574 RID: 5492 RVA: 0x00048998 File Offset: 0x00046B98
			public bool HasType
			{
				get
				{
					return this.result.hasType;
				}
			}

			// Token: 0x170005F0 RID: 1520
			// (get) Token: 0x06001575 RID: 5493 RVA: 0x000489A8 File Offset: 0x00046BA8
			// (set) Token: 0x06001576 RID: 5494 RVA: 0x000489B8 File Offset: 0x00046BB8
			public global::RustProto.AwayEvent.Types.AwayEventType Type
			{
				get
				{
					return this.result.Type;
				}
				set
				{
					this.SetType(value);
				}
			}

			// Token: 0x06001577 RID: 5495 RVA: 0x000489C4 File Offset: 0x00046BC4
			public global::RustProto.AwayEvent.Builder SetType(global::RustProto.AwayEvent.Types.AwayEventType value)
			{
				this.PrepareBuilder();
				this.result.hasType = true;
				this.result.type_ = value;
				return this;
			}

			// Token: 0x06001578 RID: 5496 RVA: 0x000489F4 File Offset: 0x00046BF4
			public global::RustProto.AwayEvent.Builder ClearType()
			{
				this.PrepareBuilder();
				this.result.hasType = false;
				this.result.type_ = global::RustProto.AwayEvent.Types.AwayEventType.UNKNOWN;
				return this;
			}

			// Token: 0x170005F1 RID: 1521
			// (get) Token: 0x06001579 RID: 5497 RVA: 0x00048A24 File Offset: 0x00046C24
			public bool HasTimestamp
			{
				get
				{
					return this.result.hasTimestamp;
				}
			}

			// Token: 0x170005F2 RID: 1522
			// (get) Token: 0x0600157A RID: 5498 RVA: 0x00048A34 File Offset: 0x00046C34
			// (set) Token: 0x0600157B RID: 5499 RVA: 0x00048A44 File Offset: 0x00046C44
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

			// Token: 0x0600157C RID: 5500 RVA: 0x00048A50 File Offset: 0x00046C50
			public global::RustProto.AwayEvent.Builder SetTimestamp(int value)
			{
				this.PrepareBuilder();
				this.result.hasTimestamp = true;
				this.result.timestamp_ = value;
				return this;
			}

			// Token: 0x0600157D RID: 5501 RVA: 0x00048A80 File Offset: 0x00046C80
			public global::RustProto.AwayEvent.Builder ClearTimestamp()
			{
				this.PrepareBuilder();
				this.result.hasTimestamp = false;
				this.result.timestamp_ = 0;
				return this;
			}

			// Token: 0x170005F3 RID: 1523
			// (get) Token: 0x0600157E RID: 5502 RVA: 0x00048AB0 File Offset: 0x00046CB0
			public bool HasInstigator
			{
				get
				{
					return this.result.hasInstigator;
				}
			}

			// Token: 0x170005F4 RID: 1524
			// (get) Token: 0x0600157F RID: 5503 RVA: 0x00048AC0 File Offset: 0x00046CC0
			// (set) Token: 0x06001580 RID: 5504 RVA: 0x00048AD0 File Offset: 0x00046CD0
			[global::System.CLSCompliant(false)]
			public ulong Instigator
			{
				get
				{
					return this.result.Instigator;
				}
				set
				{
					this.SetInstigator(value);
				}
			}

			// Token: 0x06001581 RID: 5505 RVA: 0x00048ADC File Offset: 0x00046CDC
			[global::System.CLSCompliant(false)]
			public global::RustProto.AwayEvent.Builder SetInstigator(ulong value)
			{
				this.PrepareBuilder();
				this.result.hasInstigator = true;
				this.result.instigator_ = value;
				return this;
			}

			// Token: 0x06001582 RID: 5506 RVA: 0x00048B0C File Offset: 0x00046D0C
			public global::RustProto.AwayEvent.Builder ClearInstigator()
			{
				this.PrepareBuilder();
				this.result.hasInstigator = false;
				this.result.instigator_ = 0UL;
				return this;
			}

			// Token: 0x04000B41 RID: 2881
			private bool resultIsReadOnly;

			// Token: 0x04000B42 RID: 2882
			private global::RustProto.AwayEvent result;
		}
	}
}

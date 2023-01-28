using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x02000247 RID: 583
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectCoords : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder>
	{
		// Token: 0x060011DE RID: 4574 RVA: 0x000414F8 File Offset: 0x0003F6F8
		private objectCoords()
		{
		}

		// Token: 0x060011DF RID: 4575 RVA: 0x00041508 File Offset: 0x0003F708
		static objectCoords()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x00041574 File Offset: 0x0003F774
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder>.Manufacture();
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x060011E1 RID: 4577 RVA: 0x0004157C File Offset: 0x0003F77C
		public static global::RustProto.objectCoords DefaultInstance
		{
			get
			{
				return global::RustProto.objectCoords.defaultInstance;
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x060011E2 RID: 4578 RVA: 0x00041584 File Offset: 0x0003F784
		public override global::RustProto.objectCoords DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectCoords.DefaultInstance;
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x060011E3 RID: 4579 RVA: 0x0004158C File Offset: 0x0003F78C
		protected override global::RustProto.objectCoords ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x060011E4 RID: 4580 RVA: 0x00041590 File Offset: 0x0003F790
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectCoords__Descriptor;
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x060011E5 RID: 4581 RVA: 0x00041598 File Offset: 0x0003F798
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectCoords__FieldAccessorTable;
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x060011E6 RID: 4582 RVA: 0x000415A0 File Offset: 0x0003F7A0
		public bool HasPos
		{
			get
			{
				return this.hasPos;
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x060011E7 RID: 4583 RVA: 0x000415A8 File Offset: 0x0003F7A8
		public global::RustProto.Vector Pos
		{
			get
			{
				return this.pos_ ?? global::RustProto.Vector.DefaultInstance;
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x060011E8 RID: 4584 RVA: 0x000415BC File Offset: 0x0003F7BC
		public bool HasOldPos
		{
			get
			{
				return this.hasOldPos;
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x060011E9 RID: 4585 RVA: 0x000415C4 File Offset: 0x0003F7C4
		public global::RustProto.Vector OldPos
		{
			get
			{
				return this.oldPos_ ?? global::RustProto.Vector.DefaultInstance;
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x060011EA RID: 4586 RVA: 0x000415D8 File Offset: 0x0003F7D8
		public bool HasRot
		{
			get
			{
				return this.hasRot;
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x060011EB RID: 4587 RVA: 0x000415E0 File Offset: 0x0003F7E0
		public global::RustProto.Quaternion Rot
		{
			get
			{
				return this.rot_ ?? global::RustProto.Quaternion.DefaultInstance;
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x060011EC RID: 4588 RVA: 0x000415F4 File Offset: 0x0003F7F4
		public bool HasOldRot
		{
			get
			{
				return this.hasOldRot;
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x060011ED RID: 4589 RVA: 0x000415FC File Offset: 0x0003F7FC
		public global::RustProto.Quaternion OldRot
		{
			get
			{
				return this.oldRot_ ?? global::RustProto.Quaternion.DefaultInstance;
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x060011EE RID: 4590 RVA: 0x00041610 File Offset: 0x0003F810
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x00041614 File Offset: 0x0003F814
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectCoordsFieldNames = global::RustProto.objectCoords._objectCoordsFieldNames;
			if (this.hasPos)
			{
				output.WriteMessage(1, objectCoordsFieldNames[2], this.Pos);
			}
			if (this.hasOldPos)
			{
				output.WriteMessage(2, objectCoordsFieldNames[0], this.OldPos);
			}
			if (this.hasRot)
			{
				output.WriteMessage(3, objectCoordsFieldNames[3], this.Rot);
			}
			if (this.hasOldRot)
			{
				output.WriteMessage(4, objectCoordsFieldNames[1], this.OldRot);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x060011F0 RID: 4592 RVA: 0x000416A8 File Offset: 0x0003F8A8
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
				if (this.hasPos)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(1, this.Pos);
				}
				if (this.hasOldPos)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(2, this.OldPos);
				}
				if (this.hasRot)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(3, this.Rot);
				}
				if (this.hasOldRot)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(4, this.OldRot);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060011F1 RID: 4593 RVA: 0x00041748 File Offset: 0x0003F948
		public static global::RustProto.objectCoords ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060011F2 RID: 4594 RVA: 0x0004175C File Offset: 0x0003F95C
		public static global::RustProto.objectCoords ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x00041770 File Offset: 0x0003F970
		public static global::RustProto.objectCoords ParseFrom(byte[] data)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060011F4 RID: 4596 RVA: 0x00041784 File Offset: 0x0003F984
		public static global::RustProto.objectCoords ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060011F5 RID: 4597 RVA: 0x00041798 File Offset: 0x0003F998
		public static global::RustProto.objectCoords ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x000417AC File Offset: 0x0003F9AC
		public static global::RustProto.objectCoords ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060011F7 RID: 4599 RVA: 0x000417C0 File Offset: 0x0003F9C0
		public static global::RustProto.objectCoords ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060011F8 RID: 4600 RVA: 0x000417D4 File Offset: 0x0003F9D4
		public static global::RustProto.objectCoords ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x000417E8 File Offset: 0x0003F9E8
		public static global::RustProto.objectCoords ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x000417FC File Offset: 0x0003F9FC
		public static global::RustProto.objectCoords ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectCoords.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x00041810 File Offset: 0x0003FA10
		private global::RustProto.objectCoords MakeReadOnly()
		{
			return this;
		}

		// Token: 0x060011FC RID: 4604 RVA: 0x00041814 File Offset: 0x0003FA14
		public static global::RustProto.objectCoords.Builder CreateBuilder()
		{
			return new global::RustProto.objectCoords.Builder();
		}

		// Token: 0x060011FD RID: 4605 RVA: 0x0004181C File Offset: 0x0003FA1C
		public override global::RustProto.objectCoords.Builder ToBuilder()
		{
			return global::RustProto.objectCoords.CreateBuilder(this);
		}

		// Token: 0x060011FE RID: 4606 RVA: 0x00041824 File Offset: 0x0003FA24
		public override global::RustProto.objectCoords.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectCoords.Builder();
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x0004182C File Offset: 0x0003FA2C
		public static global::RustProto.objectCoords.Builder CreateBuilder(global::RustProto.objectCoords prototype)
		{
			return new global::RustProto.objectCoords.Builder(prototype);
		}

		// Token: 0x04000A65 RID: 2661
		public const int PosFieldNumber = 1;

		// Token: 0x04000A66 RID: 2662
		public const int OldPosFieldNumber = 2;

		// Token: 0x04000A67 RID: 2663
		public const int RotFieldNumber = 3;

		// Token: 0x04000A68 RID: 2664
		public const int OldRotFieldNumber = 4;

		// Token: 0x04000A69 RID: 2665
		private static readonly global::RustProto.objectCoords defaultInstance = new global::RustProto.objectCoords().MakeReadOnly();

		// Token: 0x04000A6A RID: 2666
		private static readonly string[] _objectCoordsFieldNames = new string[]
		{
			"oldPos",
			"oldRot",
			"pos",
			"rot"
		};

		// Token: 0x04000A6B RID: 2667
		private static readonly uint[] _objectCoordsFieldTags = new uint[]
		{
			0x12U,
			0x22U,
			0xAU,
			0x1AU
		};

		// Token: 0x04000A6C RID: 2668
		private bool hasPos;

		// Token: 0x04000A6D RID: 2669
		private global::RustProto.Vector pos_;

		// Token: 0x04000A6E RID: 2670
		private bool hasOldPos;

		// Token: 0x04000A6F RID: 2671
		private global::RustProto.Vector oldPos_;

		// Token: 0x04000A70 RID: 2672
		private bool hasRot;

		// Token: 0x04000A71 RID: 2673
		private global::RustProto.Quaternion rot_;

		// Token: 0x04000A72 RID: 2674
		private bool hasOldRot;

		// Token: 0x04000A73 RID: 2675
		private global::RustProto.Quaternion oldRot_;

		// Token: 0x04000A74 RID: 2676
		private int memoizedSerializedSize = -1;

		// Token: 0x02000248 RID: 584
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder>
		{
			// Token: 0x06001200 RID: 4608 RVA: 0x00041834 File Offset: 0x0003FA34
			public Builder()
			{
				this.result = global::RustProto.objectCoords.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06001201 RID: 4609 RVA: 0x00041850 File Offset: 0x0003FA50
			internal Builder(global::RustProto.objectCoords cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x170004A4 RID: 1188
			// (get) Token: 0x06001202 RID: 4610 RVA: 0x00041868 File Offset: 0x0003FA68
			protected override global::RustProto.objectCoords.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06001203 RID: 4611 RVA: 0x0004186C File Offset: 0x0003FA6C
			private global::RustProto.objectCoords PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectCoords other = this.result;
					this.result = new global::RustProto.objectCoords();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x170004A5 RID: 1189
			// (get) Token: 0x06001204 RID: 4612 RVA: 0x000418AC File Offset: 0x0003FAAC
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x170004A6 RID: 1190
			// (get) Token: 0x06001205 RID: 4613 RVA: 0x000418BC File Offset: 0x0003FABC
			protected override global::RustProto.objectCoords MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06001206 RID: 4614 RVA: 0x000418C4 File Offset: 0x0003FAC4
			public override global::RustProto.objectCoords.Builder Clear()
			{
				this.result = global::RustProto.objectCoords.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001207 RID: 4615 RVA: 0x000418DC File Offset: 0x0003FADC
			public override global::RustProto.objectCoords.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectCoords.Builder(this.result);
				}
				return new global::RustProto.objectCoords.Builder().MergeFrom(this.result);
			}

			// Token: 0x170004A7 RID: 1191
			// (get) Token: 0x06001208 RID: 4616 RVA: 0x00041908 File Offset: 0x0003FB08
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectCoords.Descriptor;
				}
			}

			// Token: 0x170004A8 RID: 1192
			// (get) Token: 0x06001209 RID: 4617 RVA: 0x00041910 File Offset: 0x0003FB10
			public override global::RustProto.objectCoords DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectCoords.DefaultInstance;
				}
			}

			// Token: 0x0600120A RID: 4618 RVA: 0x00041918 File Offset: 0x0003FB18
			public override global::RustProto.objectCoords BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x0600120B RID: 4619 RVA: 0x0004194C File Offset: 0x0003FB4C
			public override global::RustProto.objectCoords.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectCoords)
				{
					return this.MergeFrom((global::RustProto.objectCoords)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x0600120C RID: 4620 RVA: 0x00041970 File Offset: 0x0003FB70
			public override global::RustProto.objectCoords.Builder MergeFrom(global::RustProto.objectCoords other)
			{
				if (other == global::RustProto.objectCoords.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasPos)
				{
					this.MergePos(other.Pos);
				}
				if (other.HasOldPos)
				{
					this.MergeOldPos(other.OldPos);
				}
				if (other.HasRot)
				{
					this.MergeRot(other.Rot);
				}
				if (other.HasOldRot)
				{
					this.MergeOldRot(other.OldRot);
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x0600120D RID: 4621 RVA: 0x00041A00 File Offset: 0x0003FC00
			public override global::RustProto.objectCoords.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x0600120E RID: 4622 RVA: 0x00041A10 File Offset: 0x0003FC10
			public override global::RustProto.objectCoords.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectCoords._objectCoordsFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectCoords._objectCoordsFieldTags[num2];
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
							if (num3 != 0x1AU)
							{
								if (num3 != 0x22U)
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
									global::RustProto.Quaternion.Builder builder2 = global::RustProto.Quaternion.CreateBuilder();
									if (this.result.hasOldRot)
									{
										builder2.MergeFrom(this.OldRot);
									}
									input.ReadMessage(builder2, extensionRegistry);
									this.OldRot = builder2.BuildPartial();
								}
							}
							else
							{
								global::RustProto.Quaternion.Builder builder3 = global::RustProto.Quaternion.CreateBuilder();
								if (this.result.hasRot)
								{
									builder3.MergeFrom(this.Rot);
								}
								input.ReadMessage(builder3, extensionRegistry);
								this.Rot = builder3.BuildPartial();
							}
						}
						else
						{
							global::RustProto.Vector.Builder builder4 = global::RustProto.Vector.CreateBuilder();
							if (this.result.hasOldPos)
							{
								builder4.MergeFrom(this.OldPos);
							}
							input.ReadMessage(builder4, extensionRegistry);
							this.OldPos = builder4.BuildPartial();
						}
					}
					else
					{
						global::RustProto.Vector.Builder builder5 = global::RustProto.Vector.CreateBuilder();
						if (this.result.hasPos)
						{
							builder5.MergeFrom(this.Pos);
						}
						input.ReadMessage(builder5, extensionRegistry);
						this.Pos = builder5.BuildPartial();
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x170004A9 RID: 1193
			// (get) Token: 0x0600120F RID: 4623 RVA: 0x00041C20 File Offset: 0x0003FE20
			public bool HasPos
			{
				get
				{
					return this.result.hasPos;
				}
			}

			// Token: 0x170004AA RID: 1194
			// (get) Token: 0x06001210 RID: 4624 RVA: 0x00041C30 File Offset: 0x0003FE30
			// (set) Token: 0x06001211 RID: 4625 RVA: 0x00041C40 File Offset: 0x0003FE40
			public global::RustProto.Vector Pos
			{
				get
				{
					return this.result.Pos;
				}
				set
				{
					this.SetPos(value);
				}
			}

			// Token: 0x06001212 RID: 4626 RVA: 0x00041C4C File Offset: 0x0003FE4C
			public global::RustProto.objectCoords.Builder SetPos(global::RustProto.Vector value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasPos = true;
				this.result.pos_ = value;
				return this;
			}

			// Token: 0x06001213 RID: 4627 RVA: 0x00041C7C File Offset: 0x0003FE7C
			public global::RustProto.objectCoords.Builder SetPos(global::RustProto.Vector.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasPos = true;
				this.result.pos_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06001214 RID: 4628 RVA: 0x00041CBC File Offset: 0x0003FEBC
			public global::RustProto.objectCoords.Builder MergePos(global::RustProto.Vector value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasPos && this.result.pos_ != global::RustProto.Vector.DefaultInstance)
				{
					this.result.pos_ = global::RustProto.Vector.CreateBuilder(this.result.pos_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.pos_ = value;
				}
				this.result.hasPos = true;
				return this;
			}

			// Token: 0x06001215 RID: 4629 RVA: 0x00041D44 File Offset: 0x0003FF44
			public global::RustProto.objectCoords.Builder ClearPos()
			{
				this.PrepareBuilder();
				this.result.hasPos = false;
				this.result.pos_ = null;
				return this;
			}

			// Token: 0x170004AB RID: 1195
			// (get) Token: 0x06001216 RID: 4630 RVA: 0x00041D74 File Offset: 0x0003FF74
			public bool HasOldPos
			{
				get
				{
					return this.result.hasOldPos;
				}
			}

			// Token: 0x170004AC RID: 1196
			// (get) Token: 0x06001217 RID: 4631 RVA: 0x00041D84 File Offset: 0x0003FF84
			// (set) Token: 0x06001218 RID: 4632 RVA: 0x00041D94 File Offset: 0x0003FF94
			public global::RustProto.Vector OldPos
			{
				get
				{
					return this.result.OldPos;
				}
				set
				{
					this.SetOldPos(value);
				}
			}

			// Token: 0x06001219 RID: 4633 RVA: 0x00041DA0 File Offset: 0x0003FFA0
			public global::RustProto.objectCoords.Builder SetOldPos(global::RustProto.Vector value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasOldPos = true;
				this.result.oldPos_ = value;
				return this;
			}

			// Token: 0x0600121A RID: 4634 RVA: 0x00041DD0 File Offset: 0x0003FFD0
			public global::RustProto.objectCoords.Builder SetOldPos(global::RustProto.Vector.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasOldPos = true;
				this.result.oldPos_ = builderForValue.Build();
				return this;
			}

			// Token: 0x0600121B RID: 4635 RVA: 0x00041E10 File Offset: 0x00040010
			public global::RustProto.objectCoords.Builder MergeOldPos(global::RustProto.Vector value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasOldPos && this.result.oldPos_ != global::RustProto.Vector.DefaultInstance)
				{
					this.result.oldPos_ = global::RustProto.Vector.CreateBuilder(this.result.oldPos_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.oldPos_ = value;
				}
				this.result.hasOldPos = true;
				return this;
			}

			// Token: 0x0600121C RID: 4636 RVA: 0x00041E98 File Offset: 0x00040098
			public global::RustProto.objectCoords.Builder ClearOldPos()
			{
				this.PrepareBuilder();
				this.result.hasOldPos = false;
				this.result.oldPos_ = null;
				return this;
			}

			// Token: 0x170004AD RID: 1197
			// (get) Token: 0x0600121D RID: 4637 RVA: 0x00041EC8 File Offset: 0x000400C8
			public bool HasRot
			{
				get
				{
					return this.result.hasRot;
				}
			}

			// Token: 0x170004AE RID: 1198
			// (get) Token: 0x0600121E RID: 4638 RVA: 0x00041ED8 File Offset: 0x000400D8
			// (set) Token: 0x0600121F RID: 4639 RVA: 0x00041EE8 File Offset: 0x000400E8
			public global::RustProto.Quaternion Rot
			{
				get
				{
					return this.result.Rot;
				}
				set
				{
					this.SetRot(value);
				}
			}

			// Token: 0x06001220 RID: 4640 RVA: 0x00041EF4 File Offset: 0x000400F4
			public global::RustProto.objectCoords.Builder SetRot(global::RustProto.Quaternion value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasRot = true;
				this.result.rot_ = value;
				return this;
			}

			// Token: 0x06001221 RID: 4641 RVA: 0x00041F24 File Offset: 0x00040124
			public global::RustProto.objectCoords.Builder SetRot(global::RustProto.Quaternion.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasRot = true;
				this.result.rot_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06001222 RID: 4642 RVA: 0x00041F64 File Offset: 0x00040164
			public global::RustProto.objectCoords.Builder MergeRot(global::RustProto.Quaternion value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasRot && this.result.rot_ != global::RustProto.Quaternion.DefaultInstance)
				{
					this.result.rot_ = global::RustProto.Quaternion.CreateBuilder(this.result.rot_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.rot_ = value;
				}
				this.result.hasRot = true;
				return this;
			}

			// Token: 0x06001223 RID: 4643 RVA: 0x00041FEC File Offset: 0x000401EC
			public global::RustProto.objectCoords.Builder ClearRot()
			{
				this.PrepareBuilder();
				this.result.hasRot = false;
				this.result.rot_ = null;
				return this;
			}

			// Token: 0x170004AF RID: 1199
			// (get) Token: 0x06001224 RID: 4644 RVA: 0x0004201C File Offset: 0x0004021C
			public bool HasOldRot
			{
				get
				{
					return this.result.hasOldRot;
				}
			}

			// Token: 0x170004B0 RID: 1200
			// (get) Token: 0x06001225 RID: 4645 RVA: 0x0004202C File Offset: 0x0004022C
			// (set) Token: 0x06001226 RID: 4646 RVA: 0x0004203C File Offset: 0x0004023C
			public global::RustProto.Quaternion OldRot
			{
				get
				{
					return this.result.OldRot;
				}
				set
				{
					this.SetOldRot(value);
				}
			}

			// Token: 0x06001227 RID: 4647 RVA: 0x00042048 File Offset: 0x00040248
			public global::RustProto.objectCoords.Builder SetOldRot(global::RustProto.Quaternion value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasOldRot = true;
				this.result.oldRot_ = value;
				return this;
			}

			// Token: 0x06001228 RID: 4648 RVA: 0x00042078 File Offset: 0x00040278
			public global::RustProto.objectCoords.Builder SetOldRot(global::RustProto.Quaternion.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasOldRot = true;
				this.result.oldRot_ = builderForValue.Build();
				return this;
			}

			// Token: 0x06001229 RID: 4649 RVA: 0x000420B8 File Offset: 0x000402B8
			public global::RustProto.objectCoords.Builder MergeOldRot(global::RustProto.Quaternion value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasOldRot && this.result.oldRot_ != global::RustProto.Quaternion.DefaultInstance)
				{
					this.result.oldRot_ = global::RustProto.Quaternion.CreateBuilder(this.result.oldRot_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.oldRot_ = value;
				}
				this.result.hasOldRot = true;
				return this;
			}

			// Token: 0x0600122A RID: 4650 RVA: 0x00042140 File Offset: 0x00040340
			public global::RustProto.objectCoords.Builder ClearOldRot()
			{
				this.PrepareBuilder();
				this.result.hasOldRot = false;
				this.result.oldRot_ = null;
				return this;
			}

			// Token: 0x04000A75 RID: 2677
			private bool resultIsReadOnly;

			// Token: 0x04000A76 RID: 2678
			private global::RustProto.objectCoords result;
		}
	}
}

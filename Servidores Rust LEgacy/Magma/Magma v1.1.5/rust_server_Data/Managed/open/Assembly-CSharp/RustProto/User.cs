using System;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Proto;

namespace RustProto
{
	// Token: 0x02000275 RID: 629
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class User : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.User, global::RustProto.User.Builder>
	{
		// Token: 0x0600162A RID: 5674 RVA: 0x0004A020 File Offset: 0x00048220
		private User()
		{
		}

		// Token: 0x0600162B RID: 5675 RVA: 0x0004A03C File Offset: 0x0004823C
		static User()
		{
			object.ReferenceEquals(global::RustProto.Proto.User.Descriptor, null);
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x0004A0A0 File Offset: 0x000482A0
		public static global::RustProto.User DefaultInstance
		{
			get
			{
				return global::RustProto.User.defaultInstance;
			}
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x0600162D RID: 5677 RVA: 0x0004A0A8 File Offset: 0x000482A8
		public override global::RustProto.User DefaultInstanceForType
		{
			get
			{
				return global::RustProto.User.DefaultInstance;
			}
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x0600162E RID: 5678 RVA: 0x0004A0B0 File Offset: 0x000482B0
		protected override global::RustProto.User ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x0600162F RID: 5679 RVA: 0x0004A0B4 File Offset: 0x000482B4
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.User.internal__static_RustProto_User__Descriptor;
			}
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x06001630 RID: 5680 RVA: 0x0004A0BC File Offset: 0x000482BC
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.User, global::RustProto.User.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Proto.User.internal__static_RustProto_User__FieldAccessorTable;
			}
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x06001631 RID: 5681 RVA: 0x0004A0C4 File Offset: 0x000482C4
		public bool HasUserid
		{
			get
			{
				return this.hasUserid;
			}
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x06001632 RID: 5682 RVA: 0x0004A0CC File Offset: 0x000482CC
		[global::System.CLSCompliant(false)]
		public ulong Userid
		{
			get
			{
				return this.userid_;
			}
		}

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x06001633 RID: 5683 RVA: 0x0004A0D4 File Offset: 0x000482D4
		public bool HasDisplayname
		{
			get
			{
				return this.hasDisplayname;
			}
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x0004A0DC File Offset: 0x000482DC
		public string Displayname
		{
			get
			{
				return this.displayname_;
			}
		}

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06001635 RID: 5685 RVA: 0x0004A0E4 File Offset: 0x000482E4
		public bool HasUsergroup
		{
			get
			{
				return this.hasUsergroup;
			}
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x06001636 RID: 5686 RVA: 0x0004A0EC File Offset: 0x000482EC
		public global::RustProto.User.Types.UserGroup Usergroup
		{
			get
			{
				return this.usergroup_;
			}
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x06001637 RID: 5687 RVA: 0x0004A0F4 File Offset: 0x000482F4
		public override bool IsInitialized
		{
			get
			{
				return this.hasUserid && this.hasDisplayname && this.hasUsergroup;
			}
		}

		// Token: 0x06001638 RID: 5688 RVA: 0x0004A12C File Offset: 0x0004832C
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] userFieldNames = global::RustProto.User._userFieldNames;
			if (this.hasUserid)
			{
				output.WriteUInt64(1, userFieldNames[2], this.Userid);
			}
			if (this.hasDisplayname)
			{
				output.WriteString(2, userFieldNames[0], this.Displayname);
			}
			if (this.hasUsergroup)
			{
				output.WriteEnum(3, userFieldNames[1], (int)this.Usergroup, this.Usergroup);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x06001639 RID: 5689 RVA: 0x0004A1B0 File Offset: 0x000483B0
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
				if (this.hasUserid)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeUInt64Size(1, this.Userid);
				}
				if (this.hasDisplayname)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeStringSize(2, this.Displayname);
				}
				if (this.hasUsergroup)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeEnumSize(3, (int)this.Usergroup);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x0600163A RID: 5690 RVA: 0x0004A234 File Offset: 0x00048434
		public static global::RustProto.User ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.User.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600163B RID: 5691 RVA: 0x0004A248 File Offset: 0x00048448
		public static global::RustProto.User ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.User.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600163C RID: 5692 RVA: 0x0004A25C File Offset: 0x0004845C
		public static global::RustProto.User ParseFrom(byte[] data)
		{
			return global::RustProto.User.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x0600163D RID: 5693 RVA: 0x0004A270 File Offset: 0x00048470
		public static global::RustProto.User ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.User.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x0600163E RID: 5694 RVA: 0x0004A284 File Offset: 0x00048484
		public static global::RustProto.User ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.User.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x0600163F RID: 5695 RVA: 0x0004A298 File Offset: 0x00048498
		public static global::RustProto.User ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.User.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x0004A2AC File Offset: 0x000484AC
		public static global::RustProto.User ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.User.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06001641 RID: 5697 RVA: 0x0004A2C0 File Offset: 0x000484C0
		public static global::RustProto.User ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.User.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001642 RID: 5698 RVA: 0x0004A2D4 File Offset: 0x000484D4
		public static global::RustProto.User ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.User.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06001643 RID: 5699 RVA: 0x0004A2E8 File Offset: 0x000484E8
		public static global::RustProto.User ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.User.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06001644 RID: 5700 RVA: 0x0004A2FC File Offset: 0x000484FC
		private global::RustProto.User MakeReadOnly()
		{
			return this;
		}

		// Token: 0x06001645 RID: 5701 RVA: 0x0004A300 File Offset: 0x00048500
		public static global::RustProto.User.Builder CreateBuilder()
		{
			return new global::RustProto.User.Builder();
		}

		// Token: 0x06001646 RID: 5702 RVA: 0x0004A308 File Offset: 0x00048508
		public override global::RustProto.User.Builder ToBuilder()
		{
			return global::RustProto.User.CreateBuilder(this);
		}

		// Token: 0x06001647 RID: 5703 RVA: 0x0004A310 File Offset: 0x00048510
		public override global::RustProto.User.Builder CreateBuilderForType()
		{
			return new global::RustProto.User.Builder();
		}

		// Token: 0x06001648 RID: 5704 RVA: 0x0004A318 File Offset: 0x00048518
		public static global::RustProto.User.Builder CreateBuilder(global::RustProto.User prototype)
		{
			return new global::RustProto.User.Builder(prototype);
		}

		// Token: 0x04000B84 RID: 2948
		public const int UseridFieldNumber = 1;

		// Token: 0x04000B85 RID: 2949
		public const int DisplaynameFieldNumber = 2;

		// Token: 0x04000B86 RID: 2950
		public const int UsergroupFieldNumber = 3;

		// Token: 0x04000B87 RID: 2951
		private static readonly global::RustProto.User defaultInstance = new global::RustProto.User().MakeReadOnly();

		// Token: 0x04000B88 RID: 2952
		private static readonly string[] _userFieldNames = new string[]
		{
			"displayname",
			"usergroup",
			"userid"
		};

		// Token: 0x04000B89 RID: 2953
		private static readonly uint[] _userFieldTags = new uint[]
		{
			0x12U,
			0x18U,
			8U
		};

		// Token: 0x04000B8A RID: 2954
		private bool hasUserid;

		// Token: 0x04000B8B RID: 2955
		private ulong userid_;

		// Token: 0x04000B8C RID: 2956
		private bool hasDisplayname;

		// Token: 0x04000B8D RID: 2957
		private string displayname_ = string.Empty;

		// Token: 0x04000B8E RID: 2958
		private bool hasUsergroup;

		// Token: 0x04000B8F RID: 2959
		private global::RustProto.User.Types.UserGroup usergroup_;

		// Token: 0x04000B90 RID: 2960
		private int memoizedSerializedSize = -1;

		// Token: 0x02000276 RID: 630
		[global::System.Diagnostics.DebuggerNonUserCode]
		public static class Types
		{
			// Token: 0x02000277 RID: 631
			public enum UserGroup
			{
				// Token: 0x04000B92 RID: 2962
				REGULAR,
				// Token: 0x04000B93 RID: 2963
				BANNED,
				// Token: 0x04000B94 RID: 2964
				ADMIN
			}
		}

		// Token: 0x02000278 RID: 632
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.User, global::RustProto.User.Builder>
		{
			// Token: 0x06001649 RID: 5705 RVA: 0x0004A320 File Offset: 0x00048520
			public Builder()
			{
				this.result = global::RustProto.User.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x0600164A RID: 5706 RVA: 0x0004A33C File Offset: 0x0004853C
			internal Builder(global::RustProto.User cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000631 RID: 1585
			// (get) Token: 0x0600164B RID: 5707 RVA: 0x0004A354 File Offset: 0x00048554
			protected override global::RustProto.User.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x0600164C RID: 5708 RVA: 0x0004A358 File Offset: 0x00048558
			private global::RustProto.User PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.User other = this.result;
					this.result = new global::RustProto.User();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000632 RID: 1586
			// (get) Token: 0x0600164D RID: 5709 RVA: 0x0004A398 File Offset: 0x00048598
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000633 RID: 1587
			// (get) Token: 0x0600164E RID: 5710 RVA: 0x0004A3A8 File Offset: 0x000485A8
			protected override global::RustProto.User MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x0600164F RID: 5711 RVA: 0x0004A3B0 File Offset: 0x000485B0
			public override global::RustProto.User.Builder Clear()
			{
				this.result = global::RustProto.User.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06001650 RID: 5712 RVA: 0x0004A3C8 File Offset: 0x000485C8
			public override global::RustProto.User.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.User.Builder(this.result);
				}
				return new global::RustProto.User.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000634 RID: 1588
			// (get) Token: 0x06001651 RID: 5713 RVA: 0x0004A3F4 File Offset: 0x000485F4
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.User.Descriptor;
				}
			}

			// Token: 0x17000635 RID: 1589
			// (get) Token: 0x06001652 RID: 5714 RVA: 0x0004A3FC File Offset: 0x000485FC
			public override global::RustProto.User DefaultInstanceForType
			{
				get
				{
					return global::RustProto.User.DefaultInstance;
				}
			}

			// Token: 0x06001653 RID: 5715 RVA: 0x0004A404 File Offset: 0x00048604
			public override global::RustProto.User BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06001654 RID: 5716 RVA: 0x0004A438 File Offset: 0x00048638
			public override global::RustProto.User.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.User)
				{
					return this.MergeFrom((global::RustProto.User)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06001655 RID: 5717 RVA: 0x0004A45C File Offset: 0x0004865C
			public override global::RustProto.User.Builder MergeFrom(global::RustProto.User other)
			{
				if (other == global::RustProto.User.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasUserid)
				{
					this.Userid = other.Userid;
				}
				if (other.HasDisplayname)
				{
					this.Displayname = other.Displayname;
				}
				if (other.HasUsergroup)
				{
					this.Usergroup = other.Usergroup;
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06001656 RID: 5718 RVA: 0x0004A4D0 File Offset: 0x000486D0
			public override global::RustProto.User.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06001657 RID: 5719 RVA: 0x0004A4E0 File Offset: 0x000486E0
			public override global::RustProto.User.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.User._userFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.User._userFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0U)
					{
						throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 8U)
					{
						if (num3 != 0x12U)
						{
							object obj;
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
							else if (input.ReadEnum<global::RustProto.User.Types.UserGroup>(ref this.result.usergroup_, ref obj))
							{
								this.result.hasUsergroup = true;
							}
							else if (obj is int)
							{
								if (builder == null)
								{
									builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
								}
								builder.MergeVarintField(3, (ulong)((long)((int)obj)));
							}
						}
						else
						{
							this.result.hasDisplayname = input.ReadString(ref this.result.displayname_);
						}
					}
					else
					{
						this.result.hasUserid = input.ReadUInt64(ref this.result.userid_);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x17000636 RID: 1590
			// (get) Token: 0x06001658 RID: 5720 RVA: 0x0004A684 File Offset: 0x00048884
			public bool HasUserid
			{
				get
				{
					return this.result.hasUserid;
				}
			}

			// Token: 0x17000637 RID: 1591
			// (get) Token: 0x06001659 RID: 5721 RVA: 0x0004A694 File Offset: 0x00048894
			// (set) Token: 0x0600165A RID: 5722 RVA: 0x0004A6A4 File Offset: 0x000488A4
			[global::System.CLSCompliant(false)]
			public ulong Userid
			{
				get
				{
					return this.result.Userid;
				}
				set
				{
					this.SetUserid(value);
				}
			}

			// Token: 0x0600165B RID: 5723 RVA: 0x0004A6B0 File Offset: 0x000488B0
			[global::System.CLSCompliant(false)]
			public global::RustProto.User.Builder SetUserid(ulong value)
			{
				this.PrepareBuilder();
				this.result.hasUserid = true;
				this.result.userid_ = value;
				return this;
			}

			// Token: 0x0600165C RID: 5724 RVA: 0x0004A6E0 File Offset: 0x000488E0
			public global::RustProto.User.Builder ClearUserid()
			{
				this.PrepareBuilder();
				this.result.hasUserid = false;
				this.result.userid_ = 0UL;
				return this;
			}

			// Token: 0x17000638 RID: 1592
			// (get) Token: 0x0600165D RID: 5725 RVA: 0x0004A704 File Offset: 0x00048904
			public bool HasDisplayname
			{
				get
				{
					return this.result.hasDisplayname;
				}
			}

			// Token: 0x17000639 RID: 1593
			// (get) Token: 0x0600165E RID: 5726 RVA: 0x0004A714 File Offset: 0x00048914
			// (set) Token: 0x0600165F RID: 5727 RVA: 0x0004A724 File Offset: 0x00048924
			public string Displayname
			{
				get
				{
					return this.result.Displayname;
				}
				set
				{
					this.SetDisplayname(value);
				}
			}

			// Token: 0x06001660 RID: 5728 RVA: 0x0004A730 File Offset: 0x00048930
			public global::RustProto.User.Builder SetDisplayname(string value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasDisplayname = true;
				this.result.displayname_ = value;
				return this;
			}

			// Token: 0x06001661 RID: 5729 RVA: 0x0004A760 File Offset: 0x00048960
			public global::RustProto.User.Builder ClearDisplayname()
			{
				this.PrepareBuilder();
				this.result.hasDisplayname = false;
				this.result.displayname_ = string.Empty;
				return this;
			}

			// Token: 0x1700063A RID: 1594
			// (get) Token: 0x06001662 RID: 5730 RVA: 0x0004A794 File Offset: 0x00048994
			public bool HasUsergroup
			{
				get
				{
					return this.result.hasUsergroup;
				}
			}

			// Token: 0x1700063B RID: 1595
			// (get) Token: 0x06001663 RID: 5731 RVA: 0x0004A7A4 File Offset: 0x000489A4
			// (set) Token: 0x06001664 RID: 5732 RVA: 0x0004A7B4 File Offset: 0x000489B4
			public global::RustProto.User.Types.UserGroup Usergroup
			{
				get
				{
					return this.result.Usergroup;
				}
				set
				{
					this.SetUsergroup(value);
				}
			}

			// Token: 0x06001665 RID: 5733 RVA: 0x0004A7C0 File Offset: 0x000489C0
			public global::RustProto.User.Builder SetUsergroup(global::RustProto.User.Types.UserGroup value)
			{
				this.PrepareBuilder();
				this.result.hasUsergroup = true;
				this.result.usergroup_ = value;
				return this;
			}

			// Token: 0x06001666 RID: 5734 RVA: 0x0004A7F0 File Offset: 0x000489F0
			public global::RustProto.User.Builder ClearUsergroup()
			{
				this.PrepareBuilder();
				this.result.hasUsergroup = false;
				this.result.usergroup_ = global::RustProto.User.Types.UserGroup.REGULAR;
				return this;
			}

			// Token: 0x04000B95 RID: 2965
			private bool resultIsReadOnly;

			// Token: 0x04000B96 RID: 2966
			private global::RustProto.User result;
		}
	}
}

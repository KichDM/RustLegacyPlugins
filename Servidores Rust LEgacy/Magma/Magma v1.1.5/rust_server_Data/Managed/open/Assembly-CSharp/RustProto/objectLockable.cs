using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Helpers;

namespace RustProto
{
	// Token: 0x02000257 RID: 599
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class objectLockable : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder>
	{
		// Token: 0x060013CA RID: 5066 RVA: 0x000453B4 File Offset: 0x000435B4
		private objectLockable()
		{
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x000453DC File Offset: 0x000435DC
		static objectLockable()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x00045444 File Offset: 0x00043644
		public static global::RustProto.Helpers.Recycler<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder>.Manufacture();
		}

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x060013CD RID: 5069 RVA: 0x0004544C File Offset: 0x0004364C
		public static global::RustProto.objectLockable DefaultInstance
		{
			get
			{
				return global::RustProto.objectLockable.defaultInstance;
			}
		}

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x060013CE RID: 5070 RVA: 0x00045454 File Offset: 0x00043654
		public override global::RustProto.objectLockable DefaultInstanceForType
		{
			get
			{
				return global::RustProto.objectLockable.DefaultInstance;
			}
		}

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x060013CF RID: 5071 RVA: 0x0004545C File Offset: 0x0004365C
		protected override global::RustProto.objectLockable ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x060013D0 RID: 5072 RVA: 0x00045460 File Offset: 0x00043660
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectLockable__Descriptor;
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x00045468 File Offset: 0x00043668
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_objectLockable__FieldAccessorTable;
			}
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x060013D2 RID: 5074 RVA: 0x00045470 File Offset: 0x00043670
		public bool HasPassword
		{
			get
			{
				return this.hasPassword;
			}
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x00045478 File Offset: 0x00043678
		public string Password
		{
			get
			{
				return this.password_;
			}
		}

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x060013D4 RID: 5076 RVA: 0x00045480 File Offset: 0x00043680
		public bool HasLocked
		{
			get
			{
				return this.hasLocked;
			}
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x060013D5 RID: 5077 RVA: 0x00045488 File Offset: 0x00043688
		public bool Locked
		{
			get
			{
				return this.locked_;
			}
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x060013D6 RID: 5078 RVA: 0x00045490 File Offset: 0x00043690
		[global::System.CLSCompliant(false)]
		public global::System.Collections.Generic.IList<ulong> UsersList
		{
			get
			{
				return global::Google.ProtocolBuffers.Collections.Lists.AsReadOnly<ulong>(this.users_);
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x060013D7 RID: 5079 RVA: 0x000454A0 File Offset: 0x000436A0
		public int UsersCount
		{
			get
			{
				return this.users_.Count;
			}
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x000454B0 File Offset: 0x000436B0
		[global::System.CLSCompliant(false)]
		public ulong GetUsers(int index)
		{
			return this.users_[index];
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x060013D9 RID: 5081 RVA: 0x000454C0 File Offset: 0x000436C0
		public override bool IsInitialized
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060013DA RID: 5082 RVA: 0x000454C4 File Offset: 0x000436C4
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] objectLockableFieldNames = global::RustProto.objectLockable._objectLockableFieldNames;
			if (this.hasPassword)
			{
				output.WriteString(1, objectLockableFieldNames[1], this.Password);
			}
			if (this.hasLocked)
			{
				output.WriteBool(2, objectLockableFieldNames[0], this.Locked);
			}
			if (this.users_.Count > 0)
			{
				output.WriteUInt64Array(3, objectLockableFieldNames[2], this.users_);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x060013DB RID: 5083 RVA: 0x00045544 File Offset: 0x00043744
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
				if (this.hasPassword)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeStringSize(1, this.Password);
				}
				if (this.hasLocked)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeBoolSize(2, this.Locked);
				}
				int num2 = 0;
				foreach (ulong num3 in this.UsersList)
				{
					num2 += global::Google.ProtocolBuffers.CodedOutputStream.ComputeUInt64SizeNoTag(num3);
				}
				num += num2;
				num += 1 * this.users_.Count;
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x060013DC RID: 5084 RVA: 0x0004561C File Offset: 0x0004381C
		public static global::RustProto.objectLockable ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x00045630 File Offset: 0x00043830
		public static global::RustProto.objectLockable ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x00045644 File Offset: 0x00043844
		public static global::RustProto.objectLockable ParseFrom(byte[] data)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x060013DF RID: 5087 RVA: 0x00045658 File Offset: 0x00043858
		public static global::RustProto.objectLockable ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x0004566C File Offset: 0x0004386C
		public static global::RustProto.objectLockable ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x00045680 File Offset: 0x00043880
		public static global::RustProto.objectLockable ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x00045694 File Offset: 0x00043894
		public static global::RustProto.objectLockable ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x000456A8 File Offset: 0x000438A8
		public static global::RustProto.objectLockable ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x000456BC File Offset: 0x000438BC
		public static global::RustProto.objectLockable ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x000456D0 File Offset: 0x000438D0
		public static global::RustProto.objectLockable ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.objectLockable.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x000456E4 File Offset: 0x000438E4
		private global::RustProto.objectLockable MakeReadOnly()
		{
			this.users_.MakeReadOnly();
			return this;
		}

		// Token: 0x060013E7 RID: 5095 RVA: 0x000456F4 File Offset: 0x000438F4
		public static global::RustProto.objectLockable.Builder CreateBuilder()
		{
			return new global::RustProto.objectLockable.Builder();
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x000456FC File Offset: 0x000438FC
		public override global::RustProto.objectLockable.Builder ToBuilder()
		{
			return global::RustProto.objectLockable.CreateBuilder(this);
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x00045704 File Offset: 0x00043904
		public override global::RustProto.objectLockable.Builder CreateBuilderForType()
		{
			return new global::RustProto.objectLockable.Builder();
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x0004570C File Offset: 0x0004390C
		public static global::RustProto.objectLockable.Builder CreateBuilder(global::RustProto.objectLockable prototype)
		{
			return new global::RustProto.objectLockable.Builder(prototype);
		}

		// Token: 0x04000AD7 RID: 2775
		public const int PasswordFieldNumber = 1;

		// Token: 0x04000AD8 RID: 2776
		public const int LockedFieldNumber = 2;

		// Token: 0x04000AD9 RID: 2777
		public const int UsersFieldNumber = 3;

		// Token: 0x04000ADA RID: 2778
		private static readonly global::RustProto.objectLockable defaultInstance = new global::RustProto.objectLockable().MakeReadOnly();

		// Token: 0x04000ADB RID: 2779
		private static readonly string[] _objectLockableFieldNames = new string[]
		{
			"locked",
			"password",
			"users"
		};

		// Token: 0x04000ADC RID: 2780
		private static readonly uint[] _objectLockableFieldTags = new uint[]
		{
			0x10U,
			0xAU,
			0x18U
		};

		// Token: 0x04000ADD RID: 2781
		private bool hasPassword;

		// Token: 0x04000ADE RID: 2782
		private string password_ = string.Empty;

		// Token: 0x04000ADF RID: 2783
		private bool hasLocked;

		// Token: 0x04000AE0 RID: 2784
		private bool locked_;

		// Token: 0x04000AE1 RID: 2785
		private global::Google.ProtocolBuffers.Collections.PopsicleList<ulong> users_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<ulong>();

		// Token: 0x04000AE2 RID: 2786
		private int memoizedSerializedSize = -1;

		// Token: 0x02000258 RID: 600
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder>
		{
			// Token: 0x060013EB RID: 5099 RVA: 0x00045714 File Offset: 0x00043914
			public Builder()
			{
				this.result = global::RustProto.objectLockable.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x060013EC RID: 5100 RVA: 0x00045730 File Offset: 0x00043930
			internal Builder(global::RustProto.objectLockable cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x1700055A RID: 1370
			// (get) Token: 0x060013ED RID: 5101 RVA: 0x00045748 File Offset: 0x00043948
			protected override global::RustProto.objectLockable.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x060013EE RID: 5102 RVA: 0x0004574C File Offset: 0x0004394C
			private global::RustProto.objectLockable PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.objectLockable other = this.result;
					this.result = new global::RustProto.objectLockable();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x1700055B RID: 1371
			// (get) Token: 0x060013EF RID: 5103 RVA: 0x0004578C File Offset: 0x0004398C
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x1700055C RID: 1372
			// (get) Token: 0x060013F0 RID: 5104 RVA: 0x0004579C File Offset: 0x0004399C
			protected override global::RustProto.objectLockable MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x060013F1 RID: 5105 RVA: 0x000457A4 File Offset: 0x000439A4
			public override global::RustProto.objectLockable.Builder Clear()
			{
				this.result = global::RustProto.objectLockable.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x060013F2 RID: 5106 RVA: 0x000457BC File Offset: 0x000439BC
			public override global::RustProto.objectLockable.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.objectLockable.Builder(this.result);
				}
				return new global::RustProto.objectLockable.Builder().MergeFrom(this.result);
			}

			// Token: 0x1700055D RID: 1373
			// (get) Token: 0x060013F3 RID: 5107 RVA: 0x000457E8 File Offset: 0x000439E8
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.objectLockable.Descriptor;
				}
			}

			// Token: 0x1700055E RID: 1374
			// (get) Token: 0x060013F4 RID: 5108 RVA: 0x000457F0 File Offset: 0x000439F0
			public override global::RustProto.objectLockable DefaultInstanceForType
			{
				get
				{
					return global::RustProto.objectLockable.DefaultInstance;
				}
			}

			// Token: 0x060013F5 RID: 5109 RVA: 0x000457F8 File Offset: 0x000439F8
			public override global::RustProto.objectLockable BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x060013F6 RID: 5110 RVA: 0x0004582C File Offset: 0x00043A2C
			public override global::RustProto.objectLockable.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.objectLockable)
				{
					return this.MergeFrom((global::RustProto.objectLockable)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x060013F7 RID: 5111 RVA: 0x00045850 File Offset: 0x00043A50
			public override global::RustProto.objectLockable.Builder MergeFrom(global::RustProto.objectLockable other)
			{
				if (other == global::RustProto.objectLockable.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.HasPassword)
				{
					this.Password = other.Password;
				}
				if (other.HasLocked)
				{
					this.Locked = other.Locked;
				}
				if (other.users_.Count != 0)
				{
					this.result.users_.Add(other.users_);
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x060013F8 RID: 5112 RVA: 0x000458D4 File Offset: 0x00043AD4
			public override global::RustProto.objectLockable.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x060013F9 RID: 5113 RVA: 0x000458E4 File Offset: 0x00043AE4
			public override global::RustProto.objectLockable.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.objectLockable._objectLockableFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.objectLockable._objectLockableFieldTags[num2];
					}
					uint num3 = num;
					switch (num3)
					{
					case 0x18U:
					case 0x1AU:
						input.ReadUInt64Array(num, text, this.result.users_);
						break;
					default:
						if (num3 == 0U)
						{
							throw global::Google.ProtocolBuffers.InvalidProtocolBufferException.InvalidTag();
						}
						if (num3 != 0xAU)
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
								this.result.hasLocked = input.ReadBool(ref this.result.locked_);
							}
						}
						else
						{
							this.result.hasPassword = input.ReadString(ref this.result.password_);
						}
						break;
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x1700055F RID: 1375
			// (get) Token: 0x060013FA RID: 5114 RVA: 0x00045A50 File Offset: 0x00043C50
			public bool HasPassword
			{
				get
				{
					return this.result.hasPassword;
				}
			}

			// Token: 0x17000560 RID: 1376
			// (get) Token: 0x060013FB RID: 5115 RVA: 0x00045A60 File Offset: 0x00043C60
			// (set) Token: 0x060013FC RID: 5116 RVA: 0x00045A70 File Offset: 0x00043C70
			public string Password
			{
				get
				{
					return this.result.Password;
				}
				set
				{
					this.SetPassword(value);
				}
			}

			// Token: 0x060013FD RID: 5117 RVA: 0x00045A7C File Offset: 0x00043C7C
			public global::RustProto.objectLockable.Builder SetPassword(string value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasPassword = true;
				this.result.password_ = value;
				return this;
			}

			// Token: 0x060013FE RID: 5118 RVA: 0x00045AAC File Offset: 0x00043CAC
			public global::RustProto.objectLockable.Builder ClearPassword()
			{
				this.PrepareBuilder();
				this.result.hasPassword = false;
				this.result.password_ = string.Empty;
				return this;
			}

			// Token: 0x17000561 RID: 1377
			// (get) Token: 0x060013FF RID: 5119 RVA: 0x00045AE0 File Offset: 0x00043CE0
			public bool HasLocked
			{
				get
				{
					return this.result.hasLocked;
				}
			}

			// Token: 0x17000562 RID: 1378
			// (get) Token: 0x06001400 RID: 5120 RVA: 0x00045AF0 File Offset: 0x00043CF0
			// (set) Token: 0x06001401 RID: 5121 RVA: 0x00045B00 File Offset: 0x00043D00
			public bool Locked
			{
				get
				{
					return this.result.Locked;
				}
				set
				{
					this.SetLocked(value);
				}
			}

			// Token: 0x06001402 RID: 5122 RVA: 0x00045B0C File Offset: 0x00043D0C
			public global::RustProto.objectLockable.Builder SetLocked(bool value)
			{
				this.PrepareBuilder();
				this.result.hasLocked = true;
				this.result.locked_ = value;
				return this;
			}

			// Token: 0x06001403 RID: 5123 RVA: 0x00045B3C File Offset: 0x00043D3C
			public global::RustProto.objectLockable.Builder ClearLocked()
			{
				this.PrepareBuilder();
				this.result.hasLocked = false;
				this.result.locked_ = false;
				return this;
			}

			// Token: 0x17000563 RID: 1379
			// (get) Token: 0x06001404 RID: 5124 RVA: 0x00045B6C File Offset: 0x00043D6C
			[global::System.CLSCompliant(false)]
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<ulong> UsersList
			{
				get
				{
					return this.PrepareBuilder().users_;
				}
			}

			// Token: 0x17000564 RID: 1380
			// (get) Token: 0x06001405 RID: 5125 RVA: 0x00045B7C File Offset: 0x00043D7C
			public int UsersCount
			{
				get
				{
					return this.result.UsersCount;
				}
			}

			// Token: 0x06001406 RID: 5126 RVA: 0x00045B8C File Offset: 0x00043D8C
			[global::System.CLSCompliant(false)]
			public ulong GetUsers(int index)
			{
				return this.result.GetUsers(index);
			}

			// Token: 0x06001407 RID: 5127 RVA: 0x00045B9C File Offset: 0x00043D9C
			[global::System.CLSCompliant(false)]
			public global::RustProto.objectLockable.Builder SetUsers(int index, ulong value)
			{
				this.PrepareBuilder();
				this.result.users_[index] = value;
				return this;
			}

			// Token: 0x06001408 RID: 5128 RVA: 0x00045BB8 File Offset: 0x00043DB8
			[global::System.CLSCompliant(false)]
			public global::RustProto.objectLockable.Builder AddUsers(ulong value)
			{
				this.PrepareBuilder();
				this.result.users_.Add(value);
				return this;
			}

			// Token: 0x06001409 RID: 5129 RVA: 0x00045BD4 File Offset: 0x00043DD4
			[global::System.CLSCompliant(false)]
			public global::RustProto.objectLockable.Builder AddRangeUsers(global::System.Collections.Generic.IEnumerable<ulong> values)
			{
				this.PrepareBuilder();
				this.result.users_.Add(values);
				return this;
			}

			// Token: 0x0600140A RID: 5130 RVA: 0x00045BF0 File Offset: 0x00043DF0
			public global::RustProto.objectLockable.Builder ClearUsers()
			{
				this.PrepareBuilder();
				this.result.users_.Clear();
				return this;
			}

			// Token: 0x04000AE3 RID: 2787
			private bool resultIsReadOnly;

			// Token: 0x04000AE4 RID: 2788
			private global::RustProto.objectLockable result;
		}
	}
}

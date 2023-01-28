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
	// Token: 0x02000239 RID: 569
	[global::System.Diagnostics.DebuggerNonUserCode]
	public sealed class WorldSave : global::Google.ProtocolBuffers.GeneratedMessage<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder>
	{
		// Token: 0x06000F35 RID: 3893 RVA: 0x0003A868 File Offset: 0x00038A68
		private WorldSave()
		{
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x0003A890 File Offset: 0x00038A90
		static WorldSave()
		{
			object.ReferenceEquals(global::RustProto.Worldsave.Descriptor, null);
		}

		// Token: 0x06000F37 RID: 3895 RVA: 0x0003A8E8 File Offset: 0x00038AE8
		public static global::RustProto.Helpers.Recycler<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder> Recycler()
		{
			return global::RustProto.Helpers.Recycler<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder>.Manufacture();
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000F38 RID: 3896 RVA: 0x0003A8F0 File Offset: 0x00038AF0
		public static global::RustProto.WorldSave DefaultInstance
		{
			get
			{
				return global::RustProto.WorldSave.defaultInstance;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x0003A8F8 File Offset: 0x00038AF8
		public override global::RustProto.WorldSave DefaultInstanceForType
		{
			get
			{
				return global::RustProto.WorldSave.DefaultInstance;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000F3A RID: 3898 RVA: 0x0003A900 File Offset: 0x00038B00
		protected override global::RustProto.WorldSave ThisMessage
		{
			get
			{
				return this;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x0003A904 File Offset: 0x00038B04
		public static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_WorldSave__Descriptor;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000F3C RID: 3900 RVA: 0x0003A90C File Offset: 0x00038B0C
		protected override global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder> InternalFieldAccessors
		{
			get
			{
				return global::RustProto.Worldsave.internal__static_RustProto_WorldSave__FieldAccessorTable;
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x0003A914 File Offset: 0x00038B14
		public global::System.Collections.Generic.IList<global::RustProto.SavedObject> SceneObjectList
		{
			get
			{
				return this.sceneObject_;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x0003A91C File Offset: 0x00038B1C
		public int SceneObjectCount
		{
			get
			{
				return this.sceneObject_.Count;
			}
		}

		// Token: 0x06000F3F RID: 3903 RVA: 0x0003A92C File Offset: 0x00038B2C
		public global::RustProto.SavedObject GetSceneObject(int index)
		{
			return this.sceneObject_[index];
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x0003A93C File Offset: 0x00038B3C
		public global::System.Collections.Generic.IList<global::RustProto.SavedObject> InstanceObjectList
		{
			get
			{
				return this.instanceObject_;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x0003A944 File Offset: 0x00038B44
		public int InstanceObjectCount
		{
			get
			{
				return this.instanceObject_.Count;
			}
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x0003A954 File Offset: 0x00038B54
		public global::RustProto.SavedObject GetInstanceObject(int index)
		{
			return this.instanceObject_[index];
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000F43 RID: 3907 RVA: 0x0003A964 File Offset: 0x00038B64
		public override bool IsInitialized
		{
			get
			{
				foreach (global::RustProto.SavedObject savedObject in this.SceneObjectList)
				{
					if (!savedObject.IsInitialized)
					{
						return false;
					}
				}
				foreach (global::RustProto.SavedObject savedObject2 in this.InstanceObjectList)
				{
					if (!savedObject2.IsInitialized)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0003AA38 File Offset: 0x00038C38
		public override void WriteTo(global::Google.ProtocolBuffers.ICodedOutputStream output)
		{
			int serializedSize = this.SerializedSize;
			string[] worldSaveFieldNames = global::RustProto.WorldSave._worldSaveFieldNames;
			if (this.sceneObject_.Count > 0)
			{
				output.WriteMessageArray<global::RustProto.SavedObject>(1, worldSaveFieldNames[1], this.sceneObject_);
			}
			if (this.instanceObject_.Count > 0)
			{
				output.WriteMessageArray<global::RustProto.SavedObject>(2, worldSaveFieldNames[0], this.instanceObject_);
			}
			this.UnknownFields.WriteTo(output);
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x0003AAA0 File Offset: 0x00038CA0
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
				foreach (global::RustProto.SavedObject savedObject in this.SceneObjectList)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(1, savedObject);
				}
				foreach (global::RustProto.SavedObject savedObject2 in this.InstanceObjectList)
				{
					num += global::Google.ProtocolBuffers.CodedOutputStream.ComputeMessageSize(2, savedObject2);
				}
				num += this.UnknownFields.SerializedSize;
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x0003AB88 File Offset: 0x00038D88
		public static global::RustProto.WorldSave ParseFrom(global::Google.ProtocolBuffers.ByteString data)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x0003AB9C File Offset: 0x00038D9C
		public static global::RustProto.WorldSave ParseFrom(global::Google.ProtocolBuffers.ByteString data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x0003ABB0 File Offset: 0x00038DB0
		public static global::RustProto.WorldSave ParseFrom(byte[] data)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x0003ABC4 File Offset: 0x00038DC4
		public static global::RustProto.WorldSave ParseFrom(byte[] data, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x0003ABD8 File Offset: 0x00038DD8
		public static global::RustProto.WorldSave ParseFrom(global::System.IO.Stream input)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x0003ABEC File Offset: 0x00038DEC
		public static global::RustProto.WorldSave ParseFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F4C RID: 3916 RVA: 0x0003AC00 File Offset: 0x00038E00
		public static global::RustProto.WorldSave ParseDelimitedFrom(global::System.IO.Stream input)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x0003AC14 File Offset: 0x00038E14
		public static global::RustProto.WorldSave ParseDelimitedFrom(global::System.IO.Stream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x0003AC28 File Offset: 0x00038E28
		public static global::RustProto.WorldSave ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeFrom(input).BuildParsed();
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x0003AC3C File Offset: 0x00038E3C
		public static global::RustProto.WorldSave ParseFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
		{
			return global::RustProto.WorldSave.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x0003AC50 File Offset: 0x00038E50
		private global::RustProto.WorldSave MakeReadOnly()
		{
			this.sceneObject_.MakeReadOnly();
			this.instanceObject_.MakeReadOnly();
			return this;
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x0003AC6C File Offset: 0x00038E6C
		public static global::RustProto.WorldSave.Builder CreateBuilder()
		{
			return new global::RustProto.WorldSave.Builder();
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x0003AC74 File Offset: 0x00038E74
		public override global::RustProto.WorldSave.Builder ToBuilder()
		{
			return global::RustProto.WorldSave.CreateBuilder(this);
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x0003AC7C File Offset: 0x00038E7C
		public override global::RustProto.WorldSave.Builder CreateBuilderForType()
		{
			return new global::RustProto.WorldSave.Builder();
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x0003AC84 File Offset: 0x00038E84
		public static global::RustProto.WorldSave.Builder CreateBuilder(global::RustProto.WorldSave prototype)
		{
			return new global::RustProto.WorldSave.Builder(prototype);
		}

		// Token: 0x040009B9 RID: 2489
		public const int SceneObjectFieldNumber = 1;

		// Token: 0x040009BA RID: 2490
		public const int InstanceObjectFieldNumber = 2;

		// Token: 0x040009BB RID: 2491
		private static readonly global::RustProto.WorldSave defaultInstance = new global::RustProto.WorldSave().MakeReadOnly();

		// Token: 0x040009BC RID: 2492
		private static readonly string[] _worldSaveFieldNames = new string[]
		{
			"instanceObject",
			"sceneObject"
		};

		// Token: 0x040009BD RID: 2493
		private static readonly uint[] _worldSaveFieldTags = new uint[]
		{
			0x12U,
			0xAU
		};

		// Token: 0x040009BE RID: 2494
		private global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.SavedObject> sceneObject_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.SavedObject>();

		// Token: 0x040009BF RID: 2495
		private global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.SavedObject> instanceObject_ = new global::Google.ProtocolBuffers.Collections.PopsicleList<global::RustProto.SavedObject>();

		// Token: 0x040009C0 RID: 2496
		private int memoizedSerializedSize = -1;

		// Token: 0x0200023A RID: 570
		[global::System.Diagnostics.DebuggerNonUserCode]
		public sealed class Builder : global::Google.ProtocolBuffers.GeneratedBuilder<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder>
		{
			// Token: 0x06000F55 RID: 3925 RVA: 0x0003AC8C File Offset: 0x00038E8C
			public Builder()
			{
				this.result = global::RustProto.WorldSave.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			// Token: 0x06000F56 RID: 3926 RVA: 0x0003ACA8 File Offset: 0x00038EA8
			internal Builder(global::RustProto.WorldSave cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			// Token: 0x17000394 RID: 916
			// (get) Token: 0x06000F57 RID: 3927 RVA: 0x0003ACC0 File Offset: 0x00038EC0
			protected override global::RustProto.WorldSave.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			// Token: 0x06000F58 RID: 3928 RVA: 0x0003ACC4 File Offset: 0x00038EC4
			private global::RustProto.WorldSave PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					global::RustProto.WorldSave other = this.result;
					this.result = new global::RustProto.WorldSave();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			// Token: 0x17000395 RID: 917
			// (get) Token: 0x06000F59 RID: 3929 RVA: 0x0003AD04 File Offset: 0x00038F04
			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			// Token: 0x17000396 RID: 918
			// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0003AD14 File Offset: 0x00038F14
			protected override global::RustProto.WorldSave MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			// Token: 0x06000F5B RID: 3931 RVA: 0x0003AD1C File Offset: 0x00038F1C
			public override global::RustProto.WorldSave.Builder Clear()
			{
				this.result = global::RustProto.WorldSave.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			// Token: 0x06000F5C RID: 3932 RVA: 0x0003AD34 File Offset: 0x00038F34
			public override global::RustProto.WorldSave.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new global::RustProto.WorldSave.Builder(this.result);
				}
				return new global::RustProto.WorldSave.Builder().MergeFrom(this.result);
			}

			// Token: 0x17000397 RID: 919
			// (get) Token: 0x06000F5D RID: 3933 RVA: 0x0003AD60 File Offset: 0x00038F60
			public override global::Google.ProtocolBuffers.Descriptors.MessageDescriptor DescriptorForType
			{
				get
				{
					return global::RustProto.WorldSave.Descriptor;
				}
			}

			// Token: 0x17000398 RID: 920
			// (get) Token: 0x06000F5E RID: 3934 RVA: 0x0003AD68 File Offset: 0x00038F68
			public override global::RustProto.WorldSave DefaultInstanceForType
			{
				get
				{
					return global::RustProto.WorldSave.DefaultInstance;
				}
			}

			// Token: 0x06000F5F RID: 3935 RVA: 0x0003AD70 File Offset: 0x00038F70
			public override global::RustProto.WorldSave BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			// Token: 0x06000F60 RID: 3936 RVA: 0x0003ADA4 File Offset: 0x00038FA4
			public override global::RustProto.WorldSave.Builder MergeFrom(global::Google.ProtocolBuffers.IMessage other)
			{
				if (other is global::RustProto.WorldSave)
				{
					return this.MergeFrom((global::RustProto.WorldSave)other);
				}
				base.MergeFrom(other);
				return this;
			}

			// Token: 0x06000F61 RID: 3937 RVA: 0x0003ADC8 File Offset: 0x00038FC8
			public override global::RustProto.WorldSave.Builder MergeFrom(global::RustProto.WorldSave other)
			{
				if (other == global::RustProto.WorldSave.DefaultInstance)
				{
					return this;
				}
				this.PrepareBuilder();
				if (other.sceneObject_.Count != 0)
				{
					this.result.sceneObject_.Add(other.sceneObject_);
				}
				if (other.instanceObject_.Count != 0)
				{
					this.result.instanceObject_.Add(other.instanceObject_);
				}
				this.MergeUnknownFields(other.UnknownFields);
				return this;
			}

			// Token: 0x06000F62 RID: 3938 RVA: 0x0003AE44 File Offset: 0x00039044
			public override global::RustProto.WorldSave.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input)
			{
				return this.MergeFrom(input, global::Google.ProtocolBuffers.ExtensionRegistry.Empty);
			}

			// Token: 0x06000F63 RID: 3939 RVA: 0x0003AE54 File Offset: 0x00039054
			public override global::RustProto.WorldSave.Builder MergeFrom(global::Google.ProtocolBuffers.ICodedInputStream input, global::Google.ProtocolBuffers.ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				global::Google.ProtocolBuffers.UnknownFieldSet.Builder builder = null;
				uint num;
				string text;
				while (input.ReadTag(ref num, ref text))
				{
					if (num == 0U && text != null)
					{
						int num2 = global::System.Array.BinarySearch<string>(global::RustProto.WorldSave._worldSaveFieldNames, text, global::System.StringComparer.Ordinal);
						if (num2 < 0)
						{
							if (builder == null)
							{
								builder = global::Google.ProtocolBuffers.UnknownFieldSet.CreateBuilder(this.UnknownFields);
							}
							this.ParseUnknownField(input, builder, extensionRegistry, num, text);
							continue;
						}
						num = global::RustProto.WorldSave._worldSaveFieldTags[num2];
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
							input.ReadMessageArray<global::RustProto.SavedObject>(num, text, this.result.instanceObject_, global::RustProto.SavedObject.DefaultInstance, extensionRegistry);
						}
					}
					else
					{
						input.ReadMessageArray<global::RustProto.SavedObject>(num, text, this.result.sceneObject_, global::RustProto.SavedObject.DefaultInstance, extensionRegistry);
					}
				}
				if (builder != null)
				{
					this.UnknownFields = builder.Build();
				}
				return this;
			}

			// Token: 0x17000399 RID: 921
			// (get) Token: 0x06000F64 RID: 3940 RVA: 0x0003AF8C File Offset: 0x0003918C
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<global::RustProto.SavedObject> SceneObjectList
			{
				get
				{
					return this.PrepareBuilder().sceneObject_;
				}
			}

			// Token: 0x1700039A RID: 922
			// (get) Token: 0x06000F65 RID: 3941 RVA: 0x0003AF9C File Offset: 0x0003919C
			public int SceneObjectCount
			{
				get
				{
					return this.result.SceneObjectCount;
				}
			}

			// Token: 0x06000F66 RID: 3942 RVA: 0x0003AFAC File Offset: 0x000391AC
			public global::RustProto.SavedObject GetSceneObject(int index)
			{
				return this.result.GetSceneObject(index);
			}

			// Token: 0x06000F67 RID: 3943 RVA: 0x0003AFBC File Offset: 0x000391BC
			public global::RustProto.WorldSave.Builder SetSceneObject(int index, global::RustProto.SavedObject value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.sceneObject_[index] = value;
				return this;
			}

			// Token: 0x06000F68 RID: 3944 RVA: 0x0003AFE4 File Offset: 0x000391E4
			public global::RustProto.WorldSave.Builder SetSceneObject(int index, global::RustProto.SavedObject.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.sceneObject_[index] = builderForValue.Build();
				return this;
			}

			// Token: 0x06000F69 RID: 3945 RVA: 0x0003B01C File Offset: 0x0003921C
			public global::RustProto.WorldSave.Builder AddSceneObject(global::RustProto.SavedObject value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.sceneObject_.Add(value);
				return this;
			}

			// Token: 0x06000F6A RID: 3946 RVA: 0x0003B050 File Offset: 0x00039250
			public global::RustProto.WorldSave.Builder AddSceneObject(global::RustProto.SavedObject.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.sceneObject_.Add(builderForValue.Build());
				return this;
			}

			// Token: 0x06000F6B RID: 3947 RVA: 0x0003B07C File Offset: 0x0003927C
			public global::RustProto.WorldSave.Builder AddRangeSceneObject(global::System.Collections.Generic.IEnumerable<global::RustProto.SavedObject> values)
			{
				this.PrepareBuilder();
				this.result.sceneObject_.Add(values);
				return this;
			}

			// Token: 0x06000F6C RID: 3948 RVA: 0x0003B098 File Offset: 0x00039298
			public global::RustProto.WorldSave.Builder ClearSceneObject()
			{
				this.PrepareBuilder();
				this.result.sceneObject_.Clear();
				return this;
			}

			// Token: 0x1700039B RID: 923
			// (get) Token: 0x06000F6D RID: 3949 RVA: 0x0003B0B4 File Offset: 0x000392B4
			public global::Google.ProtocolBuffers.Collections.IPopsicleList<global::RustProto.SavedObject> InstanceObjectList
			{
				get
				{
					return this.PrepareBuilder().instanceObject_;
				}
			}

			// Token: 0x1700039C RID: 924
			// (get) Token: 0x06000F6E RID: 3950 RVA: 0x0003B0C4 File Offset: 0x000392C4
			public int InstanceObjectCount
			{
				get
				{
					return this.result.InstanceObjectCount;
				}
			}

			// Token: 0x06000F6F RID: 3951 RVA: 0x0003B0D4 File Offset: 0x000392D4
			public global::RustProto.SavedObject GetInstanceObject(int index)
			{
				return this.result.GetInstanceObject(index);
			}

			// Token: 0x06000F70 RID: 3952 RVA: 0x0003B0E4 File Offset: 0x000392E4
			public global::RustProto.WorldSave.Builder SetInstanceObject(int index, global::RustProto.SavedObject value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.instanceObject_[index] = value;
				return this;
			}

			// Token: 0x06000F71 RID: 3953 RVA: 0x0003B10C File Offset: 0x0003930C
			public global::RustProto.WorldSave.Builder SetInstanceObject(int index, global::RustProto.SavedObject.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.instanceObject_[index] = builderForValue.Build();
				return this;
			}

			// Token: 0x06000F72 RID: 3954 RVA: 0x0003B144 File Offset: 0x00039344
			public global::RustProto.WorldSave.Builder AddInstanceObject(global::RustProto.SavedObject value)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.instanceObject_.Add(value);
				return this;
			}

			// Token: 0x06000F73 RID: 3955 RVA: 0x0003B178 File Offset: 0x00039378
			public global::RustProto.WorldSave.Builder AddInstanceObject(global::RustProto.SavedObject.Builder builderForValue)
			{
				global::Google.ProtocolBuffers.ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.instanceObject_.Add(builderForValue.Build());
				return this;
			}

			// Token: 0x06000F74 RID: 3956 RVA: 0x0003B1A4 File Offset: 0x000393A4
			public global::RustProto.WorldSave.Builder AddRangeInstanceObject(global::System.Collections.Generic.IEnumerable<global::RustProto.SavedObject> values)
			{
				this.PrepareBuilder();
				this.result.instanceObject_.Add(values);
				return this;
			}

			// Token: 0x06000F75 RID: 3957 RVA: 0x0003B1C0 File Offset: 0x000393C0
			public global::RustProto.WorldSave.Builder ClearInstanceObject()
			{
				this.PrepareBuilder();
				this.result.instanceObject_.Clear();
				return this;
			}

			// Token: 0x040009C1 RID: 2497
			private bool resultIsReadOnly;

			// Token: 0x040009C2 RID: 2498
			private global::RustProto.WorldSave result;
		}
	}
}

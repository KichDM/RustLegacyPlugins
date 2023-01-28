using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;

namespace RustProto.Proto
{
	// Token: 0x0200026A RID: 618
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class Avatar
	{
		// Token: 0x060015A2 RID: 5538 RVA: 0x00048D28 File Offset: 0x00046F28
		static Avatar()
		{
			byte[] array = global::System.Convert.FromBase64String("ChFydXN0L2F2YXRhci5wcm90bxIJUnVzdFByb3RvGhRydXN0L2JsdWVwcmludC5wcm90bxoPcnVzdC9pdGVtLnByb3RvGhFydXN0L2NvbW1vbi5wcm90bxoRcnVzdC92aXRhbHMucHJvdG8iqAIKBkF2YXRhchIeCgNwb3MYASABKAsyES5SdXN0UHJvdG8uVmVjdG9yEiIKA2FuZxgCIAEoCzIVLlJ1c3RQcm90by5RdWF0ZXJuaW9uEiEKBnZpdGFscxgDIAEoCzIRLlJ1c3RQcm90by5WaXRhbHMSKAoKYmx1ZXByaW50cxgEIAMoCzIULlJ1c3RQcm90by5CbHVlcHJpbnQSIgoJaW52ZW50b3J5GAUgAygLMg8uUnVzdFByb3RvLkl0ZW0SIQoId2VhcmFibGUYBiADKAsyDy5SdXN0UHJvdG8uSXRlbRIdCgRiZWx0GAcgAygLMg8uUnVzdFByb3RvLkl0ZW0SJwoJYXdheUV2ZW50GAggASgLMhQuUnVzdFByb3RvLkF3YXlFdmVudCKZAQoJQXdheUV2ZW50EjAKBHR5cGUYASACKA4yIi5SdXN0UHJvdG8uQXdheUV2ZW50LkF3YXlFdmVudFR5cGUSEQoJdGltZXN0YW1wGAIgAigFEhIKCmluc3RpZ2F0b3IYAyABKAQiMwoNQXdheUV2ZW50VHlwZRILCgdVTktOT1dOEAASCwoHU0xVTUJFUhABEggKBERJRUQQAkICSAE=");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Proto.Avatar.descriptor = root;
				global::RustProto.Proto.Avatar.internal__static_RustProto_Avatar__Descriptor = global::RustProto.Proto.Avatar.Descriptor.MessageTypes[0];
				global::RustProto.Proto.Avatar.internal__static_RustProto_Avatar__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Avatar, global::RustProto.Avatar.Builder>(global::RustProto.Proto.Avatar.internal__static_RustProto_Avatar__Descriptor, new string[]
				{
					"Pos",
					"Ang",
					"Vitals",
					"Blueprints",
					"Inventory",
					"Wearable",
					"Belt",
					"AwayEvent"
				});
				global::RustProto.Proto.Avatar.internal__static_RustProto_AwayEvent__Descriptor = global::RustProto.Proto.Avatar.Descriptor.MessageTypes[1];
				global::RustProto.Proto.Avatar.internal__static_RustProto_AwayEvent__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder>(global::RustProto.Proto.Avatar.internal__static_RustProto_AwayEvent__Descriptor, new string[]
				{
					"Type",
					"Timestamp",
					"Instigator"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[]
			{
				global::RustProto.Proto.Blueprint.Descriptor,
				global::RustProto.Proto.Item.Descriptor,
				global::RustProto.Common.Descriptor,
				global::RustProto.Proto.Vitals.Descriptor
			}, internalDescriptorAssigner);
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x00048D8C File Offset: 0x00046F8C
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x060015A4 RID: 5540 RVA: 0x00048D90 File Offset: 0x00046F90
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Avatar.descriptor;
			}
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x00048D98 File Offset: 0x00046F98
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <Avatar>m__5(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Proto.Avatar.descriptor = root;
			global::RustProto.Proto.Avatar.internal__static_RustProto_Avatar__Descriptor = global::RustProto.Proto.Avatar.Descriptor.MessageTypes[0];
			global::RustProto.Proto.Avatar.internal__static_RustProto_Avatar__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Avatar, global::RustProto.Avatar.Builder>(global::RustProto.Proto.Avatar.internal__static_RustProto_Avatar__Descriptor, new string[]
			{
				"Pos",
				"Ang",
				"Vitals",
				"Blueprints",
				"Inventory",
				"Wearable",
				"Belt",
				"AwayEvent"
			});
			global::RustProto.Proto.Avatar.internal__static_RustProto_AwayEvent__Descriptor = global::RustProto.Proto.Avatar.Descriptor.MessageTypes[1];
			global::RustProto.Proto.Avatar.internal__static_RustProto_AwayEvent__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder>(global::RustProto.Proto.Avatar.internal__static_RustProto_AwayEvent__Descriptor, new string[]
			{
				"Type",
				"Timestamp",
				"Instigator"
			});
			return null;
		}

		// Token: 0x04000B4A RID: 2890
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_Avatar__Descriptor;

		// Token: 0x04000B4B RID: 2891
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Avatar, global::RustProto.Avatar.Builder> internal__static_RustProto_Avatar__FieldAccessorTable;

		// Token: 0x04000B4C RID: 2892
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_AwayEvent__Descriptor;

		// Token: 0x04000B4D RID: 2893
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.AwayEvent, global::RustProto.AwayEvent.Builder> internal__static_RustProto_AwayEvent__FieldAccessorTable;

		// Token: 0x04000B4E RID: 2894
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000B4F RID: 2895
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache5;
	}
}

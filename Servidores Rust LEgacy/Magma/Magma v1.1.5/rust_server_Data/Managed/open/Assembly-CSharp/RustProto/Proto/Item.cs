using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;

namespace RustProto.Proto
{
	// Token: 0x02000272 RID: 626
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class Item
	{
		// Token: 0x0600161E RID: 5662 RVA: 0x00049E00 File Offset: 0x00048000
		static Item()
		{
			byte[] array = global::System.Convert.FromBase64String("Cg9ydXN0L2l0ZW0ucHJvdG8SCVJ1c3RQcm90bxoTcnVzdC9pdGVtX21vZC5wcm90byKaAQoESXRlbRIKCgJpZBgBIAIoBRIMCgRuYW1lGAIgASgJEgwKBHNsb3QYAyABKAUSDQoFY291bnQYBCABKAUSEAoIc3Vic2xvdHMYBiABKAUSEQoJY29uZGl0aW9uGAcgASgCEhQKDG1heGNvbmRpdGlvbhgIIAEoAhIgCgdzdWJpdGVtGAUgAygLMg8uUnVzdFByb3RvLkl0ZW1CAkgB");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Proto.Item.descriptor = root;
				global::RustProto.Proto.Item.internal__static_RustProto_Item__Descriptor = global::RustProto.Proto.Item.Descriptor.MessageTypes[0];
				global::RustProto.Proto.Item.internal__static_RustProto_Item__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Item, global::RustProto.Item.Builder>(global::RustProto.Proto.Item.internal__static_RustProto_Item__Descriptor, new string[]
				{
					"Id",
					"Name",
					"Slot",
					"Count",
					"Subslots",
					"Condition",
					"Maxcondition",
					"Subitem"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[]
			{
				global::RustProto.Proto.ItemMod.Descriptor
			}, internalDescriptorAssigner);
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x00049E4C File Offset: 0x0004804C
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x06001620 RID: 5664 RVA: 0x00049E50 File Offset: 0x00048050
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Item.descriptor;
			}
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x00049E58 File Offset: 0x00048058
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <Item>m__9(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Proto.Item.descriptor = root;
			global::RustProto.Proto.Item.internal__static_RustProto_Item__Descriptor = global::RustProto.Proto.Item.Descriptor.MessageTypes[0];
			global::RustProto.Proto.Item.internal__static_RustProto_Item__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Item, global::RustProto.Item.Builder>(global::RustProto.Proto.Item.internal__static_RustProto_Item__Descriptor, new string[]
			{
				"Id",
				"Name",
				"Slot",
				"Count",
				"Subslots",
				"Condition",
				"Maxcondition",
				"Subitem"
			});
			return null;
		}

		// Token: 0x04000B78 RID: 2936
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_Item__Descriptor;

		// Token: 0x04000B79 RID: 2937
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Item, global::RustProto.Item.Builder> internal__static_RustProto_Item__FieldAccessorTable;

		// Token: 0x04000B7A RID: 2938
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000B7B RID: 2939
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache3;
	}
}

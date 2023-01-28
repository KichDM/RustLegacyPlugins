using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;

namespace RustProto.Proto
{
	// Token: 0x02000273 RID: 627
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class ItemMod
	{
		// Token: 0x06001622 RID: 5666 RVA: 0x00049ED8 File Offset: 0x000480D8
		static ItemMod()
		{
			byte[] array = global::System.Convert.FromBase64String("ChNydXN0L2l0ZW1fbW9kLnByb3RvEglSdXN0UHJvdG8iIwoHSXRlbU1vZBIKCgJpZBgBIAIoBRIMCgRuYW1lGAIgASgJQgJIAQ==");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Proto.ItemMod.descriptor = root;
				global::RustProto.Proto.ItemMod.internal__static_RustProto_ItemMod__Descriptor = global::RustProto.Proto.ItemMod.Descriptor.MessageTypes[0];
				global::RustProto.Proto.ItemMod.internal__static_RustProto_ItemMod__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.ItemMod, global::RustProto.ItemMod.Builder>(global::RustProto.Proto.ItemMod.internal__static_RustProto_ItemMod__Descriptor, new string[]
				{
					"Id",
					"Name"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[0], internalDescriptorAssigner);
		}

		// Token: 0x06001623 RID: 5667 RVA: 0x00049F1C File Offset: 0x0004811C
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x06001624 RID: 5668 RVA: 0x00049F20 File Offset: 0x00048120
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.ItemMod.descriptor;
			}
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x00049F28 File Offset: 0x00048128
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <ItemMod>m__A(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Proto.ItemMod.descriptor = root;
			global::RustProto.Proto.ItemMod.internal__static_RustProto_ItemMod__Descriptor = global::RustProto.Proto.ItemMod.Descriptor.MessageTypes[0];
			global::RustProto.Proto.ItemMod.internal__static_RustProto_ItemMod__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.ItemMod, global::RustProto.ItemMod.Builder>(global::RustProto.Proto.ItemMod.internal__static_RustProto_ItemMod__Descriptor, new string[]
			{
				"Id",
				"Name"
			});
			return null;
		}

		// Token: 0x04000B7C RID: 2940
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_ItemMod__Descriptor;

		// Token: 0x04000B7D RID: 2941
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.ItemMod, global::RustProto.ItemMod.Builder> internal__static_RustProto_ItemMod__FieldAccessorTable;

		// Token: 0x04000B7E RID: 2942
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000B7F RID: 2943
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache3;
	}
}

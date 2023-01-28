using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;

namespace RustProto.Proto
{
	// Token: 0x0200026B RID: 619
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class Blueprint
	{
		// Token: 0x060015A6 RID: 5542 RVA: 0x00048E58 File Offset: 0x00047058
		static Blueprint()
		{
			byte[] array = global::System.Convert.FromBase64String("ChRydXN0L2JsdWVwcmludC5wcm90bxIJUnVzdFByb3RvIhcKCUJsdWVwcmludBIKCgJpZBgBIAIoBUICSAE=");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Proto.Blueprint.descriptor = root;
				global::RustProto.Proto.Blueprint.internal__static_RustProto_Blueprint__Descriptor = global::RustProto.Proto.Blueprint.Descriptor.MessageTypes[0];
				global::RustProto.Proto.Blueprint.internal__static_RustProto_Blueprint__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder>(global::RustProto.Proto.Blueprint.internal__static_RustProto_Blueprint__Descriptor, new string[]
				{
					"Id"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[0], internalDescriptorAssigner);
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x00048E9C File Offset: 0x0004709C
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x060015A8 RID: 5544 RVA: 0x00048EA0 File Offset: 0x000470A0
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Blueprint.descriptor;
			}
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x00048EA8 File Offset: 0x000470A8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <Blueprint>m__6(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Proto.Blueprint.descriptor = root;
			global::RustProto.Proto.Blueprint.internal__static_RustProto_Blueprint__Descriptor = global::RustProto.Proto.Blueprint.Descriptor.MessageTypes[0];
			global::RustProto.Proto.Blueprint.internal__static_RustProto_Blueprint__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder>(global::RustProto.Proto.Blueprint.internal__static_RustProto_Blueprint__Descriptor, new string[]
			{
				"Id"
			});
			return null;
		}

		// Token: 0x04000B50 RID: 2896
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_Blueprint__Descriptor;

		// Token: 0x04000B51 RID: 2897
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Blueprint, global::RustProto.Blueprint.Builder> internal__static_RustProto_Blueprint__FieldAccessorTable;

		// Token: 0x04000B52 RID: 2898
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000B53 RID: 2899
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache3;
	}
}

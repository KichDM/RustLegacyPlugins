using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;

namespace RustProto.Proto
{
	// Token: 0x0200026D RID: 621
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class Error
	{
		// Token: 0x060015AE RID: 5550 RVA: 0x00048FE0 File Offset: 0x000471E0
		static Error()
		{
			byte[] array = global::System.Convert.FromBase64String("ChBydXN0L2Vycm9yLnByb3RvEglSdXN0UHJvdG8iKAoFRXJyb3ISDgoGc3RhdHVzGAEgAigJEg8KB21lc3NhZ2UYAiACKAkiKQoJR2FtZUVycm9yEg0KBWVycm9yGAEgAigJEg0KBXRyYWNlGAIgAigJQgJIAQ==");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Proto.Error.descriptor = root;
				global::RustProto.Proto.Error.internal__static_RustProto_Error__Descriptor = global::RustProto.Proto.Error.Descriptor.MessageTypes[0];
				global::RustProto.Proto.Error.internal__static_RustProto_Error__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Error, global::RustProto.Error.Builder>(global::RustProto.Proto.Error.internal__static_RustProto_Error__Descriptor, new string[]
				{
					"Status",
					"Message"
				});
				global::RustProto.Proto.Error.internal__static_RustProto_GameError__Descriptor = global::RustProto.Proto.Error.Descriptor.MessageTypes[1];
				global::RustProto.Proto.Error.internal__static_RustProto_GameError__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.GameError, global::RustProto.GameError.Builder>(global::RustProto.Proto.Error.internal__static_RustProto_GameError__Descriptor, new string[]
				{
					"Error",
					"Trace"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[0], internalDescriptorAssigner);
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x00049024 File Offset: 0x00047224
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x060015B0 RID: 5552 RVA: 0x00049028 File Offset: 0x00047228
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Error.descriptor;
			}
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x00049030 File Offset: 0x00047230
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <Error>m__8(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Proto.Error.descriptor = root;
			global::RustProto.Proto.Error.internal__static_RustProto_Error__Descriptor = global::RustProto.Proto.Error.Descriptor.MessageTypes[0];
			global::RustProto.Proto.Error.internal__static_RustProto_Error__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Error, global::RustProto.Error.Builder>(global::RustProto.Proto.Error.internal__static_RustProto_Error__Descriptor, new string[]
			{
				"Status",
				"Message"
			});
			global::RustProto.Proto.Error.internal__static_RustProto_GameError__Descriptor = global::RustProto.Proto.Error.Descriptor.MessageTypes[1];
			global::RustProto.Proto.Error.internal__static_RustProto_GameError__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.GameError, global::RustProto.GameError.Builder>(global::RustProto.Proto.Error.internal__static_RustProto_GameError__Descriptor, new string[]
			{
				"Error",
				"Trace"
			});
			return null;
		}

		// Token: 0x04000B5A RID: 2906
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_Error__Descriptor;

		// Token: 0x04000B5B RID: 2907
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Error, global::RustProto.Error.Builder> internal__static_RustProto_Error__FieldAccessorTable;

		// Token: 0x04000B5C RID: 2908
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_GameError__Descriptor;

		// Token: 0x04000B5D RID: 2909
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.GameError, global::RustProto.GameError.Builder> internal__static_RustProto_GameError__FieldAccessorTable;

		// Token: 0x04000B5E RID: 2910
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000B5F RID: 2911
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache5;
	}
}

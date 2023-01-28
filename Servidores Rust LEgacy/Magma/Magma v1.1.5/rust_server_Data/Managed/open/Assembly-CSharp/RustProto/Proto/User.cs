using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;

namespace RustProto.Proto
{
	// Token: 0x02000274 RID: 628
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class User
	{
		// Token: 0x06001626 RID: 5670 RVA: 0x00049F78 File Offset: 0x00048178
		static User()
		{
			byte[] array = global::System.Convert.FromBase64String("Cg9ydXN0L3VzZXIucHJvdG8SCVJ1c3RQcm90byKKAQoEVXNlchIOCgZ1c2VyaWQYASACKAQSEwoLZGlzcGxheW5hbWUYAiACKAkSLAoJdXNlcmdyb3VwGAMgAigOMhkuUnVzdFByb3RvLlVzZXIuVXNlckdyb3VwIi8KCVVzZXJHcm91cBILCgdSRUdVTEFSEAASCgoGQkFOTkVEEAESCQoFQURNSU4QAkICSAE=");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Proto.User.descriptor = root;
				global::RustProto.Proto.User.internal__static_RustProto_User__Descriptor = global::RustProto.Proto.User.Descriptor.MessageTypes[0];
				global::RustProto.Proto.User.internal__static_RustProto_User__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.User, global::RustProto.User.Builder>(global::RustProto.Proto.User.internal__static_RustProto_User__Descriptor, new string[]
				{
					"Userid",
					"Displayname",
					"Usergroup"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[0], internalDescriptorAssigner);
		}

		// Token: 0x06001627 RID: 5671 RVA: 0x00049FBC File Offset: 0x000481BC
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06001628 RID: 5672 RVA: 0x00049FC0 File Offset: 0x000481C0
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.User.descriptor;
			}
		}

		// Token: 0x06001629 RID: 5673 RVA: 0x00049FC8 File Offset: 0x000481C8
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <User>m__B(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Proto.User.descriptor = root;
			global::RustProto.Proto.User.internal__static_RustProto_User__Descriptor = global::RustProto.Proto.User.Descriptor.MessageTypes[0];
			global::RustProto.Proto.User.internal__static_RustProto_User__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.User, global::RustProto.User.Builder>(global::RustProto.Proto.User.internal__static_RustProto_User__Descriptor, new string[]
			{
				"Userid",
				"Displayname",
				"Usergroup"
			});
			return null;
		}

		// Token: 0x04000B80 RID: 2944
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_User__Descriptor;

		// Token: 0x04000B81 RID: 2945
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.User, global::RustProto.User.Builder> internal__static_RustProto_User__FieldAccessorTable;

		// Token: 0x04000B82 RID: 2946
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000B83 RID: 2947
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache3;
	}
}

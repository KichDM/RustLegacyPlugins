using System;

namespace Facepunch.Build
{
	// Token: 0x0200010C RID: 268
	public static class Constants
	{
		// Token: 0x04000522 RID: 1314
		public const string EditorBundleFileName = "editorbundle.txt";

		// Token: 0x04000523 RID: 1315
		public const string ManifestFileName = "manifest.txt";

		// Token: 0x04000524 RID: 1316
		public const string AssetBundleExtension = ".unity3d";

		// Token: 0x04000525 RID: 1317
		public const string SharedSceneBundleFileName = "scene.shared.unity3d";

		// Token: 0x04000526 RID: 1318
		public const string UniqueSceneBundleFileName = "scene.specific.unity3d";

		// Token: 0x04000527 RID: 1319
		public const string BunchedSceneBundleFileName = "scenes.unity3d";

		// Token: 0x04000528 RID: 1320
		public const int ExitCode_NoError = 0;

		// Token: 0x04000529 RID: 1321
		public const int ExitCode_MissingArguments = 0x12C;

		// Token: 0x0400052A RID: 1322
		public const int ExitCode_BuildFailureException = 0x1F4;

		// Token: 0x0400052B RID: 1323
		public const int ExitCode_BuildProjectFormattingException = 0x1F6;

		// Token: 0x0400052C RID: 1324
		public const int ExitCode_OtherException = 0x1F7;

		// Token: 0x0400052D RID: 1325
		public const int ExitCode_FileNotFound = 0x194;

		// Token: 0x0400052E RID: 1326
		public const string Key_PathToBuiltServer = "FACEPUNCH_BUILD_PATH_TO_BUILT_SERVER";

		// Token: 0x0400052F RID: 1327
		public const string Key_PathToBuiltWebplayer = "FACEPUNCH_BUILD_PATH_TO_BUILT_WEBPLAYER";

		// Token: 0x04000530 RID: 1328
		public const string Key_ConnectCommand = "FACEPUNCH_BUILD_CONNECT_COMMAND";
	}
}

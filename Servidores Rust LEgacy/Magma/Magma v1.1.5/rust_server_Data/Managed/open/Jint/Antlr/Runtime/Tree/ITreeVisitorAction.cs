using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C8 RID: 200
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public interface ITreeVisitorAction
	{
		// Token: 0x06000978 RID: 2424
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object Pre(object t);

		// Token: 0x06000979 RID: 2425
		[global::System.Runtime.InteropServices.ComVisible(false)]
		object Post(object t);
	}
}

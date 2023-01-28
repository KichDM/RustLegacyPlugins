using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000C9 RID: 201
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public class TreeVisitorAction : global::Antlr.Runtime.Tree.ITreeVisitorAction
	{
		// Token: 0x0600097A RID: 2426 RVA: 0x00033C14 File Offset: 0x00031E14
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public TreeVisitorAction(global::System.Func<object, object> preAction, global::System.Func<object, object> postAction)
		{
			this._preAction = preAction;
			this._postAction = postAction;
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x00033C2C File Offset: 0x00031E2C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object Pre(object t)
		{
			if (this._preAction != null)
			{
				return this._preAction(t);
			}
			return t;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x00033C48 File Offset: 0x00031E48
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object Post(object t)
		{
			if (this._postAction != null)
			{
				return this._postAction(t);
			}
			return t;
		}

		// Token: 0x040003F6 RID: 1014
		private global::System.Func<object, object> _preAction;

		// Token: 0x040003F7 RID: 1015
		private global::System.Func<object, object> _postAction;
	}
}

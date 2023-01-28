using System;
using System.Runtime.InteropServices;

namespace Antlr.Runtime
{
	// Token: 0x020000A3 RID: 163
	[global::System.AttributeUsage(global::System.AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	[global::System.Runtime.InteropServices.ComVisible(false)]
	public sealed class GrammarRuleAttribute : global::System.Attribute
	{
		// Token: 0x06000785 RID: 1925 RVA: 0x0002EDAC File Offset: 0x0002CFAC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public GrammarRuleAttribute(string name)
		{
			this._name = name;
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x0002EDBC File Offset: 0x0002CFBC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string Name
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._name;
			}
		}

		// Token: 0x04000389 RID: 905
		private readonly string _name;
	}
}

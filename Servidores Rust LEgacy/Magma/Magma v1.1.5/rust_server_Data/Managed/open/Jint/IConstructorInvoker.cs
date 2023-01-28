using System;
using System.Reflection;

namespace Jint
{
	// Token: 0x02000032 RID: 50
	public interface IConstructorInvoker
	{
		// Token: 0x06000280 RID: 640
		global::System.Reflection.ConstructorInfo Invoke(global::System.Type type, object[] parameters);
	}
}

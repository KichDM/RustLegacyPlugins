using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000CB RID: 203
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class RewriteCardinalityException : global::System.Exception
	{
		// Token: 0x0600098B RID: 2443 RVA: 0x00033DFC File Offset: 0x00031FFC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteCardinalityException()
		{
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00033E04 File Offset: 0x00032004
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteCardinalityException(string elementDescription) : this(elementDescription, elementDescription)
		{
			this._elementDescription = elementDescription;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00033E18 File Offset: 0x00032018
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteCardinalityException(string elementDescription, global::System.Exception innerException) : this(elementDescription, elementDescription, innerException)
		{
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00033E24 File Offset: 0x00032024
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteCardinalityException(string message, string elementDescription) : base(message)
		{
			this._elementDescription = elementDescription;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00033E34 File Offset: 0x00032034
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteCardinalityException(string message, string elementDescription, global::System.Exception innerException) : base(message, innerException)
		{
			this._elementDescription = elementDescription;
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00033E48 File Offset: 0x00032048
		protected RewriteCardinalityException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._elementDescription = info.GetString("ElementDescription");
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00033E74 File Offset: 0x00032074
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("ElementDescription", this._elementDescription);
		}

		// Token: 0x040003FA RID: 1018
		private readonly string _elementDescription;
	}
}

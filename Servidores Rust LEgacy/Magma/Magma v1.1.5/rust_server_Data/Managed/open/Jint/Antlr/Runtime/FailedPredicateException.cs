using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
	// Token: 0x020000A2 RID: 162
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public class FailedPredicateException : global::Antlr.Runtime.RecognitionException
	{
		// Token: 0x0600077A RID: 1914 RVA: 0x0002EC50 File Offset: 0x0002CE50
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public FailedPredicateException()
		{
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x0002EC58 File Offset: 0x0002CE58
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public FailedPredicateException(string message) : base(message)
		{
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0002EC64 File Offset: 0x0002CE64
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public FailedPredicateException(string message, global::System.Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0002EC70 File Offset: 0x0002CE70
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public FailedPredicateException(global::Antlr.Runtime.IIntStream input, string ruleName, string predicateText) : base(input)
		{
			this._ruleName = ruleName;
			this._predicateText = predicateText;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0002EC88 File Offset: 0x0002CE88
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public FailedPredicateException(string message, global::Antlr.Runtime.IIntStream input, string ruleName, string predicateText) : base(message, input)
		{
			this._ruleName = ruleName;
			this._predicateText = predicateText;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0002ECA4 File Offset: 0x0002CEA4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public FailedPredicateException(string message, global::Antlr.Runtime.IIntStream input, string ruleName, string predicateText, global::System.Exception innerException) : base(message, input, innerException)
		{
			this._ruleName = ruleName;
			this._predicateText = predicateText;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0002ECC0 File Offset: 0x0002CEC0
		protected FailedPredicateException(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			this._ruleName = info.GetString("RuleName");
			this._predicateText = info.GetString("PredicateText");
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x0002ED00 File Offset: 0x0002CF00
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string RuleName
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._ruleName;
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x0002ED08 File Offset: 0x0002CF08
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string PredicateText
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this._predicateText;
			}
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0002ED10 File Offset: 0x0002CF10
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override void GetObjectData(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			if (info == null)
			{
				throw new global::System.ArgumentNullException("info");
			}
			base.GetObjectData(info, context);
			info.AddValue("RuleName", this._ruleName);
			info.AddValue("PredicateText", this._predicateText);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0002ED50 File Offset: 0x0002CF50
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"FailedPredicateException(",
				this.RuleName,
				",{",
				this.PredicateText,
				"}?)"
			});
		}

		// Token: 0x04000387 RID: 903
		private readonly string _ruleName;

		// Token: 0x04000388 RID: 904
		private readonly string _predicateText;
	}
}

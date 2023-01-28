using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Mono.Cecil
{
	// Token: 0x02000052 RID: 82
	public class AssemblyNameReference : global::Mono.Cecil.IMetadataScope, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x00009D3F File Offset: 0x00007F3F
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x00009D47 File Offset: 0x00007F47
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
				this.full_name = null;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060003AA RID: 938 RVA: 0x00009D57 File Offset: 0x00007F57
		// (set) Token: 0x060003AB RID: 939 RVA: 0x00009D5F File Offset: 0x00007F5F
		public string Culture
		{
			get
			{
				return this.culture;
			}
			set
			{
				this.culture = value;
				this.full_name = null;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060003AC RID: 940 RVA: 0x00009D6F File Offset: 0x00007F6F
		// (set) Token: 0x060003AD RID: 941 RVA: 0x00009D77 File Offset: 0x00007F77
		public global::System.Version Version
		{
			get
			{
				return this.version;
			}
			set
			{
				this.version = value;
				this.full_name = null;
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00009D87 File Offset: 0x00007F87
		// (set) Token: 0x060003AF RID: 943 RVA: 0x00009D8F File Offset: 0x00007F8F
		public global::Mono.Cecil.AssemblyAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.AssemblyAttributes)this.attributes;
			}
			set
			{
				this.attributes = (uint)value;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x00009D98 File Offset: 0x00007F98
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x00009DA6 File Offset: 0x00007FA6
		public bool HasPublicKey
		{
			get
			{
				return this.attributes.GetAttributes(1U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(1U, value);
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x00009DBB File Offset: 0x00007FBB
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x00009DC9 File Offset: 0x00007FC9
		public bool IsSideBySideCompatible
		{
			get
			{
				return this.attributes.GetAttributes(0U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0U, value);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00009DDE File Offset: 0x00007FDE
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x00009DF0 File Offset: 0x00007FF0
		public bool IsRetargetable
		{
			get
			{
				return this.attributes.GetAttributes(0x100U);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x100U, value);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00009E09 File Offset: 0x00008009
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x00009E11 File Offset: 0x00008011
		public byte[] PublicKey
		{
			get
			{
				return this.public_key;
			}
			set
			{
				this.public_key = value;
				this.HasPublicKey = !this.public_key.IsNullOrEmpty<byte>();
				this.public_key_token = global::Mono.Empty<byte>.Array;
				this.full_name = null;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x00009E40 File Offset: 0x00008040
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x00009EA0 File Offset: 0x000080A0
		public byte[] PublicKeyToken
		{
			get
			{
				if (this.public_key_token.IsNullOrEmpty<byte>() && !this.public_key.IsNullOrEmpty<byte>())
				{
					byte[] array = this.HashPublicKey();
					this.public_key_token = new byte[8];
					global::System.Array.Copy(array, array.Length - 8, this.public_key_token, 0, 8);
					global::System.Array.Reverse(this.public_key_token, 0, 8);
				}
				return this.public_key_token;
			}
			set
			{
				this.public_key_token = value;
				this.full_name = null;
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00009EB0 File Offset: 0x000080B0
		private byte[] HashPublicKey()
		{
			global::Mono.Cecil.AssemblyHashAlgorithm assemblyHashAlgorithm = this.hash_algorithm;
			global::System.Security.Cryptography.HashAlgorithm hashAlgorithm;
			if (assemblyHashAlgorithm == global::Mono.Cecil.AssemblyHashAlgorithm.Reserved)
			{
				hashAlgorithm = global::System.Security.Cryptography.MD5.Create();
			}
			else
			{
				hashAlgorithm = global::System.Security.Cryptography.SHA1.Create();
			}
			byte[] result;
			using (hashAlgorithm)
			{
				result = hashAlgorithm.ComputeHash(this.public_key);
			}
			return result;
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060003BB RID: 955 RVA: 0x00009F08 File Offset: 0x00008108
		public virtual global::Mono.Cecil.MetadataScopeType MetadataScopeType
		{
			get
			{
				return global::Mono.Cecil.MetadataScopeType.AssemblyNameReference;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00009F0C File Offset: 0x0000810C
		public string FullName
		{
			get
			{
				if (this.full_name != null)
				{
					return this.full_name;
				}
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append(this.name);
				if (this.version != null)
				{
					stringBuilder.Append(", ");
					stringBuilder.Append("Version=");
					stringBuilder.Append(this.version.ToString());
				}
				stringBuilder.Append(", ");
				stringBuilder.Append("Culture=");
				stringBuilder.Append(string.IsNullOrEmpty(this.culture) ? "neutral" : this.culture);
				stringBuilder.Append(", ");
				stringBuilder.Append("PublicKeyToken=");
				if (this.PublicKeyToken != null && this.public_key_token.Length > 0)
				{
					for (int i = 0; i < this.public_key_token.Length; i++)
					{
						stringBuilder.Append(this.public_key_token[i].ToString("x2"));
					}
				}
				else
				{
					stringBuilder.Append("null");
				}
				return this.full_name = stringBuilder.ToString();
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000A024 File Offset: 0x00008224
		public static global::Mono.Cecil.AssemblyNameReference Parse(string fullName)
		{
			if (fullName == null)
			{
				throw new global::System.ArgumentNullException("fullName");
			}
			if (fullName.Length == 0)
			{
				throw new global::System.ArgumentException("Name can not be empty");
			}
			global::Mono.Cecil.AssemblyNameReference assemblyNameReference = new global::Mono.Cecil.AssemblyNameReference();
			string[] array = fullName.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (i == 0)
				{
					assemblyNameReference.Name = text;
				}
				else
				{
					string[] array2 = text.Split(new char[]
					{
						'='
					});
					if (array2.Length != 2)
					{
						throw new global::System.ArgumentException("Malformed name");
					}
					string a;
					if ((a = array2[0]) != null)
					{
						if (!(a == "Version"))
						{
							if (!(a == "Culture"))
							{
								if (a == "PublicKeyToken")
								{
									string text2 = array2[1];
									if (!(text2 == "null"))
									{
										assemblyNameReference.PublicKeyToken = new byte[text2.Length / 2];
										for (int j = 0; j < assemblyNameReference.PublicKeyToken.Length; j++)
										{
											assemblyNameReference.PublicKeyToken[j] = byte.Parse(text2.Substring(j * 2, 2), global::System.Globalization.NumberStyles.HexNumber);
										}
									}
								}
							}
							else
							{
								assemblyNameReference.Culture = array2[1];
							}
						}
						else
						{
							assemblyNameReference.Version = new global::System.Version(array2[1]);
						}
					}
				}
			}
			return assemblyNameReference;
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060003BE RID: 958 RVA: 0x0000A179 File Offset: 0x00008379
		// (set) Token: 0x060003BF RID: 959 RVA: 0x0000A181 File Offset: 0x00008381
		public global::Mono.Cecil.AssemblyHashAlgorithm HashAlgorithm
		{
			get
			{
				return this.hash_algorithm;
			}
			set
			{
				this.hash_algorithm = value;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0000A18A File Offset: 0x0000838A
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x0000A192 File Offset: 0x00008392
		public virtual byte[] Hash
		{
			get
			{
				return this.hash;
			}
			set
			{
				this.hash = value;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x0000A19B File Offset: 0x0000839B
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x0000A1A3 File Offset: 0x000083A3
		public global::Mono.Cecil.MetadataToken MetadataToken
		{
			get
			{
				return this.token;
			}
			set
			{
				this.token = value;
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000A1AC File Offset: 0x000083AC
		internal AssemblyNameReference()
		{
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0000A1B4 File Offset: 0x000083B4
		public AssemblyNameReference(string name, global::System.Version version)
		{
			if (name == null)
			{
				throw new global::System.ArgumentNullException("name");
			}
			this.name = name;
			this.version = version;
			this.hash_algorithm = global::Mono.Cecil.AssemblyHashAlgorithm.None;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.AssemblyRef);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000A1EF File Offset: 0x000083EF
		public override string ToString()
		{
			return this.FullName;
		}

		// Token: 0x04000258 RID: 600
		private string name;

		// Token: 0x04000259 RID: 601
		private string culture;

		// Token: 0x0400025A RID: 602
		private global::System.Version version;

		// Token: 0x0400025B RID: 603
		private uint attributes;

		// Token: 0x0400025C RID: 604
		private byte[] public_key;

		// Token: 0x0400025D RID: 605
		private byte[] public_key_token;

		// Token: 0x0400025E RID: 606
		private global::Mono.Cecil.AssemblyHashAlgorithm hash_algorithm;

		// Token: 0x0400025F RID: 607
		private byte[] hash;

		// Token: 0x04000260 RID: 608
		internal global::Mono.Cecil.MetadataToken token;

		// Token: 0x04000261 RID: 609
		private string full_name;
	}
}

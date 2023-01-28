using System;
using System.Security.Cryptography;

namespace Mono.Security.Cryptography
{
	// Token: 0x020000AE RID: 174
	internal static class CryptoConvert
	{
		// Token: 0x0600072F RID: 1839 RVA: 0x00012FB6 File Offset: 0x000111B6
		private static int ToInt32LE(byte[] bytes, int offset)
		{
			return (int)bytes[offset + 3] << 0x18 | (int)bytes[offset + 2] << 0x10 | (int)bytes[offset + 1] << 8 | (int)bytes[offset];
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00012FD5 File Offset: 0x000111D5
		private static uint ToUInt32LE(byte[] bytes, int offset)
		{
			return (uint)((int)bytes[offset + 3] << 0x18 | (int)bytes[offset + 2] << 0x10 | (int)bytes[offset + 1] << 8 | (int)bytes[offset]);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00012FF4 File Offset: 0x000111F4
		private static byte[] Trim(byte[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != 0)
				{
					byte[] array2 = new byte[array.Length - i];
					global::System.Buffer.BlockCopy(array, i, array2, 0, array2.Length);
					return array2;
				}
			}
			return null;
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x00013030 File Offset: 0x00011230
		private static global::System.Security.Cryptography.RSA FromCapiPrivateKeyBlob(byte[] blob, int offset)
		{
			global::System.Security.Cryptography.RSAParameters parameters = default(global::System.Security.Cryptography.RSAParameters);
			try
			{
				if (blob[offset] != 7 || blob[offset + 1] != 2 || blob[offset + 2] != 0 || blob[offset + 3] != 0 || global::Mono.Security.Cryptography.CryptoConvert.ToUInt32LE(blob, offset + 8) != 0x32415352U)
				{
					throw new global::System.Security.Cryptography.CryptographicException("Invalid blob header");
				}
				int num = global::Mono.Security.Cryptography.CryptoConvert.ToInt32LE(blob, offset + 0xC);
				byte[] array = new byte[4];
				global::System.Buffer.BlockCopy(blob, offset + 0x10, array, 0, 4);
				global::System.Array.Reverse(array);
				parameters.Exponent = global::Mono.Security.Cryptography.CryptoConvert.Trim(array);
				int num2 = offset + 0x14;
				int num3 = num >> 3;
				parameters.Modulus = new byte[num3];
				global::System.Buffer.BlockCopy(blob, num2, parameters.Modulus, 0, num3);
				global::System.Array.Reverse(parameters.Modulus);
				num2 += num3;
				int num4 = num3 >> 1;
				parameters.P = new byte[num4];
				global::System.Buffer.BlockCopy(blob, num2, parameters.P, 0, num4);
				global::System.Array.Reverse(parameters.P);
				num2 += num4;
				parameters.Q = new byte[num4];
				global::System.Buffer.BlockCopy(blob, num2, parameters.Q, 0, num4);
				global::System.Array.Reverse(parameters.Q);
				num2 += num4;
				parameters.DP = new byte[num4];
				global::System.Buffer.BlockCopy(blob, num2, parameters.DP, 0, num4);
				global::System.Array.Reverse(parameters.DP);
				num2 += num4;
				parameters.DQ = new byte[num4];
				global::System.Buffer.BlockCopy(blob, num2, parameters.DQ, 0, num4);
				global::System.Array.Reverse(parameters.DQ);
				num2 += num4;
				parameters.InverseQ = new byte[num4];
				global::System.Buffer.BlockCopy(blob, num2, parameters.InverseQ, 0, num4);
				global::System.Array.Reverse(parameters.InverseQ);
				num2 += num4;
				parameters.D = new byte[num3];
				if (num2 + num3 + offset <= blob.Length)
				{
					global::System.Buffer.BlockCopy(blob, num2, parameters.D, 0, num3);
					global::System.Array.Reverse(parameters.D);
				}
			}
			catch (global::System.Exception inner)
			{
				throw new global::System.Security.Cryptography.CryptographicException("Invalid blob.", inner);
			}
			global::System.Security.Cryptography.RSA rsa = null;
			try
			{
				rsa = global::System.Security.Cryptography.RSA.Create();
				rsa.ImportParameters(parameters);
			}
			catch (global::System.Security.Cryptography.CryptographicException ex)
			{
				try
				{
					rsa = new global::System.Security.Cryptography.RSACryptoServiceProvider(new global::System.Security.Cryptography.CspParameters
					{
						Flags = global::System.Security.Cryptography.CspProviderFlags.UseMachineKeyStore
					});
					rsa.ImportParameters(parameters);
				}
				catch
				{
					throw ex;
				}
			}
			return rsa;
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000132B4 File Offset: 0x000114B4
		private static global::System.Security.Cryptography.RSA FromCapiPublicKeyBlob(byte[] blob, int offset)
		{
			global::System.Security.Cryptography.RSA result;
			try
			{
				if (blob[offset] != 6 || blob[offset + 1] != 2 || blob[offset + 2] != 0 || blob[offset + 3] != 0 || global::Mono.Security.Cryptography.CryptoConvert.ToUInt32LE(blob, offset + 8) != 0x31415352U)
				{
					throw new global::System.Security.Cryptography.CryptographicException("Invalid blob header");
				}
				int num = global::Mono.Security.Cryptography.CryptoConvert.ToInt32LE(blob, offset + 0xC);
				global::System.Security.Cryptography.RSAParameters parameters = default(global::System.Security.Cryptography.RSAParameters);
				parameters.Exponent = new byte[3];
				parameters.Exponent[0] = blob[offset + 0x12];
				parameters.Exponent[1] = blob[offset + 0x11];
				parameters.Exponent[2] = blob[offset + 0x10];
				int srcOffset = offset + 0x14;
				int num2 = num >> 3;
				parameters.Modulus = new byte[num2];
				global::System.Buffer.BlockCopy(blob, srcOffset, parameters.Modulus, 0, num2);
				global::System.Array.Reverse(parameters.Modulus);
				global::System.Security.Cryptography.RSA rsa = null;
				try
				{
					rsa = global::System.Security.Cryptography.RSA.Create();
					rsa.ImportParameters(parameters);
				}
				catch (global::System.Security.Cryptography.CryptographicException)
				{
					rsa = new global::System.Security.Cryptography.RSACryptoServiceProvider(new global::System.Security.Cryptography.CspParameters
					{
						Flags = global::System.Security.Cryptography.CspProviderFlags.UseMachineKeyStore
					});
					rsa.ImportParameters(parameters);
				}
				result = rsa;
			}
			catch (global::System.Exception inner)
			{
				throw new global::System.Security.Cryptography.CryptographicException("Invalid blob.", inner);
			}
			return result;
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x000133E4 File Offset: 0x000115E4
		public static global::System.Security.Cryptography.RSA FromCapiKeyBlob(byte[] blob)
		{
			return global::Mono.Security.Cryptography.CryptoConvert.FromCapiKeyBlob(blob, 0);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x000133F0 File Offset: 0x000115F0
		public static global::System.Security.Cryptography.RSA FromCapiKeyBlob(byte[] blob, int offset)
		{
			if (blob == null)
			{
				throw new global::System.ArgumentNullException("blob");
			}
			if (offset >= blob.Length)
			{
				throw new global::System.ArgumentException("blob is too small.");
			}
			byte b = blob[offset];
			if (b != 0)
			{
				switch (b)
				{
				case 6:
					return global::Mono.Security.Cryptography.CryptoConvert.FromCapiPublicKeyBlob(blob, offset);
				case 7:
					return global::Mono.Security.Cryptography.CryptoConvert.FromCapiPrivateKeyBlob(blob, offset);
				}
			}
			else if (blob[offset + 0xC] == 6)
			{
				return global::Mono.Security.Cryptography.CryptoConvert.FromCapiPublicKeyBlob(blob, offset + 0xC);
			}
			throw new global::System.Security.Cryptography.CryptographicException("Unknown blob format.");
		}
	}
}

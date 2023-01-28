using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Mono.Cecil.PE;

namespace Mono.Cecil
{
	// Token: 0x02000090 RID: 144
	internal static class CryptoService
	{
		// Token: 0x0600062C RID: 1580 RVA: 0x0000F8E0 File Offset: 0x0000DAE0
		public static void StrongName(global::System.IO.Stream stream, global::Mono.Cecil.PE.ImageWriter writer, global::System.Reflection.StrongNameKeyPair key_pair)
		{
			int strong_name_pointer;
			byte[] strong_name = global::Mono.Cecil.CryptoService.CreateStrongName(key_pair, global::Mono.Cecil.CryptoService.HashStream(stream, writer, out strong_name_pointer));
			global::Mono.Cecil.CryptoService.PatchStrongName(stream, strong_name_pointer, strong_name);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0000F905 File Offset: 0x0000DB05
		private static void PatchStrongName(global::System.IO.Stream stream, int strong_name_pointer, byte[] strong_name)
		{
			stream.Seek((long)strong_name_pointer, global::System.IO.SeekOrigin.Begin);
			stream.Write(strong_name, 0, strong_name.Length);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0000F91C File Offset: 0x0000DB1C
		private static byte[] CreateStrongName(global::System.Reflection.StrongNameKeyPair key_pair, byte[] hash)
		{
			byte[] result;
			using (global::System.Security.Cryptography.RSA rsa = key_pair.CreateRSA())
			{
				global::System.Security.Cryptography.RSAPKCS1SignatureFormatter rsapkcs1SignatureFormatter = new global::System.Security.Cryptography.RSAPKCS1SignatureFormatter(rsa);
				rsapkcs1SignatureFormatter.SetHashAlgorithm("SHA1");
				byte[] array = rsapkcs1SignatureFormatter.CreateSignature(hash);
				global::System.Array.Reverse(array);
				result = array;
			}
			return result;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0000F970 File Offset: 0x0000DB70
		private static byte[] HashStream(global::System.IO.Stream stream, global::Mono.Cecil.PE.ImageWriter writer, out int strong_name_pointer)
		{
			global::Mono.Cecil.PE.Section text = writer.text;
			int headerSize = (int)writer.GetHeaderSize();
			int pointerToRawData = (int)text.PointerToRawData;
			global::Mono.Cecil.PE.DataDirectory strongNameSignatureDirectory = writer.GetStrongNameSignatureDirectory();
			if (strongNameSignatureDirectory.Size == 0U)
			{
				throw new global::System.InvalidOperationException();
			}
			strong_name_pointer = (int)((long)pointerToRawData + (long)((ulong)(strongNameSignatureDirectory.VirtualAddress - text.VirtualAddress)));
			int size = (int)strongNameSignatureDirectory.Size;
			global::System.Security.Cryptography.SHA1Managed sha1Managed = new global::System.Security.Cryptography.SHA1Managed();
			byte[] buffer = new byte[0x2000];
			using (global::System.Security.Cryptography.CryptoStream cryptoStream = new global::System.Security.Cryptography.CryptoStream(global::System.IO.Stream.Null, sha1Managed, global::System.Security.Cryptography.CryptoStreamMode.Write))
			{
				stream.Seek(0L, global::System.IO.SeekOrigin.Begin);
				global::Mono.Cecil.CryptoService.CopyStreamChunk(stream, cryptoStream, buffer, headerSize);
				stream.Seek((long)pointerToRawData, global::System.IO.SeekOrigin.Begin);
				global::Mono.Cecil.CryptoService.CopyStreamChunk(stream, cryptoStream, buffer, strong_name_pointer - pointerToRawData);
				stream.Seek((long)size, global::System.IO.SeekOrigin.Current);
				global::Mono.Cecil.CryptoService.CopyStreamChunk(stream, cryptoStream, buffer, (int)(stream.Length - (long)(strong_name_pointer + size)));
			}
			return sha1Managed.Hash;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0000FA60 File Offset: 0x0000DC60
		private static void CopyStreamChunk(global::System.IO.Stream stream, global::System.IO.Stream dest_stream, byte[] buffer, int length)
		{
			while (length > 0)
			{
				int num = stream.Read(buffer, 0, global::System.Math.Min(buffer.Length, length));
				dest_stream.Write(buffer, 0, num);
				length -= num;
			}
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0000FA94 File Offset: 0x0000DC94
		public static byte[] ComputeHash(string file)
		{
			if (!global::System.IO.File.Exists(file))
			{
				return global::Mono.Empty<byte>.Array;
			}
			global::System.Security.Cryptography.SHA1Managed sha1Managed = new global::System.Security.Cryptography.SHA1Managed();
			using (global::System.IO.FileStream fileStream = new global::System.IO.FileStream(file, global::System.IO.FileMode.Open, global::System.IO.FileAccess.Read, global::System.IO.FileShare.Read))
			{
				byte[] buffer = new byte[0x2000];
				using (global::System.Security.Cryptography.CryptoStream cryptoStream = new global::System.Security.Cryptography.CryptoStream(global::System.IO.Stream.Null, sha1Managed, global::System.Security.Cryptography.CryptoStreamMode.Write))
				{
					global::Mono.Cecil.CryptoService.CopyStreamChunk(fileStream, cryptoStream, buffer, (int)fileStream.Length);
				}
			}
			return sha1Managed.Hash;
		}
	}
}

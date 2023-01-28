using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using LitJson;

namespace Facepunch.Load
{
	// Token: 0x020002DE RID: 734
	public sealed class Reader : global::Facepunch.Load.Stream
	{
		// Token: 0x06001947 RID: 6471 RVA: 0x00061A08 File Offset: 0x0005FC08
		private Reader(global::LitJson.JsonReader json, string bundlePath, bool createdForThisInstance)
		{
			if (json == null)
			{
				throw new global::System.ArgumentNullException("json");
			}
			this.json = json;
			this.disposesTextReader = createdForThisInstance;
			this.prefix = bundlePath;
			if (string.IsNullOrEmpty(this.prefix))
			{
				this.prefix = string.Empty;
			}
			else
			{
				char c = this.prefix[this.prefix.Length - 1];
				if (c != '/' && c != '\\')
				{
					this.prefix += "/";
				}
			}
		}

		// Token: 0x06001948 RID: 6472 RVA: 0x00061AB0 File Offset: 0x0005FCB0
		private Reader(global::LitJson.JsonReader json, string bundlePath) : this(json, bundlePath, false)
		{
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x00061ABC File Offset: 0x0005FCBC
		private Reader(global::System.IO.TextReader reader, string bundlePath) : this(new global::LitJson.JsonReader(reader), bundlePath, false)
		{
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x00061ACC File Offset: 0x0005FCCC
		private Reader(string text, string bundlePath) : this(new global::LitJson.JsonReader(text), bundlePath, true)
		{
		}

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x0600194B RID: 6475 RVA: 0x00061ADC File Offset: 0x0005FCDC
		public global::Facepunch.Load.Token Token
		{
			get
			{
				if (this.disposed)
				{
					throw new global::System.ObjectDisposedException("Reader");
				}
				return this.token;
			}
		}

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x0600194C RID: 6476 RVA: 0x00061AFC File Offset: 0x0005FCFC
		public global::Facepunch.Load.Item Item
		{
			get
			{
				if (this.disposed)
				{
					throw new global::System.ObjectDisposedException("Reader");
				}
				if (this.token != global::Facepunch.Load.Token.BundleListing)
				{
					throw new global::System.InvalidOperationException("You may only retreive Item when Token is Token.BundleListing!");
				}
				return this.item;
			}
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x00061B34 File Offset: 0x0005FD34
		public static global::Facepunch.Load.Reader CreateFromFile(string openFilePath, string bundlePath)
		{
			return new global::Facepunch.Load.Reader(new global::LitJson.JsonReader(global::System.IO.File.OpenText(openFilePath)), bundlePath, true);
		}

		// Token: 0x0600194E RID: 6478 RVA: 0x00061B48 File Offset: 0x0005FD48
		public static global::Facepunch.Load.Reader CreateFromFile(string openFilePath)
		{
			return global::Facepunch.Load.Reader.CreateFromFile(openFilePath, global::System.IO.Path.GetDirectoryName(openFilePath));
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x00061B58 File Offset: 0x0005FD58
		public static global::Facepunch.Load.Reader CreateFromText(string jsonText, string bundlePath)
		{
			return new global::Facepunch.Load.Reader(jsonText, bundlePath);
		}

		// Token: 0x06001950 RID: 6480 RVA: 0x00061B64 File Offset: 0x0005FD64
		public static global::Facepunch.Load.Reader CreateFromReader(global::System.IO.TextReader textReader, string bundlePath)
		{
			return new global::Facepunch.Load.Reader(textReader, bundlePath);
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x00061B70 File Offset: 0x0005FD70
		public static global::Facepunch.Load.Reader CreateFromReader(global::LitJson.JsonReader textReader, string bundlePath)
		{
			return new global::Facepunch.Load.Reader(textReader, bundlePath);
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00061B7C File Offset: 0x0005FD7C
		private string PathToBundle(string incomingPathFromJson)
		{
			if (incomingPathFromJson.Contains("//") || incomingPathFromJson.Contains(":/") || incomingPathFromJson.Contains(":\\") || global::System.IO.Path.IsPathRooted(incomingPathFromJson))
			{
				return incomingPathFromJson;
			}
			return this.prefix + incomingPathFromJson;
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x00061BD4 File Offset: 0x0005FDD4
		private void ReadBundleListing(string nameOfBundle)
		{
			if (!this.json.Read())
			{
				throw new global::LitJson.JsonException("End of stream unexpected");
			}
			if (this.json.Token != 1)
			{
				throw new global::LitJson.JsonException("Expected object start for bundle name (property) " + nameOfBundle);
			}
			this.item.Name = nameOfBundle;
			this.item.ByteLength = -1;
			while (this.json.Read())
			{
				if (this.json.Token == 3)
				{
					if (string.IsNullOrEmpty(this.item.Path))
					{
						throw new global::LitJson.JsonException("Path to bundle not defined for bundle listing " + nameOfBundle);
					}
					if (this.item.ByteLength == -1)
					{
						throw new global::LitJson.JsonException("There was no size property for bundle listing " + nameOfBundle);
					}
					global::Facepunch.Load.ContentType contentType = this.item.ContentType;
					if (contentType != global::Facepunch.Load.ContentType.Assets)
					{
						if (contentType != global::Facepunch.Load.ContentType.Scenes)
						{
							throw new global::LitJson.JsonException(string.Concat(new object[]
							{
								"The content ",
								this.item.ContentType,
								" was not handled for bundle listing ",
								nameOfBundle
							}));
						}
						if (this.item.TypeOfAssets != null)
						{
							throw new global::LitJson.JsonException("There should not have been a type property for scene bundle listing " + nameOfBundle);
						}
					}
					else if (this.item.TypeOfAssets == null)
					{
						throw new global::LitJson.JsonException("There was no valid type property for asset bundle listing " + nameOfBundle);
					}
					return;
				}
				else
				{
					if (this.json.Token == 2)
					{
						bool flag = false;
						string asString = this.json.Value.AsString;
						if (asString != null)
						{
							if (global::Facepunch.Load.Reader.<>f__switch$map4 == null)
							{
								global::Facepunch.Load.Reader.<>f__switch$map4 = new global::System.Collections.Generic.Dictionary<string, int>(5)
								{
									{
										"type",
										0
									},
									{
										"size",
										1
									},
									{
										"content",
										2
									},
									{
										"filename",
										3
									},
									{
										"url",
										4
									}
								};
							}
							int num;
							if (global::Facepunch.Load.Reader.<>f__switch$map4.TryGetValue(asString, out num))
							{
								switch (num)
								{
								case 0:
									if (!this.json.Read())
									{
										throw new global::LitJson.JsonException("Unexpected end of stream at type");
									}
									switch (this.json.Token)
									{
									case 9:
										try
										{
											this.item.TypeOfAssets = global::Facepunch.Load.Reader.ParseType(this.json.Value.AsString);
										}
										catch (global::System.TypeLoadException ex)
										{
											throw new global::LitJson.JsonException(this.json.Value.AsString, ex);
										}
										continue;
									case 0xB:
										this.item.TypeOfAssets = null;
										continue;
									}
									throw new global::LitJson.JsonException("the type property expects only null or string. got : " + this.json.Token);
								case 1:
									if (!this.json.Read())
									{
										throw new global::LitJson.JsonException("Unexpected end of stream at size");
									}
									switch (this.json.Token)
									{
									case 6:
									case 8:
										this.item.ByteLength = this.json.Value.AsInt;
										continue;
									}
									throw new global::LitJson.JsonException("the size property expects a number. got : " + this.json.Token);
								case 2:
									if (!this.json.Read())
									{
										throw new global::LitJson.JsonException("Unexpected end of stream at content");
									}
									switch (this.json.Token)
									{
									case 6:
										this.item.ContentType = (global::Facepunch.Load.ContentType)this.json.Value.AsInt;
										continue;
									case 9:
										try
										{
											this.item.ContentType = (global::Facepunch.Load.ContentType)((byte)global::System.Enum.Parse(typeof(global::Facepunch.Load.ContentType), this.json.Value.AsString, true));
										}
										catch (global::System.ArgumentException ex2)
										{
											throw new global::LitJson.JsonException(this.json.Value.AsString, ex2);
										}
										catch (global::System.OverflowException ex3)
										{
											throw new global::LitJson.JsonException(this.json.Value.AsString, ex3);
										}
										continue;
									}
									throw new global::LitJson.JsonException("the content property expects a string or int. got : " + this.json.Token);
								case 3:
								{
									if (!this.json.Read())
									{
										throw new global::LitJson.JsonException("Unexpected end of stream at filename");
									}
									global::LitJson.JsonToken jsonToken = this.json.Token;
									if (jsonToken != 9)
									{
										throw new global::LitJson.JsonException("the filename property expects a string. got : " + this.json.Token);
									}
									if (!flag)
									{
										try
										{
											this.item.Path = this.PathToBundle(this.json.Value.AsString);
										}
										catch (global::System.Exception ex4)
										{
											throw new global::LitJson.JsonException(this.json.Value.AsString, ex4);
										}
									}
									break;
								}
								case 4:
								{
									if (!this.json.Read())
									{
										throw new global::LitJson.JsonException("Unexpected end of stream at url");
									}
									global::LitJson.JsonToken jsonToken = this.json.Token;
									if (jsonToken != 9)
									{
										throw new global::LitJson.JsonException("the url property expects a string. got : " + this.json.Token);
									}
									try
									{
										this.item.Path = this.json.Value.AsString;
									}
									catch (global::System.Exception ex5)
									{
										throw new global::LitJson.JsonException(this.json.Value.AsString, ex5);
									}
									break;
								}
								default:
									goto IL_4BE;
								}
								continue;
							}
						}
						IL_4BE:
						throw new global::LitJson.JsonException("Unhandled property named " + this.json.Value.AsString);
					}
					throw new global::LitJson.JsonException("Unexpected token in json : JsonToken." + this.json.Token);
				}
			}
			throw new global::LitJson.JsonException("Unexpected end of stream");
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00062250 File Offset: 0x00060450
		public bool Read()
		{
			if (this.disposed)
			{
				throw new global::System.ObjectDisposedException("Reader");
			}
			this.item = default(global::Facepunch.Load.Item);
			if (!this.json.Read())
			{
				this.token = global::Facepunch.Load.Token.End;
				return false;
			}
			if (this.insideOrderList)
			{
				if (this.insideRandomList)
				{
					global::LitJson.JsonToken jsonToken = this.json.Token;
					if (jsonToken == 2)
					{
						this.token = global::Facepunch.Load.Token.BundleListing;
						this.ReadBundleListing(this.json.Value.AsString);
						return true;
					}
					if (jsonToken == 3)
					{
						this.token = global::Facepunch.Load.Token.RandomLoadOrderAreaEnd;
						this.insideRandomList = false;
						return true;
					}
				}
				else
				{
					global::LitJson.JsonToken jsonToken = this.json.Token;
					if (jsonToken == 1)
					{
						this.token = global::Facepunch.Load.Token.RandomLoadOrderAreaBegin;
						this.insideRandomList = true;
						return true;
					}
					if (jsonToken == 5)
					{
						this.token = global::Facepunch.Load.Token.DownloadQueueEnd;
						this.insideOrderList = false;
						return true;
					}
				}
			}
			else
			{
				global::LitJson.JsonToken jsonToken = this.json.Token;
				if (jsonToken == 0)
				{
					this.token = global::Facepunch.Load.Token.End;
					return false;
				}
				if (jsonToken == 4)
				{
					this.token = global::Facepunch.Load.Token.DownloadQueueBegin;
					this.insideOrderList = true;
					return true;
				}
			}
			throw new global::LitJson.JsonException("Bad json state");
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x0006238C File Offset: 0x0006058C
		public override void Dispose()
		{
			if (!this.disposed)
			{
				if (!this.disposesTextReader)
				{
					while (this.token != global::Facepunch.Load.Token.End && this.token != global::Facepunch.Load.Token.DownloadQueueEnd)
					{
						try
						{
							this.Read();
						}
						catch (global::LitJson.JsonException)
						{
							this.token = global::Facepunch.Load.Token.End;
						}
					}
				}
				else
				{
					try
					{
						this.json.Dispose();
					}
					catch (global::System.ObjectDisposedException)
					{
					}
				}
				this.json = null;
				this.disposed = true;
			}
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x00062444 File Offset: 0x00060644
		private static global::System.Type ParseType(string str)
		{
			global::System.Type type = global::System.Type.GetType(str, false, true);
			if (type != null)
			{
				return type;
			}
			string typeName = "Facepunch.MeshBatch." + str;
			type = global::System.Type.GetType(typeName, false, true);
			if (type != null)
			{
				return type;
			}
			return global::System.Type.GetType(str, true, true);
		}

		// Token: 0x04000E48 RID: 3656
		private global::LitJson.JsonReader json;

		// Token: 0x04000E49 RID: 3657
		private bool insideOrderList;

		// Token: 0x04000E4A RID: 3658
		private bool insideRandomList;

		// Token: 0x04000E4B RID: 3659
		private global::Facepunch.Load.Token token;

		// Token: 0x04000E4C RID: 3660
		private bool disposed;

		// Token: 0x04000E4D RID: 3661
		private readonly bool disposesTextReader;

		// Token: 0x04000E4E RID: 3662
		private readonly string prefix;

		// Token: 0x04000E4F RID: 3663
		private global::Facepunch.Load.Item item;

		// Token: 0x04000E50 RID: 3664
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map4;
	}
}

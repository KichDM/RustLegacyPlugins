using System;
using System.Net;
using System.Text;

namespace Magma
{
	// Token: 0x02000014 RID: 20
	public class Web
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x000037F8 File Offset: 0x000019F8
		public string POST(string url, string data)
		{
			string @string;
			using (global::System.Net.WebClient webClient = new global::System.Net.WebClient())
			{
				webClient.Headers[global::System.Net.HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
				byte[] bytes = webClient.UploadData(url, "POST", global::System.Text.Encoding.ASCII.GetBytes(data));
				@string = global::System.Text.Encoding.ASCII.GetString(bytes);
			}
			return @string;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003860 File Offset: 0x00001A60
		public string GET(string url)
		{
			string result;
			using (global::System.Net.WebClient webClient = new global::System.Net.WebClient())
			{
				result = webClient.DownloadString(url);
			}
			return result;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003898 File Offset: 0x00001A98
		public Web()
		{
		}
	}
}

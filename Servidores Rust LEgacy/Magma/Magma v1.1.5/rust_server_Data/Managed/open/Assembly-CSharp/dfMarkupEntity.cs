using System;
using System.Collections.Generic;
using System.Text;

// Token: 0x02000863 RID: 2147
public class dfMarkupEntity
{
	// Token: 0x06004A83 RID: 19075 RVA: 0x00118360 File Offset: 0x00116560
	public dfMarkupEntity(string entityName, string entityChar)
	{
		this.EntityName = entityName;
		this.EntityChar = entityChar;
	}

	// Token: 0x06004A84 RID: 19076 RVA: 0x00118378 File Offset: 0x00116578
	// Note: this type is marked as 'beforefieldinit'.
	static dfMarkupEntity()
	{
	}

	// Token: 0x06004A85 RID: 19077 RVA: 0x00118458 File Offset: 0x00116658
	public static string Replace(string text)
	{
		global::dfMarkupEntity.buffer.EnsureCapacity(text.Length);
		global::dfMarkupEntity.buffer.Length = 0;
		global::dfMarkupEntity.buffer.Append(text);
		for (int i = 0; i < global::dfMarkupEntity.HTML_ENTITIES.Count; i++)
		{
			global::dfMarkupEntity dfMarkupEntity = global::dfMarkupEntity.HTML_ENTITIES[i];
			global::dfMarkupEntity.buffer.Replace(dfMarkupEntity.EntityName, dfMarkupEntity.EntityChar);
		}
		return global::dfMarkupEntity.buffer.ToString();
	}

	// Token: 0x040027AD RID: 10157
	private static global::System.Collections.Generic.List<global::dfMarkupEntity> HTML_ENTITIES = new global::System.Collections.Generic.List<global::dfMarkupEntity>
	{
		new global::dfMarkupEntity("&nbsp;", " "),
		new global::dfMarkupEntity("&quot;", "\""),
		new global::dfMarkupEntity("&amp;", "&"),
		new global::dfMarkupEntity("&lt;", "<"),
		new global::dfMarkupEntity("&gt;", ">"),
		new global::dfMarkupEntity("&#39;", "'"),
		new global::dfMarkupEntity("&trade;", "™"),
		new global::dfMarkupEntity("&copy;", "©"),
		new global::dfMarkupEntity("\u00a0", " ")
	};

	// Token: 0x040027AE RID: 10158
	private static global::System.Text.StringBuilder buffer = new global::System.Text.StringBuilder();

	// Token: 0x040027AF RID: 10159
	public string EntityName;

	// Token: 0x040027B0 RID: 10160
	public string EntityChar;
}

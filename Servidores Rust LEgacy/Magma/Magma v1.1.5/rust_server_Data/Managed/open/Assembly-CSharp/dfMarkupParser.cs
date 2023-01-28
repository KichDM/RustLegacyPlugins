using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

// Token: 0x02000869 RID: 2153
public class dfMarkupParser
{
	// Token: 0x06004AA9 RID: 19113 RVA: 0x00118930 File Offset: 0x00116B30
	public dfMarkupParser()
	{
	}

	// Token: 0x06004AAA RID: 19114 RVA: 0x00118938 File Offset: 0x00116B38
	static dfMarkupParser()
	{
		global::System.Text.RegularExpressions.RegexOptions options = global::System.Text.RegularExpressions.RegexOptions.IgnoreCase | global::System.Text.RegularExpressions.RegexOptions.ExplicitCapture | global::System.Text.RegularExpressions.RegexOptions.CultureInvariant;
		global::dfMarkupParser.TAG_PATTERN = new global::System.Text.RegularExpressions.Regex("(\\<\\/?)(?<tag>[a-zA-Z0-9$_]+)(\\s(?<attr>.+?))?([\\/]*\\>)", options);
		global::dfMarkupParser.ATTR_PATTERN = new global::System.Text.RegularExpressions.Regex("(?<key>[a-zA-Z0-9$_]+)=(?<value>(\"((\\\\\")|\\\\\\\\|[^\"\\n])*\")|('((\\\\')|\\\\\\\\|[^'\\n])*')|\\d+|\\w+)", options);
		global::dfMarkupParser.STYLE_PATTERN = new global::System.Text.RegularExpressions.Regex("(?<key>[a-zA-Z0-9\\-]+)(\\s*\\:\\s*)(?<value>[^;]+)", options);
	}

	// Token: 0x06004AAB RID: 19115 RVA: 0x001189A0 File Offset: 0x00116BA0
	public static global::dfList<global::dfMarkupElement> Parse(global::dfRichTextLabel owner, string source)
	{
		global::dfList<global::dfMarkupElement> result;
		try
		{
			global::dfMarkupParser.parserInstance.owner = owner;
			global::dfList<global::dfMarkupElement> dfList = global::dfMarkupParser.parserInstance.parseMarkup(source);
			result = dfList;
		}
		finally
		{
		}
		return result;
	}

	// Token: 0x06004AAC RID: 19116 RVA: 0x001189F0 File Offset: 0x00116BF0
	private global::dfList<global::dfMarkupElement> parseMarkup(string source)
	{
		global::System.Collections.Generic.Queue<global::dfMarkupElement> queue = new global::System.Collections.Generic.Queue<global::dfMarkupElement>();
		global::System.Text.RegularExpressions.MatchCollection matchCollection = global::dfMarkupParser.TAG_PATTERN.Matches(source);
		int num = 0;
		for (int i = 0; i < matchCollection.Count; i++)
		{
			global::System.Text.RegularExpressions.Match match = matchCollection[i];
			if (match.Index > num)
			{
				string text = source.Substring(num, match.Index - num);
				global::dfMarkupString item = new global::dfMarkupString(text);
				queue.Enqueue(item);
			}
			num = match.Index + match.Length;
			queue.Enqueue(this.parseTag(match));
		}
		if (num < source.Length)
		{
			string text2 = source.Substring(num);
			global::dfMarkupString item2 = new global::dfMarkupString(text2);
			queue.Enqueue(item2);
		}
		return this.processTokens(queue);
	}

	// Token: 0x06004AAD RID: 19117 RVA: 0x00118AAC File Offset: 0x00116CAC
	private global::dfList<global::dfMarkupElement> processTokens(global::System.Collections.Generic.Queue<global::dfMarkupElement> tokens)
	{
		global::dfList<global::dfMarkupElement> dfList = global::dfList<global::dfMarkupElement>.Obtain();
		while (tokens.Count > 0)
		{
			dfList.Add(this.parseElement(tokens));
		}
		for (int i = 0; i < dfList.Count; i++)
		{
			if (dfList[i] is global::dfMarkupTag)
			{
				((global::dfMarkupTag)dfList[i]).Owner = this.owner;
			}
		}
		return dfList;
	}

	// Token: 0x06004AAE RID: 19118 RVA: 0x00118B20 File Offset: 0x00116D20
	private global::dfMarkupElement parseElement(global::System.Collections.Generic.Queue<global::dfMarkupElement> tokens)
	{
		global::dfMarkupElement dfMarkupElement = tokens.Dequeue();
		if (dfMarkupElement is global::dfMarkupString)
		{
			return ((global::dfMarkupString)dfMarkupElement).SplitWords();
		}
		global::dfMarkupTag dfMarkupTag = (global::dfMarkupTag)dfMarkupElement;
		if (dfMarkupTag.IsClosedTag || dfMarkupTag.IsEndTag)
		{
			return this.refineTag(dfMarkupTag);
		}
		while (tokens.Count > 0)
		{
			global::dfMarkupElement dfMarkupElement2 = this.parseElement(tokens);
			if (dfMarkupElement2 is global::dfMarkupTag)
			{
				global::dfMarkupTag dfMarkupTag2 = (global::dfMarkupTag)dfMarkupElement2;
				if (dfMarkupTag2.IsEndTag)
				{
					if (dfMarkupTag2.TagName == dfMarkupTag.TagName)
					{
						break;
					}
					return this.refineTag(dfMarkupTag);
				}
			}
			dfMarkupTag.AddChildNode(dfMarkupElement2);
		}
		return this.refineTag(dfMarkupTag);
	}

	// Token: 0x06004AAF RID: 19119 RVA: 0x00118BD8 File Offset: 0x00116DD8
	private global::dfMarkupTag refineTag(global::dfMarkupTag original)
	{
		if (original.IsEndTag)
		{
			return original;
		}
		if (global::dfMarkupParser.tagTypes == null)
		{
			global::dfMarkupParser.tagTypes = new global::System.Collections.Generic.Dictionary<string, global::System.Type>();
			foreach (global::System.Type type in global::System.Reflection.Assembly.GetExecutingAssembly().GetExportedTypes())
			{
				if (typeof(global::dfMarkupTag).IsAssignableFrom(type))
				{
					object[] customAttributes = type.GetCustomAttributes(typeof(global::dfMarkupTagInfoAttribute), true);
					if (customAttributes != null && customAttributes.Length != 0)
					{
						for (int j = 0; j < customAttributes.Length; j++)
						{
							string tagName = ((global::dfMarkupTagInfoAttribute)customAttributes[j]).TagName;
							global::dfMarkupParser.tagTypes[tagName] = type;
						}
					}
				}
			}
		}
		if (global::dfMarkupParser.tagTypes.ContainsKey(original.TagName))
		{
			global::System.Type type2 = global::dfMarkupParser.tagTypes[original.TagName];
			return (global::dfMarkupTag)global::System.Activator.CreateInstance(type2, new object[]
			{
				original
			});
		}
		return original;
	}

	// Token: 0x06004AB0 RID: 19120 RVA: 0x00118CDC File Offset: 0x00116EDC
	private global::dfMarkupElement parseTag(global::System.Text.RegularExpressions.Match tag)
	{
		string text = tag.Groups["tag"].Value.ToLowerInvariant();
		if (tag.Value.StartsWith("</"))
		{
			return new global::dfMarkupTag(text)
			{
				IsEndTag = true
			};
		}
		global::dfMarkupTag dfMarkupTag = new global::dfMarkupTag(text);
		string value = tag.Groups["attr"].Value;
		global::System.Text.RegularExpressions.MatchCollection matchCollection = global::dfMarkupParser.ATTR_PATTERN.Matches(value);
		for (int i = 0; i < matchCollection.Count; i++)
		{
			global::System.Text.RegularExpressions.Match match = matchCollection[i];
			string value2 = match.Groups["key"].Value;
			string text2 = global::dfMarkupEntity.Replace(match.Groups["value"].Value);
			if (text2.StartsWith("\""))
			{
				text2 = text2.Trim(new char[]
				{
					'"'
				});
			}
			else if (text2.StartsWith("'"))
			{
				text2 = text2.Trim(new char[]
				{
					'\''
				});
			}
			if (!string.IsNullOrEmpty(text2))
			{
				if (value2 == "style")
				{
					this.parseStyleAttribute(dfMarkupTag, text2);
				}
				else
				{
					dfMarkupTag.Attributes.Add(new global::dfMarkupAttribute(value2, text2));
				}
			}
		}
		if (tag.Value.EndsWith("/>") || text == "br" || text == "img")
		{
			dfMarkupTag.IsClosedTag = true;
		}
		return dfMarkupTag;
	}

	// Token: 0x06004AB1 RID: 19121 RVA: 0x00118E80 File Offset: 0x00117080
	private void parseStyleAttribute(global::dfMarkupTag element, string text)
	{
		global::System.Text.RegularExpressions.MatchCollection matchCollection = global::dfMarkupParser.STYLE_PATTERN.Matches(text);
		for (int i = 0; i < matchCollection.Count; i++)
		{
			global::System.Text.RegularExpressions.Match match = matchCollection[i];
			string name = match.Groups["key"].Value.ToLowerInvariant();
			string value = match.Groups["value"].Value;
			element.Attributes.Add(new global::dfMarkupAttribute(name, value));
		}
	}

	// Token: 0x040027BC RID: 10172
	private static global::System.Text.RegularExpressions.Regex TAG_PATTERN = null;

	// Token: 0x040027BD RID: 10173
	private static global::System.Text.RegularExpressions.Regex ATTR_PATTERN = null;

	// Token: 0x040027BE RID: 10174
	private static global::System.Text.RegularExpressions.Regex STYLE_PATTERN = null;

	// Token: 0x040027BF RID: 10175
	private static global::System.Collections.Generic.Dictionary<string, global::System.Type> tagTypes = null;

	// Token: 0x040027C0 RID: 10176
	private static global::dfMarkupParser parserInstance = new global::dfMarkupParser();

	// Token: 0x040027C1 RID: 10177
	private global::dfRichTextLabel owner;
}

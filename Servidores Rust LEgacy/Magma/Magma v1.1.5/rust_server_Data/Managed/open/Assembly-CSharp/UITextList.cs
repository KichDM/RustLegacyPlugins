using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000968 RID: 2408
[global::UnityEngine.AddComponentMenu("NGUI/UI/Text List")]
public class UITextList : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600521D RID: 21021 RVA: 0x001503AC File Offset: 0x0014E5AC
	public UITextList()
	{
	}

	// Token: 0x0600521E RID: 21022 RVA: 0x001503E0 File Offset: 0x0014E5E0
	public void Clear()
	{
		this.mParagraphs.Clear();
		this.UpdateVisibleText();
	}

	// Token: 0x0600521F RID: 21023 RVA: 0x001503F4 File Offset: 0x0014E5F4
	public void Add(string text)
	{
		this.Add(text, true);
	}

	// Token: 0x06005220 RID: 21024 RVA: 0x00150400 File Offset: 0x0014E600
	protected void Add(string text, bool updateVisible)
	{
		global::UITextList.Paragraph paragraph;
		if (this.mParagraphs.Count < this.maxEntries)
		{
			paragraph = new global::UITextList.Paragraph();
		}
		else
		{
			paragraph = this.mParagraphs[0];
			this.mParagraphs.RemoveAt(0);
		}
		paragraph.text = text;
		this.mParagraphs.Add(paragraph);
		if (this.textLabel != null && this.textLabel.font != null)
		{
			paragraph.lines = this.textLabel.font.WrapText(global::UIFont.tempMarkup, paragraph.text, this.maxWidth / this.textLabel.transform.localScale.y, this.textLabel.maxLineCount, this.textLabel.supportEncoding, this.textLabel.symbolStyle).Split(this.mSeparator);
			this.mTotalLines = 0;
			int i = 0;
			int count = this.mParagraphs.Count;
			while (i < count)
			{
				this.mTotalLines += this.mParagraphs[i].lines.Length;
				i++;
			}
		}
		if (updateVisible)
		{
			this.UpdateVisibleText();
		}
	}

	// Token: 0x06005221 RID: 21025 RVA: 0x00150540 File Offset: 0x0014E740
	private void Awake()
	{
		if (this.textLabel == null)
		{
			this.textLabel = base.GetComponentInChildren<global::UILabel>();
		}
		if (this.textLabel != null)
		{
			this.textLabel.lineWidth = 0;
		}
		global::UnityEngine.Collider collider = base.collider;
		if (collider != null)
		{
			if (this.maxHeight <= 0f)
			{
				this.maxHeight = collider.bounds.size.y / base.transform.lossyScale.y;
			}
			if (this.maxWidth <= 0f)
			{
				this.maxWidth = collider.bounds.size.x / base.transform.lossyScale.x;
			}
		}
	}

	// Token: 0x06005222 RID: 21026 RVA: 0x00150620 File Offset: 0x0014E820
	private void OnSelect(bool selected)
	{
		this.mSelected = selected;
	}

	// Token: 0x06005223 RID: 21027 RVA: 0x0015062C File Offset: 0x0014E82C
	protected void UpdateVisibleText()
	{
		if (this.textLabel != null)
		{
			global::UIFont font = this.textLabel.font;
			if (font != null)
			{
				int num = 0;
				int num2 = (this.maxHeight <= 0f) ? 0x186A0 : global::UnityEngine.Mathf.FloorToInt(this.maxHeight / this.textLabel.cachedTransform.localScale.y);
				int num3 = global::UnityEngine.Mathf.RoundToInt(this.mScroll);
				if (num2 + num3 > this.mTotalLines)
				{
					num3 = global::UnityEngine.Mathf.Max(0, this.mTotalLines - num2);
					this.mScroll = (float)num3;
				}
				if (this.style == global::UITextList.Style.Chat)
				{
					num3 = global::UnityEngine.Mathf.Max(0, this.mTotalLines - num2 - num3);
				}
				string text = string.Empty;
				int i = 0;
				int count = this.mParagraphs.Count;
				while (i < count)
				{
					global::UITextList.Paragraph paragraph = this.mParagraphs[i];
					int j = 0;
					int num4 = paragraph.lines.Length;
					while (j < num4)
					{
						string str = paragraph.lines[j];
						if (num3 > 0)
						{
							num3--;
						}
						else
						{
							if (text.Length > 0)
							{
								text += "\n";
							}
							text += str;
							num++;
							if (num >= num2)
							{
								break;
							}
						}
						j++;
					}
					if (num >= num2)
					{
						break;
					}
					i++;
				}
				this.textLabel.text = text;
			}
		}
	}

	// Token: 0x06005224 RID: 21028 RVA: 0x001507BC File Offset: 0x0014E9BC
	private void OnScroll(float val)
	{
		if (this.mSelected && this.supportScrollWheel)
		{
			val *= ((this.style != global::UITextList.Style.Chat) ? -10f : 10f);
			this.mScroll = global::UnityEngine.Mathf.Max(0f, this.mScroll + val);
			this.UpdateVisibleText();
		}
	}

	// Token: 0x04002E78 RID: 11896
	public global::UITextList.Style style;

	// Token: 0x04002E79 RID: 11897
	public global::UILabel textLabel;

	// Token: 0x04002E7A RID: 11898
	public float maxWidth;

	// Token: 0x04002E7B RID: 11899
	public float maxHeight;

	// Token: 0x04002E7C RID: 11900
	public int maxEntries = 0x32;

	// Token: 0x04002E7D RID: 11901
	public bool supportScrollWheel = true;

	// Token: 0x04002E7E RID: 11902
	protected char[] mSeparator = new char[]
	{
		'\n'
	};

	// Token: 0x04002E7F RID: 11903
	protected global::System.Collections.Generic.List<global::UITextList.Paragraph> mParagraphs = new global::System.Collections.Generic.List<global::UITextList.Paragraph>();

	// Token: 0x04002E80 RID: 11904
	protected float mScroll;

	// Token: 0x04002E81 RID: 11905
	protected bool mSelected;

	// Token: 0x04002E82 RID: 11906
	protected int mTotalLines;

	// Token: 0x02000969 RID: 2409
	public enum Style
	{
		// Token: 0x04002E84 RID: 11908
		Text,
		// Token: 0x04002E85 RID: 11909
		Chat
	}

	// Token: 0x0200096A RID: 2410
	protected class Paragraph
	{
		// Token: 0x06005225 RID: 21029 RVA: 0x0015081C File Offset: 0x0014EA1C
		public Paragraph()
		{
		}

		// Token: 0x04002E86 RID: 11910
		public string text;

		// Token: 0x04002E87 RID: 11911
		public string[] lines;
	}
}

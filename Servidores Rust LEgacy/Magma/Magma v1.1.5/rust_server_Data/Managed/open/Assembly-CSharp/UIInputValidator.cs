using System;
using UnityEngine;

// Token: 0x020008C9 RID: 2249
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Input Validator")]
[global::UnityEngine.RequireComponent(typeof(global::UIInput))]
public class UIInputValidator : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D6C RID: 19820 RVA: 0x001275EC File Offset: 0x001257EC
	public UIInputValidator()
	{
	}

	// Token: 0x06004D6D RID: 19821 RVA: 0x001275F4 File Offset: 0x001257F4
	private void Start()
	{
		base.GetComponent<global::UIInput>().validator = new global::UIInput.Validator(this.Validate);
	}

	// Token: 0x06004D6E RID: 19822 RVA: 0x00127610 File Offset: 0x00125810
	private char Validate(string text, char ch)
	{
		if (this.logic == global::UIInputValidator.Validation.None || !base.enabled)
		{
			return ch;
		}
		if (this.logic == global::UIInputValidator.Validation.Integer || this.logic == global::UIInputValidator.Validation.IntegerPositive)
		{
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
			if (this.logic != global::UIInputValidator.Validation.IntegerPositive && ch == '-' && text.Length == 0)
			{
				return ch;
			}
		}
		else if (this.logic == global::UIInputValidator.Validation.Float)
		{
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
			if (ch == '-' && text.Length == 0)
			{
				return ch;
			}
			if (ch == '.' && !text.Contains("."))
			{
				return ch;
			}
		}
		else if (this.logic == global::UIInputValidator.Validation.Alphanumeric)
		{
			if (ch >= 'A' && ch <= 'Z')
			{
				return ch;
			}
			if (ch >= 'a' && ch <= 'z')
			{
				return ch;
			}
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
		}
		else if (this.logic == global::UIInputValidator.Validation.Username)
		{
			if (ch >= 'A' && ch <= 'Z')
			{
				return ch - 'A' + 'a';
			}
			if (ch >= 'a' && ch <= 'z')
			{
				return ch;
			}
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
		}
		else if (this.logic == global::UIInputValidator.Validation.Name)
		{
			char c = (text.Length <= 0) ? ' ' : text[text.Length - 1];
			if (ch >= 'a' && ch <= 'z')
			{
				if (c == ' ')
				{
					return ch - 'a' + 'A';
				}
				return ch;
			}
			else if (ch >= 'A' && ch <= 'Z')
			{
				if (c != ' ' && c != '\'')
				{
					return ch - 'A' + 'a';
				}
				return ch;
			}
			else if (ch == '\'')
			{
				if (c != ' ' && c != '\'' && !text.Contains("'"))
				{
					return ch;
				}
			}
			else if (ch == ' ' && c != ' ' && c != '\'')
			{
				return ch;
			}
		}
		return '\0';
	}

	// Token: 0x04002A61 RID: 10849
	public global::UIInputValidator.Validation logic;

	// Token: 0x020008CA RID: 2250
	public enum Validation
	{
		// Token: 0x04002A63 RID: 10851
		None,
		// Token: 0x04002A64 RID: 10852
		Integer,
		// Token: 0x04002A65 RID: 10853
		Float,
		// Token: 0x04002A66 RID: 10854
		Alphanumeric,
		// Token: 0x04002A67 RID: 10855
		Username,
		// Token: 0x04002A68 RID: 10856
		Name,
		// Token: 0x04002A69 RID: 10857
		IntegerPositive
	}
}

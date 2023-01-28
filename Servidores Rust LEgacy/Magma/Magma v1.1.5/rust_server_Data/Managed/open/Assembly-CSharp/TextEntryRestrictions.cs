using System;
using System.Text;
using UnityEngine;

// Token: 0x0200051E RID: 1310
public class TextEntryRestrictions : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C79 RID: 11385 RVA: 0x000A7F88 File Offset: 0x000A6188
	public TextEntryRestrictions()
	{
	}

	// Token: 0x06002C7A RID: 11386 RVA: 0x000A7F9C File Offset: 0x000A619C
	public void OnKeyDown(global::dfControl control, global::dfKeyEventArgs keyEvent)
	{
		if (char.IsControl(keyEvent.Character))
		{
			return;
		}
		if (this.allowedChars.IndexOf(keyEvent.Character) == -1)
		{
			keyEvent.Use();
		}
	}

	// Token: 0x06002C7B RID: 11387 RVA: 0x000A7FD8 File Offset: 0x000A61D8
	public void OnKeyPress(global::dfControl control, global::dfKeyEventArgs keyEvent)
	{
		if (char.IsControl(keyEvent.Character))
		{
			return;
		}
		if (this.allowedChars.IndexOf(keyEvent.Character) == -1)
		{
			keyEvent.Use();
		}
	}

	// Token: 0x06002C7C RID: 11388 RVA: 0x000A8014 File Offset: 0x000A6214
	public void OnTextChanged(global::dfTextbox control, string value)
	{
		int num = control.CursorIndex;
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
		for (int i = 0; i < value.Length; i++)
		{
			if (this.allowedChars.IndexOf(value[i]) != -1)
			{
				stringBuilder.Append(value[i]);
			}
			else
			{
				num = global::UnityEngine.Mathf.Max(0, num + 1);
			}
		}
		control.Text = stringBuilder.ToString();
		control.CursorIndex = num;
	}

	// Token: 0x040016B8 RID: 5816
	public string allowedChars = "0123456789";
}

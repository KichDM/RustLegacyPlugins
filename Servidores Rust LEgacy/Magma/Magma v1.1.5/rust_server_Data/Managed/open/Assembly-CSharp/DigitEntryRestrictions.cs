using System;
using System.Text;
using UnityEngine;

// Token: 0x02000515 RID: 1301
public class DigitEntryRestrictions : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C57 RID: 11351 RVA: 0x000A7294 File Offset: 0x000A5494
	public DigitEntryRestrictions()
	{
	}

	// Token: 0x06002C58 RID: 11352 RVA: 0x000A729C File Offset: 0x000A549C
	public void OnKeyDown(global::dfControl control, global::dfKeyEventArgs keyEvent)
	{
		if (char.IsControl(keyEvent.Character))
		{
			return;
		}
		if (!char.IsDigit(keyEvent.Character))
		{
			keyEvent.Use();
		}
	}

	// Token: 0x06002C59 RID: 11353 RVA: 0x000A72C8 File Offset: 0x000A54C8
	public void OnKeyPress(global::dfControl control, global::dfKeyEventArgs keyEvent)
	{
		if (char.IsControl(keyEvent.Character))
		{
			return;
		}
		if (!char.IsDigit(keyEvent.Character))
		{
			keyEvent.Use();
		}
	}

	// Token: 0x06002C5A RID: 11354 RVA: 0x000A72F4 File Offset: 0x000A54F4
	public void OnTextChanged(global::dfTextbox control, string value)
	{
		int cursorIndex = control.CursorIndex;
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
		for (int i = 0; i < value.Length; i++)
		{
			if (char.IsDigit(value[i]))
			{
				stringBuilder.Append(value[i]);
			}
		}
		control.Text = stringBuilder.ToString();
	}
}

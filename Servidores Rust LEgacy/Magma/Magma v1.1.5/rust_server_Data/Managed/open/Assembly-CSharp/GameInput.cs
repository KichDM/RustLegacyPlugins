using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class GameInput : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000383 RID: 899 RVA: 0x00010B74 File Offset: 0x0000ED74
	public GameInput()
	{
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00010B7C File Offset: 0x0000ED7C
	// Note: this type is marked as 'beforefieldinit'.
	static GameInput()
	{
	}

	// Token: 0x06000385 RID: 901 RVA: 0x00010C6C File Offset: 0x0000EE6C
	public static global::GameInput.GameButton GetButton(string strName)
	{
		foreach (global::GameInput.GameButton gameButton in global::GameInput.Buttons)
		{
			if (gameButton.Name == strName)
			{
				return gameButton;
			}
		}
		return null;
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00010CAC File Offset: 0x0000EEAC
	public static string GetConfig()
	{
		string text = string.Empty;
		foreach (global::GameInput.GameButton gameButton in global::GameInput.Buttons)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"input.bind ",
				gameButton.Name,
				" ",
				gameButton.bindingOne.ToString(),
				" ",
				gameButton.bindingTwo.ToString(),
				"\n"
			});
		}
		return text;
	}

	// Token: 0x04000312 RID: 786
	public static global::GameInput.GameButton[] Buttons = new global::GameInput.GameButton[]
	{
		new global::GameInput.GameButton("Left"),
		new global::GameInput.GameButton("Right"),
		new global::GameInput.GameButton("Up"),
		new global::GameInput.GameButton("Down"),
		new global::GameInput.GameButton("Jump"),
		new global::GameInput.GameButton("Duck"),
		new global::GameInput.GameButton("Sprint"),
		new global::GameInput.GameButton("Fire"),
		new global::GameInput.GameButton("AltFire"),
		new global::GameInput.GameButton("Reload"),
		new global::GameInput.GameButton("Use"),
		new global::GameInput.GameButton("Inventory"),
		new global::GameInput.GameButton("Flashlight"),
		new global::GameInput.GameButton("Laser"),
		new global::GameInput.GameButton("Voice"),
		new global::GameInput.GameButton("Chat")
	};

	// Token: 0x020000B3 RID: 179
	public class GameButton
	{
		// Token: 0x06000387 RID: 903 RVA: 0x00010D44 File Offset: 0x0000EF44
		internal GameButton(string NiceName)
		{
			this.Name = NiceName;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00010D54 File Offset: 0x0000EF54
		private static bool IsKeyHeld(global::UnityEngine.KeyCode key)
		{
			return key != null && global::UnityEngine.Input.GetKey(key);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00010D68 File Offset: 0x0000EF68
		private static bool WasKeyPressed(global::UnityEngine.KeyCode key)
		{
			return key != null && global::UnityEngine.Input.GetKeyDown(key);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00010D7C File Offset: 0x0000EF7C
		private static bool WasKeyReleased(global::UnityEngine.KeyCode key)
		{
			return key != null && global::UnityEngine.Input.GetKeyUp(key);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00010D90 File Offset: 0x0000EF90
		private static global::UnityEngine.KeyCode? ParseKeyCode(string name)
		{
			global::UnityEngine.KeyCode? result;
			try
			{
				result = new global::UnityEngine.KeyCode?((int)global::System.Enum.Parse(typeof(global::UnityEngine.KeyCode), name, true));
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
				result = null;
			}
			return result;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00010DFC File Offset: 0x0000EFFC
		private static void SetKeyCode(ref global::UnityEngine.KeyCode value, string name)
		{
			global::UnityEngine.KeyCode? keyCode = global::GameInput.GameButton.ParseKeyCode(name);
			value = ((keyCode == null) ? value : keyCode.Value);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00010E2C File Offset: 0x0000F02C
		public void Bind(string A, string B)
		{
			global::GameInput.GameButton.SetKeyCode(ref this.bindingOne, A);
			global::GameInput.GameButton.SetKeyCode(ref this.bindingTwo, B);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00010E48 File Offset: 0x0000F048
		public bool IsDown()
		{
			return global::GameInput.GameButton.IsKeyHeld(this.bindingOne) || (this.bindingOne != this.bindingTwo && global::GameInput.GameButton.IsKeyHeld(this.bindingTwo));
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00010E88 File Offset: 0x0000F088
		public bool IsPressed()
		{
			if (global::GameInput.GameButton.WasKeyPressed(this.bindingOne))
			{
				return this.bindingTwo == this.bindingOne || global::GameInput.GameButton.WasKeyPressed(this.bindingTwo) || !global::GameInput.GameButton.IsKeyHeld(this.bindingTwo);
			}
			return this.bindingTwo != this.bindingOne && global::GameInput.GameButton.WasKeyPressed(this.bindingTwo) && !global::GameInput.GameButton.IsKeyHeld(this.bindingOne);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00010F0C File Offset: 0x0000F10C
		public bool IsReleased()
		{
			if (global::GameInput.GameButton.WasKeyReleased(this.bindingOne))
			{
				return this.bindingTwo == this.bindingOne || global::GameInput.GameButton.WasKeyReleased(this.bindingTwo) || !global::GameInput.GameButton.IsKeyHeld(this.bindingTwo);
			}
			return this.bindingTwo != this.bindingOne && global::GameInput.GameButton.WasKeyReleased(this.bindingTwo) && !global::GameInput.GameButton.IsKeyHeld(this.bindingOne);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00010F90 File Offset: 0x0000F190
		public override string ToString()
		{
			return this.Name ?? string.Empty;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00010FA4 File Offset: 0x0000F1A4
		public static bool operator true(global::GameInput.GameButton gameButton)
		{
			return !object.ReferenceEquals(gameButton, null) && gameButton.IsDown();
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00010FBC File Offset: 0x0000F1BC
		public static bool operator false(global::GameInput.GameButton gameButton)
		{
			return !object.ReferenceEquals(gameButton, null) && !gameButton.IsDown();
		}

		// Token: 0x04000313 RID: 787
		public readonly string Name;

		// Token: 0x04000314 RID: 788
		public global::UnityEngine.KeyCode bindingOne;

		// Token: 0x04000315 RID: 789
		public global::UnityEngine.KeyCode bindingTwo;
	}
}

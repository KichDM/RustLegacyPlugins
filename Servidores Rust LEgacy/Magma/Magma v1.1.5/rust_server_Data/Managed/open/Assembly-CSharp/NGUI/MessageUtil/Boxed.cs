using System;
using UnityEngine;

namespace NGUI.MessageUtil
{
	// Token: 0x0200093F RID: 2367
	public static class Boxed
	{
		// Token: 0x06005087 RID: 20615 RVA: 0x0013A974 File Offset: 0x00138B74
		// Note: this type is marked as 'beforefieldinit'.
		static Boxed()
		{
		}

		// Token: 0x06005088 RID: 20616 RVA: 0x0013AA18 File Offset: 0x00138C18
		public static object Box(bool b)
		{
			return (!b) ? global::NGUI.MessageUtil.Boxed.@false : global::NGUI.MessageUtil.Boxed.@true;
		}

		// Token: 0x06005089 RID: 20617 RVA: 0x0013AA30 File Offset: 0x00138C30
		public static object Box(int i)
		{
			switch (i)
			{
			case 0:
				return global::NGUI.MessageUtil.Boxed.int_0;
			case 1:
				return global::NGUI.MessageUtil.Boxed.int_1;
			case 2:
				return global::NGUI.MessageUtil.Boxed.int_2;
			default:
				return i;
			}
		}

		// Token: 0x0600508A RID: 20618 RVA: 0x0013AA70 File Offset: 0x00138C70
		public static object Box<T>(T o)
		{
			return o;
		}

		// Token: 0x0600508B RID: 20619 RVA: 0x0013AA78 File Offset: 0x00138C78
		public static object Box(global::UnityEngine.KeyCode k)
		{
			switch (k)
			{
			case 0x111:
				return global::NGUI.MessageUtil.Boxed.key_up;
			case 0x112:
				return global::NGUI.MessageUtil.Boxed.key_down;
			case 0x113:
				return global::NGUI.MessageUtil.Boxed.key_right;
			case 0x114:
				return global::NGUI.MessageUtil.Boxed.key_left;
			default:
				if (k == null)
				{
					return global::NGUI.MessageUtil.Boxed.key_none;
				}
				if (k == 9)
				{
					return global::NGUI.MessageUtil.Boxed.key_tab;
				}
				if (k != 0x1B)
				{
					return k;
				}
				return global::NGUI.MessageUtil.Boxed.key_escape;
			}
		}

		// Token: 0x04002D41 RID: 11585
		public static readonly object @true = true;

		// Token: 0x04002D42 RID: 11586
		public static readonly object @false = false;

		// Token: 0x04002D43 RID: 11587
		public static readonly object int_0 = 0;

		// Token: 0x04002D44 RID: 11588
		public static readonly object int_1 = 1;

		// Token: 0x04002D45 RID: 11589
		public static readonly object int_2 = 2;

		// Token: 0x04002D46 RID: 11590
		public static readonly object key_escape = 0x1B;

		// Token: 0x04002D47 RID: 11591
		public static readonly object key_left = 0x114;

		// Token: 0x04002D48 RID: 11592
		public static readonly object key_right = 0x113;

		// Token: 0x04002D49 RID: 11593
		public static readonly object key_up = 0x111;

		// Token: 0x04002D4A RID: 11594
		public static readonly object key_down = 0x112;

		// Token: 0x04002D4B RID: 11595
		public static readonly object key_tab = 9;

		// Token: 0x04002D4C RID: 11596
		public static readonly object key_none = 0;
	}
}

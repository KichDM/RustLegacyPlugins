using System;
using UnityEngine;

namespace NGUI.MessageUtil
{
	// Token: 0x02000940 RID: 2368
	public static class Util
	{
		// Token: 0x0600508C RID: 20620 RVA: 0x0013AAF0 File Offset: 0x00138CF0
		public static void Select(this global::UnityEngine.GameObject recv, bool selected)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnSelect", global::NGUI.MessageUtil.Boxed.Box(selected), true);
		}

		// Token: 0x0600508D RID: 20621 RVA: 0x0013AB04 File Offset: 0x00138D04
		public static void Press(this global::UnityEngine.GameObject recv, bool press)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnPress", global::NGUI.MessageUtil.Boxed.Box(press), true);
		}

		// Token: 0x0600508E RID: 20622 RVA: 0x0013AB18 File Offset: 0x00138D18
		public static void Hover(this global::UnityEngine.GameObject recv, bool highlight)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnHover", global::NGUI.MessageUtil.Boxed.Box(highlight), true);
		}

		// Token: 0x0600508F RID: 20623 RVA: 0x0013AB2C File Offset: 0x00138D2C
		public static void Tooltip(this global::UnityEngine.GameObject recv, bool show)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnTooltip", global::NGUI.MessageUtil.Boxed.Box(show), true);
		}

		// Token: 0x06005090 RID: 20624 RVA: 0x0013AB40 File Offset: 0x00138D40
		public static void Key(this global::UnityEngine.GameObject recv, global::UnityEngine.KeyCode key)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnKey", global::NGUI.MessageUtil.Boxed.Box(key), true);
		}

		// Token: 0x06005091 RID: 20625 RVA: 0x0013AB54 File Offset: 0x00138D54
		public static void Drop(this global::UnityEngine.GameObject recv, global::UnityEngine.GameObject obj)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnDrop", global::NGUI.MessageUtil.Boxed.Box<global::UnityEngine.GameObject>(obj), true);
		}

		// Token: 0x06005092 RID: 20626 RVA: 0x0013AB68 File Offset: 0x00138D68
		public static void Drag(this global::UnityEngine.GameObject recv, global::UnityEngine.Vector2 delta)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnDrag", global::NGUI.MessageUtil.Boxed.Box<global::UnityEngine.Vector2>(delta), true);
		}

		// Token: 0x06005093 RID: 20627 RVA: 0x0013AB7C File Offset: 0x00138D7C
		public static void Scroll(this global::UnityEngine.GameObject recv, float y)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnScroll", global::NGUI.MessageUtil.Boxed.Box<float>(y), true);
		}

		// Token: 0x06005094 RID: 20628 RVA: 0x0013AB90 File Offset: 0x00138D90
		public static void ScrollX(this global::UnityEngine.GameObject recv, float x)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnScrollX", global::NGUI.MessageUtil.Boxed.Box<float>(x), true);
		}

		// Token: 0x06005095 RID: 20629 RVA: 0x0013ABA4 File Offset: 0x00138DA4
		public static void Input(this global::UnityEngine.GameObject recv, string input)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnInput", global::NGUI.MessageUtil.Boxed.Box<string>(input), true);
		}

		// Token: 0x06005096 RID: 20630 RVA: 0x0013ABB8 File Offset: 0x00138DB8
		public static void Click(this global::UnityEngine.GameObject recv)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnClick", null, false);
		}

		// Token: 0x06005097 RID: 20631 RVA: 0x0013ABC8 File Offset: 0x00138DC8
		public static void DoubleClick(this global::UnityEngine.GameObject recv)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnDoubleClick", null, false);
		}

		// Token: 0x06005098 RID: 20632 RVA: 0x0013ABD8 File Offset: 0x00138DD8
		public static void DragState(this global::UnityEngine.GameObject recv, bool dragging)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnDragState", global::NGUI.MessageUtil.Boxed.Box(dragging), true);
		}

		// Token: 0x06005099 RID: 20633 RVA: 0x0013ABEC File Offset: 0x00138DEC
		public static void AltPress(this global::UnityEngine.GameObject recv, bool press)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnAltPress", global::NGUI.MessageUtil.Boxed.Box(press), true);
		}

		// Token: 0x0600509A RID: 20634 RVA: 0x0013AC00 File Offset: 0x00138E00
		public static void AltClick(this global::UnityEngine.GameObject recv)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnAltClick", null, false);
		}

		// Token: 0x0600509B RID: 20635 RVA: 0x0013AC10 File Offset: 0x00138E10
		public static void AltDoubleClick(this global::UnityEngine.GameObject recv)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnAltDoubleClick", null, false);
		}

		// Token: 0x0600509C RID: 20636 RVA: 0x0013AC20 File Offset: 0x00138E20
		public static void MidPress(this global::UnityEngine.GameObject recv, bool press)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnMidPress", global::NGUI.MessageUtil.Boxed.Box(press), true);
		}

		// Token: 0x0600509D RID: 20637 RVA: 0x0013AC34 File Offset: 0x00138E34
		public static void MidClick(this global::UnityEngine.GameObject recv)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnMidClick", null, false);
		}

		// Token: 0x0600509E RID: 20638 RVA: 0x0013AC44 File Offset: 0x00138E44
		public static void MidDoubleClick(this global::UnityEngine.GameObject recv)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, "OnMidDoubleClick", null, false);
		}

		// Token: 0x0600509F RID: 20639 RVA: 0x0013AC54 File Offset: 0x00138E54
		public static void NGUIMessage(this global::UnityEngine.GameObject recv, string message)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, message, null, false);
		}

		// Token: 0x060050A0 RID: 20640 RVA: 0x0013AC60 File Offset: 0x00138E60
		public static void NGUIMessage(this global::UnityEngine.GameObject recv, string message, bool value)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, message, global::NGUI.MessageUtil.Boxed.Box(value), true);
		}

		// Token: 0x060050A1 RID: 20641 RVA: 0x0013AC70 File Offset: 0x00138E70
		public static void NGUIMessage(this global::UnityEngine.GameObject recv, string message, int value)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, message, global::NGUI.MessageUtil.Boxed.Box(value), true);
		}

		// Token: 0x060050A2 RID: 20642 RVA: 0x0013AC80 File Offset: 0x00138E80
		public static void NGUIMessage(this global::UnityEngine.GameObject recv, string message, global::UnityEngine.KeyCode value)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, message, global::NGUI.MessageUtil.Boxed.Box(value), true);
		}

		// Token: 0x060050A3 RID: 20643 RVA: 0x0013AC90 File Offset: 0x00138E90
		public static void NGUIMessage(this global::UnityEngine.GameObject recv, string message, global::UnityEngine.GameObject value)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, message, global::NGUI.MessageUtil.Boxed.Box<global::UnityEngine.GameObject>(value), true);
		}

		// Token: 0x060050A4 RID: 20644 RVA: 0x0013ACA0 File Offset: 0x00138EA0
		public static void NGUIMessage(this global::UnityEngine.GameObject recv, string message, object value)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, message, value, true);
		}

		// Token: 0x060050A5 RID: 20645 RVA: 0x0013ACAC File Offset: 0x00138EAC
		public static void NGUIMessage<T>(this global::UnityEngine.GameObject recv, string message, T value)
		{
			global::NGUI.MessageUtil.Util.MSG(recv, message, global::NGUI.MessageUtil.Boxed.Box<T>(value), true);
		}

		// Token: 0x060050A6 RID: 20646 RVA: 0x0013ACBC File Offset: 0x00138EBC
		private static void MSG(global::UnityEngine.GameObject recv, string message, object value, bool withValue)
		{
			if (recv)
			{
				if (withValue)
				{
					if (object.ReferenceEquals(value, null))
					{
						global::UnityEngine.Debug.LogWarning(string.Format("((GameObject){2}).SendMessage(\"{0}\", SendMessageOptions.{1}, null ) was not called because of the null argument.", message, 1, recv), recv);
					}
					else
					{
						try
						{
							recv.SendMessage(message, value, 1);
						}
						catch (global::System.Exception ex)
						{
							global::UnityEngine.Debug.LogError(string.Format("((GameObject){2}).SendMessage(\"{0}\", {4}({5}), SendMessageOptions.{1}) threw the exception below\r\n{3}", new object[]
							{
								message,
								1,
								recv,
								ex,
								value,
								value.GetType()
							}), recv);
						}
					}
				}
				else
				{
					try
					{
						recv.SendMessage(message, 1);
					}
					catch (global::System.Exception ex2)
					{
						global::UnityEngine.Debug.LogError(string.Format("((GameObject){2}).SendMessage(\"{0}\", SendMessageOptions.{1}) threw the exception below\r\n{3}", new object[]
						{
							message,
							1,
							recv,
							ex2
						}), recv);
					}
				}
			}
			else if (!withValue)
			{
				global::UnityEngine.Debug.LogWarning(string.Format("((GameObject)null).SendMessage(\"{0}\", SendMessageOptions.{1})", message, 1));
			}
			else
			{
				global::UnityEngine.Debug.LogWarning(string.Format("((GameObject)null).SendMessage(\"{0}\", {1}, SendMessageOptions.{2})", message, value, 1));
			}
		}
	}
}

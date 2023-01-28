using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000532 RID: 1330
public class RPOSBumper : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002D2E RID: 11566 RVA: 0x000AB428 File Offset: 0x000A9628
	public RPOSBumper()
	{
	}

	// Token: 0x06002D2F RID: 11567 RVA: 0x000AB430 File Offset: 0x000A9630
	private void Clear()
	{
		if (this.instances != null)
		{
			foreach (global::RPOSBumper.Instance instance in this.instances)
			{
				if (instance.window)
				{
					instance.window.RemoveBumper(instance);
				}
			}
			this.instances.Clear();
		}
	}

	// Token: 0x06002D30 RID: 11568 RVA: 0x000AB4C4 File Offset: 0x000A96C4
	private void OnDestroy()
	{
		this.Clear();
	}

	// Token: 0x06002D31 RID: 11569 RVA: 0x000AB4CC File Offset: 0x000A96CC
	public void Populate()
	{
		this.Clear();
		global::System.Collections.Generic.List<global::RPOSWindow> list = new global::System.Collections.Generic.List<global::RPOSWindow>(global::RPOS.GetBumperWindowList());
		int num = list.Count;
		for (int i = 0; i < num; i++)
		{
			if (list[i] && !string.IsNullOrEmpty(list[i].title))
			{
				list[i].EnsureAwake<global::RPOSWindow>();
			}
			else
			{
				list.RemoveAt(i--);
				num--;
			}
		}
		float num2 = 75f * this.buttonPrefab.gameObject.transform.localScale.x;
		float num3 = 5f;
		float num4 = (float)num * num2 * -0.5f;
		int num5 = 0;
		if (this.instances == null)
		{
			this.instances = new global::System.Collections.Generic.HashSet<global::RPOSBumper.Instance>();
		}
		foreach (global::RPOSWindow rposwindow in list)
		{
			global::RPOSBumper.Instance instance = new global::RPOSBumper.Instance();
			instance.window = rposwindow;
			global::UnityEngine.Vector3 localScale = this.buttonPrefab.gameObject.transform.localScale;
			global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(base.gameObject, this.buttonPrefab.gameObject);
			instance.label = gameObject.gameObject.GetComponentInChildren<global::UILabel>();
			instance.label.name = rposwindow.title + "BumperButton";
			global::UnityEngine.Vector3 localPosition = gameObject.transform.localPosition;
			localPosition.x = num4 + (num2 + num3) * (float)num5;
			gameObject.transform.localPosition = localPosition;
			gameObject.transform.localScale = localScale;
			instance.button = gameObject.GetComponentInChildren<global::UIButton>();
			instance.bumper = this;
			rposwindow.AddBumper(instance);
			this.instances.Add(instance);
			num5++;
		}
		global::UnityEngine.Vector3 localScale2 = this.background.transform.localScale;
		localScale2.x = (float)num * num2 + ((float)num - 1f * num3);
		this.background.gameObject.transform.localScale = localScale2;
		this.background.gameObject.transform.localPosition = new global::UnityEngine.Vector3(localScale2.x * -0.5f, base.transform.localPosition.y, 0f);
	}

	// Token: 0x04001731 RID: 5937
	public global::UISlicedSprite background;

	// Token: 0x04001732 RID: 5938
	public global::UIButton buttonPrefab;

	// Token: 0x04001733 RID: 5939
	private global::System.Collections.Generic.HashSet<global::RPOSBumper.Instance> instances;

	// Token: 0x02000533 RID: 1331
	public class Instance
	{
		// Token: 0x06002D32 RID: 11570 RVA: 0x000AB74C File Offset: 0x000A994C
		public Instance()
		{
		}

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x06002D33 RID: 11571 RVA: 0x000AB754 File Offset: 0x000A9954
		public global::UIEventListener listener
		{
			get
			{
				if (!this.onceGetListener)
				{
					this.onceGetListener = true;
					if (this.button)
					{
						this._listener = global::UIEventListener.Get(this.button.gameObject);
					}
				}
				return this._listener;
			}
		}

		// Token: 0x04001734 RID: 5940
		public global::RPOSBumper bumper;

		// Token: 0x04001735 RID: 5941
		public global::UIButton button;

		// Token: 0x04001736 RID: 5942
		public global::UILabel label;

		// Token: 0x04001737 RID: 5943
		public global::RPOSWindow window;

		// Token: 0x04001738 RID: 5944
		private global::UIEventListener _listener;

		// Token: 0x04001739 RID: 5945
		private bool onceGetListener;
	}
}

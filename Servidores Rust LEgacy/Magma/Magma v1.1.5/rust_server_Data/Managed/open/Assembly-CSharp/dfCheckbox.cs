using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020007D8 RID: 2008
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Checkbox")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfCheckbox : global::dfControl
{
	// Token: 0x06004296 RID: 17046 RVA: 0x000F1F1C File Offset: 0x000F011C
	public dfCheckbox()
	{
	}

	// Token: 0x14000021 RID: 33
	// (add) Token: 0x06004297 RID: 17047 RVA: 0x000F1F24 File Offset: 0x000F0124
	// (remove) Token: 0x06004298 RID: 17048 RVA: 0x000F1F40 File Offset: 0x000F0140
	public event global::PropertyChangedEventHandler<bool> CheckChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.CheckChanged = (global::PropertyChangedEventHandler<bool>)global::System.Delegate.Combine(this.CheckChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.CheckChanged = (global::PropertyChangedEventHandler<bool>)global::System.Delegate.Remove(this.CheckChanged, value);
		}
	}

	// Token: 0x17000C46 RID: 3142
	// (get) Token: 0x06004299 RID: 17049 RVA: 0x000F1F5C File Offset: 0x000F015C
	// (set) Token: 0x0600429A RID: 17050 RVA: 0x000F1F64 File Offset: 0x000F0164
	public bool IsChecked
	{
		get
		{
			return this.isChecked;
		}
		set
		{
			if (value != this.isChecked)
			{
				this.isChecked = value;
				this.OnCheckChanged();
			}
		}
	}

	// Token: 0x17000C47 RID: 3143
	// (get) Token: 0x0600429B RID: 17051 RVA: 0x000F1F80 File Offset: 0x000F0180
	// (set) Token: 0x0600429C RID: 17052 RVA: 0x000F1F88 File Offset: 0x000F0188
	public global::dfControl CheckIcon
	{
		get
		{
			return this.checkIcon;
		}
		set
		{
			if (value != this.checkIcon)
			{
				this.checkIcon = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C48 RID: 3144
	// (get) Token: 0x0600429D RID: 17053 RVA: 0x000F1FA8 File Offset: 0x000F01A8
	// (set) Token: 0x0600429E RID: 17054 RVA: 0x000F1FB0 File Offset: 0x000F01B0
	public global::dfLabel Label
	{
		get
		{
			return this.label;
		}
		set
		{
			if (value != this.label)
			{
				this.label = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C49 RID: 3145
	// (get) Token: 0x0600429F RID: 17055 RVA: 0x000F1FD0 File Offset: 0x000F01D0
	// (set) Token: 0x060042A0 RID: 17056 RVA: 0x000F1FD8 File Offset: 0x000F01D8
	public global::dfControl GroupContainer
	{
		get
		{
			return this.group;
		}
		set
		{
			if (value != this.group)
			{
				this.group = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000C4A RID: 3146
	// (get) Token: 0x060042A1 RID: 17057 RVA: 0x000F1FF8 File Offset: 0x000F01F8
	// (set) Token: 0x060042A2 RID: 17058 RVA: 0x000F2028 File Offset: 0x000F0228
	public string Text
	{
		get
		{
			if (this.label != null)
			{
				return this.label.Text;
			}
			return "[LABEL NOT SET]";
		}
		set
		{
			if (this.label != null)
			{
				this.label.Text = value;
			}
		}
	}

	// Token: 0x17000C4B RID: 3147
	// (get) Token: 0x060042A3 RID: 17059 RVA: 0x000F2048 File Offset: 0x000F0248
	public override bool CanFocus
	{
		get
		{
			return base.IsEnabled && base.IsVisible;
		}
	}

	// Token: 0x060042A4 RID: 17060 RVA: 0x000F2060 File Offset: 0x000F0260
	public override void Start()
	{
		base.Start();
		if (this.checkIcon != null)
		{
			this.checkIcon.BringToFront();
			this.checkIcon.IsVisible = this.IsChecked;
		}
	}

	// Token: 0x060042A5 RID: 17061 RVA: 0x000F20A0 File Offset: 0x000F02A0
	protected internal override void OnKeyPress(global::dfKeyEventArgs args)
	{
		if (args.KeyCode == 0x20)
		{
			this.OnClick(new global::dfMouseEventArgs(this, global::dfMouseButtons.Left, 1, default(global::UnityEngine.Ray), global::UnityEngine.Vector2.zero, 0f));
			return;
		}
		base.OnKeyPress(args);
	}

	// Token: 0x060042A6 RID: 17062 RVA: 0x000F20E4 File Offset: 0x000F02E4
	protected internal override void OnClick(global::dfMouseEventArgs args)
	{
		if (this.group == null)
		{
			this.IsChecked = !this.IsChecked;
		}
		else
		{
			foreach (global::dfCheckbox dfCheckbox in base.transform.parent.GetComponentsInChildren<global::dfCheckbox>())
			{
				if (dfCheckbox != this && dfCheckbox.GroupContainer == this.GroupContainer && dfCheckbox.IsChecked)
				{
					dfCheckbox.IsChecked = false;
				}
			}
			this.IsChecked = true;
		}
		args.Use();
		base.OnClick(args);
	}

	// Token: 0x060042A7 RID: 17063 RVA: 0x000F2188 File Offset: 0x000F0388
	protected internal void OnCheckChanged()
	{
		base.SignalHierarchy("OnCheckChanged", new object[]
		{
			this.isChecked
		});
		if (this.CheckChanged != null)
		{
			this.CheckChanged(this, this.isChecked);
		}
		if (this.checkIcon != null)
		{
			if (this.IsChecked)
			{
				this.checkIcon.BringToFront();
			}
			this.checkIcon.IsVisible = this.IsChecked;
		}
	}

	// Token: 0x04002396 RID: 9110
	[global::UnityEngine.SerializeField]
	protected bool isChecked;

	// Token: 0x04002397 RID: 9111
	[global::UnityEngine.SerializeField]
	protected global::dfControl checkIcon;

	// Token: 0x04002398 RID: 9112
	[global::UnityEngine.SerializeField]
	protected global::dfLabel label;

	// Token: 0x04002399 RID: 9113
	[global::UnityEngine.SerializeField]
	protected global::dfControl group;

	// Token: 0x0400239A RID: 9114
	private global::PropertyChangedEventHandler<bool> CheckChanged;
}

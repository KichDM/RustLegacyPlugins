using System;
using System.Reflection;
using UnityEngine;

// Token: 0x02000849 RID: 2121
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Data Binding/Key Binding")]
public class dfControlKeyBinding : global::UnityEngine.MonoBehaviour, global::IDataBindingComponent
{
	// Token: 0x06004954 RID: 18772 RVA: 0x001126D8 File Offset: 0x001108D8
	public dfControlKeyBinding()
	{
	}

	// Token: 0x17000DC6 RID: 3526
	// (get) Token: 0x06004955 RID: 18773 RVA: 0x001126E0 File Offset: 0x001108E0
	// (set) Token: 0x06004956 RID: 18774 RVA: 0x001126E8 File Offset: 0x001108E8
	public global::dfControl Control
	{
		get
		{
			return this.control;
		}
		set
		{
			if (this.isBound)
			{
				this.Unbind();
			}
			this.control = value;
		}
	}

	// Token: 0x17000DC7 RID: 3527
	// (get) Token: 0x06004957 RID: 18775 RVA: 0x00112704 File Offset: 0x00110904
	// (set) Token: 0x06004958 RID: 18776 RVA: 0x0011270C File Offset: 0x0011090C
	public global::UnityEngine.KeyCode KeyCode
	{
		get
		{
			return this.keyCode;
		}
		set
		{
			this.keyCode = value;
		}
	}

	// Token: 0x17000DC8 RID: 3528
	// (get) Token: 0x06004959 RID: 18777 RVA: 0x00112718 File Offset: 0x00110918
	// (set) Token: 0x0600495A RID: 18778 RVA: 0x00112720 File Offset: 0x00110920
	public bool AltPressed
	{
		get
		{
			return this.altPressed;
		}
		set
		{
			this.altPressed = value;
		}
	}

	// Token: 0x17000DC9 RID: 3529
	// (get) Token: 0x0600495B RID: 18779 RVA: 0x0011272C File Offset: 0x0011092C
	// (set) Token: 0x0600495C RID: 18780 RVA: 0x00112734 File Offset: 0x00110934
	public bool ControlPressed
	{
		get
		{
			return this.controlPressed;
		}
		set
		{
			this.controlPressed = value;
		}
	}

	// Token: 0x17000DCA RID: 3530
	// (get) Token: 0x0600495D RID: 18781 RVA: 0x00112740 File Offset: 0x00110940
	// (set) Token: 0x0600495E RID: 18782 RVA: 0x00112748 File Offset: 0x00110948
	public bool ShiftPressed
	{
		get
		{
			return this.shiftPressed;
		}
		set
		{
			this.shiftPressed = value;
		}
	}

	// Token: 0x17000DCB RID: 3531
	// (get) Token: 0x0600495F RID: 18783 RVA: 0x00112754 File Offset: 0x00110954
	// (set) Token: 0x06004960 RID: 18784 RVA: 0x0011275C File Offset: 0x0011095C
	public global::dfComponentMemberInfo Target
	{
		get
		{
			return this.target;
		}
		set
		{
			if (this.isBound)
			{
				this.Unbind();
			}
			this.target = value;
		}
	}

	// Token: 0x06004961 RID: 18785 RVA: 0x00112778 File Offset: 0x00110978
	public void Awake()
	{
	}

	// Token: 0x06004962 RID: 18786 RVA: 0x0011277C File Offset: 0x0011097C
	public void OnEnable()
	{
	}

	// Token: 0x06004963 RID: 18787 RVA: 0x00112780 File Offset: 0x00110980
	public void Start()
	{
		if (this.control != null && this.target.IsValid)
		{
			this.Bind();
		}
	}

	// Token: 0x06004964 RID: 18788 RVA: 0x001127AC File Offset: 0x001109AC
	public void Bind()
	{
		if (this.isBound)
		{
			this.Unbind();
		}
		if (this.control != null)
		{
			this.control.KeyDown += this.eventSource_KeyDown;
		}
		this.isBound = true;
	}

	// Token: 0x06004965 RID: 18789 RVA: 0x001127FC File Offset: 0x001109FC
	public void Unbind()
	{
		if (this.control != null)
		{
			this.control.KeyDown -= this.eventSource_KeyDown;
		}
		this.isBound = false;
	}

	// Token: 0x06004966 RID: 18790 RVA: 0x00112830 File Offset: 0x00110A30
	private void eventSource_KeyDown(global::dfControl control, global::dfKeyEventArgs args)
	{
		if (args.KeyCode != this.keyCode)
		{
			return;
		}
		if (args.Shift != this.shiftPressed || args.Control != this.controlPressed || args.Alt != this.altPressed)
		{
			return;
		}
		global::System.Reflection.MethodInfo method = this.target.GetMethod();
		method.Invoke(this.target.Component, null);
	}

	// Token: 0x04002717 RID: 10007
	[global::UnityEngine.SerializeField]
	protected global::dfControl control;

	// Token: 0x04002718 RID: 10008
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.KeyCode keyCode;

	// Token: 0x04002719 RID: 10009
	[global::UnityEngine.SerializeField]
	protected bool shiftPressed;

	// Token: 0x0400271A RID: 10010
	[global::UnityEngine.SerializeField]
	protected bool altPressed;

	// Token: 0x0400271B RID: 10011
	[global::UnityEngine.SerializeField]
	protected bool controlPressed;

	// Token: 0x0400271C RID: 10012
	[global::UnityEngine.SerializeField]
	protected global::dfComponentMemberInfo target;

	// Token: 0x0400271D RID: 10013
	private bool isBound;
}

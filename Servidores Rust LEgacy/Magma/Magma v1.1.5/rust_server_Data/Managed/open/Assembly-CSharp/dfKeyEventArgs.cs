using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020007FB RID: 2043
public class dfKeyEventArgs : global::dfControlEventArgs
{
	// Token: 0x0600443B RID: 17467 RVA: 0x000F9544 File Offset: 0x000F7744
	internal dfKeyEventArgs(global::dfControl source, global::UnityEngine.KeyCode Key, bool Control, bool Shift, bool Alt) : base(source)
	{
		this.KeyCode = Key;
		this.Control = Control;
		this.Shift = Shift;
		this.Alt = Alt;
	}

	// Token: 0x17000C91 RID: 3217
	// (get) Token: 0x0600443C RID: 17468 RVA: 0x000F9578 File Offset: 0x000F7778
	// (set) Token: 0x0600443D RID: 17469 RVA: 0x000F9580 File Offset: 0x000F7780
	public global::UnityEngine.KeyCode KeyCode
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<KeyCode>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<KeyCode>k__BackingField = value;
		}
	}

	// Token: 0x17000C92 RID: 3218
	// (get) Token: 0x0600443E RID: 17470 RVA: 0x000F958C File Offset: 0x000F778C
	// (set) Token: 0x0600443F RID: 17471 RVA: 0x000F9594 File Offset: 0x000F7794
	public char Character
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Character>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Character>k__BackingField = value;
		}
	}

	// Token: 0x17000C93 RID: 3219
	// (get) Token: 0x06004440 RID: 17472 RVA: 0x000F95A0 File Offset: 0x000F77A0
	// (set) Token: 0x06004441 RID: 17473 RVA: 0x000F95A8 File Offset: 0x000F77A8
	public bool Control
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Control>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Control>k__BackingField = value;
		}
	}

	// Token: 0x17000C94 RID: 3220
	// (get) Token: 0x06004442 RID: 17474 RVA: 0x000F95B4 File Offset: 0x000F77B4
	// (set) Token: 0x06004443 RID: 17475 RVA: 0x000F95BC File Offset: 0x000F77BC
	public bool Shift
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Shift>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Shift>k__BackingField = value;
		}
	}

	// Token: 0x17000C95 RID: 3221
	// (get) Token: 0x06004444 RID: 17476 RVA: 0x000F95C8 File Offset: 0x000F77C8
	// (set) Token: 0x06004445 RID: 17477 RVA: 0x000F95D0 File Offset: 0x000F77D0
	public bool Alt
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Alt>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Alt>k__BackingField = value;
		}
	}

	// Token: 0x06004446 RID: 17478 RVA: 0x000F95DC File Offset: 0x000F77DC
	public override string ToString()
	{
		return string.Format("Key: {0}, Control: {1}, Shift: {2}, Alt: {3}", new object[]
		{
			this.KeyCode,
			this.Control,
			this.Shift,
			this.Alt
		});
	}

	// Token: 0x04002467 RID: 9319
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.KeyCode <KeyCode>k__BackingField;

	// Token: 0x04002468 RID: 9320
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private char <Character>k__BackingField;

	// Token: 0x04002469 RID: 9321
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <Control>k__BackingField;

	// Token: 0x0400246A RID: 9322
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <Shift>k__BackingField;

	// Token: 0x0400246B RID: 9323
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <Alt>k__BackingField;
}

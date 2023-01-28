using System;
using System.Runtime.Serialization;
using UnityEngine;

// Token: 0x0200017A RID: 378
public abstract class IDLocalCharacterAddon : global::IDLocalCharacter
{
	// Token: 0x06000B1E RID: 2846 RVA: 0x0002B388 File Offset: 0x00029588
	protected IDLocalCharacterAddon(global::IDLocalCharacterAddon.AddonFlags addonFlags)
	{
		this.addonFlags = addonFlags;
	}

	// Token: 0x06000B1F RID: 2847 RVA: 0x0002B398 File Offset: 0x00029598
	protected virtual bool CheckPrerequesits()
	{
		throw new global::IDLocalCharacterAddon.BaseNoImplementationCalled("You should not call base.CheckPrerequesits. or define AddonFlags you do not use.");
	}

	// Token: 0x06000B20 RID: 2848 RVA: 0x0002B3A4 File Offset: 0x000295A4
	protected virtual void OnAddonAwake()
	{
		throw new global::IDLocalCharacterAddon.BaseNoImplementationCalled("You should not call base.OnAddonAwake. or define AddonFlags you do not use.");
	}

	// Token: 0x06000B21 RID: 2849 RVA: 0x0002B3B0 File Offset: 0x000295B0
	protected virtual void OnAddonPostAwake()
	{
		throw new global::IDLocalCharacterAddon.BaseNoImplementationCalled("You should not call base.OnAddonPostAwake. or define AddonFlags you do not use.");
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x0002B3BC File Offset: 0x000295BC
	protected virtual void OnWillRemoveAddon()
	{
		throw new global::IDLocalCharacterAddon.BaseNoImplementationCalled("You should not call base.OnWillRemoveAddon. or define AddonFlags you do not use.");
	}

	// Token: 0x06000B23 RID: 2851 RVA: 0x0002B3C8 File Offset: 0x000295C8
	internal byte InitializeAddon(global::Character idMain)
	{
		if (this.addonWasAdded)
		{
			return 0;
		}
		this.idMain = idMain;
		this.addonWasAdded = true;
		byte b = 0;
		if ((byte)(this.addonFlags & global::IDLocalCharacterAddon.AddonFlags.PrerequisitCheck) == 4)
		{
			try
			{
				if (!this.CheckPrerequesits())
				{
					b |= 8;
				}
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogError(ex, this);
				if (!(ex is global::IDLocalCharacterAddon.BaseNoImplementationCalled))
				{
					b |= 8;
				}
			}
		}
		if ((b & 8) == 8)
		{
			global::UnityEngine.Object.Destroy(this);
			return b;
		}
		if ((byte)(this.addonFlags & global::IDLocalCharacterAddon.AddonFlags.FireOnAddonPostAwake) == 2)
		{
			b |= 2;
		}
		if ((byte)(this.addonFlags & global::IDLocalCharacterAddon.AddonFlags.FireOnAddonAwake) == 1)
		{
			try
			{
				this.OnAddonAwake();
			}
			catch (global::System.Exception ex2)
			{
				global::UnityEngine.Debug.Log(ex2, this);
			}
		}
		return b;
	}

	// Token: 0x06000B24 RID: 2852 RVA: 0x0002B4B4 File Offset: 0x000296B4
	internal void PostInitializeAddon()
	{
		try
		{
			this.OnAddonPostAwake();
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.Log(ex, this);
		}
	}

	// Token: 0x06000B25 RID: 2853 RVA: 0x0002B4F8 File Offset: 0x000296F8
	internal void RemoveAddon()
	{
		if (!this.removingThisAddon)
		{
			this.removingThisAddon = true;
			if ((byte)(this.addonFlags & global::IDLocalCharacterAddon.AddonFlags.FireOnWillRemoveAddon) == 8)
			{
				try
				{
					this.OnWillRemoveAddon();
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex, this);
				}
			}
			global::UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x04000793 RID: 1939
	internal const byte kInitializeAddonFlag_PostAwake = 2;

	// Token: 0x04000794 RID: 1940
	internal const byte kInitializeAddonFlag_Failed = 8;

	// Token: 0x04000795 RID: 1941
	[global::System.NonSerialized]
	private bool addonWasAdded;

	// Token: 0x04000796 RID: 1942
	[global::System.NonSerialized]
	private bool removingThisAddon;

	// Token: 0x04000797 RID: 1943
	private readonly global::IDLocalCharacterAddon.AddonFlags addonFlags;

	// Token: 0x0200017B RID: 379
	[global::System.Flags]
	protected internal enum AddonFlags : byte
	{
		// Token: 0x04000799 RID: 1945
		FireOnAddonAwake = 1,
		// Token: 0x0400079A RID: 1946
		FireOnAddonPostAwake = 2,
		// Token: 0x0400079B RID: 1947
		PrerequisitCheck = 4,
		// Token: 0x0400079C RID: 1948
		FireOnWillRemoveAddon = 8
	}

	// Token: 0x0200017C RID: 380
	[global::System.Serializable]
	private class BaseNoImplementationCalled : global::System.NotSupportedException
	{
		// Token: 0x06000B26 RID: 2854 RVA: 0x0002B560 File Offset: 0x00029760
		public BaseNoImplementationCalled()
		{
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0002B568 File Offset: 0x00029768
		public BaseNoImplementationCalled(string message) : base(message)
		{
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0002B574 File Offset: 0x00029774
		public BaseNoImplementationCalled(string message, global::System.Exception inner) : base(message, inner)
		{
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0002B580 File Offset: 0x00029780
		protected BaseNoImplementationCalled(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{
		}
	}
}

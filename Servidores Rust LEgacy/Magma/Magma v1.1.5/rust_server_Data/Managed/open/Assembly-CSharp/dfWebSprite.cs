using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000844 RID: 2116
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Sprite/Web")]
[global::UnityEngine.ExecuteInEditMode]
public class dfWebSprite : global::dfTextureSprite
{
	// Token: 0x0600493B RID: 18747 RVA: 0x001121BC File Offset: 0x001103BC
	public dfWebSprite()
	{
	}

	// Token: 0x17000DBE RID: 3518
	// (get) Token: 0x0600493C RID: 18748 RVA: 0x001121D0 File Offset: 0x001103D0
	// (set) Token: 0x0600493D RID: 18749 RVA: 0x001121D8 File Offset: 0x001103D8
	public string URL
	{
		get
		{
			return this.url;
		}
		set
		{
			if (value != this.url)
			{
				this.url = value;
				if (global::UnityEngine.Application.isPlaying)
				{
					base.StopAllCoroutines();
					base.StartCoroutine(this.downloadTexture());
				}
			}
		}
	}

	// Token: 0x17000DBF RID: 3519
	// (get) Token: 0x0600493E RID: 18750 RVA: 0x0011221C File Offset: 0x0011041C
	// (set) Token: 0x0600493F RID: 18751 RVA: 0x00112224 File Offset: 0x00110424
	public global::UnityEngine.Texture2D LoadingImage
	{
		get
		{
			return this.loadingImage;
		}
		set
		{
			this.loadingImage = value;
		}
	}

	// Token: 0x17000DC0 RID: 3520
	// (get) Token: 0x06004940 RID: 18752 RVA: 0x00112230 File Offset: 0x00110430
	// (set) Token: 0x06004941 RID: 18753 RVA: 0x00112238 File Offset: 0x00110438
	public global::UnityEngine.Texture2D ErrorImage
	{
		get
		{
			return this.errorImage;
		}
		set
		{
			this.errorImage = value;
		}
	}

	// Token: 0x06004942 RID: 18754 RVA: 0x00112244 File Offset: 0x00110444
	public override void Start()
	{
		base.Start();
		if (base.Texture == null)
		{
			base.Texture = this.LoadingImage;
		}
		if (global::UnityEngine.Application.isPlaying)
		{
			base.StartCoroutine(this.downloadTexture());
		}
	}

	// Token: 0x06004943 RID: 18755 RVA: 0x0011228C File Offset: 0x0011048C
	private global::System.Collections.IEnumerator downloadTexture()
	{
		base.Texture = this.loadingImage;
		using (global::UnityEngine.WWW request = new global::UnityEngine.WWW(this.url))
		{
			yield return request;
			if (!string.IsNullOrEmpty(request.error))
			{
				global::UnityEngine.Debug.Log("Error downloading image: " + request.error);
				base.Texture = (this.errorImage ?? this.loadingImage);
			}
			else
			{
				base.Texture = request.texture;
			}
		}
		yield break;
	}

	// Token: 0x0400270E RID: 9998
	[global::UnityEngine.SerializeField]
	protected string url = string.Empty;

	// Token: 0x0400270F RID: 9999
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Texture2D loadingImage;

	// Token: 0x04002710 RID: 10000
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Texture2D errorImage;

	// Token: 0x02000845 RID: 2117
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <downloadTexture>c__Iterator54 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06004944 RID: 18756 RVA: 0x001122A8 File Offset: 0x001104A8
		public <downloadTexture>c__Iterator54()
		{
		}

		// Token: 0x17000DC1 RID: 3521
		// (get) Token: 0x06004945 RID: 18757 RVA: 0x001122B0 File Offset: 0x001104B0
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000DC2 RID: 3522
		// (get) Token: 0x06004946 RID: 18758 RVA: 0x001122B8 File Offset: 0x001104B8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004947 RID: 18759 RVA: 0x001122C0 File Offset: 0x001104C0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				base.Texture = this.loadingImage;
				request = new global::UnityEngine.WWW(this.url);
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1U:
					if (!string.IsNullOrEmpty(request.error))
					{
						global::UnityEngine.Debug.Log("Error downloading image: " + request.error);
						base.Texture = (this.errorImage ?? this.loadingImage);
					}
					else
					{
						base.Texture = request.texture;
					}
					break;
				default:
					this.$current = request;
					this.$PC = 1;
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if (request != null)
					{
						request.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06004948 RID: 18760 RVA: 0x00112400 File Offset: 0x00110600
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					if (request != null)
					{
						request.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06004949 RID: 18761 RVA: 0x00112468 File Offset: 0x00110668
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04002711 RID: 10001
		internal global::UnityEngine.WWW <request>__0;

		// Token: 0x04002712 RID: 10002
		internal int $PC;

		// Token: 0x04002713 RID: 10003
		internal object $current;

		// Token: 0x04002714 RID: 10004
		internal global::dfWebSprite <>f__this;
	}
}

using System;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x0200096B RID: 2411
[global::UnityEngine.AddComponentMenu("NGUI/UI/Texture")]
[global::UnityEngine.ExecuteInEditMode]
public class UITexture : global::UIWidget
{
	// Token: 0x06005226 RID: 21030 RVA: 0x00150824 File Offset: 0x0014EA24
	public UITexture() : base(global::UIWidget.WidgetFlags.KeepsMaterial)
	{
	}

	// Token: 0x17000F65 RID: 3941
	// (get) Token: 0x06005227 RID: 21031 RVA: 0x00150830 File Offset: 0x0014EA30
	// (set) Token: 0x06005228 RID: 21032 RVA: 0x00150838 File Offset: 0x0014EA38
	public bool mirrorX
	{
		get
		{
			return this._mirrorX;
		}
		set
		{
			if (this._mirrorX != value)
			{
				this._mirrorX = value;
				base.ChangedAuto();
			}
		}
	}

	// Token: 0x17000F66 RID: 3942
	// (get) Token: 0x06005229 RID: 21033 RVA: 0x00150854 File Offset: 0x0014EA54
	// (set) Token: 0x0600522A RID: 21034 RVA: 0x0015085C File Offset: 0x0014EA5C
	public bool mirrorY
	{
		get
		{
			return this._mirrorY;
		}
		set
		{
			if (this._mirrorY != value)
			{
				this._mirrorY = value;
				base.ChangedAuto();
			}
		}
	}

	// Token: 0x0600522B RID: 21035 RVA: 0x00150878 File Offset: 0x0014EA78
	public override void MakePixelPerfect()
	{
		global::UnityEngine.Texture mainTexture = base.mainTexture;
		if (mainTexture != null)
		{
			global::UnityEngine.Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = (float)mainTexture.width;
			localScale.y = (float)mainTexture.height;
			localScale.z = 1f;
			base.cachedTransform.localScale = localScale;
		}
		base.MakePixelPerfect();
	}

	// Token: 0x0600522C RID: 21036 RVA: 0x001508E0 File Offset: 0x0014EAE0
	public override void OnFill(global::NGUI.Meshing.MeshBuffer m)
	{
		global::NGUI.Meshing.Vertex a;
		a.z = 0f;
		global::NGUI.Meshing.Vertex b;
		b.z = 0f;
		global::NGUI.Meshing.Vertex c;
		c.z = 0f;
		global::NGUI.Meshing.Vertex d;
		d.z = 0f;
		global::UnityEngine.Color color = base.color;
		a.r = (b.r = (c.r = (d.r = color.r)));
		a.g = (b.g = (c.g = (d.g = color.g)));
		a.b = (b.b = (c.b = (d.b = color.b)));
		a.a = (b.a = (c.a = (d.a = color.a)));
		if (this._mirrorX)
		{
			if (this._mirrorY)
			{
				a.x = 0.5f;
				a.y = -0.5f;
				b.x = 0.5f;
				b.y = -1f;
				c.x = 0f;
				c.y = -1f;
				d.x = 0f;
				d.y = -0.5f;
				a.u = 1f;
				a.v = 1f;
				b.u = 1f;
				b.v = 0f;
				c.u = 0f;
				c.v = 0f;
				d.u = 0f;
				d.v = 1f;
				m.TextureQuad(a, b, c, d);
				a.x = 0.5f;
				a.y = --0f;
				b.x = 0.5f;
				b.y = -0.5f;
				c.x = 0f;
				c.y = -0.5f;
				d.x = 0f;
				d.y = --0f;
				a.u = 0f;
				a.v = 1f;
				b.u = 0f;
				b.v = 0f;
				c.u = 1f;
				c.v = 0f;
				d.u = 1f;
				d.v = 1f;
				m.TextureQuad(a, b, c, d);
				a.x = 1f;
				a.y = -0.5f;
				b.x = 1f;
				b.y = -1f;
				c.x = 0.5f;
				c.y = -1f;
				d.x = 0.5f;
				d.y = -0.5f;
				a.u = 1f;
				a.v = 1f;
				b.u = 1f;
				b.v = 0f;
				c.u = 0f;
				c.v = 0f;
				d.u = 0f;
				d.v = 1f;
				m.TextureQuad(a, b, c, d);
				a.x = 1f;
				a.y = --0f;
				b.x = 1f;
				b.y = -0.5f;
				c.x = 0.5f;
				c.y = -0.5f;
				d.x = 0.5f;
				d.y = --0f;
				a.u = 0f;
				a.v = 1f;
				b.u = 0f;
				b.v = 0f;
				c.u = 1f;
				c.v = 0f;
				d.u = 1f;
				d.v = 1f;
				m.TextureQuad(a, b, c, d);
			}
			else
			{
				a.x = 0.5f;
				a.y = 0f;
				b.x = 0.5f;
				b.y = -1f;
				c.x = 0f;
				c.y = -1f;
				d.x = 0f;
				d.y = --0f;
				a.u = 1f;
				a.v = 1f;
				b.u = 1f;
				b.v = 0f;
				c.u = 0f;
				c.v = 0f;
				d.u = 0f;
				d.v = 1f;
				m.TextureQuad(a, b, c, d);
				a.x = 1f;
				a.y = 0f;
				b.x = 1f;
				b.y = -1f;
				c.x = 0.5f;
				c.y = -1f;
				d.x = 0.5f;
				d.y = 0f;
				a.u = 0f;
				a.v = 1f;
				b.u = 0f;
				b.v = 0f;
				c.u = 1f;
				c.v = 0f;
				d.u = 1f;
				d.v = 1f;
				m.TextureQuad(a, b, c, d);
			}
		}
		else if (this._mirrorY)
		{
			a.x = 1f;
			a.y = -0.5f;
			b.x = 1f;
			b.y = -1f;
			c.x = 0f;
			c.y = -1f;
			d.x = 0f;
			d.y = -0.5f;
			a.u = 1f;
			a.v = 0f;
			b.u = 1f;
			b.v = 1f;
			c.u = 0f;
			c.v = 1f;
			d.u = 0f;
			d.v = 0f;
			m.TextureQuad(a, b, c, d);
			a.x = 1f;
			a.y = 0f;
			b.x = 1f;
			b.y = -0.5f;
			c.x = 0f;
			c.y = -0.5f;
			d.x = 0f;
			d.y = --0f;
			a.u = 1f;
			a.v = 1f;
			b.u = 1f;
			b.v = 0f;
			c.u = 0f;
			c.v = 0f;
			d.u = 0f;
			d.v = 1f;
			m.TextureQuad(a, b, c, d);
		}
		else
		{
			a.x = 1f;
			a.y = 0f;
			b.x = 1f;
			b.y = -1f;
			c.x = 0f;
			c.y = -1f;
			d.x = 0f;
			d.y = --0f;
			a.u = 1f;
			a.v = 1f;
			b.u = 1f;
			b.v = 0f;
			c.u = 0f;
			c.v = 0f;
			d.u = 0f;
			d.v = 1f;
			m.TextureQuad(a, b, c, d);
		}
	}

	// Token: 0x04002E88 RID: 11912
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool _mirrorY;

	// Token: 0x04002E89 RID: 11913
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool _mirrorX;
}

using System;
using UnityEngine;

// Token: 0x0200098E RID: 2446
[global::UnityEngine.ExecuteInEditMode]
public class TOD_Components : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060052CA RID: 21194 RVA: 0x00158FA4 File Offset: 0x001571A4
	public TOD_Components()
	{
	}

	// Token: 0x060052CB RID: 21195 RVA: 0x00158FAC File Offset: 0x001571AC
	protected void OnEnable()
	{
		this.DomeTransform = base.transform;
		if (global::UnityEngine.Camera.main != null)
		{
			this.CameraTransform = global::UnityEngine.Camera.main.transform;
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("Main camera does not exist or is not tagged 'MainCamera'.");
		}
		this.Sky = base.GetComponent<global::TOD_Sky>();
		this.Animation = base.GetComponent<global::TOD_Animation>();
		this.Time = base.GetComponent<global::TOD_Time>();
		this.Weather = base.GetComponent<global::TOD_Weather>();
		this.Resources = base.GetComponent<global::TOD_Resources>();
		if (!this.Space)
		{
			global::UnityEngine.Debug.LogError("Space reference not set. Disabling TOD_Sky script.");
			this.Sky.enabled = false;
			return;
		}
		this.SpaceRenderer = this.Space.renderer;
		this.SpaceShader = this.SpaceRenderer.sharedMaterial;
		this.SpaceMeshFilter = this.Space.GetComponent<global::UnityEngine.MeshFilter>();
		if (!this.Atmosphere)
		{
			global::UnityEngine.Debug.LogError("Atmosphere reference not set. Disabling TOD_Sky script.");
			this.Sky.enabled = false;
			return;
		}
		this.AtmosphereRenderer = this.Atmosphere.renderer;
		this.AtmosphereShader = this.AtmosphereRenderer.sharedMaterial;
		this.AtmosphereMeshFilter = this.Atmosphere.GetComponent<global::UnityEngine.MeshFilter>();
		if (!this.Clear)
		{
			global::UnityEngine.Debug.LogError("Clear reference not set. Disabling TOD_Sky script.");
			this.Sky.enabled = false;
			return;
		}
		this.ClearRenderer = this.Clear.renderer;
		this.ClearShader = this.ClearRenderer.sharedMaterial;
		this.ClearMeshFilter = this.Clear.GetComponent<global::UnityEngine.MeshFilter>();
		if (!this.Clouds)
		{
			global::UnityEngine.Debug.LogError("Clouds reference not set. Disabling TOD_Sky script.");
			this.Sky.enabled = false;
			return;
		}
		this.CloudRenderer = this.Clouds.renderer;
		this.CloudShader = this.CloudRenderer.sharedMaterial;
		this.CloudMeshFilter = this.Clouds.GetComponent<global::UnityEngine.MeshFilter>();
		if (!this.Projector)
		{
			global::UnityEngine.Debug.LogError("Projector reference not set. Disabling TOD_Sky script.");
			this.Sky.enabled = false;
			return;
		}
		this.ShadowProjector = this.Projector.GetComponent<global::UnityEngine.Projector>();
		this.ShadowShader = this.ShadowProjector.material;
		if (!this.Light)
		{
			global::UnityEngine.Debug.LogError("Light reference not set. Disabling TOD_Sky script.");
			this.Sky.enabled = false;
			return;
		}
		this.LightTransform = this.Light.transform;
		this.LightSource = this.Light.light;
		if (!this.Sun)
		{
			global::UnityEngine.Debug.LogError("Sun reference not set. Disabling TOD_Sky script.");
			this.Sky.enabled = false;
			return;
		}
		this.SunTransform = this.Sun.transform;
		this.SunRenderer = this.Sun.renderer;
		this.SunShader = this.SunRenderer.sharedMaterial;
		this.SunMeshFilter = this.Sun.GetComponent<global::UnityEngine.MeshFilter>();
		if (this.Moon)
		{
			this.MoonTransform = this.Moon.transform;
			this.MoonRenderer = this.Moon.renderer;
			this.MoonShader = this.MoonRenderer.sharedMaterial;
			this.MoonMeshFilter = this.Moon.GetComponent<global::UnityEngine.MeshFilter>();
			return;
		}
		global::UnityEngine.Debug.LogError("Moon reference not set. Disabling TOD_Sky script.");
		this.Sky.enabled = false;
	}

	// Token: 0x04002FB9 RID: 12217
	public global::UnityEngine.GameObject Sun;

	// Token: 0x04002FBA RID: 12218
	public global::UnityEngine.GameObject Moon;

	// Token: 0x04002FBB RID: 12219
	public global::UnityEngine.GameObject Atmosphere;

	// Token: 0x04002FBC RID: 12220
	public global::UnityEngine.GameObject Clear;

	// Token: 0x04002FBD RID: 12221
	public global::UnityEngine.GameObject Clouds;

	// Token: 0x04002FBE RID: 12222
	public global::UnityEngine.GameObject Space;

	// Token: 0x04002FBF RID: 12223
	public global::UnityEngine.GameObject Light;

	// Token: 0x04002FC0 RID: 12224
	public global::UnityEngine.GameObject Projector;

	// Token: 0x04002FC1 RID: 12225
	internal global::UnityEngine.Transform DomeTransform;

	// Token: 0x04002FC2 RID: 12226
	internal global::UnityEngine.Transform SunTransform;

	// Token: 0x04002FC3 RID: 12227
	internal global::UnityEngine.Transform MoonTransform;

	// Token: 0x04002FC4 RID: 12228
	internal global::UnityEngine.Transform CameraTransform;

	// Token: 0x04002FC5 RID: 12229
	internal global::UnityEngine.Transform LightTransform;

	// Token: 0x04002FC6 RID: 12230
	internal global::UnityEngine.Renderer SpaceRenderer;

	// Token: 0x04002FC7 RID: 12231
	internal global::UnityEngine.Renderer AtmosphereRenderer;

	// Token: 0x04002FC8 RID: 12232
	internal global::UnityEngine.Renderer ClearRenderer;

	// Token: 0x04002FC9 RID: 12233
	internal global::UnityEngine.Renderer CloudRenderer;

	// Token: 0x04002FCA RID: 12234
	internal global::UnityEngine.Renderer SunRenderer;

	// Token: 0x04002FCB RID: 12235
	internal global::UnityEngine.Renderer MoonRenderer;

	// Token: 0x04002FCC RID: 12236
	internal global::UnityEngine.MeshFilter SpaceMeshFilter;

	// Token: 0x04002FCD RID: 12237
	internal global::UnityEngine.MeshFilter AtmosphereMeshFilter;

	// Token: 0x04002FCE RID: 12238
	internal global::UnityEngine.MeshFilter ClearMeshFilter;

	// Token: 0x04002FCF RID: 12239
	internal global::UnityEngine.MeshFilter CloudMeshFilter;

	// Token: 0x04002FD0 RID: 12240
	internal global::UnityEngine.MeshFilter SunMeshFilter;

	// Token: 0x04002FD1 RID: 12241
	internal global::UnityEngine.MeshFilter MoonMeshFilter;

	// Token: 0x04002FD2 RID: 12242
	internal global::UnityEngine.Material SpaceShader;

	// Token: 0x04002FD3 RID: 12243
	internal global::UnityEngine.Material AtmosphereShader;

	// Token: 0x04002FD4 RID: 12244
	internal global::UnityEngine.Material ClearShader;

	// Token: 0x04002FD5 RID: 12245
	internal global::UnityEngine.Material CloudShader;

	// Token: 0x04002FD6 RID: 12246
	internal global::UnityEngine.Material SunShader;

	// Token: 0x04002FD7 RID: 12247
	internal global::UnityEngine.Material MoonShader;

	// Token: 0x04002FD8 RID: 12248
	internal global::UnityEngine.Material ShadowShader;

	// Token: 0x04002FD9 RID: 12249
	internal global::UnityEngine.Light LightSource;

	// Token: 0x04002FDA RID: 12250
	internal global::UnityEngine.Projector ShadowProjector;

	// Token: 0x04002FDB RID: 12251
	internal global::TOD_Sky Sky;

	// Token: 0x04002FDC RID: 12252
	internal global::TOD_Animation Animation;

	// Token: 0x04002FDD RID: 12253
	internal global::TOD_Time Time;

	// Token: 0x04002FDE RID: 12254
	internal global::TOD_Weather Weather;

	// Token: 0x04002FDF RID: 12255
	internal global::TOD_Resources Resources;

	// Token: 0x04002FE0 RID: 12256
	internal global::TOD_SunShafts SunShafts;
}

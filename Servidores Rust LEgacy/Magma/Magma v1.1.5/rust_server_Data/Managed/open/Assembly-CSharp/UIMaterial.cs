using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008F8 RID: 2296
public class UIMaterial : global::UnityEngine.ScriptableObject
{
	// Token: 0x06004EAA RID: 20138 RVA: 0x0012E930 File Offset: 0x0012CB30
	public UIMaterial()
	{
	}

	// Token: 0x06004EAB RID: 20139 RVA: 0x0012E938 File Offset: 0x0012CB38
	public static global::UIMaterial Create(global::UnityEngine.Material key)
	{
		if (!key)
		{
			return null;
		}
		global::UIMaterial uimaterial;
		if (global::UIMaterial.g.keyedMaterials.TryGetValue(key, out uimaterial))
		{
			return uimaterial;
		}
		if (global::UIMaterial.g.generatedMaterials.TryGetValue(key, out uimaterial))
		{
			return uimaterial;
		}
		uimaterial = global::UnityEngine.ScriptableObject.CreateInstance<global::UIMaterial>();
		uimaterial.key = key;
		uimaterial.hashCode = ++global::UIMaterial.g.hashCodeIterator;
		if (uimaterial.hashCode == 0x7FFFFFFF)
		{
			global::UIMaterial.g.hashCodeIterator = int.MinValue;
		}
		global::UIMaterial.g.keyedMaterials.Add(key, uimaterial);
		return uimaterial;
	}

	// Token: 0x06004EAC RID: 20140 RVA: 0x0012E9C4 File Offset: 0x0012CBC4
	public static global::UIMaterial Create(global::UnityEngine.Material key, bool manageKeyDestruction, global::UIDrawCall.Clipping useAsClipping)
	{
		if (!manageKeyDestruction)
		{
			return global::UIMaterial.Create(key);
		}
		if (!key)
		{
			return null;
		}
		global::UIMaterial uimaterial;
		if (global::UIMaterial.g.keyedMaterials.TryGetValue(key, out uimaterial))
		{
			throw new global::System.InvalidOperationException("That material is registered and cannot be used with manageKeyDestruction");
		}
		if (global::UIMaterial.g.generatedMaterials.TryGetValue(key, out uimaterial))
		{
			return uimaterial;
		}
		uimaterial = global::UnityEngine.ScriptableObject.CreateInstance<global::UIMaterial>();
		uimaterial.key = key;
		uimaterial.hashCode = ++global::UIMaterial.g.hashCodeIterator;
		if (uimaterial.hashCode == 0x7FFFFFFF)
		{
			global::UIMaterial.g.hashCodeIterator = int.MinValue;
		}
		global::UIMaterial.g.generatedMaterials.Add(key, uimaterial);
		uimaterial.matFirst = key;
		switch (useAsClipping)
		{
		case global::UIDrawCall.Clipping.None:
			uimaterial.matNone = key;
			break;
		case global::UIDrawCall.Clipping.HardClip:
			uimaterial.matHardClip = key;
			break;
		case global::UIDrawCall.Clipping.AlphaClip:
			uimaterial.matAlphaClip = key;
			break;
		case global::UIDrawCall.Clipping.SoftClip:
			uimaterial.matSoftClip = key;
			break;
		default:
			throw new global::System.NotImplementedException();
		}
		uimaterial.madeMats = (global::UIMaterial.ClippingFlags)(1 << (int)useAsClipping);
		return uimaterial;
	}

	// Token: 0x06004EAD RID: 20141 RVA: 0x0012EACC File Offset: 0x0012CCCC
	public static global::UIMaterial Create(global::UnityEngine.Material key, bool manageKeyDestruction)
	{
		return global::UIMaterial.Create(key, manageKeyDestruction, global::UIDrawCall.Clipping.None);
	}

	// Token: 0x06004EAE RID: 20142 RVA: 0x0012EAD8 File Offset: 0x0012CCD8
	public sealed override int GetHashCode()
	{
		return this.hashCode;
	}

	// Token: 0x06004EAF RID: 20143 RVA: 0x0012EAE0 File Offset: 0x0012CCE0
	public override string ToString()
	{
		return (!this.key) ? "destroyed" : this.key.ToString();
	}

	// Token: 0x06004EB0 RID: 20144 RVA: 0x0012EB08 File Offset: 0x0012CD08
	private global::UnityEngine.Material FastGet(global::UIDrawCall.Clipping clipping)
	{
		switch (clipping)
		{
		case global::UIDrawCall.Clipping.None:
			return this.matNone;
		case global::UIDrawCall.Clipping.HardClip:
			return this.matHardClip;
		case global::UIDrawCall.Clipping.AlphaClip:
			return this.matAlphaClip;
		case global::UIDrawCall.Clipping.SoftClip:
			return this.matSoftClip;
		default:
			throw new global::System.NotImplementedException();
		}
	}

	// Token: 0x06004EB1 RID: 20145 RVA: 0x0012EB54 File Offset: 0x0012CD54
	private static bool ShaderNameDecor(ref string shaderName, string not1, string not2, string suffix)
	{
		string text = shaderName.Replace(not1, string.Empty).Replace(not2, string.Empty);
		if (text != shaderName)
		{
			if (!text.EndsWith(suffix))
			{
				shaderName = text + suffix;
			}
			return true;
		}
		if (!shaderName.EndsWith(suffix))
		{
			shaderName += suffix;
			return true;
		}
		return false;
	}

	// Token: 0x06004EB2 RID: 20146 RVA: 0x0012EBB8 File Offset: 0x0012CDB8
	private static global::UnityEngine.Shader GetClippingShader(global::UnityEngine.Shader original, global::UIDrawCall.Clipping clipping)
	{
		if (!original)
		{
			return null;
		}
		string text = original.name;
		switch (clipping)
		{
		case global::UIDrawCall.Clipping.None:
		{
			string text2 = text.Replace(" (HardClip)", string.Empty).Replace(" (AlphaClip)", string.Empty).Replace(" (SoftClip)", string.Empty);
			if (text2 == text)
			{
				return original;
			}
			text = text2;
			break;
		}
		case global::UIDrawCall.Clipping.HardClip:
			if (!global::UIMaterial.ShaderNameDecor(ref text, " (AlphaClip)", " (SoftClip)", " (HardClip)"))
			{
				return original;
			}
			break;
		case global::UIDrawCall.Clipping.AlphaClip:
			if (!global::UIMaterial.ShaderNameDecor(ref text, " (SoftClip)", " (HardClip)", " (AlphaClip)"))
			{
				return original;
			}
			break;
		case global::UIDrawCall.Clipping.SoftClip:
			if (!global::UIMaterial.ShaderNameDecor(ref text, " (HardClip)", " (AlphaClip)", " (SoftClip)"))
			{
				return original;
			}
			break;
		default:
			throw new global::System.NotImplementedException();
		}
		global::UnityEngine.Shader shader = global::UnityEngine.Shader.Find(text);
		if (!shader)
		{
			throw new global::UnityEngine.MissingReferenceException("Theres no shader named " + text);
		}
		return shader;
	}

	// Token: 0x06004EB3 RID: 20147 RVA: 0x0012ECCC File Offset: 0x0012CECC
	private static global::UnityEngine.Material CreateMaterial(global::UnityEngine.Shader shader)
	{
		return new global::UnityEngine.Material(shader)
		{
			hideFlags = 0xC
		};
	}

	// Token: 0x06004EB4 RID: 20148 RVA: 0x0012ECEC File Offset: 0x0012CEEC
	private static global::UIDrawCall.Clipping ShaderClipping(string shaderName)
	{
		if (shaderName.EndsWith(" (SoftClip)"))
		{
			return global::UIDrawCall.Clipping.SoftClip;
		}
		if (shaderName.EndsWith(" (HardClip)"))
		{
			return global::UIDrawCall.Clipping.HardClip;
		}
		if (shaderName.EndsWith(" (AlphaClip)"))
		{
			return global::UIDrawCall.Clipping.AlphaClip;
		}
		return global::UIDrawCall.Clipping.None;
	}

	// Token: 0x06004EB5 RID: 20149 RVA: 0x0012ED30 File Offset: 0x0012CF30
	private void MakeDefaultMaterial()
	{
		this.MakeMaterial(global::UIMaterial.ShaderClipping(this.key.shader.name));
	}

	// Token: 0x06004EB6 RID: 20150 RVA: 0x0012ED50 File Offset: 0x0012CF50
	public global::UIMaterial Clone()
	{
		global::UnityEngine.Material material = new global::UnityEngine.Material(this.key)
		{
			hideFlags = 4
		};
		return global::UIMaterial.Create(material, true);
	}

	// Token: 0x06004EB7 RID: 20151 RVA: 0x0012ED7C File Offset: 0x0012CF7C
	private global::UnityEngine.Material MakeMaterial(global::UIDrawCall.Clipping clipping)
	{
		bool flag = this.madeMats == (global::UIMaterial.ClippingFlags)0;
		global::UnityEngine.Material material;
		global::UnityEngine.Material material2;
		switch (clipping)
		{
		case global::UIDrawCall.Clipping.None:
		{
			global::UnityEngine.Shader shader = this.key.shader;
			material = this.matNone;
			material2 = (this.matNone = global::UIMaterial.CreateMaterial(shader));
			this.madeMats |= global::UIMaterial.ClippingFlags.None;
			break;
		}
		case global::UIDrawCall.Clipping.HardClip:
		{
			global::UnityEngine.Shader shader = global::UIMaterial.GetClippingShader(this.key.shader, global::UIDrawCall.Clipping.HardClip);
			material = this.matHardClip;
			material2 = (this.matHardClip = global::UIMaterial.CreateMaterial(shader));
			this.madeMats |= global::UIMaterial.ClippingFlags.HardClip;
			break;
		}
		case global::UIDrawCall.Clipping.AlphaClip:
		{
			global::UnityEngine.Shader shader = global::UIMaterial.GetClippingShader(this.key.shader, global::UIDrawCall.Clipping.AlphaClip);
			material = this.matAlphaClip;
			material2 = (this.matAlphaClip = global::UIMaterial.CreateMaterial(shader));
			this.madeMats |= global::UIMaterial.ClippingFlags.AlphaClip;
			break;
		}
		case global::UIDrawCall.Clipping.SoftClip:
		{
			global::UnityEngine.Shader shader = global::UIMaterial.GetClippingShader(this.key.shader, global::UIDrawCall.Clipping.SoftClip);
			material = this.matSoftClip;
			material2 = (this.matSoftClip = global::UIMaterial.CreateMaterial(shader));
			this.madeMats |= global::UIMaterial.ClippingFlags.SoftClip;
			break;
		}
		default:
			throw new global::System.NotImplementedException();
		}
		global::UIMaterial.g.generatedMaterials.Add(material2, this);
		if (flag)
		{
			this.matFirst = material2;
			material2.CopyPropertiesFromMaterial(this.key);
		}
		else
		{
			material2.CopyPropertiesFromMaterial(this.matFirst);
		}
		if (material)
		{
			global::UnityEngine.Object.DestroyImmediate(material);
		}
		return material2;
	}

	// Token: 0x17000E88 RID: 3720
	public global::UnityEngine.Material this[global::UIDrawCall.Clipping clipping]
	{
		get
		{
			global::UIMaterial.ClippingFlags clippingFlags = (global::UIMaterial.ClippingFlags)(1 << (int)clipping);
			if ((clippingFlags & this.madeMats) != clippingFlags)
			{
				return this.MakeMaterial(clipping);
			}
			switch (clipping)
			{
			case global::UIDrawCall.Clipping.None:
				return this.matNone;
			case global::UIDrawCall.Clipping.HardClip:
				return this.matHardClip;
			case global::UIDrawCall.Clipping.AlphaClip:
				return this.matAlphaClip;
			case global::UIDrawCall.Clipping.SoftClip:
				return this.matSoftClip;
			default:
				throw new global::System.NotImplementedException();
			}
		}
	}

	// Token: 0x06004EB9 RID: 20153 RVA: 0x0012EF5C File Offset: 0x0012D15C
	public void Set(string property, float value)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetFloat(property, value);
			}
		}
	}

	// Token: 0x06004EBA RID: 20154 RVA: 0x0012EFAC File Offset: 0x0012D1AC
	public void Set(string property, global::UnityEngine.Vector2 value)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		global::UnityEngine.Vector4 vector;
		vector.x = value.x;
		vector.y = value.y;
		vector.z = (vector.w = 0f);
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetVector(property, vector);
			}
		}
	}

	// Token: 0x06004EBB RID: 20155 RVA: 0x0012F030 File Offset: 0x0012D230
	public void Set(string property, global::UnityEngine.Vector3 value)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		global::UnityEngine.Vector4 vector;
		vector.x = value.x;
		vector.y = value.y;
		vector.z = (vector.w = 0f);
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetVector(property, vector);
			}
		}
	}

	// Token: 0x06004EBC RID: 20156 RVA: 0x0012F0B4 File Offset: 0x0012D2B4
	public void Set(string property, global::UnityEngine.Vector4 value)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		global::UnityEngine.Vector4 vector;
		vector.x = value.x;
		vector.y = value.y;
		vector.z = (vector.w = 0f);
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetVector(property, vector);
			}
		}
	}

	// Token: 0x06004EBD RID: 20157 RVA: 0x0012F138 File Offset: 0x0012D338
	public void Set(string property, global::UnityEngine.Color color)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetColor(property, color);
			}
		}
	}

	// Token: 0x06004EBE RID: 20158 RVA: 0x0012F188 File Offset: 0x0012D388
	public void Set(string property, global::UnityEngine.Matrix4x4 mat)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetMatrix(property, mat);
			}
		}
	}

	// Token: 0x06004EBF RID: 20159 RVA: 0x0012F1D8 File Offset: 0x0012D3D8
	public void Set(string property, global::UnityEngine.Texture texture)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetTexture(property, texture);
			}
		}
	}

	// Token: 0x06004EC0 RID: 20160 RVA: 0x0012F228 File Offset: 0x0012D428
	public void SetTextureScale(string property, global::UnityEngine.Vector2 scale)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetTextureScale(property, scale);
			}
		}
	}

	// Token: 0x06004EC1 RID: 20161 RVA: 0x0012F278 File Offset: 0x0012D478
	public void SetTextureOffset(string property, global::UnityEngine.Vector2 offset)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetTextureOffset(property, offset);
			}
		}
	}

	// Token: 0x06004EC2 RID: 20162 RVA: 0x0012F2C8 File Offset: 0x0012D4C8
	public void SetPass(int pass)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			this.MakeDefaultMaterial();
		}
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).SetPass(pass);
			}
		}
	}

	// Token: 0x06004EC3 RID: 20163 RVA: 0x0012F318 File Offset: 0x0012D518
	public void CopyPropertiesFromMaterial(global::UnityEngine.Material material)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			if (material == this.key)
			{
				return;
			}
			this.MakeDefaultMaterial();
		}
		for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
		{
			if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
			{
				this.FastGet(clipping).CopyPropertiesFromMaterial(material);
			}
		}
	}

	// Token: 0x06004EC4 RID: 20164 RVA: 0x0012F37C File Offset: 0x0012D57C
	public bool HasProperty(string property)
	{
		if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
		{
			return this.key.HasProperty(property);
		}
		return this.matFirst.HasProperty(property);
	}

	// Token: 0x06004EC5 RID: 20165 RVA: 0x0012F3B0 File Offset: 0x0012D5B0
	public void CopyPropertiesFromOriginal()
	{
		if (this.madeMats != (global::UIMaterial.ClippingFlags)0)
		{
			this.CopyPropertiesFromMaterial(this.key);
		}
	}

	// Token: 0x06004EC6 RID: 20166 RVA: 0x0012F3CC File Offset: 0x0012D5CC
	private void OnDestroy()
	{
		if (this.madeMats != (global::UIMaterial.ClippingFlags)0)
		{
			for (global::UIDrawCall.Clipping clipping = global::UIDrawCall.Clipping.None; clipping < (global::UIDrawCall.Clipping)4; clipping++)
			{
				if ((this.madeMats & (global::UIMaterial.ClippingFlags)(1 << (int)clipping)) != (global::UIMaterial.ClippingFlags)0)
				{
					global::UnityEngine.Material material = this.FastGet(clipping);
					global::UIMaterial.g.generatedMaterials.Remove(material);
					global::UnityEngine.Object.DestroyImmediate(material);
				}
			}
		}
		global::UIMaterial.g.keyedMaterials.Remove(this.key);
		this.matNone = (this.matFirst = (this.matHardClip = (this.matSoftClip = (this.matAlphaClip = (this.key = null)))));
	}

	// Token: 0x17000E89 RID: 3721
	// (get) Token: 0x06004EC7 RID: 20167 RVA: 0x0012F468 File Offset: 0x0012D668
	// (set) Token: 0x06004EC8 RID: 20168 RVA: 0x0012F49C File Offset: 0x0012D69C
	public global::UnityEngine.Texture mainTexture
	{
		get
		{
			return (this.madeMats != (global::UIMaterial.ClippingFlags)0) ? this.matFirst.mainTexture : this.key.mainTexture;
		}
		set
		{
			if (this.madeMats == (global::UIMaterial.ClippingFlags)0)
			{
				this.MakeDefaultMaterial();
			}
			this.Set("_MainTex", value);
		}
	}

	// Token: 0x06004EC9 RID: 20169 RVA: 0x0012F4BC File Offset: 0x0012D6BC
	public static explicit operator global::UIMaterial(global::UnityEngine.Material key)
	{
		return global::UIMaterial.Create(key);
	}

	// Token: 0x06004ECA RID: 20170 RVA: 0x0012F4C4 File Offset: 0x0012D6C4
	public static explicit operator global::UnityEngine.Material(global::UIMaterial uimat)
	{
		return (!uimat) ? null : uimat.key;
	}

	// Token: 0x04002B55 RID: 11093
	private const global::UIDrawCall.Clipping kBeginClipping = global::UIDrawCall.Clipping.None;

	// Token: 0x04002B56 RID: 11094
	private const global::UIDrawCall.Clipping kEndClipping = (global::UIDrawCall.Clipping)4;

	// Token: 0x04002B57 RID: 11095
	private const string hard = " (HardClip)";

	// Token: 0x04002B58 RID: 11096
	private const string alpha = " (AlphaClip)";

	// Token: 0x04002B59 RID: 11097
	private const string soft = " (SoftClip)";

	// Token: 0x04002B5A RID: 11098
	private global::UnityEngine.Material key;

	// Token: 0x04002B5B RID: 11099
	private global::UnityEngine.Material matNone;

	// Token: 0x04002B5C RID: 11100
	private global::UnityEngine.Material matHardClip;

	// Token: 0x04002B5D RID: 11101
	private global::UnityEngine.Material matAlphaClip;

	// Token: 0x04002B5E RID: 11102
	private global::UnityEngine.Material matSoftClip;

	// Token: 0x04002B5F RID: 11103
	private global::UnityEngine.Material matFirst;

	// Token: 0x04002B60 RID: 11104
	private int hashCode;

	// Token: 0x04002B61 RID: 11105
	private global::UIMaterial.ClippingFlags madeMats;

	// Token: 0x020008F9 RID: 2297
	private static class g
	{
		// Token: 0x06004ECB RID: 20171 RVA: 0x0012F4E0 File Offset: 0x0012D6E0
		// Note: this type is marked as 'beforefieldinit'.
		static g()
		{
		}

		// Token: 0x04002B62 RID: 11106
		public static int hashCodeIterator = int.MinValue;

		// Token: 0x04002B63 RID: 11107
		public static readonly global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::UIMaterial> generatedMaterials = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::UIMaterial>();

		// Token: 0x04002B64 RID: 11108
		public static readonly global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::UIMaterial> keyedMaterials = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::UIMaterial>();
	}

	// Token: 0x020008FA RID: 2298
	private enum ClippingFlags
	{
		// Token: 0x04002B66 RID: 11110
		None = 1,
		// Token: 0x04002B67 RID: 11111
		HardClip,
		// Token: 0x04002B68 RID: 11112
		AlphaClip = 4,
		// Token: 0x04002B69 RID: 11113
		SoftClip = 8
	}
}

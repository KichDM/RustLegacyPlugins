using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02000901 RID: 2305
public class UIPanelMaterialPropertyBlock
{
	// Token: 0x06004F05 RID: 20229 RVA: 0x00132CD4 File Offset: 0x00130ED4
	public UIPanelMaterialPropertyBlock()
	{
	}

	// Token: 0x06004F06 RID: 20230 RVA: 0x00132CDC File Offset: 0x00130EDC
	private static global::UIPanelMaterialPropertyBlock.Node NewNode(global::UIPanelMaterialPropertyBlock block, int prop, global::UIPanelMaterialPropertyBlock.PropType type)
	{
		global::UIPanelMaterialPropertyBlock.Node node;
		if (global::UIPanelMaterialPropertyBlock.dumpCount > 0)
		{
			node = global::UIPanelMaterialPropertyBlock.dump;
			global::UIPanelMaterialPropertyBlock.dump = node.prev;
			global::UIPanelMaterialPropertyBlock.dumpCount--;
			node.disposed = false;
		}
		else
		{
			node = new global::UIPanelMaterialPropertyBlock.Node();
		}
		node.property = prop;
		node.type = type;
		if (block.count++ == 0)
		{
			block.first = (block.last = node);
			node.hasNext = (node.hasPrev = false);
			node.next = (node.prev = null);
		}
		else
		{
			node.prev = block.last;
			node.hasPrev = true;
			node.next = null;
			node.hasNext = false;
			block.last = node;
			node.prev.next = node;
			node.prev.hasNext = true;
		}
		return node;
	}

	// Token: 0x06004F07 RID: 20231 RVA: 0x00132DC0 File Offset: 0x00130FC0
	private static global::UIPanelMaterialPropertyBlock.Node NewNode(global::UIPanelMaterialPropertyBlock block, int prop, ref global::UnityEngine.Vector4 value)
	{
		global::UIPanelMaterialPropertyBlock.Node node = global::UIPanelMaterialPropertyBlock.NewNode(block, prop, global::UIPanelMaterialPropertyBlock.PropType.Vector);
		node.value.VECTOR.x = value.x;
		node.value.VECTOR.y = value.y;
		node.value.VECTOR.z = value.z;
		node.value.VECTOR.w = value.w;
		return node;
	}

	// Token: 0x06004F08 RID: 20232 RVA: 0x00132E30 File Offset: 0x00131030
	private static global::UIPanelMaterialPropertyBlock.Node NewNode(global::UIPanelMaterialPropertyBlock block, int prop, ref global::UnityEngine.Color value)
	{
		global::UIPanelMaterialPropertyBlock.Node node = global::UIPanelMaterialPropertyBlock.NewNode(block, prop, global::UIPanelMaterialPropertyBlock.PropType.Color);
		node.value.COLOR.r = value.r;
		node.value.COLOR.g = value.g;
		node.value.COLOR.b = value.b;
		node.value.COLOR.a = value.a;
		return node;
	}

	// Token: 0x06004F09 RID: 20233 RVA: 0x00132EA0 File Offset: 0x001310A0
	private static global::UIPanelMaterialPropertyBlock.Node NewNode(global::UIPanelMaterialPropertyBlock block, int prop, ref float value)
	{
		global::UIPanelMaterialPropertyBlock.Node node = global::UIPanelMaterialPropertyBlock.NewNode(block, prop, global::UIPanelMaterialPropertyBlock.PropType.Float);
		node.value.FLOAT = value;
		return node;
	}

	// Token: 0x06004F0A RID: 20234 RVA: 0x00132EC4 File Offset: 0x001310C4
	private static global::UIPanelMaterialPropertyBlock.Node NewNode(global::UIPanelMaterialPropertyBlock block, int prop, ref global::UnityEngine.Matrix4x4 value)
	{
		global::UIPanelMaterialPropertyBlock.Node node = global::UIPanelMaterialPropertyBlock.NewNode(block, prop, global::UIPanelMaterialPropertyBlock.PropType.Matrix);
		node.value.MATRIX.m00 = value.m00;
		node.value.MATRIX.m10 = value.m10;
		node.value.MATRIX.m20 = value.m20;
		node.value.MATRIX.m30 = value.m30;
		node.value.MATRIX.m01 = value.m01;
		node.value.MATRIX.m11 = value.m11;
		node.value.MATRIX.m21 = value.m21;
		node.value.MATRIX.m31 = value.m31;
		node.value.MATRIX.m02 = value.m02;
		node.value.MATRIX.m12 = value.m12;
		node.value.MATRIX.m22 = value.m22;
		node.value.MATRIX.m32 = value.m32;
		node.value.MATRIX.m03 = value.m03;
		node.value.MATRIX.m13 = value.m13;
		node.value.MATRIX.m23 = value.m23;
		node.value.MATRIX.m33 = value.m33;
		return node;
	}

	// Token: 0x06004F0B RID: 20235 RVA: 0x0013303C File Offset: 0x0013123C
	public void Set(string property, global::UnityEngine.Color value)
	{
		this.Set(global::UnityEngine.Shader.PropertyToID(property), value);
	}

	// Token: 0x06004F0C RID: 20236 RVA: 0x0013304C File Offset: 0x0013124C
	public void Set(string property, global::UnityEngine.Vector4 value)
	{
		this.Set(global::UnityEngine.Shader.PropertyToID(property), value);
	}

	// Token: 0x06004F0D RID: 20237 RVA: 0x0013305C File Offset: 0x0013125C
	public void Set(string property, float value)
	{
		this.Set(global::UnityEngine.Shader.PropertyToID(property), value);
	}

	// Token: 0x06004F0E RID: 20238 RVA: 0x0013306C File Offset: 0x0013126C
	public void Set(string property, global::UnityEngine.Matrix4x4 value)
	{
		this.Set(global::UnityEngine.Shader.PropertyToID(property), value);
	}

	// Token: 0x06004F0F RID: 20239 RVA: 0x0013307C File Offset: 0x0013127C
	public void Set(int property, global::UnityEngine.Color value)
	{
		global::UIPanelMaterialPropertyBlock.NewNode(this, property, ref value);
	}

	// Token: 0x06004F10 RID: 20240 RVA: 0x00133088 File Offset: 0x00131288
	public void Set(int property, global::UnityEngine.Vector4 value)
	{
		global::UIPanelMaterialPropertyBlock.NewNode(this, property, ref value);
	}

	// Token: 0x06004F11 RID: 20241 RVA: 0x00133094 File Offset: 0x00131294
	public void Set(int property, float value)
	{
		global::UIPanelMaterialPropertyBlock.NewNode(this, property, ref value);
	}

	// Token: 0x06004F12 RID: 20242 RVA: 0x001330A0 File Offset: 0x001312A0
	public void Set(int property, global::UnityEngine.Matrix4x4 value)
	{
		global::UIPanelMaterialPropertyBlock.NewNode(this, property, ref value);
	}

	// Token: 0x06004F13 RID: 20243 RVA: 0x001330AC File Offset: 0x001312AC
	public void Clear()
	{
		if (this.count > 0)
		{
			this.first.prev = global::UIPanelMaterialPropertyBlock.dump;
			global::UIPanelMaterialPropertyBlock.dump = this.last;
			if (global::UIPanelMaterialPropertyBlock.dumpCount > 0)
			{
				this.first.prev.next = this.first;
				this.first.prev.hasNext = true;
				this.first.hasPrev = true;
			}
			this.first = (this.last = null);
			global::UIPanelMaterialPropertyBlock.dumpCount += this.count;
			this.count = 0;
		}
	}

	// Token: 0x06004F14 RID: 20244 RVA: 0x00133148 File Offset: 0x00131348
	public void AddToMaterialPropertyBlock(global::UnityEngine.MaterialPropertyBlock block)
	{
		global::UIPanelMaterialPropertyBlock.Node next = this.first;
		int num = this.count;
		while (num-- > 0)
		{
			switch (next.type)
			{
			case global::UIPanelMaterialPropertyBlock.PropType.Float:
				block.AddFloat(next.property, next.value.FLOAT);
				break;
			case global::UIPanelMaterialPropertyBlock.PropType.Vector:
				block.AddVector(next.property, next.value.VECTOR);
				break;
			case global::UIPanelMaterialPropertyBlock.PropType.Color:
				block.AddColor(next.property, next.value.COLOR);
				break;
			case global::UIPanelMaterialPropertyBlock.PropType.Matrix:
				block.AddMatrix(next.property, next.value.MATRIX);
				break;
			}
			next = next.next;
		}
	}

	// Token: 0x04002B96 RID: 11158
	private global::UIPanelMaterialPropertyBlock.Node first;

	// Token: 0x04002B97 RID: 11159
	private global::UIPanelMaterialPropertyBlock.Node last;

	// Token: 0x04002B98 RID: 11160
	private int count;

	// Token: 0x04002B99 RID: 11161
	private static global::UIPanelMaterialPropertyBlock.Node dump;

	// Token: 0x04002B9A RID: 11162
	private static int dumpCount;

	// Token: 0x02000902 RID: 2306
	private enum PropType : byte
	{
		// Token: 0x04002B9C RID: 11164
		Float,
		// Token: 0x04002B9D RID: 11165
		Vector,
		// Token: 0x04002B9E RID: 11166
		Color,
		// Token: 0x04002B9F RID: 11167
		Matrix
	}

	// Token: 0x02000903 RID: 2307
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x40)]
	private struct PropValue
	{
		// Token: 0x04002BA0 RID: 11168
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::UnityEngine.Color COLOR;

		// Token: 0x04002BA1 RID: 11169
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public float FLOAT;

		// Token: 0x04002BA2 RID: 11170
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::UnityEngine.Vector4 VECTOR;

		// Token: 0x04002BA3 RID: 11171
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::UnityEngine.Matrix4x4 MATRIX;
	}

	// Token: 0x02000904 RID: 2308
	private class Node
	{
		// Token: 0x06004F15 RID: 20245 RVA: 0x0013320C File Offset: 0x0013140C
		public Node()
		{
		}

		// Token: 0x04002BA4 RID: 11172
		public global::UIPanelMaterialPropertyBlock.Node prev;

		// Token: 0x04002BA5 RID: 11173
		public global::UIPanelMaterialPropertyBlock.Node next;

		// Token: 0x04002BA6 RID: 11174
		public int property;

		// Token: 0x04002BA7 RID: 11175
		public global::UIPanelMaterialPropertyBlock.PropValue value;

		// Token: 0x04002BA8 RID: 11176
		public global::UIPanelMaterialPropertyBlock.PropType type;

		// Token: 0x04002BA9 RID: 11177
		public bool hasNext;

		// Token: 0x04002BAA RID: 11178
		public bool hasPrev;

		// Token: 0x04002BAB RID: 11179
		public bool disposed;
	}
}

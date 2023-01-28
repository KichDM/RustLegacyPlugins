using System;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x020008F6 RID: 2294
public class UIGeometry
{
	// Token: 0x06004EA0 RID: 20128 RVA: 0x0012E5BC File Offset: 0x0012C7BC
	public UIGeometry()
	{
	}

	// Token: 0x17000E86 RID: 3718
	// (get) Token: 0x06004EA1 RID: 20129 RVA: 0x0012E5D0 File Offset: 0x0012C7D0
	public bool hasVertices
	{
		get
		{
			return this.meshBuffer.vSize > 0;
		}
	}

	// Token: 0x17000E87 RID: 3719
	// (get) Token: 0x06004EA2 RID: 20130 RVA: 0x0012E5E0 File Offset: 0x0012C7E0
	public bool hasTransformed
	{
		get
		{
			return this.vertsTransformed || this.meshBuffer.vSize == 0;
		}
	}

	// Token: 0x06004EA3 RID: 20131 RVA: 0x0012E600 File Offset: 0x0012C800
	public void Clear()
	{
		this.meshBuffer.Clear();
		this.vertsTransformed = false;
	}

	// Token: 0x06004EA4 RID: 20132 RVA: 0x0012E614 File Offset: 0x0012C814
	public void Apply(ref global::UnityEngine.Matrix4x4 widgetToPanel)
	{
		if (!this.vertsTransformed)
		{
			global::UnityEngine.Debug.LogWarning("This overload of apply suggests you have called the other overload once before");
		}
		this.Apply(ref this.lastPivotOffset, ref widgetToPanel);
	}

	// Token: 0x06004EA5 RID: 20133 RVA: 0x0012E644 File Offset: 0x0012C844
	public void Apply(ref global::UnityEngine.Vector3 pivotOffset, ref global::UnityEngine.Matrix4x4 widgetToPanel)
	{
		if (this.vertsTransformed)
		{
			if (pivotOffset == this.lastPivotOffset)
			{
				if (widgetToPanel == this.lastWidgetToPanel)
				{
					return;
				}
				global::UnityEngine.Matrix4x4 matrix4x = this.lastWidgetToPanel.inverse;
				this.lastWidgetToPanel = widgetToPanel;
				matrix4x = widgetToPanel * matrix4x;
				this.meshBuffer.TransformVertices(matrix4x.m00, matrix4x.m10, matrix4x.m20, matrix4x.m01, matrix4x.m11, matrix4x.m21, matrix4x.m02, matrix4x.m12, matrix4x.m22, matrix4x.m03, matrix4x.m13, matrix4x.m23);
			}
			else
			{
				global::UnityEngine.Debug.LogWarning("Verts were transformed more than once");
				global::UnityEngine.Matrix4x4 inverse = this.lastWidgetToPanel.inverse;
				this.meshBuffer.TransformThenOffsetVertices(inverse.m00, inverse.m10, inverse.m20, inverse.m01, inverse.m11, inverse.m21, inverse.m02, inverse.m12, inverse.m22, inverse.m03, inverse.m13, inverse.m23, -this.lastPivotOffset.x, -this.lastPivotOffset.y, -this.lastPivotOffset.z);
				this.meshBuffer.OffsetThenTransformVertices(pivotOffset.x, pivotOffset.y, pivotOffset.z, widgetToPanel.m00, widgetToPanel.m10, widgetToPanel.m20, widgetToPanel.m01, widgetToPanel.m11, widgetToPanel.m21, widgetToPanel.m02, widgetToPanel.m12, widgetToPanel.m22, widgetToPanel.m03, widgetToPanel.m13, widgetToPanel.m23);
				this.lastWidgetToPanel = widgetToPanel;
				this.lastPivotOffset = pivotOffset;
			}
		}
		else
		{
			this.meshBuffer.OffsetThenTransformVertices(pivotOffset.x, pivotOffset.y, pivotOffset.z, widgetToPanel.m00, widgetToPanel.m10, widgetToPanel.m20, widgetToPanel.m01, widgetToPanel.m11, widgetToPanel.m21, widgetToPanel.m02, widgetToPanel.m12, widgetToPanel.m22, widgetToPanel.m03, widgetToPanel.m13, widgetToPanel.m23);
			this.lastWidgetToPanel = widgetToPanel;
			this.lastPivotOffset = pivotOffset;
			this.vertsTransformed = true;
		}
	}

	// Token: 0x06004EA6 RID: 20134 RVA: 0x0012E8B4 File Offset: 0x0012CAB4
	public void WriteToBuffers(global::NGUI.Meshing.MeshBuffer m)
	{
		this.meshBuffer.WriteBuffers(m);
	}

	// Token: 0x04002B50 RID: 11088
	[global::System.NonSerialized]
	public global::NGUI.Meshing.MeshBuffer meshBuffer = new global::NGUI.Meshing.MeshBuffer();

	// Token: 0x04002B51 RID: 11089
	private bool vertsTransformed;

	// Token: 0x04002B52 RID: 11090
	private global::UnityEngine.Vector3 lastPivotOffset;

	// Token: 0x04002B53 RID: 11091
	private global::UnityEngine.Matrix4x4 lastWidgetToPanel;
}

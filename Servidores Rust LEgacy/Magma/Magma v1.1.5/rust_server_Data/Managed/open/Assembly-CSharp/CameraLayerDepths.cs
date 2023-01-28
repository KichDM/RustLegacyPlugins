using System;
using UnityEngine;

// Token: 0x02000572 RID: 1394
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class CameraLayerDepths : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002F00 RID: 12032 RVA: 0x000B315C File Offset: 0x000B135C
	public CameraLayerDepths()
	{
	}

	// Token: 0x06002F01 RID: 12033 RVA: 0x000B3164 File Offset: 0x000B1364
	private void OnPreCull()
	{
		if (this.spherical != this.spherical_ || this.layer00 != this.layer00_ || this.layer01 != this.layer01_ || this.layer02 != this.layer02_ || this.layer03 != this.layer03_ || this.layer04 != this.layer04_ || this.layer05 != this.layer05_ || this.layer06 != this.layer06_ || this.layer07 != this.layer07_ || this.layer08 != this.layer08_ || this.layer09 != this.layer09_ || this.layer10 != this.layer10_ || this.layer11 != this.layer11_ || this.layer12 != this.layer12_ || this.layer13 != this.layer13_ || this.layer14 != this.layer14_ || this.layer15 != this.layer15_ || this.layer16 != this.layer16_ || this.layer17 != this.layer17_ || this.layer18 != this.layer18_ || this.layer19 != this.layer19_ || this.layer20 != this.layer20_ || this.layer21 != this.layer21_ || this.layer22 != this.layer22_ || this.layer23 != this.layer23_ || this.layer24 != this.layer24_ || this.layer25 != this.layer25_ || this.layer26 != this.layer26_ || this.layer27 != this.layer27_ || this.layer28 != this.layer28_ || this.layer29 != this.layer29_ || this.layer30 != this.layer30_ || this.layer31 != this.layer31_)
		{
			this.Awake();
		}
	}

	// Token: 0x06002F02 RID: 12034 RVA: 0x000B33A8 File Offset: 0x000B15A8
	private static bool Set(ref float m, float v)
	{
		if (m == v)
		{
			return false;
		}
		m = v;
		return true;
	}

	// Token: 0x170009F7 RID: 2551
	public float this[int layer]
	{
		get
		{
			switch (layer)
			{
			case 0:
				return this.layer00;
			case 1:
				return this.layer01;
			case 2:
				return this.layer02;
			case 3:
				return this.layer03;
			case 4:
				return this.layer04;
			case 5:
				return this.layer05;
			case 6:
				return this.layer06;
			case 7:
				return this.layer07;
			case 8:
				return this.layer08;
			case 9:
				return this.layer09;
			case 0xA:
				return this.layer10;
			case 0xB:
				return this.layer11;
			case 0xC:
				return this.layer12;
			case 0xD:
				return this.layer13;
			case 0xE:
				return this.layer14;
			case 0xF:
				return this.layer15;
			case 0x10:
				return this.layer16;
			case 0x11:
				return this.layer17;
			case 0x12:
				return this.layer18;
			case 0x13:
				return this.layer19;
			case 0x14:
				return this.layer20;
			case 0x15:
				return this.layer21;
			case 0x16:
				return this.layer22;
			case 0x17:
				return this.layer23;
			case 0x18:
				return this.layer24;
			case 0x19:
				return this.layer25;
			case 0x1A:
				return this.layer26;
			case 0x1B:
				return this.layer27;
			case 0x1C:
				return this.layer28;
			case 0x1D:
				return this.layer29;
			case 0x1E:
				return this.layer30;
			case 0x1F:
				return this.layer31;
			default:
				throw new global::System.ArgumentOutOfRangeException();
			}
		}
		set
		{
			bool flag;
			switch (layer)
			{
			case 0:
				flag = global::CameraLayerDepths.Set(ref this.layer00, value);
				break;
			case 1:
				flag = global::CameraLayerDepths.Set(ref this.layer01, value);
				break;
			case 2:
				flag = global::CameraLayerDepths.Set(ref this.layer02, value);
				break;
			case 3:
				flag = global::CameraLayerDepths.Set(ref this.layer03, value);
				break;
			case 4:
				flag = global::CameraLayerDepths.Set(ref this.layer04, value);
				break;
			case 5:
				flag = global::CameraLayerDepths.Set(ref this.layer05, value);
				break;
			case 6:
				flag = global::CameraLayerDepths.Set(ref this.layer06, value);
				break;
			case 7:
				flag = global::CameraLayerDepths.Set(ref this.layer07, value);
				break;
			case 8:
				flag = global::CameraLayerDepths.Set(ref this.layer08, value);
				break;
			case 9:
				flag = global::CameraLayerDepths.Set(ref this.layer09, value);
				break;
			case 0xA:
				flag = global::CameraLayerDepths.Set(ref this.layer10, value);
				break;
			case 0xB:
				flag = global::CameraLayerDepths.Set(ref this.layer11, value);
				break;
			case 0xC:
				flag = global::CameraLayerDepths.Set(ref this.layer12, value);
				break;
			case 0xD:
				flag = global::CameraLayerDepths.Set(ref this.layer13, value);
				break;
			case 0xE:
				flag = global::CameraLayerDepths.Set(ref this.layer14, value);
				break;
			case 0xF:
				flag = global::CameraLayerDepths.Set(ref this.layer15, value);
				break;
			case 0x10:
				flag = global::CameraLayerDepths.Set(ref this.layer16, value);
				break;
			case 0x11:
				flag = global::CameraLayerDepths.Set(ref this.layer17, value);
				break;
			case 0x12:
				flag = global::CameraLayerDepths.Set(ref this.layer18, value);
				break;
			case 0x13:
				flag = global::CameraLayerDepths.Set(ref this.layer19, value);
				break;
			case 0x14:
				flag = global::CameraLayerDepths.Set(ref this.layer20, value);
				break;
			case 0x15:
				flag = global::CameraLayerDepths.Set(ref this.layer21, value);
				break;
			case 0x16:
				flag = global::CameraLayerDepths.Set(ref this.layer22, value);
				break;
			case 0x17:
				flag = global::CameraLayerDepths.Set(ref this.layer23, value);
				break;
			case 0x18:
				flag = global::CameraLayerDepths.Set(ref this.layer24, value);
				break;
			case 0x19:
				flag = global::CameraLayerDepths.Set(ref this.layer25, value);
				break;
			case 0x1A:
				flag = global::CameraLayerDepths.Set(ref this.layer26, value);
				break;
			case 0x1B:
				flag = global::CameraLayerDepths.Set(ref this.layer27, value);
				break;
			case 0x1C:
				flag = global::CameraLayerDepths.Set(ref this.layer28, value);
				break;
			case 0x1D:
				flag = global::CameraLayerDepths.Set(ref this.layer29, value);
				break;
			case 0x1E:
				flag = global::CameraLayerDepths.Set(ref this.layer30, value);
				break;
			case 0x1F:
				flag = global::CameraLayerDepths.Set(ref this.layer31, value);
				break;
			default:
				throw new global::System.ArgumentOutOfRangeException();
			}
			if (flag)
			{
				this.Awake();
			}
		}
	}

	// Token: 0x06002F05 RID: 12037 RVA: 0x000B3824 File Offset: 0x000B1A24
	[global::UnityEngine.ContextMenu("Ensure Layer Depths Set")]
	private void EnsureLayerDepthsSet()
	{
		float[] layerCullDistances = base.camera.layerCullDistances;
		if (layerCullDistances == null)
		{
			this.Awake();
		}
		else if (layerCullDistances.Length != 0x20)
		{
			this.Awake();
		}
		else
		{
			bool flag = false;
			for (int i = 0; i < 0x20; i++)
			{
				if (layerCullDistances[i] != this[i])
				{
					flag = true;
					this.Awake();
					break;
				}
			}
			if (!flag)
			{
				return;
			}
		}
		if (this.spherical != base.camera.layerCullSpherical)
		{
			this.Awake();
			global::UnityEngine.Debug.Log("Layer Depths Were Not Set", this);
			return;
		}
	}

	// Token: 0x06002F06 RID: 12038 RVA: 0x000B38D0 File Offset: 0x000B1AD0
	private void Awake()
	{
		this.layer00_ = this.layer00;
		this.layer01_ = this.layer01;
		this.layer02_ = this.layer02;
		this.layer03_ = this.layer03;
		this.layer04_ = this.layer04;
		this.layer05_ = this.layer05;
		this.layer06_ = this.layer06;
		this.layer07_ = this.layer07;
		this.layer08_ = this.layer08;
		this.layer09_ = this.layer09;
		this.layer10_ = this.layer10;
		this.layer11_ = this.layer11;
		this.layer12_ = this.layer12;
		this.layer13_ = this.layer13;
		this.layer14_ = this.layer14;
		this.layer15_ = this.layer15;
		this.layer16_ = this.layer16;
		this.layer17_ = this.layer17;
		this.layer18_ = this.layer18;
		this.layer19_ = this.layer19;
		this.layer20_ = this.layer20;
		this.layer21_ = this.layer21;
		this.layer22_ = this.layer22;
		this.layer23_ = this.layer23;
		this.layer24_ = this.layer24;
		this.layer25_ = this.layer25;
		this.layer26_ = this.layer26;
		this.layer27_ = this.layer27;
		this.layer28_ = this.layer28;
		this.layer29_ = this.layer29;
		this.layer30_ = this.layer30;
		this.layer31_ = this.layer31;
		float[] layerCullDistances = new float[]
		{
			this.layer00,
			this.layer01,
			this.layer02,
			this.layer03,
			this.layer04,
			this.layer05,
			this.layer06,
			this.layer07,
			this.layer08,
			this.layer09,
			this.layer10,
			this.layer11,
			this.layer12,
			this.layer13,
			this.layer14,
			this.layer15,
			this.layer16,
			this.layer17,
			this.layer18,
			this.layer19,
			this.layer20,
			this.layer21,
			this.layer22,
			this.layer23,
			this.layer24,
			this.layer25,
			this.layer26,
			this.layer27,
			this.layer28,
			this.layer29,
			this.layer30,
			this.layer31
		};
		base.camera.layerCullDistances = layerCullDistances;
		base.camera.layerCullSpherical = this.spherical;
	}

	// Token: 0x040018A5 RID: 6309
	[global::UnityEngine.SerializeField]
	private float layer00;

	// Token: 0x040018A6 RID: 6310
	[global::UnityEngine.SerializeField]
	private float layer01;

	// Token: 0x040018A7 RID: 6311
	[global::UnityEngine.SerializeField]
	private float layer02;

	// Token: 0x040018A8 RID: 6312
	[global::UnityEngine.SerializeField]
	private float layer03;

	// Token: 0x040018A9 RID: 6313
	[global::UnityEngine.SerializeField]
	private float layer04;

	// Token: 0x040018AA RID: 6314
	[global::UnityEngine.SerializeField]
	private float layer05;

	// Token: 0x040018AB RID: 6315
	[global::UnityEngine.SerializeField]
	private float layer06;

	// Token: 0x040018AC RID: 6316
	[global::UnityEngine.SerializeField]
	private float layer07;

	// Token: 0x040018AD RID: 6317
	[global::UnityEngine.SerializeField]
	private float layer08;

	// Token: 0x040018AE RID: 6318
	[global::UnityEngine.SerializeField]
	private float layer09;

	// Token: 0x040018AF RID: 6319
	[global::UnityEngine.SerializeField]
	private float layer10;

	// Token: 0x040018B0 RID: 6320
	[global::UnityEngine.SerializeField]
	private float layer11;

	// Token: 0x040018B1 RID: 6321
	[global::UnityEngine.SerializeField]
	private float layer12;

	// Token: 0x040018B2 RID: 6322
	[global::UnityEngine.SerializeField]
	private float layer13;

	// Token: 0x040018B3 RID: 6323
	[global::UnityEngine.SerializeField]
	private float layer14;

	// Token: 0x040018B4 RID: 6324
	[global::UnityEngine.SerializeField]
	private float layer15;

	// Token: 0x040018B5 RID: 6325
	[global::UnityEngine.SerializeField]
	private float layer16;

	// Token: 0x040018B6 RID: 6326
	[global::UnityEngine.SerializeField]
	private float layer17;

	// Token: 0x040018B7 RID: 6327
	[global::UnityEngine.SerializeField]
	private float layer18;

	// Token: 0x040018B8 RID: 6328
	[global::UnityEngine.SerializeField]
	private float layer19;

	// Token: 0x040018B9 RID: 6329
	[global::UnityEngine.SerializeField]
	private float layer20;

	// Token: 0x040018BA RID: 6330
	[global::UnityEngine.SerializeField]
	private float layer21;

	// Token: 0x040018BB RID: 6331
	[global::UnityEngine.SerializeField]
	private float layer22;

	// Token: 0x040018BC RID: 6332
	[global::UnityEngine.SerializeField]
	private float layer23;

	// Token: 0x040018BD RID: 6333
	[global::UnityEngine.SerializeField]
	private float layer24;

	// Token: 0x040018BE RID: 6334
	[global::UnityEngine.SerializeField]
	private float layer25;

	// Token: 0x040018BF RID: 6335
	[global::UnityEngine.SerializeField]
	private float layer26;

	// Token: 0x040018C0 RID: 6336
	[global::UnityEngine.SerializeField]
	private float layer27;

	// Token: 0x040018C1 RID: 6337
	[global::UnityEngine.SerializeField]
	private float layer28;

	// Token: 0x040018C2 RID: 6338
	[global::UnityEngine.SerializeField]
	private float layer29;

	// Token: 0x040018C3 RID: 6339
	[global::UnityEngine.SerializeField]
	private float layer30;

	// Token: 0x040018C4 RID: 6340
	[global::UnityEngine.SerializeField]
	private float layer31;

	// Token: 0x040018C5 RID: 6341
	[global::UnityEngine.SerializeField]
	private bool spherical;

	// Token: 0x040018C6 RID: 6342
	[global::System.NonSerialized]
	private float layer00_;

	// Token: 0x040018C7 RID: 6343
	[global::System.NonSerialized]
	private float layer01_;

	// Token: 0x040018C8 RID: 6344
	[global::System.NonSerialized]
	private float layer02_;

	// Token: 0x040018C9 RID: 6345
	[global::System.NonSerialized]
	private float layer03_;

	// Token: 0x040018CA RID: 6346
	[global::System.NonSerialized]
	private float layer04_;

	// Token: 0x040018CB RID: 6347
	[global::System.NonSerialized]
	private float layer05_;

	// Token: 0x040018CC RID: 6348
	[global::System.NonSerialized]
	private float layer06_;

	// Token: 0x040018CD RID: 6349
	[global::System.NonSerialized]
	private float layer07_;

	// Token: 0x040018CE RID: 6350
	[global::System.NonSerialized]
	private float layer08_;

	// Token: 0x040018CF RID: 6351
	[global::System.NonSerialized]
	private float layer09_;

	// Token: 0x040018D0 RID: 6352
	[global::System.NonSerialized]
	private float layer10_;

	// Token: 0x040018D1 RID: 6353
	[global::System.NonSerialized]
	private float layer11_;

	// Token: 0x040018D2 RID: 6354
	[global::System.NonSerialized]
	private float layer12_;

	// Token: 0x040018D3 RID: 6355
	[global::System.NonSerialized]
	private float layer13_;

	// Token: 0x040018D4 RID: 6356
	[global::System.NonSerialized]
	private float layer14_;

	// Token: 0x040018D5 RID: 6357
	[global::System.NonSerialized]
	private float layer15_;

	// Token: 0x040018D6 RID: 6358
	[global::System.NonSerialized]
	private float layer16_;

	// Token: 0x040018D7 RID: 6359
	[global::System.NonSerialized]
	private float layer17_;

	// Token: 0x040018D8 RID: 6360
	[global::System.NonSerialized]
	private float layer18_;

	// Token: 0x040018D9 RID: 6361
	[global::System.NonSerialized]
	private float layer19_;

	// Token: 0x040018DA RID: 6362
	[global::System.NonSerialized]
	private float layer20_;

	// Token: 0x040018DB RID: 6363
	[global::System.NonSerialized]
	private float layer21_;

	// Token: 0x040018DC RID: 6364
	[global::System.NonSerialized]
	private float layer22_;

	// Token: 0x040018DD RID: 6365
	[global::System.NonSerialized]
	private float layer23_;

	// Token: 0x040018DE RID: 6366
	[global::System.NonSerialized]
	private float layer24_;

	// Token: 0x040018DF RID: 6367
	[global::System.NonSerialized]
	private float layer25_;

	// Token: 0x040018E0 RID: 6368
	[global::System.NonSerialized]
	private float layer26_;

	// Token: 0x040018E1 RID: 6369
	[global::System.NonSerialized]
	private float layer27_;

	// Token: 0x040018E2 RID: 6370
	[global::System.NonSerialized]
	private float layer28_;

	// Token: 0x040018E3 RID: 6371
	[global::System.NonSerialized]
	private float layer29_;

	// Token: 0x040018E4 RID: 6372
	[global::System.NonSerialized]
	private float layer30_;

	// Token: 0x040018E5 RID: 6373
	[global::System.NonSerialized]
	private float layer31_;

	// Token: 0x040018E6 RID: 6374
	[global::System.NonSerialized]
	private bool spherical_;
}

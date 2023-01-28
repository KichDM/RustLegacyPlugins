using System;
using UnityEngine;

// Token: 0x0200027B RID: 635
public struct AABBox : global::System.IEquatable<global::AABBox>
{
	// Token: 0x0600166F RID: 5743 RVA: 0x0004AD64 File Offset: 0x00048F64
	public AABBox(global::UnityEngine.Vector3 min, global::UnityEngine.Vector3 max)
	{
		if (min.x > max.x)
		{
			this.m.x = max.x;
			this.M.x = min.x;
		}
		else
		{
			this.m.x = min.x;
			this.M.x = max.x;
		}
		if (min.y > max.y)
		{
			this.m.y = max.y;
			this.M.y = min.y;
		}
		else
		{
			this.m.y = min.y;
			this.M.y = max.y;
		}
		if (min.z > max.z)
		{
			this.m.z = max.z;
			this.M.z = min.z;
		}
		else
		{
			this.m.z = min.z;
			this.M.z = max.z;
		}
	}

	// Token: 0x06001670 RID: 5744 RVA: 0x0004AE94 File Offset: 0x00049094
	public AABBox(ref global::UnityEngine.Vector3 min, ref global::UnityEngine.Vector3 max)
	{
		if (min.x > max.x)
		{
			this.m.x = max.x;
			this.M.x = min.x;
		}
		else
		{
			this.m.x = min.x;
			this.M.x = max.x;
		}
		if (min.y > max.y)
		{
			this.m.y = max.y;
			this.M.y = min.y;
		}
		else
		{
			this.m.y = min.y;
			this.M.y = max.y;
		}
		if (min.z > max.z)
		{
			this.m.z = max.z;
			this.M.z = min.z;
		}
		else
		{
			this.m.z = min.z;
			this.M.z = max.z;
		}
	}

	// Token: 0x06001671 RID: 5745 RVA: 0x0004AFB0 File Offset: 0x000491B0
	public AABBox(ref global::UnityEngine.Vector3 center)
	{
		this.m.x = (this.M.x = center.x);
		this.m.y = (this.M.y = center.y);
		this.m.z = (this.M.z = center.z);
	}

	// Token: 0x06001672 RID: 5746 RVA: 0x0004B01C File Offset: 0x0004921C
	public AABBox(global::UnityEngine.Vector3 center)
	{
		this.m.x = (this.M.x = center.x);
		this.m.y = (this.M.y = center.y);
		this.m.z = (this.M.z = center.z);
	}

	// Token: 0x06001673 RID: 5747 RVA: 0x0004B08C File Offset: 0x0004928C
	public AABBox(global::UnityEngine.Bounds bounds)
	{
		this = new global::AABBox(bounds.min, bounds.max);
	}

	// Token: 0x06001674 RID: 5748 RVA: 0x0004B0A4 File Offset: 0x000492A4
	public AABBox(ref global::UnityEngine.Bounds bounds)
	{
		this = new global::AABBox(bounds.min, bounds.max);
	}

	// Token: 0x1700063E RID: 1598
	// (get) Token: 0x06001675 RID: 5749 RVA: 0x0004B0B8 File Offset: 0x000492B8
	public global::UnityEngine.Vector3 a
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m.x;
			result.y = this.m.y;
			result.z = this.m.z;
			return result;
		}
	}

	// Token: 0x1700063F RID: 1599
	// (get) Token: 0x06001676 RID: 5750 RVA: 0x0004B0FC File Offset: 0x000492FC
	public global::UnityEngine.Vector3 b
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m.x;
			result.y = this.m.y;
			result.z = this.M.z;
			return result;
		}
	}

	// Token: 0x17000640 RID: 1600
	// (get) Token: 0x06001677 RID: 5751 RVA: 0x0004B140 File Offset: 0x00049340
	public global::UnityEngine.Vector3 c
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.M.x;
			result.y = this.m.y;
			result.z = this.m.z;
			return result;
		}
	}

	// Token: 0x17000641 RID: 1601
	// (get) Token: 0x06001678 RID: 5752 RVA: 0x0004B184 File Offset: 0x00049384
	public global::UnityEngine.Vector3 d
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.M.x;
			result.y = this.m.y;
			result.z = this.M.z;
			return result;
		}
	}

	// Token: 0x17000642 RID: 1602
	// (get) Token: 0x06001679 RID: 5753 RVA: 0x0004B1C8 File Offset: 0x000493C8
	public global::UnityEngine.Vector3 e
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m.x;
			result.y = this.M.y;
			result.z = this.m.z;
			return result;
		}
	}

	// Token: 0x17000643 RID: 1603
	// (get) Token: 0x0600167A RID: 5754 RVA: 0x0004B20C File Offset: 0x0004940C
	public global::UnityEngine.Vector3 f
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m.x;
			result.y = this.M.y;
			result.z = this.M.z;
			return result;
		}
	}

	// Token: 0x17000644 RID: 1604
	// (get) Token: 0x0600167B RID: 5755 RVA: 0x0004B250 File Offset: 0x00049450
	public global::UnityEngine.Vector3 g
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.M.x;
			result.y = this.M.y;
			result.z = this.m.z;
			return result;
		}
	}

	// Token: 0x17000645 RID: 1605
	// (get) Token: 0x0600167C RID: 5756 RVA: 0x0004B294 File Offset: 0x00049494
	public global::UnityEngine.Vector3 h
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.M.x;
			result.y = this.M.y;
			result.z = this.M.z;
			return result;
		}
	}

	// Token: 0x17000646 RID: 1606
	// (get) Token: 0x0600167D RID: 5757 RVA: 0x0004B2D8 File Offset: 0x000494D8
	public global::UnityEngine.Vector3 line00
	{
		get
		{
			return this.a;
		}
	}

	// Token: 0x17000647 RID: 1607
	// (get) Token: 0x0600167E RID: 5758 RVA: 0x0004B2E0 File Offset: 0x000494E0
	public global::UnityEngine.Vector3 line01
	{
		get
		{
			return this.b;
		}
	}

	// Token: 0x17000648 RID: 1608
	// (get) Token: 0x0600167F RID: 5759 RVA: 0x0004B2E8 File Offset: 0x000494E8
	public global::UnityEngine.Vector3 line10
	{
		get
		{
			return this.a;
		}
	}

	// Token: 0x17000649 RID: 1609
	// (get) Token: 0x06001680 RID: 5760 RVA: 0x0004B2F0 File Offset: 0x000494F0
	public global::UnityEngine.Vector3 line11
	{
		get
		{
			return this.c;
		}
	}

	// Token: 0x1700064A RID: 1610
	// (get) Token: 0x06001681 RID: 5761 RVA: 0x0004B2F8 File Offset: 0x000494F8
	public global::UnityEngine.Vector3 line20
	{
		get
		{
			return this.a;
		}
	}

	// Token: 0x1700064B RID: 1611
	// (get) Token: 0x06001682 RID: 5762 RVA: 0x0004B300 File Offset: 0x00049500
	public global::UnityEngine.Vector3 line21
	{
		get
		{
			return this.e;
		}
	}

	// Token: 0x1700064C RID: 1612
	// (get) Token: 0x06001683 RID: 5763 RVA: 0x0004B308 File Offset: 0x00049508
	public global::UnityEngine.Vector3 line30
	{
		get
		{
			return this.b;
		}
	}

	// Token: 0x1700064D RID: 1613
	// (get) Token: 0x06001684 RID: 5764 RVA: 0x0004B310 File Offset: 0x00049510
	public global::UnityEngine.Vector3 line31
	{
		get
		{
			return this.d;
		}
	}

	// Token: 0x1700064E RID: 1614
	// (get) Token: 0x06001685 RID: 5765 RVA: 0x0004B318 File Offset: 0x00049518
	public global::UnityEngine.Vector3 line40
	{
		get
		{
			return this.b;
		}
	}

	// Token: 0x1700064F RID: 1615
	// (get) Token: 0x06001686 RID: 5766 RVA: 0x0004B320 File Offset: 0x00049520
	public global::UnityEngine.Vector3 line41
	{
		get
		{
			return this.f;
		}
	}

	// Token: 0x17000650 RID: 1616
	// (get) Token: 0x06001687 RID: 5767 RVA: 0x0004B328 File Offset: 0x00049528
	public global::UnityEngine.Vector3 line50
	{
		get
		{
			return this.c;
		}
	}

	// Token: 0x17000651 RID: 1617
	// (get) Token: 0x06001688 RID: 5768 RVA: 0x0004B330 File Offset: 0x00049530
	public global::UnityEngine.Vector3 line51
	{
		get
		{
			return this.d;
		}
	}

	// Token: 0x17000652 RID: 1618
	// (get) Token: 0x06001689 RID: 5769 RVA: 0x0004B338 File Offset: 0x00049538
	public global::UnityEngine.Vector3 line60
	{
		get
		{
			return this.c;
		}
	}

	// Token: 0x17000653 RID: 1619
	// (get) Token: 0x0600168A RID: 5770 RVA: 0x0004B340 File Offset: 0x00049540
	public global::UnityEngine.Vector3 line61
	{
		get
		{
			return this.g;
		}
	}

	// Token: 0x17000654 RID: 1620
	// (get) Token: 0x0600168B RID: 5771 RVA: 0x0004B348 File Offset: 0x00049548
	public global::UnityEngine.Vector3 line70
	{
		get
		{
			return this.d;
		}
	}

	// Token: 0x17000655 RID: 1621
	// (get) Token: 0x0600168C RID: 5772 RVA: 0x0004B350 File Offset: 0x00049550
	public global::UnityEngine.Vector3 line71
	{
		get
		{
			return this.h;
		}
	}

	// Token: 0x17000656 RID: 1622
	// (get) Token: 0x0600168D RID: 5773 RVA: 0x0004B358 File Offset: 0x00049558
	public global::UnityEngine.Vector3 line80
	{
		get
		{
			return this.e;
		}
	}

	// Token: 0x17000657 RID: 1623
	// (get) Token: 0x0600168E RID: 5774 RVA: 0x0004B360 File Offset: 0x00049560
	public global::UnityEngine.Vector3 line81
	{
		get
		{
			return this.f;
		}
	}

	// Token: 0x17000658 RID: 1624
	// (get) Token: 0x0600168F RID: 5775 RVA: 0x0004B368 File Offset: 0x00049568
	public global::UnityEngine.Vector3 line90
	{
		get
		{
			return this.e;
		}
	}

	// Token: 0x17000659 RID: 1625
	// (get) Token: 0x06001690 RID: 5776 RVA: 0x0004B370 File Offset: 0x00049570
	public global::UnityEngine.Vector3 line91
	{
		get
		{
			return this.g;
		}
	}

	// Token: 0x1700065A RID: 1626
	// (get) Token: 0x06001691 RID: 5777 RVA: 0x0004B378 File Offset: 0x00049578
	public global::UnityEngine.Vector3 lineA0
	{
		get
		{
			return this.f;
		}
	}

	// Token: 0x1700065B RID: 1627
	// (get) Token: 0x06001692 RID: 5778 RVA: 0x0004B380 File Offset: 0x00049580
	public global::UnityEngine.Vector3 lineA1
	{
		get
		{
			return this.h;
		}
	}

	// Token: 0x1700065C RID: 1628
	// (get) Token: 0x06001693 RID: 5779 RVA: 0x0004B388 File Offset: 0x00049588
	public global::UnityEngine.Vector3 lineB0
	{
		get
		{
			return this.g;
		}
	}

	// Token: 0x1700065D RID: 1629
	// (get) Token: 0x06001694 RID: 5780 RVA: 0x0004B390 File Offset: 0x00049590
	public global::UnityEngine.Vector3 lineB1
	{
		get
		{
			return this.h;
		}
	}

	// Token: 0x06001695 RID: 5781 RVA: 0x0004B398 File Offset: 0x00049598
	public void SetMinMax(ref global::UnityEngine.Vector3 min, ref global::UnityEngine.Vector3 max)
	{
		if (min.x > max.x)
		{
			this.m.x = max.x;
			this.M.x = min.x;
		}
		else
		{
			this.m.x = min.x;
			this.M.x = max.x;
		}
		if (min.y > max.y)
		{
			this.m.y = max.y;
			this.M.y = min.y;
		}
		else
		{
			this.m.y = min.y;
			this.M.y = max.y;
		}
		if (min.z > max.z)
		{
			this.m.z = max.z;
			this.M.z = min.z;
		}
		else
		{
			this.m.z = min.z;
			this.M.z = max.z;
		}
	}

	// Token: 0x06001696 RID: 5782 RVA: 0x0004B4B4 File Offset: 0x000496B4
	public void SetMinMax(ref global::UnityEngine.Vector3 min, global::UnityEngine.Vector3 max)
	{
		if (min.x > max.x)
		{
			this.m.x = max.x;
			this.M.x = min.x;
		}
		else
		{
			this.m.x = min.x;
			this.M.x = max.x;
		}
		if (min.y > max.y)
		{
			this.m.y = max.y;
			this.M.y = min.y;
		}
		else
		{
			this.m.y = min.y;
			this.M.y = max.y;
		}
		if (min.z > max.z)
		{
			this.m.z = max.z;
			this.M.z = min.z;
		}
		else
		{
			this.m.z = min.z;
			this.M.z = max.z;
		}
	}

	// Token: 0x06001697 RID: 5783 RVA: 0x0004B5D8 File Offset: 0x000497D8
	public void SetMinMax(global::UnityEngine.Vector3 min, ref global::UnityEngine.Vector3 max)
	{
		if (min.x > max.x)
		{
			this.m.x = max.x;
			this.M.x = min.x;
		}
		else
		{
			this.m.x = min.x;
			this.M.x = max.x;
		}
		if (min.y > max.y)
		{
			this.m.y = max.y;
			this.M.y = min.y;
		}
		else
		{
			this.m.y = min.y;
			this.M.y = max.y;
		}
		if (min.z > max.z)
		{
			this.m.z = max.z;
			this.M.z = min.z;
		}
		else
		{
			this.m.z = min.z;
			this.M.z = max.z;
		}
	}

	// Token: 0x06001698 RID: 5784 RVA: 0x0004B6FC File Offset: 0x000498FC
	public void SetMinMax(global::UnityEngine.Vector3 min, global::UnityEngine.Vector3 max)
	{
		if (min.x > max.x)
		{
			this.m.x = max.x;
			this.M.x = min.x;
		}
		else
		{
			this.m.x = min.x;
			this.M.x = max.x;
		}
		if (min.y > max.y)
		{
			this.m.y = max.y;
			this.M.y = min.y;
		}
		else
		{
			this.m.y = min.y;
			this.M.y = max.y;
		}
		if (min.z > max.z)
		{
			this.m.z = max.z;
			this.M.z = min.z;
		}
		else
		{
			this.m.z = min.z;
			this.M.z = max.z;
		}
	}

	// Token: 0x06001699 RID: 5785 RVA: 0x0004B82C File Offset: 0x00049A2C
	public void SetMinMax(global::UnityEngine.Bounds bounds)
	{
		global::UnityEngine.Vector3 min = bounds.min;
		global::UnityEngine.Vector3 max = bounds.max;
		if (min.x > max.x)
		{
			this.m.x = max.x;
			this.M.x = min.x;
		}
		else
		{
			this.m.x = min.x;
			this.M.x = max.x;
		}
		if (min.y > max.y)
		{
			this.m.y = max.y;
			this.M.y = min.y;
		}
		else
		{
			this.m.y = min.y;
			this.M.y = max.y;
		}
		if (min.z > max.z)
		{
			this.m.z = max.z;
			this.M.z = min.z;
		}
		else
		{
			this.m.z = min.z;
			this.M.z = max.z;
		}
	}

	// Token: 0x0600169A RID: 5786 RVA: 0x0004B96C File Offset: 0x00049B6C
	public void SetMinMax(ref global::UnityEngine.Bounds bounds)
	{
		global::UnityEngine.Vector3 min = bounds.min;
		global::UnityEngine.Vector3 max = bounds.max;
		if (min.x > max.x)
		{
			this.m.x = max.x;
			this.M.x = min.x;
		}
		else
		{
			this.m.x = min.x;
			this.M.x = max.x;
		}
		if (min.y > max.y)
		{
			this.m.y = max.y;
			this.M.y = min.y;
		}
		else
		{
			this.m.y = min.y;
			this.M.y = max.y;
		}
		if (min.z > max.z)
		{
			this.m.z = max.z;
			this.M.z = min.z;
		}
		else
		{
			this.m.z = min.z;
			this.M.z = max.z;
		}
	}

	// Token: 0x0600169B RID: 5787 RVA: 0x0004BAA8 File Offset: 0x00049CA8
	public void EnsureMinMax()
	{
		if (this.m.x > this.M.x)
		{
			float x = this.m.x;
			this.m.x = this.M.x;
			this.M.x = x;
		}
		if (this.m.y > this.M.y)
		{
			float y = this.m.y;
			this.m.y = this.M.y;
			this.M.y = y;
		}
		if (this.m.z > this.M.z)
		{
			float z = this.m.z;
			this.m.z = this.M.z;
			this.M.z = z;
		}
	}

	// Token: 0x1700065E RID: 1630
	// (get) Token: 0x0600169C RID: 5788 RVA: 0x0004BB90 File Offset: 0x00049D90
	public global::UnityEngine.Vector3 min
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = ((this.M.x >= this.m.x) ? this.m.x : this.M.x);
			result.y = ((this.M.y >= this.m.y) ? this.m.y : this.M.y);
			result.z = ((this.M.z >= this.m.z) ? this.m.z : this.M.z);
			return result;
		}
	}

	// Token: 0x1700065F RID: 1631
	// (get) Token: 0x0600169D RID: 5789 RVA: 0x0004BC58 File Offset: 0x00049E58
	public global::UnityEngine.Vector3 max
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = ((this.m.x <= this.M.x) ? this.M.x : this.m.x);
			result.y = ((this.m.y <= this.M.y) ? this.M.y : this.m.y);
			result.z = ((this.m.z <= this.M.z) ? this.M.z : this.m.z);
			return result;
		}
	}

	// Token: 0x17000660 RID: 1632
	// (get) Token: 0x0600169E RID: 5790 RVA: 0x0004BD20 File Offset: 0x00049F20
	// (set) Token: 0x0600169F RID: 5791 RVA: 0x0004BE30 File Offset: 0x0004A030
	public global::UnityEngine.Vector3 size
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = ((this.M.x >= this.m.x) ? (this.M.x - this.m.x) : (this.m.x - this.M.x));
			result.y = ((this.M.y >= this.m.y) ? (this.M.y - this.m.y) : (this.m.y - this.M.y));
			result.z = ((this.M.z >= this.m.z) ? (this.M.z - this.m.z) : (this.m.z - this.M.z));
			return result;
		}
		set
		{
			global::UnityEngine.Vector3 vector;
			vector.x = this.m.x + (this.M.x - this.m.x) * 0.5f;
			vector.y = this.m.y + (this.M.y - this.m.y) * 0.5f;
			vector.z = this.m.z + (this.M.z - this.m.z) * 0.5f;
			if (value.x < 0f)
			{
				value.x *= -0.5f;
			}
			else
			{
				value.x *= 0.5f;
			}
			this.m.x = vector.x - value.x;
			this.M.x = vector.x + value.x;
			if (value.y < 0f)
			{
				value.y *= -0.5f;
			}
			else
			{
				value.y *= 0.5f;
			}
			this.m.y = vector.y - value.y;
			this.M.y = vector.y + value.y;
			if (value.z < 0f)
			{
				value.z *= -0.5f;
			}
			else
			{
				value.z *= 0.5f;
			}
			this.m.z = vector.z - value.z;
			this.M.z = vector.z + value.z;
		}
	}

	// Token: 0x17000661 RID: 1633
	// (get) Token: 0x060016A0 RID: 5792 RVA: 0x0004C024 File Offset: 0x0004A224
	// (set) Token: 0x060016A1 RID: 5793 RVA: 0x0004C0C4 File Offset: 0x0004A2C4
	public global::UnityEngine.Vector3 center
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = this.m.x + (this.M.x - this.m.x) * 0.5f;
			result.y = this.m.y + (this.M.y - this.m.y) * 0.5f;
			result.z = this.m.z + (this.M.z - this.m.z) * 0.5f;
			return result;
		}
		set
		{
			float num = value.x - (this.m.x + (this.M.x - this.m.x) * 0.5f);
			this.m.x = this.m.x + num;
			this.M.x = this.M.x + num;
			num = value.y - (this.m.y + (this.M.y - this.m.y) * 0.5f);
			this.m.y = this.m.y + num;
			this.M.y = this.M.y + num;
			num = value.z - (this.m.z + (this.M.z - this.m.z) * 0.5f);
			this.m.z = this.m.z + num;
			this.M.z = this.M.z + num;
		}
	}

	// Token: 0x17000662 RID: 1634
	// (get) Token: 0x060016A2 RID: 5794 RVA: 0x0004C1DC File Offset: 0x0004A3DC
	public bool empty
	{
		get
		{
			return this.m.x == this.M.x && this.m.y == this.M.y && this.m.z == this.M.z;
		}
	}

	// Token: 0x17000663 RID: 1635
	// (get) Token: 0x060016A3 RID: 5795 RVA: 0x0004C23C File Offset: 0x0004A43C
	public float volume
	{
		get
		{
			if (this.M.x == this.m.x || this.M.y == this.m.y || this.M.z == this.m.z)
			{
				return 0f;
			}
			if (this.M.x < this.m.x)
			{
				if (this.M.y < this.m.y)
				{
					if (this.M.z < this.m.z)
					{
						return (this.m.x - this.M.x) * (this.m.y - this.M.y) * (this.m.z - this.M.z);
					}
					return (this.m.x - this.M.x) * (this.m.y - this.M.y) * (this.M.z - this.m.z);
				}
				else
				{
					if (this.M.z < this.m.z)
					{
						return (this.m.x - this.M.x) * (this.M.y - this.m.y) * (this.m.z - this.M.z);
					}
					return (this.m.x - this.M.x) * (this.M.y - this.m.y) * (this.M.z - this.m.z);
				}
			}
			else if (this.M.y < this.m.y)
			{
				if (this.M.z < this.m.z)
				{
					return (this.M.x - this.m.x) * (this.m.y - this.M.y) * (this.m.z - this.M.z);
				}
				return (this.M.x - this.m.x) * (this.m.y - this.M.y) * (this.M.z - this.m.z);
			}
			else
			{
				if (this.M.z < this.m.z)
				{
					return (this.M.x - this.m.x) * (this.M.y - this.m.y) * (this.m.z - this.M.z);
				}
				return (this.M.x - this.m.x) * (this.M.y - this.m.y) * (this.M.z - this.m.z);
			}
		}
	}

	// Token: 0x17000664 RID: 1636
	// (get) Token: 0x060016A4 RID: 5796 RVA: 0x0004C59C File Offset: 0x0004A79C
	public float surfaceArea
	{
		get
		{
			global::UnityEngine.Vector3 vector;
			vector.x = ((this.M.x >= this.m.x) ? (this.M.x - this.m.x) : (this.m.x - this.M.x));
			vector.y = ((this.M.y >= this.m.y) ? (this.M.y - this.m.y) : (this.m.y - this.M.y));
			vector.z = ((this.M.z >= this.m.z) ? (this.M.z - this.m.z) : (this.m.z - this.M.z));
			return 2f * vector.x * vector.y + 2f * vector.y * vector.z + 2f * vector.x * vector.z;
		}
	}

	// Token: 0x060016A5 RID: 5797 RVA: 0x0004C6EC File Offset: 0x0004A8EC
	public void Encapsulate(ref global::UnityEngine.Vector3 v)
	{
		if (v.x < this.m.x)
		{
			this.m.x = v.x;
		}
		if (v.x > this.M.x)
		{
			this.M.x = v.x;
		}
		if (v.y < this.m.y)
		{
			this.m.y = v.y;
		}
		if (v.y > this.M.y)
		{
			this.M.y = v.y;
		}
		if (v.z < this.m.z)
		{
			this.m.z = v.z;
		}
		if (v.z > this.M.z)
		{
			this.M.z = v.z;
		}
	}

	// Token: 0x060016A6 RID: 5798 RVA: 0x0004C7E4 File Offset: 0x0004A9E4
	public void Encapsulate(global::UnityEngine.Vector3 v)
	{
		if (v.x < this.m.x)
		{
			this.m.x = v.x;
		}
		if (v.x > this.M.x)
		{
			this.M.x = v.x;
		}
		if (v.y < this.m.y)
		{
			this.m.y = v.y;
		}
		if (v.y > this.M.y)
		{
			this.M.y = v.y;
		}
		if (v.z < this.m.z)
		{
			this.m.z = v.z;
		}
		if (v.z > this.M.z)
		{
			this.M.z = v.z;
		}
	}

	// Token: 0x060016A7 RID: 5799 RVA: 0x0004C8E8 File Offset: 0x0004AAE8
	public void Encapsulate(ref global::AABBox v)
	{
		if (v.M.x < v.m.x)
		{
			if (v.M.x < this.m.x)
			{
				this.m.x = v.M.x;
			}
			if (v.m.x > this.M.x)
			{
				this.M.x = v.m.x;
			}
		}
		else
		{
			if (v.m.x < this.m.x)
			{
				this.m.x = v.m.x;
			}
			if (v.M.x > this.M.x)
			{
				this.M.x = v.M.x;
			}
		}
		if (v.M.y < v.m.y)
		{
			if (v.M.y < this.m.y)
			{
				this.m.y = v.M.y;
			}
			if (v.m.y > this.M.y)
			{
				this.M.y = v.m.y;
			}
		}
		else
		{
			if (v.m.y < this.m.y)
			{
				this.m.y = v.m.y;
			}
			if (v.M.y > this.M.y)
			{
				this.M.y = v.M.y;
			}
		}
		if (v.M.z < v.m.z)
		{
			if (v.M.z < this.m.z)
			{
				this.m.z = v.M.z;
			}
			if (v.m.z > this.M.z)
			{
				this.M.z = v.m.z;
			}
		}
		else
		{
			if (v.m.z < this.m.z)
			{
				this.m.z = v.m.z;
			}
			if (v.M.z > this.M.z)
			{
				this.M.z = v.M.z;
			}
		}
	}

	// Token: 0x060016A8 RID: 5800 RVA: 0x0004CBA4 File Offset: 0x0004ADA4
	public void Encapsulate(global::AABBox v)
	{
		if (v.M.x < v.m.x)
		{
			if (v.M.x < this.m.x)
			{
				this.m.x = v.M.x;
			}
			if (v.m.x > this.M.x)
			{
				this.M.x = v.m.x;
			}
		}
		else
		{
			if (v.m.x < this.m.x)
			{
				this.m.x = v.m.x;
			}
			if (v.M.x > this.M.x)
			{
				this.M.x = v.M.x;
			}
		}
		if (v.M.y < v.m.y)
		{
			if (v.M.y < this.m.y)
			{
				this.m.y = v.M.y;
			}
			if (v.m.y > this.M.y)
			{
				this.M.y = v.m.y;
			}
		}
		else
		{
			if (v.m.y < this.m.y)
			{
				this.m.y = v.m.y;
			}
			if (v.M.y > this.M.y)
			{
				this.M.y = v.M.y;
			}
		}
		if (v.M.z < v.m.z)
		{
			if (v.M.z < this.m.z)
			{
				this.m.z = v.M.z;
			}
			if (v.m.z > this.M.z)
			{
				this.M.z = v.m.z;
			}
		}
		else
		{
			if (v.m.z < this.m.z)
			{
				this.m.z = v.m.z;
			}
			if (v.M.z > this.M.z)
			{
				this.M.z = v.M.z;
			}
		}
	}

	// Token: 0x060016A9 RID: 5801 RVA: 0x0004CE7C File Offset: 0x0004B07C
	public void Encapsulate(ref global::UnityEngine.Vector3 min, ref global::UnityEngine.Vector3 max)
	{
		if (max.x < min.x)
		{
			if (max.x < this.m.x)
			{
				this.m.x = max.x;
			}
			if (min.x > this.M.x)
			{
				this.M.x = min.x;
			}
		}
		else
		{
			if (min.x < this.m.x)
			{
				this.m.x = min.x;
			}
			if (max.x > this.M.x)
			{
				this.M.x = max.x;
			}
		}
		if (max.y < min.y)
		{
			if (max.y < this.m.y)
			{
				this.m.y = max.y;
			}
			if (min.y > this.M.y)
			{
				this.M.y = min.y;
			}
		}
		else
		{
			if (min.y < this.m.y)
			{
				this.m.y = min.y;
			}
			if (max.y > this.M.y)
			{
				this.M.y = max.y;
			}
		}
		if (max.z < min.z)
		{
			if (max.z < this.m.z)
			{
				this.m.z = max.z;
			}
			if (min.z > this.M.z)
			{
				this.M.z = min.z;
			}
		}
		else
		{
			if (min.z < this.m.z)
			{
				this.m.z = min.z;
			}
			if (max.z > this.M.z)
			{
				this.M.z = max.z;
			}
		}
	}

	// Token: 0x060016AA RID: 5802 RVA: 0x0004D0A0 File Offset: 0x0004B2A0
	public void Encapsulate(global::UnityEngine.Vector3 min, ref global::UnityEngine.Vector3 max)
	{
		if (max.x < min.x)
		{
			if (max.x < this.m.x)
			{
				this.m.x = max.x;
			}
			if (min.x > this.M.x)
			{
				this.M.x = min.x;
			}
		}
		else
		{
			if (min.x < this.m.x)
			{
				this.m.x = min.x;
			}
			if (max.x > this.M.x)
			{
				this.M.x = max.x;
			}
		}
		if (max.y < min.y)
		{
			if (max.y < this.m.y)
			{
				this.m.y = max.y;
			}
			if (min.y > this.M.y)
			{
				this.M.y = min.y;
			}
		}
		else
		{
			if (min.y < this.m.y)
			{
				this.m.y = min.y;
			}
			if (max.y > this.M.y)
			{
				this.M.y = max.y;
			}
		}
		if (max.z < min.z)
		{
			if (max.z < this.m.z)
			{
				this.m.z = max.z;
			}
			if (min.z > this.M.z)
			{
				this.M.z = min.z;
			}
		}
		else
		{
			if (min.z < this.m.z)
			{
				this.m.z = min.z;
			}
			if (max.z > this.M.z)
			{
				this.M.z = max.z;
			}
		}
	}

	// Token: 0x060016AB RID: 5803 RVA: 0x0004D2D4 File Offset: 0x0004B4D4
	public void Encapsulate(ref global::UnityEngine.Vector3 min, global::UnityEngine.Vector3 max)
	{
		if (max.x < min.x)
		{
			if (max.x < this.m.x)
			{
				this.m.x = max.x;
			}
			if (min.x > this.M.x)
			{
				this.M.x = min.x;
			}
		}
		else
		{
			if (min.x < this.m.x)
			{
				this.m.x = min.x;
			}
			if (max.x > this.M.x)
			{
				this.M.x = max.x;
			}
		}
		if (max.y < min.y)
		{
			if (max.y < this.m.y)
			{
				this.m.y = max.y;
			}
			if (min.y > this.M.y)
			{
				this.M.y = min.y;
			}
		}
		else
		{
			if (min.y < this.m.y)
			{
				this.m.y = min.y;
			}
			if (max.y > this.M.y)
			{
				this.M.y = max.y;
			}
		}
		if (max.z < min.z)
		{
			if (max.z < this.m.z)
			{
				this.m.z = max.z;
			}
			if (min.z > this.M.z)
			{
				this.M.z = min.z;
			}
		}
		else
		{
			if (min.z < this.m.z)
			{
				this.m.z = min.z;
			}
			if (max.z > this.M.z)
			{
				this.M.z = max.z;
			}
		}
	}

	// Token: 0x060016AC RID: 5804 RVA: 0x0004D508 File Offset: 0x0004B708
	public void Encapsulate(global::UnityEngine.Vector3 min, global::UnityEngine.Vector3 max)
	{
		if (max.x < min.x)
		{
			if (max.x < this.m.x)
			{
				this.m.x = max.x;
			}
			if (min.x > this.M.x)
			{
				this.M.x = min.x;
			}
		}
		else
		{
			if (min.x < this.m.x)
			{
				this.m.x = min.x;
			}
			if (max.x > this.M.x)
			{
				this.M.x = max.x;
			}
		}
		if (max.y < min.y)
		{
			if (max.y < this.m.y)
			{
				this.m.y = max.y;
			}
			if (min.y > this.M.y)
			{
				this.M.y = min.y;
			}
		}
		else
		{
			if (min.y < this.m.y)
			{
				this.m.y = min.y;
			}
			if (max.y > this.M.y)
			{
				this.M.y = max.y;
			}
		}
		if (max.z < min.z)
		{
			if (max.z < this.m.z)
			{
				this.m.z = max.z;
			}
			if (min.z > this.M.z)
			{
				this.M.z = min.z;
			}
		}
		else
		{
			if (min.z < this.m.z)
			{
				this.m.z = min.z;
			}
			if (max.z > this.M.z)
			{
				this.M.z = max.z;
			}
		}
	}

	// Token: 0x060016AD RID: 5805 RVA: 0x0004D74C File Offset: 0x0004B94C
	public void Encapsulate(ref global::UnityEngine.Bounds bounds)
	{
		global::UnityEngine.Vector3 min = bounds.min;
		global::UnityEngine.Vector3 max = bounds.max;
		if (max.x < min.x)
		{
			if (max.x < this.m.x)
			{
				this.m.x = max.x;
			}
			if (min.x > this.M.x)
			{
				this.M.x = min.x;
			}
		}
		else
		{
			if (min.x < this.m.x)
			{
				this.m.x = min.x;
			}
			if (max.x > this.M.x)
			{
				this.M.x = max.x;
			}
		}
		if (max.y < min.y)
		{
			if (max.y < this.m.y)
			{
				this.m.y = max.y;
			}
			if (min.y > this.M.y)
			{
				this.M.y = min.y;
			}
		}
		else
		{
			if (min.y < this.m.y)
			{
				this.m.y = min.y;
			}
			if (max.y > this.M.y)
			{
				this.M.y = max.y;
			}
		}
		if (max.z < min.z)
		{
			if (max.z < this.m.z)
			{
				this.m.z = max.z;
			}
			if (min.z > this.M.z)
			{
				this.M.z = min.z;
			}
		}
		else
		{
			if (min.z < this.m.z)
			{
				this.m.z = min.z;
			}
			if (max.z > this.M.z)
			{
				this.M.z = max.z;
			}
		}
	}

	// Token: 0x060016AE RID: 5806 RVA: 0x0004D99C File Offset: 0x0004BB9C
	public void Encapsulate(global::UnityEngine.Bounds bounds)
	{
		global::UnityEngine.Vector3 min = bounds.min;
		global::UnityEngine.Vector3 max = bounds.max;
		if (max.x < min.x)
		{
			if (max.x < this.m.x)
			{
				this.m.x = max.x;
			}
			if (min.x > this.M.x)
			{
				this.M.x = min.x;
			}
		}
		else
		{
			if (min.x < this.m.x)
			{
				this.m.x = min.x;
			}
			if (max.x > this.M.x)
			{
				this.M.x = max.x;
			}
		}
		if (max.y < min.y)
		{
			if (max.y < this.m.y)
			{
				this.m.y = max.y;
			}
			if (min.y > this.M.y)
			{
				this.M.y = min.y;
			}
		}
		else
		{
			if (min.y < this.m.y)
			{
				this.m.y = min.y;
			}
			if (max.y > this.M.y)
			{
				this.M.y = max.y;
			}
		}
		if (max.z < min.z)
		{
			if (max.z < this.m.z)
			{
				this.m.z = max.z;
			}
			if (min.z > this.M.z)
			{
				this.M.z = min.z;
			}
		}
		else
		{
			if (min.z < this.m.z)
			{
				this.m.z = min.z;
			}
			if (max.z > this.M.z)
			{
				this.M.z = max.z;
			}
		}
	}

	// Token: 0x060016AF RID: 5807 RVA: 0x0004DBF0 File Offset: 0x0004BDF0
	public bool Contains(ref global::UnityEngine.Vector3 v)
	{
		return this.m.x <= this.M.x && this.m.y <= this.M.y && this.m.z <= this.M.z && v.x >= this.m.x && v.y >= this.m.y && v.z >= this.m.z && v.x <= this.M.x && v.y <= this.M.y && v.z <= this.M.z;
	}

	// Token: 0x17000665 RID: 1637
	public global::UnityEngine.Vector3 this[int corner]
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = (((corner & 2) != 2) ? this.m.x : this.M.x);
			result.y = (((corner & 4) != 4) ? this.m.y : this.M.y);
			result.z = (((corner & 1) != 1) ? this.m.z : this.M.z);
			return result;
		}
	}

	// Token: 0x17000666 RID: 1638
	public float this[int corner, int axis]
	{
		get
		{
			switch (axis)
			{
			case 0:
				return ((corner & 2) != 2) ? this.m.x : this.M.x;
			case 1:
				return ((corner & 4) != 4) ? this.m.y : this.M.y;
			case 2:
				return ((corner & 1) != 1) ? this.m.z : this.M.z;
			default:
				throw new global::System.ArgumentOutOfRangeException("axis", axis, "axis<0||axis>2");
			}
		}
	}

	// Token: 0x060016B2 RID: 5810 RVA: 0x0004DE14 File Offset: 0x0004C014
	public global::BBox ToBBox()
	{
		global::BBox result;
		result.a.x = this.m.x;
		result.a.y = this.m.y;
		result.a.z = this.m.z;
		result.b.x = this.m.x;
		result.b.y = this.m.y;
		result.b.z = this.M.z;
		result.c.x = this.M.x;
		result.c.y = this.m.y;
		result.c.z = this.m.z;
		result.d.x = this.M.x;
		result.d.y = this.m.y;
		result.d.z = this.M.z;
		result.e.x = this.m.x;
		result.e.y = this.M.y;
		result.e.z = this.m.z;
		result.f.x = this.m.x;
		result.f.y = this.M.y;
		result.f.z = this.M.z;
		result.g.x = this.M.x;
		result.g.y = this.M.y;
		result.g.z = this.m.z;
		result.h.x = this.M.x;
		result.h.y = this.M.y;
		result.h.z = this.M.z;
		return result;
	}

	// Token: 0x060016B3 RID: 5811 RVA: 0x0004E04C File Offset: 0x0004C24C
	public void ToBBox(out global::BBox box)
	{
		box.a.x = this.m.x;
		box.a.y = this.m.y;
		box.a.z = this.m.z;
		box.b.x = this.m.x;
		box.b.y = this.m.y;
		box.b.z = this.M.z;
		box.c.x = this.M.x;
		box.c.y = this.m.y;
		box.c.z = this.m.z;
		box.d.x = this.M.x;
		box.d.y = this.m.y;
		box.d.z = this.M.z;
		box.e.x = this.m.x;
		box.e.y = this.M.y;
		box.e.z = this.m.z;
		box.f.x = this.m.x;
		box.f.y = this.M.y;
		box.f.z = this.M.z;
		box.g.x = this.M.x;
		box.g.y = this.M.y;
		box.g.z = this.m.z;
		box.h.x = this.M.x;
		box.h.y = this.M.y;
		box.h.z = this.M.z;
	}

	// Token: 0x060016B4 RID: 5812 RVA: 0x0004E26C File Offset: 0x0004C46C
	public void TransformedAABB3x4(ref global::UnityEngine.Matrix4x4 t, out global::AABBox mM)
	{
		global::UnityEngine.Vector3 vector;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		float num = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		float num2 = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		float num3 = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		mM.m.x = (mM.M.x = num);
		mM.m.y = (mM.M.y = num2);
		mM.m.z = (mM.M.z = num3);
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		num = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		num2 = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		num3 = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		num = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		num2 = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		num3 = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		num = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		num2 = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		num3 = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		num = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		num2 = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		num3 = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		num = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		num2 = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		num3 = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		num = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		num2 = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		num3 = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		num = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		num2 = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		num3 = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
	}

	// Token: 0x060016B5 RID: 5813 RVA: 0x0004EE20 File Offset: 0x0004D020
	public void TransformedAABB3x4(ref global::UnityEngine.Matrix4x4 t, out global::UnityEngine.Bounds bounds)
	{
		global::AABBox aabbox;
		this.TransformedAABB3x4(ref t, out aabbox);
		global::UnityEngine.Vector3 vector;
		vector.x = aabbox.M.x - aabbox.m.x;
		global::UnityEngine.Vector3 vector2;
		vector2.x = aabbox.m.x + vector.x * 0.5f;
		vector.y = aabbox.M.y - aabbox.m.y;
		vector2.y = aabbox.m.y + vector.y * 0.5f;
		vector.z = aabbox.M.z - aabbox.m.z;
		vector2.z = aabbox.m.z + vector.z * 0.5f;
		bounds..ctor(vector2, vector);
	}

	// Token: 0x060016B6 RID: 5814 RVA: 0x0004EF04 File Offset: 0x0004D104
	public void ToBoxCorners3x4(ref global::UnityEngine.Matrix4x4 t, out global::BBox box, out global::AABBox mM)
	{
		global::UnityEngine.Vector3 vector;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		box.a.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.a.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.a.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		mM.m = box.a;
		mM.M = box.a;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		box.b.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.b.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.b.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (box.b.x < mM.m.x)
		{
			mM.m.x = box.b.x;
		}
		if (box.b.x > mM.M.x)
		{
			mM.M.x = box.b.x;
		}
		if (box.b.y < mM.m.y)
		{
			mM.m.y = box.b.y;
		}
		if (box.b.y > mM.M.y)
		{
			mM.M.y = box.b.y;
		}
		if (box.b.z < mM.m.z)
		{
			mM.m.z = box.b.z;
		}
		if (box.b.z > mM.M.z)
		{
			mM.M.z = box.b.z;
		}
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		box.c.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.c.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.c.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (box.c.x < mM.m.x)
		{
			mM.m.x = box.c.x;
		}
		if (box.c.x > mM.M.x)
		{
			mM.M.x = box.c.x;
		}
		if (box.c.y < mM.m.y)
		{
			mM.m.y = box.c.y;
		}
		if (box.c.y > mM.M.y)
		{
			mM.M.y = box.c.y;
		}
		if (box.c.z < mM.m.z)
		{
			mM.m.z = box.c.z;
		}
		if (box.c.z > mM.M.z)
		{
			mM.M.z = box.c.z;
		}
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		box.d.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.d.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.d.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (box.d.x < mM.m.x)
		{
			mM.m.x = box.d.x;
		}
		if (box.d.x > mM.M.x)
		{
			mM.M.x = box.d.x;
		}
		if (box.d.y < mM.m.y)
		{
			mM.m.y = box.d.y;
		}
		if (box.d.y > mM.M.y)
		{
			mM.M.y = box.d.y;
		}
		if (box.d.z < mM.m.z)
		{
			mM.m.z = box.d.z;
		}
		if (box.d.z > mM.M.z)
		{
			mM.M.z = box.d.z;
		}
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		box.e.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.e.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.e.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (box.e.x < mM.m.x)
		{
			mM.m.x = box.e.x;
		}
		if (box.e.x > mM.M.x)
		{
			mM.M.x = box.e.x;
		}
		if (box.e.y < mM.m.y)
		{
			mM.m.y = box.e.y;
		}
		if (box.e.y > mM.M.y)
		{
			mM.M.y = box.e.y;
		}
		if (box.e.z < mM.m.z)
		{
			mM.m.z = box.e.z;
		}
		if (box.e.z > mM.M.z)
		{
			mM.M.z = box.e.z;
		}
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		box.f.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.f.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.f.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (box.f.x < mM.m.x)
		{
			mM.m.x = box.f.x;
		}
		if (box.f.x > mM.M.x)
		{
			mM.M.x = box.f.x;
		}
		if (box.f.y < mM.m.y)
		{
			mM.m.y = box.f.y;
		}
		if (box.f.y > mM.M.y)
		{
			mM.M.y = box.f.y;
		}
		if (box.f.z < mM.m.z)
		{
			mM.m.z = box.f.z;
		}
		if (box.f.z > mM.M.z)
		{
			mM.M.z = box.f.z;
		}
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		box.g.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.g.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.g.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (box.g.x < mM.m.x)
		{
			mM.m.x = box.g.x;
		}
		if (box.g.x > mM.M.x)
		{
			mM.M.x = box.g.x;
		}
		if (box.g.y < mM.m.y)
		{
			mM.m.y = box.g.y;
		}
		if (box.g.y > mM.M.y)
		{
			mM.M.y = box.g.y;
		}
		if (box.g.z < mM.m.z)
		{
			mM.m.z = box.g.z;
		}
		if (box.g.z > mM.M.z)
		{
			mM.M.z = box.g.z;
		}
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		box.h.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.h.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.h.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		if (box.h.x < mM.m.x)
		{
			mM.m.x = box.h.x;
		}
		if (box.h.x > mM.M.x)
		{
			mM.M.x = box.h.x;
		}
		if (box.h.y < mM.m.y)
		{
			mM.m.y = box.h.y;
		}
		if (box.h.y > mM.M.y)
		{
			mM.M.y = box.h.y;
		}
		if (box.h.z < mM.m.z)
		{
			mM.m.z = box.h.z;
		}
		if (box.h.z > mM.M.z)
		{
			mM.M.z = box.h.z;
		}
	}

	// Token: 0x060016B7 RID: 5815 RVA: 0x0004FEB4 File Offset: 0x0004E0B4
	public void TransformedAABB4x4(ref global::UnityEngine.Matrix4x4 t, out global::AABBox mM)
	{
		global::UnityEngine.Vector4 vector;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		float num = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		float num2 = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		float num3 = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		mM.m.x = (mM.M.x = num);
		mM.m.y = (mM.M.y = num2);
		mM.m.z = (mM.M.z = num3);
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		num = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		num2 = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		num3 = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		num = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		num2 = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		num3 = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		num = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		num2 = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		num3 = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		num = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		num2 = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		num3 = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		num = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		num2 = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		num3 = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		num = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		num2 = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		num3 = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		num = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		num2 = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		num3 = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (num < mM.m.x)
		{
			mM.m.x = num;
		}
		if (num > mM.M.x)
		{
			mM.M.x = num;
		}
		if (num2 < mM.m.y)
		{
			mM.m.y = num2;
		}
		if (num2 > mM.M.y)
		{
			mM.M.y = num2;
		}
		if (num3 < mM.m.z)
		{
			mM.m.z = num3;
		}
		if (num3 > mM.M.z)
		{
			mM.M.z = num3;
		}
	}

	// Token: 0x060016B8 RID: 5816 RVA: 0x00050D28 File Offset: 0x0004EF28
	public void TransformedAABB4x4(ref global::UnityEngine.Matrix4x4 t, out global::UnityEngine.Bounds bounds)
	{
		global::AABBox aabbox;
		this.TransformedAABB4x4(ref t, out aabbox);
		global::UnityEngine.Vector3 vector;
		vector.x = aabbox.M.x - aabbox.m.x;
		global::UnityEngine.Vector3 vector2;
		vector2.x = aabbox.m.x + vector.x * 0.5f;
		vector.y = aabbox.M.y - aabbox.m.y;
		vector2.y = aabbox.m.y + vector.y * 0.5f;
		vector.z = aabbox.M.z - aabbox.m.z;
		vector2.z = aabbox.m.z + vector.z * 0.5f;
		bounds..ctor(vector2, vector);
	}

	// Token: 0x060016B9 RID: 5817 RVA: 0x00050E0C File Offset: 0x0004F00C
	public void ToBoxCorners4x4(ref global::UnityEngine.Matrix4x4 t, out global::BBox box, out global::AABBox mM)
	{
		global::UnityEngine.Vector4 vector;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.a.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.a.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.a.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		mM.m = box.a;
		mM.M = box.a;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.b.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.b.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.b.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (box.b.x < mM.m.x)
		{
			mM.m.x = box.b.x;
		}
		if (box.b.x > mM.M.x)
		{
			mM.M.x = box.b.x;
		}
		if (box.b.y < mM.m.y)
		{
			mM.m.y = box.b.y;
		}
		if (box.b.y > mM.M.y)
		{
			mM.M.y = box.b.y;
		}
		if (box.b.z < mM.m.z)
		{
			mM.m.z = box.b.z;
		}
		if (box.b.z > mM.M.z)
		{
			mM.M.z = box.b.z;
		}
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.c.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.c.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.c.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (box.c.x < mM.m.x)
		{
			mM.m.x = box.c.x;
		}
		if (box.c.x > mM.M.x)
		{
			mM.M.x = box.c.x;
		}
		if (box.c.y < mM.m.y)
		{
			mM.m.y = box.c.y;
		}
		if (box.c.y > mM.M.y)
		{
			mM.M.y = box.c.y;
		}
		if (box.c.z < mM.m.z)
		{
			mM.m.z = box.c.z;
		}
		if (box.c.z > mM.M.z)
		{
			mM.M.z = box.c.z;
		}
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.d.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.d.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.d.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (box.d.x < mM.m.x)
		{
			mM.m.x = box.d.x;
		}
		if (box.d.x > mM.M.x)
		{
			mM.M.x = box.d.x;
		}
		if (box.d.y < mM.m.y)
		{
			mM.m.y = box.d.y;
		}
		if (box.d.y > mM.M.y)
		{
			mM.M.y = box.d.y;
		}
		if (box.d.z < mM.m.z)
		{
			mM.m.z = box.d.z;
		}
		if (box.d.z > mM.M.z)
		{
			mM.M.z = box.d.z;
		}
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.e.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.e.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.e.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (box.e.x < mM.m.x)
		{
			mM.m.x = box.e.x;
		}
		if (box.e.x > mM.M.x)
		{
			mM.M.x = box.e.x;
		}
		if (box.e.y < mM.m.y)
		{
			mM.m.y = box.e.y;
		}
		if (box.e.y > mM.M.y)
		{
			mM.M.y = box.e.y;
		}
		if (box.e.z < mM.m.z)
		{
			mM.m.z = box.e.z;
		}
		if (box.e.z > mM.M.z)
		{
			mM.M.z = box.e.z;
		}
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.f.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.f.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.f.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (box.f.x < mM.m.x)
		{
			mM.m.x = box.f.x;
		}
		if (box.f.x > mM.M.x)
		{
			mM.M.x = box.f.x;
		}
		if (box.f.y < mM.m.y)
		{
			mM.m.y = box.f.y;
		}
		if (box.f.y > mM.M.y)
		{
			mM.M.y = box.f.y;
		}
		if (box.f.z < mM.m.z)
		{
			mM.m.z = box.f.z;
		}
		if (box.f.z > mM.M.z)
		{
			mM.M.z = box.f.z;
		}
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.g.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.g.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.g.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (box.g.x < mM.m.x)
		{
			mM.m.x = box.g.x;
		}
		if (box.g.x > mM.M.x)
		{
			mM.M.x = box.g.x;
		}
		if (box.g.y < mM.m.y)
		{
			mM.m.y = box.g.y;
		}
		if (box.g.y > mM.M.y)
		{
			mM.M.y = box.g.y;
		}
		if (box.g.z < mM.m.z)
		{
			mM.m.z = box.g.z;
		}
		if (box.g.z > mM.M.z)
		{
			mM.M.z = box.g.z;
		}
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.h.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.h.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.h.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		if (box.h.x < mM.m.x)
		{
			mM.m.x = box.h.x;
		}
		if (box.h.x > mM.M.x)
		{
			mM.M.x = box.h.x;
		}
		if (box.h.y < mM.m.y)
		{
			mM.m.y = box.h.y;
		}
		if (box.h.y > mM.M.y)
		{
			mM.M.y = box.h.y;
		}
		if (box.h.z < mM.m.z)
		{
			mM.m.z = box.h.z;
		}
		if (box.h.z > mM.M.z)
		{
			mM.M.z = box.h.z;
		}
	}

	// Token: 0x060016BA RID: 5818 RVA: 0x0005207C File Offset: 0x0005027C
	public void ToBoxCorners3x4(ref global::UnityEngine.Matrix4x4 t, out global::BBox box)
	{
		global::UnityEngine.Vector3 vector;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		box.a.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.a.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.a.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		box.b.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.b.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.b.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		box.c.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.c.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.c.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		box.d.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.d.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.d.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		box.e.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.e.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.e.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		box.f.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.f.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.f.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		box.g.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.g.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.g.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		box.h.x = t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03;
		box.h.y = t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13;
		box.h.z = t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23;
	}

	// Token: 0x060016BB RID: 5819 RVA: 0x0005280C File Offset: 0x00050A0C
	public void ToBoxCorners4x4(ref global::UnityEngine.Matrix4x4 t, out global::BBox box)
	{
		global::UnityEngine.Vector4 vector;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.a.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.a.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.a.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		vector.x = this.m.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.b.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.b.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.b.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.c.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.c.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.c.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		vector.x = this.M.x;
		vector.y = this.m.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.d.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.d.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.d.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.e.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.e.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.e.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		vector.x = this.m.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.f.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.f.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.f.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.m.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.g.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.g.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.g.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
		vector.x = this.M.x;
		vector.y = this.M.y;
		vector.z = this.M.z;
		vector.w = 1f / (t.m30 * vector.x + t.m31 * vector.y + t.m32 * vector.z + t.m33);
		box.h.x = (t.m00 * vector.x + t.m01 * vector.y + t.m02 * vector.z + t.m03) * vector.w;
		box.h.y = (t.m10 * vector.x + t.m11 * vector.y + t.m12 * vector.z + t.m13) * vector.w;
		box.h.z = (t.m20 * vector.x + t.m21 * vector.y + t.m22 * vector.z + t.m23) * vector.w;
	}

	// Token: 0x060016BC RID: 5820 RVA: 0x0005325C File Offset: 0x0005145C
	public static void Transform3x4(ref global::AABBox src, ref global::UnityEngine.Matrix4x4 transform, out global::AABBox dst)
	{
		src.TransformedAABB3x4(ref transform, out dst);
	}

	// Token: 0x060016BD RID: 5821 RVA: 0x00053268 File Offset: 0x00051468
	public static void Transform4x4(ref global::AABBox src, ref global::UnityEngine.Matrix4x4 transform, out global::AABBox dst)
	{
		src.TransformedAABB4x4(ref transform, out dst);
	}

	// Token: 0x060016BE RID: 5822 RVA: 0x00053274 File Offset: 0x00051474
	public static void Transform3x4(ref global::AABBox src, ref global::UnityEngine.Matrix4x4 transform, out global::UnityEngine.Bounds dst)
	{
		src.TransformedAABB3x4(ref transform, out dst);
	}

	// Token: 0x060016BF RID: 5823 RVA: 0x00053280 File Offset: 0x00051480
	public static void Transform4x4(ref global::AABBox src, ref global::UnityEngine.Matrix4x4 transform, out global::UnityEngine.Bounds dst)
	{
		src.TransformedAABB4x4(ref transform, out dst);
	}

	// Token: 0x060016C0 RID: 5824 RVA: 0x0005328C File Offset: 0x0005148C
	public static void Transform3x4(ref global::UnityEngine.Bounds boundsSrc, ref global::UnityEngine.Matrix4x4 transform, out global::AABBox dst)
	{
		global::AABBox aabbox = new global::AABBox(boundsSrc.min, boundsSrc.max);
		global::AABBox.Transform3x4(ref aabbox, ref transform, out dst);
	}

	// Token: 0x060016C1 RID: 5825 RVA: 0x000532B8 File Offset: 0x000514B8
	public static void Transform4x4(ref global::UnityEngine.Bounds boundsSrc, ref global::UnityEngine.Matrix4x4 transform, out global::AABBox dst)
	{
		global::AABBox aabbox = new global::AABBox(boundsSrc.min, boundsSrc.max);
		global::AABBox.Transform4x4(ref aabbox, ref transform, out dst);
	}

	// Token: 0x060016C2 RID: 5826 RVA: 0x000532E4 File Offset: 0x000514E4
	public static void Transform3x4(ref global::UnityEngine.Bounds boundsSrc, ref global::UnityEngine.Matrix4x4 transform, out global::UnityEngine.Bounds dst)
	{
		global::AABBox aabbox = new global::AABBox(boundsSrc.min, boundsSrc.max);
		global::AABBox.Transform3x4(ref aabbox, ref transform, out dst);
	}

	// Token: 0x060016C3 RID: 5827 RVA: 0x00053310 File Offset: 0x00051510
	public static void Transform4x4(ref global::UnityEngine.Bounds boundsSrc, ref global::UnityEngine.Matrix4x4 transform, out global::UnityEngine.Bounds dst)
	{
		global::AABBox aabbox = new global::AABBox(boundsSrc.min, boundsSrc.max);
		global::AABBox.Transform4x4(ref aabbox, ref transform, out dst);
	}

	// Token: 0x060016C4 RID: 5828 RVA: 0x0005333C File Offset: 0x0005153C
	public static void Transform3x4(global::AABBox src, ref global::UnityEngine.Matrix4x4 transform, out global::AABBox dst)
	{
		src.TransformedAABB3x4(ref transform, out dst);
	}

	// Token: 0x060016C5 RID: 5829 RVA: 0x00053348 File Offset: 0x00051548
	public static void Transform4x4(global::AABBox src, ref global::UnityEngine.Matrix4x4 transform, out global::AABBox dst)
	{
		src.TransformedAABB4x4(ref transform, out dst);
	}

	// Token: 0x060016C6 RID: 5830 RVA: 0x00053354 File Offset: 0x00051554
	public static void Transform3x4(global::AABBox src, ref global::UnityEngine.Matrix4x4 transform, out global::UnityEngine.Bounds dst)
	{
		src.TransformedAABB3x4(ref transform, out dst);
	}

	// Token: 0x060016C7 RID: 5831 RVA: 0x00053360 File Offset: 0x00051560
	public static void Transform4x4(global::AABBox src, ref global::UnityEngine.Matrix4x4 transform, out global::UnityEngine.Bounds dst)
	{
		src.TransformedAABB4x4(ref transform, out dst);
	}

	// Token: 0x060016C8 RID: 5832 RVA: 0x0005336C File Offset: 0x0005156C
	public static void Transform3x4(global::UnityEngine.Bounds boundsSrc, ref global::UnityEngine.Matrix4x4 transform, out global::AABBox dst)
	{
		global::AABBox aabbox = new global::AABBox(boundsSrc.min, boundsSrc.max);
		global::AABBox.Transform3x4(ref aabbox, ref transform, out dst);
	}

	// Token: 0x060016C9 RID: 5833 RVA: 0x00053398 File Offset: 0x00051598
	public static void Transform4x4(global::UnityEngine.Bounds boundsSrc, ref global::UnityEngine.Matrix4x4 transform, out global::AABBox dst)
	{
		global::AABBox aabbox = new global::AABBox(boundsSrc.min, boundsSrc.max);
		global::AABBox.Transform4x4(ref aabbox, ref transform, out dst);
	}

	// Token: 0x060016CA RID: 5834 RVA: 0x000533C4 File Offset: 0x000515C4
	public static void Transform3x4(global::UnityEngine.Bounds boundsSrc, ref global::UnityEngine.Matrix4x4 transform, out global::UnityEngine.Bounds dst)
	{
		global::AABBox aabbox = new global::AABBox(boundsSrc.min, boundsSrc.max);
		global::AABBox.Transform3x4(ref aabbox, ref transform, out dst);
	}

	// Token: 0x060016CB RID: 5835 RVA: 0x000533F0 File Offset: 0x000515F0
	public static void Transform4x4(global::UnityEngine.Bounds boundsSrc, ref global::UnityEngine.Matrix4x4 transform, out global::UnityEngine.Bounds dst)
	{
		global::AABBox aabbox = new global::AABBox(boundsSrc.min, boundsSrc.max);
		global::AABBox.Transform4x4(ref aabbox, ref transform, out dst);
	}

	// Token: 0x060016CC RID: 5836 RVA: 0x0005341C File Offset: 0x0005161C
	public static global::AABBox CenterAndSize(global::UnityEngine.Vector3 center, global::UnityEngine.Vector3 size)
	{
		center.x -= size.x * 0.5f;
		center.y -= size.y * 0.5f;
		center.z -= size.z * 0.5f;
		size.x = center.x + size.x;
		size.y = center.y + size.y;
		size.z = center.z + size.z;
		return new global::AABBox(ref center, ref size);
	}

	// Token: 0x060016CD RID: 5837 RVA: 0x000534C8 File Offset: 0x000516C8
	public override bool Equals(object obj)
	{
		return obj is global::AABBox && this.Equals((global::AABBox)obj);
	}

	// Token: 0x060016CE RID: 5838 RVA: 0x000534E4 File Offset: 0x000516E4
	public override int GetHashCode()
	{
		int num = ((this.m.x + this.M.x) * 0.5f).GetHashCode() ^ ((this.m.y + this.M.y) * 0.5f).GetHashCode();
		int num2 = ((this.m.x + this.M.x - (this.m.y + this.M.y)).GetHashCode() & int.MaxValue) % 0x20;
		return num << num2 ^ num >> num2;
	}

	// Token: 0x060016CF RID: 5839 RVA: 0x0005358C File Offset: 0x0005178C
	public bool Equals(global::AABBox other)
	{
		return this.m.x.Equals(other.m.x) && this.m.y.Equals(other.m.y) && this.m.z.Equals(other.m.z) && this.M.x.Equals(other.M.x) && this.M.y.Equals(other.M.y) && this.M.z.Equals(other.M.z);
	}

	// Token: 0x060016D0 RID: 5840 RVA: 0x00053660 File Offset: 0x00051860
	public bool Equals(ref global::AABBox other)
	{
		return this.m.x.Equals(other.m.x) && this.m.y.Equals(other.m.y) && this.m.z.Equals(other.m.z) && this.M.x.Equals(other.M.x) && this.M.y.Equals(other.M.y) && this.M.z.Equals(other.M.z);
	}

	// Token: 0x060016D1 RID: 5841 RVA: 0x0005372C File Offset: 0x0005192C
	public static explicit operator global::UnityEngine.Bounds(global::AABBox mM)
	{
		global::UnityEngine.Vector3 vector;
		vector.x = mM.M.x - mM.m.x;
		global::UnityEngine.Vector3 vector2;
		vector2.x = mM.m.x + vector.x * 0.5f;
		if (vector.x < 0f)
		{
			vector.x = -vector.x;
		}
		vector.y = mM.M.y - mM.m.y;
		vector2.y = mM.m.y + vector.y * 0.5f;
		if (vector.y < 0f)
		{
			vector.y = -vector.y;
		}
		vector.z = mM.M.z - mM.m.z;
		vector2.z = mM.m.z + vector.z * 0.5f;
		if (vector.z < 0f)
		{
			vector.z = -vector.z;
		}
		return new global::UnityEngine.Bounds(vector2, vector);
	}

	// Token: 0x060016D2 RID: 5842 RVA: 0x00053864 File Offset: 0x00051A64
	public static explicit operator global::AABBox(global::UnityEngine.Bounds bounds)
	{
		global::UnityEngine.Vector3 min = bounds.min;
		global::UnityEngine.Vector3 max = bounds.max;
		global::AABBox result;
		if (min.x > max.x)
		{
			result.M.x = min.x;
			result.m.x = max.x;
		}
		else
		{
			result.M.x = max.x;
			result.m.x = min.x;
		}
		if (min.y > max.y)
		{
			result.M.y = min.y;
			result.m.y = max.y;
		}
		else
		{
			result.M.y = max.y;
			result.m.y = min.y;
		}
		if (min.z > max.z)
		{
			result.M.z = min.z;
			result.m.z = max.z;
		}
		else
		{
			result.M.z = max.z;
			result.m.z = min.z;
		}
		return result;
	}

	// Token: 0x060016D3 RID: 5843 RVA: 0x000539B0 File Offset: 0x00051BB0
	public static explicit operator global::BBox(global::AABBox mM)
	{
		global::BBox result;
		result.a.x = mM.m.x;
		result.a.y = mM.m.y;
		result.a.z = mM.m.z;
		result.b.x = mM.m.x;
		result.b.y = mM.m.y;
		result.b.z = mM.M.z;
		result.c.x = mM.M.x;
		result.c.y = mM.m.y;
		result.c.z = mM.m.z;
		result.d.x = mM.M.x;
		result.d.y = mM.m.y;
		result.d.z = mM.M.z;
		result.e.x = mM.m.x;
		result.e.y = mM.M.y;
		result.e.z = mM.m.z;
		result.f.x = mM.m.x;
		result.f.y = mM.M.y;
		result.f.z = mM.M.z;
		result.g.x = mM.M.x;
		result.g.y = mM.M.y;
		result.g.z = mM.m.z;
		result.h.x = mM.M.x;
		result.h.y = mM.M.y;
		result.h.z = mM.M.z;
		return result;
	}

	// Token: 0x060016D4 RID: 5844 RVA: 0x00053C00 File Offset: 0x00051E00
	public static explicit operator global::AABBox(global::BBox box)
	{
		global::AABBox result;
		result.m.x = (result.M.x = box.a.x);
		result.m.y = (result.M.y = box.a.y);
		result.m.z = (result.M.z = box.a.z);
		if (box.b.x < result.m.x)
		{
			result.m.x = box.b.x;
		}
		if (box.b.x > result.M.x)
		{
			result.M.x = box.b.x;
		}
		if (box.b.y < result.m.y)
		{
			result.m.y = box.b.y;
		}
		if (box.b.y > result.M.y)
		{
			result.M.y = box.b.y;
		}
		if (box.b.z < result.m.z)
		{
			result.m.z = box.b.z;
		}
		if (box.b.z > result.M.z)
		{
			result.M.z = box.b.z;
		}
		if (box.c.x < result.m.x)
		{
			result.m.x = box.c.x;
		}
		if (box.c.x > result.M.x)
		{
			result.M.x = box.c.x;
		}
		if (box.c.y < result.m.y)
		{
			result.m.y = box.c.y;
		}
		if (box.c.y > result.M.y)
		{
			result.M.y = box.c.y;
		}
		if (box.c.z < result.m.z)
		{
			result.m.z = box.c.z;
		}
		if (box.c.z > result.M.z)
		{
			result.M.z = box.c.z;
		}
		if (box.d.x < result.m.x)
		{
			result.m.x = box.d.x;
		}
		if (box.d.x > result.M.x)
		{
			result.M.x = box.d.x;
		}
		if (box.d.y < result.m.y)
		{
			result.m.y = box.d.y;
		}
		if (box.d.y > result.M.y)
		{
			result.M.y = box.d.y;
		}
		if (box.d.z < result.m.z)
		{
			result.m.z = box.d.z;
		}
		if (box.d.z > result.M.z)
		{
			result.M.z = box.d.z;
		}
		if (box.e.x < result.m.x)
		{
			result.m.x = box.e.x;
		}
		if (box.e.x > result.M.x)
		{
			result.M.x = box.e.x;
		}
		if (box.e.y < result.m.y)
		{
			result.m.y = box.e.y;
		}
		if (box.e.y > result.M.y)
		{
			result.M.y = box.e.y;
		}
		if (box.e.z < result.m.z)
		{
			result.m.z = box.e.z;
		}
		if (box.e.z > result.M.z)
		{
			result.M.z = box.e.z;
		}
		if (box.f.x < result.m.x)
		{
			result.m.x = box.f.x;
		}
		if (box.f.x > result.M.x)
		{
			result.M.x = box.f.x;
		}
		if (box.f.y < result.m.y)
		{
			result.m.y = box.f.y;
		}
		if (box.f.y > result.M.y)
		{
			result.M.y = box.f.y;
		}
		if (box.f.z < result.m.z)
		{
			result.m.z = box.f.z;
		}
		if (box.f.z > result.M.z)
		{
			result.M.z = box.f.z;
		}
		if (box.g.x < result.m.x)
		{
			result.m.x = box.g.x;
		}
		if (box.g.x > result.M.x)
		{
			result.M.x = box.g.x;
		}
		if (box.g.y < result.m.y)
		{
			result.m.y = box.g.y;
		}
		if (box.g.y > result.M.y)
		{
			result.M.y = box.g.y;
		}
		if (box.g.z < result.m.z)
		{
			result.m.z = box.g.z;
		}
		if (box.g.z > result.M.z)
		{
			result.M.z = box.g.z;
		}
		if (box.h.x < result.m.x)
		{
			result.m.x = box.h.x;
		}
		if (box.h.x > result.M.x)
		{
			result.M.x = box.h.x;
		}
		if (box.h.y < result.m.y)
		{
			result.m.y = box.h.y;
		}
		if (box.h.y > result.M.y)
		{
			result.M.y = box.h.y;
		}
		if (box.h.z < result.m.z)
		{
			result.m.z = box.h.z;
		}
		if (box.h.z > result.M.z)
		{
			result.M.z = box.h.z;
		}
		return result;
	}

	// Token: 0x04000BB9 RID: 3001
	public const int kX = 2;

	// Token: 0x04000BBA RID: 3002
	public const int kY = 4;

	// Token: 0x04000BBB RID: 3003
	public const int kZ = 1;

	// Token: 0x04000BBC RID: 3004
	public const int kA = 0;

	// Token: 0x04000BBD RID: 3005
	public const int kB = 1;

	// Token: 0x04000BBE RID: 3006
	public const int kC = 2;

	// Token: 0x04000BBF RID: 3007
	public const int kD = 3;

	// Token: 0x04000BC0 RID: 3008
	public const int kE = 4;

	// Token: 0x04000BC1 RID: 3009
	public const int kF = 5;

	// Token: 0x04000BC2 RID: 3010
	public const int kG = 6;

	// Token: 0x04000BC3 RID: 3011
	public const int kH = 7;

	// Token: 0x04000BC4 RID: 3012
	public global::UnityEngine.Vector3 m;

	// Token: 0x04000BC5 RID: 3013
	public global::UnityEngine.Vector3 M;
}

using System;
using UnityEngine;

// Token: 0x02000538 RID: 1336
public class RPOSInvCellManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002D5B RID: 11611 RVA: 0x000AC37C File Offset: 0x000AA57C
	public RPOSInvCellManager()
	{
	}

	// Token: 0x06002D5C RID: 11612 RVA: 0x000AC394 File Offset: 0x000AA594
	private void Awake()
	{
		if (this.SpawnCells)
		{
			this.CreateCellsOnGameObject(null, base.gameObject);
		}
	}

	// Token: 0x06002D5D RID: 11613 RVA: 0x000AC3B0 File Offset: 0x000AA5B0
	public void SetInventory(global::Inventory newInv, bool spawnNewCells)
	{
		this.displayInventory = newInv;
		if (spawnNewCells && this.SpawnCells)
		{
			this.generatedCells = true;
			for (int i = 0; i < this._inventoryCells.Length; i++)
			{
				global::UnityEngine.Object.Destroy(this._inventoryCells[i].gameObject);
				this._inventoryCells[i] = null;
			}
			this.NumCellsVertical = global::UnityEngine.Mathf.CeilToInt((float)newInv.slotCount / 3f);
			this.CreateCellsOnGameObject(newInv, base.gameObject);
		}
		int num = 0;
		foreach (global::RPOSInventoryCell rposinventoryCell in this._inventoryCells)
		{
			rposinventoryCell._displayInventory = newInv;
			rposinventoryCell._mySlot = (byte)(this.CellIndexStart + num);
			newInv.MarkSlotDirty((int)rposinventoryCell._mySlot);
			num++;
		}
	}

	// Token: 0x06002D5E RID: 11614 RVA: 0x000AC484 File Offset: 0x000AA684
	public int GetNumCells()
	{
		if (this.SpawnCells || this.generatedCells)
		{
			return this.NumCellsHorizontal * this.NumCellsVertical;
		}
		return this._inventoryCells.Length;
	}

	// Token: 0x06002D5F RID: 11615 RVA: 0x000AC4C0 File Offset: 0x000AA6C0
	public static int GetIndex2D(int x, int y, int width)
	{
		return x + y * width;
	}

	// Token: 0x06002D60 RID: 11616 RVA: 0x000AC4C8 File Offset: 0x000AA6C8
	protected virtual void CreateCellsOnGameObject(global::Inventory inven, global::UnityEngine.GameObject parent)
	{
		bool flag = inven;
		int newSize;
		int num;
		if (flag)
		{
			global::Inventory.Slot.Range range;
			inven.GetSlotsOfKind(global::Inventory.Slot.Kind.Default, out range);
			newSize = range.Count;
			num = range.End;
		}
		else
		{
			newSize = this.GetNumCells();
			num = int.MaxValue;
		}
		global::System.Array.Resize<global::RPOSInventoryCell>(ref this._inventoryCells, newSize);
		float x = this.CellPrefab.GetComponent<global::RPOSInventoryCell>()._background.transform.localScale.x;
		float y = this.CellPrefab.GetComponent<global::RPOSInventoryCell>()._background.transform.localScale.y;
		for (int i = 0; i < this.NumCellsVertical; i++)
		{
			for (int j = 0; j < this.NumCellsHorizontal; j++)
			{
				byte b = (byte)(this.CellIndexStart + global::RPOSInvCellManager.GetIndex2D(j, i, this.NumCellsHorizontal));
				if ((int)b >= num)
				{
					return;
				}
				global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(parent, this.CellPrefab);
				global::RPOSInventoryCell component = gameObject.GetComponent<global::RPOSInventoryCell>();
				component._mySlot = b;
				component._displayInventory = inven;
				if (this.NumberedCells)
				{
					component._numberLabel.text = (global::RPOSInvCellManager.GetIndex2D(j, i, this.NumCellsHorizontal) + 1).ToString();
				}
				gameObject.transform.localPosition = new global::UnityEngine.Vector3((float)this.CellOffsetX + ((float)j * x + (float)(j * this.CellSpacing)), -((float)this.CellOffsetY + ((float)i * y + (float)(i * this.CellSpacing))), -2f);
				this._inventoryCells[global::RPOS.GetIndex2D(j, i, this.NumCellsHorizontal)] = gameObject.GetComponent<global::RPOSInventoryCell>();
			}
		}
		if (this.CenterFromCells)
		{
			if (this.NumCellsHorizontal > 1)
			{
				base.transform.localPosition = new global::UnityEngine.Vector3((float)(this.CellOffsetX + (this.NumCellsHorizontal * this.CellSize + (this.NumCellsHorizontal - 1) * this.CellSpacing)) * -0.5f, (float)this.CellSize, 0f);
			}
			else if (this.NumCellsVertical > 1)
			{
				base.transform.localPosition = new global::UnityEngine.Vector3((float)(-(float)this.CellSize), (float)(this.CellOffsetY + this.NumCellsVertical * this.CellSize) * 0.5f, 0f);
			}
		}
	}

	// Token: 0x04001755 RID: 5973
	public bool SpawnCells;

	// Token: 0x04001756 RID: 5974
	private bool generatedCells;

	// Token: 0x04001757 RID: 5975
	public int NumCellsHorizontal;

	// Token: 0x04001758 RID: 5976
	public int NumCellsVertical;

	// Token: 0x04001759 RID: 5977
	public int CellOffsetX;

	// Token: 0x0400175A RID: 5978
	public int CellOffsetY;

	// Token: 0x0400175B RID: 5979
	public int CellSize = 0x60;

	// Token: 0x0400175C RID: 5980
	public int CellSpacing = 0xA;

	// Token: 0x0400175D RID: 5981
	public int CellIndexStart;

	// Token: 0x0400175E RID: 5982
	public bool CenterFromCells;

	// Token: 0x0400175F RID: 5983
	public bool NumberedCells;

	// Token: 0x04001760 RID: 5984
	public global::UnityEngine.GameObject CellPrefab;

	// Token: 0x04001761 RID: 5985
	public global::Inventory displayInventory;

	// Token: 0x04001762 RID: 5986
	public global::RPOSInventoryCell[] _inventoryCells;
}

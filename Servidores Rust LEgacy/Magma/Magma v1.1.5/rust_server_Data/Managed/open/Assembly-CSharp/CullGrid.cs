using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class CullGrid : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001B32 RID: 6962 RVA: 0x0006C588 File Offset: 0x0006A788
	public CullGrid()
	{
	}

	// Token: 0x06001B33 RID: 6963 RVA: 0x0006C590 File Offset: 0x0006A790
	// Note: this type is marked as 'beforefieldinit'.
	static CullGrid()
	{
	}

	// Token: 0x1700077F RID: 1919
	// (get) Token: 0x06001B34 RID: 6964 RVA: 0x0006C598 File Offset: 0x0006A798
	public static bool autoPrebindInInstantiate
	{
		get
		{
			return global::CullGrid.has_grid && global::CullGrid.cull_prebinding;
		}
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x0006C5AC File Offset: 0x0006A7AC
	private global::UnityEngine.Vector3 GetCenterSetup(int cell)
	{
		global::CullGridSetup cullGridSetup = this.setup;
		return base.transform.position + base.transform.forward * (((float)(cell / cullGridSetup.cellsWide) - ((float)cullGridSetup.cellsTall / 2f - (float)(2 - (cullGridSetup.cellsTall & 1)) / 2f)) * (float)cullGridSetup.cellSquareDimension) + base.transform.right * (((float)(cell % cullGridSetup.cellsWide) - ((float)cullGridSetup.cellsWide / 2f - (float)(2 - (cullGridSetup.cellsWide & 1)) / 2f)) * (float)cullGridSetup.cellSquareDimension);
	}

	// Token: 0x06001B36 RID: 6966 RVA: 0x0006C658 File Offset: 0x0006A858
	private void DrawGrid(int cell)
	{
		if (cell != -1)
		{
			this.DrawGrid(this.GetCenterSetup(cell));
		}
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x0006C670 File Offset: 0x0006A870
	private void DrawGrid(int centerCell, int xOffset, int yOffset)
	{
		this.DrawGrid(centerCell + xOffset + this.setup.cellsWide * 2 * yOffset);
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x0006C68C File Offset: 0x0006A88C
	private void DrawGrid(global::UnityEngine.Vector3 center)
	{
		global::UnityEngine.Vector3 vector = base.transform.right * ((float)this.setup.cellSquareDimension / 2f);
		global::UnityEngine.Vector3 vector2 = base.transform.forward * ((float)this.setup.cellSquareDimension / 2f);
		global::CullGrid.DrawQuadRayCastDown(center + vector + vector2, center + vector - vector2, center - vector - vector2, center - vector + vector2);
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x0006C718 File Offset: 0x0006A918
	private void DrawGrid(global::UnityEngine.Vector3 center, float sizeX, float sizeY)
	{
		global::UnityEngine.Vector3 vector = base.transform.right * (sizeX / 2f);
		global::UnityEngine.Vector3 vector2 = base.transform.forward * (sizeY / 2f);
		global::CullGrid.DrawQuadRayCastDown(center + vector + vector2, center + vector - vector2, center - vector - vector2, center - vector + vector2);
	}

	// Token: 0x06001B3A RID: 6970 RVA: 0x0006C790 File Offset: 0x0006A990
	internal static bool AddPlayerToCell(global::NetUser player, ushort cell)
	{
		global::uLink.NetworkGroup group = global::CullGrid.GroupIDFromCell(cell);
		if (global::netcull.log)
		{
			try
			{
				global::NetCull.AddPlayerToGroup(player.networkPlayer, group);
			}
			catch (global::System.Net.Sockets.SocketException ex)
			{
				global::UnityEngine.Debug.LogException(ex);
				return false;
			}
			catch (global::uLink.NetworkException ex2)
			{
				global::UnityEngine.Debug.LogException(ex2);
				return false;
			}
		}
		else
		{
			try
			{
				global::NetCull.AddPlayerToGroup(player.networkPlayer, group);
			}
			catch (global::System.Net.Sockets.SocketException)
			{
				return false;
			}
			catch (global::uLink.NetworkException)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06001B3B RID: 6971 RVA: 0x0006C884 File Offset: 0x0006AA84
	internal static bool RemovePlayerFromCell(global::NetUser player, ushort cell)
	{
		global::uLink.NetworkGroup group = global::CullGrid.GroupIDFromCell(cell);
		if (global::netcull.log)
		{
			try
			{
				global::NetCull.RemovePlayerFromGroup(player.networkPlayer, group);
			}
			catch (global::System.Net.Sockets.SocketException ex)
			{
				global::UnityEngine.Debug.LogException(ex);
				return false;
			}
			catch (global::uLink.NetworkException ex2)
			{
				global::UnityEngine.Debug.LogException(ex2);
				return false;
			}
		}
		else
		{
			try
			{
				global::NetCull.RemovePlayerFromGroup(player.networkPlayer, group);
			}
			catch (global::System.Net.Sockets.SocketException)
			{
				return false;
			}
			catch (global::uLink.NetworkException)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06001B3C RID: 6972 RVA: 0x0006C978 File Offset: 0x0006AB78
	private static void SetGroupFlags(global::uLink.NetworkGroup group, global::uLink.NetworkGroupFlags flags)
	{
		global::NetCull.SetGroupFlags(group, flags);
	}

	// Token: 0x17000780 RID: 1920
	// (get) Token: 0x06001B3D RID: 6973 RVA: 0x0006C984 File Offset: 0x0006AB84
	public static bool pendingPlayerGroupChanges
	{
		get
		{
			return global::CullGrid.CHANGE_QUEUE_ACTIVE;
		}
	}

	// Token: 0x06001B3E RID: 6974 RVA: 0x0006C98C File Offset: 0x0006AB8C
	public static bool FlushPlayerGroupChanges()
	{
		if (global::CullGrid.CHANGE_QUEUE_ACTIVE)
		{
			global::CullGrid.g.RunUnion();
			global::CullGrid.g.RunExcept();
			return !global::CullGrid.CHANGE_QUEUE_ACTIVE;
		}
		return false;
	}

	// Token: 0x06001B3F RID: 6975 RVA: 0x0006C9AC File Offset: 0x0006ABAC
	private static void RegisterGrid(global::CullGrid grid)
	{
		if (grid)
		{
			global::CullGrid.grid = new global::CullGrid.CullGridRuntime(grid);
			global::CullGrid.has_grid = true;
		}
	}

	// Token: 0x06001B40 RID: 6976 RVA: 0x0006C9CC File Offset: 0x0006ABCC
	private void Awake()
	{
		global::CullGrid.RegisterGrid(this);
	}

	// Token: 0x17000781 RID: 1921
	// (get) Token: 0x06001B41 RID: 6977 RVA: 0x0006C9D4 File Offset: 0x0006ABD4
	// (set) Token: 0x06001B42 RID: 6978 RVA: 0x0006CA08 File Offset: 0x0006AC08
	private static bool cellTest
	{
		get
		{
			return global::CullGrid.testingCells != null && global::CullGrid.testingCells.Length > 0 && global::CullGrid.testingCells[0];
		}
		set
		{
			if (value != global::CullGrid.cellTest)
			{
				if (value)
				{
					if (!global::CullGrid.has_grid)
					{
						return;
					}
					int numCells = global::CullGrid.grid.numCells;
					if (numCells + 0x3E8 > global::NetCull.minimumAllocatableViewIDs)
					{
						global::UnityEngine.Debug.LogError("Sorry, thats too many cells to test with:" + numCells);
						return;
					}
					if (global::CullGrid.testingCells != null)
					{
						for (int i = 0; i < global::CullGrid.testingCells.Length; i++)
						{
							if (global::CullGrid.testingCells[i])
							{
								global::NetCull.Destroy(global::CullGrid.testingCells[i]);
							}
						}
					}
					global::System.Array.Resize<global::Facepunch.NetworkView>(ref global::CullGrid.testingCells, numCells);
					int j = 0;
					int cellsWide = global::CullGrid.grid.cellsWide;
					int cellsTall = global::CullGrid.grid.cellsTall;
					while (j < cellsTall)
					{
						for (int k = 0; k < cellsWide; k++)
						{
							int num = j * cellsWide + k;
							global::UnityEngine.Vector2 vector;
							global::CullGrid.grid.GetCenter(num, out vector);
							global::CullGrid.testingCells[num] = global::Facepunch.NetworkView.Get(global::NetCull.InstantiateClassic("GridCell", new global::UnityEngine.Vector3(vector.x, (float)global::CullGrid.grid.cellSquareDimension, vector.y), global::CullCell.instantiateRotation, global::CullGrid.GroupIDFromCell((ushort)num)));
						}
						j++;
					}
				}
				else
				{
					if (global::CullGrid.testingCells != null)
					{
						for (int l = 0; l < global::CullGrid.testingCells.Length; l++)
						{
							if (global::CullGrid.testingCells[l])
							{
								global::NetCull.Destroy(global::CullGrid.testingCells[l]);
							}
						}
					}
					global::CullGrid.testingCells = null;
				}
			}
		}
	}

	// Token: 0x17000782 RID: 1922
	// (get) Token: 0x06001B43 RID: 6979 RVA: 0x0006CB98 File Offset: 0x0006AD98
	public static bool AreGroupsRegistered
	{
		get
		{
			return global::CullGrid._registeredOnce;
		}
	}

	// Token: 0x06001B44 RID: 6980 RVA: 0x0006CBA0 File Offset: 0x0006ADA0
	public static void RegisterGroups()
	{
		global::CullGrid.grid.cells = new global::System.Collections.Generic.HashSet<ushort>[global::CullGrid.grid.numCells];
		int i = 0;
		int cellsWide = global::CullGrid.grid.cellsWide;
		int cellsTall = global::CullGrid.grid.cellsTall;
		while (i < cellsTall)
		{
			for (int j = 0; j < cellsWide; j++)
			{
				int num = i * cellsWide + j;
				global::uLink.NetworkGroup group = global::CullGrid.GroupIDFromCell((ushort)num);
				global::CullGrid.SetGroupFlags(group, 2);
				global::CullGrid.grid.cells[num] = new global::System.Collections.Generic.HashSet<ushort>(global::CullGrid.grid.EnumerateNearbyCells(num, j, i));
			}
			i++;
		}
		global::CullGrid._registeredOnce = true;
	}

	// Token: 0x06001B45 RID: 6981 RVA: 0x0006CC44 File Offset: 0x0006AE44
	public static ushort CellFromGroupID(int groupID)
	{
		if (groupID < global::CullGrid.grid.groupBegin || groupID >= global::CullGrid.grid.groupEnd)
		{
			throw new global::System.ArgumentOutOfRangeException("groupID", groupID, "groupID < grid.groupBegin || groupID >= grid.groupEnd");
		}
		return (ushort)(groupID - global::CullGrid.grid.groupBegin);
	}

	// Token: 0x06001B46 RID: 6982 RVA: 0x0006CC94 File Offset: 0x0006AE94
	public static ushort CellFromGroupID(int groupID, out ushort x, out ushort y)
	{
		ushort num = global::CullGrid.CellFromGroupID(groupID);
		x = (ushort)((int)num % global::CullGrid.grid.cellsWide);
		y = (ushort)((int)num / global::CullGrid.grid.cellsWide);
		return num;
	}

	// Token: 0x06001B47 RID: 6983 RVA: 0x0006CCC8 File Offset: 0x0006AEC8
	public static int GroupIDFromCell(ushort cell)
	{
		if ((int)cell >= global::CullGrid.grid.numCells)
		{
			throw new global::System.ArgumentOutOfRangeException("cell", cell, "cell >= grid.numCells");
		}
		return global::CullGrid.grid.groupBegin + (int)cell;
	}

	// Token: 0x17000783 RID: 1923
	// (get) Token: 0x06001B48 RID: 6984 RVA: 0x0006CD08 File Offset: 0x0006AF08
	public static int Wide
	{
		get
		{
			return global::CullGrid.grid.cellsWide;
		}
	}

	// Token: 0x17000784 RID: 1924
	// (get) Token: 0x06001B49 RID: 6985 RVA: 0x0006CD14 File Offset: 0x0006AF14
	public static int Tall
	{
		get
		{
			return global::CullGrid.grid.cellsTall;
		}
	}

	// Token: 0x06001B4A RID: 6986 RVA: 0x0006CD20 File Offset: 0x0006AF20
	private static global::CullGrid.CullResultFlags NewPlayerCullInfo(global::NetUser player, int cellStart)
	{
		global::PlayerCullInfo playerCullInfo;
		return global::CullGrid.NewPlayerCullInfo(player, cellStart, out playerCullInfo);
	}

	// Token: 0x06001B4B RID: 6987 RVA: 0x0006CD38 File Offset: 0x0006AF38
	private static global::CullGrid.CullResultFlags NewPlayerCullInfo(global::NetUser player, int cellStart, out global::PlayerCullInfo info)
	{
		if (global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT.ContainsKey(player))
		{
			throw new global::System.ArgumentException("That player already has a PlayerCullInfo");
		}
		if (!player.networkPlayer.isClient || !player.networkPlayer.isConnected)
		{
			info = null;
			return global::CullGrid.CullResultFlags.Failed;
		}
		global::System.Collections.Generic.HashSet<ushort> nearCells = (cellStart != -1) ? global::CullGrid.grid.cells[cellStart] : null;
		info = new global::PlayerCullInfo();
		global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT[player] = info;
		player.cullinfo = info;
		if (global::CullGrid.g.AddQueue(player, info, nearCells))
		{
			return global::CullGrid.CullResultFlags.NoProblem | global::CullGrid.CullResultFlags.ChangedCell | global::CullGrid.CullResultFlags.Created;
		}
		return global::CullGrid.CullResultFlags.NoProblem | global::CullGrid.CullResultFlags.Created;
	}

	// Token: 0x06001B4C RID: 6988 RVA: 0x0006CDD4 File Offset: 0x0006AFD4
	private static bool GetPlayerCullInfo(global::NetUser target, out global::PlayerCullInfo info)
	{
		return global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT.TryGetValue(target, out info);
	}

	// Token: 0x06001B4D RID: 6989 RVA: 0x0006CDE4 File Offset: 0x0006AFE4
	public static global::CullGrid.CullResultFlags SetPlayerCenterFromGroupID(global::NetUser target, int groupID)
	{
		global::PlayerCullInfo playerCullInfo;
		return global::CullGrid.SetPlayerCenterFromGroupID(target, groupID, out playerCullInfo);
	}

	// Token: 0x06001B4E RID: 6990 RVA: 0x0006CDFC File Offset: 0x0006AFFC
	private static global::CullGrid.CullResultFlags SetPlayerCenterFromGroupID(global::NetUser target, int groupID, out global::PlayerCullInfo info)
	{
		if (groupID < global::CullGrid.grid.groupBegin || groupID >= global::CullGrid.grid.groupEnd)
		{
			throw new global::System.ArgumentOutOfRangeException("groupID", groupID, "groupID < groupBegin || groupID >= groupEnd");
		}
		return global::CullGrid.SetPlayerCenterFromCellID(target, groupID - global::CullGrid.grid.groupBegin, out info);
	}

	// Token: 0x06001B4F RID: 6991 RVA: 0x0006CE54 File Offset: 0x0006B054
	public static global::CullGrid.CullResultFlags SetPlayerCenterFromCellID(global::NetUser target, int cellID)
	{
		global::PlayerCullInfo playerCullInfo;
		return global::CullGrid.SetPlayerCenterFromCellID(target, cellID, out playerCullInfo);
	}

	// Token: 0x06001B50 RID: 6992 RVA: 0x0006CE6C File Offset: 0x0006B06C
	private static global::CullGrid.CullResultFlags SetPlayerCenterFromCellID(global::NetUser target, int cellID, out global::PlayerCullInfo info)
	{
		if (cellID == -0x80000000)
		{
			cellID = -1;
		}
		else if (cellID < 0 || cellID > global::CullGrid.grid.numCells)
		{
			throw new global::System.ArgumentOutOfRangeException("cellID", cellID, "cellID < 0 || cellID >= numCells");
		}
		if (!global::CullGrid.GetPlayerCullInfo(target, out info))
		{
			return global::CullGrid.NewPlayerCullInfo(target, cellID, out info);
		}
		if (global::CullGrid.g.AddQueue(target, info, global::CullGrid.grid.cells[cellID]))
		{
			return global::CullGrid.CullResultFlags.NoProblem | global::CullGrid.CullResultFlags.ChangedCell;
		}
		return global::CullGrid.CullResultFlags.NoProblem;
	}

	// Token: 0x06001B51 RID: 6993 RVA: 0x0006CEEC File Offset: 0x0006B0EC
	public static global::CullGrid.CullResultFlags SetPlayerCenterToNothing(global::NetUser target)
	{
		global::PlayerCullInfo playerCullInfo;
		return global::CullGrid.SetPlayerCenterToNothing(target, out playerCullInfo);
	}

	// Token: 0x06001B52 RID: 6994 RVA: 0x0006CF04 File Offset: 0x0006B104
	private static global::CullGrid.CullResultFlags SetPlayerCenterToNothing(global::NetUser target, out global::PlayerCullInfo info)
	{
		return global::CullGrid.SetPlayerCenterFromCellID(target, int.MinValue, out info);
	}

	// Token: 0x06001B53 RID: 6995 RVA: 0x0006CF14 File Offset: 0x0006B114
	public static global::CullGrid.CullResultFlags SetPlayerCenterFromWorldPoint(global::NetUser player, global::UnityEngine.Vector3 worldPoint)
	{
		global::PlayerCullInfo playerCullInfo;
		return global::CullGrid.SetPlayerCenterFromWorldPoint(player, ref worldPoint, out playerCullInfo);
	}

	// Token: 0x06001B54 RID: 6996 RVA: 0x0006CF2C File Offset: 0x0006B12C
	private static global::CullGrid.CullResultFlags SetPlayerCenterFromWorldPoint(global::NetUser player, ref global::UnityEngine.Vector3 worldPoint, out global::PlayerCullInfo info)
	{
		return global::CullGrid.SetPlayerCenterFromCellID(player, (int)global::CullGrid.WorldCell(ref worldPoint), out info);
	}

	// Token: 0x06001B55 RID: 6997 RVA: 0x0006CF3C File Offset: 0x0006B13C
	public static global::CullGrid.CullResultFlags SetPlayerCenterFromFlatPoint(global::NetUser player, global::UnityEngine.Vector2 flatPoint)
	{
		global::PlayerCullInfo playerCullInfo;
		return global::CullGrid.SetPlayerCenterFromFlatPoint(player, ref flatPoint, out playerCullInfo);
	}

	// Token: 0x06001B56 RID: 6998 RVA: 0x0006CF54 File Offset: 0x0006B154
	private static global::CullGrid.CullResultFlags SetPlayerCenterFromFlatPoint(global::NetUser player, ref global::UnityEngine.Vector2 flatPoint, out global::PlayerCullInfo info)
	{
		return global::CullGrid.SetPlayerCenterFromCellID(player, (int)global::CullGrid.FlatCell(ref flatPoint), out info);
	}

	// Token: 0x06001B57 RID: 6999 RVA: 0x0006CF64 File Offset: 0x0006B164
	public static global::CullGrid.CullResultFlags ClearPlayerCulling(global::NetUser player)
	{
		global::PlayerCullInfo playerCullInfo;
		if (!global::CullGrid.GetPlayerCullInfo(player, out playerCullInfo))
		{
			global::CullGrid.g.RemoveQueue_NoInfo(player);
			return global::CullGrid.CullResultFlags.NoProblem;
		}
		global::CullGrid.g.RemoveQueue(player, playerCullInfo);
		global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT.Remove(player);
		player.cullinfo = null;
		global::Facepunch.NetworkView[] array = null;
		foreach (ushort num in playerCullInfo.groups)
		{
			if (!global::CullGrid.RemovePlayerFromCell(player, num))
			{
				global::uLink.NetworkGroup networkGroup = (int)num + global::CullGrid.grid.groupBegin;
				bool flag = false;
				global::Facepunch.NetworkView[] array2;
				if ((array2 = array) == null)
				{
					array2 = (array = global::Facepunch.NetworkView.FindByOwner(player.networkPlayer));
				}
				foreach (global::Facepunch.NetworkView networkView in array2)
				{
					if (networkView && networkView.group == networkGroup)
					{
						global::NetCull.Destroy(networkView);
						flag = true;
					}
				}
				if (!flag)
				{
					global::UnityEngine.Debug.LogWarning("No views owned by player, but failed to remove player from group");
				}
				else if (!global::CullGrid.RemovePlayerFromCell(player, num))
				{
					global::UnityEngine.Debug.LogWarning("Destroyed all owned views of player, still could not remove player from group");
				}
			}
		}
		playerCullInfo.groups.Clear();
		return global::CullGrid.CullResultFlags.NoProblem | global::CullGrid.CullResultFlags.Destroyed;
	}

	// Token: 0x06001B58 RID: 7000 RVA: 0x0006D0B0 File Offset: 0x0006B2B0
	public static bool CellContainsPoint(ushort cell, ref global::UnityEngine.Vector2 flatPoint)
	{
		return cell == global::CullGrid.grid.FlatCell(ref flatPoint);
	}

	// Token: 0x06001B59 RID: 7001 RVA: 0x0006D0C0 File Offset: 0x0006B2C0
	public static bool CellContainsPoint(ushort cell, ref global::UnityEngine.Vector2 flatPoint, out ushort cell_point)
	{
		cell_point = global::CullGrid.grid.FlatCell(ref flatPoint);
		return cell == cell_point;
	}

	// Token: 0x06001B5A RID: 7002 RVA: 0x0006D0D4 File Offset: 0x0006B2D4
	public static bool CellContainsPoint(ushort cell, ref global::UnityEngine.Vector3 worldPoint)
	{
		return cell == global::CullGrid.grid.WorldCell(ref worldPoint);
	}

	// Token: 0x06001B5B RID: 7003 RVA: 0x0006D0E4 File Offset: 0x0006B2E4
	public static bool CellContainsPoint(ushort cell, ref global::UnityEngine.Vector3 worldPoint, out ushort cell_point)
	{
		cell_point = global::CullGrid.grid.WorldCell(ref worldPoint);
		return cell_point == cell;
	}

	// Token: 0x06001B5C RID: 7004 RVA: 0x0006D0F8 File Offset: 0x0006B2F8
	public static bool GroupIDContainsPoint(int groupID, ref global::UnityEngine.Vector2 flatPoint, out int groupID_point)
	{
		if (groupID < global::CullGrid.grid.groupBegin || groupID >= global::CullGrid.grid.groupEnd)
		{
			global::uLink.NetworkGroup unassigned = global::uLink.NetworkGroup.unassigned;
			groupID_point = unassigned.id;
			return false;
		}
		ushort num;
		if (!global::CullGrid.CellContainsPoint((ushort)(groupID - global::CullGrid.grid.groupBegin), ref flatPoint, out num))
		{
			groupID_point = (int)num + global::CullGrid.grid.groupBegin;
			return false;
		}
		groupID_point = groupID;
		return true;
	}

	// Token: 0x06001B5D RID: 7005 RVA: 0x0006D164 File Offset: 0x0006B364
	public static bool GroupIDContainsPoint(int groupID, ref global::UnityEngine.Vector3 worldPoint, out int groupID_point)
	{
		if (groupID < global::CullGrid.grid.groupBegin || groupID >= global::CullGrid.grid.groupEnd)
		{
			global::uLink.NetworkGroup unassigned = global::uLink.NetworkGroup.unassigned;
			groupID_point = unassigned.id;
			return false;
		}
		ushort cell;
		if (!global::CullGrid.CellContainsPoint(global::CullGrid.CellFromGroupID(groupID), ref worldPoint, out cell))
		{
			groupID_point = global::CullGrid.GroupIDFromCell(cell);
			return false;
		}
		groupID_point = groupID;
		return true;
	}

	// Token: 0x06001B5E RID: 7006 RVA: 0x0006D1C4 File Offset: 0x0006B3C4
	public static bool GroupIDContainsPoint(int groupID, ref global::UnityEngine.Vector2 flatPoint)
	{
		return groupID >= global::CullGrid.grid.groupBegin && groupID < global::CullGrid.grid.groupEnd && global::CullGrid.CellContainsPoint((ushort)(groupID - global::CullGrid.grid.groupBegin), ref flatPoint);
	}

	// Token: 0x06001B5F RID: 7007 RVA: 0x0006D208 File Offset: 0x0006B408
	public static bool GroupIDContainsPoint(int groupID, ref global::UnityEngine.Vector3 worldPoint)
	{
		return groupID >= global::CullGrid.grid.groupBegin && groupID < global::CullGrid.grid.groupEnd && global::CullGrid.CellContainsPoint((ushort)(groupID - global::CullGrid.grid.groupBegin), ref worldPoint);
	}

	// Token: 0x06001B60 RID: 7008 RVA: 0x0006D24C File Offset: 0x0006B44C
	public static global::UnityEngine.Vector2 Flat(global::UnityEngine.Vector3 triD)
	{
		global::UnityEngine.Vector2 result;
		result.x = triD.x;
		result.y = triD.z;
		return result;
	}

	// Token: 0x06001B61 RID: 7009 RVA: 0x0006D278 File Offset: 0x0006B478
	public static ushort FlatCell(global::UnityEngine.Vector2 flat)
	{
		return global::CullGrid.grid.FlatCell(ref flat);
	}

	// Token: 0x06001B62 RID: 7010 RVA: 0x0006D288 File Offset: 0x0006B488
	public static ushort WorldCell(global::UnityEngine.Vector3 world)
	{
		return global::CullGrid.grid.WorldCell(ref world);
	}

	// Token: 0x06001B63 RID: 7011 RVA: 0x0006D298 File Offset: 0x0006B498
	public static ushort FlatCell(ref global::UnityEngine.Vector2 flat)
	{
		return global::CullGrid.grid.FlatCell(ref flat);
	}

	// Token: 0x06001B64 RID: 7012 RVA: 0x0006D2A8 File Offset: 0x0006B4A8
	public static ushort WorldCell(ref global::UnityEngine.Vector3 world)
	{
		return global::CullGrid.grid.WorldCell(ref world);
	}

	// Token: 0x06001B65 RID: 7013 RVA: 0x0006D2B8 File Offset: 0x0006B4B8
	public static int FlatGroupID(ref global::UnityEngine.Vector2 flat)
	{
		return (int)global::CullGrid.grid.FlatCell(ref flat) + global::CullGrid.grid.groupBegin;
	}

	// Token: 0x06001B66 RID: 7014 RVA: 0x0006D2D0 File Offset: 0x0006B4D0
	public static int WorldGroupID(ref global::UnityEngine.Vector3 world)
	{
		return (int)global::CullGrid.grid.WorldCell(ref world) + global::CullGrid.grid.groupBegin;
	}

	// Token: 0x06001B67 RID: 7015 RVA: 0x0006D2E8 File Offset: 0x0006B4E8
	private static void RaycastDownVect(ref global::UnityEngine.Vector3 a)
	{
		global::UnityEngine.RaycastHit raycastHit;
		if (global::UnityEngine.Physics.Raycast(new global::UnityEngine.Vector3(a.x, 10000f, a.z), global::UnityEngine.Vector3.down, ref raycastHit, float.PositiveInfinity))
		{
			a = raycastHit.point + global::UnityEngine.Vector3.up * a.y;
		}
	}

	// Token: 0x06001B68 RID: 7016 RVA: 0x0006D344 File Offset: 0x0006B544
	private static void DrawQuadRayCastDown(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b, global::UnityEngine.Vector3 c, global::UnityEngine.Vector3 d)
	{
		global::CullGrid.RaycastDownVect(ref a);
		global::CullGrid.RaycastDownVect(ref b);
		global::CullGrid.RaycastDownVect(ref c);
		global::CullGrid.RaycastDownVect(ref d);
		global::UnityEngine.Gizmos.DrawLine(a, b);
		global::UnityEngine.Gizmos.DrawLine(b, c);
		global::UnityEngine.Gizmos.DrawLine(c, d);
		global::UnityEngine.Gizmos.DrawLine(d, a);
		if (a.y > c.y)
		{
			if (b.y > d.y)
			{
				if (b.y - d.y > a.y - c.y)
				{
					global::UnityEngine.Gizmos.DrawLine(b, d);
				}
				else
				{
					global::UnityEngine.Gizmos.DrawLine(a, c);
				}
			}
			else if (d.y - b.y > a.y - c.y)
			{
				global::UnityEngine.Gizmos.DrawLine(d, b);
			}
			else
			{
				global::UnityEngine.Gizmos.DrawLine(a, c);
			}
		}
		else if (b.y > d.y)
		{
			if (b.y - d.y > c.y - a.y)
			{
				global::UnityEngine.Gizmos.DrawLine(b, d);
			}
			else
			{
				global::UnityEngine.Gizmos.DrawLine(c, a);
			}
		}
		else if (d.y - b.y > c.y - a.y)
		{
			global::UnityEngine.Gizmos.DrawLine(d, b);
		}
		else
		{
			global::UnityEngine.Gizmos.DrawLine(c, a);
		}
	}

	// Token: 0x06001B69 RID: 7017 RVA: 0x0006D4AC File Offset: 0x0006B6AC
	private void DrawGizmosNow()
	{
	}

	// Token: 0x06001B6A RID: 7018 RVA: 0x0006D4B0 File Offset: 0x0006B6B0
	public static bool IsCellGroupID(int usedGroup)
	{
		return global::CullGrid.has_grid && usedGroup >= global::CullGrid.grid.groupBegin && usedGroup < global::CullGrid.grid.groupEnd;
	}

	// Token: 0x06001B6B RID: 7019 RVA: 0x0006D4E8 File Offset: 0x0006B6E8
	public static bool IsCellGroup(global::uLink.NetworkGroup group)
	{
		return global::CullGrid.IsCellGroupID(group.id);
	}

	// Token: 0x06001B6C RID: 7020 RVA: 0x0006D4F8 File Offset: 0x0006B6F8
	internal static global::CullGrid.CullResultFlags RegisterPlayerRootNetworkCullInfo(global::NetworkCullInfo cullInfo)
	{
		global::PlayerCullInfo playerCullInfo;
		global::CullGrid.CullResultFlags cullResultFlags = global::CullGrid.SetPlayerCenterFromGroupID(cullInfo.user, cullInfo.setGroupID, out playerCullInfo);
		if ((cullResultFlags & global::CullGrid.CullResultFlags.NoProblem) == global::CullGrid.CullResultFlags.NoProblem)
		{
			playerCullInfo.rootInfo = cullInfo;
			playerCullInfo.owned.Add(cullInfo);
		}
		return cullResultFlags;
	}

	// Token: 0x06001B6D RID: 7021 RVA: 0x0006D538 File Offset: 0x0006B738
	internal static global::CullGrid.CullResultFlags RegisterPlayerNonRootNetworkCullInfo(global::NetworkCullInfo cullInfo)
	{
		global::PlayerCullInfo playerCullInfo;
		if (!global::CullGrid.GetPlayerCullInfo(cullInfo.user, out playerCullInfo))
		{
			return global::CullGrid.CullResultFlags.Failed;
		}
		if (playerCullInfo.owned.Add(cullInfo))
		{
			return global::CullGrid.CullResultFlags.NoProblem | global::CullGrid.CullResultFlags.Registered;
		}
		return global::CullGrid.CullResultFlags.NoProblem;
	}

	// Token: 0x06001B6E RID: 7022 RVA: 0x0006D570 File Offset: 0x0006B770
	internal static global::CullGrid.CullResultFlags PrebindPlayerRootByGroupID(global::NetUser client, int willUseThisGroup)
	{
		return global::CullGrid.PrebindPlayerRootByCell(client, global::CullGrid.CellFromGroupID(willUseThisGroup));
	}

	// Token: 0x06001B6F RID: 7023 RVA: 0x0006D580 File Offset: 0x0006B780
	internal static global::CullGrid.CullResultFlags PrebindPlayerRootByCell(global::NetUser client, ushort willUseThisCell)
	{
		global::PlayerCullInfo info;
		if (global::CullGrid.GetPlayerCullInfo(client, out info))
		{
			return global::CullGrid.PrebindPlayerRootByCell(client, info, willUseThisCell);
		}
		global::CullGrid.CullResultFlags cullResultFlags = global::CullGrid.NewPlayerCullInfo(client, (int)willUseThisCell, out info);
		if ((cullResultFlags & global::CullGrid.CullResultFlags.NoProblem) != global::CullGrid.CullResultFlags.NoProblem)
		{
			return cullResultFlags;
		}
		global::CullGrid.CullResultFlags cullResultFlags2 = global::CullGrid.PrebindPlayerRootByCell(client, info, willUseThisCell);
		if (cullResultFlags2 == global::CullGrid.CullResultFlags.Failed)
		{
			return global::CullGrid.CullResultFlags.Failed;
		}
		return cullResultFlags | cullResultFlags2;
	}

	// Token: 0x06001B70 RID: 7024 RVA: 0x0006D5CC File Offset: 0x0006B7CC
	private static global::CullGrid.CullResultFlags PrebindPlayerRootByGroupID(global::NetUser client, global::PlayerCullInfo info, int willUseThisGroup)
	{
		return global::CullGrid.PrebindPlayerRootByCell(client, info, global::CullGrid.CellFromGroupID(willUseThisGroup));
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x0006D5DC File Offset: 0x0006B7DC
	private static global::CullGrid.CullResultFlags PrebindPlayerRootByCell(global::NetUser client, global::PlayerCullInfo info, ushort willUseThisCell)
	{
		if ((int)willUseThisCell >= global::CullGrid.grid.numCells)
		{
			throw new global::System.ArgumentOutOfRangeException("willUseThisCell", willUseThisCell, "willUseThisCell>=grid.numCells");
		}
		if (!info.groups.Add(willUseThisCell))
		{
			return global::CullGrid.CullResultFlags.NoProblem;
		}
		if (global::CullGrid.AddPlayerToCell(client, willUseThisCell))
		{
			return global::CullGrid.CullResultFlags.NoProblem | global::CullGrid.CullResultFlags.Prebound;
		}
		info.groups.Remove(willUseThisCell);
		return global::CullGrid.CullResultFlags.Failed;
	}

	// Token: 0x06001B72 RID: 7026 RVA: 0x0006D640 File Offset: 0x0006B840
	internal static bool UpdatePlayerCenterFromPlayerRoot(global::NetworkCullInfo playerRoot)
	{
		global::PlayerCullInfo playerCullInfo;
		if (global::CullGrid.GetPlayerCullInfo(playerRoot.user, out playerCullInfo) && playerCullInfo.rootInfo == playerRoot && global::CullGrid.g_root_update.pending.Add(playerRoot))
		{
			if (global::CullGrid.cull_prebinding)
			{
				global::CullGrid.PrebindPlayerRootByGroupID(playerRoot.user, playerCullInfo, playerRoot.setGroupID);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06001B73 RID: 7027 RVA: 0x0006D6A0 File Offset: 0x0006B8A0
	internal static void ApplyUpdatedPlayerCentersFromPlayerRoots()
	{
		foreach (global::NetworkCullInfo networkCullInfo in global::CullGrid.g_root_update.pending)
		{
			if (networkCullInfo)
			{
				global::CullGrid.SetPlayerCenterFromGroupID(networkCullInfo.user, networkCullInfo.setGroupID);
			}
		}
		global::CullGrid.g_root_update.pending.Clear();
	}

	// Token: 0x06001B74 RID: 7028 RVA: 0x0006D728 File Offset: 0x0006B928
	internal static bool DelistPlayerRootNetworkCullInfo(global::NetworkCullInfo cullInfo)
	{
		global::PlayerCullInfo playerCullInfo;
		if (global::CullGrid.GetPlayerCullInfo(cullInfo.user, out playerCullInfo) && playerCullInfo.rootInfo == cullInfo)
		{
			playerCullInfo.rootInfo = null;
			playerCullInfo.owned.Remove(cullInfo);
			return true;
		}
		return false;
	}

	// Token: 0x06001B75 RID: 7029 RVA: 0x0006D770 File Offset: 0x0006B970
	internal static bool DelistPlayerNonRootNetworkCullInfo(global::NetworkCullInfo cullInfo)
	{
		global::PlayerCullInfo playerCullInfo;
		return global::CullGrid.GetPlayerCullInfo(cullInfo.user, out playerCullInfo) && playerCullInfo.rootInfo != cullInfo && playerCullInfo.owned.Remove(cullInfo);
	}

	// Token: 0x06001B76 RID: 7030 RVA: 0x0006D7B0 File Offset: 0x0006B9B0
	private static void ForceRefreshAll()
	{
		foreach (global::System.Collections.Generic.KeyValuePair<global::NetUser, global::PlayerCullInfo> keyValuePair in global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT)
		{
			global::CullGrid.ForceRefreshPlayer(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x06001B77 RID: 7031 RVA: 0x0006D824 File Offset: 0x0006BA24
	private static void ForceRefreshPlayer(global::uLink.NetworkPlayer player)
	{
		global::NetUser netUser = global::NetUser.Find(player);
		if (netUser != null)
		{
			global::PlayerCullInfo info;
			if (global::CullGrid.GetPlayerCullInfo(netUser, out info))
			{
				global::CullGrid.ForceRefreshPlayer(netUser, info);
			}
		}
	}

	// Token: 0x06001B78 RID: 7032 RVA: 0x0006D85C File Offset: 0x0006BA5C
	private static void ForceRefreshPlayer(global::NetUser player, global::PlayerCullInfo info)
	{
		global::System.Collections.Generic.HashSet<ushort> hashSet = info.queuedGroups;
		bool flag;
		if (hashSet == null)
		{
			if (flag = (info.groups.Count > 0))
			{
				hashSet = new global::System.Collections.Generic.HashSet<ushort>(info.groups);
			}
			else
			{
				hashSet = null;
			}
		}
		else
		{
			flag = (hashSet.Count > 0);
			global::CullGrid.g.RemoveQueue(player, info);
		}
		foreach (ushort num in info.groups)
		{
			if (global::CullGrid.RemovePlayerFromCell(player, num))
			{
				global::CullGrid.forceWork.tempCellWork.Add(num);
			}
		}
		info.groups.ExceptWith(global::CullGrid.forceWork.tempCellWork);
		global::CullGrid.forceWork.tempCellWork.Clear();
		if (flag)
		{
			global::CullGrid.g.AddQueue(player, info, hashSet);
		}
	}

	// Token: 0x06001B79 RID: 7033 RVA: 0x0006D948 File Offset: 0x0006BB48
	private static void listplayergroups(global::uLink.NetworkPlayer player)
	{
		global::NetUser netUser = global::NetUser.Find(player);
		if (netUser != null)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			stringBuilder.AppendFormat("{0} groups = ", netUser);
			global::PlayerCullInfo playerCullInfo;
			if (global::CullGrid.GetPlayerCullInfo(netUser, out playerCullInfo))
			{
				stringBuilder.Append('[');
				bool flag = false;
				foreach (ushort cell in playerCullInfo.groups)
				{
					if (flag)
					{
						stringBuilder.Append(',');
						stringBuilder.Append(global::CullGrid.GroupIDFromCell(cell));
					}
					else
					{
						stringBuilder.Append(global::CullGrid.GroupIDFromCell(cell));
						flag = true;
					}
				}
				stringBuilder.AppendFormat("]({0})", playerCullInfo.groups.Count);
			}
			else
			{
				stringBuilder.Append("<-- no cull info -->");
			}
		}
	}

	// Token: 0x04001001 RID: 4097
	private static bool cull_prebinding = true;

	// Token: 0x04001002 RID: 4098
	[global::UnityEngine.SerializeField]
	private global::CullGridSetup setup;

	// Token: 0x04001003 RID: 4099
	private static global::CullGrid.CullGridRuntime grid;

	// Token: 0x04001004 RID: 4100
	private static bool has_grid;

	// Token: 0x04001005 RID: 4101
	private static bool g_init;

	// Token: 0x04001006 RID: 4102
	private static bool CHANGE_QUEUE_ACTIVE;

	// Token: 0x04001007 RID: 4103
	private static global::Facepunch.NetworkView[] testingCells;

	// Token: 0x04001008 RID: 4104
	private static bool _registeredOnce;

	// Token: 0x0200032E RID: 814
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 2)]
	public struct CellID
	{
		// Token: 0x06001B7A RID: 7034 RVA: 0x0006DA48 File Offset: 0x0006BC48
		public CellID(ushort cellID)
		{
			this.id = cellID;
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x06001B7B RID: 7035 RVA: 0x0006DA54 File Offset: 0x0006BC54
		public global::UnityEngine.Vector2 flatCenter
		{
			get
			{
				global::UnityEngine.Vector2 result;
				global::CullGrid.grid.GetCenter((int)this.id, out result);
				return result;
			}
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06001B7C RID: 7036 RVA: 0x0006DA74 File Offset: 0x0006BC74
		public global::UnityEngine.Vector2 flatMax
		{
			get
			{
				global::UnityEngine.Vector2 result;
				global::CullGrid.grid.GetMin((int)this.id, out result);
				return result;
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x06001B7D RID: 7037 RVA: 0x0006DA94 File Offset: 0x0006BC94
		public global::UnityEngine.Vector2 flatMin
		{
			get
			{
				global::UnityEngine.Vector2 result;
				global::CullGrid.grid.GetMax((int)this.id, out result);
				return result;
			}
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x06001B7E RID: 7038 RVA: 0x0006DAB4 File Offset: 0x0006BCB4
		public global::UnityEngine.Rect flatRect
		{
			get
			{
				global::UnityEngine.Rect result;
				global::CullGrid.grid.GetRect((int)this.id, out result);
				return result;
			}
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x06001B7F RID: 7039 RVA: 0x0006DAD4 File Offset: 0x0006BCD4
		public global::UnityEngine.Vector3 worldCenter
		{
			get
			{
				global::UnityEngine.Vector3 result;
				global::CullGrid.grid.GetCenter((int)this.id, out result);
				return result;
			}
		}

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x06001B80 RID: 7040 RVA: 0x0006DAF4 File Offset: 0x0006BCF4
		public global::UnityEngine.Vector3 worldMax
		{
			get
			{
				global::UnityEngine.Vector3 result;
				global::CullGrid.grid.GetMin((int)this.id, out result);
				return result;
			}
		}

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06001B81 RID: 7041 RVA: 0x0006DB14 File Offset: 0x0006BD14
		public global::UnityEngine.Vector3 worldMin
		{
			get
			{
				global::UnityEngine.Vector3 result;
				global::CullGrid.grid.GetMax((int)this.id, out result);
				return result;
			}
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06001B82 RID: 7042 RVA: 0x0006DB34 File Offset: 0x0006BD34
		public global::UnityEngine.Bounds worldBounds
		{
			get
			{
				global::UnityEngine.Bounds result;
				global::CullGrid.grid.GetBounds((int)this.id, out result);
				return result;
			}
		}

		// Token: 0x06001B83 RID: 7043 RVA: 0x0006DB54 File Offset: 0x0006BD54
		public bool ContainsWorldPoint(global::UnityEngine.Vector3 worldPoint)
		{
			return global::CullGrid.grid.Contains((int)this.id, ref worldPoint);
		}

		// Token: 0x06001B84 RID: 7044 RVA: 0x0006DB68 File Offset: 0x0006BD68
		public bool ContainsFlatPoint(global::UnityEngine.Vector2 flatPoint)
		{
			return global::CullGrid.grid.Contains((int)this.id, ref flatPoint);
		}

		// Token: 0x06001B85 RID: 7045 RVA: 0x0006DB7C File Offset: 0x0006BD7C
		public bool ContainsWorldPoint(ref global::UnityEngine.Vector3 worldPoint)
		{
			return this.valid && global::CullGrid.grid.Contains((int)this.id, ref worldPoint);
		}

		// Token: 0x06001B86 RID: 7046 RVA: 0x0006DBA0 File Offset: 0x0006BDA0
		public bool ContainsFlatPoint(ref global::UnityEngine.Vector2 flatPoint)
		{
			return this.valid && global::CullGrid.grid.Contains((int)this.id, ref flatPoint);
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06001B87 RID: 7047 RVA: 0x0006DBC4 File Offset: 0x0006BDC4
		public int column
		{
			get
			{
				return (!this.valid) ? -1 : ((int)this.id % global::CullGrid.grid.cellsWide);
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06001B88 RID: 7048 RVA: 0x0006DBF4 File Offset: 0x0006BDF4
		public int row
		{
			get
			{
				return (!this.valid) ? -1 : ((int)this.id / global::CullGrid.grid.cellsWide);
			}
		}

		// Token: 0x06001B89 RID: 7049 RVA: 0x0006DC24 File Offset: 0x0006BE24
		private static ushort NextRight(ushort id)
		{
			return ((int)id % global::CullGrid.grid.cellsWide != (int)global::CullGrid.grid.cellWideLast) ? (id + 1) : ushort.MaxValue;
		}

		// Token: 0x06001B8A RID: 7050 RVA: 0x0006DC50 File Offset: 0x0006BE50
		private static ushort NextLeft(ushort id)
		{
			return ((int)id % global::CullGrid.grid.cellsWide != 0) ? (id - 1) : ushort.MaxValue;
		}

		// Token: 0x06001B8B RID: 7051 RVA: 0x0006DC74 File Offset: 0x0006BE74
		private static ushort NextUp(ushort id)
		{
			return ((int)id / global::CullGrid.grid.cellsWide != (int)global::CullGrid.grid.cellTallLast) ? ((ushort)((int)id + global::CullGrid.grid.cellsWide)) : ushort.MaxValue;
		}

		// Token: 0x06001B8C RID: 7052 RVA: 0x0006DCB4 File Offset: 0x0006BEB4
		private static ushort NextDown(ushort id)
		{
			return ((int)id / global::CullGrid.grid.cellsWide != 0) ? ((ushort)((int)id - global::CullGrid.grid.cellsWide)) : ushort.MaxValue;
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06001B8D RID: 7053 RVA: 0x0006DCEC File Offset: 0x0006BEEC
		public global::CullGrid.CellID right
		{
			get
			{
				global::CullGrid.CellID result;
				result.id = ((!this.valid) ? ushort.MaxValue : global::CullGrid.CellID.NextRight(this.id));
				return result;
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06001B8E RID: 7054 RVA: 0x0006DD24 File Offset: 0x0006BF24
		public global::CullGrid.CellID left
		{
			get
			{
				global::CullGrid.CellID result;
				result.id = ((!this.valid) ? ushort.MaxValue : global::CullGrid.CellID.NextLeft(this.id));
				return result;
			}
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06001B8F RID: 7055 RVA: 0x0006DD5C File Offset: 0x0006BF5C
		public global::CullGrid.CellID up
		{
			get
			{
				global::CullGrid.CellID result;
				result.id = ((!this.valid) ? ushort.MaxValue : global::CullGrid.CellID.NextUp(this.id));
				return result;
			}
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06001B90 RID: 7056 RVA: 0x0006DD94 File Offset: 0x0006BF94
		public global::CullGrid.CellID down
		{
			get
			{
				global::CullGrid.CellID result;
				result.id = ((!this.valid) ? ushort.MaxValue : global::CullGrid.CellID.NextDown(this.id));
				return result;
			}
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06001B91 RID: 7057 RVA: 0x0006DDCC File Offset: 0x0006BFCC
		public bool mostRight
		{
			get
			{
				return this.valid && (int)this.id % global::CullGrid.grid.cellsWide == (int)global::CullGrid.grid.cellWideLast;
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06001B92 RID: 7058 RVA: 0x0006DDFC File Offset: 0x0006BFFC
		public bool mostLeft
		{
			get
			{
				return this.valid && (int)this.id % global::CullGrid.grid.cellsWide == 0;
			}
		}

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x06001B93 RID: 7059 RVA: 0x0006DE2C File Offset: 0x0006C02C
		public bool mostTop
		{
			get
			{
				return this.valid && (int)this.id / global::CullGrid.grid.cellsWide == (int)global::CullGrid.grid.cellTallLast;
			}
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06001B94 RID: 7060 RVA: 0x0006DE5C File Offset: 0x0006C05C
		public bool mostBottom
		{
			get
			{
				return this.valid && (int)this.id / global::CullGrid.grid.cellsWide == 0;
			}
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06001B95 RID: 7061 RVA: 0x0006DE8C File Offset: 0x0006C08C
		public bool valid
		{
			get
			{
				return (int)this.id < global::CullGrid.grid.numCells;
			}
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06001B96 RID: 7062 RVA: 0x0006DEA0 File Offset: 0x0006C0A0
		public int groupID
		{
			get
			{
				int result;
				if (this.valid)
				{
					result = global::CullGrid.GroupIDFromCell(this.id);
				}
				else
				{
					global::uLink.NetworkGroup unassigned = global::uLink.NetworkGroup.unassigned;
					result = unassigned.id;
				}
				return result;
			}
		}

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06001B97 RID: 7063 RVA: 0x0006DED8 File Offset: 0x0006C0D8
		public global::uLink.NetworkGroup group
		{
			get
			{
				return (!this.valid) ? global::uLink.NetworkGroup.unassigned : global::CullGrid.GroupIDFromCell(this.id);
			}
		}

		// Token: 0x04001009 RID: 4105
		private const ushort kInvalidID = 0xFFFF;

		// Token: 0x0400100A RID: 4106
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public ushort id;
	}

	// Token: 0x0200032F RID: 815
	private class CullGridRuntime : global::CullGridSetup
	{
		// Token: 0x06001B98 RID: 7064 RVA: 0x0006DF00 File Offset: 0x0006C100
		public CullGridRuntime(global::CullGrid cullGrid) : base(cullGrid.setup)
		{
			this.cullGrid = cullGrid;
			this.transform = cullGrid.transform;
			this.halfCellTall = (double)this.cellsTall / 2.0;
			this.halfCellWide = (double)this.cellsWide / 2.0;
			this.twoMinusOddTall = 2 - (this.cellsTall & 1);
			this.twoMinusOddWide = 2 - (this.cellsWide & 1);
			this.halfTwoMinusOddTall = (double)this.twoMinusOddTall / 2.0;
			this.halfTwoMinusOddWide /= 2.0;
			this.halfCellTallMinusHalfTwoMinusOddTall = this.halfCellTall - this.halfTwoMinusOddTall;
			this.halfCellWideMinusHalfTwoMinusOddWide = this.halfCellWide - this.halfTwoMinusOddWide;
			global::UnityEngine.Vector3 forward = this.transform.forward;
			global::UnityEngine.Vector3 right = this.transform.right;
			global::UnityEngine.Vector3 position = this.transform.position;
			this.fx = (double)forward.x;
			this.fy = (double)forward.y;
			this.fz = (double)forward.z;
			double num = global::System.Math.Sqrt(this.fx * this.fx + this.fy * this.fy + this.fz * this.fz);
			this.fx /= num;
			this.fy /= num;
			this.fz /= num;
			this.rx = (double)right.x;
			this.ry = (double)right.y;
			this.rz = (double)right.z;
			num = global::System.Math.Sqrt(this.rx * this.rx + this.ry * this.ry + this.rz * this.rz);
			this.rx /= num;
			this.ry /= num;
			this.rz /= num;
			this.px = (double)position.x;
			this.py = (double)position.y;
			this.pz = (double)position.z;
			this.flat_wide_ofs = (double)this.cellSquareDimension * (this.halfCellWide - (double)(1 - (this.cellsWide & 1)) / 2.0);
			this.flat_tall_ofs = (double)this.cellSquareDimension * (this.halfCellTall - (double)(1 - (this.cellsTall & 1)) / 2.0);
			this.cellTallLast = (ushort)(this.cellsTall - 1);
			this.cellWideLast = (ushort)(this.cellsWide - 1);
			this.cellTallLastTimesSquareDimension = (double)this.cellTallLast * (double)this.cellSquareDimension;
			this.cellWideLastTimesSquareDimension = (double)this.cellWideLast * (double)this.cellSquareDimension;
			this.numCells = this.cellsTall * this.cellsWide;
			this.groupEnd = this.groupBegin + this.numCells;
		}

		// Token: 0x06001B99 RID: 7065 RVA: 0x0006E1E4 File Offset: 0x0006C3E4
		public void GetCenter(int cell, out global::UnityEngine.Vector3 center)
		{
			double num = ((double)(cell % this.cellsWide) - this.halfCellWideMinusHalfTwoMinusOddWide) * (double)this.cellSquareDimension;
			double num2 = ((double)(cell / this.cellsWide) - this.halfCellTallMinusHalfTwoMinusOddTall) * (double)this.cellSquareDimension;
			center.x = (float)(this.px + this.fx * num2 + this.rx * num);
			center.y = (float)(this.py + this.fy * num2 + this.ry * num);
			center.z = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001B9A RID: 7066 RVA: 0x0006E280 File Offset: 0x0006C480
		public void GetCenter(int cell, out global::UnityEngine.Vector2 center)
		{
			double num = ((double)(cell % this.cellsWide) - this.halfCellWideMinusHalfTwoMinusOddWide) * (double)this.cellSquareDimension;
			double num2 = ((double)(cell / this.cellsWide) - this.halfCellTallMinusHalfTwoMinusOddTall) * (double)this.cellSquareDimension;
			center.x = (float)(this.px + this.fx * num2 + this.rx * num);
			center.y = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001B9B RID: 7067 RVA: 0x0006E300 File Offset: 0x0006C500
		public void GetCenter(int x, int y, out global::UnityEngine.Vector3 center)
		{
			double num = ((double)x - this.halfCellWideMinusHalfTwoMinusOddWide) * (double)this.cellSquareDimension;
			double num2 = ((double)y - this.halfCellTallMinusHalfTwoMinusOddTall) * (double)this.cellSquareDimension;
			center.x = (float)(this.px + this.fx * num2 + this.rx * num);
			center.y = (float)(this.py + this.fy * num2 + this.ry * num);
			center.z = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001B9C RID: 7068 RVA: 0x0006E390 File Offset: 0x0006C590
		public void GetCenter(int x, int y, out global::UnityEngine.Vector2 center)
		{
			double num = ((double)x - this.halfCellWideMinusHalfTwoMinusOddWide) * (double)this.cellSquareDimension;
			double num2 = ((double)y - this.halfCellTallMinusHalfTwoMinusOddTall) * (double)this.cellSquareDimension;
			center.x = (float)(this.px + this.fx * num2 + this.rx * num);
			center.y = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001B9D RID: 7069 RVA: 0x0006E400 File Offset: 0x0006C600
		public void GetMin(int cell, out global::UnityEngine.Vector3 min)
		{
			double num = ((double)(cell % this.cellsWide) - this.halfCellWideMinusHalfTwoMinusOddWide - 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)(cell / this.cellsWide) - this.halfCellTallMinusHalfTwoMinusOddTall - 0.5) * (double)this.cellSquareDimension;
			min.x = (float)(this.px + this.fx * num2 + this.rx * num);
			min.y = (float)(-32000.0 + (this.py + this.fy * num2 + this.ry * num));
			min.z = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001B9E RID: 7070 RVA: 0x0006E4BC File Offset: 0x0006C6BC
		public void GetMin(int cell, out global::UnityEngine.Vector2 min)
		{
			double num = ((double)(cell % this.cellsWide) - this.halfCellWideMinusHalfTwoMinusOddWide - 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)(cell / this.cellsWide) - this.halfCellTallMinusHalfTwoMinusOddTall - 0.5) * (double)this.cellSquareDimension;
			min.x = (float)(this.px + this.fx * num2 + this.rx * num);
			min.y = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001B9F RID: 7071 RVA: 0x0006E550 File Offset: 0x0006C750
		public void GetMin(int x, int y, out global::UnityEngine.Vector3 min)
		{
			double num = ((double)x - this.halfCellWideMinusHalfTwoMinusOddWide - 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)y - this.halfCellTallMinusHalfTwoMinusOddTall - 0.5) * (double)this.cellSquareDimension;
			min.x = (float)(this.px + this.fx * num2 + this.rx * num);
			min.y = (float)(-32000.0 + (this.py + this.fy * num2 + this.ry * num));
			min.z = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001BA0 RID: 7072 RVA: 0x0006E5FC File Offset: 0x0006C7FC
		public void GetMin(int x, int y, out global::UnityEngine.Vector2 min)
		{
			double num = ((double)x - this.halfCellWideMinusHalfTwoMinusOddWide - 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)y - this.halfCellTallMinusHalfTwoMinusOddTall - 0.5) * (double)this.cellSquareDimension;
			min.x = (float)(this.px + this.fx * num2 + this.rx * num);
			min.y = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001BA1 RID: 7073 RVA: 0x0006E680 File Offset: 0x0006C880
		public bool Contains(int cell, ref global::UnityEngine.Vector2 flatPoint)
		{
			return cell >= 0 && cell < this.numCells && (int)this.FlatCell(ref flatPoint) == cell;
		}

		// Token: 0x06001BA2 RID: 7074 RVA: 0x0006E6B0 File Offset: 0x0006C8B0
		public bool Contains(int cell, ref global::UnityEngine.Vector3 worldPoint)
		{
			return cell >= 0 && cell < this.numCells && (int)this.WorldCell(ref worldPoint) == cell;
		}

		// Token: 0x06001BA3 RID: 7075 RVA: 0x0006E6E0 File Offset: 0x0006C8E0
		public bool Contains(int x, int y, ref global::UnityEngine.Vector2 flatPoint)
		{
			return this.Contains(y * this.cellsWide + x, ref flatPoint);
		}

		// Token: 0x06001BA4 RID: 7076 RVA: 0x0006E6F4 File Offset: 0x0006C8F4
		public bool Contains(int x, int y, ref global::UnityEngine.Vector3 worldPoint)
		{
			return this.Contains(y * this.cellsWide + x, ref worldPoint);
		}

		// Token: 0x06001BA5 RID: 7077 RVA: 0x0006E708 File Offset: 0x0006C908
		public void GetRect(int x, int y, out global::UnityEngine.Rect rect)
		{
			double num = ((double)x - this.halfCellWideMinusHalfTwoMinusOddWide - 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)y - this.halfCellTallMinusHalfTwoMinusOddTall - 0.5) * (double)this.cellSquareDimension;
			double num3 = num + (double)this.cellSquareDimension;
			double num4 = num2 + (double)this.cellSquareDimension;
			double num5 = this.px + this.fx * num2 + this.rx * num;
			double num6 = this.px + this.fx * num4 + this.ry * num3;
			float num7;
			float num8;
			if (num5 < num6)
			{
				num7 = (float)num5;
				num8 = (float)(num6 - num5);
			}
			else
			{
				num7 = (float)num6;
				num8 = (float)(num5 - num6);
			}
			num5 = this.pz + this.fz * num2 + this.rx * num;
			num6 = this.pz + this.fz * num4 + this.rx * num3;
			float num9;
			float num10;
			if (num5 < num6)
			{
				num9 = (float)num5;
				num10 = (float)(num6 - num5);
			}
			else
			{
				num9 = (float)num6;
				num10 = (float)(num5 - num6);
			}
			rect..ctor(num7, num9, num8, num10);
		}

		// Token: 0x06001BA6 RID: 7078 RVA: 0x0006E828 File Offset: 0x0006CA28
		public void GetBounds(int x, int y, out global::UnityEngine.Bounds bounds)
		{
			global::UnityEngine.Vector3 vector;
			this.GetCenter(x, y, out vector);
			bounds..ctor(vector, new global::UnityEngine.Vector3((float)this.cellSquareDimension, 64000f, (float)this.cellSquareDimension));
		}

		// Token: 0x06001BA7 RID: 7079 RVA: 0x0006E860 File Offset: 0x0006CA60
		public void GetRect(int cell, out global::UnityEngine.Rect rect)
		{
			int num = cell % this.cellsWide;
			int num2 = cell / this.cellsWide;
			double num3 = ((double)num - this.halfCellWideMinusHalfTwoMinusOddWide - 0.5) * (double)this.cellSquareDimension;
			double num4 = ((double)num2 - this.halfCellTallMinusHalfTwoMinusOddTall - 0.5) * (double)this.cellSquareDimension;
			double num5 = num3 + (double)this.cellSquareDimension;
			double num6 = num4 + (double)this.cellSquareDimension;
			double num7 = this.px + this.fx * num4 + this.rx * num3;
			double num8 = this.px + this.fx * num6 + this.ry * num5;
			float num9;
			float num10;
			if (num7 < num8)
			{
				num9 = (float)num7;
				num10 = (float)(num8 - num7);
			}
			else
			{
				num9 = (float)num8;
				num10 = (float)(num7 - num8);
			}
			num7 = this.pz + this.fz * num4 + this.rx * num3;
			num8 = this.pz + this.fz * num6 + this.rx * num5;
			float num11;
			float num12;
			if (num7 < num8)
			{
				num11 = (float)num7;
				num12 = (float)(num8 - num7);
			}
			else
			{
				num11 = (float)num8;
				num12 = (float)(num7 - num8);
			}
			rect..ctor(num9, num11, num10, num12);
		}

		// Token: 0x06001BA8 RID: 7080 RVA: 0x0006E998 File Offset: 0x0006CB98
		public void GetBounds(int cell, out global::UnityEngine.Bounds bounds)
		{
			int x = cell % this.cellsWide;
			int y = cell / this.cellsWide;
			global::UnityEngine.Vector3 vector;
			this.GetCenter(x, y, out vector);
			bounds..ctor(vector, new global::UnityEngine.Vector3((float)this.cellSquareDimension, 64000f, (float)this.cellSquareDimension));
		}

		// Token: 0x06001BA9 RID: 7081 RVA: 0x0006E9E0 File Offset: 0x0006CBE0
		public void GetMax(int cell, out global::UnityEngine.Vector3 max)
		{
			double num = ((double)(cell % this.cellsWide) - this.halfCellWideMinusHalfTwoMinusOddWide + 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)(cell / this.cellsWide) - this.halfCellTallMinusHalfTwoMinusOddTall + 0.5) * (double)this.cellSquareDimension;
			max.x = (float)(this.px + this.fx * num2 + this.rx * num);
			max.y = (float)(32000.0 + (this.py + this.fy * num2 + this.ry * num));
			max.z = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001BAA RID: 7082 RVA: 0x0006EA9C File Offset: 0x0006CC9C
		public void GetMax(int cell, out global::UnityEngine.Vector2 max)
		{
			double num = ((double)(cell % this.cellsWide) - this.halfCellWideMinusHalfTwoMinusOddWide + 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)(cell / this.cellsWide) - this.halfCellTallMinusHalfTwoMinusOddTall + 0.5) * (double)this.cellSquareDimension;
			max.x = (float)(this.px + this.fx * num2 + this.rx * num);
			max.y = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001BAB RID: 7083 RVA: 0x0006EB30 File Offset: 0x0006CD30
		public void GetMax(int x, int y, out global::UnityEngine.Vector3 max)
		{
			double num = ((double)x - this.halfCellWideMinusHalfTwoMinusOddWide + 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)y - this.halfCellTallMinusHalfTwoMinusOddTall + 0.5) * (double)this.cellSquareDimension;
			max.x = (float)(this.px + this.fx * num2 + this.rx * num);
			max.y = (float)(32000.0 + (this.py + this.fy * num2 + this.ry * num));
			max.z = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001BAC RID: 7084 RVA: 0x0006EBDC File Offset: 0x0006CDDC
		public void GetMax(int x, int y, out global::UnityEngine.Vector2 max)
		{
			double num = ((double)x - this.halfCellTallMinusHalfTwoMinusOddTall + 0.5) * (double)this.cellSquareDimension;
			double num2 = ((double)y - this.halfCellTallMinusHalfTwoMinusOddTall + 0.5) * (double)this.cellSquareDimension;
			max.x = (float)(this.px + this.fx * num2 + this.rx * num);
			max.y = (float)(this.pz + this.fz * num2 + this.rz * num);
		}

		// Token: 0x06001BAD RID: 7085 RVA: 0x0006EC60 File Offset: 0x0006CE60
		public ushort FlatCell(ref global::UnityEngine.Vector2 point, out ushort x, out ushort y)
		{
			double num = (double)point.x + this.flat_wide_ofs;
			if (num <= 0.0)
			{
				x = 0;
			}
			else if (num >= this.cellWideLastTimesSquareDimension)
			{
				x = this.cellWideLast;
			}
			else
			{
				x = (ushort)global::System.Math.Floor(num / (double)this.cellSquareDimension);
			}
			double num2 = (double)point.y + this.flat_tall_ofs;
			if (num2 <= 0.0)
			{
				y = 0;
			}
			else if (num2 >= this.cellTallLastTimesSquareDimension)
			{
				y = this.cellTallLast;
			}
			else
			{
				y = (ushort)global::System.Math.Floor(num2 / (double)this.cellSquareDimension);
			}
			return (ushort)((int)y * this.cellsWide + (int)x);
		}

		// Token: 0x06001BAE RID: 7086 RVA: 0x0006ED1C File Offset: 0x0006CF1C
		public ushort FlatCell(ref global::UnityEngine.Vector2 point)
		{
			double num = (double)point.x + this.flat_wide_ofs;
			int num2;
			if (num <= 0.0)
			{
				num2 = 0;
			}
			else if (num >= this.cellWideLastTimesSquareDimension)
			{
				num2 = (int)this.cellWideLast;
			}
			else
			{
				num2 = (int)global::System.Math.Floor(num / (double)this.cellSquareDimension);
			}
			double num3 = (double)point.y + this.flat_tall_ofs;
			int num4;
			if (num3 <= 0.0)
			{
				num4 = 0;
			}
			else if (num3 >= this.cellTallLastTimesSquareDimension)
			{
				num4 = (int)this.cellTallLast;
			}
			else
			{
				num4 = (int)global::System.Math.Floor(num3 / (double)this.cellSquareDimension);
			}
			return (ushort)(num4 * this.cellsWide + num2);
		}

		// Token: 0x06001BAF RID: 7087 RVA: 0x0006EDD0 File Offset: 0x0006CFD0
		public ushort WorldCell(ref global::UnityEngine.Vector3 point, out ushort x, out ushort y)
		{
			double num = (double)point.x + this.flat_wide_ofs;
			if (num <= 0.0)
			{
				x = 0;
			}
			else if (num >= this.cellWideLastTimesSquareDimension)
			{
				x = this.cellWideLast;
			}
			else
			{
				x = (ushort)global::System.Math.Floor(num / (double)this.cellSquareDimension);
			}
			double num2 = (double)point.z + this.flat_tall_ofs;
			if (num2 <= 0.0)
			{
				y = 0;
			}
			else if (num2 >= this.cellTallLastTimesSquareDimension)
			{
				y = this.cellTallLast;
			}
			else
			{
				y = (ushort)global::System.Math.Floor(num2 / (double)this.cellSquareDimension);
			}
			return (ushort)((int)y * this.cellsWide + (int)x);
		}

		// Token: 0x06001BB0 RID: 7088 RVA: 0x0006EE8C File Offset: 0x0006D08C
		public ushort WorldCell(ref global::UnityEngine.Vector3 point)
		{
			double num = (double)point.x + this.flat_wide_ofs;
			int num2;
			if (num <= 0.0)
			{
				num2 = 0;
			}
			else if (num >= this.cellWideLastTimesSquareDimension)
			{
				num2 = (int)this.cellWideLast;
			}
			else
			{
				num2 = (int)global::System.Math.Floor(num / (double)this.cellSquareDimension);
			}
			double num3 = (double)point.z + this.flat_tall_ofs;
			int num4;
			if (num3 <= 0.0)
			{
				num4 = 0;
			}
			else if (num3 >= this.cellTallLastTimesSquareDimension)
			{
				num4 = (int)this.cellTallLast;
			}
			else
			{
				num4 = (int)global::System.Math.Floor(num3 / (double)this.cellSquareDimension);
			}
			return (ushort)(num4 * this.cellsWide + num2);
		}

		// Token: 0x06001BB1 RID: 7089 RVA: 0x0006EF40 File Offset: 0x0006D140
		public global::System.Collections.Generic.List<ushort> EnumerateNearbyCells(int cell)
		{
			return this.EnumerateNearbyCells(cell, cell % global::CullGrid.grid.cellsWide, cell / global::CullGrid.grid.cellsWide);
		}

		// Token: 0x06001BB2 RID: 7090 RVA: 0x0006EF64 File Offset: 0x0006D164
		public global::System.Collections.Generic.List<ushort> EnumerateNearbyCells(int x, int y)
		{
			return this.EnumerateNearbyCells(y * this.cellsWide + x, x, y);
		}

		// Token: 0x06001BB3 RID: 7091 RVA: 0x0006EF78 File Offset: 0x0006D178
		public global::System.Collections.Generic.List<ushort> EnumerateNearbyCells(int i, int x, int y)
		{
			if (i < 0)
			{
				throw new global::System.ArgumentOutOfRangeException("i", i, "i<0");
			}
			if (x < 0)
			{
				throw new global::System.ArgumentOutOfRangeException("x", x, "x<0");
			}
			if (y < 0)
			{
				throw new global::System.ArgumentOutOfRangeException("y", y, "y<0");
			}
			global::System.Collections.Generic.List<ushort> list = new global::System.Collections.Generic.List<ushort>();
			int num = -(this.gatheringCellsCenter % this.gatheringCellsWide);
			int num2 = -(this.gatheringCellsCenter / this.gatheringCellsWide);
			for (int j = 0; j < this.gatheringCellsWide; j++)
			{
				int num3 = j + num;
				int num4 = x + num3;
				if (num4 >= 0 && num4 < this.cellsWide)
				{
					for (int k = 0; k < this.gatheringCellsTall; k++)
					{
						int num5 = k + num2;
						int num6 = y + num5;
						if (num6 >= 0 && num6 < this.cellsTall && base.GetGatheringBit(j, k))
						{
							ushort item = (ushort)(num4 + num6 * this.cellsWide);
							if (num6 == y && num4 == x)
							{
								list.Insert(0, item);
							}
							else
							{
								list.Add(item);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0400100B RID: 4107
		private const double kMAX_WORLD_Y = 32000.0;

		// Token: 0x0400100C RID: 4108
		private const double kMIN_WORLD_Y = -32000.0;

		// Token: 0x0400100D RID: 4109
		public int groupEnd;

		// Token: 0x0400100E RID: 4110
		public int numCells;

		// Token: 0x0400100F RID: 4111
		[global::System.NonSerialized]
		public global::System.Collections.Generic.HashSet<ushort>[] cells;

		// Token: 0x04001010 RID: 4112
		public global::CullGrid cullGrid;

		// Token: 0x04001011 RID: 4113
		public global::UnityEngine.Transform transform;

		// Token: 0x04001012 RID: 4114
		public double halfCellTall;

		// Token: 0x04001013 RID: 4115
		public double halfCellWide;

		// Token: 0x04001014 RID: 4116
		public int twoMinusOddTall;

		// Token: 0x04001015 RID: 4117
		public int twoMinusOddWide;

		// Token: 0x04001016 RID: 4118
		public double halfTwoMinusOddTall;

		// Token: 0x04001017 RID: 4119
		public double halfTwoMinusOddWide;

		// Token: 0x04001018 RID: 4120
		public double halfCellTallMinusHalfTwoMinusOddTall;

		// Token: 0x04001019 RID: 4121
		public double halfCellWideMinusHalfTwoMinusOddWide;

		// Token: 0x0400101A RID: 4122
		public double px;

		// Token: 0x0400101B RID: 4123
		public double py;

		// Token: 0x0400101C RID: 4124
		public double pz;

		// Token: 0x0400101D RID: 4125
		public double fx;

		// Token: 0x0400101E RID: 4126
		public double fy;

		// Token: 0x0400101F RID: 4127
		public double fz;

		// Token: 0x04001020 RID: 4128
		public double rx;

		// Token: 0x04001021 RID: 4129
		public double ry;

		// Token: 0x04001022 RID: 4130
		public double rz;

		// Token: 0x04001023 RID: 4131
		public double flat_wide_ofs;

		// Token: 0x04001024 RID: 4132
		public double flat_tall_ofs;

		// Token: 0x04001025 RID: 4133
		public ushort cellWideLast;

		// Token: 0x04001026 RID: 4134
		public ushort cellTallLast;

		// Token: 0x04001027 RID: 4135
		public double cellWideLastTimesSquareDimension;

		// Token: 0x04001028 RID: 4136
		public double cellTallLastTimesSquareDimension;
	}

	// Token: 0x02000330 RID: 816
	private static class g
	{
		// Token: 0x06001BB4 RID: 7092 RVA: 0x0006F0C4 File Offset: 0x0006D2C4
		static g()
		{
			global::CullGrid.g_init = true;
			global::CullGrid.g.CHANGE_QUEUE_SET = new global::System.Collections.Generic.HashSet<global::NetUser>();
			global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT = new global::System.Collections.Generic.Dictionary<global::NetUser, global::PlayerCullInfo>();
			global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::NetUser, global::PlayerCullInfo>>();
		}

		// Token: 0x06001BB5 RID: 7093 RVA: 0x0006F120 File Offset: 0x0006D320
		public static bool AddQueue(global::NetUser client, global::PlayerCullInfo info, global::System.Collections.Generic.HashSet<ushort> nearCells)
		{
			if (object.ReferenceEquals(nearCells, null))
			{
				nearCells = global::CullGrid.g.EMPTY_CELL_SET;
			}
			if (nearCells.SetEquals(info.groups))
			{
				global::CullGrid.g.RemoveQueue(client, info);
				return false;
			}
			global::CullGrid.g.CHANGE_QUEUE_ADD(client);
			info.queuedGroups = nearCells;
			return true;
		}

		// Token: 0x06001BB6 RID: 7094 RVA: 0x0006F16C File Offset: 0x0006D36C
		private static bool CHANGE_QUEUE_REMOVE(global::NetUser client)
		{
			if (global::CullGrid.g.CHANGE_QUEUE_SET.Remove(client))
			{
				if (--global::CullGrid.g.CHANGE_QUEUE_COUNT == 0)
				{
					global::CullGrid.CHANGE_QUEUE_ACTIVE = false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001BB7 RID: 7095 RVA: 0x0006F19C File Offset: 0x0006D39C
		private static bool CHANGE_QUEUE_ADD(global::NetUser client)
		{
			if (global::CullGrid.g.CHANGE_QUEUE_SET.Add(client))
			{
				if (global::CullGrid.g.CHANGE_QUEUE_COUNT++ == 0)
				{
					global::CullGrid.CHANGE_QUEUE_ACTIVE = true;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001BB8 RID: 7096 RVA: 0x0006F1CC File Offset: 0x0006D3CC
		private static void DEQUEUE_FROM_CHANGE_QUEUE_LIST_ADD(global::NetUser client, global::PlayerCullInfo info)
		{
			global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST.Add(new global::System.Collections.Generic.KeyValuePair<global::NetUser, global::PlayerCullInfo>(client, info));
		}

		// Token: 0x06001BB9 RID: 7097 RVA: 0x0006F1E0 File Offset: 0x0006D3E0
		private static void DEQUEUE_FROM_CHANGE_QUEUE_LIST_CLEANUP()
		{
			foreach (global::System.Collections.Generic.KeyValuePair<global::NetUser, global::PlayerCullInfo> keyValuePair in global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST)
			{
				global::CullGrid.g.RemoveQueue(keyValuePair.Key, keyValuePair.Value);
			}
			global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST.Clear();
		}

		// Token: 0x06001BBA RID: 7098 RVA: 0x0006F25C File Offset: 0x0006D45C
		public static void RemoveQueue(global::NetUser client, global::PlayerCullInfo info)
		{
			if (global::CullGrid.g.CHANGE_QUEUE_REMOVE(client))
			{
				info.queuedGroups = null;
			}
		}

		// Token: 0x06001BBB RID: 7099 RVA: 0x0006F270 File Offset: 0x0006D470
		public static void RemoveQueue_NoInfo(global::NetUser client)
		{
			global::CullGrid.g.CHANGE_QUEUE_REMOVE(client);
			client.cullinfo = null;
		}

		// Token: 0x06001BBC RID: 7100 RVA: 0x0006F280 File Offset: 0x0006D480
		public static void RunUnion()
		{
			if (global::CullGrid.CHANGE_QUEUE_ACTIVE)
			{
				global::System.Collections.Generic.HashSet<global::NetUser>.Enumerator enumerator = global::CullGrid.g.CHANGE_QUEUE_SET.GetEnumerator();
				while (enumerator.MoveNext())
				{
					global::NetUser netUser = enumerator.Current;
					global::PlayerCullInfo playerCullInfo = global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT[netUser];
					if (playerCullInfo.DequeueUnion(netUser))
					{
						global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST_ADD(netUser, playerCullInfo);
						while (enumerator.MoveNext())
						{
							netUser = enumerator.Current;
							playerCullInfo = global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT[netUser];
							if (playerCullInfo.DequeueUnion(netUser))
							{
								global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST_ADD(netUser, playerCullInfo);
							}
						}
						enumerator.Dispose();
						global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST_CLEANUP();
						return;
					}
				}
				enumerator.Dispose();
			}
		}

		// Token: 0x06001BBD RID: 7101 RVA: 0x0006F328 File Offset: 0x0006D528
		public static void RunExcept()
		{
			if (global::CullGrid.CHANGE_QUEUE_ACTIVE)
			{
				global::System.Collections.Generic.HashSet<global::NetUser>.Enumerator enumerator = global::CullGrid.g.CHANGE_QUEUE_SET.GetEnumerator();
				while (enumerator.MoveNext())
				{
					global::NetUser netUser = enumerator.Current;
					global::PlayerCullInfo playerCullInfo = global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT[netUser];
					if (playerCullInfo.DequeueExcept(netUser))
					{
						global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST_ADD(netUser, playerCullInfo);
						while (enumerator.MoveNext())
						{
							netUser = enumerator.Current;
							playerCullInfo = global::CullGrid.g.CLIENT_TO_PLAYERCULLINFO_DICT[netUser];
							if (playerCullInfo.DequeueExcept(netUser))
							{
								global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST_ADD(netUser, playerCullInfo);
							}
						}
						enumerator.Dispose();
						global::CullGrid.g.DEQUEUE_FROM_CHANGE_QUEUE_LIST_CLEANUP();
						return;
					}
				}
				enumerator.Dispose();
			}
		}

		// Token: 0x04001029 RID: 4137
		public static global::System.Collections.Generic.Dictionary<global::NetUser, global::PlayerCullInfo> CLIENT_TO_PLAYERCULLINFO_DICT = new global::System.Collections.Generic.Dictionary<global::NetUser, global::PlayerCullInfo>();

		// Token: 0x0400102A RID: 4138
		public static global::System.Collections.Generic.HashSet<global::NetUser> CHANGE_QUEUE_SET = new global::System.Collections.Generic.HashSet<global::NetUser>();

		// Token: 0x0400102B RID: 4139
		private static global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::NetUser, global::PlayerCullInfo>> DEQUEUE_FROM_CHANGE_QUEUE_LIST = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::NetUser, global::PlayerCullInfo>>();

		// Token: 0x0400102C RID: 4140
		public static int CHANGE_QUEUE_COUNT;

		// Token: 0x0400102D RID: 4141
		private static readonly global::System.Collections.Generic.HashSet<ushort> EMPTY_CELL_SET = new global::System.Collections.Generic.HashSet<ushort>();
	}

	// Token: 0x02000331 RID: 817
	[global::System.Flags]
	public enum CullResultFlags
	{
		// Token: 0x0400102F RID: 4143
		Failed = 0,
		// Token: 0x04001030 RID: 4144
		NoProblem = 1,
		// Token: 0x04001031 RID: 4145
		ChangedCell = 2,
		// Token: 0x04001032 RID: 4146
		Created = 4,
		// Token: 0x04001033 RID: 4147
		Registered = 8,
		// Token: 0x04001034 RID: 4148
		Destroyed = 0x10,
		// Token: 0x04001035 RID: 4149
		Prebound = 0x20
	}

	// Token: 0x02000332 RID: 818
	private static class g_root_update
	{
		// Token: 0x06001BBE RID: 7102 RVA: 0x0006F3D0 File Offset: 0x0006D5D0
		// Note: this type is marked as 'beforefieldinit'.
		static g_root_update()
		{
		}

		// Token: 0x04001036 RID: 4150
		public static readonly global::System.Collections.Generic.HashSet<global::NetworkCullInfo> pending = new global::System.Collections.Generic.HashSet<global::NetworkCullInfo>();
	}

	// Token: 0x02000333 RID: 819
	private static class forceWork
	{
		// Token: 0x06001BBF RID: 7103 RVA: 0x0006F3DC File Offset: 0x0006D5DC
		// Note: this type is marked as 'beforefieldinit'.
		static forceWork()
		{
		}

		// Token: 0x04001037 RID: 4151
		public static global::System.Collections.Generic.HashSet<ushort> tempCellWork = new global::System.Collections.Generic.HashSet<ushort>();
	}
}

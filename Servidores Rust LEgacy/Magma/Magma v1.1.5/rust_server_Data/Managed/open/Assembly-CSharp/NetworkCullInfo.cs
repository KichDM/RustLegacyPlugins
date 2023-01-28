using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x02000425 RID: 1061
[global::UnityEngine.AddComponentMenu("")]
public sealed class NetworkCullInfo : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060024DA RID: 9434 RVA: 0x0008C6CC File Offset: 0x0008A8CC
	public NetworkCullInfo()
	{
	}

	// Token: 0x060024DB RID: 9435 RVA: 0x0008C6DC File Offset: 0x0008A8DC
	public static bool Find(int viewID, out global::NetworkCullInfo info)
	{
		if (!global::NetworkCullInfo.g_init)
		{
			info = null;
		}
		else if (global::NetworkCullInfo.g.dict.TryGetValue(viewID, out info))
		{
			return true;
		}
		return false;
	}

	// Token: 0x060024DC RID: 9436 RVA: 0x0008C710 File Offset: 0x0008A910
	public static bool Find(global::uLink.NetworkViewID viewID, out global::NetworkCullInfo info)
	{
		if (!global::NetworkCullInfo.g_init)
		{
			info = null;
		}
		else if (global::NetworkCullInfo.g.dict.TryGetValue(viewID.id, out info))
		{
			return true;
		}
		return false;
	}

	// Token: 0x060024DD RID: 9437 RVA: 0x0008C74C File Offset: 0x0008A94C
	public static bool Find(global::uLink.NetworkView view, out global::NetworkCullInfo info)
	{
		if (!global::NetworkCullInfo.g_init || !view)
		{
			info = null;
		}
		else if (global::NetworkCullInfo.g.dict.TryGetValue(view.viewID.id, out info))
		{
			return true;
		}
		return false;
	}

	// Token: 0x060024DE RID: 9438 RVA: 0x0008C798 File Offset: 0x0008A998
	public static bool Find(global::UnityEngine.GameObject go, out global::NetworkCullInfo info)
	{
		global::Facepunch.NetworkView networkView;
		if (networkView = global::Facepunch.NetworkView.Get(go))
		{
			return global::NetworkCullInfo.Find(networkView, out info);
		}
		info = null;
		return false;
	}

	// Token: 0x060024DF RID: 9439 RVA: 0x0008C7C4 File Offset: 0x0008A9C4
	public static bool Find(global::UnityEngine.Component component, out global::NetworkCullInfo info)
	{
		global::Facepunch.NetworkView networkView;
		if (networkView = global::Facepunch.NetworkView.Get(component))
		{
			return global::NetworkCullInfo.Find(networkView, out info);
		}
		info = null;
		return false;
	}

	// Token: 0x1700084C RID: 2124
	// (get) Token: 0x060024E0 RID: 9440 RVA: 0x0008C7F0 File Offset: 0x0008A9F0
	public global::Facepunch.NetworkView networkView
	{
		get
		{
			return this.view;
		}
	}

	// Token: 0x1700084D RID: 2125
	// (get) Token: 0x060024E1 RID: 9441 RVA: 0x0008C7F8 File Offset: 0x0008A9F8
	public bool isConnected
	{
		get
		{
			return this.view && (this.view.isMine || this.view.owner.isConnected);
		}
	}

	// Token: 0x060024E2 RID: 9442 RVA: 0x0008C840 File Offset: 0x0008AA40
	internal void AddBacker(global::NetworkCullInfo backer)
	{
		if (backer.piggy == this && backer != this)
		{
			if (!this.anyBackers)
			{
				this.backers = new global::System.Collections.Generic.HashSet<global::NetworkCullInfo>();
				this.anyBackers = true;
			}
			this.backers.Add(backer);
		}
	}

	// Token: 0x060024E3 RID: 9443 RVA: 0x0008C894 File Offset: 0x0008AA94
	internal void RemoveBacker(global::NetworkCullInfo backer)
	{
		if (backer.piggy == this)
		{
			backer.piggy = null;
			backer.valid = false;
			if (this.anyBackers && this.backers.Remove(backer))
			{
				backer.piggy = null;
				this.anyBackers = (this.backers.Count > 0);
				if (!this.anyBackers)
				{
					this.backers = null;
				}
			}
		}
	}

	// Token: 0x060024E4 RID: 9444 RVA: 0x0008C90C File Offset: 0x0008AB0C
	private void OnDestroy()
	{
		if (this.valid)
		{
			try
			{
				global::NetworkCullInfo networkCullInfo;
				if (global::NetworkCullInfo.g.dict.TryGetValue(this.viewid, out networkCullInfo) && networkCullInfo == this)
				{
					global::NetworkCullInfo.g.dict.Remove(this.viewid);
				}
				else
				{
					global::UnityEngine.Debug.LogWarning("The thing assigned to viewid was not this." + this.viewid, this);
				}
			}
			finally
			{
				try
				{
					if (this.isUser)
					{
						try
						{
							if (this.playerRoot)
							{
								global::CullGrid.DelistPlayerRootNetworkCullInfo(this);
							}
							else
							{
								global::CullGrid.DelistPlayerNonRootNetworkCullInfo(this);
							}
						}
						catch (global::System.Exception ex)
						{
							global::UnityEngine.Debug.LogError(ex, this);
						}
					}
					if (this.anyBackers)
					{
						foreach (global::NetworkCullInfo networkCullInfo2 in this.backers)
						{
							if (networkCullInfo2 && networkCullInfo2.piggy == this)
							{
								networkCullInfo2.piggy = null;
							}
						}
						this.backers = null;
						this.anyBackers = false;
					}
					if (this.riding)
					{
						if (this.piggy)
						{
							this.piggy.RemoveBacker(this);
						}
						this.piggy = null;
					}
					else
					{
						global::NetCull.Unregister(this);
					}
					this.valid = false;
				}
				finally
				{
					global::NetworkCullInfo.List.AutoRemoveInstance(this);
				}
			}
		}
		else
		{
			global::NetworkCullInfo.List.AutoRemoveInstance(this);
		}
	}

	// Token: 0x060024E5 RID: 9445 RVA: 0x0008CAE8 File Offset: 0x0008ACE8
	internal void OnInitialRegistrationComplete()
	{
		this.viewid = this.view.viewID.id;
		global::NetworkCullInfo.g.dict.Add(this.viewid, this);
	}

	// Token: 0x060024E6 RID: 9446 RVA: 0x0008CB20 File Offset: 0x0008AD20
	internal void OnGroupWillChange()
	{
	}

	// Token: 0x060024E7 RID: 9447 RVA: 0x0008CB24 File Offset: 0x0008AD24
	private void CopyFrom(global::NetworkCullInfo info)
	{
		this.lastWorkingGroupID = info.lastWorkingGroupID;
		this.workingGroupID = info.workingGroupID;
		this.setGroupID = info.setGroupID;
	}

	// Token: 0x060024E8 RID: 9448 RVA: 0x0008CB58 File Offset: 0x0008AD58
	private void ExecRiderCommand(global::NetworkCullInfo.RiderCommand cmd)
	{
		switch (cmd)
		{
		case global::NetworkCullInfo.RiderCommand.Copy:
			this.CopyFrom(this.piggy);
			break;
		case global::NetworkCullInfo.RiderCommand.OnGroupWillChange:
			this.OnGroupWillChange();
			break;
		case global::NetworkCullInfo.RiderCommand.ApplyGroupChange:
			this.ApplyGroupChange();
			break;
		case global::NetworkCullInfo.RiderCommand.OnGroupChanged:
			this.OnGroupChanged();
			break;
		}
	}

	// Token: 0x060024E9 RID: 9449 RVA: 0x0008CBB4 File Offset: 0x0008ADB4
	internal void RunRiderCommand(global::NetworkCullInfo.RiderCommand cmd)
	{
		int num = 0;
		foreach (global::NetworkCullInfo networkCullInfo in this.backers)
		{
			if (networkCullInfo.anyBackers)
			{
				num++;
			}
			else
			{
				networkCullInfo.ExecRiderCommand(cmd);
			}
		}
		if (num > 0)
		{
			foreach (global::NetworkCullInfo networkCullInfo2 in this.backers)
			{
				if (networkCullInfo2.anyBackers)
				{
					networkCullInfo2.ExecRiderCommand(cmd);
					networkCullInfo2.RunRiderCommand(cmd);
					if (--num == 0)
					{
						break;
					}
				}
			}
		}
	}

	// Token: 0x060024EA RID: 9450 RVA: 0x0008CCB0 File Offset: 0x0008AEB0
	internal void RunRiderCommandReverse(global::NetworkCullInfo.RiderCommand cmd)
	{
		int num = 0;
		int num2 = 0;
		foreach (global::NetworkCullInfo networkCullInfo in this.backers)
		{
			if (networkCullInfo.anyBackers)
			{
				networkCullInfo.RunRiderCommandReverse(cmd);
				num2++;
			}
			else
			{
				num++;
			}
		}
		if (num2 <= 0)
		{
			foreach (global::NetworkCullInfo networkCullInfo2 in this.backers)
			{
				networkCullInfo2.ExecRiderCommand(cmd);
			}
			return;
		}
		if (num == 0)
		{
			foreach (global::NetworkCullInfo networkCullInfo3 in this.backers)
			{
				networkCullInfo3.ExecRiderCommand(cmd);
			}
			return;
		}
		foreach (global::NetworkCullInfo networkCullInfo4 in this.backers)
		{
			if (networkCullInfo4.anyBackers)
			{
				networkCullInfo4.ExecRiderCommand(cmd);
				if (--num2 == 0)
				{
					break;
				}
			}
		}
		foreach (global::NetworkCullInfo networkCullInfo5 in this.backers)
		{
			if (!networkCullInfo5.anyBackers)
			{
				networkCullInfo5.ExecRiderCommand(cmd);
				if (--num == 0)
				{
					break;
				}
			}
		}
	}

	// Token: 0x060024EB RID: 9451 RVA: 0x0008CEE0 File Offset: 0x0008B0E0
	internal void ApplyGroupChange()
	{
		global::uLink.NetworkGroup group = this.setGroupID;
		try
		{
			this.view.group = group;
		}
		catch (global::System.Collections.Generic.KeyNotFoundException arg)
		{
			global::UnityEngine.Debug.LogError("caught exception during view.group assignment. no idea what is gonna come from the exception thrown \r\n" + arg, this);
		}
	}

	// Token: 0x060024EC RID: 9452 RVA: 0x0008CF40 File Offset: 0x0008B140
	internal void OnGroupChanged()
	{
	}

	// Token: 0x060024ED RID: 9453 RVA: 0x0008CF44 File Offset: 0x0008B144
	private void List_InsertIndex(int list, int index)
	{
		if (this.indexInListCapacity <= list)
		{
			global::System.Array.Resize<int>(ref this.indexInList, this.indexInListCapacity = 8);
		}
		this.indexInList[list] = index + 1;
		this.indexInListSize++;
	}

	// Token: 0x060024EE RID: 9454 RVA: 0x0008CF8C File Offset: 0x0008B18C
	private void List_SetIndex(int list, int index)
	{
		this.indexInList[list] = index + 1;
	}

	// Token: 0x060024EF RID: 9455 RVA: 0x0008CF9C File Offset: 0x0008B19C
	private void List_ShiftDown(int list)
	{
		this.indexInList[list]--;
	}

	// Token: 0x060024F0 RID: 9456 RVA: 0x0008CFB0 File Offset: 0x0008B1B0
	private void List_ShiftUp(int list)
	{
		this.indexInList[list]++;
	}

	// Token: 0x060024F1 RID: 9457 RVA: 0x0008CFC4 File Offset: 0x0008B1C4
	private bool List_Contains(int list)
	{
		return this.indexInListSize > 0 && this.indexInListCapacity > list && this.indexInList[list] != 0;
	}

	// Token: 0x060024F2 RID: 9458 RVA: 0x0008CFF0 File Offset: 0x0008B1F0
	private bool List_GetIndex(int list, out int index)
	{
		if (this.indexInListSize == 0 || this.indexInListCapacity <= list)
		{
			index = -1;
			return false;
		}
		index = this.indexInList[list] - 1;
		return index != -1;
	}

	// Token: 0x060024F3 RID: 9459 RVA: 0x0008D030 File Offset: 0x0008B230
	private void List_ClearIndex(int list)
	{
		this.indexInList[list] = 0;
		this.indexInListSize--;
	}

	// Token: 0x060024F4 RID: 9460 RVA: 0x0008D04C File Offset: 0x0008B24C
	private void Print(global::System.Text.StringBuilder sb)
	{
		global::uLink.NetworkViewID networkViewID = (!this.view) ? global::uLink.NetworkViewID.unassigned : this.view.viewID;
		bool flag = this.printing;
		try
		{
			this.printing = true;
			sb.AppendFormat("{{{0}^{1:x}", base.name, networkViewID.id);
			if (this.valid)
			{
				sb.Append('V');
			}
			if (this.riding)
			{
				sb.Append('R');
			}
			if (this.isUser)
			{
				if (this.playerRoot)
				{
					sb.Append('P');
				}
				else
				{
					sb.Append('U');
				}
				if (this.user != null)
				{
					sb.AppendFormat("{0:x}", this.user.user.Userid);
				}
				else
				{
					sb.Append('N');
				}
			}
			if (this.anyBackers)
			{
				if (flag)
				{
					sb.Append("&(...)");
				}
				else
				{
					sb.Append("&[");
					using (global::System.Collections.Generic.HashSet<global::NetworkCullInfo>.Enumerator enumerator = this.backers.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							enumerator.Current.Print(sb);
							while (enumerator.MoveNext())
							{
								sb.Append(',');
								enumerator.Current.Print(sb);
							}
						}
					}
					sb.Append(']');
				}
			}
			sb.Append('}');
		}
		finally
		{
			this.printing = flag;
		}
	}

	// Token: 0x060024F5 RID: 9461 RVA: 0x0008D218 File Offset: 0x0008B418
	public override string ToString()
	{
		global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
		this.Print(stringBuilder);
		return stringBuilder.ToString();
	}

	// Token: 0x04001295 RID: 4757
	internal const byte MOVED = 2;

	// Token: 0x04001296 RID: 4758
	internal const byte INSERTED = 1;

	// Token: 0x04001297 RID: 4759
	internal const byte REMOVED = 4;

	// Token: 0x04001298 RID: 4760
	internal const byte NO_EFFECT = 0;

	// Token: 0x04001299 RID: 4761
	private static bool g_init;

	// Token: 0x0400129A RID: 4762
	[global::System.NonSerialized]
	public int viewid;

	// Token: 0x0400129B RID: 4763
	[global::System.NonSerialized]
	public global::Facepunch.NetworkView view;

	// Token: 0x0400129C RID: 4764
	[global::System.NonSerialized]
	public global::UnityEngine.Transform transform;

	// Token: 0x0400129D RID: 4765
	[global::System.NonSerialized]
	public global::UnityEngine.Vector3 position;

	// Token: 0x0400129E RID: 4766
	[global::System.NonSerialized]
	public bool instantiating = true;

	// Token: 0x0400129F RID: 4767
	[global::System.NonSerialized]
	public global::NetworkCullInfo piggy;

	// Token: 0x040012A0 RID: 4768
	[global::System.NonSerialized]
	public global::System.Collections.Generic.HashSet<global::NetworkCullInfo> backers;

	// Token: 0x040012A1 RID: 4769
	[global::System.NonSerialized]
	public bool anyBackers;

	// Token: 0x040012A2 RID: 4770
	[global::System.NonSerialized]
	public global::NetUser user;

	// Token: 0x040012A3 RID: 4771
	[global::System.NonSerialized]
	public bool isUser;

	// Token: 0x040012A4 RID: 4772
	[global::System.NonSerialized]
	public bool playerRoot;

	// Token: 0x040012A5 RID: 4773
	[global::System.NonSerialized]
	internal ulong process_call;

	// Token: 0x040012A6 RID: 4774
	[global::System.NonSerialized]
	internal int initialGroupID;

	// Token: 0x040012A7 RID: 4775
	[global::System.NonSerialized]
	internal int workingGroupID;

	// Token: 0x040012A8 RID: 4776
	[global::System.NonSerialized]
	internal int lastWorkingGroupID;

	// Token: 0x040012A9 RID: 4777
	[global::System.NonSerialized]
	internal int setGroupID;

	// Token: 0x040012AA RID: 4778
	[global::System.NonSerialized]
	internal bool valid;

	// Token: 0x040012AB RID: 4779
	[global::System.NonSerialized]
	internal bool riding;

	// Token: 0x040012AC RID: 4780
	[global::System.NonSerialized]
	private int[] indexInList;

	// Token: 0x040012AD RID: 4781
	[global::System.NonSerialized]
	private int indexInListSize;

	// Token: 0x040012AE RID: 4782
	[global::System.NonSerialized]
	private int indexInListCapacity;

	// Token: 0x040012AF RID: 4783
	private bool printing;

	// Token: 0x02000426 RID: 1062
	private static class g
	{
		// Token: 0x060024F6 RID: 9462 RVA: 0x0008D238 File Offset: 0x0008B438
		static g()
		{
			global::NetworkCullInfo.g_init = true;
			global::NetworkCullInfo.g.dict = new global::System.Collections.Generic.Dictionary<int, global::NetworkCullInfo>();
		}

		// Token: 0x040012B0 RID: 4784
		public static readonly global::System.Collections.Generic.Dictionary<int, global::NetworkCullInfo> dict;
	}

	// Token: 0x02000427 RID: 1063
	internal enum RiderCommand : byte
	{
		// Token: 0x040012B2 RID: 4786
		Copy,
		// Token: 0x040012B3 RID: 4787
		OnGroupWillChange,
		// Token: 0x040012B4 RID: 4788
		ApplyGroupChange,
		// Token: 0x040012B5 RID: 4789
		OnGroupChanged
	}

	// Token: 0x02000428 RID: 1064
	internal class List : global::System.IDisposable
	{
		// Token: 0x060024F7 RID: 9463 RVA: 0x0008D24C File Offset: 0x0008B44C
		internal List(int list_id)
		{
			if (list_id < 0 || list_id >= 8)
			{
				throw new global::System.ArgumentException();
			}
			if (!object.ReferenceEquals(global::NetworkCullInfo.List.lists[list_id], null))
			{
				throw new global::System.InvalidOperationException();
			}
			this.id = list_id;
			global::NetworkCullInfo.List.lists[this.id] = this;
			this.iterator = -1;
		}

		// Token: 0x060024F8 RID: 9464 RVA: 0x0008D2A8 File Offset: 0x0008B4A8
		static List()
		{
			for (int i = 0; i < 8; i++)
			{
				global::NetworkCullInfo.List.exceptionDisposedMessages[i] = string.Format("The list that was once at id {0} is disposed", i);
			}
		}

		// Token: 0x060024F9 RID: 9465 RVA: 0x0008D2F4 File Offset: 0x0008B4F4
		internal static string kListString(int kListID)
		{
			switch (kListID)
			{
			case 0:
				return "SERVER MOVER REGISTRY";
			case 1:
				return "CLIENT MOVER REGISTRY";
			case 2:
				return "SERVER PROCESS DETECTION";
			case 3:
				return "CLIENT PROCESS DETECTION";
			case 4:
				return "SERVER CHANGE QUEUE";
			case 5:
				return "CLIENT CHANGE QUEUE";
			case 6:
				return "SERVER COOK LIST";
			case 7:
				return "CLIENT COOK LIST";
			default:
				throw new global::System.ArgumentOutOfRangeException("kListID", kListID, "kListID<0||kListID>kMaxListCount");
			}
		}

		// Token: 0x060024FA RID: 9466 RVA: 0x0008D374 File Offset: 0x0008B574
		internal static int kListID(string kListString)
		{
			switch (kListString)
			{
			case "SERVER MOVER REGISTRY":
				return 0;
			case "CLIENT MOVER REGISTRY":
				return 1;
			case "SERVER PROCESS DETECTION":
				return 2;
			case "CLIENT PROCESS DETECTION":
				return 3;
			case "SERVER CHANGE QUEUE":
				return 4;
			case "CLIENT CHANGE QUEUE":
				return 5;
			case "SERVER COOK LIST":
				return 6;
			case "CLIENT COOK LIST":
				return 7;
			}
			throw new global::System.ArgumentOutOfRangeException("kListID", kListString, "Not valid");
		}

		// Token: 0x060024FB RID: 9467 RVA: 0x0008D460 File Offset: 0x0008B660
		public void Dispose()
		{
			if (this.disposed)
			{
				throw new global::System.ObjectDisposedException(global::NetworkCullInfo.List.exceptionDisposedMessages[this.id]);
			}
			this.Clear();
			global::NetworkCullInfo.List.lists[this.id] = null;
			this.disposed = true;
			this.buffer = null;
		}

		// Token: 0x060024FC RID: 9468 RVA: 0x0008D4AC File Offset: 0x0008B6AC
		private int NewIndex()
		{
			int num = this.size++;
			if (num == this.capacity)
			{
				this.capacity += 0x10;
				global::System.Array.Resize<global::NetworkCullInfo>(ref this.buffer, this.capacity);
			}
			return num;
		}

		// Token: 0x060024FD RID: 9469 RVA: 0x0008D4F8 File Offset: 0x0008B6F8
		public byte Add(global::NetworkCullInfo info)
		{
			if (this.disposed)
			{
				throw new global::System.ObjectDisposedException(global::NetworkCullInfo.List.exceptionDisposedMessages[this.id]);
			}
			if (info.List_Contains(this.id))
			{
				return 0;
			}
			int num = this.NewIndex();
			this.buffer[num] = info;
			info.List_InsertIndex(this.id, num);
			return 1;
		}

		// Token: 0x060024FE RID: 9470 RVA: 0x0008D554 File Offset: 0x0008B754
		private void _RemoveAt(int index)
		{
			this.buffer[index].List_ClearIndex(this.id);
			for (int i = index + 1; i < this.size; i++)
			{
				this.buffer[index] = this.buffer[i];
				this.buffer[index].List_ShiftDown(this.id);
				index++;
			}
			this.buffer[--this.size] = null;
		}

		// Token: 0x060024FF RID: 9471 RVA: 0x0008D5D0 File Offset: 0x0008B7D0
		public byte RemoveAt(int index)
		{
			if (!this.disposed && index >= 0 && index < this.size)
			{
				this._RemoveAt(index);
				return 4;
			}
			return 0;
		}

		// Token: 0x06002500 RID: 9472 RVA: 0x0008D608 File Offset: 0x0008B808
		public byte Remove(global::NetworkCullInfo info)
		{
			int num;
			if (this.disposed || !info.List_GetIndex(this.id, out num))
			{
				return 0;
			}
			this.RemoveAt(num);
			if (this.iterator > num)
			{
				this.iterator--;
			}
			return 4;
		}

		// Token: 0x06002501 RID: 9473 RVA: 0x0008D658 File Offset: 0x0008B858
		public bool Contains(global::NetworkCullInfo info)
		{
			return info.List_Contains(this.id);
		}

		// Token: 0x06002502 RID: 9474 RVA: 0x0008D668 File Offset: 0x0008B868
		public int IndexOf(global::NetworkCullInfo info)
		{
			int result;
			info.List_GetIndex(this.id, out result);
			return result;
		}

		// Token: 0x06002503 RID: 9475 RVA: 0x0008D688 File Offset: 0x0008B888
		public byte Clear()
		{
			if (!this.disposed && this.size != 0)
			{
				for (int i = this.size - 1; i >= 0; i--)
				{
					this.buffer[i].List_ClearIndex(this.id);
					this.buffer[i] = null;
				}
				this.iterator = -1;
				this.size = 0;
				return 4;
			}
			return 0;
		}

		// Token: 0x06002504 RID: 9476 RVA: 0x0008D6F4 File Offset: 0x0008B8F4
		public bool TrimFat()
		{
			if (this.size != this.capacity)
			{
				this.capacity = this.size;
				if (this.capacity == 0)
				{
					this.buffer = null;
				}
				else
				{
					global::System.Array.Resize<global::NetworkCullInfo>(ref this.buffer, this.capacity);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06002505 RID: 9477 RVA: 0x0008D74C File Offset: 0x0008B94C
		public bool AddFat(int targetCapacity)
		{
			if (this.capacity < targetCapacity)
			{
				this.capacity = targetCapacity;
				global::System.Array.Resize<global::NetworkCullInfo>(ref this.buffer, this.capacity);
				return true;
			}
			return false;
		}

		// Token: 0x06002506 RID: 9478 RVA: 0x0008D778 File Offset: 0x0008B978
		private void RemoveAt_Null(int index)
		{
			for (int i = index + 1; i < this.size; i++)
			{
				this.buffer[index] = this.buffer[i];
				this.buffer[index].List_ShiftDown(this.id);
				index++;
			}
			this.buffer[--this.size] = null;
			if (this.iterator > index)
			{
				this.iterator--;
			}
		}

		// Token: 0x06002507 RID: 9479 RVA: 0x0008D7FC File Offset: 0x0008B9FC
		public static void LockAutoRemove()
		{
			if (global::NetworkCullInfo.List.autoRemoveLockCount++ == 0)
			{
				global::NetworkCullInfo.List.autoRemoveLocked = true;
			}
		}

		// Token: 0x06002508 RID: 9480 RVA: 0x0008D818 File Offset: 0x0008BA18
		public static void UnlockAutoRemove()
		{
			if (--global::NetworkCullInfo.List.autoRemoveLockCount == 0)
			{
				global::NetworkCullInfo.List.autoRemoveLocked = false;
				if (global::NetworkCullInfo.List.autoRemoveLockedModifications > 0)
				{
					int num = -1;
					int num2 = 0;
					while (global::NetworkCullInfo.List.autoRemoveLockedModifications > 0)
					{
						if (num2-- == 0)
						{
							while (++num != 8)
							{
								if (!object.ReferenceEquals(global::NetworkCullInfo.List.lists[num], null) && global::NetworkCullInfo.List.lists[num].size != 0)
								{
									break;
								}
							}
							if (num == 8)
							{
								global::NetworkCullInfo.List.autoRemoveLockedModifications = 0;
								break;
							}
							num2 = global::NetworkCullInfo.List.lists[num].size;
						}
						else if (!global::NetworkCullInfo.List.lists[num].buffer[num2])
						{
							global::NetworkCullInfo.List.lists[num].RemoveAt_Null(num2);
							global::NetworkCullInfo.List.autoRemoveLockedModifications--;
						}
					}
					global::NetCull.CullProcessor.CheckCondition();
				}
			}
		}

		// Token: 0x06002509 RID: 9481 RVA: 0x0008D900 File Offset: 0x0008BB00
		internal static void AutoRemoveInstance(global::NetworkCullInfo instance)
		{
			if (instance.indexInListSize == 0)
			{
				return;
			}
			if (global::NetworkCullInfo.List.autoRemoveLocked)
			{
				for (int i = 0; i < 8; i++)
				{
					int num;
					if (instance.List_GetIndex(i, out num))
					{
						global::NetworkCullInfo.List.lists[i].buffer[num] = null;
						instance.List_ClearIndex(i);
						global::NetworkCullInfo.List.autoRemoveLockedModifications++;
						if (instance.indexInListSize == 0)
						{
							break;
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < 8; j++)
				{
					if (global::NetworkCullInfo.List.lists[j].Remove(instance) == 4 && global::NetworkCullInfo.List.lists[j].size == 0)
					{
						break;
					}
				}
				global::NetCull.CullProcessor.CheckCondition();
			}
		}

		// Token: 0x0600250A RID: 9482 RVA: 0x0008D9C4 File Offset: 0x0008BBC4
		internal static string ListNetworkCullInfoLists()
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			stringBuilder.Append("NetworkCullInfo.List.lists = [");
			for (int i = 0; i < 8; i++)
			{
				if (i != 0)
				{
					stringBuilder.AppendLine(",");
				}
				else
				{
					stringBuilder.AppendLine();
				}
				stringBuilder.Append(" list.");
				stringBuilder.Append(i);
				stringBuilder.Append('(');
				stringBuilder.Append(global::NetworkCullInfo.List.kListString(i));
				stringBuilder.Append(')');
				if (global::NetworkCullInfo.List.lists[i] == null)
				{
					stringBuilder.Append(" is null");
				}
				else
				{
					stringBuilder.Append(" size is ");
					stringBuilder.Append(global::NetworkCullInfo.List.lists[i].size);
					if (global::NetworkCullInfo.List.lists[i].size == 0)
					{
						stringBuilder.Append(" {}");
					}
					else
					{
						stringBuilder.Append(" {");
						for (int j = 0; j < global::NetworkCullInfo.List.lists[i].size; j++)
						{
							if (j != 0)
							{
								stringBuilder.AppendLine(",");
							}
							else
							{
								stringBuilder.AppendLine();
							}
							stringBuilder.Append("  ");
							global::NetworkCullInfo networkCullInfo = global::NetworkCullInfo.List.lists[i].buffer[j];
							if (networkCullInfo)
							{
								networkCullInfo.Print(stringBuilder);
							}
							else
							{
								stringBuilder.Append("<destroyed>");
							}
						}
						stringBuilder.AppendLine();
						stringBuilder.Append(" }");
					}
				}
			}
			stringBuilder.AppendLine();
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		// Token: 0x040012B6 RID: 4790
		internal const int kListID_ServerRegistry = 0;

		// Token: 0x040012B7 RID: 4791
		internal const int kListID_ClientRegistry = 1;

		// Token: 0x040012B8 RID: 4792
		internal const int kListID_ServerDetect = 2;

		// Token: 0x040012B9 RID: 4793
		internal const int kListID_ClientDetect = 3;

		// Token: 0x040012BA RID: 4794
		internal const int kListID_ServerChange = 4;

		// Token: 0x040012BB RID: 4795
		internal const int kListID_ClientChange = 5;

		// Token: 0x040012BC RID: 4796
		internal const int kListID_ServerApply = 6;

		// Token: 0x040012BD RID: 4797
		internal const int kListID_ClientApply = 7;

		// Token: 0x040012BE RID: 4798
		internal const int kMaxListCount = 8;

		// Token: 0x040012BF RID: 4799
		internal const string kListString_ServerRegistry = "SERVER MOVER REGISTRY";

		// Token: 0x040012C0 RID: 4800
		internal const string kListString_ClientRegistry = "CLIENT MOVER REGISTRY";

		// Token: 0x040012C1 RID: 4801
		internal const string kListString_ServerDetect = "SERVER PROCESS DETECTION";

		// Token: 0x040012C2 RID: 4802
		internal const string kListString_ClientDetect = "CLIENT PROCESS DETECTION";

		// Token: 0x040012C3 RID: 4803
		internal const string kListString_ServerChange = "SERVER CHANGE QUEUE";

		// Token: 0x040012C4 RID: 4804
		internal const string kListString_ClientChange = "CLIENT CHANGE QUEUE";

		// Token: 0x040012C5 RID: 4805
		internal const string kListString_ServerApply = "SERVER COOK LIST";

		// Token: 0x040012C6 RID: 4806
		internal const string kListString_ClientApply = "CLIENT COOK LIST";

		// Token: 0x040012C7 RID: 4807
		public int size;

		// Token: 0x040012C8 RID: 4808
		public int capacity;

		// Token: 0x040012C9 RID: 4809
		public int iterator;

		// Token: 0x040012CA RID: 4810
		private readonly int id;

		// Token: 0x040012CB RID: 4811
		private bool disposed;

		// Token: 0x040012CC RID: 4812
		public global::NetworkCullInfo[] buffer;

		// Token: 0x040012CD RID: 4813
		private static readonly string[] exceptionDisposedMessages = new string[8];

		// Token: 0x040012CE RID: 4814
		private static readonly global::NetworkCullInfo.List[] lists = new global::NetworkCullInfo.List[8];

		// Token: 0x040012CF RID: 4815
		private static int listsCount;

		// Token: 0x040012D0 RID: 4816
		private static int autoRemoveLockCount;

		// Token: 0x040012D1 RID: 4817
		private static int autoRemoveLockedModifications;

		// Token: 0x040012D2 RID: 4818
		private static bool autoRemoveLocked;

		// Token: 0x040012D3 RID: 4819
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map5;
	}
}

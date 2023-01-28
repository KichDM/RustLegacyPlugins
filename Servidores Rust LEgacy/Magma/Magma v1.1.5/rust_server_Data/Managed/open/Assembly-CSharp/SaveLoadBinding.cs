using System;
using System.Collections.Generic;
using uLink;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public sealed class SaveLoadBinding
{
	// Token: 0x0600041F RID: 1055 RVA: 0x0001385C File Offset: 0x00011A5C
	internal SaveLoadBinding()
	{
		this.savedToCurrent = new global::System.Collections.Generic.Dictionary<int, global::NetEntityID>();
		this.loadCallbacks = new global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.HashSet<global::SaveLoadBinding.CallbackData>>();
		this.shutdown = false;
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x00013884 File Offset: 0x00011A84
	internal void Bind(int oldID, global::uLink.NetworkViewID currentID)
	{
		this.Bind(oldID, currentID);
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x00013894 File Offset: 0x00011A94
	internal void Bind(int oldID, global::NetEntityID currentID)
	{
		this.savedToCurrent[oldID] = currentID;
		global::System.Collections.Generic.HashSet<global::SaveLoadBinding.CallbackData> hashSet;
		if (this.loadCallbacks.TryGetValue(oldID, out hashSet))
		{
			this.savedToCurrent.Remove(oldID);
			foreach (global::SaveLoadBinding.CallbackData callbackData in hashSet)
			{
				try
				{
					callbackData.callback(oldID, currentID, callbackData.userData);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
				}
			}
		}
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x00013958 File Offset: 0x00011B58
	internal void FinalizeBinding()
	{
		if (!this.shutdown)
		{
			this.shutdown = true;
			global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.HashSet<global::SaveLoadBinding.CallbackData>>> list = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.HashSet<global::SaveLoadBinding.CallbackData>>>(this.loadCallbacks);
			this.loadCallbacks.Clear();
			foreach (global::System.Collections.Generic.KeyValuePair<int, global::System.Collections.Generic.HashSet<global::SaveLoadBinding.CallbackData>> keyValuePair in list)
			{
				int key = keyValuePair.Key;
				foreach (global::SaveLoadBinding.CallbackData callbackData in keyValuePair.Value)
				{
					try
					{
						callbackData.callback(key, global::NetEntityID.unassigned, callbackData.userData);
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogException(ex);
					}
				}
			}
		}
	}

	// Token: 0x1700008D RID: 141
	public global::NetEntityID this[int oldID]
	{
		get
		{
			global::NetEntityID result;
			this.TryGetIDFromSavedID(oldID, out result);
			return result;
		}
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x00013A94 File Offset: 0x00011C94
	public bool TryGetIDFromSavedID(int oldID, out global::NetEntityID currentID)
	{
		if (!this.savedToCurrent.TryGetValue(oldID, out currentID))
		{
			currentID = global::NetEntityID.unassigned;
			return false;
		}
		return true;
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x00013AC4 File Offset: 0x00011CC4
	public void RegisterCallbackOnLoaded(int oldID, global::SaveLoadBindingCallback callback, object userData)
	{
		global::NetEntityID spawnedID;
		if (!this.TryGetIDFromSavedID(oldID, out spawnedID))
		{
			if (!this.shutdown)
			{
				goto IL_33;
			}
		}
		try
		{
			callback(oldID, spawnedID, userData);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex);
		}
		IL_33:
		global::SaveLoadBinding.CallbackData item = new global::SaveLoadBinding.CallbackData(callback, userData);
		global::System.Collections.Generic.HashSet<global::SaveLoadBinding.CallbackData> hashSet;
		if (!this.loadCallbacks.TryGetValue(oldID, out hashSet))
		{
			hashSet = (this.loadCallbacks[oldID] = new global::System.Collections.Generic.HashSet<global::SaveLoadBinding.CallbackData>());
		}
		hashSet.Add(item);
	}

	// Token: 0x040003E5 RID: 997
	[global::System.NonSerialized]
	private readonly global::System.Collections.Generic.Dictionary<int, global::NetEntityID> savedToCurrent;

	// Token: 0x040003E6 RID: 998
	[global::System.NonSerialized]
	private readonly global::System.Collections.Generic.Dictionary<int, global::System.Collections.Generic.HashSet<global::SaveLoadBinding.CallbackData>> loadCallbacks;

	// Token: 0x040003E7 RID: 999
	[global::System.NonSerialized]
	private bool shutdown;

	// Token: 0x020000D7 RID: 215
	private class CallbackData : global::System.IEquatable<global::SaveLoadBinding.CallbackData>
	{
		// Token: 0x06000426 RID: 1062 RVA: 0x00013B58 File Offset: 0x00011D58
		public CallbackData(global::SaveLoadBindingCallback callback, object userData)
		{
			if (object.ReferenceEquals(callback, null))
			{
				throw new global::System.ArgumentNullException("callback");
			}
			this.callback = callback;
			this.userData = userData;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00013B88 File Offset: 0x00011D88
		public override bool Equals(object obj)
		{
			return obj is global::SaveLoadBinding.CallbackData && this.Equals((global::SaveLoadBinding.CallbackData)obj);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00013BA4 File Offset: 0x00011DA4
		public bool Equals(global::SaveLoadBinding.CallbackData obj)
		{
			return !object.ReferenceEquals(obj, null) && obj.callback == this.callback && object.Equals(this.userData, obj.userData);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00013BE8 File Offset: 0x00011DE8
		public override int GetHashCode()
		{
			int num = this.callback.GetHashCode();
			if (!object.ReferenceEquals(this.userData, null))
			{
				int hashCode = this.userData.GetHashCode();
				num ^= (hashCode << 0x10 | (hashCode >> 0x10 & 0xFFFF));
			}
			return num;
		}

		// Token: 0x040003E8 RID: 1000
		public readonly global::SaveLoadBindingCallback callback;

		// Token: 0x040003E9 RID: 1001
		public readonly object userData;
	}
}

using System;
using UnityEngine;

// Token: 0x0200045F RID: 1119
public static class SocketUtility
{
	// Token: 0x060026AF RID: 9903 RVA: 0x000948D0 File Offset: 0x00092AD0
	public static void Play(this global::UnityEngine.AudioClip clip, global::Socket socket, bool parent, float volume, float pitch, global::UnityEngine.AudioRolloffMode rolloffMode, float minDistance, float maxDistance, float doppler, float spread, bool bypassEffects)
	{
		if (socket != null)
		{
			return;
		}
		if (parent)
		{
			socket.Snap();
			clip.Play(socket.attachParent, socket.position, socket.rotation, volume, pitch, rolloffMode, minDistance, maxDistance, doppler, spread, bypassEffects);
		}
		else
		{
			clip.Play(socket.position, socket.rotation, volume, pitch, rolloffMode, minDistance, maxDistance, doppler, spread, bypassEffects);
		}
	}

	// Token: 0x060026B0 RID: 9904 RVA: 0x00094940 File Offset: 0x00092B40
	public static bool FindSocket<TSocket>(this global::Socket.Map map, string name, out TSocket socket) where TSocket : global::Socket, new()
	{
		return map.Socket<TSocket>(name, out socket);
	}

	// Token: 0x060026B1 RID: 9905 RVA: 0x00094960 File Offset: 0x00092B60
	public static bool FindSocket<TSocket>(this global::Socket.Map map, int index, out TSocket socket) where TSocket : global::Socket, new()
	{
		return map.Socket<TSocket>(index, out socket);
	}

	// Token: 0x060026B2 RID: 9906 RVA: 0x00094980 File Offset: 0x00092B80
	public static bool FindSocket(this global::Socket.Map map, string name, out global::Socket socket)
	{
		return map.Socket(name, out socket);
	}

	// Token: 0x060026B3 RID: 9907 RVA: 0x000949A0 File Offset: 0x00092BA0
	public static bool FindSocket(this global::Socket.Map map, int index, out global::Socket socket)
	{
		return map.Socket(index, out socket);
	}

	// Token: 0x060026B4 RID: 9908 RVA: 0x000949C0 File Offset: 0x00092BC0
	public static bool ContainsSocket<TSocket>(this global::Socket.Map map, string name) where TSocket : global::Socket, new()
	{
		TSocket tsocket;
		return map.FindSocket(name, out tsocket);
	}

	// Token: 0x060026B5 RID: 9909 RVA: 0x000949D8 File Offset: 0x00092BD8
	public static bool ContainsSocket<TSocket>(this global::Socket.Map map, int index) where TSocket : global::Socket, new()
	{
		TSocket tsocket;
		return map.FindSocket(index, out tsocket);
	}

	// Token: 0x060026B6 RID: 9910 RVA: 0x000949F0 File Offset: 0x00092BF0
	public static bool ContainsSocket(this global::Socket.Map map, string name)
	{
		global::Socket socket;
		return map.FindSocket(name, out socket);
	}

	// Token: 0x060026B7 RID: 9911 RVA: 0x00094A08 File Offset: 0x00092C08
	public static bool ContainsSocket(this global::Socket.Map map, int index)
	{
		global::Socket socket;
		return map.FindSocket(index, out socket);
	}

	// Token: 0x060026B8 RID: 9912 RVA: 0x00094A20 File Offset: 0x00092C20
	public static int SocketIndex(this global::Socket.Map map, string name)
	{
		int result;
		map.SocketIndex(name, out result);
		return result;
	}

	// Token: 0x060026B9 RID: 9913 RVA: 0x00094A40 File Offset: 0x00092C40
	public static global::Socket.Map GetSocketMapOrNull(this global::Socket.Mapped mapped)
	{
		return (!object.ReferenceEquals(mapped, null) && mapped as global::UnityEngine.Object) ? mapped.socketMap : null;
	}

	// Token: 0x060026BA RID: 9914 RVA: 0x00094A78 File Offset: 0x00092C78
	public static bool GetSocketMapOrNull(this global::Socket.Mapped mapped, out global::Socket.Map map)
	{
		if (object.ReferenceEquals(mapped, null) || !(mapped as global::UnityEngine.Object))
		{
			map = null;
			return false;
		}
		map = mapped.socketMap;
		return !object.ReferenceEquals(map, null);
	}

	// Token: 0x060026BB RID: 9915 RVA: 0x00094ABC File Offset: 0x00092CBC
	public static bool FindSocket<TSocket>(this global::Socket.Mapped mapped, string name, out TSocket socket) where TSocket : global::Socket, new()
	{
		return mapped.GetSocketMapOrNull().Socket<TSocket>(name, out socket);
	}

	// Token: 0x060026BC RID: 9916 RVA: 0x00094AE0 File Offset: 0x00092CE0
	public static bool FindSocket<TSocket>(this global::Socket.Mapped mapped, int index, out TSocket socket) where TSocket : global::Socket, new()
	{
		return mapped.GetSocketMapOrNull().Socket<TSocket>(index, out socket);
	}

	// Token: 0x060026BD RID: 9917 RVA: 0x00094B04 File Offset: 0x00092D04
	public static bool FindSocket(this global::Socket.Mapped mapped, string name, out global::Socket socket)
	{
		return mapped.GetSocketMapOrNull().Socket(name, out socket);
	}

	// Token: 0x060026BE RID: 9918 RVA: 0x00094B28 File Offset: 0x00092D28
	public static bool FindSocket(this global::Socket.Mapped mapped, int index, out global::Socket socket)
	{
		return mapped.GetSocketMapOrNull().Socket(index, out socket);
	}

	// Token: 0x060026BF RID: 9919 RVA: 0x00094B4C File Offset: 0x00092D4C
	public static bool ContainsSocket<TSocket>(this global::Socket.Mapped mapped, string name) where TSocket : global::Socket, new()
	{
		TSocket tsocket;
		return mapped.GetSocketMapOrNull().FindSocket(name, out tsocket);
	}

	// Token: 0x060026C0 RID: 9920 RVA: 0x00094B68 File Offset: 0x00092D68
	public static bool ContainsSocket<TSocket>(this global::Socket.Mapped mapped, int index) where TSocket : global::Socket, new()
	{
		TSocket tsocket;
		return mapped.GetSocketMapOrNull().FindSocket(index, out tsocket);
	}

	// Token: 0x060026C1 RID: 9921 RVA: 0x00094B84 File Offset: 0x00092D84
	public static bool ContainsSocket(this global::Socket.Mapped mapped, string name)
	{
		global::Socket socket;
		return mapped.GetSocketMapOrNull().FindSocket(name, out socket);
	}

	// Token: 0x060026C2 RID: 9922 RVA: 0x00094BA0 File Offset: 0x00092DA0
	public static bool ContainsSocket(this global::Socket.Mapped mapped, int index)
	{
		global::Socket socket;
		return mapped.GetSocketMapOrNull().FindSocket(index, out socket);
	}

	// Token: 0x060026C3 RID: 9923 RVA: 0x00094BBC File Offset: 0x00092DBC
	public static int SocketIndex(this global::Socket.Mapped mapped, string name)
	{
		int result;
		mapped.GetSocketMapOrNull().SocketIndex(name, out result);
		return result;
	}
}

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// Token: 0x020001EB RID: 491
public struct EventLister<T>
{
	// Token: 0x06000DA4 RID: 3492 RVA: 0x000352B8 File Offset: 0x000334B8
	static EventLister()
	{
		if (!typeof(T).IsSubclassOf(typeof(global::System.Delegate)))
		{
			throw new global::System.InvalidOperationException("T is not a delegate");
		}
		global::EventListerInvokeAttribute eventListerInvokeAttribute = (global::EventListerInvokeAttribute)global::System.Attribute.GetCustomAttribute(typeof(T), typeof(global::EventListerInvokeAttribute), false);
		global::EventLister<T>.InvokeCallType = eventListerInvokeAttribute.InvokeCall;
		global::EventLister<T>.CalleeType = eventListerInvokeAttribute.InvokeClass;
		global::System.Reflection.MethodInfo method = global::EventLister<T>.InvokeCallType.GetMethod("Invoke");
		global::System.Reflection.ParameterInfo[] parameters = method.GetParameters();
		global::System.Type[] array = new global::System.Type[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		global::EventLister<T>.CalleeMethod = global::EventLister<T>.CalleeType.GetMethod(eventListerInvokeAttribute.InvokeMember, global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic, null, method.CallingConvention, array, null);
		global::System.Reflection.ParameterInfo[] parameters2 = global::EventLister<T>.CalleeMethod.GetParameters();
		for (int j = 0; j < parameters2.Length; j++)
		{
			if ((parameters2[j].Attributes & parameters[j].Attributes) != parameters[j].Attributes)
			{
				throw new global::System.InvalidOperationException("Parameter does not match the InvokeCall " + parameters2[j]);
			}
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x000353E8 File Offset: 0x000335E8
	public bool empty
	{
		get
		{
			return object.ReferenceEquals(this.node, null);
		}
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x000353F8 File Offset: 0x000335F8
	public bool Add(T callback)
	{
		if (object.ReferenceEquals(this.node, null))
		{
			this.node = new global::EventLister<T>.Node(callback);
			return true;
		}
		if (this.node.hashSet.Add(callback))
		{
			this.node.list.Add(callback);
			this.node.count++;
			return true;
		}
		return false;
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x00035464 File Offset: 0x00033664
	public bool Remove(T callback)
	{
		if (object.ReferenceEquals(this.node, null) || !this.node.hashSet.Remove(callback))
		{
			return false;
		}
		if (--this.node.count == 0 && !this.node.invoking)
		{
			this.node = null;
		}
		else
		{
			int num = this.node.list.IndexOf(callback);
			this.node.list.RemoveAt(num);
			if (this.node.iter > num)
			{
				this.node.iter--;
			}
		}
		return true;
	}

	// Token: 0x06000DA8 RID: 3496 RVA: 0x0003551C File Offset: 0x0003371C
	public void Clear()
	{
		this.node = null;
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x00035528 File Offset: 0x00033728
	public bool Invoke<C>(C caller)
	{
		if (object.ReferenceEquals(this.node, null))
		{
			return false;
		}
		if (this.node.invoking)
		{
			throw new global::System.InvalidOperationException("This lister is invoking already");
		}
		global::EventLister<T>.ExecCall<C> invoke = global::EventLister<T>.Invocation<C>.Invoke;
		try
		{
			this.node.invoking = true;
			this.node.iter = 0;
			while (this.node.iter < this.node.count)
			{
				T callback = this.node.list[this.node.iter++];
				try
				{
					invoke(caller, callback);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex);
				}
			}
		}
		finally
		{
			if (this.node.count == 0)
			{
				this.node = null;
			}
			else
			{
				this.node.invoking = false;
			}
		}
		return true;
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x00035644 File Offset: 0x00033844
	public void InvokeManual<C>(T callback, C caller)
	{
		try
		{
			global::EventLister<T>.Invocation<C>.Invoke(caller, callback);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex);
		}
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x0003568C File Offset: 0x0003388C
	public bool Invoke<C, D>(C caller, ref D data)
	{
		if (object.ReferenceEquals(this.node, null))
		{
			return false;
		}
		if (this.node.invoking)
		{
			throw new global::System.InvalidOperationException("This lister is invoking already");
		}
		global::EventLister<T>.ExecCall<C, D> invoke = global::EventLister<T>.Invocation<C, D>.Invoke;
		try
		{
			this.node.invoking = true;
			this.node.iter = 0;
			while (this.node.iter < this.node.count)
			{
				T callback = this.node.list[this.node.iter++];
				try
				{
					invoke(caller, ref data, callback);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogError(ex);
				}
			}
		}
		finally
		{
			if (this.node.count == 0)
			{
				this.node = null;
			}
			else
			{
				this.node.invoking = false;
			}
		}
		return true;
	}

	// Token: 0x06000DAC RID: 3500 RVA: 0x000357AC File Offset: 0x000339AC
	public void InvokeManual<C, D>(T callback, C caller, ref D data)
	{
		try
		{
			global::EventLister<T>.Invocation<C, D>.Invoke(caller, ref data, callback);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex);
		}
	}

	// Token: 0x040008A4 RID: 2212
	public static readonly global::System.Type InvokeCallType;

	// Token: 0x040008A5 RID: 2213
	public static readonly global::System.Type CalleeType;

	// Token: 0x040008A6 RID: 2214
	public static readonly global::System.Reflection.MethodInfo CalleeMethod;

	// Token: 0x040008A7 RID: 2215
	private global::EventLister<T>.Node node;

	// Token: 0x020001EC RID: 492
	internal static class Invocation<C>
	{
		// Token: 0x06000DAD RID: 3501 RVA: 0x000357F4 File Offset: 0x000339F4
		static Invocation()
		{
			if (global::EventLister<T>.InvokeCallType != typeof(global::EventLister<T>.ExecCall<C>))
			{
				throw new global::System.InvalidOperationException(global::EventLister<T>.InvokeCallType.Name + " should have been used.");
			}
			global::EventLister<T>.Invocation<C>.Invoke = (global::EventLister<T>.ExecCall<C>)global::System.Delegate.CreateDelegate(typeof(global::EventLister<T>.ExecCall<C>), global::EventLister<T>.CalleeMethod);
		}

		// Token: 0x040008A8 RID: 2216
		public static readonly global::EventLister<T>.ExecCall<C> Invoke;
	}

	// Token: 0x020001ED RID: 493
	internal static class Invocation<C, D>
	{
		// Token: 0x06000DAE RID: 3502 RVA: 0x00035850 File Offset: 0x00033A50
		static Invocation()
		{
			if (global::EventLister<T>.InvokeCallType != typeof(global::EventLister<T>.ExecCall<C, D>))
			{
				throw new global::System.InvalidOperationException(global::EventLister<T>.InvokeCallType.Name + " should have been used.");
			}
			global::EventLister<T>.Invocation<C, D>.Invoke = (global::EventLister<T>.ExecCall<C, D>)global::System.Delegate.CreateDelegate(typeof(global::EventLister<T>.ExecCall<C, D>), global::EventLister<T>.CalleeMethod);
		}

		// Token: 0x040008A9 RID: 2217
		public static readonly global::EventLister<T>.ExecCall<C, D> Invoke;
	}

	// Token: 0x020001EE RID: 494
	private sealed class Node
	{
		// Token: 0x06000DAF RID: 3503 RVA: 0x000358AC File Offset: 0x00033AAC
		internal Node(T callback)
		{
			this.hashSet.Add(callback);
			this.list.Add(callback);
			this.count = 1;
		}

		// Token: 0x040008AA RID: 2218
		internal readonly global::System.Collections.Generic.HashSet<T> hashSet = new global::System.Collections.Generic.HashSet<T>();

		// Token: 0x040008AB RID: 2219
		internal readonly global::System.Collections.Generic.List<T> list = new global::System.Collections.Generic.List<T>();

		// Token: 0x040008AC RID: 2220
		internal int count;

		// Token: 0x040008AD RID: 2221
		internal int iter;

		// Token: 0x040008AE RID: 2222
		internal bool invoking;
	}

	// Token: 0x020001EF RID: 495
	// (Invoke) Token: 0x06000DB1 RID: 3505
	public delegate void ExecCall<C>(C caller, T callback);

	// Token: 0x020001F0 RID: 496
	// (Invoke) Token: 0x06000DB5 RID: 3509
	public delegate void ExecCall<C, D>(C caller, ref D data, T callback);
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uLink;
using UnityEngine;

// Token: 0x0200033A RID: 826
public sealed class InterpTimedEvent : global::System.IDisposable
{
	// Token: 0x06001BCF RID: 7119 RVA: 0x0006F7AC File Offset: 0x0006D9AC
	private InterpTimedEvent()
	{
	}

	// Token: 0x06001BD0 RID: 7120 RVA: 0x0006F7B4 File Offset: 0x0006D9B4
	// Note: this type is marked as 'beforefieldinit'.
	static InterpTimedEvent()
	{
	}

	// Token: 0x1700079E RID: 1950
	// (get) Token: 0x06001BD1 RID: 7121 RVA: 0x0006F7C4 File Offset: 0x0006D9C4
	public static int ArgumentCount
	{
		get
		{
			return global::InterpTimedEvent.current.args.length;
		}
	}

	// Token: 0x1700079F RID: 1951
	// (get) Token: 0x06001BD2 RID: 7122 RVA: 0x0006F7D8 File Offset: 0x0006D9D8
	public static global::UnityEngine.MonoBehaviour Target
	{
		get
		{
			return global::InterpTimedEvent.current.component;
		}
	}

	// Token: 0x170007A0 RID: 1952
	// (get) Token: 0x06001BD3 RID: 7123 RVA: 0x0006F7E4 File Offset: 0x0006D9E4
	public static string Tag
	{
		get
		{
			return global::InterpTimedEvent.current.tag;
		}
	}

	// Token: 0x06001BD4 RID: 7124 RVA: 0x0006F7F0 File Offset: 0x0006D9F0
	public static object Argument(int index)
	{
		return global::InterpTimedEvent.current.args.parameters[index];
	}

	// Token: 0x170007A1 RID: 1953
	// (get) Token: 0x06001BD5 RID: 7125 RVA: 0x0006F804 File Offset: 0x0006DA04
	public static global::uLink.NetworkMessageInfo Info
	{
		get
		{
			return global::InterpTimedEvent.current.info;
		}
	}

	// Token: 0x170007A2 RID: 1954
	// (get) Token: 0x06001BD6 RID: 7126 RVA: 0x0006F810 File Offset: 0x0006DA10
	public static double Timestamp
	{
		get
		{
			return global::InterpTimedEvent.current.info.timestamp;
		}
	}

	// Token: 0x170007A3 RID: 1955
	// (get) Token: 0x06001BD7 RID: 7127 RVA: 0x0006F824 File Offset: 0x0006DA24
	public static ulong TimestampInMilliseconds
	{
		get
		{
			return global::InterpTimedEvent.current.info.timestampInMillis;
		}
	}

	// Token: 0x170007A4 RID: 1956
	// (get) Token: 0x06001BD8 RID: 7128 RVA: 0x0006F838 File Offset: 0x0006DA38
	public static global::uLink.NetworkPlayer Sender
	{
		get
		{
			return global::InterpTimedEvent.current.info.sender;
		}
	}

	// Token: 0x170007A5 RID: 1957
	// (get) Token: 0x06001BD9 RID: 7129 RVA: 0x0006F84C File Offset: 0x0006DA4C
	public static global::uLink.NetworkView NetworkView
	{
		get
		{
			return global::InterpTimedEvent.current.info.networkView;
		}
	}

	// Token: 0x170007A6 RID: 1958
	// (get) Token: 0x06001BDA RID: 7130 RVA: 0x0006F860 File Offset: 0x0006DA60
	public static global::uLink.NetworkFlags Flags
	{
		get
		{
			return global::InterpTimedEvent.current.info.flags;
		}
	}

	// Token: 0x06001BDB RID: 7131 RVA: 0x0006F874 File Offset: 0x0006DA74
	public static global::System.Type ArgumentType(int index)
	{
		return global::InterpTimedEvent.current.args.types[index];
	}

	// Token: 0x170007A7 RID: 1959
	// (get) Token: 0x06001BDC RID: 7132 RVA: 0x0006F888 File Offset: 0x0006DA88
	public static object[] ArgumentArray
	{
		get
		{
			return global::InterpTimedEvent.current.args.parameters;
		}
	}

	// Token: 0x170007A8 RID: 1960
	// (get) Token: 0x06001BDD RID: 7133 RVA: 0x0006F89C File Offset: 0x0006DA9C
	public static global::System.Type[] ArgumentTypeArray
	{
		get
		{
			return global::InterpTimedEvent.current.args.types;
		}
	}

	// Token: 0x06001BDE RID: 7134 RVA: 0x0006F8B0 File Offset: 0x0006DAB0
	public static T Argument<T>(int index)
	{
		global::System.Type type = global::InterpTimedEvent.current.args.types[index];
		if (!typeof(T).IsAssignableFrom(type) && (typeof(void) != type || typeof(T).IsValueType))
		{
			throw new global::System.InvalidCastException(string.Format("Argument #{0} was a {1} and {2} is not assignable by {1}", index, global::InterpTimedEvent.current.args.types[index], typeof(T)));
		}
		return (T)((object)global::InterpTimedEvent.current.args.parameters[index]);
	}

	// Token: 0x06001BDF RID: 7135 RVA: 0x0006F950 File Offset: 0x0006DB50
	public static bool ArgumentIs<T>(int index)
	{
		global::System.Type type = global::InterpTimedEvent.current.args.types[index];
		return typeof(T).IsAssignableFrom(type) || (type == typeof(void) && !typeof(T).IsValueType);
	}

	// Token: 0x06001BE0 RID: 7136 RVA: 0x0006F9AC File Offset: 0x0006DBAC
	public static bool ArgumentIs(int index, global::System.Type comptype)
	{
		global::System.Type type = global::InterpTimedEvent.current.args.types[index];
		return comptype.IsAssignableFrom(global::InterpTimedEvent.current.args.types[index]) || (type == typeof(void) && !comptype.IsValueType);
	}

	// Token: 0x06001BE1 RID: 7137 RVA: 0x0006FA08 File Offset: 0x0006DC08
	public static void MarkUnhandled()
	{
		global::UnityEngine.Debug.LogWarning("Unhandled Timed Event :" + ((!string.IsNullOrEmpty(global::InterpTimedEvent.current.tag)) ? global::InterpTimedEvent.current.tag : " without a tag"), global::InterpTimedEvent.current.component);
	}

	// Token: 0x170007A9 RID: 1961
	// (get) Token: 0x06001BE2 RID: 7138 RVA: 0x0006FA58 File Offset: 0x0006DC58
	// (set) Token: 0x06001BE3 RID: 7139 RVA: 0x0006FA60 File Offset: 0x0006DC60
	public static bool syncronizationPaused
	{
		get
		{
			return global::InterpTimedEventSyncronizer.paused;
		}
		set
		{
			global::InterpTimedEventSyncronizer.paused = value;
		}
	}

	// Token: 0x170007AA RID: 1962
	// (get) Token: 0x06001BE4 RID: 7140 RVA: 0x0006FA68 File Offset: 0x0006DC68
	public global::IInterpTimedEventReceiver receiver
	{
		get
		{
			return this.component as global::IInterpTimedEventReceiver;
		}
	}

	// Token: 0x06001BE5 RID: 7141 RVA: 0x0006FA78 File Offset: 0x0006DC78
	public static void EmergencyDump()
	{
	}

	// Token: 0x06001BE6 RID: 7142 RVA: 0x0006FA7C File Offset: 0x0006DC7C
	public void Dispose()
	{
		if (this.inlist)
		{
			global::InterpTimedEvent.queue.Remove(this);
		}
		if (!this.disposed)
		{
			this.prev = default(global::InterpTimedEvent.Dir);
			this.next = global::InterpTimedEvent.dump;
			global::InterpTimedEvent.dump.has = true;
			global::InterpTimedEvent.dump.node = this;
			this.component = null;
			this.args.Dispose();
			this.args = null;
			this.info = null;
			this.tag = null;
			global::InterpTimedEvent.dumpCount++;
			this.disposed = true;
		}
	}

	// Token: 0x06001BE7 RID: 7143 RVA: 0x0006FB18 File Offset: 0x0006DD18
	private static void InvokeDirect(global::InterpTimedEvent evnt)
	{
		global::InterpTimedEvent interpTimedEvent = global::InterpTimedEvent.current;
		global::InterpTimedEvent.current = evnt;
		global::InterpTimedEvent.Invoke();
		global::InterpTimedEvent.current = interpTimedEvent;
	}

	// Token: 0x06001BE8 RID: 7144 RVA: 0x0006FB3C File Offset: 0x0006DD3C
	private static void Invoke()
	{
		global::UnityEngine.MonoBehaviour monoBehaviour = global::InterpTimedEvent.current.component;
		if (monoBehaviour)
		{
			global::IInterpTimedEventReceiver interpTimedEventReceiver = monoBehaviour as global::IInterpTimedEventReceiver;
			try
			{
				interpTimedEventReceiver.OnInterpTimedEvent();
			}
			catch (global::System.Exception arg)
			{
				global::UnityEngine.Debug.LogError("Exception thrown during catchup \r\n" + arg, monoBehaviour);
			}
		}
		else
		{
			global::UnityEngine.Debug.LogWarning("A component implementing IInterpTimeEventReceiver was destroyed without properly calling InterpEvent.Remove() in OnDestroy!\r\n" + ((!string.IsNullOrEmpty(global::InterpTimedEvent.current.tag)) ? ("The tag was \"" + global::InterpTimedEvent.current.tag + "\"") : "There was no tag set"));
		}
		global::InterpTimedEvent.current.Dispose();
	}

	// Token: 0x06001BE9 RID: 7145 RVA: 0x0006FBFC File Offset: 0x0006DDFC
	public static void Catchup()
	{
		global::InterpTimedEvent.Catchup(global::Interpolation.timeInMillis);
	}

	// Token: 0x06001BEA RID: 7146 RVA: 0x0006FC08 File Offset: 0x0006DE08
	public static void ForceCatchupToDate()
	{
		global::InterpTimedEvent._forceCatchupToDate = true;
	}

	// Token: 0x06001BEB RID: 7147 RVA: 0x0006FC10 File Offset: 0x0006DE10
	public static void Catchup(ulong playhead)
	{
		global::InterpTimedEvent._forceCatchupToDate = false;
		while (global::InterpTimedEvent.queue.Dequeue(playhead, out global::InterpTimedEvent.current))
		{
			global::InterpTimedEvent.Invoke();
		}
	}

	// Token: 0x06001BEC RID: 7148 RVA: 0x0006FC38 File Offset: 0x0006DE38
	public static void Clear()
	{
		global::InterpTimedEvent.Clear(false);
	}

	// Token: 0x06001BED RID: 7149 RVA: 0x0006FC40 File Offset: 0x0006DE40
	public static void Clear(bool invokePending)
	{
		global::InterpTimedEvent.LList.Iterator iterator = default(global::InterpTimedEvent.LList.Iterator);
		if (invokePending)
		{
			global::InterpTimedEvent interpTimedEvent;
			while (global::InterpTimedEvent.queue.Dequeue(0xFFFFFFFFFFFFFFFFUL, out interpTimedEvent, ref iterator))
			{
				global::InterpTimedEvent.InvokeDirect(interpTimedEvent);
			}
		}
		else
		{
			global::InterpTimedEvent interpTimedEvent;
			while (global::InterpTimedEvent.queue.Dequeue(0xFFFFFFFFFFFFFFFFUL, out interpTimedEvent, ref iterator))
			{
				interpTimedEvent.Dispose();
			}
		}
	}

	// Token: 0x06001BEE RID: 7150 RVA: 0x0006FCA4 File Offset: 0x0006DEA4
	public static void Remove(global::UnityEngine.MonoBehaviour receiver)
	{
		global::InterpTimedEvent.Remove(receiver, false);
	}

	// Token: 0x06001BEF RID: 7151 RVA: 0x0006FCB0 File Offset: 0x0006DEB0
	public static void Remove(global::UnityEngine.MonoBehaviour receiver, bool invokePending)
	{
		global::InterpTimedEvent.LList.Iterator iterator = default(global::InterpTimedEvent.LList.Iterator);
		if (invokePending)
		{
			global::InterpTimedEvent interpTimedEvent;
			while (global::InterpTimedEvent.queue.Dequeue(receiver, 0xFFFFFFFFFFFFFFFFUL, out interpTimedEvent, ref iterator))
			{
				global::InterpTimedEvent.InvokeDirect(interpTimedEvent);
			}
		}
		else
		{
			global::InterpTimedEvent interpTimedEvent;
			while (global::InterpTimedEvent.queue.Dequeue(receiver, 0xFFFFFFFFFFFFFFFFUL, out interpTimedEvent, ref iterator))
			{
				interpTimedEvent.Dispose();
			}
		}
	}

	// Token: 0x06001BF0 RID: 7152 RVA: 0x0006FD14 File Offset: 0x0006DF14
	internal static global::InterpTimedEvent New(global::UnityEngine.MonoBehaviour receiver, string tag, ref global::uLink.NetworkMessageInfo info, object[] args, bool immediate)
	{
		if (!receiver)
		{
			global::UnityEngine.Debug.LogError("receiver is null or has been destroyed", receiver);
			return null;
		}
		if (!(receiver is global::IInterpTimedEventReceiver))
		{
			global::UnityEngine.Debug.LogError("receiver of type " + receiver.GetType() + " does not implement IInterpTimedEventReceiver", receiver);
			return null;
		}
		global::InterpTimedEvent interpTimedEvent;
		if (global::InterpTimedEvent.dump.has)
		{
			global::InterpTimedEvent.dumpCount--;
			interpTimedEvent = global::InterpTimedEvent.dump.node;
			global::InterpTimedEvent.dump = interpTimedEvent.next;
			interpTimedEvent.next = default(global::InterpTimedEvent.Dir);
			interpTimedEvent.prev = default(global::InterpTimedEvent.Dir);
			interpTimedEvent.disposed = false;
		}
		else
		{
			interpTimedEvent = new global::InterpTimedEvent();
		}
		interpTimedEvent.args = global::InterpTimedEvent.ArgList.New(args);
		interpTimedEvent.tag = tag;
		interpTimedEvent.component = receiver;
		interpTimedEvent.info = info;
		if (!immediate)
		{
			global::InterpTimedEvent.queue.Insert(interpTimedEvent);
		}
		return interpTimedEvent;
	}

	// Token: 0x06001BF1 RID: 7153 RVA: 0x0006FDF8 File Offset: 0x0006DFF8
	public static bool Queue(global::IInterpTimedEventReceiver receiver, string tag, ref global::uLink.NetworkMessageInfo info)
	{
		return global::InterpTimedEvent.QueueOrExecute(receiver, false, tag, ref info, global::InterpTimedEvent.emptyArgs);
	}

	// Token: 0x06001BF2 RID: 7154 RVA: 0x0006FE08 File Offset: 0x0006E008
	public static bool Queue(global::IInterpTimedEventReceiver receiver, string tag, ref global::uLink.NetworkMessageInfo info, params object[] args)
	{
		return global::InterpTimedEvent.QueueOrExecute(receiver, false, tag, ref info, args);
	}

	// Token: 0x06001BF3 RID: 7155 RVA: 0x0006FE14 File Offset: 0x0006E014
	public static bool Execute(global::IInterpTimedEventReceiver receiver, string tag, ref global::uLink.NetworkMessageInfo info)
	{
		return global::InterpTimedEvent.QueueOrExecute(receiver, true, tag, ref info, global::InterpTimedEvent.emptyArgs);
	}

	// Token: 0x06001BF4 RID: 7156 RVA: 0x0006FE24 File Offset: 0x0006E024
	public static bool Execute(global::IInterpTimedEventReceiver receiver, string tag, ref global::uLink.NetworkMessageInfo info, params object[] args)
	{
		return global::InterpTimedEvent.QueueOrExecute(receiver, true, tag, ref info, args);
	}

	// Token: 0x06001BF5 RID: 7157 RVA: 0x0006FE30 File Offset: 0x0006E030
	public static bool QueueOrExecute(global::IInterpTimedEventReceiver receiver, bool immediate, string tag, ref global::uLink.NetworkMessageInfo info)
	{
		return global::InterpTimedEvent.QueueOrExecute(receiver, immediate, tag, ref info, global::InterpTimedEvent.emptyArgs);
	}

	// Token: 0x06001BF6 RID: 7158 RVA: 0x0006FE40 File Offset: 0x0006E040
	public static bool QueueOrExecute(global::IInterpTimedEventReceiver receiver, bool immediate, string tag, ref global::uLink.NetworkMessageInfo info, params object[] args)
	{
		global::UnityEngine.MonoBehaviour receiver2 = receiver as global::UnityEngine.MonoBehaviour;
		immediate = true;
		global::InterpTimedEvent interpTimedEvent = global::InterpTimedEvent.New(receiver2, tag, ref info, args, immediate);
		if (interpTimedEvent == null)
		{
			return false;
		}
		if (immediate)
		{
			global::InterpTimedEvent.InvokeDirect(interpTimedEvent);
		}
		else if (!global::InterpTimedEventSyncronizer.available)
		{
			global::UnityEngine.Debug.LogWarning("Not running event because theres no syncronizer available. " + tag, receiver as global::UnityEngine.Object);
			return false;
		}
		return true;
	}

	// Token: 0x06001BF7 RID: 7159 RVA: 0x0006FEA0 File Offset: 0x0006E0A0
	public static void EMERGENCY_DUMP(bool TRY_TO_EXECUTE)
	{
		global::UnityEngine.Debug.LogWarning("RUNNING EMERGENCY DUMP: TRY TO EXECUTE=" + TRY_TO_EXECUTE);
		try
		{
			if (TRY_TO_EXECUTE)
			{
				try
				{
					global::System.Collections.Generic.List<global::InterpTimedEvent> list = global::InterpTimedEvent.queue.EmergencyDump(true);
					foreach (global::InterpTimedEvent interpTimedEvent in list)
					{
						try
						{
							global::InterpTimedEvent.InvokeDirect(interpTimedEvent);
						}
						catch (global::System.Exception ex)
						{
							global::UnityEngine.Debug.LogException(ex);
						}
						finally
						{
							try
							{
								interpTimedEvent.Dispose();
							}
							catch (global::System.Exception ex2)
							{
								global::UnityEngine.Debug.LogException(ex2);
							}
						}
					}
				}
				catch (global::System.Exception ex3)
				{
					global::UnityEngine.Debug.LogException(ex3);
				}
			}
			else
			{
				global::InterpTimedEvent.queue.EmergencyDump(false);
			}
		}
		catch (global::System.Exception ex4)
		{
			global::UnityEngine.Debug.LogException(ex4);
		}
		finally
		{
			global::InterpTimedEvent.queue = default(global::InterpTimedEvent.LList);
			global::InterpTimedEvent.dump = default(global::InterpTimedEvent.Dir);
			global::InterpTimedEvent.dumpCount = 0;
		}
		global::UnityEngine.Debug.LogWarning("END OF EMERGENCY DUMP: TRY TO EXECUTE=" + TRY_TO_EXECUTE);
	}

	// Token: 0x04001042 RID: 4162
	internal static global::InterpTimedEvent current;

	// Token: 0x04001043 RID: 4163
	public global::UnityEngine.MonoBehaviour component;

	// Token: 0x04001044 RID: 4164
	public global::uLink.NetworkMessageInfo info;

	// Token: 0x04001045 RID: 4165
	public global::InterpTimedEvent.ArgList args;

	// Token: 0x04001046 RID: 4166
	public string tag;

	// Token: 0x04001047 RID: 4167
	private bool disposed;

	// Token: 0x04001048 RID: 4168
	private bool inlist;

	// Token: 0x04001049 RID: 4169
	private static int dumpCount;

	// Token: 0x0400104A RID: 4170
	private static global::InterpTimedEvent.Dir dump;

	// Token: 0x0400104B RID: 4171
	private static global::InterpTimedEvent.LList queue;

	// Token: 0x0400104C RID: 4172
	internal global::InterpTimedEvent.Dir next;

	// Token: 0x0400104D RID: 4173
	internal global::InterpTimedEvent.Dir prev;

	// Token: 0x0400104E RID: 4174
	private static bool _forceCatchupToDate;

	// Token: 0x0400104F RID: 4175
	private static readonly object[] emptyArgs = new object[0];

	// Token: 0x0200033B RID: 827
	public sealed class ArgList : global::System.IDisposable
	{
		// Token: 0x06001BF8 RID: 7160 RVA: 0x00070054 File Offset: 0x0006E254
		private ArgList(int length)
		{
			this.length = length;
			this.parameters = new object[length];
			this.types = new global::System.Type[length];
		}

		// Token: 0x06001BF9 RID: 7161 RVA: 0x0007007C File Offset: 0x0006E27C
		// Note: this type is marked as 'beforefieldinit'.
		static ArgList()
		{
		}

		// Token: 0x06001BFA RID: 7162 RVA: 0x00070094 File Offset: 0x0006E294
		private void AddToDump(ref global::InterpTimedEvent.ArgList.Dump dump)
		{
			this.dumpNext = dump.last;
			dump.count++;
			dump.last = this;
		}

		// Token: 0x06001BFB RID: 7163 RVA: 0x000700B8 File Offset: 0x0006E2B8
		public void Dispose()
		{
			if (!this.disposed && this.length != 0)
			{
				for (int i = 0; i < this.length; i++)
				{
					this.types[i] = null;
					this.parameters[i] = null;
				}
				if (global::InterpTimedEvent.ArgList.dumps.Length <= this.length)
				{
					global::System.Array.Resize<global::InterpTimedEvent.ArgList.Dump>(ref global::InterpTimedEvent.ArgList.dumps, this.length + 1);
				}
				this.AddToDump(ref global::InterpTimedEvent.ArgList.dumps[this.length]);
				this.disposed = true;
			}
		}

		// Token: 0x06001BFC RID: 7164 RVA: 0x00070148 File Offset: 0x0006E348
		private static global::InterpTimedEvent.ArgList Recycle(ref global::InterpTimedEvent.ArgList.Dump dump, int length)
		{
			if (dump.count > 0)
			{
				global::InterpTimedEvent.ArgList last = dump.last;
				dump.last = last.dumpNext;
				dump.count--;
				last.dumpNext = null;
				last.disposed = false;
				return last;
			}
			return new global::InterpTimedEvent.ArgList(length);
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x00070198 File Offset: 0x0006E398
		public static global::InterpTimedEvent.ArgList New(object[] args)
		{
			int num = (args != null) ? args.Length : 0;
			if (num == 0)
			{
				return global::InterpTimedEvent.ArgList.voidParameters;
			}
			global::InterpTimedEvent.ArgList argList;
			if (global::InterpTimedEvent.ArgList.dumps.Length > num)
			{
				argList = global::InterpTimedEvent.ArgList.Recycle(ref global::InterpTimedEvent.ArgList.dumps[num], num);
			}
			else
			{
				argList = new global::InterpTimedEvent.ArgList(num);
			}
			for (int i = 0; i < num; i++)
			{
				object obj = args[i];
				argList.parameters[i] = obj;
				argList.types[i] = ((obj != null) ? obj.GetType() : typeof(void));
			}
			return argList;
		}

		// Token: 0x04001050 RID: 4176
		public readonly object[] parameters;

		// Token: 0x04001051 RID: 4177
		public readonly global::System.Type[] types;

		// Token: 0x04001052 RID: 4178
		public readonly int length;

		// Token: 0x04001053 RID: 4179
		private bool disposed;

		// Token: 0x04001054 RID: 4180
		private static global::InterpTimedEvent.ArgList voidParameters = new global::InterpTimedEvent.ArgList(0);

		// Token: 0x04001055 RID: 4181
		private static global::InterpTimedEvent.ArgList.Dump[] dumps = new global::InterpTimedEvent.ArgList.Dump[4];

		// Token: 0x04001056 RID: 4182
		private global::InterpTimedEvent.ArgList dumpNext;

		// Token: 0x0200033C RID: 828
		private struct Dump
		{
			// Token: 0x04001057 RID: 4183
			public global::InterpTimedEvent.ArgList last;

			// Token: 0x04001058 RID: 4184
			public int count;
		}
	}

	// Token: 0x0200033D RID: 829
	internal struct Dir
	{
		// Token: 0x04001059 RID: 4185
		public bool has;

		// Token: 0x0400105A RID: 4186
		public global::InterpTimedEvent node;
	}

	// Token: 0x0200033E RID: 830
	internal struct LList
	{
		// Token: 0x06001BFE RID: 7166 RVA: 0x00070230 File Offset: 0x0006E430
		public bool Dequeue(ulong playhead, out global::InterpTimedEvent node)
		{
			global::InterpTimedEvent.LList.Iterator iterator = default(global::InterpTimedEvent.LList.Iterator);
			return this.Dequeue(playhead, out node, ref iterator);
		}

		// Token: 0x06001BFF RID: 7167 RVA: 0x00070254 File Offset: 0x0006E454
		public bool Dequeue(ulong playhead, out global::InterpTimedEvent node, ref global::InterpTimedEvent.LList.Iterator iter_)
		{
			if (this.count <= 0)
			{
				node = null;
				return false;
			}
			global::InterpTimedEvent.Dir dir = (!iter_.started) ? this.first : iter_.d;
			if (dir.has)
			{
				if (playhead >= dir.node.info.timestamp)
				{
					node = dir.node;
					iter_.d = node.next;
					iter_.started = true;
					this.Remove(node);
					return true;
				}
			}
			iter_.d = default(global::InterpTimedEvent.Dir);
			iter_.started = true;
			node = null;
			return false;
		}

		// Token: 0x06001C00 RID: 7168 RVA: 0x00070300 File Offset: 0x0006E500
		public bool Dequeue(global::UnityEngine.MonoBehaviour script, ulong playhead, out global::InterpTimedEvent node)
		{
			global::InterpTimedEvent.LList.Iterator iterator = default(global::InterpTimedEvent.LList.Iterator);
			return this.Dequeue(script, playhead, out node, ref iterator);
		}

		// Token: 0x06001C01 RID: 7169 RVA: 0x00070324 File Offset: 0x0006E524
		public bool Dequeue(global::UnityEngine.MonoBehaviour script, ulong playhead, out global::InterpTimedEvent node, ref global::InterpTimedEvent.LList.Iterator iter_)
		{
			if (this.count <= 0)
			{
				node = null;
				return false;
			}
			global::InterpTimedEvent.Dir dir = (!iter_.started) ? this.first : iter_.d;
			while (dir.has)
			{
				if (playhead < dir.node.info.timestamp)
				{
					break;
				}
				if (dir.node.component == script)
				{
					node = dir.node;
					iter_.d = node.next;
					iter_.started = true;
					this.Remove(node);
					return true;
				}
				dir = dir.node.next;
			}
			iter_.d = default(global::InterpTimedEvent.Dir);
			iter_.started = true;
			node = null;
			return false;
		}

		// Token: 0x06001C02 RID: 7170 RVA: 0x000703FC File Offset: 0x0006E5FC
		internal bool Remove(global::InterpTimedEvent node)
		{
			if (this.RemoveUnsafe(node))
			{
				if (this.FAIL_SAFE_SET != null)
				{
					this.FAIL_SAFE_SET.Remove(node);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001C03 RID: 7171 RVA: 0x00070428 File Offset: 0x0006E628
		private bool RemoveUnsafe(global::InterpTimedEvent node)
		{
			if (this.count > 0 && node != null && node.inlist)
			{
				if (node.prev.has)
				{
					if (node.next.has)
					{
						node.next.node.prev = node.prev;
						node.prev.node.next = node.next;
						this.count--;
						node.prev = (node.next = default(global::InterpTimedEvent.Dir));
						node.inlist = false;
						return true;
					}
					this.last = node.prev;
					this.last.node.next = default(global::InterpTimedEvent.Dir);
					this.count--;
					node.prev = (node.next = default(global::InterpTimedEvent.Dir));
					node.inlist = false;
					return true;
				}
				else
				{
					if (node.next.has)
					{
						this.first = node.next;
						this.first.node.prev = default(global::InterpTimedEvent.Dir);
						this.count--;
						node.prev = (node.next = default(global::InterpTimedEvent.Dir));
						node.inlist = false;
						return true;
					}
					if (this.first.node == node)
					{
						this.first = (this.last = default(global::InterpTimedEvent.Dir));
						this.count = 0;
						node.prev = (node.next = default(global::InterpTimedEvent.Dir));
						node.inlist = false;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06001C04 RID: 7172 RVA: 0x000705E0 File Offset: 0x0006E7E0
		private bool Insert(ref global::InterpTimedEvent.Dir ent)
		{
			if (ent.node == null)
			{
				return false;
			}
			if (ent.node.inlist)
			{
				return false;
			}
			if (this.count == 0)
			{
				this.first = (this.last = ent);
			}
			else if (this.last.node.info.timestampInMillis <= ent.node.info.timestampInMillis)
			{
				if (this.count == 1)
				{
					this.first = this.last;
					this.last = ent;
					ent.node.prev = this.first;
					this.first.node.next = this.last;
				}
				else
				{
					ent.node.prev = this.last;
					this.last.node.next = ent;
					this.last = ent;
				}
			}
			else if (this.count == 1)
			{
				this.first = ent;
				this.first.node.next = this.last;
				this.last.node.prev = this.first;
			}
			else if (this.first.node.info.timestampInMillis > ent.node.info.timestampInMillis)
			{
				ent.node.next = this.first;
				this.first.node.prev = ent;
				this.first = ent;
			}
			else
			{
				global::InterpTimedEvent.Dir prev;
				if (this.first.node.info.timestampInMillis == ent.node.info.timestampInMillis)
				{
					prev = this.first;
					while (prev.node.next.has)
					{
						if (prev.node.next.node.info.timestampInMillis > ent.node.info.timestampInMillis)
						{
							break;
						}
						prev = prev.node.next;
					}
				}
				else
				{
					prev = this.last;
					while (prev.node.prev.has)
					{
						prev = prev.node.prev;
						if (prev.node.info.timestampInMillis <= ent.node.info.timestampInMillis)
						{
							break;
						}
					}
				}
				ent.node.next = prev.node.next;
				ent.node.prev = prev;
			}
			this.count++;
			ent.node.inlist = true;
			if (this.FAIL_SAFE_SET == null)
			{
				this.FAIL_SAFE_SET = new global::System.Collections.Generic.HashSet<global::InterpTimedEvent>();
			}
			this.FAIL_SAFE_SET.Add(ent.node);
			return true;
		}

		// Token: 0x06001C05 RID: 7173 RVA: 0x000708E4 File Offset: 0x0006EAE4
		public bool Insert(global::InterpTimedEvent node)
		{
			global::InterpTimedEvent.Dir dir;
			dir.node = node;
			dir.has = true;
			return this.Insert(ref dir);
		}

		// Token: 0x06001C06 RID: 7174 RVA: 0x0007090C File Offset: 0x0006EB0C
		public global::System.Collections.Generic.List<global::InterpTimedEvent> EmergencyDump(bool botherSorting)
		{
			global::System.Collections.Generic.HashSet<global::InterpTimedEvent> hashSet = new global::System.Collections.Generic.HashSet<global::InterpTimedEvent>();
			global::InterpTimedEvent.LList.Iterator iterator = default(global::InterpTimedEvent.LList.Iterator);
			bool flag;
			do
			{
				global::InterpTimedEvent item;
				try
				{
					flag = this.Dequeue(ulong.MaxValue, out item, ref iterator);
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex);
					break;
				}
				if (flag)
				{
					hashSet.Add(item);
				}
			}
			while (flag);
			this.first = (this.last = default(global::InterpTimedEvent.Dir));
			this.count = 0;
			global::System.Collections.Generic.HashSet<global::InterpTimedEvent> fail_SAFE_SET = this.FAIL_SAFE_SET;
			this.FAIL_SAFE_SET = null;
			if (fail_SAFE_SET != null)
			{
				hashSet.UnionWith(fail_SAFE_SET);
			}
			global::System.Collections.Generic.List<global::InterpTimedEvent> list = new global::System.Collections.Generic.List<global::InterpTimedEvent>(hashSet);
			if (botherSorting)
			{
				try
				{
					list.Sort(delegate(global::InterpTimedEvent x, global::InterpTimedEvent y)
					{
						if (x == null)
						{
							if (y == null)
							{
								return 0;
							}
							return 0.CompareTo(1);
						}
						else
						{
							if (y == null)
							{
								return 1.CompareTo(0);
							}
							ulong timestampInMillis = x.info.timestampInMillis;
							return timestampInMillis.CompareTo(y.info.timestampInMillis);
						}
					});
				}
				catch (global::System.Exception ex2)
				{
					global::UnityEngine.Debug.LogException(ex2);
				}
			}
			return list;
		}

		// Token: 0x06001C07 RID: 7175 RVA: 0x00070A20 File Offset: 0x0006EC20
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static int <EmergencyDump>m__13(global::InterpTimedEvent x, global::InterpTimedEvent y)
		{
			if (x == null)
			{
				if (y == null)
				{
					return 0;
				}
				return 0.CompareTo(1);
			}
			else
			{
				if (y == null)
				{
					return 1.CompareTo(0);
				}
				ulong timestampInMillis = x.info.timestampInMillis;
				return timestampInMillis.CompareTo(y.info.timestampInMillis);
			}
		}

		// Token: 0x0400105B RID: 4187
		public global::InterpTimedEvent.Dir first;

		// Token: 0x0400105C RID: 4188
		public global::InterpTimedEvent.Dir last;

		// Token: 0x0400105D RID: 4189
		public int count;

		// Token: 0x0400105E RID: 4190
		private global::System.Collections.Generic.HashSet<global::InterpTimedEvent> FAIL_SAFE_SET;

		// Token: 0x0400105F RID: 4191
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Comparison<global::InterpTimedEvent> <>f__am$cache4;

		// Token: 0x0200033F RID: 831
		public struct Iterator
		{
			// Token: 0x04001060 RID: 4192
			internal global::InterpTimedEvent.Dir d;

			// Token: 0x04001061 RID: 4193
			internal bool started;
		}
	}
}

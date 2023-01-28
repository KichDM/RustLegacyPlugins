using System;
using System.Threading;
using System.Timers;

namespace Magma.Events
{
	// Token: 0x02000011 RID: 17
	public class TimedEvent
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600009D RID: 157 RVA: 0x000035CC File Offset: 0x000017CC
		// (remove) Token: 0x0600009E RID: 158 RVA: 0x00003604 File Offset: 0x00001804
		public event global::Magma.Events.TimedEvent.TimedEventFireDelegate OnFire
		{
			add
			{
				global::Magma.Events.TimedEvent.TimedEventFireDelegate timedEventFireDelegate = this.OnFire;
				global::Magma.Events.TimedEvent.TimedEventFireDelegate timedEventFireDelegate2;
				do
				{
					timedEventFireDelegate2 = timedEventFireDelegate;
					global::Magma.Events.TimedEvent.TimedEventFireDelegate value2 = (global::Magma.Events.TimedEvent.TimedEventFireDelegate)global::System.Delegate.Combine(timedEventFireDelegate2, value);
					timedEventFireDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Events.TimedEvent.TimedEventFireDelegate>(ref this.OnFire, value2, timedEventFireDelegate2);
				}
				while (timedEventFireDelegate != timedEventFireDelegate2);
			}
			remove
			{
				global::Magma.Events.TimedEvent.TimedEventFireDelegate timedEventFireDelegate = this.OnFire;
				global::Magma.Events.TimedEvent.TimedEventFireDelegate timedEventFireDelegate2;
				do
				{
					timedEventFireDelegate2 = timedEventFireDelegate;
					global::Magma.Events.TimedEvent.TimedEventFireDelegate value2 = (global::Magma.Events.TimedEvent.TimedEventFireDelegate)global::System.Delegate.Remove(timedEventFireDelegate2, value);
					timedEventFireDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Events.TimedEvent.TimedEventFireDelegate>(ref this.OnFire, value2, timedEventFireDelegate2);
				}
				while (timedEventFireDelegate != timedEventFireDelegate2);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600009F RID: 159 RVA: 0x0000363C File Offset: 0x0000183C
		// (remove) Token: 0x060000A0 RID: 160 RVA: 0x00003674 File Offset: 0x00001874
		public event global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate OnFireArgs
		{
			add
			{
				global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate timedEventFireArgsDelegate = this.OnFireArgs;
				global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate timedEventFireArgsDelegate2;
				do
				{
					timedEventFireArgsDelegate2 = timedEventFireArgsDelegate;
					global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate value2 = (global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate)global::System.Delegate.Combine(timedEventFireArgsDelegate2, value);
					timedEventFireArgsDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate>(ref this.OnFireArgs, value2, timedEventFireArgsDelegate2);
				}
				while (timedEventFireArgsDelegate != timedEventFireArgsDelegate2);
			}
			remove
			{
				global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate timedEventFireArgsDelegate = this.OnFireArgs;
				global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate timedEventFireArgsDelegate2;
				do
				{
					timedEventFireArgsDelegate2 = timedEventFireArgsDelegate;
					global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate value2 = (global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate)global::System.Delegate.Remove(timedEventFireArgsDelegate2, value);
					timedEventFireArgsDelegate = global::System.Threading.Interlocked.CompareExchange<global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate>(ref this.OnFireArgs, value2, timedEventFireArgsDelegate2);
				}
				while (timedEventFireArgsDelegate != timedEventFireArgsDelegate2);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000036A9 File Offset: 0x000018A9
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x000036B1 File Offset: 0x000018B1
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x000036BA File Offset: 0x000018BA
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x000036C7 File Offset: 0x000018C7
		public double Interval
		{
			get
			{
				return this._timer.Interval;
			}
			set
			{
				this._timer.Interval = value;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x000036D8 File Offset: 0x000018D8
		public double TimeLeft
		{
			get
			{
				return this.Interval - (double)((global::System.DateTime.UtcNow.Ticks - this.lastTick) / 0x2710L);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00003708 File Offset: 0x00001908
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00003710 File Offset: 0x00001910
		public global::ParamsList Args
		{
			get
			{
				return this._args;
			}
			set
			{
				this._args = value;
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003719 File Offset: 0x00001919
		public TimedEvent(string name, double interval)
		{
			this._name = name;
			this._timer = new global::System.Timers.Timer();
			this._timer.Interval = interval;
			this._timer.Elapsed += this._timer_Elapsed;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003756 File Offset: 0x00001956
		public TimedEvent(string name, double interval, global::ParamsList args) : this(name, interval)
		{
			this.Args = args;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003768 File Offset: 0x00001968
		public void Start()
		{
			this._timer.Start();
			this.lastTick = global::System.DateTime.UtcNow.Ticks;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003793 File Offset: 0x00001993
		public void Stop()
		{
			this._timer.Stop();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000037A0 File Offset: 0x000019A0
		private void _timer_Elapsed(object sender, global::System.Timers.ElapsedEventArgs e)
		{
			if (this.OnFire != null)
			{
				this.OnFire(this.Name);
			}
			if (this.OnFireArgs != null)
			{
				this.OnFireArgs(this.Name, this.Args);
			}
			this.lastTick = global::System.DateTime.UtcNow.Ticks;
		}

		// Token: 0x04000026 RID: 38
		private global::Magma.Events.TimedEvent.TimedEventFireDelegate OnFire;

		// Token: 0x04000027 RID: 39
		private global::Magma.Events.TimedEvent.TimedEventFireArgsDelegate OnFireArgs;

		// Token: 0x04000028 RID: 40
		private global::System.Timers.Timer _timer;

		// Token: 0x04000029 RID: 41
		private long lastTick;

		// Token: 0x0400002A RID: 42
		private string _name;

		// Token: 0x0400002B RID: 43
		private global::ParamsList _args;

		// Token: 0x02000012 RID: 18
		// (Invoke) Token: 0x060000AE RID: 174
		public delegate void TimedEventFireDelegate(string name);

		// Token: 0x02000013 RID: 19
		// (Invoke) Token: 0x060000B2 RID: 178
		public delegate void TimedEventFireArgsDelegate(string name, global::ParamsList list);
	}
}

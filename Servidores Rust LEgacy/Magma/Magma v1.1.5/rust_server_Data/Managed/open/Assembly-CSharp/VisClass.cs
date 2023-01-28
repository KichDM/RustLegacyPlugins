using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020004B7 RID: 1207
public class VisClass : global::UnityEngine.ScriptableObject
{
	// Token: 0x060029E3 RID: 10723 RVA: 0x0009DE64 File Offset: 0x0009C064
	public VisClass()
	{
	}

	// Token: 0x060029E4 RID: 10724 RVA: 0x0009DE6C File Offset: 0x0009C06C
	// Note: this type is marked as 'beforefieldinit'.
	static VisClass()
	{
	}

	// Token: 0x17000941 RID: 2369
	// (get) Token: 0x060029E5 RID: 10725 RVA: 0x0009DE7C File Offset: 0x0009C07C
	public global::VisClass superClass
	{
		get
		{
			return this._super;
		}
	}

	// Token: 0x060029E6 RID: 10726 RVA: 0x0009DE84 File Offset: 0x0009C084
	public void EditorOnly_Rep(ref global::VisClass.Rep rep)
	{
		if (this.keys == null && this.values == null)
		{
			this.keys = new string[0];
			this.values = new global::VisQuery[0];
		}
		global::VisClass.Rep.Ref(ref rep, this);
	}

	// Token: 0x060029E7 RID: 10727 RVA: 0x0009DEBC File Offset: 0x0009C0BC
	public bool EditorOnly_Apply(ref global::VisClass.Rep rep)
	{
		return rep != null && rep.Apply();
	}

	// Token: 0x060029E8 RID: 10728 RVA: 0x0009DED0 File Offset: 0x0009C0D0
	public void EditorOnly_Add(ref global::VisClass.Rep rep, string key, global::VisQuery value)
	{
		global::System.Array.Resize<string>(ref this.keys, this.keys.Length + 1);
		global::System.Array.Resize<global::VisQuery>(ref this.values, this.values.Length + 1);
		this.keys[this.keys.Length - 1] = key;
		this.values[this.values.Length - 1] = value;
		rep = null;
	}

	// Token: 0x060029E9 RID: 10729 RVA: 0x0009DF30 File Offset: 0x0009C130
	public bool EditorOnly_SetSuper(ref global::VisClass.Rep rep, global::VisClass _super)
	{
		global::VisClass visClass = _super;
		int num = 0x32;
		while (visClass != null)
		{
			if (visClass == this)
			{
				global::UnityEngine.Debug.LogError("Self Reference Detected", this);
				return false;
			}
			visClass = visClass._super;
			if (--num <= 0)
			{
				global::UnityEngine.Debug.LogError("Circular Dependancy Detected", this);
				return false;
			}
		}
		rep = null;
		this._super = _super;
		return true;
	}

	// Token: 0x060029EA RID: 10730 RVA: 0x0009DF98 File Offset: 0x0009C198
	private void BuildMembers(global::System.Collections.Generic.List<global::VisQuery> list, global::System.Collections.Generic.HashSet<global::VisQuery> hset)
	{
		if (this._super)
		{
			if (this._super.recurseLock)
			{
				global::UnityEngine.Debug.LogError("Recursion in setup hit itself, some VisClass has super set to something which references itself", this._super);
				return;
			}
			this._super.recurseLock = true;
			this._super.BuildMembers(list, hset);
			this._super.recurseLock = false;
		}
		if (this.values != null)
		{
			for (int i = 0; i < this.values.Length; i++)
			{
				if (this.values[i] != null && hset.Remove(this.values[i]))
				{
					list.Add(this.values[i]);
				}
			}
		}
	}

	// Token: 0x060029EB RID: 10731 RVA: 0x0009E054 File Offset: 0x0009C254
	private void Setup()
	{
		if (this.locked)
		{
			return;
		}
		if (this.recurseLock)
		{
			global::UnityEngine.Debug.LogError("Recursion in setup hit itself, some VisClass has super set to something which references itself", this);
			return;
		}
		this.recurseLock = true;
		global::System.Collections.Generic.List<global::VisQuery> list = new global::System.Collections.Generic.List<global::VisQuery>();
		global::System.Collections.Generic.HashSet<global::VisQuery> hashSet = new global::System.Collections.Generic.HashSet<global::VisQuery>();
		global::System.Collections.Generic.Dictionary<string, global::VisQuery> dictionary = new global::System.Collections.Generic.Dictionary<string, global::VisQuery>();
		if (this._super)
		{
			this._super.Setup();
			if (this.keys != null)
			{
				for (int i = 0; i < this.keys.Length; i++)
				{
					string text = this.keys[i];
					if (!string.IsNullOrEmpty(text))
					{
						global::VisQuery visQuery = this.values[i];
						int num;
						if (this._super.members.TryGetValue(text, out num))
						{
							global::VisQuery visQuery2 = this._super.instance[num];
							if (visQuery2 == visQuery)
							{
								if (visQuery2 != null)
								{
									hashSet.Add(visQuery2);
									dictionary.Add(text, visQuery2);
								}
							}
							else if (visQuery != null)
							{
								dictionary.Add(text, visQuery);
								hashSet.Add(visQuery);
							}
						}
						else if (visQuery != null)
						{
							dictionary.Add(text, visQuery);
							hashSet.Add(visQuery);
						}
					}
				}
			}
			this.BuildMembers(list, hashSet);
		}
		else
		{
			for (int j = 0; j < this.keys.Length; j++)
			{
				string text2 = this.keys[j];
				if (!string.IsNullOrEmpty(text2))
				{
					global::VisQuery visQuery3 = this.values[j];
					if (!(visQuery3 == null))
					{
						dictionary.Add(text2, visQuery3);
						if (hashSet.Add(visQuery3))
						{
							list.Add(visQuery3);
						}
					}
				}
			}
		}
		this.members = new global::System.Collections.Generic.Dictionary<string, int>(dictionary.Count);
		foreach (global::System.Collections.Generic.KeyValuePair<string, global::VisQuery> keyValuePair in dictionary)
		{
			this.members.Add(keyValuePair.Key, list.IndexOf(keyValuePair.Value));
		}
		this.instance = list.ToArray();
		this.recurseLock = false;
		this.locked = true;
	}

	// Token: 0x17000942 RID: 2370
	// (get) Token: 0x060029EC RID: 10732 RVA: 0x0009E2C0 File Offset: 0x0009C4C0
	public global::VisClass.Handle handle
	{
		get
		{
			if (!this.locked)
			{
				this.Setup();
				if (!this.locked)
				{
					return new global::VisClass.Handle(null);
				}
			}
			return new global::VisClass.Handle(this);
		}
	}

	// Token: 0x040014FA RID: 5370
	[global::UnityEngine.SerializeField]
	private global::VisClass _super;

	// Token: 0x040014FB RID: 5371
	[global::UnityEngine.SerializeField]
	private string[] keys;

	// Token: 0x040014FC RID: 5372
	[global::UnityEngine.SerializeField]
	private global::VisQuery[] values;

	// Token: 0x040014FD RID: 5373
	[global::System.NonSerialized]
	private global::VisQuery[] instance;

	// Token: 0x040014FE RID: 5374
	[global::System.NonSerialized]
	private global::System.Collections.Generic.Dictionary<string, int> members;

	// Token: 0x040014FF RID: 5375
	[global::System.NonSerialized]
	private bool locked;

	// Token: 0x04001500 RID: 5376
	[global::System.NonSerialized]
	private bool recurseLock;

	// Token: 0x04001501 RID: 5377
	private static readonly global::VisQuery.Instance[] none = new global::VisQuery.Instance[0];

	// Token: 0x020004B8 RID: 1208
	public class Rep
	{
		// Token: 0x060029ED RID: 10733 RVA: 0x0009E2EC File Offset: 0x0009C4EC
		public Rep()
		{
		}

		// Token: 0x060029EE RID: 10734 RVA: 0x0009E300 File Offset: 0x0009C500
		// Note: this type is marked as 'beforefieldinit'.
		static Rep()
		{
		}

		// Token: 0x060029EF RID: 10735 RVA: 0x0009E304 File Offset: 0x0009C504
		private static bool MarkModified(global::VisClass.Rep.Setting setting)
		{
			if (global::VisClass.Rep.building)
			{
				return false;
			}
			setting.rep.modifiedSettings.Add(setting);
			return true;
		}

		// Token: 0x060029F0 RID: 10736 RVA: 0x0009E328 File Offset: 0x0009C528
		internal static void Recur(ref global::VisClass.Rep rep, global::VisClass klass)
		{
			if (klass._super)
			{
				global::VisClass.Rep.Recur(ref rep, klass._super);
				foreach (global::VisClass.Rep.Setting setting in rep.dict.Values)
				{
					setting.isInherited = true;
				}
				for (int i = 0; i < klass.keys.Length; i++)
				{
					string text = klass.keys[i];
					if (!string.IsNullOrEmpty(text))
					{
						global::VisQuery visQuery = klass.values[i];
						global::VisClass.Rep.Setting setting2;
						if (!rep.dict.TryGetValue(text, out setting2))
						{
							if (visQuery == null)
							{
								goto IL_F7;
							}
							setting2 = new global::VisClass.Rep.Setting(text, klass, rep);
							rep.dict.Add(text, setting2);
						}
						else
						{
							setting2 = (rep.dict[text] = setting2.Override(klass));
						}
						setting2.isInherited = false;
						setting2.query = visQuery;
					}
					IL_F7:;
				}
			}
			else
			{
				rep = new global::VisClass.Rep();
				rep.klass = global::VisClass.Rep.nklass;
				rep.dict = new global::System.Collections.Generic.Dictionary<string, global::VisClass.Rep.Setting>();
				for (int j = 0; j < klass.keys.Length; j++)
				{
					string text2 = klass.keys[j];
					if (!string.IsNullOrEmpty(text2))
					{
						global::VisQuery visQuery2 = klass.values[j];
						if (!(visQuery2 == null))
						{
							global::VisClass.Rep.Setting setting3 = new global::VisClass.Rep.Setting(text2, klass, rep);
							setting3.query = visQuery2;
							rep.dict.Add(text2, setting3);
						}
					}
				}
			}
		}

		// Token: 0x060029F1 RID: 10737 RVA: 0x0009E4FC File Offset: 0x0009C6FC
		internal static void Ref(ref global::VisClass.Rep rep, global::VisClass klass)
		{
			if (rep == null)
			{
				global::VisClass.Rep.nklass = klass;
				global::VisClass.Rep.building = true;
				global::VisClass.Rep.Recur(ref rep, klass);
				global::VisClass.Rep.building = false;
				global::VisClass.Rep.nklass = null;
			}
		}

		// Token: 0x060029F2 RID: 10738 RVA: 0x0009E530 File Offset: 0x0009C730
		private void Remove(global::VisClass.Rep.Setting setting)
		{
			for (int i = 0; i < this.klass.keys.Length; i++)
			{
				if (this.klass.keys[i] == setting.name)
				{
					int num = i;
					while (++num < this.klass.keys.Length)
					{
						this.klass.keys[num - 1] = this.klass.keys[num];
						this.klass.values[num - 1] = this.klass.values[num];
					}
					global::System.Array.Resize<string>(ref this.klass.keys, this.klass.keys.Length - 1);
					global::System.Array.Resize<global::VisQuery>(ref this.klass.values, this.klass.values.Length - 1);
					break;
				}
			}
			if (setting.isOverride)
			{
				this.dict[setting.name] = setting.MoveBack();
			}
			else
			{
				this.dict.Remove(setting.name);
			}
		}

		// Token: 0x060029F3 RID: 10739 RVA: 0x0009E64C File Offset: 0x0009C84C
		private void Change(global::VisClass.Rep.Setting setting)
		{
			if (setting.isInherited)
			{
				global::VisQuery valueSet = setting.valueSet;
				setting = (this.dict[setting.name] = setting.Override(this.klass));
				setting.isInherited = false;
				setting.valueSet = valueSet;
				global::System.Array.Resize<string>(ref this.klass.keys, this.klass.keys.Length + 1);
				global::System.Array.Resize<global::VisQuery>(ref this.klass.values, this.klass.values.Length + 1);
				this.klass.keys[this.klass.keys.Length - 1] = setting.name;
				this.klass.values[this.klass.values.Length - 1] = valueSet;
			}
			else
			{
				for (int i = 0; i < this.klass.keys.Length; i++)
				{
					if (this.klass.keys[i] == setting.name)
					{
						this.klass.values[i] = setting.query;
						break;
					}
				}
			}
		}

		// Token: 0x060029F4 RID: 10740 RVA: 0x0009E76C File Offset: 0x0009C96C
		internal bool Apply()
		{
			if (this.modifiedSettings.Count == 0)
			{
				return false;
			}
			foreach (global::VisClass.Rep.Setting setting in this.modifiedSettings)
			{
				global::VisClass.Rep.Action action = setting.action;
				if (action != global::VisClass.Rep.Action.Revert)
				{
					if (action == global::VisClass.Rep.Action.Value)
					{
						if (setting.valueSet == null && !setting.isOverride)
						{
							this.Remove(setting);
						}
						else
						{
							this.Change(setting);
						}
					}
				}
				else
				{
					this.Remove(setting);
				}
				setting.action = global::VisClass.Rep.Action.None;
			}
			return true;
		}

		// Token: 0x04001502 RID: 5378
		internal static global::VisClass nklass;

		// Token: 0x04001503 RID: 5379
		internal global::VisClass klass;

		// Token: 0x04001504 RID: 5380
		private static bool building;

		// Token: 0x04001505 RID: 5381
		private global::System.Collections.Generic.HashSet<global::VisClass.Rep.Setting> modifiedSettings = new global::System.Collections.Generic.HashSet<global::VisClass.Rep.Setting>();

		// Token: 0x04001506 RID: 5382
		public global::System.Collections.Generic.Dictionary<string, global::VisClass.Rep.Setting> dict;

		// Token: 0x020004B9 RID: 1209
		internal enum Action
		{
			// Token: 0x04001508 RID: 5384
			None,
			// Token: 0x04001509 RID: 5385
			Revert,
			// Token: 0x0400150A RID: 5386
			Value
		}

		// Token: 0x020004BA RID: 1210
		public class Setting
		{
			// Token: 0x060029F5 RID: 10741 RVA: 0x0009E844 File Offset: 0x0009CA44
			internal Setting(string key, global::VisClass klass, global::VisClass.Rep rep)
			{
				this.key = key;
				this.rep = rep;
				this._inheritedClass = klass;
			}

			// Token: 0x17000943 RID: 2371
			// (get) Token: 0x060029F6 RID: 10742 RVA: 0x0009E864 File Offset: 0x0009CA64
			internal string name
			{
				get
				{
					return this.key;
				}
			}

			// Token: 0x17000944 RID: 2372
			// (get) Token: 0x060029F7 RID: 10743 RVA: 0x0009E86C File Offset: 0x0009CA6C
			private global::VisClass inheritedClass
			{
				get
				{
					return this._inheritedClass;
				}
			}

			// Token: 0x060029F8 RID: 10744 RVA: 0x0009E874 File Offset: 0x0009CA74
			internal global::VisClass.Rep.Setting Override(global::VisClass klass)
			{
				global::VisClass.Rep.Setting setting = (global::VisClass.Rep.Setting)base.MemberwiseClone();
				setting._inheritedClass = klass;
				setting._hasSuper = true;
				setting._inheritSetting = this;
				return setting;
			}

			// Token: 0x17000945 RID: 2373
			// (get) Token: 0x060029F9 RID: 10745 RVA: 0x0009E8A4 File Offset: 0x0009CAA4
			// (set) Token: 0x060029FA RID: 10746 RVA: 0x0009E8AC File Offset: 0x0009CAAC
			public bool isInherited
			{
				get
				{
					return this._isInherited;
				}
				set
				{
					if (this._isInherited != value)
					{
						this._isInherited = value;
						if (global::VisClass.Rep.MarkModified(this))
						{
							this.action = global::VisClass.Rep.Action.Revert;
						}
					}
				}
			}

			// Token: 0x17000946 RID: 2374
			// (get) Token: 0x060029FB RID: 10747 RVA: 0x0009E8D4 File Offset: 0x0009CAD4
			public bool isOverride
			{
				get
				{
					return this._hasSuper;
				}
			}

			// Token: 0x17000947 RID: 2375
			// (get) Token: 0x060029FC RID: 10748 RVA: 0x0009E8DC File Offset: 0x0009CADC
			public global::VisQuery superQuery
			{
				get
				{
					return (!this._hasSuper) ? null : this._inheritSetting.query;
				}
			}

			// Token: 0x17000948 RID: 2376
			// (get) Token: 0x060029FD RID: 10749 RVA: 0x0009E8FC File Offset: 0x0009CAFC
			// (set) Token: 0x060029FE RID: 10750 RVA: 0x0009E904 File Offset: 0x0009CB04
			public global::VisQuery query
			{
				get
				{
					return this._value;
				}
				set
				{
					if (this._isInherited)
					{
						global::VisClass.Rep.MarkModified(this);
					}
					else if (this._value == value)
					{
						return;
					}
					if (global::VisClass.Rep.MarkModified(this))
					{
						this.action = global::VisClass.Rep.Action.Value;
						this._valueSet = value;
					}
					else
					{
						this._value = value;
					}
				}
			}

			// Token: 0x060029FF RID: 10751 RVA: 0x0009E960 File Offset: 0x0009CB60
			internal global::VisClass.Rep.Setting MoveBack()
			{
				return this._inheritSetting;
			}

			// Token: 0x17000949 RID: 2377
			// (get) Token: 0x06002A00 RID: 10752 RVA: 0x0009E968 File Offset: 0x0009CB68
			// (set) Token: 0x06002A01 RID: 10753 RVA: 0x0009E970 File Offset: 0x0009CB70
			internal global::VisQuery valueSet
			{
				get
				{
					return this._valueSet;
				}
				set
				{
					this._value = value;
				}
			}

			// Token: 0x0400150B RID: 5387
			internal global::VisClass.Rep rep;

			// Token: 0x0400150C RID: 5388
			internal global::VisClass.Rep.Action action;

			// Token: 0x0400150D RID: 5389
			private bool _unchanged;

			// Token: 0x0400150E RID: 5390
			private bool _isInherited;

			// Token: 0x0400150F RID: 5391
			private bool _hasSuper;

			// Token: 0x04001510 RID: 5392
			private global::VisQuery _value;

			// Token: 0x04001511 RID: 5393
			private global::VisQuery _valueSet;

			// Token: 0x04001512 RID: 5394
			private global::VisClass _inheritedClass;

			// Token: 0x04001513 RID: 5395
			private global::VisClass.Rep.Setting _inheritSetting;

			// Token: 0x04001514 RID: 5396
			private string key;
		}
	}

	// Token: 0x020004BB RID: 1211
	public struct Handle
	{
		// Token: 0x06002A02 RID: 10754 RVA: 0x0009E97C File Offset: 0x0009CB7C
		internal Handle(global::VisClass klass)
		{
			this.klass = klass;
			this.bits = 0L;
			if (klass)
			{
				int num = 0;
				this.queries = new global::VisQuery.Instance[klass.instance.Length];
				for (int i = 0; i < this.queries.Length; i++)
				{
					this.queries[i] = new global::VisQuery.Instance(klass.instance[i], ref num);
				}
			}
			else
			{
				this.queries = global::VisClass.none;
			}
		}

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x06002A03 RID: 10755 RVA: 0x0009E9F8 File Offset: 0x0009CBF8
		public bool valid
		{
			get
			{
				return this.queries != null;
			}
		}

		// Token: 0x1700094B RID: 2379
		// (get) Token: 0x06002A04 RID: 10756 RVA: 0x0009EA08 File Offset: 0x0009CC08
		public int Length
		{
			get
			{
				return this.klass.instance.Length;
			}
		}

		// Token: 0x1700094C RID: 2380
		public global::VisQuery.Instance this[int i]
		{
			get
			{
				return this.queries[i];
			}
		}

		// Token: 0x1700094D RID: 2381
		public global::VisQuery.Instance this[string name]
		{
			get
			{
				return this.queries[this.klass.members[name]];
			}
		}

		// Token: 0x04001515 RID: 5397
		private readonly global::VisClass klass;

		// Token: 0x04001516 RID: 5398
		private readonly global::VisQuery.Instance[] queries;

		// Token: 0x04001517 RID: 5399
		private long bits;
	}
}

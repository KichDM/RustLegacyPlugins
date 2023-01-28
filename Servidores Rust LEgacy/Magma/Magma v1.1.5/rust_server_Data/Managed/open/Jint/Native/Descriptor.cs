using System;
using System.Runtime.CompilerServices;

namespace Jint.Native
{
	// Token: 0x02000019 RID: 25
	[global::System.Serializable]
	public abstract class Descriptor
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x00005A00 File Offset: 0x00003C00
		public Descriptor(global::Jint.Native.JsDictionaryObject owner, string name)
		{
			this.Owner = owner;
			this.Name = name;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00005A18 File Offset: 0x00003C18
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x00005A20 File Offset: 0x00003C20
		public string Name
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Name>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Name>k__BackingField = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00005A2C File Offset: 0x00003C2C
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00005A34 File Offset: 0x00003C34
		public bool Enumerable
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Enumerable>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Enumerable>k__BackingField = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00005A40 File Offset: 0x00003C40
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00005A48 File Offset: 0x00003C48
		public bool Configurable
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Configurable>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Configurable>k__BackingField = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00005A54 File Offset: 0x00003C54
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00005A5C File Offset: 0x00003C5C
		public bool Writable
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Writable>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Writable>k__BackingField = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00005A68 File Offset: 0x00003C68
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00005A70 File Offset: 0x00003C70
		public global::Jint.Native.JsDictionaryObject Owner
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Owner>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Owner>k__BackingField = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00005A7C File Offset: 0x00003C7C
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00005A84 File Offset: 0x00003C84
		public virtual bool isDeleted
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<isDeleted>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			protected set
			{
				this.<isDeleted>k__BackingField = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000BE RID: 190
		public abstract bool isReference { get; }

		// Token: 0x060000BF RID: 191 RVA: 0x00005A90 File Offset: 0x00003C90
		public virtual void Delete()
		{
			this.isDeleted = true;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00005A9C File Offset: 0x00003C9C
		public bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000C1 RID: 193
		public abstract global::Jint.Native.Descriptor Clone();

		// Token: 0x060000C2 RID: 194
		public abstract global::Jint.Native.JsInstance Get(global::Jint.Native.JsDictionaryObject that);

		// Token: 0x060000C3 RID: 195
		public abstract void Set(global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance value);

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000C4 RID: 196
		internal abstract global::Jint.Native.DescriptorType DescriptorType { get; }

		// Token: 0x060000C5 RID: 197 RVA: 0x00005AA0 File Offset: 0x00003CA0
		internal static global::Jint.Native.Descriptor ToPropertyDesciptor(global::Jint.Native.IGlobal global, global::Jint.Native.JsDictionaryObject owner, string name, global::Jint.Native.JsInstance jsInstance)
		{
			if (jsInstance.Class != "Object")
			{
				throw new global::Jint.Native.JsException(global.TypeErrorClass.New("The target object has to be an instance of an object"));
			}
			global::Jint.Native.JsObject jsObject = (global::Jint.Native.JsObject)jsInstance;
			if ((jsObject.HasProperty("value") || jsObject.HasProperty("writable")) && (jsObject.HasProperty("set") || jsObject.HasProperty("get")))
			{
				throw new global::Jint.Native.JsException(global.TypeErrorClass.New("The property cannot be both writable and have get/set accessors or cannot have both a value and an accessor defined"));
			}
			global::Jint.Native.JsInstance jsInstance2 = null;
			global::Jint.Native.Descriptor descriptor;
			if (jsObject.HasProperty("value"))
			{
				descriptor = new global::Jint.Native.ValueDescriptor(owner, name, jsObject["value"]);
			}
			else
			{
				descriptor = new global::Jint.Native.PropertyDescriptor(global, owner, name);
			}
			if (jsObject.TryGetProperty("enumerable", out jsInstance2))
			{
				descriptor.Enumerable = jsInstance2.ToBoolean();
			}
			if (jsObject.TryGetProperty("configurable", out jsInstance2))
			{
				descriptor.Configurable = jsInstance2.ToBoolean();
			}
			if (jsObject.TryGetProperty("writable", out jsInstance2))
			{
				descriptor.Writable = jsInstance2.ToBoolean();
			}
			if (jsObject.TryGetProperty("get", out jsInstance2))
			{
				if (!(jsInstance2 is global::Jint.Native.JsFunction))
				{
					throw new global::Jint.Native.JsException(global.TypeErrorClass.New("The getter has to be a function"));
				}
				((global::Jint.Native.PropertyDescriptor)descriptor).GetFunction = (global::Jint.Native.JsFunction)jsInstance2;
			}
			if (jsObject.TryGetProperty("set", out jsInstance2))
			{
				if (!(jsInstance2 is global::Jint.Native.JsFunction))
				{
					throw new global::Jint.Native.JsException(global.TypeErrorClass.New("The setter has to be a function"));
				}
				((global::Jint.Native.PropertyDescriptor)descriptor).SetFunction = (global::Jint.Native.JsFunction)jsInstance2;
			}
			return descriptor;
		}

		// Token: 0x04000048 RID: 72
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private string <Name>k__BackingField;

		// Token: 0x04000049 RID: 73
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <Enumerable>k__BackingField;

		// Token: 0x0400004A RID: 74
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <Configurable>k__BackingField;

		// Token: 0x0400004B RID: 75
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <Writable>k__BackingField;

		// Token: 0x0400004C RID: 76
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsDictionaryObject <Owner>k__BackingField;

		// Token: 0x0400004D RID: 77
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <isDeleted>k__BackingField;
	}
}

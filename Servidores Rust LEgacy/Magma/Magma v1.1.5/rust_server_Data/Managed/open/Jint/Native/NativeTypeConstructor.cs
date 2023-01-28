using System;

namespace Jint.Native
{
	// Token: 0x02000022 RID: 34
	internal class NativeTypeConstructor : global::Jint.Native.NativeConstructor
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00007674 File Offset: 0x00005874
		protected NativeTypeConstructor(global::Jint.Native.IGlobal global, global::Jint.Native.JsObject typePrototype) : base(typeof(global::System.Type), global, typePrototype, typePrototype)
		{
			this.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, typePrototype);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00007698 File Offset: 0x00005898
		public static global::Jint.Native.NativeTypeConstructor CreateNativeTypeConstructor(global::Jint.Native.IGlobal global)
		{
			if (global == null)
			{
				throw new global::System.ArgumentNullException("global");
			}
			global::Jint.Native.JsObject typePrototype = global.FunctionClass.New();
			global::Jint.Native.NativeTypeConstructor nativeTypeConstructor = new global::Jint.Native.NativeTypeConstructor(global, typePrototype);
			nativeTypeConstructor.InitPrototype(global);
			nativeTypeConstructor.SetupNativeProperties(nativeTypeConstructor);
			return nativeTypeConstructor;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000076E0 File Offset: 0x000058E0
		public override global::Jint.Native.JsInstance Wrap<T>(T value)
		{
			if (value == null)
			{
				throw new global::System.ArgumentNullException("value");
			}
			if (value is global::System.Type)
			{
				global::Jint.Native.NativeConstructor nativeConstructor = new global::Jint.Native.NativeConstructor(value as global::System.Type, base.Global, null, base.PrototypeProperty);
				nativeConstructor.InitPrototype(base.Global);
				base.SetupNativeProperties(nativeConstructor);
				return nativeConstructor;
			}
			throw new global::Jint.JintException(string.Concat(new string[]
			{
				"Attempt to wrap '",
				value.GetType().FullName,
				"' with '",
				typeof(global::System.Type).FullName,
				"'"
			}));
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000077B0 File Offset: 0x000059B0
		public global::Jint.Native.JsInstance WrapSpecialType(global::System.Type value, global::Jint.Native.JsObject prototypePropertyPrototype)
		{
			if (value == null)
			{
				throw new global::System.ArgumentNullException("value");
			}
			global::Jint.Native.NativeConstructor nativeConstructor = new global::Jint.Native.NativeConstructor(value, base.Global, prototypePropertyPrototype, base.PrototypeProperty);
			nativeConstructor.InitPrototype(base.Global);
			base.SetupNativeProperties(nativeConstructor);
			return nativeConstructor;
		}
	}
}

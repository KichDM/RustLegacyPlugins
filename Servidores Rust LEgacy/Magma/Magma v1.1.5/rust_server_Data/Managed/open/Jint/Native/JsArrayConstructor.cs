using System;
using System.Collections.Generic;
using System.Text;
using Jint.Expressions;

namespace Jint.Native
{
	// Token: 0x02000057 RID: 87
	[global::System.Serializable]
	public class JsArrayConstructor : global::Jint.Native.JsConstructor
	{
		// Token: 0x06000426 RID: 1062 RVA: 0x00024180 File Offset: 0x00022380
		public JsArrayConstructor(global::Jint.Native.IGlobal global) : base(global)
		{
			base.Name = "Array";
			base.DefineOwnProperty(global::Jint.Native.JsFunction.PROTOTYPE, global.ObjectClass.New(this), global::Jint.Native.PropertyAttributes.ReadOnly | global::Jint.Native.PropertyAttributes.DontEnum | global::Jint.Native.PropertyAttributes.DontDelete);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000241BC File Offset: 0x000223BC
		public override void InitPrototype(global::Jint.Native.IGlobal global)
		{
			global::Jint.Native.JsObject prototypeProperty = base.PrototypeProperty;
			prototypeProperty.DefineOwnProperty(new global::Jint.Native.PropertyDescriptor<global::Jint.Native.JsObject>(global, prototypeProperty, "length", new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance>(this.GetLengthImpl), new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.SetLengthImpl))
			{
				Enumerable = false
			});
			prototypeProperty.DefineOwnProperty("toString", global.FunctionClass.New<global::Jint.Native.JsArray>(new global::System.Func<global::Jint.Native.JsArray, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("toLocaleString", global.FunctionClass.New<global::Jint.Native.JsArray>(new global::System.Func<global::Jint.Native.JsArray, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ToLocaleStringImpl)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("concat", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Concat)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("join", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Join), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("pop", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Pop)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("push", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Push), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("reverse", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Reverse)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("shift", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Shift)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("slice", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Slice), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("sort", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Sort)), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("splice", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.Splice), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("unshift", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.UnShift), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("indexOf", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.IndexOfImpl), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			prototypeProperty.DefineOwnProperty("lastIndexOf", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.LastIndexOfImpl), 1), global::Jint.Native.PropertyAttributes.DontEnum);
			if (global.HasOption(global::Jint.Options.Ecmascript5))
			{
				prototypeProperty.DefineOwnProperty("forEach", global.FunctionClass.New<global::Jint.Native.JsObject>(new global::System.Func<global::Jint.Native.JsObject, global::Jint.Native.JsInstance[], global::Jint.Native.JsInstance>(this.ForEach), 2), global::Jint.Native.PropertyAttributes.DontEnum);
			}
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00024428 File Offset: 0x00022628
		public global::Jint.Native.JsArray New()
		{
			return new global::Jint.Native.JsArray(base.PrototypeProperty);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00024448 File Offset: 0x00022648
		public override global::Jint.Native.JsObject Construct(global::Jint.Native.JsInstance[] parameters, global::System.Type[] genericArgs, global::Jint.Expressions.IJintVisitor visitor)
		{
			global::Jint.Native.JsArray jsArray = this.New();
			for (int i = 0; i < parameters.Length; i++)
			{
				jsArray.put(i, parameters[i]);
			}
			return jsArray;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00024484 File Offset: 0x00022684
		public override global::Jint.Native.JsInstance Execute(global::Jint.Expressions.IJintVisitor visitor, global::Jint.Native.JsDictionaryObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (that == null || that as global::Jint.Native.IGlobal == visitor.Global)
			{
				return visitor.Return(this.Construct(parameters, null, visitor));
			}
			for (int i = 0; i < parameters.Length; i++)
			{
				that[i.ToString()] = parameters[i];
			}
			return visitor.Return(that);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x000244E8 File Offset: 0x000226E8
		public global::Jint.Native.JsInstance ToStringImpl(global::Jint.Native.JsArray target, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsArray jsArray = base.Global.ArrayClass.New();
			for (int i = 0; i < target.Length; i++)
			{
				global::Jint.Native.JsDictionaryObject jsDictionaryObject = (global::Jint.Native.JsDictionaryObject)target[i.ToString()];
				if (global::Jint.ExecutionVisitor.IsNullOrUndefined(jsDictionaryObject))
				{
					jsArray[i.ToString()] = base.Global.StringClass.New();
				}
				else
				{
					global::Jint.Native.JsFunction jsFunction = jsDictionaryObject["toString"] as global::Jint.Native.JsFunction;
					if (jsFunction != null)
					{
						base.Global.Visitor.ExecuteFunction(jsFunction, jsDictionaryObject, parameters);
						jsArray[i.ToString()] = base.Global.Visitor.Returned;
					}
					else
					{
						jsArray[i.ToString()] = base.Global.StringClass.New();
					}
				}
			}
			return base.Global.StringClass.New(jsArray.ToString());
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000245E0 File Offset: 0x000227E0
		public global::Jint.Native.JsInstance ToLocaleStringImpl(global::Jint.Native.JsArray target, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsArray jsArray = base.Global.ArrayClass.New();
			for (int i = 0; i < target.Length; i++)
			{
				global::Jint.Native.JsDictionaryObject jsDictionaryObject = (global::Jint.Native.JsDictionaryObject)target[i.ToString()];
				base.Global.Visitor.ExecuteFunction((global::Jint.Native.JsFunction)jsDictionaryObject["toLocaleString"], jsDictionaryObject, parameters);
				jsArray[i.ToString()] = base.Global.Visitor.Returned;
			}
			return base.Global.StringClass.New(jsArray.ToString());
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00024680 File Offset: 0x00022880
		public global::Jint.Native.JsInstance Concat(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (target is global::Jint.Native.JsArray)
			{
				return ((global::Jint.Native.JsArray)target).concat(base.Global, parameters);
			}
			global::Jint.Native.JsArray jsArray = base.Global.ArrayClass.New();
			global::System.Collections.Generic.List<global::Jint.Native.JsInstance> list = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>();
			list.Add(target);
			list.AddRange(parameters);
			int num = 0;
			while (list.Count > 0)
			{
				global::Jint.Native.JsInstance jsInstance = list[0];
				list.RemoveAt(0);
				if (base.Global.ArrayClass.HasInstance(jsInstance as global::Jint.Native.JsObject))
				{
					for (int i = 0; i < ((global::Jint.Native.JsObject)jsInstance).Length; i++)
					{
						string index = i.ToString();
						global::Jint.Native.JsInstance value = null;
						if (((global::Jint.Native.JsObject)jsInstance).TryGetProperty(index, out value))
						{
							jsArray.put(num, value);
						}
						num++;
					}
				}
				else
				{
					jsArray.put(num, jsInstance);
					num++;
				}
			}
			return jsArray;
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00024770 File Offset: 0x00022970
		public global::Jint.Native.JsInstance Join(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (target is global::Jint.Native.JsArray)
			{
				return ((global::Jint.Native.JsArray)target).join(base.Global, (parameters.Length > 0) ? parameters[0] : global::Jint.Native.JsUndefined.Instance);
			}
			string value = (parameters.Length == 0 || parameters[0] == global::Jint.Native.JsUndefined.Instance) ? "," : parameters[0].ToString();
			if (target.Length == 0)
			{
				return base.Global.StringClass.New();
			}
			global::Jint.Native.JsInstance jsInstance = target[0.ToString()];
			global::System.Text.StringBuilder stringBuilder;
			if (jsInstance == global::Jint.Native.JsUndefined.Instance || jsInstance == global::Jint.Native.JsNull.Instance)
			{
				stringBuilder = new global::System.Text.StringBuilder(string.Empty);
			}
			else
			{
				stringBuilder = new global::System.Text.StringBuilder(jsInstance.ToString());
			}
			double num = target["length"].ToNumber();
			int num2 = 1;
			while ((double)num2 < num)
			{
				stringBuilder.Append(value);
				global::Jint.Native.JsInstance jsInstance2 = target[num2.ToString()];
				if (jsInstance2 != global::Jint.Native.JsUndefined.Instance && jsInstance2 != global::Jint.Native.JsNull.Instance)
				{
					stringBuilder.Append(jsInstance2.ToString());
				}
				num2++;
			}
			return base.Global.StringClass.New(stringBuilder.ToString());
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x000248C0 File Offset: 0x00022AC0
		public global::Jint.Native.JsInstance Pop(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			uint num = global::System.Convert.ToUInt32(target.Length);
			if (num == 0U)
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			string index = (num - 1U).ToString();
			global::Jint.Native.JsInstance result = target[index];
			target.Delete(index);
			target.Length--;
			return result;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00024914 File Offset: 0x00022B14
		public global::Jint.Native.JsInstance Push(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			int num = (int)target["length"].ToNumber();
			foreach (global::Jint.Native.JsInstance value in parameters)
			{
				target[base.Global.NumberClass.New((double)num)] = value;
				num++;
			}
			return base.Global.NumberClass.New((double)num);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00024984 File Offset: 0x00022B84
		public global::Jint.Native.JsInstance Reverse(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			int length = target.Length;
			int num = length / 2;
			for (int num2 = 0; num2 != num; num2++)
			{
				string index = (length - num2 - 1).ToString();
				string index2 = num2.ToString();
				global::Jint.Native.JsInstance value = null;
				global::Jint.Native.JsInstance value2 = null;
				bool flag = target.TryGetProperty(index2, out value);
				bool flag2 = target.TryGetProperty(index, out value2);
				if (flag)
				{
					target[index] = value;
				}
				else
				{
					target.Delete(index);
				}
				if (flag2)
				{
					target[index2] = value2;
				}
				else
				{
					target.Delete(index2);
				}
			}
			return target;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00024A24 File Offset: 0x00022C24
		public global::Jint.Native.JsInstance Shift(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (target.Length == 0)
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			global::Jint.Native.JsInstance result = target[0.ToString()];
			for (int i = 1; i < target.Length; i++)
			{
				global::Jint.Native.JsInstance value = null;
				string index = i.ToString();
				string index2 = (i - 1).ToString();
				if (target.TryGetProperty(index, out value))
				{
					target[index2] = value;
				}
				else
				{
					target.Delete(index2);
				}
			}
			target.Delete((target.Length - 1).ToString());
			target.Length--;
			return result;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00024AD0 File Offset: 0x00022CD0
		public global::Jint.Native.JsInstance Slice(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			int num = (parameters.Length > 0) ? ((int)parameters[0].ToNumber()) : 0;
			int num2 = (parameters.Length > 1) ? ((int)parameters[1].ToNumber()) : target.Length;
			if (num < 0)
			{
				num += target.Length;
			}
			if (num2 < 0)
			{
				num2 += target.Length;
			}
			if (num > target.Length)
			{
				num = target.Length;
			}
			if (num2 > target.Length)
			{
				num2 = target.Length;
			}
			global::Jint.Native.JsArray jsArray = base.Global.ArrayClass.New();
			for (int i = num; i < num2; i++)
			{
				this.Push(jsArray, new global::Jint.Native.JsInstance[]
				{
					target[base.Global.NumberClass.New((double)i)]
				});
			}
			return jsArray;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00024BBC File Offset: 0x00022DBC
		public global::Jint.Native.JsInstance Sort(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (target.Length <= 1)
			{
				return target;
			}
			global::Jint.Native.JsFunction jsFunction = null;
			if (parameters.Length > 0)
			{
				jsFunction = (parameters[0] as global::Jint.Native.JsFunction);
			}
			global::System.Collections.Generic.List<global::Jint.Native.JsInstance> list = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>();
			int num = (int)target["length"].ToNumber();
			for (int i = 0; i < num; i++)
			{
				list.Add(target[i.ToString()]);
			}
			if (jsFunction != null)
			{
				try
				{
					list.Sort(new global::Jint.Native.JsComparer(base.Global.Visitor, jsFunction));
					goto IL_A5;
				}
				catch (global::System.Exception ex)
				{
					if (ex.InnerException is global::Jint.Native.JsException)
					{
						throw ex.InnerException;
					}
					throw;
				}
			}
			list.Sort();
			IL_A5:
			for (int j = 0; j < num; j++)
			{
				target[j.ToString()] = list[j];
			}
			return target;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00024CA8 File Offset: 0x00022EA8
		public global::Jint.Native.JsInstance Splice(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			global::Jint.Native.JsArray jsArray = base.Global.ArrayClass.New();
			int num = global::System.Convert.ToInt32(parameters[0].ToNumber());
			int num2 = (num < 0) ? global::System.Math.Max(target.Length + num, 0) : global::System.Math.Min(num, target.Length);
			int num3 = global::System.Math.Min(global::System.Math.Max(global::System.Convert.ToInt32(parameters[1].ToNumber()), 0), target.Length - num2);
			int length = target.Length;
			for (int i = 0; i < num3; i++)
			{
				string index = (num + i).ToString();
				global::Jint.Native.JsInstance value = null;
				if (target.TryGetProperty(index, out value))
				{
					jsArray.put(i, value);
				}
			}
			global::System.Collections.Generic.List<global::Jint.Native.JsInstance> list = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>();
			list.AddRange(parameters);
			list.RemoveAt(0);
			list.RemoveAt(0);
			if (list.Count < num3)
			{
				for (int j = num2; j < length - num3; j++)
				{
					global::Jint.Native.JsInstance value2 = null;
					string index2 = (j + num3).ToString();
					string index3 = (j + list.Count).ToString();
					if (target.TryGetProperty(index2, out value2))
					{
						target[index3] = value2;
					}
					else
					{
						target.Delete(index3);
					}
				}
				for (int k = target.Length; k > length - num3 + list.Count; k--)
				{
					target.Delete((k - 1).ToString());
				}
				target.Length = length - num3 + list.Count;
			}
			else
			{
				for (int l = length - num3; l > num2; l--)
				{
					global::Jint.Native.JsInstance value3 = null;
					string index4 = (l + num3 - 1).ToString();
					string index5 = (l + list.Count - 1).ToString();
					if (target.TryGetProperty(index4, out value3))
					{
						target[index5] = value3;
					}
					else
					{
						target.Delete(index5);
					}
				}
			}
			for (int m = 0; m < list.Count; m++)
			{
				target[m.ToString()] = list[m];
			}
			return jsArray;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00024EE4 File Offset: 0x000230E4
		public global::Jint.Native.JsInstance UnShift(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			for (int i = target.Length; i > 0; i--)
			{
				global::Jint.Native.JsInstance value = null;
				string index = (i - 1).ToString();
				string index2 = (i + parameters.Length - 1).ToString();
				if (target.TryGetProperty(index, out value))
				{
					target[index2] = value;
				}
				else
				{
					target.Delete(index2);
				}
			}
			global::System.Collections.Generic.List<global::Jint.Native.JsInstance> list = new global::System.Collections.Generic.List<global::Jint.Native.JsInstance>(parameters);
			int num = 0;
			while (list.Count > 0)
			{
				global::Jint.Native.JsInstance value2 = list[0];
				list.RemoveAt(0);
				target[num.ToString()] = value2;
				num++;
			}
			return base.Global.NumberClass.New((double)target.Length);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00024FA8 File Offset: 0x000231A8
		public global::Jint.Native.JsInstance LastIndexOfImpl(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				return base.Global.NumberClass.New(-1.0);
			}
			int length = target.Length;
			if (length == 0)
			{
				return base.Global.NumberClass.New(-1.0);
			}
			int num = length;
			if (parameters.Length > 1)
			{
				num = global::System.Convert.ToInt32(parameters[1].ToNumber());
			}
			global::Jint.Native.JsInstance jsInstance = parameters[0];
			int i;
			if (num >= 0)
			{
				i = global::System.Math.Min(num, length - 1);
			}
			else
			{
				i = length - global::System.Math.Abs(num - 1);
			}
			while (i >= 0)
			{
				global::Jint.Native.JsInstance jsInstance2 = null;
				if (target.TryGetProperty(i.ToString(), out jsInstance2) && jsInstance2 == jsInstance)
				{
					return base.Global.NumberClass.New((double)i);
				}
				i--;
			}
			return base.Global.NumberClass.New(-1.0);
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x000250A0 File Offset: 0x000232A0
		public global::Jint.Native.JsInstance IndexOfImpl(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				return base.Global.NumberClass.New(-1.0);
			}
			int num = (int)target["length"].ToNumber();
			if (num == 0)
			{
				return base.Global.NumberClass.New(-1.0);
			}
			int num2 = 0;
			if (parameters.Length > 1)
			{
				num2 = global::System.Convert.ToInt32(parameters[1].ToNumber());
			}
			if (num2 >= num)
			{
				return base.Global.NumberClass.New(-1.0);
			}
			global::Jint.Native.JsInstance right = parameters[0];
			int i;
			if (num2 >= 0)
			{
				i = num2;
			}
			else
			{
				i = num - global::System.Math.Abs(num2);
			}
			while (i < num)
			{
				global::Jint.Native.JsInstance left = null;
				if (target.TryGetProperty(i.ToString(), out left) && global::Jint.Native.JsInstance.StrictlyEquals(base.Global, left, right) == base.Global.BooleanClass.True)
				{
					return base.Global.NumberClass.New((double)i);
				}
				i++;
			}
			return base.Global.NumberClass.New(-1.0);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x000251D8 File Offset: 0x000233D8
		public global::Jint.Native.JsInstance ForEach(global::Jint.Native.JsObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length == 0)
			{
				throw new global::Jint.Native.JsException(base.Global.ErrorClass.New("Missing argument 0 when calling " + target + ".forEach"));
			}
			if (parameters[0].Class != "Function")
			{
				throw new global::Jint.Native.JsException(base.Global.ErrorClass.New(target + " is not a function"));
			}
			global::Jint.Native.JsFunction function = (global::Jint.Native.JsFunction)parameters[0];
			global::Jint.Native.JsDictionaryObject this2 = base.Global as global::Jint.Native.JsDictionaryObject;
			if (parameters.Length > 1)
			{
				if (parameters[1] is global::Jint.Native.JsDictionaryObject)
				{
					this2 = (parameters[1] as global::Jint.Native.JsDictionaryObject);
				}
				else if (base.Global.HasOption(global::Jint.Options.Strict) && (parameters[1] is global::Jint.Native.JsUndefined || parameters[1] is global::Jint.Native.JsNull))
				{
					this2 = (parameters[1] as global::Jint.Native.JsDictionaryObject);
				}
			}
			global::Jint.Native.JsArray jsArray = (global::Jint.Native.JsArray)target;
			for (int i = 0; i < jsArray.Length; i++)
			{
				global::Jint.Native.JsNumber jsNumber = base.Global.NumberClass.New((double)i);
				base.Global.Visitor.ExecuteFunction(function, this2, new global::Jint.Native.JsInstance[]
				{
					jsArray[jsNumber],
					jsNumber,
					jsArray
				});
			}
			return global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x0002534C File Offset: 0x0002354C
		private global::Jint.Native.JsInstance GetLengthImpl(global::Jint.Native.JsObject that)
		{
			return base.Global.NumberClass.New((double)that.Length);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00025374 File Offset: 0x00023574
		private global::Jint.Native.JsInstance SetLengthImpl(global::Jint.Native.JsObject that, global::Jint.Native.JsInstance[] parameters)
		{
			if (that is global::Jint.Native.JsArray)
			{
				that.Length = (int)parameters[0].ToNumber();
			}
			else
			{
				int length = that.Length;
				that.Length = (int)parameters[0].ToNumber();
				for (int i = that.Length; i < length; i++)
				{
					that.Delete(base.Global.NumberClass.New((double)i));
				}
			}
			return parameters[0];
		}
	}
}

using System;
using System.Linq;
using System.Reflection;

// Token: 0x02000852 RID: 2130
public class dfObservableProperty : global::IObservableValue
{
	// Token: 0x060049A7 RID: 18855 RVA: 0x0011355C File Offset: 0x0011175C
	internal dfObservableProperty(object target, string memberName)
	{
		global::System.Reflection.MemberInfo memberInfo = target.GetType().GetMember(memberName, global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public).FirstOrDefault<global::System.Reflection.MemberInfo>();
		if (memberInfo == null)
		{
			throw new global::System.ArgumentException("Invalid property or field name: " + memberName, "memberName");
		}
		this.initMember(target, memberInfo);
	}

	// Token: 0x060049A8 RID: 18856 RVA: 0x001135A8 File Offset: 0x001117A8
	internal dfObservableProperty(object target, global::System.Reflection.FieldInfo field)
	{
		this.initField(target, field);
	}

	// Token: 0x060049A9 RID: 18857 RVA: 0x001135B8 File Offset: 0x001117B8
	internal dfObservableProperty(object target, global::System.Reflection.PropertyInfo property)
	{
		this.initProperty(target, property);
	}

	// Token: 0x060049AA RID: 18858 RVA: 0x001135C8 File Offset: 0x001117C8
	internal dfObservableProperty(object target, global::System.Reflection.MemberInfo member)
	{
		this.initMember(target, member);
	}

	// Token: 0x17000DD0 RID: 3536
	// (get) Token: 0x060049AB RID: 18859 RVA: 0x001135D8 File Offset: 0x001117D8
	// (set) Token: 0x060049AC RID: 18860 RVA: 0x001135E0 File Offset: 0x001117E0
	public object Value
	{
		get
		{
			return this.getter();
		}
		set
		{
			this.lastValue = value;
			this.setter(value);
			this.hasChanged = false;
		}
	}

	// Token: 0x17000DD1 RID: 3537
	// (get) Token: 0x060049AD RID: 18861 RVA: 0x001135F8 File Offset: 0x001117F8
	public bool HasChanged
	{
		get
		{
			if (this.hasChanged)
			{
				return true;
			}
			object obj = this.getter();
			if (object.ReferenceEquals(obj, this.lastValue))
			{
				this.hasChanged = false;
			}
			else if (obj == null || this.lastValue == null)
			{
				this.hasChanged = true;
			}
			else
			{
				this.hasChanged = !obj.Equals(this.lastValue);
			}
			return this.hasChanged;
		}
	}

	// Token: 0x060049AE RID: 18862 RVA: 0x00113670 File Offset: 0x00111870
	public void ClearChangedFlag()
	{
		this.hasChanged = false;
		this.lastValue = this.getter();
	}

	// Token: 0x060049AF RID: 18863 RVA: 0x00113688 File Offset: 0x00111888
	private void initMember(object target, global::System.Reflection.MemberInfo member)
	{
		if (member is global::System.Reflection.FieldInfo)
		{
			this.initField(target, (global::System.Reflection.FieldInfo)member);
		}
		else
		{
			this.initProperty(target, (global::System.Reflection.PropertyInfo)member);
		}
	}

	// Token: 0x060049B0 RID: 18864 RVA: 0x001136C0 File Offset: 0x001118C0
	private void initField(object target, global::System.Reflection.FieldInfo field)
	{
		this.target = target;
		this.fieldInfo = field;
		this.Value = this.getter();
	}

	// Token: 0x060049B1 RID: 18865 RVA: 0x001136DC File Offset: 0x001118DC
	private void initProperty(object target, global::System.Reflection.PropertyInfo property)
	{
		this.target = target;
		this.propertyInfo = property;
		this.Value = this.getter();
	}

	// Token: 0x060049B2 RID: 18866 RVA: 0x001136F8 File Offset: 0x001118F8
	private object getter()
	{
		if (this.propertyInfo != null)
		{
			return this.getPropertyValue();
		}
		return this.getFieldValue();
	}

	// Token: 0x060049B3 RID: 18867 RVA: 0x00113714 File Offset: 0x00111914
	private void setter(object value)
	{
		if (this.propertyInfo != null)
		{
			this.setPropertyValue(value);
		}
		else
		{
			this.setFieldValue(value);
		}
	}

	// Token: 0x060049B4 RID: 18868 RVA: 0x00113734 File Offset: 0x00111934
	private object getPropertyValue()
	{
		if (this.propertyGetter == null)
		{
			this.propertyGetter = this.propertyInfo.GetGetMethod();
			if (this.propertyGetter == null)
			{
				throw new global::System.InvalidOperationException("Cannot read property: " + this.propertyInfo);
			}
		}
		return this.propertyGetter.Invoke(this.target, null);
	}

	// Token: 0x060049B5 RID: 18869 RVA: 0x00113790 File Offset: 0x00111990
	private void setPropertyValue(object value)
	{
		global::System.Reflection.MethodInfo setMethod = this.propertyInfo.GetSetMethod();
		if (!this.propertyInfo.CanWrite || setMethod == null)
		{
			return;
		}
		global::System.Type propertyType = this.propertyInfo.PropertyType;
		if (value == null || propertyType.IsAssignableFrom(value.GetType()))
		{
			this.propertyInfo.SetValue(this.target, value, null);
		}
		else
		{
			object value2 = global::System.Convert.ChangeType(value, propertyType);
			this.propertyInfo.SetValue(this.target, value2, null);
		}
	}

	// Token: 0x060049B6 RID: 18870 RVA: 0x00113818 File Offset: 0x00111A18
	private void setFieldValue(object value)
	{
		if (this.fieldInfo.IsLiteral)
		{
			return;
		}
		global::System.Type fieldType = this.fieldInfo.FieldType;
		if (value == null || fieldType.IsAssignableFrom(value.GetType()))
		{
			this.fieldInfo.SetValue(this.target, value);
		}
		else
		{
			object value2 = global::System.Convert.ChangeType(value, fieldType);
			this.fieldInfo.SetValue(this.target, value2);
		}
	}

	// Token: 0x060049B7 RID: 18871 RVA: 0x0011388C File Offset: 0x00111A8C
	private void setFieldValueNOP(object value)
	{
	}

	// Token: 0x060049B8 RID: 18872 RVA: 0x00113890 File Offset: 0x00111A90
	private object getFieldValue()
	{
		return this.fieldInfo.GetValue(this.target);
	}

	// Token: 0x04002733 RID: 10035
	private object lastValue;

	// Token: 0x04002734 RID: 10036
	private bool hasChanged;

	// Token: 0x04002735 RID: 10037
	private object target;

	// Token: 0x04002736 RID: 10038
	private global::System.Reflection.FieldInfo fieldInfo;

	// Token: 0x04002737 RID: 10039
	private global::System.Reflection.PropertyInfo propertyInfo;

	// Token: 0x04002738 RID: 10040
	private global::System.Reflection.MethodInfo propertyGetter;

	// Token: 0x02000853 RID: 2131
	// (Invoke) Token: 0x060049BA RID: 18874
	private delegate object ValueGetter();

	// Token: 0x02000854 RID: 2132
	// (Invoke) Token: 0x060049BE RID: 18878
	private delegate void ValueSetter(object value);
}

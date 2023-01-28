using System;

namespace Jint
{
	// Token: 0x02000088 RID: 136
	public class Number
	{
		// Token: 0x06000605 RID: 1541 RVA: 0x00029380 File Offset: 0x00027580
		public static object Add(object a, object b)
		{
			global::System.TypeCode typeCode = global::System.Type.GetTypeCode(a.GetType());
			global::System.TypeCode typeCode2 = global::System.Type.GetTypeCode(b.GetType());
			switch (typeCode)
			{
			case global::System.TypeCode.SByte:
				switch (typeCode2)
				{
				case global::System.TypeCode.SByte:
					return (int)((sbyte)a + (sbyte)b);
				case global::System.TypeCode.Int16:
					return (int)((short)((sbyte)a) + (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((ushort)((sbyte)a) + (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((sbyte)a) + (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((sbyte)a) + (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((sbyte)a) + (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '+' can't be applied to operands of types 'sbyte' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((sbyte)a) + (float)b;
				case global::System.TypeCode.Double:
					return (double)((sbyte)a) + (double)b;
				case global::System.TypeCode.Decimal:
					return (sbyte)a + (decimal)b;
				}
				break;
			case global::System.TypeCode.Byte:
				switch (typeCode2)
				{
				case global::System.TypeCode.SByte:
					return (int)((byte)a + (byte)((sbyte)b));
				case global::System.TypeCode.Int16:
					return (int)((short)((byte)a) + (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((ushort)((byte)a) + (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((byte)a) + (int)b;
				case global::System.TypeCode.UInt32:
					return (uint)((byte)a) + (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((byte)a) + (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((byte)a) + (ulong)b;
				case global::System.TypeCode.Single:
					return (float)((byte)a) + (float)b;
				case global::System.TypeCode.Double:
					return (double)((byte)a) + (double)b;
				case global::System.TypeCode.Decimal:
					return (byte)a + (decimal)b;
				}
				break;
			case global::System.TypeCode.Int16:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int16:
					return (int)((short)a + (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((short)a + (short)((ushort)b));
				case global::System.TypeCode.Int32:
					return (int)((short)a) + (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((short)a) + (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((short)a) + (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '+' can't be applied to operands of types 'short' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((short)a) + (float)b;
				case global::System.TypeCode.Double:
					return (double)((short)a) + (double)b;
				case global::System.TypeCode.Decimal:
					return (short)a + (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt16:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt16:
					return (int)((ushort)a + (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((ushort)a) + (int)b;
				case global::System.TypeCode.UInt32:
					return (uint)((ushort)a) + (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((ushort)a) + (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((ushort)a) + (ulong)b;
				case global::System.TypeCode.Single:
					return (float)((ushort)a) + (float)b;
				case global::System.TypeCode.Double:
					return (double)((ushort)a) + (double)b;
				case global::System.TypeCode.Decimal:
					return (ushort)a + (decimal)b;
				}
				break;
			case global::System.TypeCode.Int32:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int32:
					return (int)a + (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((int)a) + (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((int)a) + (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '+' can't be applied to operands of types 'int' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((int)a) + (float)b;
				case global::System.TypeCode.Double:
					return (double)((int)a) + (double)b;
				case global::System.TypeCode.Decimal:
					return (int)a + (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt32:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt32:
					return (uint)a + (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((uint)a) + (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((uint)a) + (ulong)b;
				case global::System.TypeCode.Single:
					return (uint)a + (float)b;
				case global::System.TypeCode.Double:
					return (uint)a + (double)b;
				case global::System.TypeCode.Decimal:
					return (uint)a + (decimal)b;
				}
				break;
			case global::System.TypeCode.Int64:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int64:
					return (long)a + (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '+' can't be applied to operands of types 'long' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((long)a) + (float)b;
				case global::System.TypeCode.Double:
					return (double)((long)a) + (double)b;
				case global::System.TypeCode.Decimal:
					return (long)a + (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt64:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					return (ulong)a + (ulong)b;
				case global::System.TypeCode.Single:
					return (ulong)a + (float)b;
				case global::System.TypeCode.Double:
					return (ulong)a + (double)b;
				case global::System.TypeCode.Decimal:
					return (ulong)a + (decimal)b;
				}
				break;
			case global::System.TypeCode.Single:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '+' can't be applied to operands of types 'float' and 'decimal'");
				case global::System.TypeCode.Single:
					return (float)a + (float)b;
				case global::System.TypeCode.Double:
					return (double)((float)a) + (double)b;
				}
				break;
			case global::System.TypeCode.Double:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '+' can't be applied to operands of types 'double' and 'decimal'");
				case global::System.TypeCode.Double:
					return (double)a + (double)b;
				}
				break;
			case global::System.TypeCode.Decimal:
			{
				global::System.TypeCode typeCode3 = typeCode2;
				if (typeCode3 == global::System.TypeCode.Decimal)
				{
					return (decimal)a + (decimal)b;
				}
				break;
			}
			}
			return null;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00029AC0 File Offset: 0x00027CC0
		public static object Soustract(object a, object b)
		{
			global::System.TypeCode typeCode = global::System.Type.GetTypeCode(a.GetType());
			global::System.TypeCode typeCode2 = global::System.Type.GetTypeCode(b.GetType());
			switch (typeCode)
			{
			case global::System.TypeCode.SByte:
				switch (typeCode2)
				{
				case global::System.TypeCode.SByte:
					return (int)((sbyte)a - (sbyte)b);
				case global::System.TypeCode.Int16:
					return (int)((short)((sbyte)a) - (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((ushort)((sbyte)a) - (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((sbyte)a) - (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((sbyte)a) - (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((sbyte)a) - (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '-' can't be applied to operands of types 'sbyte' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((sbyte)a) - (float)b;
				case global::System.TypeCode.Double:
					return (double)((sbyte)a) - (double)b;
				case global::System.TypeCode.Decimal:
					return (sbyte)a - (decimal)b;
				}
				break;
			case global::System.TypeCode.Byte:
				switch (typeCode2)
				{
				case global::System.TypeCode.SByte:
					return (int)((byte)a - (byte)((sbyte)b));
				case global::System.TypeCode.Int16:
					return (int)((short)((byte)a) - (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((ushort)((byte)a) - (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((byte)a) - (int)b;
				case global::System.TypeCode.UInt32:
					return (uint)((byte)a) - (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((byte)a) - (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((byte)a) - (ulong)b;
				case global::System.TypeCode.Single:
					return (float)((byte)a) - (float)b;
				case global::System.TypeCode.Double:
					return (double)((byte)a) - (double)b;
				case global::System.TypeCode.Decimal:
					return (byte)a - (decimal)b;
				}
				break;
			case global::System.TypeCode.Int16:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int16:
					return (int)((short)a - (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((short)a - (short)((ushort)b));
				case global::System.TypeCode.Int32:
					return (int)((short)a) - (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((short)a) - (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((short)a) - (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '-' can't be applied to operands of types 'short' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((short)a) - (float)b;
				case global::System.TypeCode.Double:
					return (double)((short)a) - (double)b;
				case global::System.TypeCode.Decimal:
					return (short)a - (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt16:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt16:
					return (int)((ushort)a - (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((ushort)a) - (int)b;
				case global::System.TypeCode.UInt32:
					return (uint)((ushort)a) - (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((ushort)a) - (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((ushort)a) - (ulong)b;
				case global::System.TypeCode.Single:
					return (float)((ushort)a) - (float)b;
				case global::System.TypeCode.Double:
					return (double)((ushort)a) - (double)b;
				case global::System.TypeCode.Decimal:
					return (ushort)a - (decimal)b;
				}
				break;
			case global::System.TypeCode.Int32:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int32:
					return (int)a - (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((int)a) - (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((int)a) - (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '-' can't be applied to operands of types 'int' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((int)a) - (float)b;
				case global::System.TypeCode.Double:
					return (double)((int)a) - (double)b;
				case global::System.TypeCode.Decimal:
					return (int)a - (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt32:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt32:
					return (uint)a - (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((uint)a) - (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((uint)a) - (ulong)b;
				case global::System.TypeCode.Single:
					return (uint)a - (float)b;
				case global::System.TypeCode.Double:
					return (uint)a - (double)b;
				case global::System.TypeCode.Decimal:
					return (uint)a - (decimal)b;
				}
				break;
			case global::System.TypeCode.Int64:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int64:
					return (long)a - (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '-' can't be applied to operands of types 'long' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((long)a) - (float)b;
				case global::System.TypeCode.Double:
					return (double)((long)a) - (double)b;
				case global::System.TypeCode.Decimal:
					return (long)a - (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt64:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					return (ulong)a - (ulong)b;
				case global::System.TypeCode.Single:
					return (ulong)a - (float)b;
				case global::System.TypeCode.Double:
					return (ulong)a - (double)b;
				case global::System.TypeCode.Decimal:
					return (ulong)a - (decimal)b;
				}
				break;
			case global::System.TypeCode.Single:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '-' can't be applied to operands of types 'float' and 'decimal'");
				case global::System.TypeCode.Single:
					return (float)a - (float)b;
				case global::System.TypeCode.Double:
					return (double)((float)a) - (double)b;
				}
				break;
			case global::System.TypeCode.Double:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '-' can't be applied to operands of types 'double' and 'decimal'");
				case global::System.TypeCode.Double:
					return (double)a - (double)b;
				}
				break;
			case global::System.TypeCode.Decimal:
			{
				global::System.TypeCode typeCode3 = typeCode2;
				if (typeCode3 == global::System.TypeCode.Decimal)
				{
					return (byte)a - (decimal)b;
				}
				break;
			}
			}
			return null;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0002A204 File Offset: 0x00028404
		public static object Multiply(object a, object b)
		{
			global::System.TypeCode typeCode = global::System.Type.GetTypeCode(a.GetType());
			global::System.TypeCode typeCode2 = global::System.Type.GetTypeCode(b.GetType());
			switch (typeCode)
			{
			case global::System.TypeCode.SByte:
				switch (typeCode2)
				{
				case global::System.TypeCode.SByte:
					return (int)((sbyte)a * (sbyte)b);
				case global::System.TypeCode.Int16:
					return (int)((short)((sbyte)a) * (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((ushort)((sbyte)a) * (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((sbyte)a) * (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((sbyte)a) * (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((sbyte)a) * (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '*' can't be applied to operands of types 'sbyte' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((sbyte)a) * (float)b;
				case global::System.TypeCode.Double:
					return (double)((sbyte)a) * (double)b;
				case global::System.TypeCode.Decimal:
					return (sbyte)a * (decimal)b;
				}
				break;
			case global::System.TypeCode.Byte:
				switch (typeCode2)
				{
				case global::System.TypeCode.SByte:
					return (int)((byte)a * (byte)((sbyte)b));
				case global::System.TypeCode.Int16:
					return (int)((short)((byte)a) * (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((ushort)((byte)a) * (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((byte)a) * (int)b;
				case global::System.TypeCode.UInt32:
					return (uint)((byte)a) * (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((byte)a) * (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((byte)a) * (ulong)b;
				case global::System.TypeCode.Single:
					return (float)((byte)a) * (float)b;
				case global::System.TypeCode.Double:
					return (double)((byte)a) * (double)b;
				case global::System.TypeCode.Decimal:
					return (byte)a * (decimal)b;
				}
				break;
			case global::System.TypeCode.Int16:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int16:
					return (int)((short)a * (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((short)a * (short)((ushort)b));
				case global::System.TypeCode.Int32:
					return (int)((short)a) * (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((short)a) * (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((short)a) * (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '*' can't be applied to operands of types 'short' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((short)a) * (float)b;
				case global::System.TypeCode.Double:
					return (double)((short)a) * (double)b;
				case global::System.TypeCode.Decimal:
					return (short)a * (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt16:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt16:
					return (int)((ushort)a * (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((ushort)a) * (int)b;
				case global::System.TypeCode.UInt32:
					return (uint)((ushort)a) * (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((ushort)a) * (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((ushort)a) * (ulong)b;
				case global::System.TypeCode.Single:
					return (float)((ushort)a) * (float)b;
				case global::System.TypeCode.Double:
					return (double)((ushort)a) * (double)b;
				case global::System.TypeCode.Decimal:
					return (ushort)a * (decimal)b;
				}
				break;
			case global::System.TypeCode.Int32:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int32:
					return (int)a * (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((int)a) * (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((int)a) * (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '*' can't be applied to operands of types 'int' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((int)a) * (float)b;
				case global::System.TypeCode.Double:
					return (double)((int)a) * (double)b;
				case global::System.TypeCode.Decimal:
					return (int)a * (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt32:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt32:
					return (uint)a * (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((uint)a) * (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((uint)a) * (ulong)b;
				case global::System.TypeCode.Single:
					return (uint)a * (float)b;
				case global::System.TypeCode.Double:
					return (uint)a * (double)b;
				case global::System.TypeCode.Decimal:
					return (uint)a * (decimal)b;
				}
				break;
			case global::System.TypeCode.Int64:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int64:
					return (long)a * (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '*' can't be applied to operands of types 'long' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((long)a) * (float)b;
				case global::System.TypeCode.Double:
					return (double)((long)a) * (double)b;
				case global::System.TypeCode.Decimal:
					return (long)a * (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt64:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					return (ulong)a * (ulong)b;
				case global::System.TypeCode.Single:
					return (ulong)a * (float)b;
				case global::System.TypeCode.Double:
					return (ulong)a * (double)b;
				case global::System.TypeCode.Decimal:
					return (ulong)a * (decimal)b;
				}
				break;
			case global::System.TypeCode.Single:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '*' can't be applied to operands of types 'float' and 'decimal'");
				case global::System.TypeCode.Single:
					return (float)a * (float)b;
				case global::System.TypeCode.Double:
					return (double)((float)a) * (double)b;
				}
				break;
			case global::System.TypeCode.Double:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '*' can't be applied to operands of types 'double' and 'decimal'");
				case global::System.TypeCode.Double:
					return (double)a * (double)b;
				}
				break;
			case global::System.TypeCode.Decimal:
			{
				global::System.TypeCode typeCode3 = typeCode2;
				if (typeCode3 == global::System.TypeCode.Decimal)
				{
					return (byte)a * (decimal)b;
				}
				break;
			}
			}
			return null;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0002A948 File Offset: 0x00028B48
		public static object Divide(object a, object b)
		{
			global::System.TypeCode typeCode = global::System.Type.GetTypeCode(a.GetType());
			global::System.TypeCode typeCode2 = global::System.Type.GetTypeCode(b.GetType());
			switch (typeCode)
			{
			case global::System.TypeCode.SByte:
				switch (typeCode2)
				{
				case global::System.TypeCode.SByte:
					return (int)((sbyte)a / (sbyte)b);
				case global::System.TypeCode.Int16:
					return (int)((short)((sbyte)a) / (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((ushort)((sbyte)a) / (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((sbyte)a) / (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((sbyte)a) / (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((sbyte)a) / (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '/' can't be applied to operands of types 'sbyte' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((sbyte)a) / (float)b;
				case global::System.TypeCode.Double:
					return (double)((sbyte)a) / (double)b;
				case global::System.TypeCode.Decimal:
					return (sbyte)a / (decimal)b;
				}
				break;
			case global::System.TypeCode.Byte:
				switch (typeCode2)
				{
				case global::System.TypeCode.SByte:
					return (int)((byte)a / (byte)((sbyte)b));
				case global::System.TypeCode.Int16:
					return (int)((short)((byte)a) / (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((ushort)((byte)a) / (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((byte)a) / (int)b;
				case global::System.TypeCode.UInt32:
					return (uint)((byte)a) / (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((byte)a) / (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((byte)a) / (ulong)b;
				case global::System.TypeCode.Single:
					return (float)((byte)a) / (float)b;
				case global::System.TypeCode.Double:
					return (double)((byte)a) / (double)b;
				case global::System.TypeCode.Decimal:
					return (byte)a / (decimal)b;
				}
				break;
			case global::System.TypeCode.Int16:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int16:
					return (int)((short)a / (short)b);
				case global::System.TypeCode.UInt16:
					return (int)((short)a / (short)((ushort)b));
				case global::System.TypeCode.Int32:
					return (int)((short)a) / (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((short)a) / (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((short)a) / (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '/' can't be applied to operands of types 'short' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((short)a) / (float)b;
				case global::System.TypeCode.Double:
					return (double)((short)a) / (double)b;
				case global::System.TypeCode.Decimal:
					return (short)a / (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt16:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt16:
					return (int)((ushort)a / (ushort)b);
				case global::System.TypeCode.Int32:
					return (int)((ushort)a) / (int)b;
				case global::System.TypeCode.UInt32:
					return (uint)((ushort)a) / (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((ushort)a) / (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((ushort)a) / (ulong)b;
				case global::System.TypeCode.Single:
					return (float)((ushort)a) / (float)b;
				case global::System.TypeCode.Double:
					return (double)((ushort)a) / (double)b;
				case global::System.TypeCode.Decimal:
					return (ushort)a / (decimal)b;
				}
				break;
			case global::System.TypeCode.Int32:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int32:
					return (int)a / (int)b;
				case global::System.TypeCode.UInt32:
					return (long)((int)a) / (long)((ulong)((uint)b));
				case global::System.TypeCode.Int64:
					return (long)((int)a) / (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '/' can't be applied to operands of types 'int' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((int)a) / (float)b;
				case global::System.TypeCode.Double:
					return (double)((int)a) / (double)b;
				case global::System.TypeCode.Decimal:
					return (int)a / (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt32:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt32:
					return (uint)a / (uint)b;
				case global::System.TypeCode.Int64:
					return (long)((ulong)((uint)a) / (ulong)((long)b));
				case global::System.TypeCode.UInt64:
					return (ulong)((uint)a) / (ulong)b;
				case global::System.TypeCode.Single:
					return (uint)a / (float)b;
				case global::System.TypeCode.Double:
					return (uint)a / (double)b;
				case global::System.TypeCode.Decimal:
					return (uint)a / (decimal)b;
				}
				break;
			case global::System.TypeCode.Int64:
				switch (typeCode2)
				{
				case global::System.TypeCode.Int64:
					return (long)a / (long)b;
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '/' can't be applied to operands of types 'long' and 'ulong'");
				case global::System.TypeCode.Single:
					return (float)((long)a) / (float)b;
				case global::System.TypeCode.Double:
					return (double)((long)a) / (double)b;
				case global::System.TypeCode.Decimal:
					return (long)a / (decimal)b;
				}
				break;
			case global::System.TypeCode.UInt64:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					return (ulong)a / (ulong)b;
				case global::System.TypeCode.Single:
					return (ulong)a / (float)b;
				case global::System.TypeCode.Double:
					return (ulong)a / (double)b;
				case global::System.TypeCode.Decimal:
					return (ulong)a / (decimal)b;
				}
				break;
			case global::System.TypeCode.Single:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '/' can't be applied to operands of types 'float' and 'decimal'");
				case global::System.TypeCode.Single:
					return (float)a / (float)b;
				case global::System.TypeCode.Double:
					return (double)((float)a) / (double)b;
				}
				break;
			case global::System.TypeCode.Double:
				switch (typeCode2)
				{
				case global::System.TypeCode.UInt64:
					throw new global::System.InvalidOperationException("Operator '/' can't be applied to operands of types 'double' and 'decimal'");
				case global::System.TypeCode.Double:
					return (double)a / (double)b;
				}
				break;
			case global::System.TypeCode.Decimal:
			{
				global::System.TypeCode typeCode3 = typeCode2;
				if (typeCode3 == global::System.TypeCode.Decimal)
				{
					return (byte)a / (decimal)b;
				}
				break;
			}
			}
			return null;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0002B08C File Offset: 0x0002928C
		public static object Max(object a, object b)
		{
			if (a == null && b == null)
			{
				return null;
			}
			if (a == null)
			{
				return b;
			}
			if (b == null)
			{
				return a;
			}
			global::System.TypeCode typeCode = global::System.Type.GetTypeCode(a.GetType());
			global::System.Type.GetTypeCode(b.GetType());
			switch (typeCode)
			{
			case global::System.TypeCode.SByte:
				return global::System.Math.Max((sbyte)a, global::System.Convert.ToSByte(b));
			case global::System.TypeCode.Byte:
				return global::System.Math.Max((byte)a, global::System.Convert.ToByte(b));
			case global::System.TypeCode.Int16:
				return global::System.Math.Max((short)a, global::System.Convert.ToInt16(b));
			case global::System.TypeCode.UInt16:
				return global::System.Math.Max((ushort)a, global::System.Convert.ToUInt16(b));
			case global::System.TypeCode.Int32:
				return global::System.Math.Max((int)a, global::System.Convert.ToInt32(b));
			case global::System.TypeCode.UInt32:
				return global::System.Math.Max((uint)a, global::System.Convert.ToUInt32(b));
			case global::System.TypeCode.Int64:
				return global::System.Math.Max((long)a, global::System.Convert.ToInt64(b));
			case global::System.TypeCode.UInt64:
				return global::System.Math.Max((ulong)a, global::System.Convert.ToUInt64(b));
			case global::System.TypeCode.Single:
				return global::System.Math.Max((float)a, global::System.Convert.ToSingle(b));
			case global::System.TypeCode.Double:
				return global::System.Math.Max((double)a, global::System.Convert.ToDouble(b));
			case global::System.TypeCode.Decimal:
				return global::System.Math.Max((decimal)a, global::System.Convert.ToDecimal(b));
			default:
				return null;
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0002B20C File Offset: 0x0002940C
		public static object Min(object a, object b)
		{
			if (a == null && b == null)
			{
				return null;
			}
			if (a == null)
			{
				return b;
			}
			if (b == null)
			{
				return a;
			}
			global::System.TypeCode typeCode = global::System.Type.GetTypeCode(a.GetType());
			global::System.Type.GetTypeCode(b.GetType());
			switch (typeCode)
			{
			case global::System.TypeCode.SByte:
				return global::System.Math.Min((sbyte)a, global::System.Convert.ToSByte(b));
			case global::System.TypeCode.Byte:
				return global::System.Math.Min((byte)a, global::System.Convert.ToByte(b));
			case global::System.TypeCode.Int16:
				return global::System.Math.Min((short)a, global::System.Convert.ToInt16(b));
			case global::System.TypeCode.UInt16:
				return global::System.Math.Min((ushort)a, global::System.Convert.ToUInt16(b));
			case global::System.TypeCode.Int32:
				return global::System.Math.Min((int)a, global::System.Convert.ToInt32(b));
			case global::System.TypeCode.UInt32:
				return global::System.Math.Min((uint)a, global::System.Convert.ToUInt32(b));
			case global::System.TypeCode.Int64:
				return global::System.Math.Min((long)a, global::System.Convert.ToInt64(b));
			case global::System.TypeCode.UInt64:
				return global::System.Math.Min((ulong)a, global::System.Convert.ToUInt64(b));
			case global::System.TypeCode.Single:
				return global::System.Math.Min((float)a, global::System.Convert.ToSingle(b));
			case global::System.TypeCode.Double:
				return global::System.Math.Min((double)a, global::System.Convert.ToDouble(b));
			case global::System.TypeCode.Decimal:
				return global::System.Math.Min((decimal)a, global::System.Convert.ToDecimal(b));
			default:
				return null;
			}
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0002B38C File Offset: 0x0002958C
		public Number()
		{
		}
	}
}

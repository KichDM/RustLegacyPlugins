using System;
using System.Runtime.CompilerServices;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000087 RID: 135
	public sealed class MethodDefinition : global::Mono.Cecil.MethodReference, global::Mono.Cecil.IMemberDefinition, global::Mono.Cecil.ICustomAttributeProvider, global::Mono.Cecil.ISecurityDeclarationProvider, global::Mono.Cecil.IMetadataTokenProvider
	{
		// Token: 0x0600057A RID: 1402 RVA: 0x0000DBAC File Offset: 0x0000BDAC
		public override void Accept(global::Mono.Cecil.IReflectionVisitor visitor)
		{
			visitor.VisitMethodDefinition(this);
			visitor.VisitGenericParameterCollection(this.GenericParameters);
			visitor.VisitParameterDefinitionCollection(this.Parameters);
			if (this.PInvokeInfo != null)
			{
				this.PInvokeInfo.Accept(visitor);
			}
			visitor.VisitSecurityDeclarationCollection(this.SecurityDeclarations);
			visitor.VisitOverrideCollection(this.Overrides);
			visitor.VisitCustomAttributeCollection(this.CustomAttributes);
		}

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0000DC10 File Offset: 0x0000BE10
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x0000DC18 File Offset: 0x0000BE18
		public global::Mono.Cecil.MethodAttributes Attributes
		{
			get
			{
				return (global::Mono.Cecil.MethodAttributes)this.attributes;
			}
			set
			{
				this.attributes = (ushort)value;
			}
		}

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0000DC21 File Offset: 0x0000BE21
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x0000DC29 File Offset: 0x0000BE29
		public global::Mono.Cecil.MethodImplAttributes ImplAttributes
		{
			get
			{
				return (global::Mono.Cecil.MethodImplAttributes)this.impl_attributes;
			}
			set
			{
				this.impl_attributes = (ushort)value;
			}
		}

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0000DC34 File Offset: 0x0000BE34
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x0000DC8B File Offset: 0x0000BE8B
		public global::Mono.Cecil.MethodSemanticsAttributes SemanticsAttributes
		{
			get
			{
				if (this.sem_attrs != null)
				{
					return this.sem_attrs.Value;
				}
				if (base.HasImage)
				{
					this.ReadSemantics();
					return this.sem_attrs.Value;
				}
				this.sem_attrs = new global::Mono.Cecil.MethodSemanticsAttributes?(global::Mono.Cecil.MethodSemanticsAttributes.None);
				return this.sem_attrs.Value;
			}
			set
			{
				this.sem_attrs = new global::Mono.Cecil.MethodSemanticsAttributes?(value);
			}
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0000DCA4 File Offset: 0x0000BEA4
		internal void ReadSemantics()
		{
			if (this.sem_attrs != null)
			{
				return;
			}
			global::Mono.Cecil.ModuleDefinition module = this.Module;
			if (module == null)
			{
				return;
			}
			if (!module.HasImage)
			{
				return;
			}
			module.Read<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.MethodSemanticsAttributes>(this, (global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader) => reader.ReadAllSemantics(method));
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x0000DCF8 File Offset: 0x0000BEF8
		public bool HasSecurityDeclarations
		{
			get
			{
				if (this.security_declarations != null)
				{
					return this.security_declarations.Count > 0;
				}
				return this.GetHasSecurityDeclarations(this.Module);
			}
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x0000DD20 File Offset: 0x0000BF20
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> SecurityDeclarations
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> result;
				if ((result = this.security_declarations) == null)
				{
					result = (this.security_declarations = this.GetSecurityDeclarations(this.Module));
				}
				return result;
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x0000DD4C File Offset: 0x0000BF4C
		public bool HasCustomAttributes
		{
			get
			{
				if (this.custom_attributes != null)
				{
					return this.custom_attributes.Count > 0;
				}
				return this.GetHasCustomAttributes(this.Module);
			}
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0000DD74 File Offset: 0x0000BF74
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> CustomAttributes
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> result;
				if ((result = this.custom_attributes) == null)
				{
					result = (this.custom_attributes = this.GetCustomAttributes(this.Module));
				}
				return result;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x0000DDA0 File Offset: 0x0000BFA0
		public int RVA
		{
			get
			{
				return (int)this.rva;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0000DDA8 File Offset: 0x0000BFA8
		public bool HasBody
		{
			get
			{
				return (this.attributes & 0x400) == 0 && (this.attributes & 0x2000) == 0 && (this.impl_attributes & 0x1000) == 0 && (this.impl_attributes & 1) == 0 && (this.impl_attributes & 4) == 0 && (this.impl_attributes & 3) == 0;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x0000DE0C File Offset: 0x0000C00C
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x0000DE84 File Offset: 0x0000C084
		public global::Mono.Cecil.Cil.MethodBody Body
		{
			get
			{
				if (this.body != null)
				{
					return this.body;
				}
				if (!this.HasBody)
				{
					return null;
				}
				if (base.HasImage && this.rva != 0U)
				{
					return this.body = this.Module.Read<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.Cil.MethodBody>(this, (global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader) => reader.ReadMethodBody(method));
				}
				return this.body = new global::Mono.Cecil.Cil.MethodBody(this);
			}
			set
			{
				this.body = value;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x0000DE8D File Offset: 0x0000C08D
		public bool HasPInvokeInfo
		{
			get
			{
				return this.pinvoke != null || this.IsPInvokeImpl;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0000DEA8 File Offset: 0x0000C0A8
		// (set) Token: 0x0600058C RID: 1420 RVA: 0x0000DF08 File Offset: 0x0000C108
		public global::Mono.Cecil.PInvokeInfo PInvokeInfo
		{
			get
			{
				if (this.pinvoke != null)
				{
					return this.pinvoke;
				}
				if (base.HasImage && this.IsPInvokeImpl)
				{
					return this.pinvoke = this.Module.Read<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.PInvokeInfo>(this, (global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader) => reader.ReadPInvokeInfo(method));
				}
				return null;
			}
			set
			{
				this.IsPInvokeImpl = true;
				this.pinvoke = value;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0000DF24 File Offset: 0x0000C124
		public bool HasOverrides
		{
			get
			{
				if (this.overrides != null)
				{
					return this.overrides.Count > 0;
				}
				if (base.HasImage)
				{
					return this.Module.Read<global::Mono.Cecil.MethodDefinition, bool>(this, (global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader) => reader.HasOverrides(method));
				}
				return false;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x0000DF84 File Offset: 0x0000C184
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference> Overrides
		{
			get
			{
				if (this.overrides != null)
				{
					return this.overrides;
				}
				if (base.HasImage)
				{
					return this.overrides = this.Module.Read<global::Mono.Cecil.MethodDefinition, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference>>(this, (global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader) => reader.ReadOverrides(method));
				}
				return this.overrides = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference>();
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0000DFE9 File Offset: 0x0000C1E9
		public override bool HasGenericParameters
		{
			get
			{
				if (this.generic_parameters != null)
				{
					return this.generic_parameters.Count > 0;
				}
				return this.GetHasGenericParameters(this.Module);
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0000E010 File Offset: 0x0000C210
		public override global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> GenericParameters
		{
			get
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> result;
				if ((result = this.generic_parameters) == null)
				{
					result = (this.generic_parameters = this.GetGenericParameters(this.Module));
				}
				return result;
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x0000E03C File Offset: 0x0000C23C
		// (set) Token: 0x06000592 RID: 1426 RVA: 0x0000E04B File Offset: 0x0000C24B
		public bool IsCompilerControlled
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 0U, value);
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0000E061 File Offset: 0x0000C261
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x0000E070 File Offset: 0x0000C270
		public bool IsPrivate
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 1U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 1U, value);
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0000E086 File Offset: 0x0000C286
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x0000E095 File Offset: 0x0000C295
		public bool IsFamilyAndAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 2U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 2U, value);
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x0000E0AB File Offset: 0x0000C2AB
		// (set) Token: 0x06000598 RID: 1432 RVA: 0x0000E0BA File Offset: 0x0000C2BA
		public bool IsAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 3U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 3U, value);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x0000E0D0 File Offset: 0x0000C2D0
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x0000E0DF File Offset: 0x0000C2DF
		public bool IsFamily
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 4U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 4U, value);
			}
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x0000E0F5 File Offset: 0x0000C2F5
		// (set) Token: 0x0600059C RID: 1436 RVA: 0x0000E104 File Offset: 0x0000C304
		public bool IsFamilyOrAssembly
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 5U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 5U, value);
			}
		}

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0000E11A File Offset: 0x0000C31A
		// (set) Token: 0x0600059E RID: 1438 RVA: 0x0000E129 File Offset: 0x0000C329
		public bool IsPublic
		{
			get
			{
				return this.attributes.GetMaskedAttributes(7, 6U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(7, 6U, value);
			}
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0000E13F File Offset: 0x0000C33F
		// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0000E14E File Offset: 0x0000C34E
		public bool IsStatic
		{
			get
			{
				return this.attributes.GetAttributes(0x10);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x10, value);
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0000E164 File Offset: 0x0000C364
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0000E173 File Offset: 0x0000C373
		public bool IsFinal
		{
			get
			{
				return this.attributes.GetAttributes(0x20);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x20, value);
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0000E189 File Offset: 0x0000C389
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0000E198 File Offset: 0x0000C398
		public bool IsVirtual
		{
			get
			{
				return this.attributes.GetAttributes(0x40);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x40, value);
			}
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0000E1AE File Offset: 0x0000C3AE
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x0000E1C0 File Offset: 0x0000C3C0
		public bool IsHideBySig
		{
			get
			{
				return this.attributes.GetAttributes(0x80);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x80, value);
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0000E1D9 File Offset: 0x0000C3D9
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0000E1EC File Offset: 0x0000C3EC
		public bool IsReuseSlot
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x100, 0U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x100, 0U, value);
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0000E206 File Offset: 0x0000C406
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x0000E21D File Offset: 0x0000C41D
		public bool IsNewSlot
		{
			get
			{
				return this.attributes.GetMaskedAttributes(0x100, 0x100U);
			}
			set
			{
				this.attributes = this.attributes.SetMaskedAttributes(0x100, 0x100U, value);
			}
		}

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060005AB RID: 1451 RVA: 0x0000E23B File Offset: 0x0000C43B
		// (set) Token: 0x060005AC RID: 1452 RVA: 0x0000E24D File Offset: 0x0000C44D
		public bool IsCheckAccessOnOverride
		{
			get
			{
				return this.attributes.GetAttributes(0x200);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x200, value);
			}
		}

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x0000E266 File Offset: 0x0000C466
		// (set) Token: 0x060005AE RID: 1454 RVA: 0x0000E278 File Offset: 0x0000C478
		public bool IsAbstract
		{
			get
			{
				return this.attributes.GetAttributes(0x400);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x400, value);
			}
		}

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060005AF RID: 1455 RVA: 0x0000E291 File Offset: 0x0000C491
		// (set) Token: 0x060005B0 RID: 1456 RVA: 0x0000E2A3 File Offset: 0x0000C4A3
		public bool IsSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x800);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x800, value);
			}
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060005B1 RID: 1457 RVA: 0x0000E2BC File Offset: 0x0000C4BC
		// (set) Token: 0x060005B2 RID: 1458 RVA: 0x0000E2CE File Offset: 0x0000C4CE
		public bool IsPInvokeImpl
		{
			get
			{
				return this.attributes.GetAttributes(0x2000);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x2000, value);
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x0000E2E7 File Offset: 0x0000C4E7
		// (set) Token: 0x060005B4 RID: 1460 RVA: 0x0000E2F5 File Offset: 0x0000C4F5
		public bool IsUnmanagedExport
		{
			get
			{
				return this.attributes.GetAttributes(8);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(8, value);
			}
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0000E30A File Offset: 0x0000C50A
		// (set) Token: 0x060005B6 RID: 1462 RVA: 0x0000E31C File Offset: 0x0000C51C
		public bool IsRuntimeSpecialName
		{
			get
			{
				return this.attributes.GetAttributes(0x1000);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x1000, value);
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x0000E335 File Offset: 0x0000C535
		// (set) Token: 0x060005B8 RID: 1464 RVA: 0x0000E347 File Offset: 0x0000C547
		public bool HasSecurity
		{
			get
			{
				return this.attributes.GetAttributes(0x4000);
			}
			set
			{
				this.attributes = this.attributes.SetAttributes(0x4000, value);
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0000E360 File Offset: 0x0000C560
		// (set) Token: 0x060005BA RID: 1466 RVA: 0x0000E36F File Offset: 0x0000C56F
		public bool IsIL
		{
			get
			{
				return this.impl_attributes.GetMaskedAttributes(3, 0U);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetMaskedAttributes(3, 0U, value);
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x0000E385 File Offset: 0x0000C585
		// (set) Token: 0x060005BC RID: 1468 RVA: 0x0000E394 File Offset: 0x0000C594
		public bool IsNative
		{
			get
			{
				return this.impl_attributes.GetMaskedAttributes(3, 1U);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetMaskedAttributes(3, 1U, value);
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060005BD RID: 1469 RVA: 0x0000E3AA File Offset: 0x0000C5AA
		// (set) Token: 0x060005BE RID: 1470 RVA: 0x0000E3B9 File Offset: 0x0000C5B9
		public bool IsRuntime
		{
			get
			{
				return this.impl_attributes.GetMaskedAttributes(3, 3U);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetMaskedAttributes(3, 3U, value);
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x0000E3CF File Offset: 0x0000C5CF
		// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0000E3DE File Offset: 0x0000C5DE
		public bool IsUnmanaged
		{
			get
			{
				return this.impl_attributes.GetMaskedAttributes(4, 4U);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetMaskedAttributes(4, 4U, value);
			}
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0000E3F4 File Offset: 0x0000C5F4
		// (set) Token: 0x060005C2 RID: 1474 RVA: 0x0000E403 File Offset: 0x0000C603
		public bool IsManaged
		{
			get
			{
				return this.impl_attributes.GetMaskedAttributes(4, 0U);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetMaskedAttributes(4, 0U, value);
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x0000E419 File Offset: 0x0000C619
		// (set) Token: 0x060005C4 RID: 1476 RVA: 0x0000E428 File Offset: 0x0000C628
		public bool IsForwardRef
		{
			get
			{
				return this.impl_attributes.GetAttributes(0x10);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetAttributes(0x10, value);
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x0000E43E File Offset: 0x0000C63E
		// (set) Token: 0x060005C6 RID: 1478 RVA: 0x0000E450 File Offset: 0x0000C650
		public bool IsPreserveSig
		{
			get
			{
				return this.impl_attributes.GetAttributes(0x80);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetAttributes(0x80, value);
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0000E469 File Offset: 0x0000C669
		// (set) Token: 0x060005C8 RID: 1480 RVA: 0x0000E47B File Offset: 0x0000C67B
		public bool IsInternalCall
		{
			get
			{
				return this.impl_attributes.GetAttributes(0x1000);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetAttributes(0x1000, value);
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000E494 File Offset: 0x0000C694
		// (set) Token: 0x060005CA RID: 1482 RVA: 0x0000E4A3 File Offset: 0x0000C6A3
		public bool IsSynchronized
		{
			get
			{
				return this.impl_attributes.GetAttributes(0x20);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetAttributes(0x20, value);
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0000E4B9 File Offset: 0x0000C6B9
		// (set) Token: 0x060005CC RID: 1484 RVA: 0x0000E4C7 File Offset: 0x0000C6C7
		public bool NoInlining
		{
			get
			{
				return this.impl_attributes.GetAttributes(8);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetAttributes(8, value);
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000E4DC File Offset: 0x0000C6DC
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x0000E4EB File Offset: 0x0000C6EB
		public bool NoOptimization
		{
			get
			{
				return this.impl_attributes.GetAttributes(0x40);
			}
			set
			{
				this.impl_attributes = this.impl_attributes.SetAttributes(0x40, value);
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0000E501 File Offset: 0x0000C701
		// (set) Token: 0x060005D0 RID: 1488 RVA: 0x0000E50A File Offset: 0x0000C70A
		public bool IsSetter
		{
			get
			{
				return this.GetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.Setter);
			}
			set
			{
				this.SetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.Setter, value);
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0000E514 File Offset: 0x0000C714
		// (set) Token: 0x060005D2 RID: 1490 RVA: 0x0000E51D File Offset: 0x0000C71D
		public bool IsGetter
		{
			get
			{
				return this.GetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.Getter);
			}
			set
			{
				this.SetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.Getter, value);
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0000E527 File Offset: 0x0000C727
		// (set) Token: 0x060005D4 RID: 1492 RVA: 0x0000E530 File Offset: 0x0000C730
		public bool IsOther
		{
			get
			{
				return this.GetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.Other);
			}
			set
			{
				this.SetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.Other, value);
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0000E53A File Offset: 0x0000C73A
		// (set) Token: 0x060005D6 RID: 1494 RVA: 0x0000E543 File Offset: 0x0000C743
		public bool IsAddOn
		{
			get
			{
				return this.GetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.AddOn);
			}
			set
			{
				this.SetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.AddOn, value);
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x0000E54D File Offset: 0x0000C74D
		// (set) Token: 0x060005D8 RID: 1496 RVA: 0x0000E557 File Offset: 0x0000C757
		public bool IsRemoveOn
		{
			get
			{
				return this.GetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.RemoveOn);
			}
			set
			{
				this.SetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.RemoveOn, value);
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x0000E562 File Offset: 0x0000C762
		// (set) Token: 0x060005DA RID: 1498 RVA: 0x0000E56C File Offset: 0x0000C76C
		public bool IsFire
		{
			get
			{
				return this.GetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.Fire);
			}
			set
			{
				this.SetSemantics(global::Mono.Cecil.MethodSemanticsAttributes.Fire, value);
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x0000E577 File Offset: 0x0000C777
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x0000E584 File Offset: 0x0000C784
		public new global::Mono.Cecil.TypeDefinition DeclaringType
		{
			get
			{
				return (global::Mono.Cecil.TypeDefinition)base.DeclaringType;
			}
			set
			{
				base.DeclaringType = value;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x0000E58D File Offset: 0x0000C78D
		public bool IsConstructor
		{
			get
			{
				return this.IsRuntimeSpecialName && this.IsSpecialName && (this.Name == ".cctor" || this.Name == ".ctor");
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x0000E5C5 File Offset: 0x0000C7C5
		public override bool IsDefinition
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0000E5C8 File Offset: 0x0000C7C8
		internal MethodDefinition()
		{
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Method);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0000E5E0 File Offset: 0x0000C7E0
		public MethodDefinition(string name, global::Mono.Cecil.MethodAttributes attributes, global::Mono.Cecil.TypeReference returnType) : base(name, returnType)
		{
			this.attributes = (ushort)attributes;
			this.HasThis = !this.IsStatic;
			this.token = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Method);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0000E610 File Offset: 0x0000C810
		public override global::Mono.Cecil.MethodDefinition Resolve()
		{
			return this;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0000DC99 File Offset: 0x0000BE99
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.MethodSemanticsAttributes <ReadSemantics>b__0(global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadAllSemantics(method);
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0000DE00 File Offset: 0x0000C000
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.Cil.MethodBody <get_Body>b__2(global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadMethodBody(method);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0000DE9F File Offset: 0x0000C09F
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.PInvokeInfo <get_PInvokeInfo>b__4(global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadPInvokeInfo(method);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0000DF18 File Offset: 0x0000C118
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <get_HasOverrides>b__6(global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.HasOverrides(method);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0000DF7B File Offset: 0x0000C17B
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference> <get_Overrides>b__8(global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.ReadOverrides(method);
		}

		// Token: 0x04000378 RID: 888
		private ushort attributes;

		// Token: 0x04000379 RID: 889
		private ushort impl_attributes;

		// Token: 0x0400037A RID: 890
		internal global::Mono.Cecil.MethodSemanticsAttributes? sem_attrs;

		// Token: 0x0400037B RID: 891
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> custom_attributes;

		// Token: 0x0400037C RID: 892
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> security_declarations;

		// Token: 0x0400037D RID: 893
		internal uint rva;

		// Token: 0x0400037E RID: 894
		internal global::Mono.Cecil.PInvokeInfo pinvoke;

		// Token: 0x0400037F RID: 895
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference> overrides;

		// Token: 0x04000380 RID: 896
		internal global::Mono.Cecil.Cil.MethodBody body;

		// Token: 0x04000381 RID: 897
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.MethodSemanticsAttributes> CS$<>9__CachedAnonymousMethodDelegate1;

		// Token: 0x04000382 RID: 898
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.Cil.MethodBody> CS$<>9__CachedAnonymousMethodDelegate3;

		// Token: 0x04000383 RID: 899
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.PInvokeInfo> CS$<>9__CachedAnonymousMethodDelegate5;

		// Token: 0x04000384 RID: 900
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.MetadataReader, bool> CS$<>9__CachedAnonymousMethodDelegate7;

		// Token: 0x04000385 RID: 901
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference>> CS$<>9__CachedAnonymousMethodDelegate9;
	}
}

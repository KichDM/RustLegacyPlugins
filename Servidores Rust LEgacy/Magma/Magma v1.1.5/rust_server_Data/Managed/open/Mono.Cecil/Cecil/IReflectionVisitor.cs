using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000036 RID: 54
	public interface IReflectionVisitor
	{
		// Token: 0x060002F2 RID: 754
		void VisitModuleDefinition(global::Mono.Cecil.ModuleDefinition module);

		// Token: 0x060002F3 RID: 755
		void VisitTypeDefinitionCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> types);

		// Token: 0x060002F4 RID: 756
		void VisitTypeDefinition(global::Mono.Cecil.TypeDefinition type);

		// Token: 0x060002F5 RID: 757
		void VisitTypeReferenceCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> refs);

		// Token: 0x060002F6 RID: 758
		void VisitTypeReference(global::Mono.Cecil.TypeReference type);

		// Token: 0x060002F7 RID: 759
		void VisitMemberReferenceCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MemberReference> members);

		// Token: 0x060002F8 RID: 760
		void VisitMemberReference(global::Mono.Cecil.MemberReference member);

		// Token: 0x060002F9 RID: 761
		void VisitInterfaceCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> interfaces);

		// Token: 0x060002FA RID: 762
		void VisitInterface(global::Mono.Cecil.TypeReference interf);

		// Token: 0x060002FB RID: 763
		void VisitExternTypeCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> externs);

		// Token: 0x060002FC RID: 764
		void VisitExternType(global::Mono.Cecil.TypeReference externType);

		// Token: 0x060002FD RID: 765
		void VisitOverrideCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodReference> meth);

		// Token: 0x060002FE RID: 766
		void VisitOverride(global::Mono.Cecil.MethodReference ov);

		// Token: 0x060002FF RID: 767
		void VisitNestedTypeCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeDefinition> nestedTypes);

		// Token: 0x06000300 RID: 768
		void VisitNestedType(global::Mono.Cecil.TypeDefinition nestedType);

		// Token: 0x06000301 RID: 769
		void VisitParameterDefinitionCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ParameterDefinition> parameters);

		// Token: 0x06000302 RID: 770
		void VisitParameterDefinition(global::Mono.Cecil.ParameterDefinition parameter);

		// Token: 0x06000303 RID: 771
		void VisitMethodDefinitionCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> methods);

		// Token: 0x06000304 RID: 772
		void VisitMethodDefinition(global::Mono.Cecil.MethodDefinition method);

		// Token: 0x06000305 RID: 773
		void VisitConstructorCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.MethodDefinition> ctors);

		// Token: 0x06000306 RID: 774
		void VisitConstructor(global::Mono.Cecil.MethodDefinition ctor);

		// Token: 0x06000307 RID: 775
		void VisitPInvokeInfo(global::Mono.Cecil.PInvokeInfo pinvk);

		// Token: 0x06000308 RID: 776
		void VisitEventDefinitionCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.EventDefinition> events);

		// Token: 0x06000309 RID: 777
		void VisitEventDefinition(global::Mono.Cecil.EventDefinition evt);

		// Token: 0x0600030A RID: 778
		void VisitFieldDefinitionCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.FieldDefinition> fields);

		// Token: 0x0600030B RID: 779
		void VisitFieldDefinition(global::Mono.Cecil.FieldDefinition field);

		// Token: 0x0600030C RID: 780
		void VisitPropertyDefinitionCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.PropertyDefinition> properties);

		// Token: 0x0600030D RID: 781
		void VisitPropertyDefinition(global::Mono.Cecil.PropertyDefinition property);

		// Token: 0x0600030E RID: 782
		void VisitSecurityDeclarationCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.SecurityDeclaration> secDecls);

		// Token: 0x0600030F RID: 783
		void VisitSecurityDeclaration(global::Mono.Cecil.SecurityDeclaration secDecl);

		// Token: 0x06000310 RID: 784
		void VisitCustomAttributeCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.CustomAttribute> customAttrs);

		// Token: 0x06000311 RID: 785
		void VisitCustomAttribute(global::Mono.Cecil.CustomAttribute customAttr);

		// Token: 0x06000312 RID: 786
		void VisitGenericParameterCollection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.GenericParameter> genparams);

		// Token: 0x06000313 RID: 787
		void VisitGenericParameter(global::Mono.Cecil.GenericParameter genparam);

		// Token: 0x06000314 RID: 788
		void VisitMarshalSpec(global::Mono.Cecil.MarshalInfo marshalSpec);

		// Token: 0x06000315 RID: 789
		void TerminateModuleDefinition(global::Mono.Cecil.ModuleDefinition module);
	}
}

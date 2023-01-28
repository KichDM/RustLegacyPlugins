using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200008B RID: 139
	public enum Code
	{
		// Token: 0x040003AC RID: 940
		Nop,
		// Token: 0x040003AD RID: 941
		Break,
		// Token: 0x040003AE RID: 942
		Ldarg_0,
		// Token: 0x040003AF RID: 943
		Ldarg_1,
		// Token: 0x040003B0 RID: 944
		Ldarg_2,
		// Token: 0x040003B1 RID: 945
		Ldarg_3,
		// Token: 0x040003B2 RID: 946
		Ldloc_0,
		// Token: 0x040003B3 RID: 947
		Ldloc_1,
		// Token: 0x040003B4 RID: 948
		Ldloc_2,
		// Token: 0x040003B5 RID: 949
		Ldloc_3,
		// Token: 0x040003B6 RID: 950
		Stloc_0,
		// Token: 0x040003B7 RID: 951
		Stloc_1,
		// Token: 0x040003B8 RID: 952
		Stloc_2,
		// Token: 0x040003B9 RID: 953
		Stloc_3,
		// Token: 0x040003BA RID: 954
		Ldarg_S,
		// Token: 0x040003BB RID: 955
		Ldarga_S,
		// Token: 0x040003BC RID: 956
		Starg_S,
		// Token: 0x040003BD RID: 957
		Ldloc_S,
		// Token: 0x040003BE RID: 958
		Ldloca_S,
		// Token: 0x040003BF RID: 959
		Stloc_S,
		// Token: 0x040003C0 RID: 960
		Ldnull,
		// Token: 0x040003C1 RID: 961
		Ldc_I4_M1,
		// Token: 0x040003C2 RID: 962
		Ldc_I4_0,
		// Token: 0x040003C3 RID: 963
		Ldc_I4_1,
		// Token: 0x040003C4 RID: 964
		Ldc_I4_2,
		// Token: 0x040003C5 RID: 965
		Ldc_I4_3,
		// Token: 0x040003C6 RID: 966
		Ldc_I4_4,
		// Token: 0x040003C7 RID: 967
		Ldc_I4_5,
		// Token: 0x040003C8 RID: 968
		Ldc_I4_6,
		// Token: 0x040003C9 RID: 969
		Ldc_I4_7,
		// Token: 0x040003CA RID: 970
		Ldc_I4_8,
		// Token: 0x040003CB RID: 971
		Ldc_I4_S,
		// Token: 0x040003CC RID: 972
		Ldc_I4,
		// Token: 0x040003CD RID: 973
		Ldc_I8,
		// Token: 0x040003CE RID: 974
		Ldc_R4,
		// Token: 0x040003CF RID: 975
		Ldc_R8,
		// Token: 0x040003D0 RID: 976
		Dup,
		// Token: 0x040003D1 RID: 977
		Pop,
		// Token: 0x040003D2 RID: 978
		Jmp,
		// Token: 0x040003D3 RID: 979
		Call,
		// Token: 0x040003D4 RID: 980
		Calli,
		// Token: 0x040003D5 RID: 981
		Ret,
		// Token: 0x040003D6 RID: 982
		Br_S,
		// Token: 0x040003D7 RID: 983
		Brfalse_S,
		// Token: 0x040003D8 RID: 984
		Brtrue_S,
		// Token: 0x040003D9 RID: 985
		Beq_S,
		// Token: 0x040003DA RID: 986
		Bge_S,
		// Token: 0x040003DB RID: 987
		Bgt_S,
		// Token: 0x040003DC RID: 988
		Ble_S,
		// Token: 0x040003DD RID: 989
		Blt_S,
		// Token: 0x040003DE RID: 990
		Bne_Un_S,
		// Token: 0x040003DF RID: 991
		Bge_Un_S,
		// Token: 0x040003E0 RID: 992
		Bgt_Un_S,
		// Token: 0x040003E1 RID: 993
		Ble_Un_S,
		// Token: 0x040003E2 RID: 994
		Blt_Un_S,
		// Token: 0x040003E3 RID: 995
		Br,
		// Token: 0x040003E4 RID: 996
		Brfalse,
		// Token: 0x040003E5 RID: 997
		Brtrue,
		// Token: 0x040003E6 RID: 998
		Beq,
		// Token: 0x040003E7 RID: 999
		Bge,
		// Token: 0x040003E8 RID: 1000
		Bgt,
		// Token: 0x040003E9 RID: 1001
		Ble,
		// Token: 0x040003EA RID: 1002
		Blt,
		// Token: 0x040003EB RID: 1003
		Bne_Un,
		// Token: 0x040003EC RID: 1004
		Bge_Un,
		// Token: 0x040003ED RID: 1005
		Bgt_Un,
		// Token: 0x040003EE RID: 1006
		Ble_Un,
		// Token: 0x040003EF RID: 1007
		Blt_Un,
		// Token: 0x040003F0 RID: 1008
		Switch,
		// Token: 0x040003F1 RID: 1009
		Ldind_I1,
		// Token: 0x040003F2 RID: 1010
		Ldind_U1,
		// Token: 0x040003F3 RID: 1011
		Ldind_I2,
		// Token: 0x040003F4 RID: 1012
		Ldind_U2,
		// Token: 0x040003F5 RID: 1013
		Ldind_I4,
		// Token: 0x040003F6 RID: 1014
		Ldind_U4,
		// Token: 0x040003F7 RID: 1015
		Ldind_I8,
		// Token: 0x040003F8 RID: 1016
		Ldind_I,
		// Token: 0x040003F9 RID: 1017
		Ldind_R4,
		// Token: 0x040003FA RID: 1018
		Ldind_R8,
		// Token: 0x040003FB RID: 1019
		Ldind_Ref,
		// Token: 0x040003FC RID: 1020
		Stind_Ref,
		// Token: 0x040003FD RID: 1021
		Stind_I1,
		// Token: 0x040003FE RID: 1022
		Stind_I2,
		// Token: 0x040003FF RID: 1023
		Stind_I4,
		// Token: 0x04000400 RID: 1024
		Stind_I8,
		// Token: 0x04000401 RID: 1025
		Stind_R4,
		// Token: 0x04000402 RID: 1026
		Stind_R8,
		// Token: 0x04000403 RID: 1027
		Add,
		// Token: 0x04000404 RID: 1028
		Sub,
		// Token: 0x04000405 RID: 1029
		Mul,
		// Token: 0x04000406 RID: 1030
		Div,
		// Token: 0x04000407 RID: 1031
		Div_Un,
		// Token: 0x04000408 RID: 1032
		Rem,
		// Token: 0x04000409 RID: 1033
		Rem_Un,
		// Token: 0x0400040A RID: 1034
		And,
		// Token: 0x0400040B RID: 1035
		Or,
		// Token: 0x0400040C RID: 1036
		Xor,
		// Token: 0x0400040D RID: 1037
		Shl,
		// Token: 0x0400040E RID: 1038
		Shr,
		// Token: 0x0400040F RID: 1039
		Shr_Un,
		// Token: 0x04000410 RID: 1040
		Neg,
		// Token: 0x04000411 RID: 1041
		Not,
		// Token: 0x04000412 RID: 1042
		Conv_I1,
		// Token: 0x04000413 RID: 1043
		Conv_I2,
		// Token: 0x04000414 RID: 1044
		Conv_I4,
		// Token: 0x04000415 RID: 1045
		Conv_I8,
		// Token: 0x04000416 RID: 1046
		Conv_R4,
		// Token: 0x04000417 RID: 1047
		Conv_R8,
		// Token: 0x04000418 RID: 1048
		Conv_U4,
		// Token: 0x04000419 RID: 1049
		Conv_U8,
		// Token: 0x0400041A RID: 1050
		Callvirt,
		// Token: 0x0400041B RID: 1051
		Cpobj,
		// Token: 0x0400041C RID: 1052
		Ldobj,
		// Token: 0x0400041D RID: 1053
		Ldstr,
		// Token: 0x0400041E RID: 1054
		Newobj,
		// Token: 0x0400041F RID: 1055
		Castclass,
		// Token: 0x04000420 RID: 1056
		Isinst,
		// Token: 0x04000421 RID: 1057
		Conv_R_Un,
		// Token: 0x04000422 RID: 1058
		Unbox,
		// Token: 0x04000423 RID: 1059
		Throw,
		// Token: 0x04000424 RID: 1060
		Ldfld,
		// Token: 0x04000425 RID: 1061
		Ldflda,
		// Token: 0x04000426 RID: 1062
		Stfld,
		// Token: 0x04000427 RID: 1063
		Ldsfld,
		// Token: 0x04000428 RID: 1064
		Ldsflda,
		// Token: 0x04000429 RID: 1065
		Stsfld,
		// Token: 0x0400042A RID: 1066
		Stobj,
		// Token: 0x0400042B RID: 1067
		Conv_Ovf_I1_Un,
		// Token: 0x0400042C RID: 1068
		Conv_Ovf_I2_Un,
		// Token: 0x0400042D RID: 1069
		Conv_Ovf_I4_Un,
		// Token: 0x0400042E RID: 1070
		Conv_Ovf_I8_Un,
		// Token: 0x0400042F RID: 1071
		Conv_Ovf_U1_Un,
		// Token: 0x04000430 RID: 1072
		Conv_Ovf_U2_Un,
		// Token: 0x04000431 RID: 1073
		Conv_Ovf_U4_Un,
		// Token: 0x04000432 RID: 1074
		Conv_Ovf_U8_Un,
		// Token: 0x04000433 RID: 1075
		Conv_Ovf_I_Un,
		// Token: 0x04000434 RID: 1076
		Conv_Ovf_U_Un,
		// Token: 0x04000435 RID: 1077
		Box,
		// Token: 0x04000436 RID: 1078
		Newarr,
		// Token: 0x04000437 RID: 1079
		Ldlen,
		// Token: 0x04000438 RID: 1080
		Ldelema,
		// Token: 0x04000439 RID: 1081
		Ldelem_I1,
		// Token: 0x0400043A RID: 1082
		Ldelem_U1,
		// Token: 0x0400043B RID: 1083
		Ldelem_I2,
		// Token: 0x0400043C RID: 1084
		Ldelem_U2,
		// Token: 0x0400043D RID: 1085
		Ldelem_I4,
		// Token: 0x0400043E RID: 1086
		Ldelem_U4,
		// Token: 0x0400043F RID: 1087
		Ldelem_I8,
		// Token: 0x04000440 RID: 1088
		Ldelem_I,
		// Token: 0x04000441 RID: 1089
		Ldelem_R4,
		// Token: 0x04000442 RID: 1090
		Ldelem_R8,
		// Token: 0x04000443 RID: 1091
		Ldelem_Ref,
		// Token: 0x04000444 RID: 1092
		Stelem_I,
		// Token: 0x04000445 RID: 1093
		Stelem_I1,
		// Token: 0x04000446 RID: 1094
		Stelem_I2,
		// Token: 0x04000447 RID: 1095
		Stelem_I4,
		// Token: 0x04000448 RID: 1096
		Stelem_I8,
		// Token: 0x04000449 RID: 1097
		Stelem_R4,
		// Token: 0x0400044A RID: 1098
		Stelem_R8,
		// Token: 0x0400044B RID: 1099
		Stelem_Ref,
		// Token: 0x0400044C RID: 1100
		Ldelem_Any,
		// Token: 0x0400044D RID: 1101
		Stelem_Any,
		// Token: 0x0400044E RID: 1102
		Unbox_Any,
		// Token: 0x0400044F RID: 1103
		Conv_Ovf_I1,
		// Token: 0x04000450 RID: 1104
		Conv_Ovf_U1,
		// Token: 0x04000451 RID: 1105
		Conv_Ovf_I2,
		// Token: 0x04000452 RID: 1106
		Conv_Ovf_U2,
		// Token: 0x04000453 RID: 1107
		Conv_Ovf_I4,
		// Token: 0x04000454 RID: 1108
		Conv_Ovf_U4,
		// Token: 0x04000455 RID: 1109
		Conv_Ovf_I8,
		// Token: 0x04000456 RID: 1110
		Conv_Ovf_U8,
		// Token: 0x04000457 RID: 1111
		Refanyval,
		// Token: 0x04000458 RID: 1112
		Ckfinite,
		// Token: 0x04000459 RID: 1113
		Mkrefany,
		// Token: 0x0400045A RID: 1114
		Ldtoken,
		// Token: 0x0400045B RID: 1115
		Conv_U2,
		// Token: 0x0400045C RID: 1116
		Conv_U1,
		// Token: 0x0400045D RID: 1117
		Conv_I,
		// Token: 0x0400045E RID: 1118
		Conv_Ovf_I,
		// Token: 0x0400045F RID: 1119
		Conv_Ovf_U,
		// Token: 0x04000460 RID: 1120
		Add_Ovf,
		// Token: 0x04000461 RID: 1121
		Add_Ovf_Un,
		// Token: 0x04000462 RID: 1122
		Mul_Ovf,
		// Token: 0x04000463 RID: 1123
		Mul_Ovf_Un,
		// Token: 0x04000464 RID: 1124
		Sub_Ovf,
		// Token: 0x04000465 RID: 1125
		Sub_Ovf_Un,
		// Token: 0x04000466 RID: 1126
		Endfinally,
		// Token: 0x04000467 RID: 1127
		Leave,
		// Token: 0x04000468 RID: 1128
		Leave_S,
		// Token: 0x04000469 RID: 1129
		Stind_I,
		// Token: 0x0400046A RID: 1130
		Conv_U,
		// Token: 0x0400046B RID: 1131
		Arglist,
		// Token: 0x0400046C RID: 1132
		Ceq,
		// Token: 0x0400046D RID: 1133
		Cgt,
		// Token: 0x0400046E RID: 1134
		Cgt_Un,
		// Token: 0x0400046F RID: 1135
		Clt,
		// Token: 0x04000470 RID: 1136
		Clt_Un,
		// Token: 0x04000471 RID: 1137
		Ldftn,
		// Token: 0x04000472 RID: 1138
		Ldvirtftn,
		// Token: 0x04000473 RID: 1139
		Ldarg,
		// Token: 0x04000474 RID: 1140
		Ldarga,
		// Token: 0x04000475 RID: 1141
		Starg,
		// Token: 0x04000476 RID: 1142
		Ldloc,
		// Token: 0x04000477 RID: 1143
		Ldloca,
		// Token: 0x04000478 RID: 1144
		Stloc,
		// Token: 0x04000479 RID: 1145
		Localloc,
		// Token: 0x0400047A RID: 1146
		Endfilter,
		// Token: 0x0400047B RID: 1147
		Unaligned,
		// Token: 0x0400047C RID: 1148
		Volatile,
		// Token: 0x0400047D RID: 1149
		Tail,
		// Token: 0x0400047E RID: 1150
		Initobj,
		// Token: 0x0400047F RID: 1151
		Constrained,
		// Token: 0x04000480 RID: 1152
		Cpblk,
		// Token: 0x04000481 RID: 1153
		Initblk,
		// Token: 0x04000482 RID: 1154
		No,
		// Token: 0x04000483 RID: 1155
		Rethrow,
		// Token: 0x04000484 RID: 1156
		Sizeof,
		// Token: 0x04000485 RID: 1157
		Refanytype,
		// Token: 0x04000486 RID: 1158
		Readonly
	}
}

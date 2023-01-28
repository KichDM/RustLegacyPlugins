using System;

// Token: 0x02000419 RID: 1049
public enum NetError
{
	// Token: 0x04001229 RID: 4649
	AlreadyConnectedToAnotherServer = -1,
	// Token: 0x0400122A RID: 4650
	ApprovalDenied = 0x51,
	// Token: 0x0400122B RID: 4651
	ConnectionBanned = 0x15,
	// Token: 0x0400122C RID: 4652
	ConnectionFailed = 0xE,
	// Token: 0x0400122D RID: 4653
	ConnectionTimeout = 0x46,
	// Token: 0x0400122E RID: 4654
	CreateSocketOrThreadFailure = -2,
	// Token: 0x0400122F RID: 4655
	DetectedDuplicatePlayerID = 0x17,
	// Token: 0x04001230 RID: 4656
	EmptyConnectTarget = -4,
	// Token: 0x04001231 RID: 4657
	IncompatibleVersions = 0x40,
	// Token: 0x04001232 RID: 4658
	IncorrectParameters = -3,
	// Token: 0x04001233 RID: 4659
	InternalDirectConnectFailed = -5,
	// Token: 0x04001234 RID: 4660
	InvalidPassword = 0x16,
	// Token: 0x04001235 RID: 4661
	IsAuthoritativeServer = 0x50,
	// Token: 0x04001236 RID: 4662
	LimitedPlayers = 0x47,
	// Token: 0x04001237 RID: 4663
	NATPunchthroughFailed = 0x3F,
	// Token: 0x04001238 RID: 4664
	NATTargetConnectionLost = 0x3E,
	// Token: 0x04001239 RID: 4665
	NATTargetNotConnected = 0x3D,
	// Token: 0x0400123A RID: 4666
	NoError = 0,
	// Token: 0x0400123B RID: 4667
	ProxyServerNotEnabled = 0x5C,
	// Token: 0x0400123C RID: 4668
	ProxyServerOutOfPorts,
	// Token: 0x0400123D RID: 4669
	ProxyTargetNotConnected = 0x5A,
	// Token: 0x0400123E RID: 4670
	ProxyTargetNotRegistered,
	// Token: 0x0400123F RID: 4671
	RSAPublicKeyMismatch = 0x14,
	// Token: 0x04001240 RID: 4672
	TooManyConnectedPlayers = 0x11,
	// Token: 0x04001241 RID: 4673
	Facepunch_Kick_ServerRestarting = 0x80,
	// Token: 0x04001242 RID: 4674
	Facepunch_Approval_Closed,
	// Token: 0x04001243 RID: 4675
	Facepunch_Approval_TooManyConnectedPlayersNow,
	// Token: 0x04001244 RID: 4676
	Facepunch_Approval_ConnectorAuthorizeException,
	// Token: 0x04001245 RID: 4677
	Facepunch_Approval_ConnectorAuthorizeExecution,
	// Token: 0x04001246 RID: 4678
	Facepunch_Approval_ConnectorDidNothing,
	// Token: 0x04001247 RID: 4679
	Facepunch_Approval_ConnectorCreateFailure,
	// Token: 0x04001248 RID: 4680
	Facepunch_Approval_ServerDoesNotSupportConnector,
	// Token: 0x04001249 RID: 4681
	Facepunch_Approval_MissingServerManagement,
	// Token: 0x0400124A RID: 4682
	Facepunch_Approval_ServerLoginException,
	// Token: 0x0400124B RID: 4683
	Facepunch_Approval_DisposedWait,
	// Token: 0x0400124C RID: 4684
	Facepunch_Approval_DisposedLimbo,
	// Token: 0x0400124D RID: 4685
	Facepunch_Kick_MultipleConnections,
	// Token: 0x0400124E RID: 4686
	Facepunch_Kick_Violation,
	// Token: 0x0400124F RID: 4687
	Facepunch_Kick_RCON,
	// Token: 0x04001250 RID: 4688
	Facepunch_Kick_Ban,
	// Token: 0x04001251 RID: 4689
	Facepunch_Kick_BadName,
	// Token: 0x04001252 RID: 4690
	Facepunch_Connector_InLimboState,
	// Token: 0x04001253 RID: 4691
	Facepunch_Connector_WaitedLimbo,
	// Token: 0x04001254 RID: 4692
	Facepunch_Connector_RoutineMoveException,
	// Token: 0x04001255 RID: 4693
	Facepunch_Connector_RoutineYieldException,
	// Token: 0x04001256 RID: 4694
	Facepunch_Connector_MissingFeatureImplementation,
	// Token: 0x04001257 RID: 4695
	Facepunch_Connector_Cancelled,
	// Token: 0x04001258 RID: 4696
	Facepunch_Connector_AuthFailure,
	// Token: 0x04001259 RID: 4697
	Facepunch_Connector_AuthException,
	// Token: 0x0400125A RID: 4698
	Facepunch_Connector_MultipleAttempts,
	// Token: 0x0400125B RID: 4699
	Facepunch_Connector_VAC_Banned,
	// Token: 0x0400125C RID: 4700
	Facepunch_Connector_AuthTimeout,
	// Token: 0x0400125D RID: 4701
	Facepunch_Connector_Old,
	// Token: 0x0400125E RID: 4702
	Facepunch_Connector_NoConnect,
	// Token: 0x0400125F RID: 4703
	Facepunch_Connector_Invalid,
	// Token: 0x04001260 RID: 4704
	Facepunch_Connector_Expired,
	// Token: 0x04001261 RID: 4705
	Facepunch_Connector_ConnectedElsewhere,
	// Token: 0x04001262 RID: 4706
	Facepunch_API_Failure,
	// Token: 0x04001263 RID: 4707
	Facepunch_Whitelist_Failure
}

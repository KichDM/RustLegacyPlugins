using System;
using System.Collections.Generic;
using uLink;
using UnityEngine;

// Token: 0x0200041A RID: 1050
public static class NetErrorHelper
{
	// Token: 0x06002478 RID: 9336 RVA: 0x0008AF10 File Offset: 0x00089110
	static NetErrorHelper()
	{
		global::NetErrorHelper.CacheNiceStrings();
		global::uLink.NetworkConnectionError networkConnectionError = 0;
		foreach (object obj in global::System.Enum.GetValues(typeof(global::uLink.NetworkConnectionError)))
		{
			if ((int)obj < networkConnectionError)
			{
				networkConnectionError = (int)obj;
			}
		}
		if (networkConnectionError != -5)
		{
			global::UnityEngine.Debug.LogWarning(string.Concat(new object[]
			{
				"Most Negative Base ",
				networkConnectionError,
				" (",
				networkConnectionError,
				")"
			}));
		}
	}

	// Token: 0x06002479 RID: 9337 RVA: 0x0008AFF8 File Offset: 0x000891F8
	public static global::NetError ToNetError(this global::uLink.NetworkConnectionError error)
	{
		int num = error;
		if (num < -5 && num >> 7 == -1)
		{
			num &= 0xFF;
		}
		return (global::NetError)num;
	}

	// Token: 0x0600247A RID: 9338 RVA: 0x0008B024 File Offset: 0x00089224
	internal static global::uLink.NetworkConnectionError _uLink(this global::NetError error)
	{
		return error;
	}

	// Token: 0x0600247B RID: 9339 RVA: 0x0008B028 File Offset: 0x00089228
	private static void CacheNiceStrings()
	{
		foreach (object obj in global::System.Enum.GetValues(typeof(global::NetError)))
		{
			global::NetError netError = (global::NetError)((int)obj);
			string text = global::NetErrorHelper.BuildNiceString(netError);
			if (text == null && netError != global::NetError.NoError)
			{
				global::UnityEngine.Debug.LogWarning("NetError." + obj + " has no nice string");
				text = global::NetErrorHelper.FallbackNiceString(netError);
			}
			global::NetErrorHelper.niceStrings[netError] = text;
		}
	}

	// Token: 0x0600247C RID: 9340 RVA: 0x0008B0DC File Offset: 0x000892DC
	private static string FallbackNiceString(global::NetError error)
	{
		string str = error.ToString().Replace("Facepunch_", string.Empty);
		string str2 = "(";
		int num = (int)error;
		return (str + str2 + num.ToString("X") + ")").Replace("_", " ");
	}

	// Token: 0x0600247D RID: 9341 RVA: 0x0008B130 File Offset: 0x00089330
	public static string NiceString(this global::NetError value)
	{
		string result;
		if (global::NetErrorHelper.niceStrings.TryGetValue(value, out result))
		{
			return result;
		}
		return global::NetErrorHelper.FallbackNiceString(value);
	}

	// Token: 0x0600247E RID: 9342 RVA: 0x0008B158 File Offset: 0x00089358
	private static string BuildNiceString(global::NetError value)
	{
		switch (value)
		{
		case global::NetError.ProxyTargetNotConnected:
			return "Proxy target not connected";
		case global::NetError.ProxyTargetNotRegistered:
			return "Proxy target not registered";
		case global::NetError.ProxyServerNotEnabled:
			return "Proxy server not enabled";
		case global::NetError.ProxyServerOutOfPorts:
			return "Proxy server out of ports";
		default:
			switch (value)
			{
			case global::NetError.NATTargetNotConnected:
				return "NAT target not connected";
			case global::NetError.NATTargetConnectionLost:
				return "NAT target connection lost";
			case global::NetError.NATPunchthroughFailed:
				return "NAT punchthrough";
			case global::NetError.IncompatibleVersions:
				return "Version incompatible";
			default:
				switch (value)
				{
				case global::NetError.ConnectionFailed:
					return "Could not reach the server";
				default:
					switch (value + 5)
					{
					case global::NetError.NoError:
						return "Direct connect failed";
					case (global::NetError)1:
						return "Invalid server";
					case (global::NetError)2:
						return "Incorrect parameters";
					case (global::NetError)3:
						return "Could not create socket or thread";
					case (global::NetError)4:
						return "Already connected to different server";
					case (global::NetError)5:
						return null;
					default:
						if (value == global::NetError.IsAuthoritativeServer)
						{
							return "Authoritative server";
						}
						if (value != global::NetError.ApprovalDenied)
						{
							return null;
						}
						return "You've been denied from connecting";
					}
					break;
				case global::NetError.TooManyConnectedPlayers:
					return "Full";
				case global::NetError.RSAPublicKeyMismatch:
					return "RSA public key mismatch";
				case global::NetError.ConnectionBanned:
					return "Banned from connecting";
				case global::NetError.InvalidPassword:
					return "Invalid password";
				case global::NetError.DetectedDuplicatePlayerID:
					return "Duplicate players identified";
				}
				break;
			case global::NetError.ConnectionTimeout:
				return "Timed out";
			case global::NetError.LimitedPlayers:
				return "Server has limited players";
			}
			break;
		case global::NetError.Facepunch_Kick_ServerRestarting:
			return "Server restarting";
		case global::NetError.Facepunch_Approval_Closed:
			return "Not accepting new connections.";
		case global::NetError.Facepunch_Approval_TooManyConnectedPlayersNow:
			return "Authorization busy";
		case global::NetError.Facepunch_Approval_ConnectorAuthorizeException:
			return "Server exception with authorization";
		case global::NetError.Facepunch_Approval_ConnectorAuthorizeExecution:
			return "Aborted starting of authorization";
		case global::NetError.Facepunch_Approval_ConnectorDidNothing:
			return "Server failed to start authorization";
		case global::NetError.Facepunch_Approval_ConnectorCreateFailure:
			return "Server was unable to start authorization";
		case global::NetError.Facepunch_Approval_ServerDoesNotSupportConnector:
			return "Unsupported ticket";
		case global::NetError.Facepunch_Approval_MissingServerManagement:
			return "Server is not prepared";
		case global::NetError.Facepunch_Approval_ServerLoginException:
			return "Server exception";
		case global::NetError.Facepunch_Approval_DisposedWait:
			return "Aborted authorization";
		case global::NetError.Facepunch_Approval_DisposedLimbo:
			return "Failed to run authorization";
		case global::NetError.Facepunch_Kick_MultipleConnections:
			return "Started a different connection";
		case global::NetError.Facepunch_Kick_Violation:
			return "Kicked because of violation";
		case global::NetError.Facepunch_Kick_RCON:
			return "Kicked by admin";
		case global::NetError.Facepunch_Kick_Ban:
			return "Kicked and Banned by admin";
		case global::NetError.Facepunch_Kick_BadName:
			return "Rejected name";
		case global::NetError.Facepunch_Connector_InLimboState:
			return "Lost connection during authorization";
		case global::NetError.Facepunch_Connector_WaitedLimbo:
			return "Server lost you while processing ticket";
		case global::NetError.Facepunch_Connector_RoutineMoveException:
			return "Server exception occured while awaiting authorization";
		case global::NetError.Facepunch_Connector_RoutineYieldException:
			return "Server exception occured when checking authorization";
		case global::NetError.Facepunch_Connector_MissingFeatureImplementation:
			return "Authorization produced an unhandled message";
		case global::NetError.Facepunch_Connector_Cancelled:
			return "A ticket was cancelled - try again";
		case global::NetError.Facepunch_Connector_AuthFailure:
			return "Authorization failed";
		case global::NetError.Facepunch_Connector_AuthException:
			return "Server exception while starting authorization";
		case global::NetError.Facepunch_Connector_MultipleAttempts:
			return "Multiple authorization attempts";
		case global::NetError.Facepunch_Connector_VAC_Banned:
			return "VAC banned";
		case global::NetError.Facepunch_Connector_AuthTimeout:
			return "Timed out authorizing your ticket";
		case global::NetError.Facepunch_Connector_Old:
			return "Ticket already used";
		case global::NetError.Facepunch_Connector_NoConnect:
			return "Lost authorization";
		case global::NetError.Facepunch_Connector_Invalid:
			return "Ticket invalid";
		case global::NetError.Facepunch_Connector_Expired:
			return "Ticket expired";
		case global::NetError.Facepunch_Connector_ConnectedElsewhere:
			return "Changed connection";
		case global::NetError.Facepunch_API_Failure:
			return "API Failure";
		case global::NetError.Facepunch_Whitelist_Failure:
			return "Not in whitelist";
		}
	}

	// Token: 0x04001264 RID: 4708
	private const int mostNegativeNoErrorValue = -5;

	// Token: 0x04001265 RID: 4709
	private const int userDefined1Value = 0x80;

	// Token: 0x04001266 RID: 4710
	private const int noErrorValue = 0;

	// Token: 0x04001267 RID: 4711
	private const int fixErrorSignageMask = 0xFF;

	// Token: 0x04001268 RID: 4712
	private const int maxUserDefinedErrorCount = 0x77;

	// Token: 0x04001269 RID: 4713
	private const string kConnectFailServerSide = "Server failed to approve the connection ";

	// Token: 0x0400126A RID: 4714
	private static readonly global::System.Collections.Generic.Dictionary<global::NetError, string> niceStrings = new global::System.Collections.Generic.Dictionary<global::NetError, string>(global::System.Enum.GetValues(typeof(global::NetError)).Length);
}

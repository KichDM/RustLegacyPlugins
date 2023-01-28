using System;
using System.Collections.Generic;
using uLink;
using UnityEngine;

// Token: 0x02000580 RID: 1408
public sealed class Context : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002F37 RID: 12087 RVA: 0x000B3F70 File Offset: 0x000B2170
	public Context()
	{
	}

	// Token: 0x06002F38 RID: 12088 RVA: 0x000B3F78 File Offset: 0x000B2178
	private void Awake()
	{
		if (global::Context.self && global::Context.self != this)
		{
			global::UnityEngine.Debug.LogError("More than one", this);
			return;
		}
		global::Context.self = this;
		global::Context.network = base.GetComponent<global::uLinkNetworkView>();
		global::UnityEngine.Object.Destroy(base.GetComponent<global::ContextUI>());
	}

	// Token: 0x06002F39 RID: 12089 RVA: 0x000B3FCC File Offset: 0x000B21CC
	private void OnDestroy()
	{
		if (global::Context.self == this)
		{
			global::Context.self = null;
			global::Context.network = null;
		}
	}

	// Token: 0x06002F3A RID: 12090 RVA: 0x000B3FEC File Offset: 0x000B21EC
	public static void Abort(global::Contextual contextual)
	{
		if (!global::Context.self)
		{
			return;
		}
		global::System.Collections.Generic.ICollection<global::Controllable> collection = global::Context.g.GatherControllables(contextual);
		int count = collection.Count;
		if (count > 0)
		{
			foreach (global::Controllable controllable in collection)
			{
				global::ContextServerStage contextServerStage;
				if (global::Context.g.RemoveGet(controllable, out contextServerStage) && contextServerStage.contextual == contextual)
				{
					controllable.isInContextQuery = false;
					global::Context.ClientRequest_Error(controllable.networkViewOwner, "aborted", contextual);
				}
			}
		}
	}

	// Token: 0x06002F3B RID: 12091 RVA: 0x000B40A0 File Offset: 0x000B22A0
	private static void ClientRequest_Error(global::uLink.NetworkPlayer sender, object error, global::UnityEngine.Object errorObject)
	{
		global::Context.ClientRequest_Cancel(sender);
	}

	// Token: 0x06002F3C RID: 12092 RVA: 0x000B40A8 File Offset: 0x000B22A8
	private static void ClientRequest_Cancel(global::uLink.NetworkPlayer sender)
	{
		global::Context.network.RPC("Context:G", sender, new object[0]);
	}

	// Token: 0x06002F3D RID: 12093 RVA: 0x000B40C0 File Offset: 0x000B22C0
	private static void ClientRequest_SucceededImmediate(global::uLink.NetworkPlayer sender)
	{
		global::Context.network.RPC("Context:I", sender, new object[0]);
	}

	// Token: 0x06002F3E RID: 12094 RVA: 0x000B40D8 File Offset: 0x000B22D8
	private static void ClientRequest_FailedImmediate(global::uLink.NetworkPlayer sender)
	{
		global::Context.network.RPC("Context:H", sender, new object[0]);
	}

	// Token: 0x06002F3F RID: 12095 RVA: 0x000B40F0 File Offset: 0x000B22F0
	private static void ClientRequest_SucceededSelection(global::uLink.NetworkPlayer sender)
	{
		global::Context.network.RPC("Context:K", sender, new object[0]);
	}

	// Token: 0x06002F40 RID: 12096 RVA: 0x000B4108 File Offset: 0x000B2308
	private static void ClientRequest_FailedSelection(global::uLink.NetworkPlayer sender)
	{
		global::Context.network.RPC("Context:J", sender, new object[0]);
	}

	// Token: 0x06002F41 RID: 12097 RVA: 0x000B4120 File Offset: 0x000B2320
	private static void ClientRequest_StaleSelection(global::uLink.NetworkPlayer sender)
	{
		global::Context.network.RPC("Context:L", sender, new object[0]);
	}

	// Token: 0x06002F42 RID: 12098 RVA: 0x000B4138 File Offset: 0x000B2338
	private static void ClientRequest_NoOp(global::uLink.NetworkPlayer sender)
	{
		global::Context.network.RPC("Context:F", sender, new object[0]);
	}

	// Token: 0x06002F43 RID: 12099 RVA: 0x000B4150 File Offset: 0x000B2350
	private static void ClientRequest_PromptMenu(global::uLink.NetworkPlayer sender, global::ContextMenuData menu)
	{
		global::Context.network.RPC<global::ContextMenuData>("Context:E", sender, menu);
	}

	// Token: 0x06002F44 RID: 12100 RVA: 0x000B4164 File Offset: 0x000B2364
	private global::ContextServerResponse ExecuteClientResponse_Menu(global::Controllable control, global::Contextual contextual, ulong timestamp, global::ContextExecution execution, out global::ContextMenuData options)
	{
		global::IContextRequestableMenu contextRequestableMenu;
		if (!contextual.AsMenu(out contextRequestableMenu))
		{
			global::UnityEngine.Debug.LogError("IContextRequestable returned menu options but did not implement IContextRequestableMenu!:" + contextual, contextual);
			options = null;
			return global::ContextServerResponse.InvalidCast;
		}
		global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> enumerable = contextRequestableMenu.ContextQueryMenu(control, timestamp);
		if (enumerable == null)
		{
			global::UnityEngine.Debug.LogWarning("ContextQueryMenu returning null means that its a NoOp. Remove this warning if intentional:" + contextual, contextual);
			options = null;
			return global::ContextServerResponse.NoOp;
		}
		global::ContextMenuData contextMenuData = new global::ContextMenuData(enumerable);
		if (contextMenuData.options_length > 0)
		{
			try
			{
				global::Context.g.Add(control, new global::ContextServerStage
				{
					execution = execution,
					contextual = contextual,
					actions = enumerable,
					created_timestamp_client = timestamp,
					created_timestamp_server = global::NetCull.timeInMillis
				});
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, contextual);
				options = null;
				return global::ContextServerResponse.PutInMenuException;
			}
			try
			{
				control.isInContextQuery = true;
			}
			catch (global::System.Exception ex2)
			{
				global::UnityEngine.Debug.LogException(ex2, contextual);
				global::ContextServerStage contextServerStage;
				global::Context.g.RemoveGet(control, out contextServerStage);
				options = null;
				return global::ContextServerResponse.PutInMenuException;
			}
			options = contextMenuData;
			return global::ContextServerResponse.PutInMenu;
		}
		options = null;
		return global::ContextServerResponse.NoMenuOptions;
	}

	// Token: 0x06002F45 RID: 12101 RVA: 0x000B4298 File Offset: 0x000B2498
	private global::ContextServerResponse ExecuteClientResponse_MenuSelection(global::Controllable controllable, global::ContextServerStage context, int name, ulong timestamp)
	{
		if (!context.contextual || !context.contextual.exists)
		{
			global::UnityEngine.Debug.Log("Requestable was destroyed.");
			return global::ContextServerResponse.CouldNotGetPlayerContextContextual;
		}
		if ((byte)(context.execution & global::ContextExecution.Menu) != 2)
		{
			return global::ContextServerResponse.InvalidCast;
		}
		global::IContextRequestableMenu contextRequestableMenu;
		if (!context.contextual.AsMenu(out contextRequestableMenu))
		{
			global::UnityEngine.Debug.LogError("Contextual was flaged to use menu but doesnt implement IContextRequestableMenu", context.contextual);
			return global::ContextServerResponse.InvalidCast;
		}
		int num = 0;
		int num2 = 0;
		foreach (global::ContextActionPrototype contextActionPrototype in context.actions)
		{
			if (contextActionPrototype.name == name)
			{
				switch (contextRequestableMenu.ContextRespondMenu(controllable, contextActionPrototype, timestamp))
				{
				case global::ContextResponse.DoneBreak:
					return global::ContextServerResponse.ImmediateSuccess;
				case global::ContextResponse.DoneContinue:
					num2++;
					break;
				case global::ContextResponse.FailBreak:
					return global::ContextServerResponse.ImmediateFail;
				case global::ContextResponse.FailContinue:
					num2++;
					num++;
					break;
				case global::ContextResponse.SendUpdate:
					global::UnityEngine.Debug.LogError("TODO");
					break;
				}
			}
		}
		if (num2 == 0)
		{
			return global::ContextServerResponse.NoSelection;
		}
		if (num2 > num)
		{
			return global::ContextServerResponse.SelectionSuccess;
		}
		return global::ContextServerResponse.SelectionFail;
	}

	// Token: 0x06002F46 RID: 12102 RVA: 0x000B43E4 File Offset: 0x000B25E4
	private global::ContextServerResponse ExecuteClientResponse_Quick(global::Controllable control, global::Contextual contextual, ulong timestamp, bool immediate)
	{
		global::IContextRequestableQuick contextRequestableQuick;
		if (!contextual.AsQuick(out contextRequestableQuick))
		{
			global::UnityEngine.Debug.LogError("instance did not implement IContextRequestableQuick!:" + contextual.implementor, contextual);
			return global::ContextServerResponse.InvalidCast;
		}
		global::ContextResponse contextResponse = contextRequestableQuick.ContextRespondQuick(control, timestamp);
		if (contextResponse != global::ContextResponse.DoneBreak && contextResponse != global::ContextResponse.DoneContinue)
		{
			return (!immediate) ? global::ContextServerResponse.SelectionFail : global::ContextServerResponse.ImmediateFail;
		}
		return (!immediate) ? global::ContextServerResponse.SelectionSuccess : global::ContextServerResponse.ImmediateSuccess;
	}

	// Token: 0x06002F47 RID: 12103 RVA: 0x000B4450 File Offset: 0x000B2650
	private global::ContextServerResponse ExecuteClientResponse_MenuCancel(global::Controllable controllable, global::ContextServerStage context, ulong timestamp)
	{
		return global::ContextServerResponse.NoOp;
	}

	// Token: 0x06002F48 RID: 12104 RVA: 0x000B4454 File Offset: 0x000B2654
	private static global::ContextServerResponse? DEQUEUE(global::uLink.NetworkPlayer sender, out global::Controllable control, out global::ContextServerStage context, out global::Contextual contextual)
	{
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		if (!serverManagement)
		{
			contextual = null;
			control = null;
			context = null;
			return new global::ContextServerResponse?(global::ContextServerResponse.CouldNotGetServerManagement);
		}
		global::PlayerClient playerClient;
		if (!serverManagement.GetPlayerClient(sender, out playerClient))
		{
			contextual = null;
			control = null;
			context = null;
			return new global::ContextServerResponse?(global::ContextServerResponse.CouldNotGetPlayerClient);
		}
		control = playerClient.controllable;
		if (!control)
		{
			contextual = null;
			context = null;
			return new global::ContextServerResponse?(global::ContextServerResponse.CouldNotGetPlayerControllable);
		}
		if (!global::Context.g.RemoveGet(control, out context))
		{
			contextual = null;
			return new global::ContextServerResponse?(global::ContextServerResponse.CouldNotGetPlayerContext);
		}
		control.isInContextQuery = false;
		global::Contextual contextual2;
		contextual = (contextual2 = context.contextual);
		if (contextual2 && contextual.exists)
		{
			return null;
		}
		return new global::ContextServerResponse?(global::ContextServerResponse.CouldNotGetPlayerContextContextual);
	}

	// Token: 0x06002F49 RID: 12105 RVA: 0x000B4518 File Offset: 0x000B2718
	private static global::ContextServerResponse? DEQUEUE(global::uLink.NetworkPlayer sender, out global::Controllable control, out global::Contextual contextual)
	{
		global::ContextServerStage contextServerStage;
		return global::Context.DEQUEUE(sender, out control, out contextServerStage, out contextual);
	}

	// Token: 0x06002F4A RID: 12106 RVA: 0x000B4530 File Offset: 0x000B2730
	private static global::ContextServerResponse? DEQUEUE(global::uLink.NetworkPlayer sender, out global::Controllable control, out global::ContextServerStage context)
	{
		global::Contextual contextual;
		return global::Context.DEQUEUE(sender, out control, out context, out contextual);
	}

	// Token: 0x06002F4B RID: 12107 RVA: 0x000B4548 File Offset: 0x000B2748
	private static global::ContextServerResponse? DEQUEUE(global::uLink.NetworkPlayer sender, out global::Controllable control)
	{
		global::ContextServerStage contextServerStage;
		global::Contextual contextual;
		return global::Context.DEQUEUE(sender, out control, out contextServerStage, out contextual);
	}

	// Token: 0x06002F4C RID: 12108 RVA: 0x000B4560 File Offset: 0x000B2760
	private global::ContextServerResponse ClientSelection_Menu(int name, ref global::uLink.NetworkMessageInfo info)
	{
		global::Controllable controllable;
		global::ContextServerStage context;
		global::ContextServerResponse? contextServerResponse = global::Context.DEQUEUE(info.sender, out controllable, out context);
		return (contextServerResponse == null) ? this.ExecuteClientResponse_MenuSelection(controllable, context, name, info.timestampInMillis) : contextServerResponse.Value;
	}

	// Token: 0x06002F4D RID: 12109 RVA: 0x000B45A8 File Offset: 0x000B27A8
	private global::ContextServerResponse ClientSelection_Quick(ref global::uLink.NetworkMessageInfo info)
	{
		global::Controllable control;
		global::Contextual contextual;
		global::ContextServerResponse? contextServerResponse = global::Context.DEQUEUE(info.sender, out control, out contextual);
		return (contextServerResponse == null) ? this.ExecuteClientResponse_Quick(control, contextual, info.timestampInMillis, false) : contextServerResponse.Value;
	}

	// Token: 0x06002F4E RID: 12110 RVA: 0x000B45F0 File Offset: 0x000B27F0
	private global::ContextServerResponse ClientSelection_Cancel(ref global::uLink.NetworkMessageInfo info)
	{
		global::Controllable controllable;
		global::ContextServerStage context;
		global::ContextServerResponse? contextServerResponse = global::Context.DEQUEUE(info.sender, out controllable, out context);
		return (contextServerResponse == null) ? this.ExecuteClientResponse_MenuCancel(controllable, context, info.timestampInMillis) : contextServerResponse.Value;
	}

	// Token: 0x06002F4F RID: 12111 RVA: 0x000B4638 File Offset: 0x000B2838
	private static void ISSUE_RESPONSE(global::ContextServerResponse response, global::uLink.NetworkPlayer sender, global::ContextMenuData menu)
	{
		switch (response)
		{
		case global::ContextServerResponse.ImmediateSuccess:
			global::Context.ClientRequest_SucceededImmediate(sender);
			break;
		case global::ContextServerResponse.ImmediateFail:
			global::Context.ClientRequest_FailedImmediate(sender);
			break;
		case global::ContextServerResponse.InvalidCast:
		case global::ContextServerResponse.NoMenuOptions:
		case global::ContextServerResponse.PutInMenuException:
		case global::ContextServerResponse.NoOp:
			global::Context.ClientRequest_NoOp(sender);
			break;
		case global::ContextServerResponse.PutInMenu:
			if (menu == null)
			{
				throw new global::System.ArgumentNullException("menu");
			}
			global::Context.ClientRequest_PromptMenu(sender, menu);
			break;
		case global::ContextServerResponse.NoSelection:
		case global::ContextServerResponse.CouldNotGetPlayerContextContextual:
			global::Context.ClientRequest_StaleSelection(sender);
			break;
		case global::ContextServerResponse.SelectionSuccess:
			global::Context.ClientRequest_SucceededSelection(sender);
			break;
		case global::ContextServerResponse.SelectionFail:
			global::Context.ClientRequest_FailedSelection(sender);
			break;
		case global::ContextServerResponse.CouldNotGetPlayerContext:
			global::Context.ClientRequest_Cancel(sender);
			break;
		}
	}

	// Token: 0x06002F50 RID: 12112 RVA: 0x000B4700 File Offset: 0x000B2900
	private global::ContextServerResponse ClientQuery(global::Controllable control, global::Contextual contextual, ulong timestamp, out global::ContextMenuData options)
	{
		global::IContextRequestable @interface = contextual.@interface;
		global::ContextExecution contextExecution = @interface.ContextQuery(control, timestamp);
		global::ContextServerResponse result;
		switch ((byte)(contextExecution & (global::ContextExecution.Quick | global::ContextExecution.Menu)))
		{
		case 0:
			options = null;
			result = global::ContextServerResponse.NoOp;
			break;
		case 1:
			options = null;
			result = this.ExecuteClientResponse_Quick(control, contextual, timestamp, true);
			break;
		case 2:
			result = this.ExecuteClientResponse_Menu(control, contextual, timestamp, contextExecution, out options);
			break;
		case 3:
		{
			global::ContextServerResponse contextServerResponse;
			result = (contextServerResponse = this.ExecuteClientResponse_Menu(control, contextual, timestamp, contextExecution, out options));
			bool flag;
			if (contextServerResponse != global::ContextServerResponse.NoMenuOptions)
			{
				flag = (contextServerResponse == global::ContextServerResponse.PutInMenuException && contextual.RouteToQuickOnEmptyMenu(control, timestamp, true));
			}
			else
			{
				flag = contextual.RouteToQuickOnEmptyMenu(control, timestamp, false);
			}
			if (flag)
			{
				result = this.ExecuteClientResponse_Quick(control, contextual, timestamp, true);
			}
			break;
		}
		default:
			throw new global::System.NotImplementedException();
		}
		return result;
	}

	// Token: 0x06002F51 RID: 12113 RVA: 0x000B47D8 File Offset: 0x000B29D8
	[global::UnityEngine.RPC]
	private void A(global::NetEntityID hit, global::uLink.NetworkMessageInfo info)
	{
		global::Contextual contextual;
		if (!global::Contextual.ContextOf(hit, out contextual))
		{
			global::Context.ClientRequest_Error(info.sender, "Did not find contextual", null);
			return;
		}
		if (contextual.shuttingDown)
		{
			global::Context.ClientRequest_Error(info.sender, "Contextual was shutting down", null);
		}
		else if (global::Context.g.SoleAccessObtained(contextual))
		{
			global::Context.ClientRequest_Error(info.sender, "observed is being accessed elswhere", contextual);
		}
		else
		{
			global::uLink.NetworkPlayer sender = info.sender;
			global::PlayerClient playerClient;
			if (!global::ServerManagement.Get().GetPlayerClient(sender, out playerClient))
			{
				global::Context.ClientRequest_Error(info.sender, "sender did not have a player client " + sender, contextual);
			}
			else
			{
				global::Controllable controllable = playerClient.controllable;
				if (!controllable)
				{
					global::Context.ClientRequest_Error(info.sender, "sender's controllable is null ( unset or destroyed )", playerClient);
				}
				else
				{
					global::UnityEngine.Collider collider = contextual.collider;
					bool flag;
					if (collider && collider.enabled && !collider.attachedRigidbody)
					{
						global::UnityEngine.Vector3 eyesOrigin = controllable.eyesOrigin;
						global::UnityEngine.Vector3 vector = collider.ClosestPointOnBounds(eyesOrigin);
						global::UnityEngine.Vector3 vector2 = vector - eyesOrigin;
						global::UnityEngine.Vector3 center = collider.bounds.center;
						float num;
						if (eyesOrigin == vector)
						{
							num = 0f;
						}
						else
						{
							global::UnityEngine.Plane plane;
							plane..ctor(vector2, eyesOrigin);
							num = plane.GetDistanceToPoint(center);
						}
						global::UnityEngine.RaycastHit raycastHit;
						global::Contextual contextual2;
						flag = ((num > 0f && global::UnityEngine.Physics.Raycast(eyesOrigin, vector2, ref raycastHit, num * 1.5f + 0.01f, -0xC030005) && (raycastHit.collider == collider || (global::Contextual.ContextOf(raycastHit.collider, out contextual2) && contextual2 == contextual))) || (global::UnityEngine.Physics.Linecast(eyesOrigin, center, ref raycastHit, -0xC030005) && (raycastHit.collider == collider || (global::Contextual.ContextOf(raycastHit.collider, out contextual2) && contextual2 == contextual))) || (global::UnityEngine.Physics.Raycast(eyesOrigin, controllable.eyesRotation * global::UnityEngine.Vector3.forward, ref raycastHit, 15f, -0xC030005) & (raycastHit.collider == collider || (global::Contextual.ContextOf(raycastHit.collider, out contextual2) && contextual2 == contextual))));
					}
					else
					{
						flag = true;
					}
					if (flag)
					{
						global::ContextMenuData menu;
						global::Context.ISSUE_RESPONSE(this.ClientQuery(controllable, contextual, info.timestampInMillis, out menu), info.sender, menu);
					}
					else
					{
						global::Context.ClientRequest_Error(info.sender, "could not validate origin to destination", playerClient);
					}
				}
			}
		}
	}

	// Token: 0x06002F52 RID: 12114 RVA: 0x000B4A84 File Offset: 0x000B2C84
	[global::UnityEngine.RPC]
	private void B(global::uLink.NetworkMessageInfo info)
	{
		global::Context.ISSUE_RESPONSE(this.ClientSelection_Quick(ref info), info.sender, null);
	}

	// Token: 0x06002F53 RID: 12115 RVA: 0x000B4A9C File Offset: 0x000B2C9C
	[global::UnityEngine.RPC]
	private void C(int name, global::uLink.NetworkMessageInfo info)
	{
		global::Context.ISSUE_RESPONSE(this.ClientSelection_Menu(name, ref info), info.sender, null);
	}

	// Token: 0x06002F54 RID: 12116 RVA: 0x000B4AB4 File Offset: 0x000B2CB4
	[global::UnityEngine.RPC]
	private void D(global::uLink.NetworkMessageInfo info)
	{
		global::Context.ISSUE_RESPONSE(this.ClientSelection_Cancel(ref info), info.sender, null);
	}

	// Token: 0x06002F55 RID: 12117 RVA: 0x000B4ACC File Offset: 0x000B2CCC
	[global::UnityEngine.RPC]
	private void E(global::ContextMenuData options, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002F56 RID: 12118 RVA: 0x000B4AD0 File Offset: 0x000B2CD0
	[global::UnityEngine.RPC]
	private void F(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002F57 RID: 12119 RVA: 0x000B4AD4 File Offset: 0x000B2CD4
	[global::UnityEngine.RPC]
	private void G(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002F58 RID: 12120 RVA: 0x000B4AD8 File Offset: 0x000B2CD8
	[global::UnityEngine.RPC]
	private void H(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002F59 RID: 12121 RVA: 0x000B4ADC File Offset: 0x000B2CDC
	[global::UnityEngine.RPC]
	private void I(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002F5A RID: 12122 RVA: 0x000B4AE0 File Offset: 0x000B2CE0
	[global::UnityEngine.RPC]
	private void J(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002F5B RID: 12123 RVA: 0x000B4AE4 File Offset: 0x000B2CE4
	[global::UnityEngine.RPC]
	private void K(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002F5C RID: 12124 RVA: 0x000B4AE8 File Offset: 0x000B2CE8
	[global::UnityEngine.RPC]
	private void L(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002F5D RID: 12125 RVA: 0x000B4AEC File Offset: 0x000B2CEC
	[global::UnityEngine.RPC]
	private void M(global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x0400190A RID: 6410
	private const string kRPCPrefix = "Context:";

	// Token: 0x0400190B RID: 6411
	private const string kRPC_RequestFromClient = "Context:A";

	// Token: 0x0400190C RID: 6412
	private const string kRPC_QuickTapFromClient = "Context:B";

	// Token: 0x0400190D RID: 6413
	private const string kRPC_SelectedOptionFromClient = "Context:C";

	// Token: 0x0400190E RID: 6414
	private const string kRPC_NoSelectionFromClient = "Context:D";

	// Token: 0x0400190F RID: 6415
	private const string kRPC_ReadOptionsFromServer = "Context:E";

	// Token: 0x04001910 RID: 6416
	private const string kRPC_NoOpFromServer = "Context:F";

	// Token: 0x04001911 RID: 6417
	private const string kRPC_CancelFromServer = "Context:G";

	// Token: 0x04001912 RID: 6418
	private const string kRPC_FailedImmediateFromServer = "Context:H";

	// Token: 0x04001913 RID: 6419
	private const string kRPC_SuccessImmediateFromServer = "Context:I";

	// Token: 0x04001914 RID: 6420
	private const string kRPC_FailedSelectionFromServer = "Context:J";

	// Token: 0x04001915 RID: 6421
	private const string kRPC_SuccessSelectionFromServer = "Context:K";

	// Token: 0x04001916 RID: 6422
	private const string kRPC_StaleSelectionFromServer = "Context:L";

	// Token: 0x04001917 RID: 6423
	private const string kRPC_RetryFromServer = "Context:M";

	// Token: 0x04001918 RID: 6424
	private static global::Context self;

	// Token: 0x04001919 RID: 6425
	private static global::uLinkNetworkView network;

	// Token: 0x02000581 RID: 1409
	private static class g
	{
		// Token: 0x06002F5E RID: 12126 RVA: 0x000B4AF0 File Offset: 0x000B2CF0
		static g()
		{
			global::Controllable.onDestroyInContextQuery += global::Context.g.RespondToDestroyInContextQuery;
			global::Context.g.serverContextDictionary = new global::System.Collections.Generic.Dictionary<global::Controllable, global::ContextServerStage>();
		}

		// Token: 0x06002F5F RID: 12127 RVA: 0x000B4B10 File Offset: 0x000B2D10
		private static void RespondToDestroyInContextQuery(global::Controllable controllable)
		{
			global::ContextServerStage contextServerStage;
			global::Context.g.RemoveGet(controllable, out contextServerStage);
		}

		// Token: 0x06002F60 RID: 12128 RVA: 0x000B4B28 File Offset: 0x000B2D28
		public static void Add(global::Controllable controllable, global::ContextServerStage context)
		{
			if (context.contextual.soleAccessObtained)
			{
				throw new global::System.ArgumentException("context had already obtained sole access", "context");
			}
			global::Context.g.serverContextDictionary.Add(controllable, context);
			context.contextual.soleAccessObtained = context.contextual.isSoleAccess;
			context.contextual.accessCount++;
		}

		// Token: 0x06002F61 RID: 12129 RVA: 0x000B4B8C File Offset: 0x000B2D8C
		public static bool RemoveGet(global::Controllable controllable, out global::ContextServerStage context)
		{
			if (global::Context.g.serverContextDictionary.TryGetValue(controllable, out context))
			{
				context.contextual.soleAccessObtained = false;
				global::Context.g.serverContextDictionary.Remove(controllable);
				context.contextual.accessCount--;
				return true;
			}
			return false;
		}

		// Token: 0x06002F62 RID: 12130 RVA: 0x000B4BDC File Offset: 0x000B2DDC
		public static bool SoleAccessObtained(global::Contextual script)
		{
			return script && script.soleAccessObtained && script.isSoleAccess;
		}

		// Token: 0x06002F63 RID: 12131 RVA: 0x000B4C00 File Offset: 0x000B2E00
		public static global::System.Collections.Generic.ICollection<global::Controllable> GatherControllables(global::Contextual contextual)
		{
			if (contextual.accessCount > 0)
			{
				foreach (global::System.Collections.Generic.KeyValuePair<global::Controllable, global::ContextServerStage> keyValuePair in global::Context.g.serverContextDictionary)
				{
					if (keyValuePair.Value.contextual == contextual)
					{
						global::System.Collections.Generic.List<global::Controllable> list = new global::System.Collections.Generic.List<global::Controllable>(contextual.accessCount);
						list.Add(keyValuePair.Key);
						int num = contextual.accessCount - 1;
						global::System.Collections.Generic.Dictionary<global::Controllable, global::ContextServerStage>.Enumerator enumerator;
						while (num > 0 && enumerator.MoveNext())
						{
							keyValuePair = enumerator.Current;
							if (keyValuePair.Value.contextual == contextual)
							{
								list.Add(keyValuePair.Key);
								num--;
							}
						}
						return list;
					}
				}
			}
			return global::Context.g.EmptyArray.Controllable;
		}

		// Token: 0x0400191A RID: 6426
		private static readonly global::System.Collections.Generic.Dictionary<global::Controllable, global::ContextServerStage> serverContextDictionary;

		// Token: 0x02000582 RID: 1410
		private static class EmptyArray
		{
			// Token: 0x06002F64 RID: 12132 RVA: 0x000B4CFC File Offset: 0x000B2EFC
			// Note: this type is marked as 'beforefieldinit'.
			static EmptyArray()
			{
			}

			// Token: 0x0400191B RID: 6427
			public static readonly global::Controllable[] Controllable = new global::Controllable[0];
		}
	}
}

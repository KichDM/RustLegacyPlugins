using System;
using UnityEngine;

// Token: 0x02000179 RID: 377
public abstract class IDLocalCharacter : global::IDLocal
{
	// Token: 0x06000A5F RID: 2655 RVA: 0x0002A770 File Offset: 0x00028970
	protected IDLocalCharacter()
	{
	}

	// Token: 0x170002A5 RID: 677
	// (get) Token: 0x06000A60 RID: 2656 RVA: 0x0002A778 File Offset: 0x00028978
	public global::Character idMain
	{
		get
		{
			return (global::Character)this.idMain;
		}
	}

	// Token: 0x170002A6 RID: 678
	// (get) Token: 0x06000A61 RID: 2657 RVA: 0x0002A788 File Offset: 0x00028988
	public global::Character character
	{
		get
		{
			return (global::Character)this.idMain;
		}
	}

	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x06000A62 RID: 2658 RVA: 0x0002A798 File Offset: 0x00028998
	public global::HitBoxSystem hitBoxSystem
	{
		get
		{
			return this.idMain.hitBoxSystem;
		}
	}

	// Token: 0x170002A8 RID: 680
	// (get) Token: 0x06000A63 RID: 2659 RVA: 0x0002A7A8 File Offset: 0x000289A8
	public global::RecoilSimulation recoilSimulation
	{
		get
		{
			return this.idMain.recoilSimulation;
		}
	}

	// Token: 0x170002A9 RID: 681
	// (get) Token: 0x06000A64 RID: 2660 RVA: 0x0002A7B8 File Offset: 0x000289B8
	public global::PlayerClient playerClient
	{
		get
		{
			return this.idMain.playerClient;
		}
	}

	// Token: 0x170002AA RID: 682
	// (get) Token: 0x06000A65 RID: 2661 RVA: 0x0002A7C8 File Offset: 0x000289C8
	public bool controlled
	{
		get
		{
			return this.idMain.controlled;
		}
	}

	// Token: 0x170002AB RID: 683
	// (get) Token: 0x06000A66 RID: 2662 RVA: 0x0002A7D8 File Offset: 0x000289D8
	public bool playerControlled
	{
		get
		{
			return this.idMain.playerControlled;
		}
	}

	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06000A67 RID: 2663 RVA: 0x0002A7E8 File Offset: 0x000289E8
	public bool aiControlled
	{
		get
		{
			return this.idMain.aiControlled;
		}
	}

	// Token: 0x170002AD RID: 685
	// (get) Token: 0x06000A68 RID: 2664 RVA: 0x0002A7F8 File Offset: 0x000289F8
	public bool localPlayerControlled
	{
		get
		{
			return this.idMain.localPlayerControlled;
		}
	}

	// Token: 0x170002AE RID: 686
	// (get) Token: 0x06000A69 RID: 2665 RVA: 0x0002A808 File Offset: 0x00028A08
	public bool remotePlayerControlled
	{
		get
		{
			return this.idMain.remotePlayerControlled;
		}
	}

	// Token: 0x170002AF RID: 687
	// (get) Token: 0x06000A6A RID: 2666 RVA: 0x0002A818 File Offset: 0x00028A18
	public bool localAIControlled
	{
		get
		{
			return this.idMain.localAIControlled;
		}
	}

	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x06000A6B RID: 2667 RVA: 0x0002A828 File Offset: 0x00028A28
	public bool remoteAIControlled
	{
		get
		{
			return this.idMain.remoteAIControlled;
		}
	}

	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x06000A6C RID: 2668 RVA: 0x0002A838 File Offset: 0x00028A38
	public bool localControlled
	{
		get
		{
			return this.idMain.localControlled;
		}
	}

	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x06000A6D RID: 2669 RVA: 0x0002A848 File Offset: 0x00028A48
	public bool remoteControlled
	{
		get
		{
			return this.idMain.remoteControlled;
		}
	}

	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x06000A6E RID: 2670 RVA: 0x0002A858 File Offset: 0x00028A58
	public global::Controllable controllable
	{
		get
		{
			return this.idMain.controllable;
		}
	}

	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x06000A6F RID: 2671 RVA: 0x0002A868 File Offset: 0x00028A68
	public global::Controllable controlledControllable
	{
		get
		{
			return this.idMain.controlledControllable;
		}
	}

	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x06000A70 RID: 2672 RVA: 0x0002A878 File Offset: 0x00028A78
	public global::Controllable playerControlledControllable
	{
		get
		{
			return this.idMain.playerControlledControllable;
		}
	}

	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x06000A71 RID: 2673 RVA: 0x0002A888 File Offset: 0x00028A88
	public global::Controllable aiControlledControllable
	{
		get
		{
			return this.idMain.aiControlledControllable;
		}
	}

	// Token: 0x170002B7 RID: 695
	// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0002A898 File Offset: 0x00028A98
	public global::Controllable localPlayerControlledControllable
	{
		get
		{
			return this.idMain.localPlayerControlledControllable;
		}
	}

	// Token: 0x170002B8 RID: 696
	// (get) Token: 0x06000A73 RID: 2675 RVA: 0x0002A8A8 File Offset: 0x00028AA8
	public global::Controllable localAIControlledControllable
	{
		get
		{
			return this.idMain.localAIControlledControllable;
		}
	}

	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x06000A74 RID: 2676 RVA: 0x0002A8B8 File Offset: 0x00028AB8
	public global::Controllable remotePlayerControlledControllable
	{
		get
		{
			return this.idMain.remotePlayerControlledControllable;
		}
	}

	// Token: 0x170002BA RID: 698
	// (get) Token: 0x06000A75 RID: 2677 RVA: 0x0002A8C8 File Offset: 0x00028AC8
	public global::Controllable remoteAIControlledControllable
	{
		get
		{
			return this.idMain.remoteAIControlledControllable;
		}
	}

	// Token: 0x170002BB RID: 699
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0002A8D8 File Offset: 0x00028AD8
	public string npcName
	{
		get
		{
			return this.idMain.npcName;
		}
	}

	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0002A8E8 File Offset: 0x00028AE8
	public global::Character previousCharacter
	{
		get
		{
			return this.idMain.previousCharacter;
		}
	}

	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0002A8F8 File Offset: 0x00028AF8
	public global::Character rootCharacter
	{
		get
		{
			return this.idMain.rootCharacter;
		}
	}

	// Token: 0x170002BE RID: 702
	// (get) Token: 0x06000A79 RID: 2681 RVA: 0x0002A908 File Offset: 0x00028B08
	public global::Character nextCharacter
	{
		get
		{
			return this.idMain.nextCharacter;
		}
	}

	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06000A7A RID: 2682 RVA: 0x0002A918 File Offset: 0x00028B18
	public global::Character masterCharacter
	{
		get
		{
			return this.idMain.masterCharacter;
		}
	}

	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0002A928 File Offset: 0x00028B28
	public global::Controllable masterControllable
	{
		get
		{
			return this.idMain.masterControllable;
		}
	}

	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06000A7C RID: 2684 RVA: 0x0002A938 File Offset: 0x00028B38
	public global::Controllable rootControllable
	{
		get
		{
			return this.idMain.rootControllable;
		}
	}

	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0002A948 File Offset: 0x00028B48
	public global::Controllable nextControllable
	{
		get
		{
			return this.idMain.nextControllable;
		}
	}

	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0002A958 File Offset: 0x00028B58
	public global::Controllable previousControllable
	{
		get
		{
			return this.idMain.previousControllable;
		}
	}

	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0002A968 File Offset: 0x00028B68
	public int controlDepth
	{
		get
		{
			return this.idMain.controlDepth;
		}
	}

	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x06000A80 RID: 2688 RVA: 0x0002A978 File Offset: 0x00028B78
	public int controlCount
	{
		get
		{
			return this.idMain.controlCount;
		}
	}

	// Token: 0x170002C6 RID: 710
	// (get) Token: 0x06000A81 RID: 2689 RVA: 0x0002A988 File Offset: 0x00028B88
	public string controllerClassName
	{
		get
		{
			return this.idMain.controllerClassName;
		}
	}

	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0002A998 File Offset: 0x00028B98
	public bool controlOverridden
	{
		get
		{
			return this.idMain.controlOverridden;
		}
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x0002A9A8 File Offset: 0x00028BA8
	public bool ControlOverriddenBy(global::Controllable controllable)
	{
		return this.idMain.ControlOverriddenBy(controllable);
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x0002A9B8 File Offset: 0x00028BB8
	public bool ControlOverriddenBy(global::Controller controller)
	{
		return this.idMain.ControlOverriddenBy(controller);
	}

	// Token: 0x06000A85 RID: 2693 RVA: 0x0002A9C8 File Offset: 0x00028BC8
	public bool ControlOverriddenBy(global::Character character)
	{
		return this.idMain.ControlOverriddenBy(character);
	}

	// Token: 0x06000A86 RID: 2694 RVA: 0x0002A9D8 File Offset: 0x00028BD8
	public bool ControlOverriddenBy(global::IDMain main)
	{
		return this.idMain.ControlOverriddenBy(main);
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x0002A9E8 File Offset: 0x00028BE8
	public bool ControlOverriddenBy(global::IDBase idBase)
	{
		return this.idMain.ControlOverriddenBy(idBase);
	}

	// Token: 0x06000A88 RID: 2696 RVA: 0x0002A9F8 File Offset: 0x00028BF8
	public bool ControlOverriddenBy(global::IDLocalCharacter idLocal)
	{
		return this.idMain.ControlOverriddenBy(idLocal);
	}

	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06000A89 RID: 2697 RVA: 0x0002AA08 File Offset: 0x00028C08
	public bool overridingControl
	{
		get
		{
			return this.idMain.overridingControl;
		}
	}

	// Token: 0x06000A8A RID: 2698 RVA: 0x0002AA18 File Offset: 0x00028C18
	public bool OverridingControlOf(global::Controllable controllable)
	{
		return this.idMain.OverridingControlOf(controllable);
	}

	// Token: 0x06000A8B RID: 2699 RVA: 0x0002AA28 File Offset: 0x00028C28
	public bool OverridingControlOf(global::Controller controller)
	{
		return this.idMain.OverridingControlOf(controller);
	}

	// Token: 0x06000A8C RID: 2700 RVA: 0x0002AA38 File Offset: 0x00028C38
	public bool OverridingControlOf(global::Character character)
	{
		return this.idMain.OverridingControlOf(character);
	}

	// Token: 0x06000A8D RID: 2701 RVA: 0x0002AA48 File Offset: 0x00028C48
	public bool OverridingControlOf(global::IDMain main)
	{
		return this.idMain.OverridingControlOf(main);
	}

	// Token: 0x06000A8E RID: 2702 RVA: 0x0002AA58 File Offset: 0x00028C58
	public bool OverridingControlOf(global::IDBase idBase)
	{
		return this.idMain.OverridingControlOf(idBase);
	}

	// Token: 0x06000A8F RID: 2703 RVA: 0x0002AA68 File Offset: 0x00028C68
	public bool OverridingControlOf(global::IDLocalCharacter idLocal)
	{
		return this.idMain.OverridingControlOf(idLocal);
	}

	// Token: 0x170002C9 RID: 713
	// (get) Token: 0x06000A90 RID: 2704 RVA: 0x0002AA78 File Offset: 0x00028C78
	public bool assignedControl
	{
		get
		{
			return this.idMain.assignedControl;
		}
	}

	// Token: 0x06000A91 RID: 2705 RVA: 0x0002AA88 File Offset: 0x00028C88
	public bool AssignedControlOf(global::Controllable controllable)
	{
		return this.idMain.AssignedControlOf(controllable);
	}

	// Token: 0x06000A92 RID: 2706 RVA: 0x0002AA98 File Offset: 0x00028C98
	public bool AssignedControlOf(global::Controller controller)
	{
		return this.idMain.AssignedControlOf(controller);
	}

	// Token: 0x06000A93 RID: 2707 RVA: 0x0002AAA8 File Offset: 0x00028CA8
	public bool AssignedControlOf(global::IDMain character)
	{
		return this.idMain.AssignedControlOf(character);
	}

	// Token: 0x06000A94 RID: 2708 RVA: 0x0002AAB8 File Offset: 0x00028CB8
	public bool AssignedControlOf(global::IDBase idBase)
	{
		return this.idMain.AssignedControlOf(idBase);
	}

	// Token: 0x06000A95 RID: 2709 RVA: 0x0002AAC8 File Offset: 0x00028CC8
	public global::RelativeControl RelativeControlTo(global::Controllable controllable)
	{
		return this.idMain.RelativeControlTo(controllable);
	}

	// Token: 0x06000A96 RID: 2710 RVA: 0x0002AAD8 File Offset: 0x00028CD8
	public global::RelativeControl RelativeControlTo(global::Controller controller)
	{
		return this.idMain.RelativeControlTo(controller);
	}

	// Token: 0x06000A97 RID: 2711 RVA: 0x0002AAE8 File Offset: 0x00028CE8
	public global::RelativeControl RelativeControlTo(global::Character character)
	{
		return this.idMain.RelativeControlTo(character);
	}

	// Token: 0x06000A98 RID: 2712 RVA: 0x0002AAF8 File Offset: 0x00028CF8
	public global::RelativeControl RelativeControlTo(global::IDMain main)
	{
		return this.idMain.RelativeControlTo(main);
	}

	// Token: 0x06000A99 RID: 2713 RVA: 0x0002AB08 File Offset: 0x00028D08
	public global::RelativeControl RelativeControlTo(global::IDLocalCharacter idLocal)
	{
		return this.idMain.RelativeControlTo(idLocal);
	}

	// Token: 0x06000A9A RID: 2714 RVA: 0x0002AB18 File Offset: 0x00028D18
	public global::RelativeControl RelativeControlTo(global::IDBase idBase)
	{
		return this.idMain.RelativeControlTo(idBase);
	}

	// Token: 0x06000A9B RID: 2715 RVA: 0x0002AB28 File Offset: 0x00028D28
	public global::RelativeControl RelativeControlFrom(global::Controllable controllable)
	{
		return this.idMain.RelativeControlFrom(controllable);
	}

	// Token: 0x06000A9C RID: 2716 RVA: 0x0002AB38 File Offset: 0x00028D38
	public global::RelativeControl RelativeControlFrom(global::Controller controller)
	{
		return this.idMain.RelativeControlFrom(controller);
	}

	// Token: 0x06000A9D RID: 2717 RVA: 0x0002AB48 File Offset: 0x00028D48
	public global::RelativeControl RelativeControlFrom(global::Character character)
	{
		return this.idMain.RelativeControlFrom(character);
	}

	// Token: 0x06000A9E RID: 2718 RVA: 0x0002AB58 File Offset: 0x00028D58
	public global::RelativeControl RelativeControlFrom(global::IDMain main)
	{
		return this.idMain.RelativeControlFrom(main);
	}

	// Token: 0x06000A9F RID: 2719 RVA: 0x0002AB68 File Offset: 0x00028D68
	public global::RelativeControl RelativeControlFrom(global::IDLocalCharacter idLocal)
	{
		return this.idMain.RelativeControlFrom(idLocal);
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x0002AB78 File Offset: 0x00028D78
	public global::RelativeControl RelativeControlFrom(global::IDBase idBase)
	{
		return this.idMain.RelativeControlFrom(idBase);
	}

	// Token: 0x170002CA RID: 714
	// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x0002AB88 File Offset: 0x00028D88
	public global::Controller controller
	{
		get
		{
			return this.idMain.controller;
		}
	}

	// Token: 0x170002CB RID: 715
	// (get) Token: 0x06000AA2 RID: 2722 RVA: 0x0002AB98 File Offset: 0x00028D98
	public global::Controller controlledController
	{
		get
		{
			return this.idMain.controlledController;
		}
	}

	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x0002ABA8 File Offset: 0x00028DA8
	public global::Controller playerControlledController
	{
		get
		{
			return this.idMain.playerControlledController;
		}
	}

	// Token: 0x170002CD RID: 717
	// (get) Token: 0x06000AA4 RID: 2724 RVA: 0x0002ABB8 File Offset: 0x00028DB8
	public global::Controller aiControlledController
	{
		get
		{
			return this.idMain.aiControlledController;
		}
	}

	// Token: 0x170002CE RID: 718
	// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x0002ABC8 File Offset: 0x00028DC8
	public global::Controller localPlayerControlledController
	{
		get
		{
			return this.idMain.localPlayerControlledController;
		}
	}

	// Token: 0x170002CF RID: 719
	// (get) Token: 0x06000AA6 RID: 2726 RVA: 0x0002ABD8 File Offset: 0x00028DD8
	public global::Controller localAIControlledController
	{
		get
		{
			return this.idMain.localAIControlledController;
		}
	}

	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x0002ABE8 File Offset: 0x00028DE8
	public global::Controller remotePlayerControlledController
	{
		get
		{
			return this.idMain.remotePlayerControlledController;
		}
	}

	// Token: 0x170002D1 RID: 721
	// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x0002ABF8 File Offset: 0x00028DF8
	public global::Controller remoteAIControlledController
	{
		get
		{
			return this.idMain.remoteAIControlledController;
		}
	}

	// Token: 0x170002D2 RID: 722
	// (get) Token: 0x06000AA9 RID: 2729 RVA: 0x0002AC08 File Offset: 0x00028E08
	public global::Controller masterController
	{
		get
		{
			return this.idMain.masterController;
		}
	}

	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06000AAA RID: 2730 RVA: 0x0002AC18 File Offset: 0x00028E18
	public global::Controller rootController
	{
		get
		{
			return this.idMain.rootController;
		}
	}

	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06000AAB RID: 2731 RVA: 0x0002AC28 File Offset: 0x00028E28
	public global::Controller nextController
	{
		get
		{
			return this.idMain.nextController;
		}
	}

	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06000AAC RID: 2732 RVA: 0x0002AC38 File Offset: 0x00028E38
	public global::Controller previousController
	{
		get
		{
			return this.idMain.previousController;
		}
	}

	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06000AAD RID: 2733 RVA: 0x0002AC48 File Offset: 0x00028E48
	public float maxPitch
	{
		get
		{
			return this.idMain.maxPitch;
		}
	}

	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000AAE RID: 2734 RVA: 0x0002AC58 File Offset: 0x00028E58
	public float minPitch
	{
		get
		{
			return this.idMain.minPitch;
		}
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x0002AC68 File Offset: 0x00028E68
	public float ClampPitch(float v)
	{
		return this.idMain.ClampPitch(v);
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x0002AC78 File Offset: 0x00028E78
	public void ClampPitch(ref float v)
	{
		this.idMain.ClampPitch(ref v);
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x0002AC88 File Offset: 0x00028E88
	public global::Angle2 ClampPitch(global::Angle2 v)
	{
		return this.idMain.ClampPitch(v);
	}

	// Token: 0x06000AB2 RID: 2738 RVA: 0x0002AC98 File Offset: 0x00028E98
	public void ClampPitch(ref global::Angle2 v)
	{
		this.idMain.ClampPitch(ref v);
	}

	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x0002ACA8 File Offset: 0x00028EA8
	// (set) Token: 0x06000AB4 RID: 2740 RVA: 0x0002ACB8 File Offset: 0x00028EB8
	public global::CharacterStateFlags stateFlags
	{
		get
		{
			return this.idMain.stateFlags;
		}
		set
		{
			this.idMain.stateFlags = value;
		}
	}

	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x0002ACC8 File Offset: 0x00028EC8
	// (set) Token: 0x06000AB6 RID: 2742 RVA: 0x0002ACD8 File Offset: 0x00028ED8
	public bool lockMovement
	{
		get
		{
			return this.idMain.lockMovement;
		}
		set
		{
			this.idMain.lockMovement = value;
		}
	}

	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x0002ACE8 File Offset: 0x00028EE8
	// (set) Token: 0x06000AB8 RID: 2744 RVA: 0x0002ACF8 File Offset: 0x00028EF8
	public bool lockLook
	{
		get
		{
			return this.idMain.lockLook;
		}
		set
		{
			this.idMain.lockLook = value;
		}
	}

	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x0002AD08 File Offset: 0x00028F08
	// (set) Token: 0x06000ABA RID: 2746 RVA: 0x0002AD18 File Offset: 0x00028F18
	public float eyesPitch
	{
		get
		{
			return this.idMain.eyesPitch;
		}
		set
		{
			this.idMain.eyesPitch = value;
		}
	}

	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0002AD28 File Offset: 0x00028F28
	// (set) Token: 0x06000ABC RID: 2748 RVA: 0x0002AD38 File Offset: 0x00028F38
	public float eyesYaw
	{
		get
		{
			return this.idMain.eyesYaw;
		}
		set
		{
			this.idMain.eyesYaw = value;
		}
	}

	// Token: 0x170002DD RID: 733
	// (get) Token: 0x06000ABD RID: 2749 RVA: 0x0002AD48 File Offset: 0x00028F48
	// (set) Token: 0x06000ABE RID: 2750 RVA: 0x0002AD58 File Offset: 0x00028F58
	public global::Angle2 eyesAngles
	{
		get
		{
			return this.idMain.eyesAngles;
		}
		set
		{
			this.idMain.eyesAngles = value;
		}
	}

	// Token: 0x170002DE RID: 734
	// (get) Token: 0x06000ABF RID: 2751 RVA: 0x0002AD68 File Offset: 0x00028F68
	public global::UnityEngine.Vector3 eyesOrigin
	{
		get
		{
			return this.idMain.eyesOrigin;
		}
	}

	// Token: 0x170002DF RID: 735
	// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0002AD78 File Offset: 0x00028F78
	public global::UnityEngine.Vector3 eyesOriginAtInitialOffset
	{
		get
		{
			return this.idMain.eyesOriginAtInitialOffset;
		}
	}

	// Token: 0x170002E0 RID: 736
	// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x0002AD88 File Offset: 0x00028F88
	// (set) Token: 0x06000AC2 RID: 2754 RVA: 0x0002AD98 File Offset: 0x00028F98
	public global::UnityEngine.Vector3 eyesOffset
	{
		get
		{
			return this.idMain.eyesOffset;
		}
		set
		{
			this.idMain.eyesOffset = value;
		}
	}

	// Token: 0x170002E1 RID: 737
	// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x0002ADA8 File Offset: 0x00028FA8
	public global::UnityEngine.Vector3 initialEyesOffset
	{
		get
		{
			return this.idMain.initialEyesOffset;
		}
	}

	// Token: 0x170002E2 RID: 738
	// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x0002ADB8 File Offset: 0x00028FB8
	public float initialEyesOffsetX
	{
		get
		{
			return this.idMain.initialEyesOffsetX;
		}
	}

	// Token: 0x170002E3 RID: 739
	// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x0002ADC8 File Offset: 0x00028FC8
	public float initialEyesOffsetY
	{
		get
		{
			return this.idMain.initialEyesOffsetY;
		}
	}

	// Token: 0x170002E4 RID: 740
	// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x0002ADD8 File Offset: 0x00028FD8
	public float initialEyesOffsetZ
	{
		get
		{
			return this.idMain.initialEyesOffsetZ;
		}
	}

	// Token: 0x170002E5 RID: 741
	// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x0002ADE8 File Offset: 0x00028FE8
	public global::UnityEngine.Ray eyesRay
	{
		get
		{
			return this.idMain.eyesRay;
		}
	}

	// Token: 0x170002E6 RID: 742
	// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x0002ADF8 File Offset: 0x00028FF8
	// (set) Token: 0x06000AC9 RID: 2761 RVA: 0x0002AE08 File Offset: 0x00029008
	public global::UnityEngine.Quaternion eyesRotation
	{
		get
		{
			return this.idMain.eyesRotation;
		}
		set
		{
			this.idMain.eyesRotation = value;
		}
	}

	// Token: 0x170002E7 RID: 743
	// (get) Token: 0x06000ACA RID: 2762 RVA: 0x0002AE18 File Offset: 0x00029018
	public global::UnityEngine.Transform eyesTransformReadOnly
	{
		get
		{
			return this.idMain.eyesTransformReadOnly;
		}
	}

	// Token: 0x170002E8 RID: 744
	// (get) Token: 0x06000ACB RID: 2763 RVA: 0x0002AE28 File Offset: 0x00029028
	// (set) Token: 0x06000ACC RID: 2764 RVA: 0x0002AE38 File Offset: 0x00029038
	public global::UnityEngine.Vector3 origin
	{
		get
		{
			return this.idMain.origin;
		}
		set
		{
			this.idMain.origin = value;
		}
	}

	// Token: 0x170002E9 RID: 745
	// (get) Token: 0x06000ACD RID: 2765 RVA: 0x0002AE48 File Offset: 0x00029048
	public global::UnityEngine.Vector3 forward
	{
		get
		{
			return this.idMain.forward;
		}
	}

	// Token: 0x170002EA RID: 746
	// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0002AE58 File Offset: 0x00029058
	public global::UnityEngine.Vector3 right
	{
		get
		{
			return this.idMain.right;
		}
	}

	// Token: 0x170002EB RID: 747
	// (get) Token: 0x06000ACF RID: 2767 RVA: 0x0002AE68 File Offset: 0x00029068
	public global::UnityEngine.Vector3 up
	{
		get
		{
			return this.idMain.up;
		}
	}

	// Token: 0x170002EC RID: 748
	// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0002AE78 File Offset: 0x00029078
	// (set) Token: 0x06000AD1 RID: 2769 RVA: 0x0002AE88 File Offset: 0x00029088
	public global::UnityEngine.Quaternion rotation
	{
		get
		{
			return this.idMain.rotation;
		}
		set
		{
			this.idMain.rotation = value;
		}
	}

	// Token: 0x170002ED RID: 749
	// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x0002AE98 File Offset: 0x00029098
	public bool signaledDeath
	{
		get
		{
			return this.idMain.signaledDeath;
		}
	}

	// Token: 0x06000AD3 RID: 2771 RVA: 0x0002AEA8 File Offset: 0x000290A8
	public void ApplyAdditiveEyeAngles(global::Angle2 angles)
	{
		this.idMain.ApplyAdditiveEyeAngles(angles);
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x0002AEB8 File Offset: 0x000290B8
	public T AddAddon<T>() where T : global::IDLocalCharacterAddon, new()
	{
		return this.idMain.AddAddon<T>();
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x0002AEC8 File Offset: 0x000290C8
	public TBase AddAddon<TBase, T>() where TBase : global::IDLocalCharacterAddon where T : TBase, new()
	{
		return this.idMain.AddAddon<TBase, T>();
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x0002AED8 File Offset: 0x000290D8
	public global::IDLocalCharacterAddon AddAddon(global::System.Type addonType)
	{
		return this.idMain.AddAddon(addonType);
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x0002AEE8 File Offset: 0x000290E8
	public global::IDLocalCharacterAddon AddAddon(global::System.Type addonType, global::System.Type minimumType)
	{
		return this.idMain.AddAddon(addonType, minimumType);
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x0002AEF8 File Offset: 0x000290F8
	public TBase AddAddon<TBase>(global::System.Type addonType) where TBase : global::IDLocalCharacterAddon
	{
		return this.idMain.AddAddon<TBase>(addonType);
	}

	// Token: 0x06000AD9 RID: 2777 RVA: 0x0002AF08 File Offset: 0x00029108
	public global::IDLocalCharacterAddon AddAddon(string addonTypeName)
	{
		return this.idMain.AddAddon(addonTypeName);
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x0002AF18 File Offset: 0x00029118
	public global::IDLocalCharacterAddon AddAddon(string addonTypeName, global::System.Type minimumType)
	{
		return this.idMain.AddAddon(addonTypeName, minimumType);
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x0002AF28 File Offset: 0x00029128
	public TBase AddAddon<TBase>(string addonTypeName) where TBase : global::IDLocalCharacterAddon
	{
		return this.idMain.AddAddon<TBase>(addonTypeName);
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x0002AF38 File Offset: 0x00029138
	public void RemoveAddon(global::IDLocalCharacterAddon addon)
	{
		this.idMain.RemoveAddon(addon);
	}

	// Token: 0x06000ADD RID: 2781 RVA: 0x0002AF48 File Offset: 0x00029148
	public void RemoveAddon<T>(ref T addon) where T : global::IDLocalCharacterAddon
	{
		this.idMain.RemoveAddon<T>(ref addon);
	}

	// Token: 0x170002EE RID: 750
	// (get) Token: 0x06000ADE RID: 2782 RVA: 0x0002AF58 File Offset: 0x00029158
	// (set) Token: 0x06000ADF RID: 2783 RVA: 0x0002AF84 File Offset: 0x00029184
	protected global::RPOSLimitFlags rposLimitFlags
	{
		get
		{
			global::Controller controller = this.controller;
			return (!controller) ? ((global::RPOSLimitFlags)-1) : controller.rposLimitFlags;
		}
		set
		{
			global::Controller controller = this.controller;
			if (controller)
			{
				controller.rposLimitFlags = value;
			}
		}
	}

	// Token: 0x170002EF RID: 751
	// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x0002AFAC File Offset: 0x000291AC
	public global::NetUser netUser
	{
		get
		{
			return this.idMain.netUser;
		}
	}

	// Token: 0x06000AE1 RID: 2785 RVA: 0x0002AFBC File Offset: 0x000291BC
	public bool GetNetUser(out global::NetUser netUser)
	{
		return this.idMain.GetNetUser(out netUser);
	}

	// Token: 0x06000AE2 RID: 2786 RVA: 0x0002AFCC File Offset: 0x000291CC
	public global::CharacterTrait GetTrait(global::System.Type characterTraitType)
	{
		return this.idMain.GetTrait(characterTraitType);
	}

	// Token: 0x06000AE3 RID: 2787 RVA: 0x0002AFDC File Offset: 0x000291DC
	public TCharacterTrait GetTrait<TCharacterTrait>() where TCharacterTrait : global::CharacterTrait
	{
		return this.idMain.GetTrait<TCharacterTrait>();
	}

	// Token: 0x170002F0 RID: 752
	// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x0002AFEC File Offset: 0x000291EC
	public bool? idle
	{
		get
		{
			return this.idMain.idle;
		}
	}

	// Token: 0x170002F1 RID: 753
	// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x0002AFFC File Offset: 0x000291FC
	public global::IDLocalCharacterIdleControl idleControl
	{
		get
		{
			return this.idMain.idleControl;
		}
	}

	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x0002B00C File Offset: 0x0002920C
	public global::Crouchable crouchable
	{
		get
		{
			return this.idMain.crouchable;
		}
	}

	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x0002B01C File Offset: 0x0002921C
	public bool crouched
	{
		get
		{
			return this.idMain.crouched;
		}
	}

	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x0002B02C File Offset: 0x0002922C
	public global::TakeDamage takeDamage
	{
		get
		{
			return this.idMain.takeDamage;
		}
	}

	// Token: 0x170002F5 RID: 757
	// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x0002B03C File Offset: 0x0002923C
	public float health
	{
		get
		{
			return this.idMain.health;
		}
	}

	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x06000AEA RID: 2794 RVA: 0x0002B04C File Offset: 0x0002924C
	public float healthFraction
	{
		get
		{
			return this.idMain.healthFraction;
		}
	}

	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x06000AEB RID: 2795 RVA: 0x0002B05C File Offset: 0x0002925C
	public bool alive
	{
		get
		{
			return this.idMain.alive;
		}
	}

	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x06000AEC RID: 2796 RVA: 0x0002B06C File Offset: 0x0002926C
	public bool dead
	{
		get
		{
			return this.idMain.dead;
		}
	}

	// Token: 0x170002F9 RID: 761
	// (get) Token: 0x06000AED RID: 2797 RVA: 0x0002B07C File Offset: 0x0002927C
	public float healthLoss
	{
		get
		{
			return this.idMain.healthLoss;
		}
	}

	// Token: 0x170002FA RID: 762
	// (get) Token: 0x06000AEE RID: 2798 RVA: 0x0002B08C File Offset: 0x0002928C
	public float healthLossFraction
	{
		get
		{
			return this.idMain.healthLossFraction;
		}
	}

	// Token: 0x170002FB RID: 763
	// (get) Token: 0x06000AEF RID: 2799 RVA: 0x0002B09C File Offset: 0x0002929C
	public float maxHealth
	{
		get
		{
			return this.idMain.maxHealth;
		}
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x0002B0AC File Offset: 0x000292AC
	public void AdjustClientSideHealth(float newHealthValue)
	{
		this.idMain.AdjustClientSideHealth(newHealthValue);
	}

	// Token: 0x170002FC RID: 764
	// (get) Token: 0x06000AF1 RID: 2801 RVA: 0x0002B0BC File Offset: 0x000292BC
	public global::VisNode visNode
	{
		get
		{
			return this.idMain.visNode;
		}
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x0002B0CC File Offset: 0x000292CC
	public bool CanSee(global::VisNode other)
	{
		return this.idMain.CanSee(other);
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x0002B0DC File Offset: 0x000292DC
	public bool CanSee(global::Character other)
	{
		return this.idMain.CanSee(other);
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x0002B0EC File Offset: 0x000292EC
	public bool CanSee(global::IDMain other)
	{
		return this.idMain.CanSee(other);
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x0002B0FC File Offset: 0x000292FC
	public bool CanSeeUnobstructed(global::VisNode other)
	{
		return this.idMain.CanSeeUnobstructed(other);
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x0002B10C File Offset: 0x0002930C
	public bool CanSeeUnobstructed(global::Character other)
	{
		return this.idMain.CanSeeUnobstructed(other);
	}

	// Token: 0x06000AF7 RID: 2807 RVA: 0x0002B11C File Offset: 0x0002931C
	public bool CanSeeUnobstructed(global::IDMain other)
	{
		return this.idMain.CanSeeUnobstructed(other);
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x0002B12C File Offset: 0x0002932C
	public bool CanSee(global::VisNode other, bool unobstructed)
	{
		return this.idMain.CanSee(other, unobstructed);
	}

	// Token: 0x06000AF9 RID: 2809 RVA: 0x0002B13C File Offset: 0x0002933C
	public bool CanSee(global::Character other, bool unobstructed)
	{
		return this.idMain.CanSee(other, unobstructed);
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x0002B14C File Offset: 0x0002934C
	public bool CanSee(global::IDMain other, bool unobstructed)
	{
		return this.idMain.CanSee(other, unobstructed);
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x0002B15C File Offset: 0x0002935C
	public bool AudibleMessage(global::UnityEngine.Vector3 point, float hearRadius, string message, object arg)
	{
		return this.idMain.AudibleMessage(point, hearRadius, message, arg);
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x0002B170 File Offset: 0x00029370
	public bool AudibleMessage(global::UnityEngine.Vector3 point, float hearRadius, string message)
	{
		return this.idMain.AudibleMessage(point, hearRadius, message);
	}

	// Token: 0x06000AFD RID: 2813 RVA: 0x0002B180 File Offset: 0x00029380
	public bool AudibleMessage(float hearRadius, string message, object arg)
	{
		return this.idMain.AudibleMessage(hearRadius, message, arg);
	}

	// Token: 0x06000AFE RID: 2814 RVA: 0x0002B190 File Offset: 0x00029390
	public bool AudibleMessage(float hearRadius, string message)
	{
		return this.idMain.AudibleMessage(hearRadius, message);
	}

	// Token: 0x06000AFF RID: 2815 RVA: 0x0002B1A0 File Offset: 0x000293A0
	public bool GestureMessage(string message)
	{
		return this.idMain.GestureMessage(message);
	}

	// Token: 0x06000B00 RID: 2816 RVA: 0x0002B1B0 File Offset: 0x000293B0
	public bool GestureMessage(string message, object arg)
	{
		return this.idMain.GestureMessage(message, arg);
	}

	// Token: 0x06000B01 RID: 2817 RVA: 0x0002B1C0 File Offset: 0x000293C0
	public bool AttentionMessage(string message)
	{
		return this.idMain.AttentionMessage(message);
	}

	// Token: 0x06000B02 RID: 2818 RVA: 0x0002B1D0 File Offset: 0x000293D0
	public bool AttentionMessage(string message, object arg)
	{
		return this.idMain.AttentionMessage(message, arg);
	}

	// Token: 0x06000B03 RID: 2819 RVA: 0x0002B1E0 File Offset: 0x000293E0
	public bool ContactMessage(string message)
	{
		return this.idMain.ContactMessage(message);
	}

	// Token: 0x06000B04 RID: 2820 RVA: 0x0002B1F0 File Offset: 0x000293F0
	public bool ContactMessage(string message, object arg)
	{
		return this.idMain.ContactMessage(message, arg);
	}

	// Token: 0x06000B05 RID: 2821 RVA: 0x0002B200 File Offset: 0x00029400
	public bool StealthMessage(string message)
	{
		return this.idMain.StealthMessage(message);
	}

	// Token: 0x06000B06 RID: 2822 RVA: 0x0002B210 File Offset: 0x00029410
	public bool StealthMessage(string message, object arg)
	{
		return this.idMain.StealthMessage(message, arg);
	}

	// Token: 0x06000B07 RID: 2823 RVA: 0x0002B220 File Offset: 0x00029420
	public bool PreyMessage(string message)
	{
		return this.idMain.PreyMessage(message);
	}

	// Token: 0x06000B08 RID: 2824 RVA: 0x0002B230 File Offset: 0x00029430
	public bool PreyMessage(string message, object arg)
	{
		return this.idMain.PreyMessage(message, arg);
	}

	// Token: 0x06000B09 RID: 2825 RVA: 0x0002B240 File Offset: 0x00029440
	public bool ObliviousMessage(string message)
	{
		return this.idMain.ObliviousMessage(message);
	}

	// Token: 0x06000B0A RID: 2826 RVA: 0x0002B250 File Offset: 0x00029450
	public bool ObliviousMessage(string message, object arg)
	{
		return this.idMain.ObliviousMessage(message, arg);
	}

	// Token: 0x170002FD RID: 765
	// (get) Token: 0x06000B0B RID: 2827 RVA: 0x0002B260 File Offset: 0x00029460
	// (set) Token: 0x06000B0C RID: 2828 RVA: 0x0002B270 File Offset: 0x00029470
	public global::Vis.Mask viewMask
	{
		get
		{
			return this.idMain.viewMask;
		}
		set
		{
			this.idMain.viewMask = value;
		}
	}

	// Token: 0x170002FE RID: 766
	// (get) Token: 0x06000B0D RID: 2829 RVA: 0x0002B280 File Offset: 0x00029480
	// (set) Token: 0x06000B0E RID: 2830 RVA: 0x0002B290 File Offset: 0x00029490
	public global::Vis.Mask traitMask
	{
		get
		{
			return this.idMain.traitMask;
		}
		set
		{
			this.idMain.traitMask = value;
		}
	}

	// Token: 0x170002FF RID: 767
	// (get) Token: 0x06000B0F RID: 2831 RVA: 0x0002B2A0 File Offset: 0x000294A0
	// (set) Token: 0x06000B10 RID: 2832 RVA: 0x0002B2B0 File Offset: 0x000294B0
	public bool blind
	{
		get
		{
			return this.idMain.blind;
		}
		set
		{
			this.idMain.blind = value;
		}
	}

	// Token: 0x17000300 RID: 768
	// (get) Token: 0x06000B11 RID: 2833 RVA: 0x0002B2C0 File Offset: 0x000294C0
	// (set) Token: 0x06000B12 RID: 2834 RVA: 0x0002B2D0 File Offset: 0x000294D0
	public bool deaf
	{
		get
		{
			return this.idMain.deaf;
		}
		set
		{
			this.idMain.deaf = value;
		}
	}

	// Token: 0x17000301 RID: 769
	// (get) Token: 0x06000B13 RID: 2835 RVA: 0x0002B2E0 File Offset: 0x000294E0
	// (set) Token: 0x06000B14 RID: 2836 RVA: 0x0002B2F0 File Offset: 0x000294F0
	public bool mute
	{
		get
		{
			return this.idMain.mute;
		}
		set
		{
			this.idMain.mute = value;
		}
	}

	// Token: 0x17000302 RID: 770
	// (get) Token: 0x06000B15 RID: 2837 RVA: 0x0002B300 File Offset: 0x00029500
	public global::UnityEngine.NavMeshAgent agent
	{
		get
		{
			return this.idMain.agent;
		}
	}

	// Token: 0x06000B16 RID: 2838 RVA: 0x0002B310 File Offset: 0x00029510
	public bool CreateNavMeshAgent()
	{
		return this.idMain.CreateNavMeshAgent();
	}

	// Token: 0x17000303 RID: 771
	// (get) Token: 0x06000B17 RID: 2839 RVA: 0x0002B320 File Offset: 0x00029520
	public global::CharacterInterpolatorBase interpolator
	{
		get
		{
			return this.idMain.interpolator;
		}
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x0002B330 File Offset: 0x00029530
	public bool CreateInterpolator()
	{
		return this.idMain.CreateInterpolator();
	}

	// Token: 0x17000304 RID: 772
	// (get) Token: 0x06000B19 RID: 2841 RVA: 0x0002B340 File Offset: 0x00029540
	public global::CCMotor ccmotor
	{
		get
		{
			return this.idMain.ccmotor;
		}
	}

	// Token: 0x06000B1A RID: 2842 RVA: 0x0002B350 File Offset: 0x00029550
	public bool CreateCCMotor()
	{
		return this.idMain.CreateCCMotor();
	}

	// Token: 0x17000305 RID: 773
	// (get) Token: 0x06000B1B RID: 2843 RVA: 0x0002B360 File Offset: 0x00029560
	public global::IDLocalCharacterAddon overlay
	{
		get
		{
			return this.idMain.overlay;
		}
	}

	// Token: 0x06000B1C RID: 2844 RVA: 0x0002B370 File Offset: 0x00029570
	public bool CreateOverlay()
	{
		return this.idMain.CreateOverlay();
	}

	// Token: 0x06000B1D RID: 2845 RVA: 0x0002B380 File Offset: 0x00029580
	protected static void DestroyCharacter(global::Character character)
	{
		global::Character.DestroyCharacter(character);
	}
}

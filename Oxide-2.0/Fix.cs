using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using System.Linq;
using System.Collections.Generic;
using RustProto;
using Oxide.Core.Libraries;

// Reference: Oxide.Ext.RustLegacy
// Reference: Facepunch.ID
// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers

namespace Oxide.Plugins
{
    [Info("Fix", "lutSEfer", "1.0.0")]
    class Fix : RustLegacyPlugin
    {
				public double distFix { get; set; } = 0;

		void OnItemDeployed(DeployableObject component, IDeployableItem item)
		{			
				distFix = Math.Floor(Vector3.Distance(component.transform.position, item.character.playerClient.lastKnownPosition));
				if (component.gameObject.name == "Barricade_Fence_Deployable(Clone)"||component.gameObject.name == "Furnace(Clone)")
					if (distFix<=1)
				{
				SendReply(item.character.playerClient.netUser, "[color#FF4500]Нельзя находится в текстурах печек и баррикад![color#CDB38B]");
				item.character.GetComponent<Inventory>().AddItemAmount(item.datablock, 1);
				timer.Once(0.01f, () => NetCull.Destroy(component.gameObject));
				}
				if (component.gameObject.name.Contains("Shelter"))
				{
				Vector3 lastPosition = component.transform.position;
				foreach (Collider collider in Physics.OverlapSphere(lastPosition, 3f))
				{
					if (collider.gameObject.name.Contains("Door"))					
					{
						SendReply(item.character.playerClient.netUser, "[color#FF4500]Застраивать входы запрещено![color#CDB38B]");
						item.character.GetComponent<Inventory>().AddItemAmount(item.datablock, 1);
						timer.Once(0.01f, () => NetCull.Destroy(component.gameObject));
					}
				}
				}
		}
	}
}
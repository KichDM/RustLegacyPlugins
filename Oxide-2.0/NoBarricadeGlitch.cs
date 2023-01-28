using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
// Reference: Facepunch.MeshBatch

namespace Oxide.Plugins
{
    [Info("NoBarricadeGlitch", "Jean", 0.1)]
    [Description("...........")]

    class NoBarricadeGlitch : RustLegacyPlugin
    {
		public  Vector3 Vector3Up = new Vector3(0f, 1f, 0f);
		
	   void OnItemDeployed(DeployableObject component, IDeployableItem item)
	   {
		    if (component.gameObject.name == "Barricade_Fence_Deployable(Clone)" )
            {
                foreach (Collider collider in Physics.OverlapSphere(component.transform.position + Vector3Up, 3f))
                {
                    if (collider.gameObject.name.IndexOf("Player") != -1) 
                    {
                        ConsoleNetworker.SendClientCommand(item.character.playerClient.netPlayer, "chat.add [NoGlitch] " + Facepunch.Utility.String.QuoteSafe("Jugadores demasiado cerca de [color red]barricada."));
                        item.character.GetComponent<Inventory>().AddItemAmount(item.datablock, 1);
                        timer.Once(0.01f, () => NetCull.Destroy(component.gameObject));
                        return;
                    }
                }
            }	
			if (component.gameObject.name == "Furnace(Clone)")
            {
                foreach (Collider collider in Physics.OverlapSphere(component.transform.position + Vector3Up, 0.5f))
                {
                    if (collider.gameObject.name.IndexOf("Player") != -1)
                    {
                        ConsoleNetworker.SendClientCommand(item.character.playerClient.netPlayer, "chat.add [NoGlitch] " + Facepunch.Utility.String.QuoteSafe("Jugadores demasiado cerca del [color red]Furnace."));
                        item.character.GetComponent<Inventory>().AddItemAmount(item.datablock, 1);
                        timer.Once(0.01f, () => NetCull.Destroy(component.gameObject));
                        return;
                    }
                }
			} 
			if (component.gameObject.name == "Wood_Shelter(Clone)")
            {
                foreach (Collider collider in Physics.OverlapSphere(component.transform.position + Vector3Up, 0.9f))
                {
                    if (collider.gameObject.name.IndexOf("Player") != -1)
                    {
                        ConsoleNetworker.SendClientCommand(item.character.playerClient.netPlayer, "chat.add [NoGlitch] " + Facepunch.Utility.String.QuoteSafe("Jugadores demasiado cerca del [color red]Shelter."));
                        item.character.GetComponent<Inventory>().AddItemAmount(item.datablock, 1);
                        timer.Once(0.01f, () => NetCull.Destroy(component.gameObject));
                        return;
                    }
                }
			}
			///Limpar o server de objetos
			if (component.gameObject.name == "Wood_Shelter(Clone)")
            {
                ConsoleNetworker.SendClientCommand(item.character.playerClient.netPlayer, "chat.add [NoGlitch] " + Facepunch.Utility.String.QuoteSafe("Su [color red]Wood Shelter[color clear] sera autoremovida ea [color red]60 [color clear~]segundos"));
				timer.Once(60f, () => NetCull.Destroy(component.gameObject));
				return;
			}
			
			if (component.gameObject.name == "Barricade_Fence_Deployable(Clone)")
            {
                ConsoleNetworker.SendClientCommand(item.character.playerClient.netPlayer, "chat.add [NoGlitch] " + Facepunch.Utility.String.QuoteSafe("Su [color red]Wood Barricade[color clear] sera autoremovida en [color red]120 [color clear]segundos"));
				timer.Once(120f, () => NetCull.Destroy(component.gameObject));
				return;
			}
			//if (component.gameObject.name == "WoodSpikeWall(Clone)")
   //         {
   //             ConsoleNetworker.SendClientCommand(item.character.playerClient.netPlayer, "chat.add [NoGlitch] " + Facepunch.Utility.String.QuoteSafe("Sua [color red]Wood Spike Wall[color clear] será autoremovida en [color red]60 [color clear]segundos"));
			//	timer.Once(60f, () => NetCull.Destroy(component.gameObject));
			//	return;
			//}
	   }				

	}   
}	
		
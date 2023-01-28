// Reference: Facepunch.ID
// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers
//
//
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;

namespace Oxide.Plugins
{
    [Info("Resource", "PionixZ", "1.0.2")]
    class Resource: RustLegacyPlugin
    {
        MethodInfo genericspawn_serverload;
        FieldInfo genericspawn_spawnstagger;

        public static Dictionary<string, object> SpawnLists = NewSpawnList();

        void LoadDefaultConfig() { }

        private void CheckCfg<T>(string Key, ref T var)
        {
            if (Config[Key] is T)
                var = (T)Config[Key];
            else
                Config[Key] = var;
        }

        void Init()
        {
            
                CheckCfg<Dictionary<string, object>>("Spawnlists", ref SpawnLists);
                SaveConfig();
            
        }

        void PathResources()
        {
            
                int count = 0;
                foreach (GenericSpawner spawner in UnityEngine.Resources.FindObjectsOfTypeAll<GenericSpawner>())
                {
                    GameObject.Destroy(spawner);
                }
                foreach (KeyValuePair<string, object> spawnlist in SpawnLists)
                {
                    var currentSpawnlist = (Dictionary<string, object>)spawnlist.Value;
                    var newlist = new List<GenericSpawnerSpawnList.GenericSpawnInstance>();
                    foreach (object pair in (List<object>)currentSpawnlist["spawnList"])
                    {
                        var currentspawninstance = (Dictionary<string, object>)pair;
                        var newspawnlistdata = new GenericSpawnerSpawnList.GenericSpawnInstance();
                        newspawnlistdata.forceStaticInstantiate = false;
                        newspawnlistdata.numToSpawnPerTick = Convert.ToInt32(currentspawninstance["numToSpawnPerTick"]);
                        newspawnlistdata.prefabName = currentspawninstance["prefabName"].ToString();

                        newspawnlistdata.targetPopulation = Convert.ToInt32(currentspawninstance["targetPopulation"]);
                        newspawnlistdata.useNavmeshSample = true;
                        newspawnlistdata.spawned = new List<UnityEngine.GameObject>();
                        newlist.Add(newspawnlistdata);
                    }
                    var gameobject = new UnityEngine.GameObject();
                    var generic = gameobject.AddComponent<GenericSpawner>();
                    generic.transform.position = new Vector3(Convert.ToSingle(currentSpawnlist["position_x"]), Convert.ToSingle(currentSpawnlist["position_y"]), Convert.ToSingle(currentSpawnlist["position_z"]));
                    generic.initialSpawn = true;
                    generic._spawnList = newlist;
                    generic.radius = Convert.ToSingle(currentSpawnlist["radius"]);
                    genericspawn_serverload.Invoke(generic, new object[] { });
                    generic.SpawnThink();
                    count++;
                }
                Puts(string.Format("{0} recursos personalizados carregados.", count.ToString()));
            
        }
         
        static Dictionary<string, object> NewSpawnList()
        {
           
                var tblspawnlists = new Dictionary<string, object>();

                foreach (GenericSpawner spawner in UnityEngine.Resources.FindObjectsOfTypeAll<GenericSpawner>())
                {
                    var genericspawn = new Dictionary<string, object>();
                    genericspawn.Add("radius", spawner.radius);
                    genericspawn.Add("thinkDelay", spawner.thinkDelay);
                    genericspawn.Add("position_x", spawner.transform.position.x);
                    genericspawn.Add("position_y", spawner.transform.position.y);
                    genericspawn.Add("position_z", spawner.transform.position.z);
                    var genericlist = new List<object>();
                    foreach (GenericSpawnerSpawnList.GenericSpawnInstance spawninstance in spawner._spawnList)
                    {
                        var spawninstances = new Dictionary<string, object>();
                        spawninstances.Add("numToSpawnPerTick", spawninstance.numToSpawnPerTick);
                        spawninstances.Add("prefabName", spawninstance.prefabName.ToString());
                        spawninstances.Add("targetPopulation", spawninstance.targetPopulation);
                        genericlist.Add(spawninstances);
                    }
                    genericspawn.Add("spawnList", genericlist);
                    tblspawnlists.Add(tblspawnlists.Count.ToString(), genericspawn);
                }
                return tblspawnlists;
          
        }

        void OnServerInitialized()
        {
            
                genericspawn_serverload = typeof(GenericSpawner).GetMethod("OnServerLoad", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                genericspawn_spawnstagger = typeof(GenericSpawner).GetField("spawnStagger", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                PathResources();
            
        }
        
        
    }
}

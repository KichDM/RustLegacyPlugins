

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Facepunch.Clocks.Counters;
using Facepunch.MeshBatch;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Configuration;
using UnityEngine;
using RustExtended;

namespace Oxide.Plugins
{

    [Info("FixGate", "Chill", "0.1")]
    [Description("FixGate")]
    class FixGate : RustLegacyPlugin
    {



        public class colis : MonoBehaviour
        {
            //If your GameObject starts to collide with another GameObject with a Collider

            void OnTriggerStay(Collider other)
            {
               // D("OnTriggerStay " + other.collider.name);
              //  D("OnTriggerStay " + other.gameObject.name);
              //  NetCull.Destroy(other.gameObject);

            }
            void OnTriggerEnter(Collider other)
            {
               // D("OnTriggerStay " + other.collider.name);
             //   D("OnTriggerStay " + other.gameObject.name);
                Component[] components = other.gameObject.GetComponents<Component>();
                foreach (var script in components)
                {
                 //   D(string.Format("components {0} ", script));
                }

                if (other.name.Contains("MESHBATCH"))
                {
                    MeshBatchPhysicalOutput mes = other.gameObject.GetComponent<MeshBatchPhysicalOutput>();


                 //   D("OnTriggerStay MESHBATCH  " + mes.gameObject.name);

                    IDMain idmain = mes.idMain;
                    GameObject gameObjectS = idmain.gameObject;
                    string text = gameObjectS.name.Trim();

                   // D("OnTriggerStay MESHBATCH  " + text);

                    StructureMaster component2 = gameObjectS.GetComponent<StructureMaster>();
                    foreach (var VARIABLE in component2._structureComponents)
                    {
                       // D("OnTriggerStay MESHBATCH  " + VARIABLE + " " + VARIABLE.gameObject.transform.position.ToString() + " " + Vector3.Distance(base.gameObject.transform.position, VARIABLE.gameObject.transform.position).ToString());
                        if (Vector3.Distance(base.gameObject.transform.position,
                                VARIABLE.gameObject.transform.position) < 2f)
                        {
                            DeployableObject obj = base.gameObject.GetComponent<DeployableObject>();
                            if (obj.ownerID != VARIABLE._master.ownerID)
                            {

                                if (VARIABLE.gameObject.name.ToLower().Contains("wall"))
                                {
                                 //   D("OnTriggerStay MESHBATCH  " + VARIABLE + " " + VARIABLE.gameObject.transform.position.ToString() + " " + Vector3.Distance(base.gameObject.transform.position, VARIABLE.gameObject.transform.position).ToString());

                                    NetCull.Destroy(base.gameObject);
                                }
                               
                            } 
                           
                        }
                      
                    }

                  //  D("OnTriggerStay MESHBATCH  " + component2.CompByLocal(other.bounds.center).name);
                }

                //  NetCull.Destroy(other.gameObject);
            }
            void OnCollisionEnter(Collision collision)
            {
                //Output the Collider's GameObject's name
              //  D("OnCollisionEnter " + collision.collider.name);
                OnTriggerEnter(collision.collider);
                //    NetCull.Destroy(collision.gameObject);
            }

            //If your GameObject keeps colliding with another GameObject with a Collider, do something
            void OnCollisionStay(Collision collision)
            {
                //Check to see if the Collider's name is "Chest"


           //     D("OnCollisionStay " + collision.collider.name);

               // NetCull.Destroy(collision.gameObject);
            }
        }





        public static void D(string x)
        {
            Helper.Log(x);
        }


        void OnItemDeployed(DeployableObject deployable, IDeployableItem item)
        {
            string nameitem_uses = item.datablock?.name?? null;
            if (nameitem_uses == null)
            {
                return;
            }
            if (nameitem_uses.Contains("Wood Gate"))
            {
  
               
                Collider[] colliderArray = Physics.OverlapSphere(deployable.collider.bounds.center + new Vector3(0f, -5f, 0f), 4f);
                foreach (var sss in colliderArray){
                    if (sss)
                    {
                        if (sss.gameObject.name.Contains("Cube"))
                        {
                            NetCull.Destroy(deployable.gameObject);
                            return;
                        }
                    }
                }



    
              
                Rigidbody x = deployable.gameObject.collider.gameObject.AddComponent<Rigidbody>();
                x.collisionDetectionMode = CollisionDetectionMode.Continuous;
                x.isKinematic = false;
                x.freezeRotation = true;
                x.constraints = RigidbodyConstraints.FreezeAll;
                x.useGravity = false;
                x.detectCollisions = true;
                x.gameObject.collider.enabled = true;
            
                deployable.gameObject.collider.gameObject.AddComponent<colis>();
             
            }
        }
    }
}

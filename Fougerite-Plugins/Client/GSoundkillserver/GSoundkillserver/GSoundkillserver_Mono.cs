using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Fougerite;
using Fougerite.Events;
using RustBuster2016Server;
using UnityEngine;
using uLink;
using Random = System.Random;

namespace GSoundkillserver {
    public class PlData {
        public PlData() { }
        public PlData(int fragi,int hsi,ulong lasti,ulong fdeadi,int samei,bool firsti) {
            frag = fragi;
            hs = hsi;
            last = lasti;
            fdead = fdeadi;
            same = samei;
            first = firsti;
        }
        // Properties.
        public int frag { get; set; }
        public int hs { get; set; }
        public ulong last { get; set; }
        public ulong fdead { get; set; }
        public int same { get; set; }
        public bool first { get; set; }

    }//new PlData {senddata=,randomnum=,frag=,hs=,last=,same=,first=false}
    class GSoundkillserver_Mono : UnityEngine.MonoBehaviour {
        internal Random Randomizer;
        internal Dictionary<ulong, PlData> allplayers_data = new Dictionary<ulong, PlData>();
        internal Dictionary<string, string> bodies = new Dictionary<string, string>(){
            { "Undefined","Body"},{ "Hip","Hip"},{ "Spine0","Chest"},{ "Spine1","Chest"},{ "Spine2","Chest"},{ "Spine3","Chest"},{ "Spine4","Chest"},{ "Spine5","Chest"},{ "Neck","Neck"},{ "Head","Head"},{ "Scalp","Head"},{ "Nostrils","Head"},{ "Jaw","Head"},{ "TongueRear","Head"},
            { "TongueFront","Head"},{ "Heart "," Heart"},{ "Brain","Head"},{ "Stomache "," Gut"},{ "L_Lung","Chest"},{ "R_Lung "," Chest"},{ "L_Eye","Head"},{ "R_Eye "," Head"},{ "L_Clavical","Chest"},{ "R_Clavical "," Chest"},{ "L_UpperArm0","Left Arm"},{ "R_UpperArm0","Right Arm"},
            { "L_UpperArm1","Left Arm"},{ "R_UpperArm1","Right Arm"},{ "L_ForeArm0","Left Arm"},{ "R_ForeArm0","Right Arm"},{ "L_ForeArm1","Left Arm"},{ "R_ForeArm1","Right Arm"},{ "L_Hand","Left Hand"},{ "R_Hand","Right Hand"},{ "L_Finger_Index0","Left Hand"},{ "R_Finger_Index0","Right Hand"},
            { "L_Finger_Index1","Left Hand"},{ "R_Finger_Index1","Right Hand"},{ "L_Finger_Index2","Left Hand"},{ "R_Finger_Index2","Right Hand"},{ "L_Finger_Index3","Left Hand"},{ "R_Finger_Index3","Right Hand"},{ "L_Finger_Index4","Left Hand"},{ "R_Finger_Index4","Right Hand"},
            { "L_Finger_Middle0","Left Hand"},{ "R_Finger_Middle0","Right Hand"},{ "L_Finger_Middle1","Left Hand"},{ "R_Finger_Middle1","Right Hand"},{ "L_Finger_Middle2","Left Hand"},{ "R_Finger_Middle2","Right Hand"},{ "L_Finger_Middle3","Left Hand"},{ "R_Finger_Middle3","Right Hand"},
            { "L_Finger_Middle4","Left Hand"},{ "R_Finger_Middle4","Right Hand"},{ "L_Finger_Ring0","Left Hand"},{ "R_Finger_Ring0","Right Hand"},{ "L_Finger_Ring1","Left Hand"},{ "R_Finger_Ring1","Right Hand"},{ "L_Finger_Ring2","Left Hand"},{ "R_Finger_Ring2","Right Hand"},
            { "L_Finger_Ring3","Left Hand"},{ "R_Finger_Ring3","Right Hand"},{ "L_Finger_Ring4","Left Hand"},{ "R_Finger_Ring4","Right Hand"},{ "L_Finger_Pinky0","Left Hand"},{ "R_Finger_Pinky0","Right Hand"},{ "L_Finger_Pinky1","Left Hand"},{ "R_Finger_Pinky1","Right Hand"},
            { "L_Finger_Pinky2","Left Hand"},{ "R_Finger_Pinky2","Right Hand"},{ "L_Finger_Pinky3","Left Hand"},{ "R_Finger_Pinky3","Right Hand"},{ "L_Finger_Pinky4","Left Hand"},{ "R_Finger_Pinky4","Right Hand"},{ "L_Finger_Thumb0","Left Hand"},{ "R_Finger_Thumb0","Right Hand"},
            { "L_Finger_Thumb1","Left Hand"},{ "R_Finger_Thumb1","Right Hand"},{ "L_Finger_Thumb2","Left Hand"},{ "R_Finger_Thumb2","Right Hand"},{ "L_Finger_Thumb3","Left Hand"},{ "R_Finger_Thumb3","Right Hand"},{ "L_Finger_Thumb4","Left Hand"},{ "R_Finger_Thumb4","Right Hand"},
            { "L_Fingers","Left Hand"},{ "R_Fingers","Right Hand"},{ "L_Thigh0","Left Leg"},{ "R_Thigh0","Right Leg"},{ "L_Thigh1","Left Leg"},{ "R_Thigh1","Right Leg"},{ "L_Shin0","Left Leg"},{ "R_Shin0","Right Leg"},{ "L_Shin1","Left Leg"},{ "R_Shin1","Right Leg"},{ "L_Foot","Left Foot"},
            { "R_Foot","Right Foot"},{ "L_Heel0","Left Foot"},{ "R_Heel0","Right Foot"},{ "L_Heel1","Left Foot"},{ "R_Heel1","Right Foot"},{ "L_Toe0","Left Foot"},{ "R_Toe0","Right Foot"},{ "L_Toe1","Left Foot"},{ "R_Toe1","Right Foot"},{ "L_EyeLidLower","Head"},{ "R_EyeLidLower "," Head"},
            { "L_EyeLidUpper","Head"},{ "R_EyeLidUpper "," Head"},{ "L_BrowInner","Head"},{ "R_BrowInner "," Head"},{ "L_BrowOuter","Head"},{ "R_BrowOuter","Head"},{ "L_Cheek","Head"},{ "R_Cheek","Head"},{ "L_LipUpper","Head"},{ "R_LipUpper","Head"},{ "L_LipLower","Head"},{ "R_LipLower","Head"},{ "L_LipCorner","Head"},{ "R_LipCorner","Head"},
    };
        void Start() {
            Randomizer = new Random();
        }
        public void PlayerKilled(DeathEvent de) {
            int Att_sound = 0,Vic_sound = 0;
            if (de.VictimIsSleeper) return;
            if (de.DamageType != null && de.Attacker != null && de.Victim != null && de.AttackerIsPlayer && de.VictimIsPlayer) {
                Fougerite.Player attacker = (Fougerite.Player)de.Attacker;
                Fougerite.Player victim = (Fougerite.Player)de.Victim;
                string victimname = victim.Name;
                ulong A_steamID = attacker.UID;
                ulong V_steamID = victim.UID;

                PlData att_data;
                PlData vic_data;
                if (!allplayers_data.TryGetValue(A_steamID, out att_data)) {
                    ConsoleSystem.PrintError("Gsoundkill erroras:51");
                    return;
                }
                if (!allplayers_data.TryGetValue(V_steamID, out vic_data)) {
                    ConsoleSystem.PrintError("Gsoundkill erroras:21");
                    return;
                }
                if (A_steamID == V_steamID) {
                    Vic_sound = Randomizer.Next(12, 14);
                }
                string weapon = de.WeaponName;
                string bdPart;
                if (!bodies.TryGetValue(de.DamageEvent.bodyPart.ToString(), out bdPart)) {
                    ConsoleSystem.PrintError("Gsoundkill erroras:151");
                    return;
                }
                Vector3 killerloc = attacker.Location;
                Vector3 location = victim.Location;
                double distance = Math.Round(Vector3.Distance(killerloc, location));
                double damage = Math.Round(de.DamageAmount);
                string bleed = de.DamageType;
                att_data.frag++;
                if (weapon == "F1 Grenade" || weapon == "Explosive Charge") {
                    Vic_sound = 2;
                } else if (weapon == "Pick Axe") {
                    Vic_sound = Randomizer.Next(12, 14);
                } else {
                    if (att_data.frag > 1 && att_data.frag < 15) {
                        Att_sound = att_data.frag + 13;
                    } else if (att_data.frag > 14) {
                        Att_sound = 27;
                    }
                    if(bdPart== "Head") {
                        att_data.hs++;
                        Att_sound = Randomizer.Next(9, 11);
                        if (att_data.hs>4) {
                            Att_sound = 8;
                        }
                    } else {
                        att_data.hs = 0;
                    }
                }
                if(att_data.last== V_steamID) {
                    att_data.same++;
                    if (att_data.same < 6) {
                        if (att_data.same > 2) Att_sound = 5;
                        if (att_data.same > 4) Att_sound = 3;
                    }
                } else {
                    att_data.last = V_steamID;
                }
                if (distance>100) {
                    Att_sound = 4;
                }
                if (att_data.first) {
                    Att_sound = 1;
                }
                if (att_data.fdead == V_steamID) Att_sound = 6;
                att_data.fdead = 0;
                att_data.first = false;
                allplayers_data[A_steamID]= att_data;
                allplayers_data[V_steamID] = new PlData {frag = 0, hs = 0, last = 0, fdead = A_steamID, same = 0, first = vic_data.first };
                try {
                    uLink.NetworkView.Get(attacker.PlayerClient.networkView).RPC("GKillSound", attacker.NetworkPlayer, Att_sound);
                    uLink.NetworkView.Get(victim.PlayerClient.networkView).RPC("GKillSound", victim.NetworkPlayer, Vic_sound);
                } catch {
                    ConsoleSystem.PrintError("Gsoundkill erroras:1");
                }
            }
        }
        /*123456 8....27
         1-firstblood   2- nade             3- ownage
         4-eagleeye     5- flawlessvictory  6- payback
         7-hattrick     8-headhunter        
         9-headshot 10-headshot2    11-headshot3        
         12-humiliatingdefeat 1 2 14
         15-multikill   16-triplekill       17-killingspree
         18-rampage     19-dominating       20-unstoppable      
         21-megakill    22-ultrakill        23-monsterkill      
         24-ludicrouskill 25-wickedsick     26-holyshit         
         27-godlike
         28-prepare 29 30 31*/

        public void OnRustBusterLogin(API.RustBusterUserAPI user) {
            try {
                ulong UL_steamID = Convert.ToUInt64(user.SteamID);
                allplayers_data[UL_steamID] = new PlData {frag = 0, hs = 0, last = 0, fdead = 0, same = 0, first = true };
            } catch {
                ConsoleSystem.PrintError("Gsoundkill erroras:2");
            }
        }
        public void OnPlConnect(Fougerite.Player Playe) {
            PlData Loggin;
            if (!allplayers_data.TryGetValue(Playe.UID, out Loggin)) {
                ConsoleSystem.PrintError("Gsoundkill erroras:OnRustBusterLogin shit");
                try {
                    allplayers_data[Playe.UID] = new PlData { frag = 0, hs = 0, last = 0, fdead = 0, same = 0, first = true };
                } catch {
                    ConsoleSystem.PrintError("Gsoundkill erroras:11");
                }
            }
        }
    

        public void OnPlayerSpawned(Fougerite.Player Playe, SpawnEvent se) {
            Playe.Inventory.RemoveItem("",1);
            try {
                int ssound = Randomizer.Next(28, 31);
                if (allplayers_data.ContainsKey(Playe.UID)) {
                    uLink.NetworkView.Get(Playe.PlayerClient.networkView).RPC("GKillSound", Playe.NetworkPlayer, ssound);
                }
            } catch {
                ConsoleSystem.PrintError("Gsoundkill erroras:3");
            }
        }
        public void OnPlayerDc(Fougerite.Player Playe) {
            PlData laik;
            if (allplayers_data.TryGetValue(Playe.UID,out laik)) {
                allplayers_data.Remove(Playe.UID);
            } else {
                ConsoleSystem.PrintError("Gsoundkill erroras:4");
            }
        }
    }
}

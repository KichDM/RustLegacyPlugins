using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using RustBuster2016.API;

namespace GGrass {
    public class GGrassGUI : MonoBehaviour {
        public Texture2D ButtonOFF, ButtonHover, ButtonON;
        private bool Grass = true;
        public void Start() {
            ButtonOFF = new Texture2D(60, 16, TextureFormat.ARGB32, false); ButtonOFF.LoadImage(ToBytes("GGrass.Resources.BL_grass.png"));
            ButtonHover = new Texture2D(60, 16, TextureFormat.ARGB32, false); ButtonHover.LoadImage(ToBytes("GGrass.Resources.YE_grass.png"));
            ButtonON = new Texture2D(60, 16, TextureFormat.ARGB32, false); ButtonON.LoadImage(ToBytes("GGrass.Resources.GR_grass.png"));
            Debug.Log("Starting Grass button By Gintaras");
        }
        public static byte[] ToBytes(string x) {
            return ReadFully(Assembly.GetExecutingAssembly().GetManifestResourceStream(x));
        }
        public static byte[] ReadFully(Stream input) {
            byte[] buffer = new byte[16384];
            using (MemoryStream memoryStream = new MemoryStream()) {
                int count;
                while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);
                return memoryStream.ToArray();
            }
        }

        public void OnGUI() {
            int w = Screen.width, h = Screen.height;
            Rect RGrass = new Rect(0, 20, 60, 16);
            if (RGrass.Contains(Event.current.mousePosition)) {
                GUI.DrawTexture(RGrass, ButtonHover, ScaleMode.StretchToFill);
                if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                    switchgrass();
                }
            } else {
                if (Grass) {
                    GUI.DrawTexture(RGrass, ButtonON, ScaleMode.StretchToFill);
                } else {
                    GUI.DrawTexture(RGrass, ButtonOFF, ScaleMode.StretchToFill);
                }
            }
        }
        private void switchgrass() {
            if (Grass) {
                Grass = false;
                ConsoleWindow.singleton.RunCommand("grass.on false");
                Terrain.activeTerrain.heightmapPixelError = 110;
                Terrain.activeTerrain.detailObjectDistance = 0;
                Terrain.activeTerrain.treeDistance = 225;
                Terrain.activeTerrain.treeMaximumFullLODCount = 0;
            } else {
                Grass = true;
                ConsoleWindow.singleton.RunCommand("grass.on true");
                Terrain.activeTerrain.heightmapPixelError = 30;
                Terrain.activeTerrain.detailObjectDistance = 134;
                Terrain.activeTerrain.treeDistance = 2000;
                Terrain.activeTerrain.treeMaximumFullLODCount = 60;
            }
        }
    }
}

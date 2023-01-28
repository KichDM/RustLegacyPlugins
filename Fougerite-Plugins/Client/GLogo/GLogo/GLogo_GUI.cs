﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GLogo {
    public class GLogo_GUI : MonoBehaviour {
        public bool ShowMap = false;
        public Texture2D imageLogo;
        public void Start() {
            byte[] bytes = Convert.FromBase64String("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");
            imageLogo = new Texture2D(200, 200, TextureFormat.RGBA32, false);
            //imageMap.anisoLevel = 0;
            //imageMap.filterMode = FilterMode.Trilinear;
            imageLogo.LoadImage(bytes);
            Debug.Log("Start G Logo By Gintaras");
        }
        public void OnGUI() {
            int w = Screen.width, h = Screen.height;
            int rate = 125;
            GUI.DrawTexture(new Rect(w - rate, 0, rate, rate), imageLogo, ScaleMode.StretchToFill);
        }
    }
}
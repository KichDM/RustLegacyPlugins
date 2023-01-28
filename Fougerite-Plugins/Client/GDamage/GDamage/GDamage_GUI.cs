using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GDamage {
    class GDamage_GUI : MonoBehaviour {
        public Texture dotTexture;
        /*float deltaTime = 0.0f;
        public void Update() {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        }
        */
        public void OnGUI() {
            var PlayerTrans = PlayerClient.GetLocalPlayer().controllable.GetComponent<Character>().healthLoss

            /*GUI.contentColor = Color.white;
            int w = Screen.width, h = Screen.height;
            GUIStyle style = new GUIStyle();
            Rect rect = new Rect(0, h - h * 3 / 100, w / 4, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = Color.white;
            style.richText = true;
            float fps = 1.0f / deltaTime;
            string text = "<b>FPS: " + Math.Round(fps) + "</b>";
            GUI.Label(rect, text, style);*/
            GUI.DrawTexture(new Rect(100, 100, this.dotTexture.width, this.dotTexture.height), this.dotTexture);
        }
    }
}

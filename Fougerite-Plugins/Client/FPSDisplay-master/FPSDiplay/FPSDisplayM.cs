using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FPSDiplay
{
    public class FPSDisplayM : MonoBehaviour
    {
        float deltaTime = 0.0f;
        public void Update()
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        }

        public void OnGUI()
        {
            GUI.contentColor = Color.blue;
            int w = Screen.width, h = Screen.height;
            GUIStyle style = new GUIStyle();
            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = Color.yellow;    
            float fps = 1.0f / deltaTime;
            string text = "(FPS: " + Math.Round(fps) + " )";
            GUI.Label(rect, text, style);   
        }
    }
}

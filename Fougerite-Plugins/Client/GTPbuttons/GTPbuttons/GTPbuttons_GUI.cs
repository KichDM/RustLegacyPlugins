using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using RustBuster2016;
using RustBuster2016.API;

namespace GTPbuttons {
    public class GTPbuttonsGUI : MonoBehaviour {
        public Texture2D SButtonOFF, SButtonHover, SButtonON;
        public Texture2D AButtonOFF, AButtonHover, AButtonON;
        public Texture2D HButtonOFF, HButtonHover, HButtonON;

        public Texture2D KButtonOFF, KButtonHover, KButtonON;
        public Texture2D PButtonOFF, PButtonHover, PButtonON;
        public Texture2D DButtonOFF, DButtonHover, DButtonON;
        bool menu = false, arena = true, small = false, hangar = false,
            kit = false, p250 = false, kdefault = true;
        public void Start() {
            AButtonOFF = new Texture2D(60, 16, TextureFormat.ARGB32, false); AButtonOFF.LoadImage(ToBytes("GTPbuttons.Resources.BL_menu.png"));
            AButtonHover = new Texture2D(60, 16, TextureFormat.ARGB32, false); AButtonHover.LoadImage(ToBytes("GTPbuttons.Resources.YE_menu.png"));
            AButtonON = new Texture2D(60, 16, TextureFormat.ARGB32, false); AButtonON.LoadImage(ToBytes("GTPbuttons.Resources.GR_menu.png"));

            SButtonOFF = new Texture2D(60, 16, TextureFormat.ARGB32, false); SButtonOFF.LoadImage(ToBytes("GTPbuttons.Resources.BL_small.png"));
            SButtonHover = new Texture2D(60, 16, TextureFormat.ARGB32, false); SButtonHover.LoadImage(ToBytes("GTPbuttons.Resources.YE_small.png"));
            SButtonON = new Texture2D(60, 16, TextureFormat.ARGB32, false); SButtonON.LoadImage(ToBytes("GTPbuttons.Resources.GR_small.png"));

            HButtonOFF = new Texture2D(60, 16, TextureFormat.ARGB32, false); HButtonOFF.LoadImage(ToBytes("GTPbuttons.Resources.BL_hangar.png"));
            HButtonHover = new Texture2D(60, 16, TextureFormat.ARGB32, false); HButtonHover.LoadImage(ToBytes("GTPbuttons.Resources.YE_hangar.png"));
            HButtonON = new Texture2D(60, 16, TextureFormat.ARGB32, false); HButtonON.LoadImage(ToBytes("GTPbuttons.Resources.GR_hangar.png"));

            KButtonOFF = new Texture2D(60, 16, TextureFormat.ARGB32, false); KButtonOFF.LoadImage(ToBytes("GTPbuttons.Resources.BL_kit.png"));
            KButtonHover = new Texture2D(60, 16, TextureFormat.ARGB32, false); KButtonHover.LoadImage(ToBytes("GTPbuttons.Resources.YE_kit.png"));
            KButtonON = new Texture2D(60, 16, TextureFormat.ARGB32, false); KButtonON.LoadImage(ToBytes("GTPbuttons.Resources.GR_kit.png"));

            PButtonOFF = new Texture2D(60, 16, TextureFormat.ARGB32, false); PButtonOFF.LoadImage(ToBytes("GTPbuttons.Resources.BL_P250.png"));
            PButtonHover = new Texture2D(60, 16, TextureFormat.ARGB32, false); PButtonHover.LoadImage(ToBytes("GTPbuttons.Resources.YE_P250.png"));
            PButtonON = new Texture2D(60, 16, TextureFormat.ARGB32, false); PButtonON.LoadImage(ToBytes("GTPbuttons.Resources.GR_P250.png"));

            DButtonOFF = new Texture2D(60, 16, TextureFormat.ARGB32, false); DButtonOFF.LoadImage(ToBytes("GTPbuttons.Resources.BL_default.png"));
            DButtonHover = new Texture2D(60, 16, TextureFormat.ARGB32, false); DButtonHover.LoadImage(ToBytes("GTPbuttons.Resources.YE_default.png"));
            DButtonON = new Texture2D(60, 16, TextureFormat.ARGB32, false); DButtonON.LoadImage(ToBytes("GTPbuttons.Resources.GR_default.png"));
            Debug.Log("Starting TP and Kit Meniu By Gintaras");
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
            Rect Rmenu = new Rect(61, 0, 60, 16);
            Menuitem(Rmenu, AButtonOFF, AButtonHover, AButtonON, ref menu);
            Rect Rkit = new Rect(122, 0, 60, 16);
            Menuitem(Rkit, KButtonOFF, KButtonHover, KButtonON, ref kit);
            if (menu) {
                Rect Rarena = new Rect(61, 18, 60, 16);
                Rect Rsmall = new Rect(61, 36, 60, 16);
                Rect Rhangar = new Rect(61, 54, 60, 16);
                if (Rarena.Contains(Event.current.mousePosition)) {
                    GUI.DrawTexture(Rarena, AButtonHover, ScaleMode.StretchToFill);
                    if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                        if (!arena) {
                            arena = true;
                            small = false;
                            hangar = false;
                            string msg = GTPbuttons.Instance.SendMessageToServer("arena");
                            if (msg == "yes") {
                                arena = true;
                            }
                        }
                    }
                } else {
                    if (arena) {
                        GUI.DrawTexture(Rarena, AButtonON, ScaleMode.StretchToFill);
                    } else {
                        GUI.DrawTexture(Rarena, AButtonOFF, ScaleMode.StretchToFill);
                    }
                }

                if (Rsmall.Contains(Event.current.mousePosition)) {
                    GUI.DrawTexture(Rsmall, SButtonHover, ScaleMode.StretchToFill);
                    if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                        if (!small) {
                            arena = false;
                            small = true;
                            hangar = false;
                            string msg = GTPbuttons.Instance.SendMessageToServer("small");
                            if (msg == "yes") {
                                small = true;
                            }
                        }
                    }
                } else {
                    if (small) {
                        GUI.DrawTexture(Rsmall, SButtonON, ScaleMode.StretchToFill);
                    } else {
                        GUI.DrawTexture(Rsmall, SButtonOFF, ScaleMode.StretchToFill);
                    }
                }

                if (Rhangar.Contains(Event.current.mousePosition)) {
                    GUI.DrawTexture(Rhangar, HButtonHover, ScaleMode.StretchToFill);
                    if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                        if (!hangar) {
                            arena = false;
                            small = false;
                            hangar = true;
                            string msg = GTPbuttons.Instance.SendMessageToServer("hangar");
                            if (msg == "yes") {
                                hangar = true;
                            }
                        }
                    }
                } else {
                    if (hangar) {
                        GUI.DrawTexture(Rhangar, HButtonON, ScaleMode.StretchToFill);
                    } else {
                        GUI.DrawTexture(Rhangar, HButtonOFF, ScaleMode.StretchToFill);
                    }
                }
            }
            if (kit) {
                Rect RP250 = new Rect(122, 18, 60, 16);
                Rect Rdefault = new Rect(122, 36, 60, 16);
                if (RP250.Contains(Event.current.mousePosition)) {
                    GUI.DrawTexture(RP250, DButtonHover, ScaleMode.StretchToFill);
                    if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                        if (!kdefault) {
                            kdefault = true;
                            p250 = false;
                            string msg = GTPbuttons.Instance.SendMessageToServer("default");
                            if (msg == "yes") {
                                kdefault = true;
                            }
                        }
                    }
                } else {
                    if (kdefault) {
                        GUI.DrawTexture(RP250, DButtonON, ScaleMode.StretchToFill);
                    } else {
                        GUI.DrawTexture(RP250, DButtonOFF, ScaleMode.StretchToFill);
                    }
                }

                if (Rdefault.Contains(Event.current.mousePosition)) {
                    GUI.DrawTexture(Rdefault, PButtonHover, ScaleMode.StretchToFill);
                    if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                        if (!p250) {
                            kdefault = false;
                            p250 = true;
                            string msg = GTPbuttons.Instance.SendMessageToServer("p250");
                            if (msg == "yes") {
                                p250 = true;
                            }
                        }
                    }
                } else {
                    if (p250) {
                        GUI.DrawTexture(Rdefault, PButtonON, ScaleMode.StretchToFill);
                    } else {
                        GUI.DrawTexture(Rdefault, PButtonOFF, ScaleMode.StretchToFill);
                    }
                }
            }
        }
        public void Menuitem(Rect pos, Texture2D off, Texture2D hover, Texture2D on, ref bool a) {
            if (pos.Contains(Event.current.mousePosition)) {
                GUI.DrawTexture(pos, hover, ScaleMode.StretchToFill);
                if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                    if (a) {
                        a = false;
                    } else {
                        a = true;
                    }
                }
            } else {
                if (a) {
                    GUI.DrawTexture(pos, on, ScaleMode.StretchToFill);
                } else {
                    GUI.DrawTexture(pos, off, ScaleMode.StretchToFill);
                }
            }
        }
    }
}
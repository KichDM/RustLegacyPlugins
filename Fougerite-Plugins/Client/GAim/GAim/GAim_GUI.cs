using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using UnityEngine;

namespace GAim {
    public class GAim_GUI : MonoBehaviour {
        private bool ShowAim = true;
        public Texture2D Taskelis;
        public Texture2D ButtonOFF;
        public Texture2D ButtonHover;
        public Texture2D ButtonON;
        public void Start() {
            byte[] Byteimage = System.Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKBAMAAAB/HNKOAAAAHlBMVEUAAAAAAAEAAAEAAAEAAAH////y8vKtra0mJifv7+/kN/yFAAAABXRSTlMA8q1Ehq9quroAAAAuSURBVAjXY2AwElRmYGBpT6twYLCYGhrZzKAeGhpaxCAGJBMhJEQEIgtRCdEFAKbfDjcgZsgTAAAAAElFTkSuQmCC");
            byte[] BButtonOFF = System.Convert.FromBase64String("/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQECAgICAgICAgICAgMDAwMDAwMDAwP/2wBDAQEBAQEBAQIBAQICAgECAgMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwP/wAARCAAQADwDAREAAhEBAxEB/8QAGAAAAwEBAAAAAAAAAAAAAAAABQgJCgb/xAAwEAAABQMBBAgHAQAAAAAAAAACBAUGBwEDCBMACRUWERIUITNUpNMKIiQxMlNVYf/EABQBAQAAAAAAAAAAAAAAAAAAAAD/xAAUEQEAAAAAAAAAAAAAAAAAAAAA/9oADAMBAAIRAxEAPwDIwtramUUzJcuZ07NvR6gNEuPo65e0MXzDtCFXpEKte+uwCuZFrzvpynsbBpMgncxtCVN0A780luTZNSsxFmMpwyMg2GE+8zOS3Xj7j47mWgvtaUmbfYpp8rKqYIqZgZU2SXSlilxZSK0K3qUuAMgsUQ4l4sPfc6ZC7wFxEslKThB0tJ0CF0BFmmJE+KXI7XoWaV5ryHebh7F5XdyW3GwN+lO3t0K/fMq9E69pLCd2sHYwqxOHw5bPSJL3cwIOlOYlKE8iTIbeW7seqtHSytQyTTYxJzUpKbbPIUaNdDbZBdYSQulyFxatKHZ1G2SEOhkF6tsQQy3weKDH3fmekp4uQ063+5o/Y7fjNVSViTTjSWXiYMPOPW47FQCioNVnMxFu2bCir3QF6W0+yINgIaDqMVKjEExeZFrzvpynsbB1XEjvLHEdb6z92na/oaHh6el4Xd+P+/fYBS2iKZtTMmC5bUs3NHqD1i4OnqF7QBfKO6EVOgQa076bAK5bWvJeoKe/sGslt7+2LIoy1xGJxJDb0Bu5cfMSymK7wjl2QxjoYyTc6QaaqsmuVUbz/MO5yOhIS1xxJLVOH0i0+Saas8FFdO2RGhhvUBFkbLnB5n7rXL/AVoX8tLDknfIxWyAjNXU4Phq802oSZ6k3wRVGzsWqZbXnAcA4kJhplFxeLpt24imFAzQunKwSdsZ4GeyO+ICkRVeBxs4vNhyIePsqYx4ywROSdLjdRrMjpSrDqm9rT/XIaqzJfPtlPC+2e7uFXjCsK+I4XsgCIsUHaBeqEu98Hlex94HnpKeUcNNR/tmP3w34zSklHk0m0kZ4lzDMj1uNNUGop7VeLzRbVm+opF0ZettQvCFYEGo6AFWoAhMXlta8l6gp7+wdVw07yxw7R+s/TqWv6Gv4mppeF3/l/n32D//Z");
            byte[] BButtonHover = System.Convert.FromBase64String("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");
            byte[] BButtonON = System.Convert.FromBase64String("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");
            Taskelis = new Texture2D(10, 10, TextureFormat.RGBA32, false);
            ButtonOFF = new Texture2D(60, 16, TextureFormat.RGB24, false);
            ButtonHover = new Texture2D(60, 16, TextureFormat.RGB24, false);
            ButtonON = new Texture2D(60, 16, TextureFormat.RGB24, false);
            Taskelis.LoadImage(Byteimage);
            ButtonOFF.LoadImage(BButtonOFF);
            ButtonHover.LoadImage(BButtonHover);
            ButtonON.LoadImage(BButtonON);
            Debug.Log("Start AIM Dot By Gintaras");

        }
        public void OnGUI() {
            int w = Screen.width, h = Screen.height;
            Rect Mikpos = new Rect(0, 0, 60, 16);

            if (Mikpos.Contains(Event.current.mousePosition)) {
                GUI.DrawTexture(Mikpos, ButtonHover, ScaleMode.StretchToFill);
                if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                    if (ShowAim) {
                        ShowAim = false;
                    } else {
                        ShowAim = true;
                    }
                }
            } else {
                if (ShowAim) {
                    GUI.DrawTexture(Mikpos, ButtonON, ScaleMode.StretchToFill);
                } else {
                    GUI.DrawTexture(Mikpos, ButtonOFF, ScaleMode.StretchToFill);
                }
            }
            if (ShowAim) {
                GUI.DrawTexture(new Rect(w / 2 - h / 400, h / 2- h / 400, h / 200, h / 200), Taskelis, ScaleMode.StretchToFill);
            }
        }
    }
}


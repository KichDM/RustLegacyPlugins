using System;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RustBuster2016.API;
using UnityEngine;
using uLink;

namespace GSoundkill {
    public class GSoundkill_GUI : UnityEngine.MonoBehaviour {
        public Texture2D ButtonOFF, ButtonHover, ButtonON;
        private bool ifplay = true;
        private string absolutePath = "./RB_Data/MCK/GKillSounds"; // relative path to where the app is running
        private static AudioSource src;
        internal Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
        internal Dictionary<int, string> clipnames = new Dictionary<int, string>(){
            {1,"firstblood.wav"},
            {2,"nade.wav"},
            {3,"ownage.wav"},
            {4,"eagleeye.wav"},
            {5,"flawlessvictory.wav"},
            {6,"payback.wav"},
            {7,"hattrick.wav"},
            {8,"headhunter.wav"},
            {9,"headshot.wav"},
            {10,"headshot2.wav"},
            {11,"headshot3.wav"},
            {12,"humiliatingdefeat.wav"},
            {13,"humiliatingdefeat1.wav"},
            {14,"humiliatingdefeat2.wav"},
            {15,"multikill.wav"},
            {16,"triplekill.wav"},
            {17,"killingspree.wav"},
            {18,"rampage.wav"},
            {19,"dominating.wav"},
            {20,"unstoppable.wav"},
            {21,"megakill.wav"},
            {22,"ultrakill.wav"},
            {23,"monsterkill.wav"},
            {24,"ludicrouskill.wav"},
            {25,"whickedsick.wav"},
            {26,"holyshit.wav"},
            {27,"godlike.wav"},
            {28,"prepare.wav"},
            {29,"prepare2.wav"},
            {30,"prepare3.wav"},
            {31,"prepare4.wav"}
        };
        private string[] fileTypes = { "ogg", "wav" };
        private FileInfo[] files;
        public void Start() {
            ButtonOFF = new Texture2D(60, 16, TextureFormat.ARGB32, false); ButtonOFF.LoadImage(ToBytes("GSoundkill.Resources.BL_sound.png"));
            ButtonHover = new Texture2D(60, 16, TextureFormat.ARGB32, false); ButtonHover.LoadImage(ToBytes("GSoundkill.Resources.YE_sound.png"));
            ButtonON = new Texture2D(60, 16, TextureFormat.ARGB32, false); ButtonON.LoadImage(ToBytes("GSoundkill.Resources.GR_sound.png"));
            if (src == null) src = gameObject.AddComponent<AudioSource>();
            reloadSounds();
        }
        public void OnGUI() {
            int w = Screen.width, h = Screen.height;
            Rect Rmenu = new Rect(61, 20, 60, 16);
            if (Rmenu.Contains(Event.current.mousePosition)) {
                GUI.DrawTexture(Rmenu, ButtonHover, ScaleMode.StretchToFill);
                if (Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1")) {
                    if (ifplay) {
                        ifplay = false;
                    } else {
                        ifplay = true;
                    }
                }
            } else {
                if(ifplay) {
                    GUI.DrawTexture(Rmenu, ButtonON, ScaleMode.StretchToFill);
                } else {
                    GUI.DrawTexture(Rmenu, ButtonOFF, ScaleMode.StretchToFill);
                }
            }
        }
        public void PlaySound(int nr) {
            if(ifplay) {
                src.clip = clips[clipnames[nr]];
                src.Play();
            }
        }
        public void reloadSounds() {
            DirectoryInfo info = new DirectoryInfo(absolutePath);
            files = info.GetFiles();

            foreach (FileInfo f in files) {
                if (validFileType(f.FullName)) {
                    StartCoroutine(loadFile(f.FullName));
                }
            }
        }

        public bool validFileType(string filename) {
            foreach (string ext in fileTypes) {
                if (filename.IndexOf(ext) > -1) return true;
            }
            return false;
        }

        public IEnumerator loadFile(string path) {
            WWW www = new WWW("file://" + path);

            AudioClip myAudioClip = www.audioClip;
            while (!myAudioClip.isReadyToPlay)
                yield return www;

            AudioClip clip = www.GetAudioClip(false);
            string[] parts = path.Split('\\');
            clip.name = parts[parts.Length - 1];
            clips[parts[parts.Length - 1]] = clip;
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
        [RPC]
        public void GKillSound(int sound) {
            if(sound>0&&sound<32) {
                PlaySound(sound);
            }
        }
    }
}



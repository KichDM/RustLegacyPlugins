using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RustBuster2016;
using System.Collections;
using RustBuster2016.API.Events;

namespace GDeathMSG {
    class GDeathMSG_GUI:MonoBehaviour {
        public Texture2D Backgrounds;
        GUIStyle style = new GUIStyle();
        Font fontas;
        public static GDeathMSG_GUI Instancija;
        AssetBundle bundle;
        private string absolutePath = "./RB_Data/MCK";
        private FileInfo[] files;
        internal Dictionary<string, char> charlib = new Dictionary<string, char>(){
            {"head",'\uE000'},{"deagle",'\uE001'},{"dual",'\uE002'},{"fseven",'\uE003'},{"glock",'\uE004'},{"ak47",'\uE007'},{"aug",'\uE008'},{"awp",'\uE009'},{"famas",'\uE00A'},{"g3sg1",'\uE00B'},{"galil",'\uE00D'},{"m4a4",'\uE00E'},
            {"m4a1",'\uE010'},{"mac10",'\uE011'},{"p2000",'\uE013'},{"ump45",'\uE018'},{"xm1014",'\uE019'},{"bazon",'\uE01A'},{"mag7",'\uE01B'},{"negev",'\uE01C'},{"blender",'\uE01D'},{"tec9",'\uE01E'},{"zap",'\uE01F'},
            {"p250",'\uE020'},{"mp7",'\uE021'},{"mp9",'\uE022'},{"nova",'\uE023'},{"p90",'\uE024'},{"scar20",'\uE026'},{"sg553",'\uE027'},{"scout",'\uE028'},{"knife",'\uE02A'},{"flash",'\uE02B'},{"granade",'\uE02C'},{"smoke",'\uE02D'},{"flame",'\uE02E'},{"decoy",'\uE02F'},
            {"flame1",'\uE030'},{"c4",'\uE031'},{"knife1",'\uE03B'},{"m249",'\uE03C'},{"usp",'\uE03D'},{"cz75",'\uE03F'},
            {"revolver",'\uE040'},{"shield",'\uE064'},{"shield1",'\uE065'},{"defuze",'\uE066'},
            {"kbayonet",'\uE1F4'},{"kflip",'\uE1F9'},{"kgut",'\uE1FA'},{"kkarambit",'\uE1FB'},{"km9",'\uE1FC'},{"khuntsman",'\uE1FD'},
            {"kfalchion",'\uE200'},{"kbowie",'\uE202'},{"kbutterfly",'\uE203'},{"kshadow",'\uE204'}
        };
        internal List<DeathData> showdata = new List<DeathData>();
        public void Start() {
            Instancija = this;
            Backgrounds = new Texture2D(298, 30, TextureFormat.ARGB32, false); Backgrounds.LoadImage(ToBytes("GDeathMSG.Resources.background.png"));
            style.alignment = TextAnchor.MiddleRight;
            style.normal.textColor = Color.white;
            style.richText = true;
            DirectoryInfo info = new DirectoryInfo(absolutePath);
            files = info.GetFiles("csgo_icons.unity3d");
            if (fontas == null) {
                StartCoroutine(downloading());
            } else {
                style.font = fontas;
            }
            GDeathMSG.Instancija.RBactivate();
            SphereCollider colider=this.gameObject.AddComponent<SphereCollider>();
            colider.radius = 1f;
        }
        void OnDestroy() {
            if(bundle!=null) {
                bundle.Unload(true);
            }
        }
        private void destroyterrain() {
            Destroy(Terrain.activeTerrain.gameObject);
        }
        public void OnChat(ChatEvent ce) {
            if (ce.ChatUI.textInput.Text.Contains("/destworld")) {
                Debug.Log("shit happens");
                destroyterrain();
            } else if(ce.ChatUI.textInput.Text.Contains("/worldg")) {
                var file = new System.IO.StreamWriter(RustBuster2016.API.Hooks.GameDirectory+ "\\Objects.txt", true);
                GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
                foreach (GameObject go in allObjects) {
                    string linija="";
                    if (go.activeInHierarchy&& go.name!=""&& !IsDigitsOnly(go.name)) {
                        linija = go.name+" child: ";
                        Transform[] ts = go.GetComponentsInChildren<Transform>();
                        if (ts != null) {
                            foreach (Transform t in ts) {
                                if (t != null && t.gameObject != null)
                                    linija += t.gameObject.name + ", ";
                            }
                        }
                    }
                    if (linija != "") {
                        file.WriteLine(linija);
                    }
                }
                file.Close();
            } else if (ce.ChatUI.textInput.Text.Contains("/apclient")) {
                foreach (Player a in GameObject.FindObjectsOfType<Player>()) {
                    Debug.Log(a.name+" "+a.gameObject.transform.position.x.ToString()+" "+ a.gameObject.transform.position.y.ToString()+" "+a.gameObject.transform.position.z.ToString());
                    RustBuster2016.API.Hooks.LogData("death",a.name);
                }
            }
        }
        bool IsDigitsOnly(string str) {
            foreach (char c in str) {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public void OnGUI() {
            if (fontas == null) return;
            float w = (float)Screen.width, h = (float)Screen.height;
            float hdydis = 30 * (h/1000);
            float wdydis = 300 * (w / 1500);
            style.fontSize = (int)(20 * (h / 1000));
            float haddon = 125f;
            foreach(DeathData one in showdata){
                GUI.DrawTexture(new Rect(w - wdydis, haddon, wdydis, hdydis), Backgrounds, ScaleMode.StretchToFill);
                GUI.Label(new Rect(w - wdydis, haddon, wdydis, hdydis), "<b><color=\"#89ff8b\">"+one.att_name+ "</color> "+charlib[one.weap].ToString()+" "+(one.head? charlib["head"].ToString():"")+" <color=\"#ff9696\">" + one.vic_name + "</color> <color=\"#7fb0ff\">" + one.distance.ToString() + "m</color></b>", style);
                if(one.time<= Time.time) {
                    showdata.Remove(one);
                }
                haddon += hdydis + 1f;
            }
        }
        public IEnumerator downloading() {
            WWW www = WWW.LoadFromCacheOrDownload("file://" + files[0].FullName,1);
            yield return www;
            bundle = www.assetBundle;
            fontas = (Font)bundle.mainAsset;
            style.font = fontas;
            www.Dispose();
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
        public void GDeathMessage(string att_namei, string vic_namei, string weapi, bool headi, int distancei) {
            //RustBuster2016.API.Hooks.LogData("deathmsg", "trying rpc"+ att_namei+" "+ vic_namei);
            DeathData newone = new DeathData {time=(Time.time+10), att_name = att_namei, vic_name = vic_namei, weap = weapi, head = headi, distance = distancei };
            if(showdata.Count>4) {
                showdata.RemoveAt(0);
            }
            showdata.Add(newone);

        }
    }
    public class DeathData {
        public DeathData() { }
        public DeathData(float timei, string att_namei, string vic_namei, string weapi, bool headi, int distancei) {
            time = timei;
            att_name = att_namei;
            vic_name = vic_namei;
            weap = weapi;
            head = headi;
            distance = distancei;
        }
        public float time { get; set; }
        public string att_name { get; set; }
        public string vic_name { get; set; }
        public string weap { get; set; }
        public bool head { get; set; }
        public int distance { get; set; }
    }
}

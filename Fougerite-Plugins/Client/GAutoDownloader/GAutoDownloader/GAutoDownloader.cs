using System;
using System.IO;
using System.Linq;
using Fougerite;
using RustBuster2016Server;
using System.Text.RegularExpressions;

namespace GAutoDownloader {
    public class GAutoDownloader : Fougerite.Module {
        public string folderis;

        public override string Name { get { return "GAutoDownloader"; } }
        public override string Author { get { return "Gintaras"; } }
        public override string Description { get { return "Auto sends files to player"; } }
        public override Version Version { get { return new Version("0.2"); } }

        public override void Initialize() {
            Hooks.OnModulesLoaded += OnMLoad;
            Hooks.OnConsoleReceived += OnConsole;
        }

        public override void DeInitialize() {
            Hooks.OnModulesLoaded -= OnMLoad;
            Hooks.OnConsoleReceived -= OnConsole;
        }
        public void OnMLoad() {
            this.LoadConfig();
            AddRBdownloadables();
        }
        public void OnConsole(ref ConsoleSystem.Arg arg, bool external) {
            if (arg.Class == "gauto") {
                if (arg.Function == "reload") {
                    if (!external) {
                        if (arg.argUser.admin) {
                            this.LoadConfig();
                            WipeRBdownloadables();
                            AddRBdownloadables();
                        }
                    } else {
                        AddRBdownloadables();
                    }
                } else if (arg.Function == "load") {
                    if (!external) {
                        if (arg.argUser.admin) {
                            this.LoadConfig();
                            AddRBdownloadables();
                        }
                    } else {
                        AddRBdownloadables();
                    }
                } else if (arg.Function == "unload") {
                    if (!external) {
                        if (arg.argUser.admin) {
                            WipeRBdownloadables();
                        }
                    } else {
                        WipeRBdownloadables();
                    }
                }
            }
        }
        public void AddRBdownloadables() {
            string a = Util.GetRootFolder() + "\\AutoSendFiles";
            if (!Directory.Exists(a)) {
                Directory.CreateDirectory(a);
            }
            if (!Directory.Exists(a)) {
                ConsoleSystem.PrintError("System Cant Create AutoSendFiles folder");
            }
            Regex rx = new Regex("^[A-Za-z0-9]+$");
            if (folderis == null || folderis == "" || !rx.IsMatch(folderis)) {
                ConsoleSystem.PrintError("Your settings folder can only contain A-Z a-z 0-9");
            } else {
                ConsoleSystem.Print("Starting GAutoDownloader searching...");
                if(CheckIfDirNotEmpty(a)){
                    DirectoryInfo b = new DirectoryInfo(a);
                    foreach (var c in b.GetFiles("*.*", SearchOption.AllDirectories)) {
                        string fold = c.FullName.Replace(a, "").Replace(c.Name, "");
                        fold.Remove(fold.Length - 1);
                        bool addtest=API.AddFileToDownload(new RBDownloadable(this.folderis + fold, c.FullName));
                        if(!addtest) {
                            ConsoleSystem.PrintError("DBDownloadable has problem! try to update rustbuster");
                        }
                        ConsoleSystem.Print("added:" + fold + "\\" + c.Name);
                    }
                } else {
                    ConsoleSystem.PrintError("GAutoDownloader:There is nothing to send ");
                }
                ConsoleSystem.Print("Ending GAutoDownloader setting up RB.");
            }
        }
        public void WipeRBdownloadables() {
            ConsoleSystem.Print("GAutoDownloader Unloading files:");
            if (API.RBDownloadables.Any()) {
                foreach (var dfile in API.RBDownloadables) {
                    API.DeleteFileFromDownloadByClass(dfile);
                    ConsoleSystem.Print(dfile.Clientpath + dfile.Filename);
                }
            }
            ConsoleSystem.Print("GAutoDownloader ended unloading.");
        }
        public void LoadConfig() {
            if (!Directory.Exists(ModuleFolder)) {
                Directory.CreateDirectory(ModuleFolder);
            }
            if (!File.Exists(Path.Combine(ModuleFolder, "Settings.ini"))) {
                File.Create(Path.Combine(ModuleFolder, "Settings.ini")).Dispose();
                IniParser Settings = new IniParser(Path.Combine(ModuleFolder, "Settings.ini"));
                string SrvName = Fougerite.Server.GetServer().server_message_name;
                Regex rx = new Regex("\\[[^A-Z]+\\]");
                Regex rx1 = new Regex("[^a-zA-Z0-9-]");
                SrvName = rx.Replace(SrvName, "");
                SrvName = rx1.Replace(SrvName, "");
                Settings.AddSetting("Settings", "folder", SrvName);
                Settings.Save();
                this.folderis = SrvName;
            } else {
                IniParser Config = new IniParser(Path.Combine(ModuleFolder, "Settings.ini"));
                this.folderis = Config.GetSetting("Settings", "folder");
            }
        }
        public bool CheckIfDirNotEmpty(string a) {
            if (Directory.GetFiles(a).Length > 0) {
                return true;
            }
            string[] dir=Directory.GetDirectories(a);
            foreach (string di in dir) {
                if (Directory.GetFiles(di).Length > 0) {
                    return true;
                }
            }
            return false;
        }
    }
}
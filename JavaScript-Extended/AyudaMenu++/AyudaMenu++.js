//* By KichDM
//*TODO Para NovaLand Zero





//*Colores Designados mas facil para usar PA
var negro = "[color#000000]"
var gris = "[color#424242]"
var grisclaro = "[color#D8D8D8]"
var blanco = "[color#FFFFFF]"
var rosa = "[color#F781F3]"
var morado = "[color#6A0888]"
var rojo = "[color#FF0000]"
var azul = "[color#001EFF]"
var verde = "[color#00FF40]"
var azulclaro = "[color#00b7eb]"
var amarillo = "[color#FCFF02]"
var naranja = "[color#CD8C00]"
var marron = "[color#604200]"
var turquesa = "[color#00FFC0]"

// Lee el archivo ini
function iniset() {
    return Plugin.GetIni("ayuda_ajustes"); 
}

function Ainiset() {
    return Plugin.GetIni("admin_ayuda_ajustes");
}

// Esto creara un init si no esta creado o te falta esto lo hara atuomaticamente
function On_PluginInit() {

    if (!Plugin.IniExists("ayuda_ajustes")) {
        var inifile = Plugin.CreateIni("ayuda_ajustes");
        inifile.AddSetting("Ajustes", "Activo", true);
        inifile.AddSetting("Ajustes", "Mensajes", true);
        inifile.AddSetting("Ajustes", "TAG", "Server");
        inifile.AddSetting("Ajustes", "Color1", "[color#FF8000]");
        inifile.AddSetting("Ajustes", "Color2", "[color#00FFFF]");

        // Lista de comandos lo uso como paginas
        inifile.AddSetting("Comandos0", "/test=klk0");
        inifile.AddSetting("Comandos1", "/test=klk1");
        inifile.AddSetting("Comandos2", "/test=klk2");
        inifile.AddSetting("Comandos3", "/test=klk3");
        inifile.Save();
    }
     ///Este crea el init del admin tt
    if (!Plugin.IniExists("admin_ayuda_ajustes")) {
        var inifile = Plugin.CreateIni("admin_ayuda_ajustes");
        // Lista de comandos Admin eso de abajo lo uso como paginas
        inifile.AddSetting("AComandos0", "/test=klkA0");
        inifile.AddSetting("AComandos1", "/test=klkA1");
        inifile.AddSetting("AComandos2", "/test=klkA2");
        inifile.Save();
    }
}

//Cuando se conecta un player mensaje de ayuda :>
function On_PlayerConnected(Player) {
    var getinifile = iniset();
    var TAG = getinifile.GetSetting("Ajustes", "TAG");
    {
            Player.MessageFrom("" + TAG + "", "[color#FF8000]Para ver el menu de ayuda de comandos usa [color#FF8000]/ayuda");
        }
    }

//Cuando ejecutan el comando ayuda todo aca abajo izi
function On_Command(Player, cmd, args) {
    cmd = Data.ToLower(cmd);
    var getinifile = iniset();
    var inienum = getinifile.EnumSection("Comandos0");
    var inienum1 = getinifile.EnumSection("Comandos1");
    var inienum2 = getinifile.EnumSection("Comandos2");
    var inienum3 = getinifile.EnumSection("Comandos3");
    var color1 = getinifile.GetSetting("Ajustes", "Color1");
    var color2 = getinifile.GetSetting("Ajustes", "Color2");
    var TAG = getinifile.GetSetting("Ajustes", "TAG");

            if (cmd == "ayuda" || cmd == "comandos" || cmd == "help") {
                if (args.Length != 1)
                {
                    Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Ayuda - Comandos 1/4 =============");
                    for (var option in inienum) {
                        var name = getinifile.GetSetting("Comandos0", option);

                        Player.MessageFrom("[" + TAG + "]", color1 + option + color2 + " | " + name);

                    }
                    return;
                }

            switch (args[0].ToLower())
            {
                case "1":
                    Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Ayuda - Comandos 2/4 =============");
                    for (var option1 in inienum1) {
                        var name1 = getinifile.GetSetting("Comandos1", option1);

                        Player.MessageFrom("[" + TAG + "]", color1 + option1 + color2 + " | " + name1);

                    }
                break;

                case "2":
                    Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Ayuda - Comandos 3/4 =============");
                    for (var option2 in inienum2) {
                        var name2 = getinifile.GetSetting("Comandos2", option2);

                        Player.MessageFrom("[" + TAG + "]", color1 + option2 + color2 + " | " + name2);

                    }
                break;

                case "3":
                    Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Ayuda - Comandos 4/4 =============");
                    for (var option3 in inienum3) {
                        var name3 = getinifile.GetSetting("Comandos3", option3);

                        Player.MessageFrom("[" + TAG + "]", color1 + option3 + color2 + " | " + name3);

                    }
                break;

                case "clan":
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan create" + color2 +"<nombre> para crear un clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan invite" + color2 +"<player>    Invita a un jugador a un clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan" + color2 +"Información sobre el clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan disband" + color2 +"Disolver el clan, eliminar a todos los miembros..");     
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan dismiss" + color2 +"/clan dismiss.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan leave " + color2 +"Dejar el clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan members" + color2 +"Lista de jugadores del clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan abbr" + color2 +"Información sobre el clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/ayuda clan1" + color2 +"para ver la siguiente pagina de ayuda clan.");
                Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Ayuda Clanes 1/3 =============");
                break;

                case "clan1":
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan online" + color2 +"Lista de jugadores del clan en el servidor.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan transfer" + color2 +"<player>    Transfiere el clan a otro jugador.");
                Player.MessageFrom("[" + TAG + "]", color1 +"clan deposit" + color2 +"<value>    Capital del clan, cantidad de dinero.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan withdraw" + color2 +"<value>    Retirar dinero de la capital del clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan tax <value>" + color2 +"Establecer el impuesto para los miembros del clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan house" + color2 +"Establece el punto de casa, tu clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan warp" + color2 +"Teletransportación a la base del clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan war" + color2 +"<nombre del clan> Declaración de guerra contra otro clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/clan details" + color2 +"[on|off]    Activar / desactivar la información del clan.");
                Player.MessageFrom("[" + TAG + "]", color1 +"/ayuda clan2" + color2 +"para ver la siguiente pagina de ayuda clan.");
                Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Ayuda Clanes 2/3 =============");
                break;

                case "clan2":
                    Player.MessageFrom("[" + TAG + "]", color1 +"/clan motd" + color2 +"<message text>    Establezca un mensaje de saludo para el clan.");
                    Player.MessageFrom("[" + TAG + "]", color1 +"/clan [up|rise|grow|level]" + color2 +"Incrementa el nivel del clan.")
                    Player.MessageFrom("[" + TAG + "]", color1 +"/ayuda clan1" + color2 +"Para seguir viendo la pagina de ayuda clan.")
                    Player.MessageFrom("[" + TAG + "]", color1 +"/clan priv" + color2 +"<player>    Muestra los privilegios del miembro especificado en el clan.");
                    Player.MessageFrom("[" + TAG + "]", color1 +"/clan priv" + color2 +"<player> invite    Establece el privilegio de invitar a otros jugadores para un miembro del clan.");
                    Player.MessageFrom("[" + TAG + "]", color1 +"/clan priv" + color2 +"<player> dismiss    Permitir que un miembro expulse a los miembros del clan.");
                    Player.MessageFrom("[" + TAG + "]", color1 +"/clan priv" + color2 +"<player> management    Dale a un miembro la capacidad de administrar un clan.");
                    Player.MessageFrom("[" + TAG + "]", color1 +"/clan ffire" + color2 +"[on|off]    Enciende / apaga el fuego contra personas amigas del clan.");
                    Player.MessageFrom("[" + TAG + "]", color1 +"/clans" + color2 +"Muestra todos los clanes en el servidor.");
                    Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Ayuda Clanes 3/3 =============");
                    break;
                
                default:{
                    Player.MessageFrom("[" + TAG + "]",color2 + "=============Novaland Zero - Ayuda - Comandos 1/3 =============");
                    for (var option in inienum) {
                        var name = getinifile.GetSetting("Comandos0", option);

                        Player.MessageFrom("[" + TAG + "]", color1 + option + color2 + " | " + name);

                    }
                break;
            }
        }
       
    }
    
    var Agetinifile = Ainiset();
    var Ainienum = Agetinifile.EnumSection("AComandos0");
    var Ainienum1 = Agetinifile.EnumSection("AComandos1");
    var Ainienum2 = Agetinifile.EnumSection("AComandos2");
    var Ainienum3 = Agetinifile.EnumSection("AComandos3");
    var TAG = getinifile.GetSetting("Ajustes", "TAG");

/// Este es el help para el admin
    if (cmd == "ad" || cmd == "adminhelp" || cmd == "ayudaadmin" && Player.Admin) {
        if (args.Length != 1)
        {
            Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Admin Ayuda 1/4 - Comandos=============");
            for (var aoption in Ainienum) {
                var aname = Agetinifile.GetSetting("AComandos0", aoption);

                Player.MessageFrom("[" + TAG + "]", color1 + aoption + color2 + " | " + aname);


            }
            return;
        }

    switch (args[0].ToLower())
    {
        case "1":
            Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Admin Ayuda 2/4 - Comandos=============");
            for (var aoption1 in Ainienum1) {
                var aname1 = Agetinifile.GetSetting("AComandos1", aoption1);

                Player.MessageFrom("[" + TAG + "]", color1 + aoption1 + color2 + " | " + aname1);

            }
        break;

        case "2":
            Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Admin Ayuda 3/4 - Comandos=============");
            for (var aoption2 in Ainienum2) {
                var aname2 = Agetinifile.GetSetting("AComandos2", aoption2);

                Player.MessageFrom("[" + TAG + "]", color1 + aoption2 + color2 + " | " + aname2);

            }
        break;

        case "3":
            Player.MessageFrom("[" + TAG + "]", color2 + "=============Novaland Zero - Admin Ayuda 4/4 - Comandos=============");
            for (var aoption3 in Ainienum3) {
                var aname3 = Agetinifile.GetSetting("AComandos3", aoption3);

                Player.MessageFrom("[" + TAG + "]", color1 + aoption3 + color2 + " | " + aname3);

            }
        break;

        
        default:{
            Player.MessageFrom("[" + TAG + "]",color2 + "=============Novaland Zero - Admin Ayuda 1/4 - Comandos=============");
            for (var aoption in Ainienum) {
                var aname = Agetinifile.GetSetting("AComandos0", aoption);

                Player.MessageFrom("[" + TAG + "]", color1 + aoption + color2 + " | " + aname);

            }
        break;
            }
            
        }
    }

    // Ayudas apartes nada que ver con el plugin solo para novaland zero
    if (cmd == "contacto") {
        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤" +grisclaro+ "Dueño: "+azulclaro+"KichDM#6035");
        Player.MessageFrom("[" + TAG + "]",  rojo +"➤"  +grisclaro+ "Discord﹣  "+azulclaro+"discord.gg/t8WeFSYMfE");
        Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "Sitio Web﹣  "+azulclaro+"Se esta haciendo");
        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    }

    if (cmd == "staffonline" || cmd == "staff") {

        var user = Users.Find(Player.SteamID);
    if(user.Rank > 13 && user.Rank < 15)
    {
        Server.BroadcastFrom("Novaland Zero","[color#22AB22]["+ RustExtended.Core.Ranks[Users.GetBySteamID(Player.SteamID).Rank]+"] "+Player.Name );
    }
    else 
    {
        Server.BroadcastFrom( "Novaland Zero", "No hay staff on ");
    }
        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤" +grisclaro+ "Dueño: "+azulclaro+"KichDM#6035");
        Player.MessageFrom("[" + TAG + "]",  rojo +"➤"  +grisclaro+ "Discord﹣  "+azulclaro+"discord.gg/t8WeFSYMfE");
        Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "Sitio Web﹣  "+azulclaro+"Se esta haciendo");
        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    }

    if (cmd == "reglas") {
        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ 1. "+blanco+"Queda totalmente prohibido el uso de cualquier tipo de macro/hack .");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ 2. "+blanco+"El uso de discord es obligatorio en nuestro servidor.");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ 3. "+blanco+"No le niegue la TV/Test a un miembro del STAFF.");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ 4. "+blanco+"No se tolerará ningún tipo de ofensa al personal/jugadores..");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ 5. "+blanco+"Prohibido el uso de Bugs que se beneficien (ctrl bug y alt + enter son excepciones). ");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ 6. "+blanco+"La divulgación de enlaces maliciosos y otros servidores resultará en la prohibición .");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ 7. "+blanco+"El uso de apodos inapropiados resultará en el destierro .");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ 8. "+blanco+"Prohibido hacer bases anti-raids o en huecos bugueados del mapa.");
        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    }

    if (cmd == "dc" || cmd == "discord") {
        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        Player.MessageFrom("[" + TAG + "]", rojo + "➤ "+verde+"Discord " + azulclaro + "discord.gg/SPvSt2Jvdz");
        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
    }


    if(cmd == "vip")
	{
        if (args.Length == 0) { 
            Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Player.MessageFrom("[" + TAG + "]", rojo + "➤" +grisclaro+ "/vip comprar - "+azulclaro+"para consultar como comprar tu vip ");
            Player.MessageFrom("[" + TAG + "]",  rojo +"➤"  +grisclaro+ "/vip activacion - "+azulclaro+"para comprobar cómo activar su vip .");
            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "/vip precio -  "+azulclaro+"para comprobar los valores vip`s .");
            Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "Lista VIPS -  "+azulclaro+"Disponibles");
            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "/vip ferro -  "+azulclaro+"para comprobar los beneficios de vip ferro");
            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "/vip pedra -  "+azulclaro+"para comprobar los beneficios de la piedra vip");
            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "/vip maderia -  "+azulclaro+"para comprobar los beneficios de vip madeira ");
            Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            return; }
		switch (args[0].ToLower())
                {
                    case "comprar":
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Para comprar tu VIP ");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Realiza el pago en nuestra web/Discord");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Site﹣  "+azulclaro+"en desarrollo");
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "precio":
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Ferro﹣  "+azulclaro+"R$ 75,00 | $11 Dlrs [color clear]﹣  30 dias");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Pedra﹣  "+azulclaro+"R$ 45,00 | $9 Dlrs [color clear]﹣  30 dias");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Madeira﹣  "+azulclaro+"R$ 30,00 | $6 Dlrs [color clear]﹣  30 dias");
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "activacion":
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  [color clear]Para activar tu vip ");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  [color clear]Contacta a uno de los responsables ﹣  "+azulclaro+"/contato");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  [color clear]Presentar comprobante de pago ");
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "ferro":
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Habla en color en el chat del servidor ");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Tag"+azulclaro+"〔 FERRO 〕   "+blanco+"en el servidor de chat y discord");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Acesso aos 5 kits exclusivo ao vip ferro.");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Kits en el juego y ventajas exclusivas.");
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "pedra":
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Habla en color en el chat del servidor ");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Tag"+azulclaro+"〔 PEDRA 〕   "+blanco+"en el servidor de chat y discord");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Acesso aos 5 kits exclusivo ao vip pedra.");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Kits en el juego y ventajas exclusivas.");
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "madeira":
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Habla en color en el chat del servidor ");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Tag"+azulclaro+"〔 MADEIRA 〕   "+blanco+"en el servidor de chat y discord");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Acesso aos 4 kits exclusivo ao vip madeira.");
                        Player.MessageFrom("[" + TAG + "]", rojo+"➤  "+blanco+"Kits en el juego y ventajas exclusivas.");
                        Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    default:
                        {
                            Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            Player.MessageFrom("[" + TAG + "]", rojo + "➤" +grisclaro+ "/vip comprar - "+azulclaro+"para consultar como comprar tu vip ");
                            Player.MessageFrom("[" + TAG + "]",  rojo +"➤"  +grisclaro+ "/vip activacion - "+azulclaro+"para comprobar cómo activar su vip .");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "/vip precio -  "+azulclaro+"para comprobar los valores vip`s .");
                            Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "Lista VIPS -  "+azulclaro+"Disponibles");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "/vip ferro -  "+azulclaro+"para comprobar los beneficios de vip ferro");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "/vip pedra -  "+azulclaro+"para comprobar los beneficios de la piedra vip");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤"  +grisclaro+ "/vip maderia -  "+azulclaro+"para comprobar los beneficios de vip madeira ");
                            Player.MessageFrom("[" + TAG + "]", blanco + "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            break;
                        }
                }
            }

        if(cmd == "tags")
        {
            if (args.Length == 0) { 
                Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Player.MessageFrom("[" + TAG + "]", rojo + "➤  "  +grisclaro+ "/tags dv﹣  "  +azulclaro+ "utiliza para ver los requisitos de un divulgador ");
                Player.MessageFrom("[" + TAG + "]", rojo + "➤  "  +grisclaro+ "/tags yt﹣  "  +azulclaro+ "utiliza para ver los requisitos de un youtuber");
                Player.MessageFrom("[" + TAG + "]", rojo + "➤  "  +grisclaro+ "/tags mod﹣  "  +azulclaro+ "utiliza para ver los requisitos de un moderador");
                Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                return; }
            switch (args[0].ToLower())
                    {
                        case "dv":
                            Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Comparte nuestro servidor en al menos 5 grupos﹣  "+azulclaro+"Facebook" +grisclaro+ "/"+azulclaro+"Discord");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Contacta a uno de los responsables ﹣  "+azulclaro+"/contato");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Presentar fotos publicitarias de todos los grupos publicitados ");
                            Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            break;
                        case "yt":
                            Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Grabe y publique un video presentando nuestro servidor ");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "El video debe tener al menos  "+azulclaro+"3 minutos" +grisclaro+ " de duracion");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Contacta a uno de los responsables ﹣  "+azulclaro+"/contato");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Muestra el video y espera a que sea aprobado");
                            Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            break;
                        case "mod":
                            Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Se requieren conocimientos de búsqueda hacks/pogramas maliciosos");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Edad minima requirida ﹣  "+azulclaro+" 18 años");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Contacta a uno de los responsables ﹣  "+azulclaro+" /contato");
                            Player.MessageFrom("[" + TAG + "]",  rojo + "➤  " +grisclaro+ "Serás sometido a una prueba de búsqueda.");
                            Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            break;
                        default:
                            {
                                Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                                Player.MessageFrom("[" + TAG + "]", rojo + "➤  "  +grisclaro+ "/tags dv﹣  "  +azulclaro+ "utiliza para ver los requisitos de un divulgador ");
                                Player.MessageFrom("[" + TAG + "]", rojo + "➤  "  +grisclaro+ "/tags yt﹣  "  +azulclaro+ "utiliza para ver los requisitos de un youtuber");
                                Player.MessageFrom("[" + TAG + "]", rojo + "➤  "  +grisclaro+ "/tags mod﹣  "  +azulclaro+ "utiliza para ver los requisitos de un moderador");
                                Player.MessageFrom("[" + TAG + "]", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                                break;
                            }
                    }
                
            }
    }